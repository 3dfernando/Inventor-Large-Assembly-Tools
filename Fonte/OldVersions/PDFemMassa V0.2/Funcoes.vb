
Module Funcoes

#Region "DLLs da API do Windows"

#End Region

#Region "Variáveis e Objetos"

    Public ListaArquivos() As ConfigArquivo

    Public Structure ConfigArquivo
        Dim CaminhoCompleto As String
        Dim NomeArquivo As String
        Dim FormatoPredefinido As Boolean
        Dim FormatoPos As Long
        Dim FormatoLargura As String
        Dim FormatoAltura As String
        Dim FormatoUnidades As String
        Dim PosicaoPredefinida As Boolean
        Dim Posicao As String
        Dim Checked As Boolean
        Dim TipoArquivo As String
    End Structure

#End Region

#Region "Funções Personalizadas"
    Public Function NomeDoArquivo(ByVal Caminho As String) As String
        Dim I As Long
        For I = Caminho.Length To 1 Step -1
            If Mid(Caminho, I, 1) = "\" Then
                NomeDoArquivo = Mid(Caminho, I + 1, Caminho.Length - I + 1)
                Exit Function
            End If
        Next
        NomeDoArquivo = ""
    End Function

    Public Function TipoDoArquivo(ByVal Caminho As String) As String
        Dim I As Long
        For I = Caminho.Length To 1 Step -1
            If Mid(Caminho, I, 1) = "." Then
                TipoDoArquivo = Mid(Caminho, I + 1, Caminho.Length - I + 1)
                Exit Function
            End If
        Next
        TipoDoArquivo = ""
    End Function


    Public Function CaminhoArquivo(ByVal Caminho As String) As String
        Dim I As Long
        For I = Caminho.Length To 1 Step -1
            If Mid(Caminho, I, 1) = "\" Then
                CaminhoArquivo = Mid(Caminho, 1, I)
                Exit Function
            End If
        Next
        CaminhoArquivo = ""
    End Function

    Public Function TabelaResolucoesPDF(ByVal Resolucao As Integer) As Integer
        Select Case Resolucao
            Case 0
                TabelaResolucoesPDF = 150
            Case 1
                TabelaResolucoesPDF = 200
            Case 2
                TabelaResolucoesPDF = 300
            Case 3
                TabelaResolucoesPDF = 400
            Case 4
                TabelaResolucoesPDF = 600
            Case 5
                TabelaResolucoesPDF = 720
            Case 6
                TabelaResolucoesPDF = 1200
            Case 7
                TabelaResolucoesPDF = 2400
            Case 8
                TabelaResolucoesPDF = 4800
        End Select
    End Function

#End Region

End Module
