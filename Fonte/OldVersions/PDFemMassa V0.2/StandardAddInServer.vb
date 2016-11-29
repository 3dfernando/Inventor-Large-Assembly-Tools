Imports Inventor
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports Microsoft.VisualBasic.Compatibility
Imports stdole

Namespace PDFemMassa
    <ProgIdAttribute("PDFemMassa.StandardAddInServer"), _
    GuidAttribute("13bb839b-222f-41c7-9662-695f8e12c4f5")> _
    Public Class StandardAddInServer
        Implements Inventor.ApplicationAddInServer

#Region "Variáveis e Objetos"
        ' Inventor application object.
        Public Shared m_inventorApplication As Inventor.Application

        'Botão do PDF em Massa
        Public Shared WithEvents BotaoPDF As ButtonDefinition
        Public WithEvents BotaoSheetMetal As ButtonDefinition

        'Eventos do Inventor
        Private WithEvents Eventos As Inventor.ApplicationEvents

        'GUID do AddIn
        Private ClientId As String

        'Flag do Sheet Metal
        Public Shared AtualizarSheetMetalMontagens As Boolean = False
        Dim TamanhoGrande As Integer = 32
#End Region

#Region "ApplicationAddInServer Members"

        Public Sub Activate(ByVal addInSiteObject As Inventor.ApplicationAddInSite, ByVal firstTime As Boolean) Implements Inventor.ApplicationAddInServer.Activate

            ' This method is called by Inventor when it loads the AddIn.
            ' The AddInSiteObject provides access to the Inventor Application object.
            ' The FirstTime flag indicates if the AddIn is loaded for the first time.

            ' Initialize AddIn members.
            m_inventorApplication = addInSiteObject.Application
            Dim UI As UserInterfaceManager = m_inventorApplication.UserInterfaceManager

            ClientId = AddInGuid(GetType(StandardAddInServer))

            'Implementa um ícone para o botão PDF

            If UI.InterfaceStyle = InterfaceStyleEnum.kRibbonInterface Then
                TamanhoGrande = 32
            Else
                TamanhoGrande = 24
            End If

            Dim ControlDefs As ControlDefinitions = m_inventorApplication.CommandManager.ControlDefinitions

            Dim IconePequeno As stdole.IPictureDisp = _
                Microsoft.VisualBasic.Compatibility.VB6.IconToIPicture( _
                New System.Drawing.Icon(My.Resources.IconePDF, 16, 16))

            Dim IconeGrande As stdole.IPictureDisp = _
                Microsoft.VisualBasic.Compatibility.VB6.IconToIPicture( _
                New System.Drawing.Icon(My.Resources.IconePDF, TamanhoGrande, TamanhoGrande))

            'Implementa o botão PDF
            BotaoPDF = ControlDefs.AddButtonDefinition("Exportação", "adFernandoExport", _
                        CommandTypesEnum.kNonShapeEditCmdType, ClientId, _
                        "Exporta PDFs e Imprime vários arquivos", "Assistente de Exportação", _
                        IconePequeno, IconeGrande, ButtonDisplayEnum.kDisplayTextInLearningMode)

            'Implementa um ícone para o botão SheetMetal

            Dim IconePequeno2 As stdole.IPictureDisp = _
                Microsoft.VisualBasic.Compatibility.VB6.IconToIPicture( _
                New System.Drawing.Icon(My.Resources.IconeSheetMetal, 16, 16))

            Dim IconeGrande2 As stdole.IPictureDisp = _
                Microsoft.VisualBasic.Compatibility.VB6.IconToIPicture( _
                New System.Drawing.Icon(My.Resources.IconeSheetMetal, TamanhoGrande, TamanhoGrande))

            'Implementa o botão SheetMetal
            BotaoSheetMetal = ControlDefs.AddButtonDefinition("Atualizar Chapas", "adFernandoSheetMetal", _
                        CommandTypesEnum.kNonShapeEditCmdType, ClientId, _
                        "Atualiza as chapas nas montagens", "Atualiza as chapas nas montagens", _
                        IconePequeno2, IconeGrande2, ButtonDisplayEnum.kDisplayTextInLearningMode)

            If firstTime Then
                CriaClassica()
                CriaRibbon()
            End If

            Eventos = m_inventorApplication.ApplicationEvents

        End Sub

        Public Sub Deactivate() Implements Inventor.ApplicationAddInServer.Deactivate

            ' This method is called by Inventor when the AddIn is unloaded.
            ' The AddIn will be unloaded either manually by the user or
            ' when the Inventor session is terminated.

            ' TODO:  Add ApplicationAddInServer.Deactivate implementation

            ' Release objects.
            Marshal.ReleaseComObject(m_inventorApplication)
            m_inventorApplication = Nothing

            System.GC.WaitForPendingFinalizers()
            System.GC.Collect()

        End Sub

        Public ReadOnly Property Automation() As Object Implements Inventor.ApplicationAddInServer.Automation

            ' This property is provided to allow the AddIn to expose an API 
            ' of its own to other programs. Typically, this  would be done by
            ' implementing the AddIn's API interface in a class and returning 
            ' that class object through this property.

            Get
                Return Nothing
            End Get

        End Property

        Public Sub ExecuteCommand(ByVal commandID As Integer) Implements Inventor.ApplicationAddInServer.ExecuteCommand

            ' Note:this method is now obsolete, you should use the 
            ' ControlDefinition functionality for implementing commands.

        End Sub

