
Public Class frmAssemblyTools


#Region "Variaveis e Objetos"
    Private frmAssemblyToolsLoaded As Boolean
    Private frmAssemblyToolsOriginalSize As System.Drawing.Size
    Public ListContents() As NodeContent
    Private projectPath As String
    Private currentAssemblyFullPath As String
    Private AssemblyAtual As Inventor.AssemblyDocument
    Private DocumentosReferenciados As Inventor.DocumentsEnumerator

    Dim ErrorLog As System.IO.StreamWriter
    Dim ImportLog As System.IO.StreamWriter

    Public Shared ThisApplication As Inventor.Application

    Public Class CSVRow
        Public NomeArquivoOriginal As String
        Public NovoNomeArquivo As String
    End Class

    Public Class NodeContent
        Public NomeArquivoOriginal As String
        Public NovoNomeArquivo As String
        Public HasIDW As Boolean
        Public IsLibrary As Boolean
        Public CaminhoCompleto As String
        Public NovoCaminhoCompleto As String
        Public CaminhoCompletoIDW As String
        Public NovoCaminhoCompletoIDW As String
        Public imageIDX As String
    End Class

    Class ListSorterIdx : Implements IComparer
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim xObj As NodeContent = DirectCast(x, NodeContent)
            Dim yObj As NodeContent = DirectCast(y, NodeContent)
            Return New CaseInsensitiveComparer().Compare(xObj.imageIDX, yObj.imageIDX)
        End Function
    End Class

#End Region

