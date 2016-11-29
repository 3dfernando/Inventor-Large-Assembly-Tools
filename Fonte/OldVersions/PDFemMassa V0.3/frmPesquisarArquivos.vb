Imports Inventor
Imports Microsoft.VisualBasic.Strings
Imports System.Windows.Forms

Public Class frmPesquisarArquivos

    Private Sub frmPesquisarArquivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvTabela_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTabela.KeyDown
        If e.Control = True Then
            If e.KeyCode = Keys.V Then
                ColarCelulasDGV()
            End If
        Else
            If e.KeyCode = Keys.Delete Then
                DeletarCelulasDGV()
            End If
        End If
    End Sub

    Private Sub DeletarCelulasDGV()
        If dgvTabela.SelectedCells.Count > 0 Then
            For Each Celula As DataGridViewCell In dgvTabela.SelectedCells
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
End Class