#End Region

#Region "COM Registration"

        ' Registers this class as an AddIn for Inventor.
        ' This function is called when the assembly is registered for COM.
        <ComRegisterFunctionAttribute()> _
        Public Shared Sub Register(ByVal t As Type)

            Dim clssRoot As RegistryKey = Registry.ClassesRoot
            Dim clsid As RegistryKey = Nothing
            Dim subKey As RegistryKey = Nothing

            Try
                clsid = clssRoot.CreateSubKey("CLSID\" + AddInGuid(t))
                clsid.SetValue(Nothing, "Ferramentas de Exportação")
                subKey = clsid.CreateSubKey("Implemented Categories\{39AD2B5C-7A29-11D6-8E0A-0010B541CAA8}")
                subKey.Close()

                subKey = clsid.CreateSubKey("Settings")
                subKey.SetValue("AddInType", "Standard")
                subKey.SetValue("LoadOnStartUp", "1")

                'subKey.SetValue("SupportedSoftwareVersionLessThan", "")
                subKey.SetValue("SupportedSoftwareVersionGreaterThan", "12..")
                'subKey.SetValue("SupportedSoftwareVersionEqualTo", "")
                'subKey.SetValue("SupportedSoftwareVersionNotEqualTo", "")
                'subKey.SetValue("Hidden", "0")
                'subKey.SetValue("UserUnloadable", "1")
                subKey.SetValue("Version", 2)
                subKey.Close()

                subKey = clsid.CreateSubKey("Description")
                subKey.SetValue(Nothing, "Ferramentas de Exportação")

            Catch ex As Exception
                System.Diagnostics.Trace.Assert(False)
            Finally
                If Not subKey Is Nothing Then subKey.Close()
                If Not clsid Is Nothing Then clsid.Close()
                If Not clssRoot Is Nothing Then clssRoot.Close()
            End Try

        End Sub

        ' Unregisters this class as an AddIn for Inventor.
        ' This function is called when the assembly is unregistered.
        <ComUnregisterFunctionAttribute()> _
        Public Shared Sub Unregister(ByVal t As Type)

            Dim clssRoot As RegistryKey = Registry.ClassesRoot
            Dim clsid As RegistryKey = Nothing

            Try
                clssRoot = Microsoft.Win32.Registry.ClassesRoot
                clsid = clssRoot.OpenSubKey("CLSID\" + AddInGuid(t), True)
                clsid.SetValue(Nothing, "")
                clsid.DeleteSubKeyTree("Implemented Categories\{39AD2B5C-7A29-11D6-8E0A-0010B541CAA8}")
                clsid.DeleteSubKeyTree("Settings")
                clsid.DeleteSubKeyTree("Description")
            Catch
            Finally
                If Not clsid Is Nothing Then clsid.Close()
                If Not clssRoot Is Nothing Then clssRoot.Close()
            End Try

        End Sub

        ' This property uses reflection to get the value for the GuidAttribute attached to the class.
        Public Shared ReadOnly Property AddInGuid(ByVal t As Type) As String
            Get
                Dim guid As String = ""
                Try
                    Dim customAttributes() As Object = t.GetCustomAttributes(GetType(GuidAttribute), False)
                    Dim guidAttribute As GuidAttribute = CType(customAttributes(0), GuidAttribute)
                    guid = "{" + guidAttribute.Value.ToString() + "}"
                Finally
                    AddInGuid = guid
                End Try
            End Get
        End Property

#End Region

#Region "Cria Interface (Clássica ou Ribbon)"
        Private Sub CriaRibbon()
            Dim UI As UserInterfaceManager
            UI = m_inventorApplication.UserInterfaceManager


            'Ribbon "Zero Doc"
            Dim RibbonTemp As Ribbon = UI.Ribbons.Item("ZeroDoc")
            'Tab "Getting Started"
            Dim TabTemp As RibbonTab = RibbonTemp.RibbonTabs.Item("id_GetStarted")
            'Painel "Launch"
            Dim PanelTemp As RibbonPanel = TabTemp.RibbonPanels.Item("id_Panel_Launch")
            'Adiciona um separador
            PanelTemp.CommandControls.AddSeparator()
            'Adiciona o botão
            PanelTemp.CommandControls.AddButton(BotaoPDF, True, True)
            PanelTemp.CommandControls.AddButton(BotaoSheetMetal, True, True)


            'Ribbon "Part"
            RibbonTemp = UI.Ribbons.Item("Part")
            'Tab "Tools"
            TabTemp = RibbonTemp.RibbonTabs.Item("id_TabTools")
            'Painel novo, "Exportar"
            PanelTemp = TabTemp.RibbonPanels.Add("Exportar", "adFernandoExportPartPanel", ClientId)
            'Adiciona o botão
            PanelTemp.CommandControls.AddButton(BotaoPDF, True, True)
            PanelTemp.CommandControls.AddButton(BotaoSheetMetal, True, True)

            'Ribbon "Assembly"
            RibbonTemp = UI.Ribbons.Item("Assembly")
            'Tab "Tools"
            TabTemp = RibbonTemp.RibbonTabs.Item("id_TabTools")
            'Painel novo, "Exportar"
            PanelTemp = TabTemp.RibbonPanels.Add("Exportar", "adFernandoExportAssyPanel", ClientId)
            'Adiciona o botão
            PanelTemp.CommandControls.AddButton(BotaoPDF, True, True)
            PanelTemp.CommandControls.AddButton(BotaoSheetMetal, True, True)

            'Ribbon "Drawing"
            RibbonTemp = UI.Ribbons.Item("Drawing")
            'Tab "Tools"
            TabTemp = RibbonTemp.RibbonTabs.Item("id_TabTools")
            'Painel novo, "Exportar"
            PanelTemp = TabTemp.RibbonPanels.Add("Exportar", "adFernandoExportDwgPanel", ClientId)
            'Adiciona o botão
            PanelTemp.CommandControls.AddButton(BotaoPDF, True, True)
            PanelTemp.CommandControls.AddButton(BotaoSheetMetal, True, True)

            'Insere também no menu principal
            Dim MenuPrincipal As CommandControls = UI.FileBrowserControls
            MenuPrincipal.AddButton(BotaoPDF, True, True, "Export", True)

        End Sub

        Private Sub CriaClassica()
            Dim UI As UserInterfaceManager
            UI = m_inventorApplication.UserInterfaceManager

            Dim BarrasFerramentas As CommandBars
            Dim BarraFerramentas As CommandBar

            BarrasFerramentas = UI.CommandBars
            BarraFerramentas = BarrasFerramentas.Add("Assistente de Exportação", "adFernandoExportToolbar", , ClientId)

            BarraFerramentas.Controls.AddButton(BotaoPDF)
            BarraFerramentas.Controls.AddButton(BotaoSheetMetal)

        End Sub
#End Region

#Region "Ações e Métodos"
        Public Shared Sub BotaoPDF_OnExecute(ByVal Context As Inventor.NameValueMap) Handles BotaoPDF.OnExecute
            Dim FormInicio As New frmInicio
            FormInicio.ShowDialog()
        End Sub

        Public Sub BotaoSheetMetal_OnExecute(ByVal Context As Inventor.NameValueMap) Handles BotaoSheetMetal.OnExecute
            If AtualizarSheetMetalMontagens Then
                AtualizarSheetMetalMontagens = False
                BotaoSheetMetal.Pressed = False
            Else
                AtualizarSheetMetalMontagens = True
                BotaoSheetMetal.Pressed = True
            End If
        End Sub

#End Region

#Region "ATUALIZAR PROPRIEDADES DO SHEET METAL"

        Private Sub Eventos_OnSaveDocument(ByVal DocumentObject As Inventor._Document, ByVal BeforeOrAfter As Inventor.EventTimingEnum, ByVal Context As Inventor.NameValueMap, ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles Eventos.OnSaveDocument
            If BeforeOrAfter = EventTimingEnum.kBefore Then
                'Antes de salvar, atualiza as propriedades do documento!
                If DocumentObject.DocumentType = DocumentTypeEnum.kAssemblyDocumentObject And _
                AtualizarSheetMetalMontagens Then
                    For Each Doc As Inventor.Document In DocumentObject.ReferencedDocuments
                        AtualizaSheetMetal(Doc, True)
                    Next
                Else
                    AtualizaSheetMetal(DocumentObject)
                End If
            End If
        End Sub

        Private Sub AtualizaSheetMetal(ByVal Documento As Inventor.Document, Optional ByVal Assembly As Boolean = False)
            Dim Part As PartDocument
            Dim Aberta As Boolean = False

            m_inventorApplication.SilentOperation = True

            If Documento.DocumentType = DocumentTypeEnum.kPartDocumentObject Then
                Part = Documento
                If Part.DocumentSubType.DocumentSubTypeID = "{9C464203-9BAE-11D3-8BAD-0060B0CE6BB4}" Then
                    Dim Sheet As SheetMetalComponentDefinition
                    Sheet = Part.ComponentDefinition

                    Try
                        If Not Sheet.HasFlatPattern Then
                            Sheet.Unfold()
                            Sheet.FlatPattern.ExitEdit()
                            Aberta = True
                        End If

                        Dim Max As Point
                        Dim Min As Point

                        Dim DeltaX As Double
                        Dim DeltaY As Double
                        Dim DeltaZ As Double
                        Dim Espessura As Double

                        Espessura = Math.Round(Sheet.Thickness.Value, 3) * 10
                        Max = Sheet.FlatPattern.RangeBox.MaxPoint
                        Min = Sheet.FlatPattern.RangeBox.MinPoint

                        DeltaX = Math.Round(Math.Abs(Max.X - Min.X), 3) * 10
                        DeltaY = Math.Round(Math.Abs(Max.Y - Min.Y), 3) * 10
                        DeltaZ = Math.Round(Math.Abs(Max.Z - Min.Z), 3) * 10

                        'Aplica as propriedades

                        If DeltaX = Espessura Then
                            If DeltaY < DeltaZ Then
                                AtualizaPropriedade(Documento, "SheetMetalLength", Trim(Str(Math.Round(DeltaY, 0))))
                                AtualizaPropriedade(Documento, "SheetMetalWidth", Trim(Str(Math.Round(DeltaZ, 0))))
                            Else
                                AtualizaPropriedade(Documento, "SheetMetalLength", Trim(Str(Math.Round(DeltaZ, 0))))
                                AtualizaPropriedade(Documento, "SheetMetalWidth", Trim(Str(Math.Round(DeltaY, 0))))
                            End If
                        ElseIf DeltaY = Espessura Then
                            If DeltaX < DeltaZ Then
                                AtualizaPropriedade(Documento, "SheetMetalLength", Trim(Str(Math.Round(DeltaX, 0))))
                                AtualizaPropriedade(Documento, "SheetMetalWidth", Trim(Str(Math.Round(DeltaZ, 0))))
                            Else
                                AtualizaPropriedade(Documento, "SheetMetalLength", Trim(Str(Math.Round(DeltaZ, 0))))
                                AtualizaPropriedade(Documento, "SheetMetalWidth", Trim(Str(Math.Round(DeltaX, 0))))
                            End If
                        ElseIf DeltaZ = Espessura Then
                            If DeltaX < DeltaY Then
                                AtualizaPropriedade(Documento, "SheetMetalLength", Trim(Str(Math.Round(DeltaX, 0))))
                                AtualizaPropriedade(Documento, "SheetMetalWidth", Trim(Str(Math.Round(DeltaY, 0))))
                            Else
                                AtualizaPropriedade(Documento, "SheetMetalLength", Trim(Str(Math.Round(DeltaY, 0))))
                                AtualizaPropriedade(Documento, "SheetMetalWidth", Trim(Str(Math.Round(DeltaX, 0))))
                            End If
                        Else
                            'Se não é nenhum dos três, pega os dois maiores
                            If DeltaX > DeltaY Then
                                If DeltaY > DeltaZ Then
                                    AtualizaPropriedade(Documento, "SheetMetalLength", Trim(Str(Math.Round(DeltaX, 0))))
                                    AtualizaPropriedade(Documento, "SheetMetalWidth", Trim(Str(Math.Round(DeltaY, 0))))
                                Else
                                    AtualizaPropriedade(Documento, "SheetMetalLength", Trim(Str(Math.Round(DeltaX, 0))))
                                    AtualizaPropriedade(Documento, "SheetMetalWidth", Trim(Str(Math.Round(DeltaZ, 0))))
                                End If
                            Else
                                If DeltaY > DeltaZ Then
                                    AtualizaPropriedade(Documento, "SheetMetalLength", Trim(Str(Math.Round(DeltaY, 0))))
                                    AtualizaPropriedade(Documento, "SheetMetalWidth", Trim(Str(Math.Round(DeltaZ, 0))))
                                Else
                                    AtualizaPropriedade(Documento, "SheetMetalLength", Trim(Str(Math.Round(DeltaX, 0))))
                                    AtualizaPropriedade(Documento, "SheetMetalWidth", Trim(Str(Math.Round(DeltaZ, 0))))
                                End If
                            End If
                        End If

                        If Aberta And Assembly Then
                            Part.Save()
                            Part.Close()
                        End If
                    Catch ex As Exception

                    End Try
                End If
            ElseIf Documento.DocumentType = DocumentTypeEnum.kAssemblyDocumentObject And _
            AtualizarSheetMetalMontagens Then
                For Each Doc As Inventor.Document In Documento.ReferencedDocuments
                    AtualizaSheetMetal(Doc, True)
                Next
            End If

            m_inventorApplication.SilentOperation = False
        End Sub

        Public Sub AtualizaPropriedade(ByVal Documento As Document, ByVal Propriedade As String, _
                                       ByVal Valor As String)
            Dim CustomProps As PropertySet

            CustomProps = Documento.PropertySets.Item("Inventor User Defined Properties")

            Try
                CustomProps.Item(Propriedade).Value = Valor
            Catch ex As Exception
                Try
                    CustomProps.Add(Valor, Propriedade)
                Catch ex2 As Exception

                End Try
            End Try
        End Sub


#End Region

    End Class

End Namespace

