Imports Inventor
Imports Microsoft.VisualBasic.Strings
Imports System.Windows.Forms

Public Class frmPesquisarArquivos

#Region "Variáveis e Objetos"
    Private TempoInicial As Double
    Private Cancelar As Boolean = False
    Private ArquivosEncontrados As Long = 0
    Public Shared ArquivosSelecionados As New ArrayList

    Public Shared ThisApplication As Inventor.Application
#End Region


#Region "Eventos"

    Private Sub dgvTabela_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTabela.KeyDown
        If e.Control = True Then
            If e.KeyCode = Keys.V Then
                ColarCelulasDGV()
            End If
        Else
            If e.KeyCode = Keys.Delete Then
                DeletarCelulasDGV(dgvTabela)
            End If
        End If
    End Sub

    Private Sub dgvResultados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvResultados.KeyDown
        If e.KeyCode = Keys.Delete Then
            DeletarCelulasDGV(dgvResultados)
        End If
    End Sub


    Private Sub cmdPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisa.Click
        'Inicia a pesquisa para cada um dos campos da tabela
        If cmdPesquisa.ImageIndex = 0 Then
            cmdPesquisa.ImageIndex = 1
            cmdPesquisa.Text = "&Cancelar Pesquisa"
            'Inicia a Pesquisa
            Cancelar = False
            ArquivosEncontrados = 0
            TempoInicial = DateAndTime.Timer

            'Zera a dgvResultados
            dgvResultados.Columns.Clear()
            ArquivosSelecionados.Clear()

            'Pesquisa Arquivos
            Dim StrPesquisa() As String
            StrPesquisa = ConstroiStrPesquisa()
            dgvResultados.RowCount = dgvTabela.RowCount

            Dim Caminho As String
            Dim CaminhosPesquisa As New System.Collections.Specialized.StringCollection

            For Each Caminho In My.Settings.LocaisPadraoPesquisa
                'Adiciona os caminhos informados pelo usuário na lista
                CaminhosPesquisa.Add(Caminho)
            Next
            If My.Settings.PesquisarUsarProjectPaths Then
                'Se estiver nos Settings para pesquisar no Project atual, popula a lista com o project atual
                Dim ProjectManager As Inventor.DesignProjectManager
                ProjectManager = ThisApplication.DesignProjectManager

                If Not CaminhosPesquisa.Contains(ProjectManager.ActiveDesignProject.WorkspacePath) Then
                    CaminhosPesquisa.Add(ProjectManager.ActiveDesignProject.WorkspacePath)
                End If

                For Each T As Inventor.ProjectPath In ProjectManager.ActiveDesignProject.LibraryPaths
                    If Not CaminhosPesquisa.Contains(T.Path) Then
                        CaminhosPesquisa.Add(T.Path)
                    End If
                Next
            End If

            For Each Caminho In CaminhosPesquisa
                PesquisarPasta(StrPesquisa, Caminho, My.Settings.PesquisarSubPastas, _
                                My.Settings.PesquisarDWG, My.Settings.PesquisarIDW)
            Next

            'Terminou a pesquisa!
            cmdPesquisa.ImageIndex = 0
            cmdPesquisa.Text = "Iniciar &Pesquisa"
            lblTempo.Text = "Resultados da Pesquisa - Pesquisa Finalizada"

        Else
            cmdPesquisa.ImageIndex = 0
            cmdPesquisa.Text = "Iniciar &Pesquisa"
            lblTempo.Text = "Resultados da Pesquisa - Pesquisa Cancelada."

            'Cancela a Pesquisa
            Cancelar = True
        End If
    End Sub

    Private Sub cmdAdicionarArquivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarArquivos.Click
        'Adiciona os arquivos na lista
        Dim Linha As DataGridViewRow
        Dim Celula As DataGridViewCell
        Dim Texto As String

        ArquivosSelecionados.Clear()
        For Each Linha In dgvResultados.Rows
            For Each Celula In Linha.Cells
                If Not Celula.Value = vbNullString Then
                    Texto = Celula.ToolTipText
                    If Not ArquivosSelecionados.Contains(Texto) Then
                        ArquivosSelecionados.Add(Texto)
                    End If
                End If
            Next
        Next

        ArquivosSelecionados.Sort()

        Me.Close()
    End Sub

    Private Sub cmdOpcoesPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpcoesPesquisa.Click
        Dim Form As New frmOpcoesGeral
        Form.Abas.SelectTab(1)
        Form.ShowDialog()
    End Sub

    Private Sub frmPesquisarArquivos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Seta no escopo do Form a aplicação do inventor
        ThisApplication = PDFemMassa.StandardAddInServer.m_inventorApplication
    End Sub
