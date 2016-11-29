Imports System.IO
Imports System.Windows
Imports Inventor

Public Class frmListaArquivos

#Region "Variaveis e Objetos"

    Private PosicaoCmdSalvar As System.Drawing.Point
    Private PosicaoCmdCancelar As System.Drawing.Point
    Private TamanhoLstArquivos As System.Drawing.Size
    Private TamanhoForm As System.Drawing.Size
    Private FormLoaded As Boolean
    Private WithEvents ItemDeMenu As Forms.ToolStripMenuItem
    Private Tip As Forms.ToolTip

    Private Const IDW As Integer = 1
    Private Const DWG As Integer = 2

    Public Shared ThisApplication As Inventor.Application
#End Region

#Region "Eventos"

    Private Sub frmListaArquivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'Seta no escopo do Form a aplicação do inventor
            ThisApplication = PDFemMassa.StandardAddInServer.m_inventorApplication

            'Cria as colunas da lista de arquivos
            lstArquivos.Columns.Clear()

            lstArquivos.Columns.Add("Check", "", 50, Windows.Forms.HorizontalAlignment.Left, 9999)
            lstArquivos.Columns.Add("NomeArq", "Nome do Arquivo", 120, Windows.Forms.HorizontalAlignment.Left, 9999)
            lstArquivos.Columns.Add("CaminhoArq", "Localização", 100, Windows.Forms.HorizontalAlignment.Left, 9999)
            lstArquivos.Columns.Add("Formato", "Formato", 110, Windows.Forms.HorizontalAlignment.Center, 9999)
            lstArquivos.Columns.Add("PosImpr", "Posição Impr.", 80, Windows.Forms.HorizontalAlignment.Center, 9999)


            'Cria as variáveis que representam a posição e o tamanho dos componentes
            'Finalidade: Resize do Form deve fazer os comandos acompanharem!
            PosicaoCmdCancelar = cmdCancelar.Location
            PosicaoCmdSalvar = cmdSaveClose.Location
            TamanhoLstArquivos = lstArquivos.Size
            TamanhoForm = Me.Size
            FormLoaded = True

            'Cria o menu de apoio com os formatos de folha
            Dim I As Integer

            ItemDeMenu = New Forms.ToolStripMenuItem
            ItemDeMenu.Text = "Configuração Definida"
            ItemDeMenu.Name = "mnuConfigDef"

            mniFormato.DropDownItems.Add(ItemDeMenu)
            AddHandler ItemDeMenu.Click, AddressOf CliqueItemDeMenu

            ItemDeMenu = Nothing

            For I = 0 To My.Settings.LabelsPapel.Count - 1
                ItemDeMenu = New Forms.ToolStripMenuItem
                ItemDeMenu.Text = My.Settings.LabelsPapel(I)
                ItemDeMenu.Name = "mnu" & My.Settings.TamanhosPapel(I) & "x" & I

                mniFormato.DropDownItems.Add(ItemDeMenu)
                AddHandler ItemDeMenu.Click, AddressOf CliqueItemDeMenu

                ItemDeMenu = Nothing
            Next I

            ItemDeMenu = New Forms.ToolStripMenuItem
            ItemDeMenu.Text = "Opções..."
            ItemDeMenu.Name = "mnuOpcoesFormato"

            mniFormato.DropDownItems.Add(ItemDeMenu)
            AddHandler ItemDeMenu.Click, AddressOf CliqueItemDeMenu

            ItemDeMenu = Nothing

            'Preenche a lista de arquivos com os valores já selecionados
            Dim Item As Forms.ListViewItem

            lstArquivos.Items.Clear()
            If Not ListaArquivos Is Nothing Then
                For I = 0 To ListaArquivos.Length
                    Item = New Forms.ListViewItem

                    'Nome do Arquivo
                    Item.SubItems.Add(ListaArquivos(I).NomeArquivo)
                    'Caminho Completo
                    Item.SubItems.Add(ListaArquivos(I).CaminhoCompleto)
                    'Formato de Folha
                    If ListaArquivos(I).FormatoPredefinido Then
                        Item.SubItems.Add("Predefinido")
                    Else
                        Item.SubItems.Add(My.Settings.LabelsPapel(ListaArquivos(I).FormatoPos))
                    End If
                    'Posição de Impressão
                    If ListaArquivos(I).PosicaoPredefinida Then
                        Item.SubItems.Add("Predefinida")
                    Else
                        Item.SubItems.Add(ListaArquivos(I).Posicao)
                    End If
                    'Checked
                    Item.Checked = ListaArquivos(I).Checked
                    'Imagem do tipo de arquivo
                    If LCase(ListaArquivos(I).TipoArquivo) = "dwg" Then
                        Item.ImageIndex = DWG
                    ElseIf LCase(ListaArquivos(I).TipoArquivo) = "idw" Then
                        Item.ImageIndex = IDW
                    End If

                    lstArquivos.Items.Add(Item)

                    Item = Nothing
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdIncluirArquivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIncluirArquivos.Click
        Dim Arquivo As String

        'Mostra a janela de seleção de arquivos
        DialogArquivos.ShowDialog()

        'Nenhum arquivo selecionado, sair da sub
        If DialogArquivos.FileNames.Length = 0 Then Exit Sub

        'Pega cada arquivo selecionado
        For Each Arquivo In DialogArquivos.FileNames
            IncluirArquivoNaLista(Arquivo)
        Next
    End Sub

    Private Sub cmdIncluirPasta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIncluirPasta.Click
        Dim Caminho As String

        'Mostra a janela de seleção de pasta
        DialogPasta.ShowDialog()

        Caminho = DialogPasta.SelectedPath
        If Caminho.Length = 0 Then
            'Nenhum caminho selecionado, sair da sub!
            Exit Sub
        Else
            'Pega todos os dwgs ou idws dentro da pasta
            IncluirPastaNaLista(Caminho)
        End If
    End Sub

    Private Sub lstArquivos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstArquivos.KeyDown
        Dim ItemDeLista As Forms.ListViewItem
        If e.KeyCode = Forms.Keys.Delete Then
            For Each ItemDeLista In lstArquivos.SelectedItems
                lstArquivos.Items.Remove(ItemDeLista)
            Next
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmListaArquivos_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Tamanho mínima do form
        If Me.Height < 250 Then Me.Height = 250
        If Me.Width < 300 Then Me.Width = 300

        If FormLoaded Then
            'Ajusta os componentes na altura
            lstArquivos.Height = TamanhoLstArquivos.Height - TamanhoForm.Height + Me.Height
            cmdSaveClose.Top = PosicaoCmdSalvar.Y - TamanhoForm.Height + Me.Height
            cmdCancelar.Top = PosicaoCmdCancelar.Y - TamanhoForm.Height + Me.Height

            'Ajusta os componentes na largura
            lstArquivos.Width = TamanhoLstArquivos.Width - TamanhoForm.Width + Me.Width
            cmdSaveClose.Left = PosicaoCmdSalvar.X - TamanhoForm.Width + Me.Width
            cmdCancelar.Left = PosicaoCmdCancelar.X - TamanhoForm.Width + Me.Width
        End If

    End Sub

    Private Sub CliqueItemDeMenu(ByVal sender As Object, ByVal e As System.EventArgs)
        'Compila todos os cliques de menu deste form
        Dim CallingObject As Forms.ToolStripMenuItem
        Dim ItemDeLista As Forms.ListViewItem
        Dim TempString As String
        Dim Pos As String = vbNullString
        Dim I, PosL As Long

        CallingObject = sender

        If CallingObject.Name = "mnuConfigDef" Then
            For Each ItemDeLista In lstArquivos.SelectedItems
                ItemDeLista.SubItems(3).Text = "Predefinido"
            Next
        ElseIf CallingObject.Name = "mnuOpcoesFormato" Then
            Dim Form As New frmOpcoesGeral
            Form.Abas.SelectTab(2)
            Form.ShowDialog()
        Else
            TempString = Strings.Right(CallingObject.Name, CallingObject.Name.Length - 3)
            'Pega a posição no my.settings do formato no menu
            For I = TempString.Length To 1 Step -1
                If Mid(TempString, I, 1) = "x" Then
                    Pos = Mid(TempString, I + 1, TempString.Length - I)
                    Exit For
                End If
            Next

            PosL = Val(Pos)

            For Each ItemDeLista In lstArquivos.SelectedItems
                ItemDeLista.SubItems(3).Text = My.Settings.LabelsPapel(PosL)
            Next

        End If

    End Sub

    Private Sub mniSelecionarTudo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSelecionarTudo.Click
        Dim Item As Forms.ListViewItem
        For Each Item In lstArquivos.Items
            Item.Selected = True
        Next
    End Sub

    Private Sub mnuPosImprPredef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPosImprPredef.Click
        Dim Item As Forms.ListViewItem
        For Each Item In lstArquivos.SelectedItems
            Item.SubItems(4).Text = "Predefinida"
        Next
    End Sub

    Private Sub mniPosImprRetrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPosImprRetrato.Click
        Dim Item As Forms.ListViewItem
        For Each Item In lstArquivos.SelectedItems
            Item.SubItems(4).Text = "Retrato"
        Next
    End Sub

    Private Sub mniPosImprPaisagem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPosImprPaisagem.Click
        Dim Item As Forms.ListViewItem
        For Each Item In lstArquivos.SelectedItems
            Item.SubItems(4).Text = "Paisagem"
        Next
    End Sub

    Private Sub cmdSaveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveClose.Click
        'Salva todos os arquivos
        Try
            Dim Item As Forms.ListViewItem
            Dim Buffer() As ConfigArquivo = Nothing
            Dim I As Long = 0

            For Each Item In lstArquivos.Items

                ReDim Preserve Buffer(I)

                'Checked
                Buffer(I).Checked = Item.Checked
                'Imagem do tipo de arquivo
                If LCase(TipoDoArquivo(Item.SubItems(2).Text)) = "dwg" Then
                    Buffer(I).TipoArquivo = "dwg"
                ElseIf LCase(TipoDoArquivo(Item.SubItems(2).Text)) = "idw" Then
                    Buffer(I).TipoArquivo = "idw"
                End If
                'Nome do Arquivo
                Buffer(I).NomeArquivo = Item.SubItems(1).Text
                'Caminho Completo
                Buffer(I).CaminhoCompleto = Item.SubItems(2).Text
                'Formato de Folha
                If Item.SubItems(3).Text = "Predefinido" Then
                    Buffer(I).FormatoPredefinido = True
                    Buffer(I).FormatoAltura = vbNullString
                    Buffer(I).FormatoLargura = vbNullString
                    Buffer(I).FormatoPos = vbNullString
                Else
                    Buffer(I).FormatoPredefinido = False
                    Buffer(I).FormatoPos = RetornaPosDentroDeMySettingsLabelsFormatos(Item.SubItems(3).Text)
                    Dim Alt As String = vbNullString
                    Dim Larg As String = vbNullString
                    Dim Unid As String = vbNullString
                    RetornaTamanhoUnidadesMySettings(Buffer(I).FormatoPos, Alt, Larg, Unid)
                    Buffer(I).FormatoAltura = Alt
                    Buffer(I).FormatoLargura = Larg
                    Buffer(I).FormatoUnidades = Unid
                End If
                'Posição de Impressão
                If Item.SubItems(4).Text = "Predefinida" Then
                    Buffer(I).PosicaoPredefinida = True
                    Buffer(I).Posicao = vbNullString
                Else
                    Buffer(I).PosicaoPredefinida = False
                    Buffer(I).Posicao = Item.SubItems(4).Text
                End If

                I = I + 1
            Next

            ListaArquivos = Buffer

        Catch ex As Exception

        End Try

        Me.Close()
    End Sub

    Private Sub cmdOpcoesPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpcoesPesquisa.Click
        Dim Form As New frmOpcoesGeral
        Form.Abas.SelectTab(1)
        Form.ShowDialog()
    End Sub

    Private Sub cmdPesquisarArquivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisarArquivos.Click
        Dim Form As New frmPesquisarArquivos
        Form.ShowDialog()

        'Adiciona os arquivos caso sejam encontrados
        Dim Caminho As String

        For Each Caminho In frmPesquisarArquivos.ArquivosSelecionados
            IncluirArquivoNaLista(Caminho)
        Next

    End Sub

    Private Sub cmdPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisa.Click
        If txtPesquisa.Text = vbNullString Then
            MsgBox("A pesquisa deve conter algum valor!", MsgBoxStyle.OkOnly Or _
                    MsgBoxStyle.Critical, "Não é possível pesquisar")
        Else
            frmPesquisa.Pesquisa = txtPesquisa.Text
            Dim Form As New frmPesquisa
            Form.ShowDialog()

            'Adiciona os arquivos caso sejam encontrados
            Dim Caminho As String

            For Each Caminho In frmPesquisa.ArquivosSelecionados
                IncluirArquivoNaLista(Caminho)
            Next

        End If
    End Sub

    Private Sub txtPesquisa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPesquisa.KeyDown
        If e.KeyCode = Forms.Keys.Enter Then
            cmdPesquisa_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmdIncluirMontagem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIncluirMontagem.Click
        'Descobre quantos arquivos tem para imprimir
        Dim DocumentoAtual As Inventor.Document
        Dim AssemblyAtual As Inventor.AssemblyDocument
        Dim DocumentosReferenciados As Inventor.DocumentsEnumerator
        Dim DocumentoEncontrado As Inventor.Document

        Dim FullFilePath As String
        Dim FileName As String
        Dim FileType As String
        Dim FilePath As String
        Dim DrawingFullPath As String

        Dim NFiles As Double
        Dim N As Double
        Dim ArquivosAdicionados As Long = 0
        Dim DrawingPaths() As String
        Dim ListaArquivosNaoAdicionados As String = ""

        Try
            DocumentoAtual = ThisApplication.ActiveDocument
            If IsNothing(DocumentoAtual) Then
                MsgBox("Não há nenhum documento aberto!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
                Exit Sub
            End If

            If DocumentoAtual.DocumentType = Inventor.DocumentTypeEnum.kAssemblyDocumentObject Then
                AssemblyAtual = DocumentoAtual

                'Pesquisa todos os arquivos referenciados (parts e assemblies)
                DocumentosReferenciados = AssemblyAtual.AllReferencedDocuments
                NFiles = DocumentosReferenciados.Count
                ReDim DrawingPaths(NFiles + 1)
                N = 0


                'Para cada documento referenciado, cria um filepath do possível IDW para verificação
                For Each DocumentoEncontrado In DocumentosReferenciados
                    FullFilePath = DocumentoEncontrado.File.FullFileName
                    FileName = NomeDoArquivoSemExtensao(FullFilePath)
                    FileType = TipoDoArquivo(FullFilePath)
                    FilePath = CaminhoArquivo(FullFilePath)

                    If FileType = "ipt" Or FileType = "iam" Then
                        DrawingFullPath = FilePath & FileName & ".idw"
                        DrawingPaths(N) = DrawingFullPath
                    End If
                    N = N + 1
                Next

                Dim AssemblyPath As String
                AssemblyPath = AssemblyAtual.FullFileName
                AssemblyPath = CaminhoArquivo(AssemblyPath) & NomeDoArquivoSemExtensao(AssemblyPath) & ".idw"
                DrawingPaths(N) = AssemblyPath

                'Pergunta ao usuário se ele quer adicionar a quantidade de arquivos informada
                'If MsgBox("Serão adicionados até" & Str(NFiles) & " arquivos. Continuar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, _
                '          "Confirmação") = MsgBoxResult.No Then Exit Sub

                Array.Sort(DrawingPaths)

                'Para cada IDW encontrado, verifica se o arquivo existe. Se sim, adiciona-o a lista.
                For Each DrawingFullPath In DrawingPaths
                    If System.IO.File.Exists(DrawingFullPath) Then
                        IncluirArquivoNaLista(DrawingFullPath)
                        ArquivosAdicionados = ArquivosAdicionados + 1
                    Else
                        ListaArquivosNaoAdicionados = ListaArquivosNaoAdicionados & vbCrLf & NomeDoArquivoSemExtensao(DrawingFullPath)
                    End If
                Next

                MsgBox("Foram adicionados " & Str(ArquivosAdicionados) & " arquivos de um total de" & Str(NFiles) & " referências contidas nesta montagem." & _
                       vbCrLf & "Os documentos listados não têm desenho relacionado a eles:" & vbCrLf & ListaArquivosNaoAdicionados, _
                       MsgBoxStyle.Information)

            Else
                MsgBox("O documento aberto não é uma montagem!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "Funções e Subs"
    Private Sub IncluirArquivoNaLista(ByVal CaminhoCompleto As String)
        'Inclui um arquivo na lista.
        Dim ItemdeLista As New Windows.Forms.ListViewItem
        Dim ItemExistente As Windows.Forms.ListViewItem

        For Each ItemExistente In lstArquivos.Items
            If ItemExistente.SubItems(2).Text = CaminhoCompleto Then
                'Não adiciona item se o arquivo já foi adicionado!
                Exit Sub
            End If
        Next

        ItemdeLista.SubItems.Add(NomeDoArquivo(CaminhoCompleto))
        ItemdeLista.SubItems.Add(CaminhoCompleto)
        ItemdeLista.SubItems.Add("Predefinido")
        ItemdeLista.SubItems.Add("Predefinida")
        ItemdeLista.Checked = True

        'Coloca o ícone
        If LCase(TipoDoArquivo(CaminhoCompleto)) = "dwg" Then
            ItemdeLista.ImageIndex = DWG
        ElseIf LCase(TipoDoArquivo(CaminhoCompleto)) = "idw" Then
            ItemdeLista.ImageIndex = IDW
        End If

        lstArquivos.Items.Add(ItemdeLista)

    End Sub

    Private Sub IncluirPastaNaLista(ByVal CaminhoPasta As String)
        'Inclui uma pasta na lista, conforme as configurações
        Dim Arquivo As String
        Dim Pasta As String

        'Inclui os arquivos desta pasta
        For Each Arquivo In Directory.GetFiles(CaminhoPasta)
            If chkIDW.Checked = True And LCase(TipoDoArquivo(Arquivo)) = "idw" Then
                IncluirArquivoNaLista(Arquivo)
            End If
            If chkDWG.Checked = True And LCase(TipoDoArquivo(Arquivo)) = "dwg" Then
                IncluirArquivoNaLista(Arquivo)
            End If
        Next

        If chkSubPastas.Checked = True Then
            'Também inclui cada subpasta dentro desta pasta!
            For Each Pasta In Directory.GetDirectories(CaminhoPasta)
                IncluirPastaNaLista(Pasta)
            Next
        End If

    End Sub

    Private Function RetornaPosDentroDeMySettingsLabelsFormatos(ByVal Pesquisa As String) As Long
        Dim TempString As String
        Dim I As Long

        For I = 0 To My.Settings.LabelsPapel.Count - 1
            TempString = My.Settings.LabelsPapel(I)
            If InStr(Pesquisa, TempString) > 0 Then
                RetornaPosDentroDeMySettingsLabelsFormatos = I
                Exit For
            End If
        Next
    End Function

    Private Sub RetornaTamanhoUnidadesMySettings(ByVal Pos As Long, _
                                                 ByRef RetornaAltura As String, _
                                                 ByRef RetornaLargura As String, _
                                                 ByRef RetornaUnidades As String)
        Dim I As Integer
        Dim J As Integer
        For I = 1 To My.Settings.TamanhosPapel(Pos).Length - 1
            If Mid(My.Settings.TamanhosPapel(Pos), I, 1) = "x" Then
                RetornaAltura = Strings.Left(My.Settings.TamanhosPapel(Pos), I - 1)
                Exit For
            End If
        Next
        For J = I + 1 To My.Settings.TamanhosPapel(Pos).Length - 1
            If Mid(My.Settings.TamanhosPapel(Pos), I, 1) = "x" Then
                RetornaLargura = Mid(My.Settings.TamanhosPapel(Pos), I + 1, J - I - 1)
                Exit For
            End If
        Next
        For I = My.Settings.TamanhosPapel(Pos).Length - 1 To 1 Step -1
            If Mid(My.Settings.TamanhosPapel(Pos), I, 1) = "x" Then
                RetornaUnidades = Strings.Right(My.Settings.TamanhosPapel(Pos), _
                                               My.Settings.TamanhosPapel(Pos).Length - I)
                Exit For
            End If
        Next


    End Sub

#End Region

End Class