#Region "Subs e Funções"
    Private Sub frmAssemblyTools_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Seta no escopo do Form a aplicação do inventor
            ThisApplication = PDFemMassa.StandardAddInServer.m_inventorApplication

            frmAssemblyToolsLoaded = True
            frmAssemblyToolsOriginalSize = Me.Size

            tlvMain.Columns.Clear()
            tlvMain.Columns.Add("Original Filename", 300, Windows.Forms.HorizontalAlignment.Left)
            tlvMain.Columns.Add("New Filename", 250, Windows.Forms.HorizontalAlignment.Left)
            tlvMain.Columns.Add("IDW?", 50, Windows.Forms.HorizontalAlignment.Center)
            tlvMain.Columns.Add("Library?", 50, Windows.Forms.HorizontalAlignment.Center)
            tlvMain.Columns.Add("Complete Filepath", 150, Windows.Forms.HorizontalAlignment.Left)

            'Loads the data 
            LoadTree()

            'Loads project path in txtProject
            txtProject.Text = ThisApplication.DesignProjectManager.ActiveDesignProject.FullFileName

            'Loads the packandgo path in textbox
            txtBkpPath.Text = My.Settings.PackAndGoPath
            txtTemplate.Text = My.Settings.IDWTemplatePath
            chkDesenhosVazios.Checked = My.Settings.chkCopyDrawing

            'Gets the size of the backup folder
            Dim d As New System.IO.DirectoryInfo(txtBkpPath.Text)
            Dim s As Long
            s = DirSize(d)
            If s > 1073741824 Then
                lblBkp.Text = "Backup Folder (" & Trim(Str(Int(s * 10 / 1073741824) / 10)) & " GB):"
            Else
                lblBkp.Text = "Backup Folder (" & Trim(Str(Int(s * 10 / 1048576) / 10)) & " MB):"
            End If

        Catch ex As Exception
            WriteErrorLine(ex, "==========[L84] Error opening the batch renamer form (frmAssemblyTools)==========")
        End Try
    End Sub

    Private Sub frmAssemblyTools_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Tamanho mínimo do form
        If Me.Height < 578 Then Me.Height = 578
        If Me.Width < 651 Then Me.Width = 651

        If frmAssemblyToolsLoaded Then
            'Ajusta os componentes na altura
            tlvMain.Height = tlvMain.Height - frmAssemblyToolsOriginalSize.Height + Me.Height
            grpOptions.Top = grpOptions.Top - frmAssemblyToolsOriginalSize.Height + Me.Height
            grpPanG.Top = grpPanG.Top - frmAssemblyToolsOriginalSize.Height + Me.Height
            cmdPEG.Top = cmdPEG.Top - frmAssemblyToolsOriginalSize.Height + Me.Height
            cmdApply.Top = cmdApply.Top - frmAssemblyToolsOriginalSize.Height + Me.Height

            'Ajusta os componentes na largura
            tlvMain.Width = tlvMain.Width - frmAssemblyToolsOriginalSize.Width + Me.Width
            frmAssemblyToolsOriginalSize = Me.Size
        End If
    End Sub

    Private Function CheckIfIsInLibrary(Path As String) As Boolean
        'This function will look the active project and review the library paths
        Dim CurrentPath As String

        For Each LibPath As Inventor.ProjectPath In ThisApplication.DesignProjectManager.ActiveDesignProject.LibraryPaths
            CurrentPath = LibPath.Path
            If Strings.Left(CurrentPath, 1) = "." Then
                CurrentPath = CaminhoArquivo(ThisApplication.DesignProjectManager.ActiveDesignProject.FullFileName) & Strings.Right(CurrentPath, Len(CurrentPath) - 2)
            End If

            If Path.Contains(CurrentPath) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub LoadTree()
        'Descobre quantos arquivos tem para imprimir
        Dim DocumentoAtual As Inventor.Document
        Dim DocumentoEncontrado As Inventor.Document

        Dim NFiles As Double
        Dim N As Double
        Dim ArquivosAdicionados As Long = 0
        Dim DrawingPaths() As String
        Dim ListaArquivosNaoAdicionados As String = ""
        Dim NewNode As WinControls.ListView.TreeListNode
        Dim isPart As Boolean
        Dim isAssembly As Boolean
        Dim imageIdx As Long
        Dim Node As New NodeContent
        Dim IDWFileName As String = ""

        Try
            DocumentoAtual = ThisApplication.ActiveDocument
            If IsNothing(DocumentoAtual) Then
                MsgBox("No current open documents!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                Me.Close()
                Exit Sub
            End If

            If DocumentoAtual.DocumentType = Inventor.DocumentTypeEnum.kAssemblyDocumentObject Then
                AssemblyAtual = DocumentoAtual
                currentAssemblyFullPath = AssemblyAtual.FullFileName

                'Pesquisa todos os arquivos referenciados (parts e assemblies)
                DocumentosReferenciados = AssemblyAtual.AllReferencedDocuments
                NFiles = DocumentosReferenciados.Count
                ReDim DrawingPaths(NFiles - 1)
                ReDim ListContents(NFiles - 1)

                N = 0

                For Each DocumentoEncontrado In DocumentosReferenciados
                    ListContents(N) = New NodeContent
                    ListContents(N).NomeArquivoOriginal = NomeDoArquivoSemExtensao(DocumentoEncontrado.FullFileName)
                    isPart = (DocumentoEncontrado.DocumentType = Inventor.DocumentTypeEnum.kPartDocumentObject)
                    isAssembly = (DocumentoEncontrado.DocumentType = Inventor.DocumentTypeEnum.kAssemblyDocumentObject)

                    imageIdx = 0
                    If isPart Then
                        imageIdx = 2
                    ElseIf isAssembly Then
                        imageIdx = 1
                    End If

                    ListContents(N).imageIDX = imageIdx
                    ListContents(N).NovoNomeArquivo = ""
                    ListContents(N).HasIDW = findIDW(DocumentoEncontrado.FullFileName, IDWFileName)
                    ListContents(N).IsLibrary = CheckIfIsInLibrary(DocumentoEncontrado.FullFileName)
                    ListContents(N).CaminhoCompleto = DocumentoEncontrado.FullFileName
                    ListContents(N).CaminhoCompletoIDW = IDWFileName

                    N = N + 1
                Next
                Array.Sort(ListContents, New ListSorterIdx)

                'Fills up the treeview
                tlvMain.Nodes.Clear()
                For Each Element As NodeContent In ListContents
                    NewNode = tlvMain.Nodes.Add(Element.NomeArquivoOriginal)
                    NewNode.ImageIndex = Element.imageIDX
                    NewNode.SelectedImageIndex = Element.imageIDX
                    NewNode.SubItems.Add(Element.NovoNomeArquivo)
                    NewNode.SubItems.Add(Element.HasIDW)
                    NewNode.SubItems.Add(Element.IsLibrary)
                    NewNode.SubItems.Add(Element.CaminhoCompleto)
                Next
            Else
                MsgBox("The current document is not an assembly!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                Me.Close()
            End If
        Catch ex As Exception
            WriteErrorLine(ex, "==========[L201] Generic error loading the assembly tree==========")
        End Try
    End Sub

    Private Function findIDW(FullFileName As String, ByRef IDWFullFileNameOut As String) As Boolean
        'Essa função tenta achar um IDW na pasta com o mesmo nome do arquivo original e retorna T/F
        Dim NomeArquivoIDW As String
        NomeArquivoIDW = NomeDoArquivoSemExtensao(FullFileName) & ".idw"
        IDWFullFileNameOut = CaminhoArquivo(FullFileName) & NomeArquivoIDW

        Try
            findIDW = FileIO.FileSystem.FileExists(IDWFullFileNameOut)
        Catch ex As Exception
            WriteErrorLine(ex, "==========[L214] Error checking the IDW in the file " & NomeArquivoIDW & "==========")
        End Try
    End Function

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        'Asks the user for confirmation and performs the modifications needed
        Dim I, J, K As Long
        Dim TempString As String

        Try
            If MsgBox("Are you sure? You will not be able to undo this action!" & vbCrLf & "The current assembly will be saved and closed. Continue?", vbYesNo, "Confirmation") = vbYes Then
                Me.Text = "Batch Renamer - Performing Pack and Go..."
                Dim itemsToModify As Long
                itemsToModify = 0

                'Counts the items to modify in the list
                For I = 0 To UBound(ListContents)
                    'For each file in the list:
                    If Not ((ListContents(I).IsLibrary And Not (chkLibraryAccess.Checked))) Then 'Denies modification if not modifying library and is a library item
                        'If there is any change:
                        If ListContents(I).NovoNomeArquivo <> "" Then
                            itemsToModify = itemsToModify + 1
                        End If
                    End If
                Next

                If itemsToModify = 0 Then MsgBox("Nothing to change!", vbOKOnly, "No action")

                ThisApplication.SilentOperation = True
                'Performs a pack and go
                Dim Res As String
                Res = CreatePackAndGo() '**************************THIS CAUSES AN ERROR IN DEBUG BUT WORKS FINE OUTSIDE THE DEBUG ENVIRONMENT, SO COMMENT OUT FOR DEBUG
                If Res = "" Then
                    If MsgBox("Error! The Pack and Go files couldn't be created. Abort?", vbYesNo, "Pack and Go error") = vbYes Then
                        Exit Sub
                    End If
                End If

                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Does the shit~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                '============Copies files==========
                Me.Text = "Batch Renamer - Copying Files..."
                'First creates an empty drawing document (the empty drawing)
                Dim EmptyDrawing As Inventor.DrawingDocument
                Dim EmptyDrawingFullFileName As String = ""
                If chkDesenhosVazios.Checked Then
                    Try
                        EmptyDrawingFullFileName = CaminhoArquivo(currentAssemblyFullPath) & "EmptyDrawing.idw"

                        EmptyDrawing = ThisApplication.Documents.Add(Inventor.DocumentTypeEnum.kDrawingDocumentObject, txtTemplate.Text, False)
                        EmptyDrawing.SaveAs(EmptyDrawingFullFileName, True)
                        EmptyDrawing.Close()
                    Catch ex As Exception
                        WriteErrorLine(ex, "==========[L267] Error creating a new empty drawing file==========")
                        chkDesenhosVazios.Checked = False
                    End Try
                End If

                For I = 0 To UBound(ListContents)
                    'For each file in the list:
                    If Not ((ListContents(I).IsLibrary And Not (chkLibraryAccess.Checked))) Then 'Denies modification if not modifying library and is a library item
                        'If there is any change:
                        If ListContents(I).NovoNomeArquivo <> "" Then
                            Try
                                'Copies the file with a new name
                                If System.IO.File.Exists(ListContents(I).NovoCaminhoCompleto) Then
                                    System.IO.File.Delete(ListContents(I).NovoCaminhoCompleto)
                                End If
                                System.IO.File.Copy(ListContents(I).CaminhoCompleto, ListContents(I).NovoCaminhoCompleto)

                                'Creates an empty drawing or copies the existing drawing
                                If ListContents(I).HasIDW Then
                                    'It supposedly has an existing idw, so copies it
                                    If System.IO.File.Exists(ListContents(I).NovoCaminhoCompletoIDW) Then
                                        System.IO.File.Delete(ListContents(I).NovoCaminhoCompletoIDW)
                                    End If
                                    System.IO.File.Copy(ListContents(I).CaminhoCompletoIDW, ListContents(I).NovoCaminhoCompletoIDW)
                                Else
                                    'It doesn't have an existing idw, so creates a brand new one
                                    If chkDesenhosVazios.Checked Then
                                        If System.IO.File.Exists(ListContents(I).NovoCaminhoCompletoIDW) Then
                                            System.IO.File.Delete(ListContents(I).NovoCaminhoCompletoIDW)
                                        End If
                                        System.IO.File.Copy(EmptyDrawingFullFileName, ListContents(I).NovoCaminhoCompletoIDW)
                                    End If
                                End If
                            Catch ex As Exception
                                WriteErrorLine(ex, "==========[L301] Error trying to copy the original file or trying to generate a new IDW file from " & ListContents(I).CaminhoCompleto & " to " & ListContents(I).NovoCaminhoCompleto & "==========")
                            End Try
                        End If
                    End If
                    TempString = "Batch Renamer - Copying Files... " & Trim(Str(I + 1)) & "/" & Trim(Str(UBound(ListContents) + 1))
                    Me.Text = TempString
                Next
                If chkDesenhosVazios.Checked Then
                    System.IO.File.Delete(EmptyDrawingFullFileName)
                End If

                '==============Replaces all the references in the parts/assemblies===================
                Me.Text = "Batch Renamer - Redoing References inside Copied Files (Parts/Assemblies)..."
                Dim drawingDoc As Inventor._Document
                Dim optionsOpen As Inventor.NameValueMap
                optionsOpen = ThisApplication.TransientObjects.CreateNameValueMap
                optionsOpen.Add("SkipAllUnresolvedFiles", True)

                For I = 0 To UBound(ListContents)
                    'For each file in the list:
                    If Not ((ListContents(I).IsLibrary And Not (chkLibraryAccess.Checked))) Then 'Denies modification if not modifying library and is a library item
                        'If there is any change:
                        Try
                            If ListContents(I).NovoNomeArquivo <> "" Then
                                'Opens the new file if it is marked to be renamed
                                drawingDoc = ThisApplication.Documents.OpenWithOptions(ListContents(I).NovoCaminhoCompleto, optionsOpen, False)
                            Else
                                'Opens the old file if it is NOT marked to be renamed
                                drawingDoc = ThisApplication.Documents.OpenWithOptions(ListContents(I).CaminhoCompleto, optionsOpen, False)
                            End If
                        Catch ex As Exception
                            WriteErrorLine(ex, "==========[L332] Error trying to open the file " & drawingDoc.FullFileName & "==========")
                        End Try

                        'replaces the required references in the copy according to the new list
                        For Each refDoc As Inventor.DocumentDescriptor In drawingDoc.ReferencedDocumentDescriptors
                            For J = 0 To UBound(ListContents)
                                'For each file in the list that needs to be replaced:
                                If Not ((ListContents(J).IsLibrary And Not (chkLibraryAccess.Checked))) Then 'Denies modification if not modifying library and is a library item
                                    If ListContents(J).NovoNomeArquivo <> "" Then
                                        If refDoc.ReferencedFileDescriptor.FullFileName = ListContents(J).CaminhoCompleto Then
                                            Try
                                                refDoc.ReferencedFileDescriptor.ReplaceReference(ListContents(J).NovoCaminhoCompleto)
                                            Catch ex As Exception
                                                WriteErrorLine(ex, "==========[L345] Error trying to replace reference from " & refDoc.ReferencedFileDescriptor.FullFileName & " to " & ListContents(J).NovoCaminhoCompleto & "==========")
                                            End Try
                                        End If
                                    End If
                                End If
                            Next
                        Next
                        drawingDoc.Save2()
                        drawingDoc.Close()
                        'End If
                    End If
                    TempString = "Batch Renamer - Redoing References inside Copied Files (Parts/Assemblies)..." & Trim(Str(I + 1)) & "/" & Trim(Str(UBound(ListContents) + 1))
                    Me.Text = TempString
                Next

                'Goes through all the referenced files in the assembly and replaces the references in the assembly
                Me.Text = "Batch Renamer - Relinking References on the Top-Level Assembly..."
                'First closes it without saving
                Dim AssemblyFilePath As String = AssemblyAtual.FullFileName
                Dim Docum As Inventor.DocumentDescriptor

                AssemblyAtual.Save2()
                AssemblyAtual.Close(True)

                drawingDoc = ThisApplication.Documents.OpenWithOptions(AssemblyFilePath, optionsOpen, False)

                Try
                    K = 0
                    For Each Docum In drawingDoc.ReferencedDocumentDescriptors
                        For J = 0 To UBound(ListContents)
                            'For each file in the list that needs to be replaced:
                            If Not ((ListContents(J).IsLibrary And Not (chkLibraryAccess.Checked))) Then 'Denies modification if not modifying library and is a library item
                                If ListContents(J).NovoNomeArquivo <> "" Then
                                    If Docum.ReferencedFileDescriptor.FullFileName = ListContents(J).CaminhoCompleto Then
                                        Try
                                            Docum.ReferencedFileDescriptor.ReplaceReference(ListContents(J).NovoCaminhoCompleto)
                                        Catch ex As Exception
                                            WriteErrorLine(ex, "==========[L379] Error trying to replace reference from " & Docum.ReferencedFileDescriptor.FullFileName & " to " & ListContents(J).NovoCaminhoCompleto & "==========")
                                        End Try
                                    End If
                                End If
                            End If
                        Next
                        K = K + 1
                        TempString = "Batch Renamer - Relinking References on the Top-Level Assembly..." & Trim(Str(K + 1)) & "/" & Trim(Str(drawingDoc.ReferencedDocumentDescriptors.Count))
                        Me.Text = TempString
                    Next
                Catch ex As Exception
                    WriteErrorLine(ex, "==========[L390] Generic reference replacement error==========")
                End Try

                '============Saves assembly=============
                Me.Text = "Batch Renamer - Saving the Top Level Assembly..."
                drawingDoc.Update2()
                drawingDoc.Save2()


                '==============Replaces all the references in the drawings===================
                Me.Text = "Batch Renamer - Redoing References on the Drawing Files (IDWs)..."

                For I = 0 To UBound(ListContents)
                    'For each file in the list:
                    If Not ((ListContents(I).IsLibrary And Not (chkLibraryAccess.Checked))) Then 'Denies modification if not modifying library and is a library item
                        'If there is any change:
                        If ListContents(I).NovoNomeArquivo <> "" Then
                            If ListContents(I).HasIDW Then 'It needs to have already had an existing IDW file
                                'It supposedly has an existing idw, so copies it
                                If System.IO.File.Exists(ListContents(I).NovoCaminhoCompletoIDW) Then
                                    'opens the copy on the apprentice
                                    drawingDoc = ThisApplication.Documents.OpenWithOptions(ListContents(I).NovoCaminhoCompletoIDW, optionsOpen, False)


                                    'replaces the required references in the copy according to the new list
                                    For Each refDoc As Inventor.DocumentDescriptor In drawingDoc.ReferencedDocumentDescriptors
                                        For J = 0 To UBound(ListContents)
                                            'For each file in the list that needs to be replaced:
                                            If Not ((ListContents(J).IsLibrary And Not (chkLibraryAccess.Checked))) Then 'Denies modification if not modifying library and is a library item
                                                If ListContents(J).NovoNomeArquivo <> "" Then
                                                    If refDoc.ReferencedFileDescriptor.FullFileName = ListContents(J).CaminhoCompleto Then
                                                        Try
                                                            refDoc.ReferencedFileDescriptor.ReplaceReference(ListContents(J).NovoCaminhoCompleto)
                                                        Catch ex As Exception
                                                            WriteErrorLine(ex, "==========[L424] Error trying to replace reference from " & refDoc.ReferencedFileDescriptor.FullFileName & " to " & ListContents(J).NovoCaminhoCompleto & "==========")
                                                        End Try
                                                    End If
                                                End If
                                            End If
                                        Next
                                    Next
                                    drawingDoc.Update2()
                                    drawingDoc.Save2()
                                    drawingDoc.Close()
                                End If
                            End If
                        End If
                    End If
                    TempString = "Batch Renamer - Redoing References on the Drawing Files (IDWs)..." & Trim(Str(I + 1)) & "/" & Trim(Str(UBound(ListContents) + 1))
                    Me.Text = TempString
                Next



                '==========Deletes files=============
                Me.Text = "Batch Renamer - Deleting Old Files..."
                Try
                    For I = 0 To UBound(ListContents)
                        If Not ((ListContents(I).IsLibrary And Not (chkLibraryAccess.Checked))) Then
                            If ListContents(I).NovoNomeArquivo <> "" Then
                                If ListContents(I).NovoNomeArquivo <> AssemblyFilePath Then 'Cannot delete its own path!!!
                                    System.IO.File.Delete(ListContents(I).CaminhoCompleto)
                                    If ListContents(I).HasIDW Then
                                        System.IO.File.Delete(ListContents(I).CaminhoCompletoIDW)
                                    End If
                                End If
                            End If
                        End If
                        TempString = "Batch Renamer - Deleting Old Files..." & Trim(Str(I + 1)) & "/" & Trim(Str(UBound(ListContents) + 1))
                        Me.Text = TempString
                    Next
                Catch ex As Exception
                    WriteErrorLine(ex, "==========[L463] Error trying to delete original files (old names)==========")
                End Try

                Me.Text = "Batch Renamer"
                MsgBox("Operation completed successfully." & vbNewLine & Trim(Str(itemsToModify)) & " files were renamed and relinked.", vbInformation + vbOKOnly, "Sucess")

                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            WriteErrorLine(ex, "==========[L464] Error trying to replace the references.==========")
        End Try

        If Not IsNothing(ErrorLog) Then
            MsgBox("Errors occured during the operation." & vbNewLine & "Please review carefully the Errorlog.txt file inside the assembly root folder to check the errors that occured.")
            ThisApplication.SilentOperation = False
            Me.Close()
        End If

        ThisApplication.SilentOperation = False
    End Sub

    Private Sub cmdEditPathPanG_Click(sender As Object, e As EventArgs) Handles cmdEditPathPanG.Click
        'Edits and saves the path in the settings
        Dim selPath As String
        Try
            fldDiag.ShowNewFolderButton = True
            fldDiag.ShowDialog()
            selPath = fldDiag.SelectedPath

            txtBkpPath.Text = selPath
            My.Settings.PackAndGoPath = selPath
            My.Settings.Save()
        Catch ex As Exception
            WriteErrorLine(ex, "==========[L488] Error trying to edit the output path of the Pack and Go folder==========")
        End Try
    End Sub

    Private Function CreatePackAndGo() As String
        'Code snippet from http://adndevblog.typepad.com/manufacturing/2013/05/use-packandgo-of-2014-api.html
        Dim PeGComp As New PackAndGoLib.PackAndGoComponent
        Dim PeG As PackAndGoLib.PackAndGo
        Dim newPath As String
        Dim assemblyName As String
        Dim datetimenow As String

        datetimenow = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
        datetimenow = datetimenow.Replace("-", "")
        datetimenow = datetimenow.Replace(":", "")
        datetimenow = datetimenow.Replace(" ", "")

        assemblyName = NomeDoArquivoSemExtensao(currentAssemblyFullPath)
        newPath = FileIO.FileSystem.CombinePath(txtBkpPath.Text, datetimenow & "_" & assemblyName)
        System.IO.Directory.CreateDirectory(newPath)

        Try

            PeG = PeGComp.CreatePackAndGo(currentAssemblyFullPath, newPath)
            'PeG.ProjectFile = txtProject.Text
            'Dim sRefFiles = New String() {}
            Dim sRefFiles(0) As String
            Dim sMissFiles = New Object

            '  Set the options
            PeG.SkipLibraries = False
            PeG.SkipStyles = True
            PeG.SkipTemplates = True
            PeG.CollectWorkgroups = False
            PeG.KeepFolderHierarchy = True
            PeG.IncludeLinkedFiles = True

            Dim i As Long

            For i = 0 To UBound(ListContents)
                ReDim Preserve sRefFiles(UBound(sRefFiles) + 1)
                sRefFiles(UBound(sRefFiles)) = ListContents(i).CaminhoCompleto
                If ListContents(i).HasIDW Then
                    ReDim Preserve sRefFiles(UBound(sRefFiles) + 1)
                    sRefFiles(UBound(sRefFiles)) = ListContents(i).CaminhoCompletoIDW
                End If
            Next
            sRefFiles(0) = currentAssemblyFullPath
            'adds the current assembly idw
            Dim IDWPath As String
            IDWPath = Mid(currentAssemblyFullPath, 1, Len(currentAssemblyFullPath) - 4) & ".idw"

            If System.IO.File.Exists(IDWPath) Then
                ReDim Preserve sRefFiles(UBound(sRefFiles) + 1)
                sRefFiles(UBound(sRefFiles)) = IDWPath
            End If


            '  Add the referenced files for package
            PeG.AddFilesToPackage(sRefFiles)

            ' Start the pack and go to create the package
            PeG.CreatePackage()
            CreatePackAndGo = newPath
        Catch ex As Exception
            WriteErrorLine(ex, "==========[L553] Error occured while trying to perform the Pack and Go operation==========")
            MsgBox("Couldn't perform the Pack and Go operation. Please review whether the given folder" & vbCrLf & " exists e whether this program has user permission to access it." & vbCrLf &
                    "Error description:" & vbCrLf & ex.Message, vbCritical + vbOKOnly, "PackAndGo Error")
            CreatePackAndGo = ""
        End Try
    End Function

    Private Sub RenomearArquivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenomearArquivoToolStripMenuItem.Click
        'This will rename the selected treelistview node (if more than one, will rename all)
        Dim selnode As WinControls.ListView.TreeListNode
        Dim newName, DestinationFileName As String

        Try
            For Each selnode In tlvMain.SelectedItems
                newName = InputBox("Please enter a new name for this file", "Rename file")

                If ValidarNomeArquivo(newName) Then
                    selnode.Font = New System.Drawing.Font(selnode.Font, System.Drawing.FontStyle.Bold)
                    selnode.SubItems(0).Text = newName
                    ListContents(selnode.Index).NovoNomeArquivo = newName
                    DestinationFileName = System.IO.Path.Combine(CaminhoArquivo(ListContents(selnode.Index).CaminhoCompleto), ListContents(selnode.Index).NovoNomeArquivo)
                    DestinationFileName = DestinationFileName & "." & ExtensaoArquivo(ListContents(selnode.Index).CaminhoCompleto)
                    ListContents(selnode.Index).NovoCaminhoCompleto = DestinationFileName
                    ListContents(selnode.Index).NovoCaminhoCompletoIDW = System.IO.Path.Combine(CaminhoArquivo(ListContents(selnode.Index).CaminhoCompleto), ListContents(selnode.Index).NovoNomeArquivo) & ".idw"

                    If selnode.SubItems(2).Text = "True" Then selnode.ForeColor = System.Drawing.Color.Red
                Else
                    MsgBox("Invalid filename!", vbOKOnly, "Renaming error")
                End If
            Next
        Catch ex As Exception
            WriteErrorLine(ex, "==========[L584] Error when tagging a file to be renamed==========")
        End Try

    End Sub

    Private Sub NãoRenomearArquivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NãoRenomearArquivoToolStripMenuItem.Click
        'This will cancel the rename for the selected treelistview node (if more than one, will do in all nodes)
        Dim selnode As WinControls.ListView.TreeListNode

        Try
            For Each selnode In tlvMain.SelectedItems
                selnode.Font = New System.Drawing.Font(selnode.Font, System.Drawing.FontStyle.Regular)
                selnode.ForeColor = System.Drawing.Color.Black
                selnode.SubItems(0).Text = ""
                ListContents(selnode.Index).NovoNomeArquivo = ""
                ListContents(selnode.Index).NovoCaminhoCompleto = ""
                ListContents(selnode.Index).NovoCaminhoCompletoIDW = ""
            Next
        Catch ex As Exception
            WriteErrorLine(ex, "==========[L603] Error trying to remove a renaming file tag==========")
        End Try
    End Sub

    Private Function ValidarNomeArquivo(ByVal fileName As String) As Boolean
        'Verify invalid chars in filename
        Dim c As Char
        For Each c In System.IO.Path.GetInvalidFileNameChars()
            If fileName.Contains(c) Then Return False
        Next
        If fileName = "" Then Return False

        Dim I As Long
        For I = 0 To UBound(ListContents)
            If ListContents(I).NomeArquivoOriginal = fileName Then Return False 'Verify whether new filename exists already in the old assembly
            If ListContents(I).NovoNomeArquivo = fileName Then Return False 'Verify whether new filename is duplicate with another new filename
        Next

        Return True
    End Function

    Private Sub cmdCsv_Click(sender As Object, e As EventArgs) Handles cmdCsv.Click
        Dim ArquivoSel As String
        Dim SkippedRows As New System.Collections.Generic.Dictionary(Of Long, CSVRow)
        Dim RowsToAdd As New System.Collections.Generic.Dictionary(Of Long, CSVRow)
        Dim IncompleteCSV As Boolean

        Dim k As Long

        FOpen.CheckFileExists = True
        FOpen.ShowDialog()

        ArquivoSel = FOpen.FileName
        IncompleteCSV = False

        If FileIO.FileSystem.FileExists(ArquivoSel) Then
            Using Reader As New Microsoft.VisualBasic.FileIO.TextFieldParser(ArquivoSel, System.Text.Encoding.GetEncoding("Windows-1252"))
                Reader.TextFieldType = FileIO.FieldType.Delimited
                Reader.SetDelimiters({";", vbTab, ","})
                Dim currentRow As String()
                k = 0

                'Reads data from file
                While Not Reader.EndOfData
                    Try
                        currentRow = Reader.ReadFields()
                        If UBound(currentRow) = 1 Then
                            Dim TempRow As New CSVRow
                            Dim Last4Chars As String

                            Last4Chars = ""
                            If Len(currentRow(0)) > 4 Then Last4Chars = Mid(currentRow(0), Len(currentRow(0)) - 3, 4)
                            If Last4Chars = ".iam" Or Last4Chars = ".ipt" Then
                                TempRow.NomeArquivoOriginal = Mid(currentRow(0), 1, Len(currentRow(0)) - 4)
                            Else
                                TempRow.NomeArquivoOriginal = currentRow(0)
                            End If

                            Last4Chars = ""
                            If Len(currentRow(1)) > 4 Then Last4Chars = Mid(currentRow(1), Len(currentRow(1)) - 3, 4)
                            If Last4Chars = ".iam" Or Last4Chars = ".ipt" Then
                                TempRow.NovoNomeArquivo = Mid(currentRow(1), 1, Len(currentRow(1)) - 4)
                            Else
                                TempRow.NovoNomeArquivo = currentRow(1)
                            End If


                            RowsToAdd.Add(k, TempRow)
                            k = k + 1
                        Else
                                IncompleteCSV = True
                        End If
                    Catch ex As Exception
                        WriteErrorLine(ex, "==========[L676] Error trying to read a CSV file==========")
                    End Try
                End While
            End Using

            'Looks up all data collected in the table and makes the replacements
            Dim CurrentNode As WinControls.ListView.TreeListNode
            Dim DestinationFileName As String
            Dim FileAdded As Boolean
            Dim NonMatchList As New System.Collections.Generic.List(Of Long)

            For Each k In RowsToAdd.Keys
                FileAdded = False
                For Each CurrentNode In tlvMain.Nodes
                    If Trim(CurrentNode.Text.ToUpper) = Trim(RowsToAdd.Item(k).NomeArquivoOriginal.ToUpper) Then 'Case insensitive comparison
                        If ValidarNomeArquivo(RowsToAdd.Item(k).NovoNomeArquivo) Then 'Confirms there is no repeating/invalid chars
                            'It's a match, replace the entry and make it bold
                            ListContents(CurrentNode.Index).NovoNomeArquivo = RowsToAdd.Item(k).NovoNomeArquivo
                            DestinationFileName = System.IO.Path.Combine(CaminhoArquivo(ListContents(CurrentNode.Index).CaminhoCompleto), ListContents(CurrentNode.Index).NovoNomeArquivo)
                            DestinationFileName = DestinationFileName & "." & ExtensaoArquivo(ListContents(CurrentNode.Index).CaminhoCompleto)
                            ListContents(CurrentNode.Index).NovoCaminhoCompleto = DestinationFileName
                            ListContents(CurrentNode.Index).NovoCaminhoCompletoIDW = System.IO.Path.Combine(CaminhoArquivo(ListContents(CurrentNode.Index).CaminhoCompleto), ListContents(CurrentNode.Index).NovoNomeArquivo) & ".idw"

                            CurrentNode.SubItems(0).Text = RowsToAdd.Item(k).NovoNomeArquivo
                            CurrentNode.Font = New System.Drawing.Font(CurrentNode.Font, System.Drawing.FontStyle.Bold)
                            If CurrentNode.SubItems(2).Text = "True" Then CurrentNode.ForeColor = System.Drawing.Color.Red
                            FileAdded = True
                        End If
                    End If
                Next
                If Not FileAdded Then
                    NonMatchList.Add(k)
                End If
            Next

            If NonMatchList.Count > 0 Then
                'Some item has not been added
                Dim NonMatchString As String
                NonMatchString = ""
                For Each i As Long In NonMatchList
                    NonMatchString = NonMatchString & RowsToAdd.Item(i).NomeArquivoOriginal & " para " & RowsToAdd.Item(i).NovoNomeArquivo & vbNewLine
                Next
                MsgBox("The following files weren't added because they don't have corresponding files in the assembly parts list or because there were duplicates:" & vbNewLine & vbNewLine & NonMatchString)
            End If

        End If
    End Sub

    Private Sub WriteErrorLine(ex As Exception, addMessage As String)
        'This writes the error line in an error log 
        Try
            Dim CaminhoErrorLog As String
            If IsNothing(ErrorLog) Then
                CaminhoErrorLog = CaminhoArquivo(currentAssemblyFullPath) & "ErrorLog_RenameFiles_" & NomeDoArquivoSemExtensao(currentAssemblyFullPath) & ".txt"
                ErrorLog = My.Computer.FileSystem.OpenTextFileWriter(CaminhoErrorLog, False)
            End If

            ErrorLog.Write(addMessage)
            ErrorLog.Write(vbNewLine)
            ErrorLog.Write(ex.ToString)
            ErrorLog.Write(vbNewLine)
            ErrorLog.Write(vbNewLine)
        Catch x As Exception
            'This is so bad!!! I don't know what to do then... =P
        End Try
    End Sub

    Private Sub WriteImportLogLine(Message As String)
        'This writes the error line in an error log 
        Dim CaminhoImportLog As String
        If IsNothing(ImportLog) Then
            CaminhoImportLog = CaminhoArquivo(currentAssemblyFullPath) & "ImportLog_RenameFiles_" & NomeDoArquivoSemExtensao(currentAssemblyFullPath) & ".txt"
            ImportLog = My.Computer.FileSystem.OpenTextFileWriter(CaminhoImportLog, False)
        End If

        ImportLog.Write(Message)
        ImportLog.Write(vbNewLine)
    End Sub

    Private Sub frmAssemblyTools_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Unloads the log file
        Try
            ErrorLog.Close()
            ImportLog.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPurge_Click(sender As Object, e As EventArgs) Handles cmdPurge.Click
        If MsgBox("CAUTION: This action will DELETE the contents of the folder:" & vbNewLine & txtBkpPath.Text & vbNewLine & "Proceed?", vbYesNo + vbCritical, "Purger") = vbYes Then
            Try
                If System.IO.Directory.Exists(txtBkpPath.Text) Then
                    If (System.IO.Path.GetPathRoot(txtBkpPath.Text) <> txtBkpPath.Text) And (Environment.SystemDirectory <> txtBkpPath.Text) Then
                        System.IO.Directory.Delete(txtBkpPath.Text, True)
                        System.IO.Directory.CreateDirectory(txtBkpPath.Text)
                        MsgBox("Folder purged successfuly.", vbOKOnly, "Purger")
                        lblBkp.Text = "Backup Folder (0 MB):"
                    End If
                End If
            Catch ex As Exception
                WriteErrorLine(ex, "==========[L777] Error trying to purge the backup Pack and Go folder==========")
            End Try
        End If
    End Sub

    Private Sub cmdTemplate_Click(sender As Object, e As EventArgs) Handles cmdTemplate.Click
        Dim ArquivoSel As String

        OpenIDW.CheckFileExists = True
        OpenIDW.ShowDialog()

        ArquivoSel = OpenIDW.FileName

        If FileIO.FileSystem.FileExists(ArquivoSel) Then
            txtTemplate.Text = ArquivoSel
            My.Settings.IDWTemplatePath = ArquivoSel
            My.Settings.Save()
        End If
    End Sub

    Private Sub chkDesenhosVazios_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkDesenhosVazios.CheckedChanged
        My.Settings.chkCopyDrawing = chkDesenhosVazios.Checked
        My.Settings.Save()
    End Sub

    Private Sub cmdPEG_Click(sender As Object, e As EventArgs) Handles cmdPEG.Click
        'Creates a Pack and Go without executing the whole function

        Try
            fldDiag.ShowNewFolderButton = True
            fldDiag.ShowDialog()

            Dim FileSavePath As String
            FileSavePath = fldDiag.SelectedPath

            Dim Path As String
            'Dim LastFolder As String
            Path = CreatePackAndGo()
            'LastFolder = NomeDaUltimaPasta(Path)

            ' My.Computer.FileSystem.CopyDirectory(Path, FileSavePath & "\" & LastFolder, True)
            My.Computer.FileSystem.CopyDirectory(Path, FileSavePath, True)

            MsgBox("Congratulations! You performed the Pack and Go operation successfuly." & vbCrLf & "NOW BACK TO WORK!")

        Catch ex As Exception
            MsgBox("File copy error. It is possible the new full filenames (plus path) is too long (>248 caracteres). Error string below:" & vbCrLf & vbCrLf & ex.ToString)
        End Try
    End Sub


#End Region
End Class