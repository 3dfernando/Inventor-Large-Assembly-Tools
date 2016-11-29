<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpcoesGeral
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpcoesGeral))
        Me.Abas = New System.Windows.Forms.TabControl
        Me.TabGeral = New System.Windows.Forms.TabPage
        Me.chkInverterOrdem = New System.Windows.Forms.CheckBox
        Me.chkFecharDesenhos = New System.Windows.Forms.CheckBox
        Me.chkIgnorarSalvar = New System.Windows.Forms.CheckBox
        Me.chkSilentMode = New System.Windows.Forms.CheckBox
        Me.chkFecharAuto = New System.Windows.Forms.CheckBox
        Me.TabPesquisa = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkPesquisarDWG = New System.Windows.Forms.CheckBox
        Me.chkPesquisarIDW = New System.Windows.Forms.CheckBox
        Me.chkPesquisarSubpastas = New System.Windows.Forms.CheckBox
        Me.chkPesquisaPrimeiro = New System.Windows.Forms.CheckBox
        Me.cmdUpPesquisa = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdDownPesquisa = New System.Windows.Forms.Button
        Me.cmdExcluirPastaPesquisa = New System.Windows.Forms.Button
        Me.cmdAdicionarPastaPesquisa = New System.Windows.Forms.Button
        Me.lstLocaisPadraoPesquisa = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabFormatos = New System.Windows.Forms.TabPage
        Me.cmdExcluirFormato = New System.Windows.Forms.Button
        Me.cmdUpFormato = New System.Windows.Forms.Button
        Me.cmdDownFormato = New System.Windows.Forms.Button
        Me.cmdCancelarFormato = New System.Windows.Forms.Button
        Me.cmdAdicionarFormato = New System.Windows.Forms.Button
        Me.cmdAlterarFormato = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optMilimetros = New System.Windows.Forms.RadioButton
        Me.optPolegadas = New System.Windows.Forms.RadioButton
        Me.txtLargura = New System.Windows.Forms.TextBox
        Me.txtAltura = New System.Windows.Forms.TextBox
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lstFormatos = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabExportar = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdIniFile = New System.Windows.Forms.Button
        Me.txtIniFile = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkRemoveLineweightsPDF = New System.Windows.Forms.CheckBox
        Me.chkMonochromePDF = New System.Windows.Forms.CheckBox
        Me.cmbResolucaoPDF = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbFolhasPDF = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TabImprimir = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkImpressaoAgruparFormatos = New System.Windows.Forms.CheckBox
        Me.chkImpressaoInverter = New System.Windows.Forms.CheckBox
        Me.chkImpressaoRotacionar90 = New System.Windows.Forms.CheckBox
        Me.chkImpressaoRemoveLineweights = New System.Windows.Forms.CheckBox
        Me.chkImpressaoMonochrome = New System.Windows.Forms.CheckBox
        Me.updNumCopias = New System.Windows.Forms.NumericUpDown
        Me.cmbImpressaoFolhas = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdSaveClose = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DialogoPasta = New System.Windows.Forms.FolderBrowserDialog
        Me.DialogoIni = New System.Windows.Forms.OpenFileDialog
        Me.Abas.SuspendLayout()
        Me.TabGeral.SuspendLayout()
        Me.TabPesquisa.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabFormatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabExportar.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabImprimir.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.updNumCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Abas
        '
        Me.Abas.Controls.Add(Me.TabGeral)
        Me.Abas.Controls.Add(Me.TabPesquisa)
        Me.Abas.Controls.Add(Me.TabFormatos)
        Me.Abas.Controls.Add(Me.TabExportar)
        Me.Abas.Controls.Add(Me.TabImprimir)
        Me.Abas.Location = New System.Drawing.Point(2, 4)
        Me.Abas.Name = "Abas"
        Me.Abas.SelectedIndex = 0
        Me.Abas.Size = New System.Drawing.Size(358, 502)
        Me.Abas.TabIndex = 0
        '
        'TabGeral
        '
        Me.TabGeral.Controls.Add(Me.chkInverterOrdem)
        Me.TabGeral.Controls.Add(Me.chkFecharDesenhos)
        Me.TabGeral.Controls.Add(Me.chkIgnorarSalvar)
        Me.TabGeral.Controls.Add(Me.chkSilentMode)
        Me.TabGeral.Controls.Add(Me.chkFecharAuto)
        Me.TabGeral.Location = New System.Drawing.Point(4, 22)
        Me.TabGeral.Name = "TabGeral"
        Me.TabGeral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGeral.Size = New System.Drawing.Size(350, 476)
        Me.TabGeral.TabIndex = 0
        Me.TabGeral.Text = "Geral"
        Me.TabGeral.UseVisualStyleBackColor = True
        '
        'chkInverterOrdem
        '
        Me.chkInverterOrdem.AutoSize = True
        Me.chkInverterOrdem.Location = New System.Drawing.Point(17, 128)
        Me.chkInverterOrdem.Name = "chkInverterOrdem"
        Me.chkInverterOrdem.Size = New System.Drawing.Size(165, 17)
        Me.chkInverterOrdem.TabIndex = 0
        Me.chkInverterOrdem.Text = "&Inverter ordem de exportação"
        Me.ToolTip1.SetToolTip(Me.chkInverterOrdem, "Faz com que a ordem de exportação seja invertida." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Desta forma, a sequência de im" & _
                "pressão em certas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "impressoras colocará as folhas na ordem sequencial" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "correta.")
        Me.chkInverterOrdem.UseVisualStyleBackColor = True
        '
        'chkFecharDesenhos
        '
        Me.chkFecharDesenhos.AutoSize = True
        Me.chkFecharDesenhos.Location = New System.Drawing.Point(17, 105)
        Me.chkFecharDesenhos.Name = "chkFecharDesenhos"
        Me.chkFecharDesenhos.Size = New System.Drawing.Size(204, 17)
        Me.chkFecharDesenhos.TabIndex = 0
        Me.chkFecharDesenhos.Text = "Fechar os &desenhos após exportação"
        Me.ToolTip1.SetToolTip(Me.chkFecharDesenhos, "Esta opção permite que, após cada operação de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "exportação, os desenhos sejam fech" & _
                "ados para" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "economizar recursos operacionais do sistema.")
        Me.chkFecharDesenhos.UseVisualStyleBackColor = True
        '
        'chkIgnorarSalvar
        '
        Me.chkIgnorarSalvar.AutoSize = True
        Me.chkIgnorarSalvar.Location = New System.Drawing.Point(36, 69)
        Me.chkIgnorarSalvar.Name = "chkIgnorarSalvar"
        Me.chkIgnorarSalvar.Size = New System.Drawing.Size(260, 30)
        Me.chkIgnorarSalvar.TabIndex = 0
        Me.chkIgnorarSalvar.Text = "Ignorar as mensagens ""&Deseja salvar o arquivo?""" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "antes do fechamento do mesmo"
        Me.ToolTip1.SetToolTip(Me.chkIgnorarSalvar, resources.GetString("chkIgnorarSalvar.ToolTip"))
        Me.chkIgnorarSalvar.UseVisualStyleBackColor = True
        '
        'chkSilentMode
        '
        Me.chkSilentMode.AutoSize = True
        Me.chkSilentMode.Location = New System.Drawing.Point(17, 46)
        Me.chkSilentMode.Name = "chkSilentMode"
        Me.chkSilentMode.Size = New System.Drawing.Size(252, 17)
        Me.chkSilentMode.TabIndex = 0
        Me.chkSilentMode.Text = "Ignorar &todas as mensagens de erro do Inventor"
        Me.ToolTip1.SetToolTip(Me.chkSilentMode, resources.GetString("chkSilentMode.ToolTip"))
        Me.chkSilentMode.UseVisualStyleBackColor = True
        '
        'chkFecharAuto
        '
        Me.chkFecharAuto.AutoSize = True
        Me.chkFecharAuto.Location = New System.Drawing.Point(17, 23)
        Me.chkFecharAuto.Name = "chkFecharAuto"
        Me.chkFecharAuto.Size = New System.Drawing.Size(224, 17)
        Me.chkFecharAuto.TabIndex = 0
        Me.chkFecharAuto.Text = "&Fechar o programa ao finalizar exportação"
        Me.ToolTip1.SetToolTip(Me.chkFecharAuto, "Esta opção faz com que, após completar a tarefa de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "exportação, o programa feche " & _
                "automaticamente.")
        Me.chkFecharAuto.UseVisualStyleBackColor = True
        '
        'TabPesquisa
        '
        Me.TabPesquisa.Controls.Add(Me.GroupBox2)
        Me.TabPesquisa.Controls.Add(Me.chkPesquisarSubpastas)
        Me.TabPesquisa.Controls.Add(Me.chkPesquisaPrimeiro)
        Me.TabPesquisa.Controls.Add(Me.cmdUpPesquisa)
        Me.TabPesquisa.Controls.Add(Me.cmdDownPesquisa)
        Me.TabPesquisa.Controls.Add(Me.cmdExcluirPastaPesquisa)
        Me.TabPesquisa.Controls.Add(Me.cmdAdicionarPastaPesquisa)
        Me.TabPesquisa.Controls.Add(Me.lstLocaisPadraoPesquisa)
        Me.TabPesquisa.Controls.Add(Me.Label4)
        Me.TabPesquisa.Location = New System.Drawing.Point(4, 22)
        Me.TabPesquisa.Name = "TabPesquisa"
        Me.TabPesquisa.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPesquisa.Size = New System.Drawing.Size(350, 476)
        Me.TabPesquisa.TabIndex = 1
        Me.TabPesquisa.Text = "Pesquisa"
        Me.TabPesquisa.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkPesquisarDWG)
        Me.GroupBox2.Controls.Add(Me.chkPesquisarIDW)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 241)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(167, 68)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'chkPesquisarDWG
        '
        Me.chkPesquisarDWG.AutoSize = True
        Me.chkPesquisarDWG.Location = New System.Drawing.Point(8, 39)
        Me.chkPesquisarDWG.Name = "chkPesquisarDWG"
        Me.chkPesquisarDWG.Size = New System.Drawing.Size(145, 17)
        Me.chkPesquisarDWG.TabIndex = 0
        Me.chkPesquisarDWG.Text = "Pesquisar arquivos D&WG"
        Me.chkPesquisarDWG.UseVisualStyleBackColor = True
        '
        'chkPesquisarIDW
        '
        Me.chkPesquisarIDW.AutoSize = True
        Me.chkPesquisarIDW.Location = New System.Drawing.Point(8, 16)
        Me.chkPesquisarIDW.Name = "chkPesquisarIDW"
        Me.chkPesquisarIDW.Size = New System.Drawing.Size(140, 17)
        Me.chkPesquisarIDW.TabIndex = 0
        Me.chkPesquisarIDW.Text = "Pesquisar arquivos I&DW"
        Me.chkPesquisarIDW.UseVisualStyleBackColor = True
        '
        'chkPesquisarSubpastas
        '
        Me.chkPesquisarSubpastas.AutoSize = True
        Me.chkPesquisarSubpastas.Location = New System.Drawing.Point(20, 225)
        Me.chkPesquisarSubpastas.Name = "chkPesquisarSubpastas"
        Me.chkPesquisarSubpastas.Size = New System.Drawing.Size(125, 17)
        Me.chkPesquisarSubpastas.TabIndex = 3
        Me.chkPesquisarSubpastas.Text = "Pesquisar S&ubpastas"
        Me.ToolTip1.SetToolTip(Me.chkPesquisarSubpastas, "Marcar esta opção faz com que o mecanismo de pesquisa pesquisa a árvore inteira d" & _
                "entro de um local de pesquisa.")
        Me.chkPesquisarSubpastas.UseVisualStyleBackColor = True
        '
        'chkPesquisaPrimeiro
        '
        Me.chkPesquisaPrimeiro.AutoSize = True
        Me.chkPesquisaPrimeiro.Location = New System.Drawing.Point(20, 202)
        Me.chkPesquisaPrimeiro.Name = "chkPesquisaPrimeiro"
        Me.chkPesquisaPrimeiro.Size = New System.Drawing.Size(257, 17)
        Me.chkPesquisaPrimeiro.TabIndex = 3
        Me.chkPesquisaPrimeiro.Text = "&Parar de procurar no primeiro arquivo encontrado"
        Me.ToolTip1.SetToolTip(Me.chkPesquisaPrimeiro, resources.GetString("chkPesquisaPrimeiro.ToolTip"))
        Me.chkPesquisaPrimeiro.UseVisualStyleBackColor = True
        '
        'cmdUpPesquisa
        '
        Me.cmdUpPesquisa.Enabled = False
        Me.cmdUpPesquisa.ImageKey = "UpArrow.png"
        Me.cmdUpPesquisa.ImageList = Me.ImageList1
        Me.cmdUpPesquisa.Location = New System.Drawing.Point(38, 151)
        Me.cmdUpPesquisa.Name = "cmdUpPesquisa"
        Me.cmdUpPesquisa.Size = New System.Drawing.Size(32, 32)
        Me.cmdUpPesquisa.TabIndex = 2
        Me.cmdUpPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUpPesquisa.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Black
        Me.ImageList1.Images.SetKeyName(0, "kfloppy.png")
        Me.ImageList1.Images.SetKeyName(1, "edit_add.png")
        Me.ImageList1.Images.SetKeyName(2, "cancel.png")
        Me.ImageList1.Images.SetKeyName(3, "Undo.png")
        Me.ImageList1.Images.SetKeyName(4, "1downarrow.png")
        Me.ImageList1.Images.SetKeyName(5, "1uparrow.png")
        Me.ImageList1.Images.SetKeyName(6, "UpArrow.png")
        Me.ImageList1.Images.SetKeyName(7, "DownArrow.png")
        Me.ImageList1.Images.SetKeyName(8, "folder_yellow.png")
        Me.ImageList1.Images.SetKeyName(9, "IniFile.png")
        '
        'cmdDownPesquisa
        '
        Me.cmdDownPesquisa.Enabled = False
        Me.cmdDownPesquisa.ImageKey = "DownArrow.png"
        Me.cmdDownPesquisa.ImageList = Me.ImageList1
        Me.cmdDownPesquisa.Location = New System.Drawing.Point(76, 151)
        Me.cmdDownPesquisa.Name = "cmdDownPesquisa"
        Me.cmdDownPesquisa.Size = New System.Drawing.Size(32, 32)
        Me.cmdDownPesquisa.TabIndex = 2
        Me.cmdDownPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDownPesquisa.UseVisualStyleBackColor = True
        '
        'cmdExcluirPastaPesquisa
        '
        Me.cmdExcluirPastaPesquisa.Enabled = False
        Me.cmdExcluirPastaPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExcluirPastaPesquisa.ImageKey = "cancel.png"
        Me.cmdExcluirPastaPesquisa.ImageList = Me.ImageList1
        Me.cmdExcluirPastaPesquisa.Location = New System.Drawing.Point(114, 151)
        Me.cmdExcluirPastaPesquisa.Name = "cmdExcluirPastaPesquisa"
        Me.cmdExcluirPastaPesquisa.Size = New System.Drawing.Size(94, 32)
        Me.cmdExcluirPastaPesquisa.TabIndex = 2
        Me.cmdExcluirPastaPesquisa.Text = "E&xcluir Pasta"
        Me.cmdExcluirPastaPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExcluirPastaPesquisa.UseVisualStyleBackColor = True
        '
        'cmdAdicionarPastaPesquisa
        '
        Me.cmdAdicionarPastaPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdicionarPastaPesquisa.ImageKey = "folder_yellow.png"
        Me.cmdAdicionarPastaPesquisa.ImageList = Me.ImageList1
        Me.cmdAdicionarPastaPesquisa.Location = New System.Drawing.Point(214, 151)
        Me.cmdAdicionarPastaPesquisa.Name = "cmdAdicionarPastaPesquisa"
        Me.cmdAdicionarPastaPesquisa.Size = New System.Drawing.Size(117, 32)
        Me.cmdAdicionarPastaPesquisa.TabIndex = 2
        Me.cmdAdicionarPastaPesquisa.Text = "&Adicionar Pasta..."
        Me.cmdAdicionarPastaPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionarPastaPesquisa.UseVisualStyleBackColor = True
        '
        'lstLocaisPadraoPesquisa
        '
        Me.lstLocaisPadraoPesquisa.FormattingEnabled = True
        Me.lstLocaisPadraoPesquisa.Location = New System.Drawing.Point(20, 37)
        Me.lstLocaisPadraoPesquisa.Name = "lstLocaisPadraoPesquisa"
        Me.lstLocaisPadraoPesquisa.Size = New System.Drawing.Size(311, 108)
        Me.lstLocaisPadraoPesquisa.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Locais padrão de pesquisa:"
        '
        'TabFormatos
        '
        Me.TabFormatos.Controls.Add(Me.cmdExcluirFormato)
        Me.TabFormatos.Controls.Add(Me.cmdUpFormato)
        Me.TabFormatos.Controls.Add(Me.cmdDownFormato)
        Me.TabFormatos.Controls.Add(Me.cmdCancelarFormato)
        Me.TabFormatos.Controls.Add(Me.cmdAdicionarFormato)
        Me.TabFormatos.Controls.Add(Me.cmdAlterarFormato)
        Me.TabFormatos.Controls.Add(Me.GroupBox1)
        Me.TabFormatos.Controls.Add(Me.txtLargura)
        Me.TabFormatos.Controls.Add(Me.txtAltura)
        Me.TabFormatos.Controls.Add(Me.txtDescricao)
        Me.TabFormatos.Controls.Add(Me.Label5)
        Me.TabFormatos.Controls.Add(Me.Label3)
        Me.TabFormatos.Controls.Add(Me.lstFormatos)
        Me.TabFormatos.Controls.Add(Me.Label2)
        Me.TabFormatos.Controls.Add(Me.Label1)
        Me.TabFormatos.Location = New System.Drawing.Point(4, 22)
        Me.TabFormatos.Name = "TabFormatos"
        Me.TabFormatos.Size = New System.Drawing.Size(350, 476)
        Me.TabFormatos.TabIndex = 2
        Me.TabFormatos.Text = "Formatos"
        Me.TabFormatos.UseVisualStyleBackColor = True
        '
        'cmdExcluirFormato
        '
        Me.cmdExcluirFormato.Enabled = False
        Me.cmdExcluirFormato.ImageKey = "cancel.png"
        Me.cmdExcluirFormato.ImageList = Me.ImageList1
        Me.cmdExcluirFormato.Location = New System.Drawing.Point(229, 268)
        Me.cmdExcluirFormato.Name = "cmdExcluirFormato"
        Me.cmdExcluirFormato.Size = New System.Drawing.Size(32, 32)
        Me.cmdExcluirFormato.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdExcluirFormato, "Exclui este formato")
        Me.cmdExcluirFormato.UseVisualStyleBackColor = True
        '
        'cmdUpFormato
        '
        Me.cmdUpFormato.Enabled = False
        Me.cmdUpFormato.ImageKey = "UpArrow.png"
        Me.cmdUpFormato.ImageList = Me.ImageList1
        Me.cmdUpFormato.Location = New System.Drawing.Point(191, 230)
        Me.cmdUpFormato.Name = "cmdUpFormato"
        Me.cmdUpFormato.Padding = New System.Windows.Forms.Padding(1)
        Me.cmdUpFormato.Size = New System.Drawing.Size(32, 32)
        Me.cmdUpFormato.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdUpFormato, "Move este ítem uma linha para cima")
        Me.cmdUpFormato.UseVisualStyleBackColor = True
        '
        'cmdDownFormato
        '
        Me.cmdDownFormato.Enabled = False
        Me.cmdDownFormato.ImageKey = "DownArrow.png"
        Me.cmdDownFormato.ImageList = Me.ImageList1
        Me.cmdDownFormato.Location = New System.Drawing.Point(191, 268)
        Me.cmdDownFormato.Name = "cmdDownFormato"
        Me.cmdDownFormato.Size = New System.Drawing.Size(32, 32)
        Me.cmdDownFormato.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdDownFormato, "Move este ítem uma linha para baixo")
        Me.cmdDownFormato.UseVisualStyleBackColor = True
        '
        'cmdCancelarFormato
        '
        Me.cmdCancelarFormato.Enabled = False
        Me.cmdCancelarFormato.ImageKey = "Undo.png"
        Me.cmdCancelarFormato.ImageList = Me.ImageList1
        Me.cmdCancelarFormato.Location = New System.Drawing.Point(267, 268)
        Me.cmdCancelarFormato.Name = "cmdCancelarFormato"
        Me.cmdCancelarFormato.Size = New System.Drawing.Size(32, 32)
        Me.cmdCancelarFormato.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdCancelarFormato, "Cancela a edição deste ítem.")
        Me.cmdCancelarFormato.UseVisualStyleBackColor = True
        '
        'cmdAdicionarFormato
        '
        Me.cmdAdicionarFormato.ImageKey = "edit_add.png"
        Me.cmdAdicionarFormato.ImageList = Me.ImageList1
        Me.cmdAdicionarFormato.Location = New System.Drawing.Point(229, 230)
        Me.cmdAdicionarFormato.Name = "cmdAdicionarFormato"
        Me.cmdAdicionarFormato.Size = New System.Drawing.Size(32, 32)
        Me.cmdAdicionarFormato.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdAdicionarFormato, "Adiciona um formato de folha")
        Me.cmdAdicionarFormato.UseVisualStyleBackColor = True
        '
        'cmdAlterarFormato
        '
        Me.cmdAlterarFormato.Enabled = False
        Me.cmdAlterarFormato.ImageKey = "kfloppy.png"
        Me.cmdAlterarFormato.ImageList = Me.ImageList1
        Me.cmdAlterarFormato.Location = New System.Drawing.Point(267, 230)
        Me.cmdAlterarFormato.Name = "cmdAlterarFormato"
        Me.cmdAlterarFormato.Size = New System.Drawing.Size(32, 32)
        Me.cmdAlterarFormato.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdAlterarFormato, "Salva as edições neste formato de folha")
        Me.cmdAlterarFormato.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optMilimetros)
        Me.GroupBox1.Controls.Add(Me.optPolegadas)
        Me.GroupBox1.Location = New System.Drawing.Point(191, 153)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(120, 71)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Unidades"
        '
        'optMilimetros
        '
        Me.optMilimetros.AutoSize = True
        Me.optMilimetros.Checked = True
        Me.optMilimetros.Enabled = False
        Me.optMilimetros.Location = New System.Drawing.Point(8, 42)
        Me.optMilimetros.Name = "optMilimetros"
        Me.optMilimetros.Size = New System.Drawing.Size(73, 17)
        Me.optMilimetros.TabIndex = 0
        Me.optMilimetros.TabStop = True
        Me.optMilimetros.Text = "&Milímetros"
        Me.ToolTip1.SetToolTip(Me.optMilimetros, "Especifica a unidade do formato atual em milímetros")
        Me.optMilimetros.UseVisualStyleBackColor = True
        '
        'optPolegadas
        '
        Me.optPolegadas.AutoSize = True
        Me.optPolegadas.Enabled = False
        Me.optPolegadas.Location = New System.Drawing.Point(8, 19)
        Me.optPolegadas.Name = "optPolegadas"
        Me.optPolegadas.Size = New System.Drawing.Size(75, 17)
        Me.optPolegadas.TabIndex = 0
        Me.optPolegadas.Text = "&Polegadas"
        Me.ToolTip1.SetToolTip(Me.optPolegadas, "Especifica a unidade do formato atual em polegadas")
        Me.optPolegadas.UseVisualStyleBackColor = True
        '
        'txtLargura
        '
        Me.txtLargura.Enabled = False
        Me.txtLargura.Location = New System.Drawing.Point(259, 113)
        Me.txtLargura.Name = "txtLargura"
        Me.txtLargura.Size = New System.Drawing.Size(52, 20)
        Me.txtLargura.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtLargura, "Largura na unidade especificada")
        '
        'txtAltura
        '
        Me.txtAltura.Enabled = False
        Me.txtAltura.Location = New System.Drawing.Point(191, 113)
        Me.txtAltura.Name = "txtAltura"
        Me.txtAltura.Size = New System.Drawing.Size(52, 20)
        Me.txtAltura.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtAltura, "Altura na unidade especificada")
        '
        'txtDescricao
        '
        Me.txtDescricao.Enabled = False
        Me.txtDescricao.Location = New System.Drawing.Point(191, 65)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(117, 20)
        Me.txtDescricao.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtDescricao, "Nome do formato de arquivo")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(246, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "x"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(188, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Dimensões"
        '
        'lstFormatos
        '
        Me.lstFormatos.FormattingEnabled = True
        Me.lstFormatos.Location = New System.Drawing.Point(25, 51)
        Me.lstFormatos.Name = "lstFormatos"
        Me.lstFormatos.Size = New System.Drawing.Size(141, 251)
        Me.lstFormatos.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(188, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descrição"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Formatos Disponíveis:"
        '
        'TabExportar
        '
        Me.TabExportar.Controls.Add(Me.GroupBox4)
        Me.TabExportar.Controls.Add(Me.GroupBox3)
        Me.TabExportar.Location = New System.Drawing.Point(4, 22)
        Me.TabExportar.Name = "TabExportar"
        Me.TabExportar.Padding = New System.Windows.Forms.Padding(3)
        Me.TabExportar.Size = New System.Drawing.Size(350, 476)
        Me.TabExportar.TabIndex = 3
        Me.TabExportar.Text = "Exportação"
        Me.TabExportar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdIniFile)
        Me.GroupBox4.Controls.Add(Me.txtIniFile)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 148)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(336, 92)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Opções de DWG/DXF"
        '
        'cmdIniFile
        '
        Me.cmdIniFile.ImageKey = "IniFile.png"
        Me.cmdIniFile.ImageList = Me.ImageList1
        Me.cmdIniFile.Location = New System.Drawing.Point(10, 44)
        Me.cmdIniFile.Name = "cmdIniFile"
        Me.cmdIniFile.Size = New System.Drawing.Size(32, 32)
        Me.cmdIniFile.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cmdIniFile, resources.GetString("cmdIniFile.ToolTip"))
        Me.cmdIniFile.UseVisualStyleBackColor = True
        '
        'txtIniFile
        '
        Me.txtIniFile.Enabled = False
        Me.txtIniFile.Location = New System.Drawing.Point(48, 51)
        Me.txtIniFile.Name = "txtIniFile"
        Me.txtIniFile.Size = New System.Drawing.Size(280, 20)
        Me.txtIniFile.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(261, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Utilizar as opções selecionadas no arquivo .ini abaixo:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkRemoveLineweightsPDF)
        Me.GroupBox3.Controls.Add(Me.chkMonochromePDF)
        Me.GroupBox3.Controls.Add(Me.cmbResolucaoPDF)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cmbFolhasPDF)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(337, 130)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opções de PDF"
        '
        'chkRemoveLineweightsPDF
        '
        Me.chkRemoveLineweightsPDF.AutoSize = True
        Me.chkRemoveLineweightsPDF.Location = New System.Drawing.Point(11, 103)
        Me.chkRemoveLineweightsPDF.Name = "chkRemoveLineweightsPDF"
        Me.chkRemoveLineweightsPDF.Size = New System.Drawing.Size(165, 17)
        Me.chkRemoveLineweightsPDF.TabIndex = 2
        Me.chkRemoveLineweightsPDF.Text = "&Remover espessuras de linha"
        Me.ToolTip1.SetToolTip(Me.chkRemoveLineweightsPDF, "Esta opção remove todas as espessuras de linha ao " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "gerar os PDFs.")
        Me.chkRemoveLineweightsPDF.UseVisualStyleBackColor = True
        '
        'chkMonochromePDF
        '
        Me.chkMonochromePDF.AutoSize = True
        Me.chkMonochromePDF.Location = New System.Drawing.Point(11, 80)
        Me.chkMonochromePDF.Name = "chkMonochromePDF"
        Me.chkMonochromePDF.Size = New System.Drawing.Size(155, 17)
        Me.chkMonochromePDF.TabIndex = 2
        Me.chkMonochromePDF.Text = "&Todas as cores como preto"
        Me.ToolTip1.SetToolTip(Me.chkMonochromePDF, "Esta opção vai exportar todos os PDFs com linhas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "em preto (As vistas coloridas " & _
                "e imagens são exportadas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "em cores)")
        Me.chkMonochromePDF.UseVisualStyleBackColor = True
        '
        'cmbResolucaoPDF
        '
        Me.cmbResolucaoPDF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResolucaoPDF.FormattingEnabled = True
        Me.cmbResolucaoPDF.Items.AddRange(New Object() {"150 DPI", "200 DPI", "300 DPI", "400 DPI", "600 DPI", "720 DPI", "1200 DPI", "2400 DPI", "4800 DPI"})
        Me.cmbResolucaoPDF.Location = New System.Drawing.Point(113, 50)
        Me.cmbResolucaoPDF.Name = "cmbResolucaoPDF"
        Me.cmbResolucaoPDF.Size = New System.Drawing.Size(210, 21)
        Me.cmbResolucaoPDF.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Resolução Vetorial:"
        '
        'cmbFolhasPDF
        '
        Me.cmbFolhasPDF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFolhasPDF.FormattingEnabled = True
        Me.cmbFolhasPDF.Items.AddRange(New Object() {"Todas as Folhas", "Somente a Primeira Folha"})
        Me.cmbFolhasPDF.Location = New System.Drawing.Point(113, 23)
        Me.cmbFolhasPDF.Name = "cmbFolhasPDF"
        Me.cmbFolhasPDF.Size = New System.Drawing.Size(210, 21)
        Me.cmbFolhasPDF.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Folhas a Exportar:"
        '
        'TabImprimir
        '
        Me.TabImprimir.Controls.Add(Me.GroupBox5)
        Me.TabImprimir.Location = New System.Drawing.Point(4, 22)
        Me.TabImprimir.Name = "TabImprimir"
        Me.TabImprimir.Padding = New System.Windows.Forms.Padding(3)
        Me.TabImprimir.Size = New System.Drawing.Size(350, 476)
        Me.TabImprimir.TabIndex = 4
        Me.TabImprimir.Text = "Impressão"
        Me.TabImprimir.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkImpressaoAgruparFormatos)
        Me.GroupBox5.Controls.Add(Me.chkImpressaoInverter)
        Me.GroupBox5.Controls.Add(Me.chkImpressaoRotacionar90)
        Me.GroupBox5.Controls.Add(Me.chkImpressaoRemoveLineweights)
        Me.GroupBox5.Controls.Add(Me.chkImpressaoMonochrome)
        Me.GroupBox5.Controls.Add(Me.updNumCopias)
        Me.GroupBox5.Controls.Add(Me.cmbImpressaoFolhas)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 11)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(337, 194)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Opções de Impressão"
        '
        'chkImpressaoAgruparFormatos
        '
        Me.chkImpressaoAgruparFormatos.AutoSize = True
        Me.chkImpressaoAgruparFormatos.Enabled = False
        Me.chkImpressaoAgruparFormatos.Location = New System.Drawing.Point(9, 169)
        Me.chkImpressaoAgruparFormatos.Name = "chkImpressaoAgruparFormatos"
        Me.chkImpressaoAgruparFormatos.Size = New System.Drawing.Size(140, 17)
        Me.chkImpressaoAgruparFormatos.TabIndex = 3
        Me.chkImpressaoAgruparFormatos.Text = "&Agrupar Formatos Iguais"
        Me.ToolTip1.SetToolTip(Me.chkImpressaoAgruparFormatos, resources.GetString("chkImpressaoAgruparFormatos.ToolTip"))
        Me.chkImpressaoAgruparFormatos.UseVisualStyleBackColor = True
        '
        'chkImpressaoInverter
        '
        Me.chkImpressaoInverter.AutoSize = True
        Me.chkImpressaoInverter.Location = New System.Drawing.Point(9, 146)
        Me.chkImpressaoInverter.Name = "chkImpressaoInverter"
        Me.chkImpressaoInverter.Size = New System.Drawing.Size(117, 17)
        Me.chkImpressaoInverter.TabIndex = 3
        Me.chkImpressaoInverter.Text = "&Inverter Dimensões"
        Me.ToolTip1.SetToolTip(Me.chkImpressaoInverter, "Inverte altura com largura. Em algumas impressoras," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "esta configuração traz resul" & _
                "tados mais satisfatórios de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "impressão.")
        Me.chkImpressaoInverter.UseVisualStyleBackColor = True
        '
        'chkImpressaoRotacionar90
        '
        Me.chkImpressaoRotacionar90.AutoSize = True
        Me.chkImpressaoRotacionar90.Location = New System.Drawing.Point(9, 123)
        Me.chkImpressaoRotacionar90.Name = "chkImpressaoRotacionar90"
        Me.chkImpressaoRotacionar90.Size = New System.Drawing.Size(97, 17)
        Me.chkImpressaoRotacionar90.TabIndex = 3
        Me.chkImpressaoRotacionar90.Text = "Rotacionar &90º"
        Me.ToolTip1.SetToolTip(Me.chkImpressaoRotacionar90, "Esta opção rotaciona todas as folhas 90 graus." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Em certas impressoras, isto faz c" & _
                "om que as folhas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "saiam da maneira correta.")
        Me.chkImpressaoRotacionar90.UseVisualStyleBackColor = True
        '
        'chkImpressaoRemoveLineweights
        '
        Me.chkImpressaoRemoveLineweights.AutoSize = True
        Me.chkImpressaoRemoveLineweights.Location = New System.Drawing.Point(9, 100)
        Me.chkImpressaoRemoveLineweights.Name = "chkImpressaoRemoveLineweights"
        Me.chkImpressaoRemoveLineweights.Size = New System.Drawing.Size(165, 17)
        Me.chkImpressaoRemoveLineweights.TabIndex = 3
        Me.chkImpressaoRemoveLineweights.Text = "&Remover espessuras de linha"
        Me.ToolTip1.SetToolTip(Me.chkImpressaoRemoveLineweights, "Esta opção remove espessuras de linha" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "das impressões.")
        Me.chkImpressaoRemoveLineweights.UseVisualStyleBackColor = True
        '
        'chkImpressaoMonochrome
        '
        Me.chkImpressaoMonochrome.AutoSize = True
        Me.chkImpressaoMonochrome.Location = New System.Drawing.Point(9, 77)
        Me.chkImpressaoMonochrome.Name = "chkImpressaoMonochrome"
        Me.chkImpressaoMonochrome.Size = New System.Drawing.Size(155, 17)
        Me.chkImpressaoMonochrome.TabIndex = 3
        Me.chkImpressaoMonochrome.Text = "&Todas as cores como preto"
        Me.ToolTip1.SetToolTip(Me.chkImpressaoMonochrome, "Esta opção vai imprimir todos os documentos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "com cores em preto. (Vistas colorida" & _
                "s e Imagens" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "não são afetadas por esta opção)")
        Me.chkImpressaoMonochrome.UseVisualStyleBackColor = True
        '
        'updNumCopias
        '
        Me.updNumCopias.Location = New System.Drawing.Point(105, 51)
        Me.updNumCopias.Name = "updNumCopias"
        Me.updNumCopias.Size = New System.Drawing.Size(36, 20)
        Me.updNumCopias.TabIndex = 2
        '
        'cmbImpressaoFolhas
        '
        Me.cmbImpressaoFolhas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpressaoFolhas.FormattingEnabled = True
        Me.cmbImpressaoFolhas.Items.AddRange(New Object() {"Todas as Folhas", "Somente a Primeira Folha"})
        Me.cmbImpressaoFolhas.Location = New System.Drawing.Point(105, 24)
        Me.cmbImpressaoFolhas.Name = "cmbImpressaoFolhas"
        Me.cmbImpressaoFolhas.Size = New System.Drawing.Size(217, 21)
        Me.cmbImpressaoFolhas.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Número de Cópias:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Folhas a Imprimir:"
        '
        'cmdSaveClose
        '
        Me.cmdSaveClose.Location = New System.Drawing.Point(238, 512)
        Me.cmdSaveClose.Name = "cmdSaveClose"
        Me.cmdSaveClose.Size = New System.Drawing.Size(118, 30)
        Me.cmdSaveClose.TabIndex = 1
        Me.cmdSaveClose.Text = "&Salvar e Fechar"
        Me.ToolTip1.SetToolTip(Me.cmdSaveClose, "Salva as configurações, mantendo-as" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sempre que o Inventor for iniciado, e fecha" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "esta janela.")
        Me.cmdSaveClose.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Location = New System.Drawing.Point(114, 512)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(118, 30)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "&Cancelar"
        Me.ToolTip1.SetToolTip(Me.cmdCancelar, "Ignora todas as mudanças feitas nesta janela.")
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'DialogoIni
        '
        Me.DialogoIni.Filter = "Arquivos de Inicialização (*.ini)|*.ini"
        Me.DialogoIni.Title = "Escolher Arquivo de Configuração..."
        '
        'frmOpcoesGeral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(361, 545)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdSaveClose)
        Me.Controls.Add(Me.Abas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOpcoesGeral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurações"
        Me.Abas.ResumeLayout(False)
        Me.TabGeral.ResumeLayout(False)
        Me.TabGeral.PerformLayout()
        Me.TabPesquisa.ResumeLayout(False)
        Me.TabPesquisa.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabFormatos.ResumeLayout(False)
        Me.TabFormatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabExportar.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabImprimir.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.updNumCopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Abas As System.Windows.Forms.TabControl
    Friend WithEvents TabGeral As System.Windows.Forms.TabPage
    Friend WithEvents TabFormatos As System.Windows.Forms.TabPage
    Friend WithEvents cmdSaveClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents lstFormatos As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optMilimetros As System.Windows.Forms.RadioButton
    Friend WithEvents optPolegadas As System.Windows.Forms.RadioButton
    Friend WithEvents txtLargura As System.Windows.Forms.TextBox
    Friend WithEvents txtAltura As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdAlterarFormato As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdCancelarFormato As System.Windows.Forms.Button
    Friend WithEvents cmdAdicionarFormato As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdExcluirFormato As System.Windows.Forms.Button
    Friend WithEvents cmdUpFormato As System.Windows.Forms.Button
    Friend WithEvents cmdDownFormato As System.Windows.Forms.Button
    Friend WithEvents DialogoPasta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TabPesquisa As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPesquisarDWG As System.Windows.Forms.CheckBox
    Friend WithEvents chkPesquisarIDW As System.Windows.Forms.CheckBox
    Friend WithEvents chkPesquisarSubpastas As System.Windows.Forms.CheckBox
    Friend WithEvents chkPesquisaPrimeiro As System.Windows.Forms.CheckBox
    Friend WithEvents cmdUpPesquisa As System.Windows.Forms.Button
    Friend WithEvents cmdDownPesquisa As System.Windows.Forms.Button
    Friend WithEvents cmdExcluirPastaPesquisa As System.Windows.Forms.Button
    Friend WithEvents cmdAdicionarPastaPesquisa As System.Windows.Forms.Button
    Friend WithEvents lstLocaisPadraoPesquisa As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkFecharDesenhos As System.Windows.Forms.CheckBox
    Friend WithEvents chkIgnorarSalvar As System.Windows.Forms.CheckBox
    Friend WithEvents chkSilentMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkFecharAuto As System.Windows.Forms.CheckBox
    Friend WithEvents TabExportar As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFolhasPDF As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkRemoveLineweightsPDF As System.Windows.Forms.CheckBox
    Friend WithEvents chkMonochromePDF As System.Windows.Forms.CheckBox
    Friend WithEvents cmbResolucaoPDF As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabImprimir As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkImpressaoRotacionar90 As System.Windows.Forms.CheckBox
    Friend WithEvents chkImpressaoRemoveLineweights As System.Windows.Forms.CheckBox
    Friend WithEvents chkImpressaoMonochrome As System.Windows.Forms.CheckBox
    Friend WithEvents updNumCopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbImpressaoFolhas As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkImpressaoAgruparFormatos As System.Windows.Forms.CheckBox
    Friend WithEvents chkInverterOrdem As System.Windows.Forms.CheckBox
    Friend WithEvents cmdIniFile As System.Windows.Forms.Button
    Friend WithEvents txtIniFile As System.Windows.Forms.TextBox
    Friend WithEvents DialogoIni As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkImpressaoInverter As System.Windows.Forms.CheckBox
End Class
