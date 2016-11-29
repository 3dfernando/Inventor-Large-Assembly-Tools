
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
    Public Function ExtensaoArquivo(ByVal Caminho As String) As String
        If IsNothing(Caminho) Then Return ""
        Dim I As Long
        For I = Caminho.Length To 1 Step -1
            If Mid(Caminho, I, 1) = "." Then
                ExtensaoArquivo = Mid(Caminho, I + 1, Caminho.Length - I + 1)
                Exit Function
            End If
        Next
        ExtensaoArquivo = ""
    End Function

    Public Function NomeDoArquivo(ByVal Caminho As String) As String
        If IsNothing(Caminho) Then Return ""
        Dim I As Long
        For I = Caminho.Length To 1 Step -1
            If Mid(Caminho, I, 1) = "\" Then
                NomeDoArquivo = Mid(Caminho, I + 1, Caminho.Length - I + 1)
                Exit Function
            End If
        Next
        NomeDoArquivo = ""
    End Function

    Public Function NomeDoArquivoSemExtensao(ByVal Caminho As String) As String
        If IsNothing(Caminho) Then Return ""
        Dim I As Long
        For I = Caminho.Length To 1 Step -1
            If Mid(Caminho, I, 1) = "\" Then
                NomeDoArquivoSemExtensao = Mid(Caminho, I + 1, Caminho.Length - I - 4)
                Exit Function
            End If
        Next
        NomeDoArquivoSemExtensao = ""
    End Function

    Public Function TipoDoArquivo(ByVal Caminho As String) As String
        If IsNothing(Caminho) Then Return ""
        Dim I As Long
        For I = Caminho.Length To 1 Step -1
            If Mid(Caminho, I, 1) = "." Then
                TipoDoArquivo = Mid(Caminho, I + 1, Caminho.Length - I + 1)
                Exit Function
            End If
        Next
        TipoDoArquivo = ""
    End Function

    Public Function NomeDaUltimaPasta(ByVal Caminho As String) As String
        If IsNothing(Caminho) Then Return ""
        Dim I As Long
        For I = Caminho.Length To 1 Step -1
            If Mid(Caminho, I, 1) = "\" Then
                NomeDaUltimaPasta = Mid(Caminho, I + 1, Len(Caminho))
                Exit Function
            End If
        Next
        NomeDaUltimaPasta = ""
    End Function

    Public Function CaminhoArquivo(ByVal Caminho As String) As String
        If IsNothing(Caminho) Then Return ""
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

    Public Function DirSize(ByVal d As System.IO.DirectoryInfo) As Long
        'Code snippet from http://stackoverflow.com/questions/3208776/what-s-the-best-way-to-calculate-the-size-of-a-directory-in-vb-net
        Dim Size As Long = 0
        ' Add file sizes.
        Dim fis As System.IO.FileInfo() = d.GetFiles()
        Dim fi As System.IO.FileInfo
        For Each fi In fis
            Size += fi.Length
        Next fi
        ' Add subdirectory sizes.
        Dim dis As System.IO.DirectoryInfo() = d.GetDirectories()
        Dim di As System.IO.DirectoryInfo
        For Each di In dis
            Size += DirSize(di)
        Next di
        Return Size
    End Function 'DirSize
#End Region

End Module
