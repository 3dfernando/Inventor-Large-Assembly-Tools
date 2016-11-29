
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
            tlvMain.Columns.Add("Nome do Arquivo Original", 300, Windows.Forms.HorizontalAlignment.Left)
            tlvMain.Columns.Add("Novo Nome do Arquivo", 250, Windows.Forms.HorizontalAlignment.Left)
            tlvMain.Columns.Add("IDW?", 50, Windows.Forms.HorizontalAlignment.Center)
            tlvMain.Columns.Add("Biblioteca?", 50, Windows.Forms.HorizontalAlignment.Center)
            tlvMain.Columns.Add("Caminho Completo", 150, Windows.Forms.HorizontalAlignment.Left)

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
                lblBkp.Text = "Pasta bkp (" & Trim(Str(Int(s * 10 / 1073741824) / 10)) & " GB):"
            Else
                lblBkp.Text = "Pasta bkp (" & Trim(Str(Int(s * 10 / 1048576) / 10)) & " MB):"
            End If

        Catch ex As Exception
            WriteErrorLine(ex, "==========Erro ao abrir o form AssemblyTools==========")
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
                MsgBox("Não há nenhum documento aberto!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
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
                MsgBox("O documento aberto não é uma montagem!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Me.Close()
            End If
        Catch ex As Exception
            WriteErrorLine(ex, "==========Erro genérico ao carregar a árvore da montagem==========")
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
            WriteErrorLine(ex, "==========Erro durante a checagem de IDW no arquivo " & NomeArquivoIDW & "==========")
        End Try
    End Function

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        'Asks the user for confirmation and performs the modifications needed
        Dim I, J, K As Long
        Dim TempString As String

        Try
            If MsgBox("Você tem certeza? Esta ação é irreversível!", vbYesNo, "Confirmação") = vbYes Then
                Me.Text = "Ferramentas de Montagem - Fazendo Pack and Go..."
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

                If itemsToModify = 0 Then MsgBox("Não há nada a ser modificado!", vbOKOnly, "Sem ações")

                ThisApplication.SilentOperation = True
                'Performs a pack and go
                Dim Res As String
                Res = CreatePackAndGo()
                If Res = "" Then
                    If MsgBox("Erro! O Pack and Go não pôde ser criado. Abortar?", vbYesNo, "Erro do Pack and Go") = vbYes Then
                        Exit Sub
                    End If
                End If

                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Does the shit~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                '============Copies files==========
                Me.Text = "Ferramentas de Montagem - Copiando arquivos..."
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
                        WriteErrorLine(ex, "==========Erro ao criar arquivo de desenho vazio==========")
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
                                WriteErrorLine(ex, "==========Erro ao tentar copiar ou fazer IDW do arquivo " & ListContents(I).CaminhoCompleto & " para " & ListContents(I).NovoCaminhoCompleto & "==========")
                            End Try
                        End If
                    End If
                    TempString = "Ferramentas de Montagem - Copiando arquivos... " & Trim(Str(I + 1)) & "/" & Trim(Str(UBound(ListContents) + 1))
                    Me.Text = TempString
                Next
                If chkDesenhosVazios.Checked Then
                    System.IO.File.Delete(EmptyDrawingFullFileName)
                End If

                '==============Replaces all the references in the parts/assemblies===================
                Me.Text = "Ferramentas de Montagem - Refazendo Referências nas Cópias (Parts/Assemblies)..."
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
                            WriteErrorLine(ex, "==========Erro ao tentar abrir arquivo" & ListContents(I).CaminhoCompleto & " ou " & ListContents(I).NovoCaminhoCompleto & "==========")
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
                                                WriteErrorLine(ex, "==========Erro ao tentar substituir referência de " & refDoc.ReferencedFileDescriptor.FullFileName & " para " & ListContents(J).NovoCaminhoCompleto & "==========")
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
                    TempString = "Ferramentas de Montagem - Refazendo Referências nas Cópias (Parts/Assemblies)..." & Trim(Str(I + 1)) & "/" & Trim(Str(UBound(ListContents) + 1))
                    Me.Text = TempString
                Next

                'Goes through all the referenced files in the assembly and replaces the references in the assembly
                Me.Text = "Ferramentas de Montagem - Refazendo Referências na Montagem Atual..."
                Try
                    K = 0
                    For Each Docum As Inventor.DocumentDescriptor In AssemblyAtual.ReferencedDocumentDescriptors
                        For J = 0 To UBound(ListContents)
                            'For each file in the list that needs to be replaced:
                            If Not ((ListContents(J).IsLibrary And Not (chkLibraryAccess.Checked))) Then 'Denies modification if not modifying library and is a library item
                                If ListContents(J).NovoNomeArquivo <> "" Then
                                    If Docum.ReferencedFileDescriptor.FullFileName = ListContents(J).CaminhoCompleto Then
                                        Try
                                            Docum.ReferencedFileDescriptor.ReplaceReference(ListContents(J).NovoCaminhoCompleto)
                                        Catch ex As Exception
                                            WriteErrorLine(ex, "==========Erro ao tentar substituir referência de " & Docum.ReferencedFileDescriptor.FullFileName & " para " & ListContents(J).NovoCaminhoCompleto & "==========")
                                        End Try
                                    End If
                                End If
                            End If
                        Next
                        K = K + 1
                        TempString = "Ferramentas de Montagem - Refazendo Referências na Montagem Atual..." & Trim(Str(K + 1)) & "/" & Trim(Str(AssemblyAtual.ReferencedDocumentDescriptors.Count))
                        Me.Text = TempString
                    Next
                Catch ex As Exception
                    WriteErrorLine(ex, "==========Erro genérico na substituição de referência==========")
                End Try

                '==============Replaces all the references in the drawings===================
                Me.Text = "Ferramentas de Montagem - Refazendo Referências nas Cópias (Drawings)..."

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
                                                            WriteErrorLine(ex, "==========Erro ao tentar substituir referência de " & refDoc.ReferencedFileDescriptor.FullFileName & " para " & ListContents(J).NovoCaminhoCompleto & "==========")
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
                    TempString = "Ferramentas de Montagem - Refazendo Referências nas Cópias (Drawings)..." & Trim(Str(I + 1)) & "/" & Trim(Str(UBound(ListContents) + 1))
                    Me.Text = TempString
                Next


                '============Saves assembly=============
                Me.Text = "Ferramentas de Montagem - Salvando a Montagem Atual..."
                AssemblyAtual.Update2()
                AssemblyAtual.Save2()

                '==========Deletes files=============
                Me.Text = "Ferramentas de Montagem - Deletando Arquivos Antigos..."
                Try
                    For I = 0 To UBound(ListContents)
                        If Not ((ListContents(I).IsLibrary And Not (chkLibraryAccess.Checked))) Then
                            If ListContents(I).NovoNomeArquivo <> "" Then
                                If ListContents(I).NovoNomeArquivo <> AssemblyAtual.FullFileName Then 'Cannot delete its own path!!!
                                    System.IO.File.Delete(ListContents(I).CaminhoCompleto)
                                    If ListContents(I).HasIDW Then
                                        System.IO.File.Delete(ListContents(I).CaminhoCompletoIDW)
                                    End If
                                End If
                            End If
                        End If
                        TempString = "Ferramentas de Montagem - Deletando Arquivos Antigos..." & Trim(Str(I + 1)) & "/" & Trim(Str(UBound(ListContents) + 1))
                        Me.Text = TempString
                    Next
                Catch ex As Exception
                    WriteErrorLine(ex, "==========Erro ao tentar deletar os arquivos==========")
                End Try

                Me.Text = "Ferramentas de Montagem"
                MsgBox("Itens modificados com sucesso." & vbNewLine & Trim(Str(itemsToModify)) & " arquivos potencialmente foram alterados.", vbInformation + vbOKOnly, "Sucesso")

                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            WriteErrorLine(ex, "==========Erro ao tentar aplicar os vínculos.==========")
        End Try

        If Not IsNothing(ErrorLog) Then
            MsgBox("Ocorreram erros durante a execução." & vbNewLine & "Favor verificar o arquivo ErrorLog.txt na pasta da montagem.")
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
            WriteErrorLine(ex, "==========Erro ao tentar editar o caminho de saída do Pack and Go==========")
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
            WriteErrorLine(ex, "==========Erro ao tentar fazer o Pack and Go==========")
            MsgBox("Não foi possível realizar o Pack and Go. Confira se a pasta" & vbCrLf & " existe e se as permissões de usuário podem acessá-la." & vbCrLf &
                    "Descrição do erro:" & vbCrLf & ex.Message, vbCritical + vbOKOnly, "Erro no PackAndGo")
            CreatePackAndGo = ""
        End Try
    End Function

    Private Sub RenomearArquivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenomearArquivoToolStripMenuItem.Click
        'This will rename the selected treelistview node (if more than one, will rename all)
        Dim selnode As WinControls.ListView.TreeListNode
        Dim newName, DestinationFileName As String

        Try
            For Each selnode In tlvMain.SelectedItems
                newName = InputBox("Entre o nomo nome deste arquivo", "Renomear arquivo")

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
                    MsgBox("Nome de Arquivo Inválido!", vbOKOnly, "Erro ao renomear")
                End If
            Next
        Catch ex As Exception
            WriteErrorLine(ex, "==========Erro ao marcar arquivo para renomeação==========")
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
            WriteErrorLine(ex, "==========Erro ao tentar remover renomeamento de arquivo==========")
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
                        WriteErrorLine(ex, "==========Erro ao ler dados do arquivo CSV==========")
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
                MsgBox("Os arquivos abaixo não foram adicionados por não terem correspondência na lista da montagem ou por serem duplicados:" & vbNewLine & vbNewLine & NonMatchString)
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
            'This is so bad!!!
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
        If MsgBox("Atenção: Esta ação deletará o conteúdo da pasta:" & vbNewLine & txtBkpPath.Text & vbNewLine & "Prosseguir?", vbYesNo + vbCritical, "Purgar") = vbYes Then
            Try
                If System.IO.Directory.Exists(txtBkpPath.Text) Then
                    If (System.IO.Path.GetPathRoot(txtBkpPath.Text) <> txtBkpPath.Text) And (Environment.SystemDirectory <> txtBkpPath.Text) Then
                        System.IO.Directory.Delete(txtBkpPath.Text, True)
                        System.IO.Directory.CreateDirectory(txtBkpPath.Text)
                        MsgBox("Pasta purgada com sucesso!", vbOKOnly, "Purgar")
                        lblBkp.Text = "Pasta bkp (0 MB):"
                    End If
                End If
            Catch ex As Exception
                WriteErrorLine(ex, "==========Erro ao purgar os arquivos da pasta de backup (Pack and Go)==========")
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

            MsgBox("Parabéns! Você fez o Pack & Go com sucesso!" & vbCrLf & "AGORA VOLTE AO TRABALHO.")

        Catch ex As Exception
            MsgBox("Erro na cópia dos arquivos. Possivelmente o caminho dos arquivos está longo demais (>248 caracteres)." & vbCrLf & vbCrLf & ex.ToString)
        End Try
    End Sub


#End Region
End Class