#End Region

#Region "Funções e Subs"

    Private Sub PesquisarPasta(ByVal Search() As String, ByVal Pasta As String, ByVal PesquisarSubpastas As Boolean, _
                               ByVal PesquisarDWG As Boolean, ByVal PesquisarIDW As Boolean)
        'Faz a pesquisa dentro de uma pasta conforme as configurações
        Dim TempString As String
        Dim FArquivo As String
        Dim DPasta As String
        Dim NomePasta As String
        Dim OK As Boolean
        Dim StrSearch As String
        Dim N As Long = 0


        Try
            'Primeiro encontra os arquivos dentro da pasta atual
            For Each StrSearch In Search
                If Not StrSearch = vbNullString Then
                    'MultipleMsgBox(System.IO.Directory.GetFiles(Pasta, "*" & StrSearch & "*"))
                    For Each FArquivo In System.IO.Directory.GetFiles(Pasta, "*" & StrSearch & "*")
                        'Pesquisa apenas o nome do arquivo

                        If Cancelar Then Exit Sub

                        TempString = Strings.Right(FArquivo, FArquivo.Length - FArquivo.LastIndexOf("\") - 1)

                        'If InStr(LCase(TempString), LCase(StrSearch)) > 0 Then
                        If LCase(TipoDoArquivo(FArquivo)) = "dwg" And PesquisarDWG Or _
                            LCase(TipoDoArquivo(FArquivo)) = "idw" And PesquisarIDW Then

                            ArquivosEncontrados = ArquivosEncontrados + 1
                            AdicionaArquivoNaLista(FArquivo, N)
                        End If
                        'End If

                        AtualizaTempo()

                        System.Windows.Forms.Application.DoEvents()
                    Next
                End If
                N = N + 1
            Next

            'Depois procura dentro das subpastas, caso seja o configurado:

            If PesquisarSubpastas Then
                For Each DPasta In System.IO.Directory.GetDirectories(Pasta)
                    NomePasta = NomeDoArquivo(DPasta).ToLower
                    OK = Not ((NomePasta = "oldversions") Or (NomePasta = "old versions"))
                    OK = OK Or My.Settings.PesquisarOldVersions
                    'Só pesquisa a pasta seguinte se:
                    '   Ela não é uma pasta Oldversions
                    '   A opção Pesquisar Oldversions está selecionada

                    If OK Then
                        PesquisarPasta(Search, DPasta, My.Settings.PesquisarSubPastas, _
                                    My.Settings.PesquisarDWG, My.Settings.PesquisarIDW)
                        If Cancelar Then Exit Sub

                        System.Windows.Forms.Application.DoEvents()
                        AtualizaTempo()
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AtualizaTempo()
        Dim TimeElapsed As Double
        Dim Minutos As String
        Dim Segundos As String

        TimeElapsed = DateAndTime.Timer - TempoInicial
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

        lblTempo.Text = "Resultados da Pesquisa - Pesquisa em Andamento a " & Minutos & "min:" & Segundos & "s"

    End Sub

    Private Function ConstroiStrPesquisa() As String()
        Dim Resultado() As String
        Dim N As Long = 0
        Dim Linha As DataGridViewRow

        For Each Linha In dgvTabela.Rows
            If Not Linha.Cells(0).Value = vbNullString Then
                ReDim Preserve Resultado(N)
                Resultado(N) = Linha.Cells(0).Value
                N = N + 1
            End If
        Next

        ConstroiStrPesquisa = Resultado
    End Function

    Private Sub AdicionaArquivoNaLista(ByVal Arquivo As String, ByVal nLinha As Long)

        Dim CelAtual As DataGridViewCell

        If dgvResultados.Rows.Count >= nLinha Then
            'Tenta preencher a próxima coluna vazia da linha atual
            For Each CelAtual In dgvResultados.Rows(nLinha).Cells
                If CelAtual.Value = "" Then
                    CelAtual.Value = NomeDoArquivo(Arquivo)
                    CelAtual.ToolTipText = Arquivo
                    Exit Sub
                End If
            Next
            'Se ele chegou aqui é porque todas as colunas da linha selecionada estão cheias
            'Adiciona nova coluna
            Dim NovaColuna As Integer
            NovaColuna = dgvResultados.Columns.Add(Str(dgvResultados.Columns.Count), "")

            dgvResultados.Rows(nLinha).Cells(NovaColuna).Value = NomeDoArquivo(Arquivo)
            dgvResultados.Rows(nLinha).Cells(NovaColuna).ToolTipText = Arquivo
        End If
    End Sub

    Private Sub MultipleMsgBox(ByVal str() As String)
        Dim Texto As String
        Dim Temp As String
        Texto = ""
        For Each Temp In str
            Texto = Texto & Temp & vbCrLf
        Next
        MsgBox(Texto)
    End Sub

    Private Sub DeletarCelulasDGV(ByVal DataGrid As DataGridView)
        If DataGrid.SelectedCells.Count > 0 Then
            For Each Celula As DataGridViewCell In DataGrid.SelectedCells
                If Not Celula.ReadOnly Then
                    Celula.Value = ""
                End If
            Next
        End If
    End Sub

    Private Sub ColarCelulasDGV()
        Const TAB As Integer = Keys.Tab
        Const CRLF As Integer = Asc(vbCrLf)
        Dim ValorColado As String
        Dim CelulaAtual As String = vbNullString
        Dim CharAtual As Char
        Dim QtdLinhas As Integer = 1
        Dim QtdColunas As Integer = 1
        Dim ColunaAtual As Integer = 1
        Dim ContChar As Integer = 0

        Dim ColSelCel As Integer
        Dim LinSelCel As Integer

        Dim MaxCol As Integer
        Dim MaxLin As Integer

        'Tenta ignorar alguns possiveis erros que podem acontecer
        Try
            ValorColado = Clipboard.GetText(1)
        Catch ex As Exception
            MsgBox("Não foi Possível colar o texto!")
            Exit Sub
        End Try


        If ValorColado = vbNullString Then Exit Sub

        'Pega o índice da celula selecionada
        If dgvTabela.SelectedCells.Count = 0 Then
            Exit Sub
        Else
            ColSelCel = dgvTabela.SelectedCells(0).ColumnIndex
            LinSelCel = dgvTabela.SelectedCells(0).RowIndex
            If ColSelCel <> 1 Then Exit Sub 'Se a célula não está na coluna 1, não cola
        End If

        'Pega os bounds da tabela
        MaxCol = dgvTabela.ColumnCount - 1
        MaxLin = dgvTabela.RowCount - 1

        If LinSelCel >= dgvTabela.Rows.Count - 1 Then dgvTabela.Rows.Add(1)

        'Preenche a tabela
        For Each CharAtual In ValorColado
            ContChar = ContChar + 1
            If Asc(CharAtual) = TAB Then
                'Nova célula
                If (Not ColSelCel + ColunaAtual - 1 > MaxCol) And Not (LinSelCel + QtdLinhas - 1 > MaxLin) Then
                    dgvTabela.Rows(QtdLinhas + LinSelCel - 1).Cells(ColunaAtual + ColSelCel - 1).Value = CelulaAtual
                End If

                ColunaAtual = ColunaAtual + 1
                If QtdColunas < ColunaAtual Then QtdColunas = ColunaAtual


                CelulaAtual = vbNullString
            ElseIf Asc(CharAtual) = CRLF Then
                'Nova linha
                If (LinSelCel + QtdLinhas - 1 > MaxLin) Then
                    dgvTabela.Rows.Add(1)
                End If

                If (Not ColSelCel + ColunaAtual - 1 > MaxCol) Then
                    dgvTabela.Rows(QtdLinhas + LinSelCel - 1).Cells(ColunaAtual + ColSelCel - 1).Value = CelulaAtual
                End If

                If Not ContChar = ValorColado.Length - 1 Then
                    QtdLinhas = QtdLinhas + 1
                Else
                    Exit For
                End If

                ColunaAtual = 1
                CelulaAtual = vbNullString
            Else
                CelulaAtual = CelulaAtual & CharAtual
            End If
        Next

        If Not ContChar = ValorColado.Length - 1 And (Not ColSelCel + ColunaAtual - 1 > MaxCol) And Not (LinSelCel + QtdLinhas - 1 > MaxLin) Then
            dgvTabela.Rows(QtdLinhas + LinSelCel - 1).Cells(ColunaAtual + ColSelCel - 1).Value = CelulaAtual
        End If

        If QtdColunas = 1 And QtdLinhas = 1 And dgvTabela.SelectedCells.Count > 1 Then
            'Colar múltiplo
            For Each Celula As DataGridViewCell In dgvTabela.SelectedCells
                Celula.Value = CelulaAtual
            Next
        End If

    End Sub
#End Region


End Class