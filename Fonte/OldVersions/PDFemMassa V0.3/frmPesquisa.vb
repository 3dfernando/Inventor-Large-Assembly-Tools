Public Class frmPesquisa

#Region "Variáveis e Objetos"
    Private PosCmdCancelar As System.Drawing.Point
    Private PosCmdAdicionar As System.Drawing.Point
    Private PosLblTempo As System.Drawing.Point

    Private SizeLstArquivosEncontrados As System.Drawing.Size
    Private SizeForm As System.Drawing.Size
    Private FormLoaded As Boolean = False

    Private Const IDW As Integer = 1
    Private Const DWG As Integer = 2
    Private Const txtPesquisando As String = "Pesquisando..."
    Private Const txtNoResults As String = "Sem Resultados."

    Public Shared Pesquisa As String
    Public Shared ArquivosSelecionados As New System.Collections.Specialized.StringCollection

    Private TempoInicial As Double
    Private PrimeiroArquivoEncontrado As Boolean = False
    Private Cancelar As Boolean = False
    Private ArquivosEncontrados As Long = 0

#End Region

#Region "Eventos"

    Private Sub frmPesquisa_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Pesquisa.
        Dim Caminho As String
        Dim ItemTemp As New Windows.Forms.ListViewItem

        ItemTemp.SubItems.Add(txtPesquisando)
        lstArquivosEncontrados.Items.Clear()
        lstArquivosEncontrados.Items.Add(ItemTemp)
        ArquivosEncontrados = 0

        For Each Caminho In My.Settings.LocaisPadraoPesquisa
            PesquisarPasta(Pesquisa, Caminho, My.Settings.PesquisarSubPastas, _
                            My.Settings.PesquisarDWG, My.Settings.PesquisarIDW)
        Next

        cmdCancel.Enabled = False
        cmdAdicionar.Enabled = True

        If ArquivosEncontrados = 0 Then
            ItemTemp.SubItems(1).Text = txtNoResults
            cmdAdicionar.Enabled = False
        End If

        If My.Settings.PesquisarPrimeiro Then
            cmdAdicionar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub frmPesquisa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Carrega as variáveis de posição para futuro redimensionamento do form
        PosCmdAdicionar = cmdAdicionar.Location
        PosCmdCancelar = cmdCancel.Location
        PosLblTempo = lblTempo.Location
        SizeLstArquivosEncontrados = lstArquivosEncontrados.Size

        SizeForm = Me.Size
        FormLoaded = True
        cmdCancel.Enabled = True
        cmdAdicionar.Enabled = False

        'Inicializa a listview
        lstArquivosEncontrados.Columns.Clear()

        lstArquivosEncontrados.Columns.Add("A", "", 50, Windows.Forms.HorizontalAlignment.Left, 99)
        lstArquivosEncontrados.Columns.Add("NomeArq", "Nome do Arquivo", 120, Windows.Forms.HorizontalAlignment.Left, 99)
        lstArquivosEncontrados.Columns.Add("CaminhoArq", "Localização", 160, Windows.Forms.HorizontalAlignment.Left, 99)

        'Zera a lista de strings
        ArquivosSelecionados.Clear()
    End Sub

    Private Sub frmPesquisa_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Inicia o contador de tempo
        TempoInicial = Timer

        'Ao redimensionar o form, redimensiona os componentes.
        If FormLoaded Then
            cmdAdicionar.Left = Me.Width - SizeForm.Width + PosCmdAdicionar.X
            cmdCancel.Left = Me.Width - SizeForm.Width + PosCmdCancelar.X
            lblTempo.Left = Me.Width - SizeForm.Width + PosLblTempo.X
            lstArquivosEncontrados.Width = Me.Width - SizeForm.Width + SizeLstArquivosEncontrados.Width

            lblTempo.Top = PosLblTempo.Y
            cmdAdicionar.Top = Me.Height - SizeForm.Height + PosCmdAdicionar.Y
            cmdCancel.Top = Me.Height - SizeForm.Height + PosCmdCancelar.Y
            lstArquivosEncontrados.Height = Me.Height - SizeForm.Height + SizeLstArquivosEncontrados.Height
        End If
    End Sub

    Private Sub PesquisarPasta(ByVal Search As String, ByVal Pasta As String, ByVal PesquisarSubpastas As Boolean, _
                               ByVal PesquisarDWG As Boolean, ByVal pesquisarIDW As Boolean)
        'Faz a pesquisa dentro de uma pasta conforme as configurações
        Dim TempString As String
        Dim FArquivo As String
        Dim DPasta As String
        Try
            'Primeiro encontra os arquivos dentro da pasta atual
            For Each FArquivo In System.IO.Directory.GetFiles(Pasta)
                'Pesquisa apenas o nome do arquivo
                If PrimeiroArquivoEncontrado And My.Settings.PesquisarPrimeiro Then Exit Sub

                If Cancelar Then Exit Sub

                TempString = Strings.Right(FArquivo, FArquivo.Length - FArquivo.LastIndexOf("\") - 1)
                If InStr(LCase(TempString), LCase(Search)) > 0 Then
                    If LCase(TipoDoArquivo(FArquivo)) = "dwg" And PesquisarDWG Or _
                        LCase(TipoDoArquivo(FArquivo)) = "idw" And pesquisarIDW Then

                        If Not PrimeiroArquivoEncontrado Then
                            PrimeiroArquivoEncontrado = True
                            lstArquivosEncontrados.Items.Clear()
                        End If
                        ArquivosEncontrados = ArquivosEncontrados + 1
                        AdicionaArquivoNaLista(FArquivo)
                    End If
                End If

                AtualizaTempo()
                System.Windows.Forms.Application.DoEvents()
            Next

            'Depois procura dentro das subpastas, caso seja o configurado:

            If PesquisarSubpastas Then
                For Each DPasta In System.IO.Directory.GetDirectories(Pasta)

                    PesquisarPasta(Search, DPasta, My.Settings.PesquisarSubPastas, _
                                My.Settings.PesquisarDWG, My.Settings.PesquisarIDW)
                    If Cancelar Then Exit Sub

                    System.Windows.Forms.Application.DoEvents()
                    AtualizaTempo()
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AdicionaArquivoNaLista(ByVal Arquivo As String)
        Dim Item As New Windows.Forms.ListViewItem

        Item.Checked = True
        Item.SubItems.Add(NomeDoArquivo(Arquivo))
        Item.SubItems.Add(Arquivo)
        If LCase(TipoDoArquivo(Arquivo)) = "dwg" Then
            Item.ImageIndex = DWG
        ElseIf LCase(TipoDoArquivo(Arquivo)) = "idw" Then
            Item.ImageIndex = IDW
        End If

        lstArquivosEncontrados.Items.Add(Item)

    End Sub

    Private Sub AtualizaTempo()
        Dim TimeElapsed As Double
        Dim Minutos As String
        Dim Segundos As String

        TimeElapsed = Timer - TempoInicial
        If Int(TimeElapsed / 60) < 10 Then
            Minutos = "0" & Trim(Str(Int(TimeElapsed / 60)))
        Else
            Minutos = Trim(Str(Int(TimeElapsed / 60)))
        End If

        If Int(TimeElapsed - (Int(TimeElapsed / 60) * 60)) < 10 Then
            Segundos = "0" & Trim(Str(Int(TimeElapsed - (Int(TimeElapsed / 60) * 60))))
        Else
            Segundos = Trim(Str(Int(TimeElapsed - (Int(TimeElapsed / 60) * 60))))
        End If

        lblTempo.Text = "Tempo de Pesquisa: " & Minutos & ":" & Segundos

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Cancelar = True
    End Sub

    Private Sub cmdAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionar.Click
        'Adiciona os arquivos no buffer para jogá-los na lista
        Dim Item As Windows.Forms.ListViewItem

        If ArquivosEncontrados > 0 Then
            ArquivosSelecionados.Clear()
            For Each Item In lstArquivosEncontrados.Items
                If Item.Checked Then
                    ArquivosSelecionados.Add(Item.SubItems(2).Text)
                End If
            Next
        End If
        Me.Close()
    End Sub

    Private Sub SelecionarTudoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelecionarTudoToolStripMenuItem.Click
        Dim Item As Windows.Forms.ListViewItem
        For Each Item In lstArquivosEncontrados.Items
            Item.Selected = True
        Next
    End Sub
#End Region

End Class