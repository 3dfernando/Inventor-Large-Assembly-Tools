<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaArquivos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListaArquivos))
        Me.lstArquivos = New System.Windows.Forms.ListView()
        Me.mnuListaArquivos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mniFormato = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniPosicao = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPosImprPredef = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniPosImprRetrato = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniPosImprPaisagem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniSelecionarTudo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdIncluirArquivos = New System.Windows.Forms.Button()
        Me.cmdIncluirPasta = New System.Windows.Forms.Button()
        Me.DialogPasta = New System.Windows.Forms.FolderBrowserDialog()
        Me.DialogArquivos = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkSubPastas = New System.Windows.Forms.CheckBox()
        Me.chkIDW = New System.Windows.Forms.CheckBox()
        Me.chkDWG = New System.Windows.Forms.CheckBox()
        Me.cmdSaveClose = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdOpcoesPesquisa = New System.Windows.Forms.Button()
        Me.cmdPesquisa = New System.Windows.Forms.Button()
        Me.txtPesquisa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdPesquisarArquivos = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdIncluirMontagem = New System.Windows.Forms.Button()
        Me.mnuListaArquivos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstArquivos
        '
        Me.lstArquivos.CheckBoxes = True
        Me.lstArquivos.ContextMenuStrip = Me.mnuListaArquivos
        Me.lstArquivos.FullRowSelect = True
        Me.lstArquivos.GridLines = True
        Me.lstArquivos.Location = New System.Drawing.Point(153, 12)
        Me.lstArquivos.Name = "lstArquivos"
        Me.lstArquivos.Size = New System.Drawing.Size(564, 456)
        Me.lstArquivos.SmallImageList = Me.ImageList1
        Me.lstArquivos.TabIndex = 0
        Me.lstArquivos.UseCompatibleStateImageBehavior = False
        Me.lstArquivos.View = System.Windows.Forms.View.Details
        '
        'mnuListaArquivos
        '
        Me.mnuListaArquivos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniFormato, Me.mniPosicao, Me.mniSelecionarTudo})
        Me.mnuListaArquivos.Name = "mnuFormatoPagina"
        Me.mnuListaArquivos.Size = New System.Drawing.Size(189, 70)
        '
        'mniFormato
        '
        Me.mniFormato.Name = "mniFormato"
        Me.mniFormato.Size = New System.Drawing.Size(188, 22)
        Me.mniFormato.Text = "Formato da Folha"
        '
        'mniPosicao
        '
        Me.mniPosicao.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPosImprPredef, Me.mniPosImprRetrato, Me.mniPosImprPaisagem})
        Me.mniPosicao.Name = "mniPosicao"
        Me.mniPosicao.Size = New System.Drawing.Size(188, 22)
        Me.mniPosicao.Text = "Posição de Impressão"
        '
        'mnuPosImprPredef
        '
        Me.mnuPosImprPredef.Name = "mnuPosImprPredef"
        Me.mnuPosImprPredef.Size = New System.Drawing.Size(193, 22)
        Me.mnuPosImprPredef.Text = "Configuração Definida"
        '
        'mniPosImprRetrato
        '
        Me.mniPosImprRetrato.Name = "mniPosImprRetrato"
        Me.mniPosImprRetrato.Size = New System.Drawing.Size(193, 22)
        Me.mniPosImprRetrato.Text = "Retrato"
        '
        'mniPosImprPaisagem
        '
        Me.mniPosImprPaisagem.Name = "mniPosImprPaisagem"
        Me.mniPosImprPaisagem.Size = New System.Drawing.Size(193, 22)
        Me.mniPosImprPaisagem.Text = "Paisagem"
        '
        'mniSelecionarTudo
        '
        Me.mniSelecionarTudo.Name = "mniSelecionarTudo"
        Me.mniSelecionarTudo.Size = New System.Drawing.Size(188, 22)
        Me.mniSelecionarTudo.Text = "Selecionar Tudo"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        Me.ImageList1.Images.SetKeyName(0, "folder_yellow.png")
        Me.ImageList1.Images.SetKeyName(1, "Inventor_idw.png")
        Me.ImageList1.Images.SetKeyName(2, "Autocad_dwg.png")
        Me.ImageList1.Images.SetKeyName(3, "search.png")
        Me.ImageList1.Images.SetKeyName(4, "kdb_form.png")
        Me.ImageList1.Images.SetKeyName(5, "iam.png")
        Me.ImageList1.Images.SetKeyName(6, "system-search-2.ico")
        Me.ImageList1.Images.SetKeyName(7, "folder-saved-search.ico")
        '
        'cmdIncluirArquivos
        '
        Me.cmdIncluirArquivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdIncluirArquivos.ImageKey = "Inventor_idw.png"
        Me.cmdIncluirArquivos.ImageList = Me.ImageList1
        Me.cmdIncluirArquivos.Location = New System.Drawing.Point(8, 12)
        Me.cmdIncluirArquivos.Name = "cmdIncluirArquivos"
        Me.cmdIncluirArquivos.Size = New System.Drawing.Size(135, 32)
        Me.cmdIncluirArquivos.TabIndex = 1
        Me.cmdIncluirArquivos.Text = "Include Drawings"
        Me.cmdIncluirArquivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdIncluirArquivos, "Opens a new window to include individual drawings.")
        Me.cmdIncluirArquivos.UseVisualStyleBackColor = True
        '
        'cmdIncluirPasta
        '
        Me.cmdIncluirPasta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdIncluirPasta.ImageKey = "folder_yellow.png"
        Me.cmdIncluirPasta.ImageList = Me.ImageList1
        Me.cmdIncluirPasta.Location = New System.Drawing.Point(4, 12)
        Me.cmdIncluirPasta.Name = "cmdIncluirPasta"
        Me.cmdIncluirPasta.Size = New System.Drawing.Size(135, 32)
        Me.cmdIncluirPasta.TabIndex = 1
        Me.cmdIncluirPasta.Text = "Include a Folder"
        Me.cmdIncluirPasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdIncluirPasta, "Opens a folder selection dialog to select a search folder.")
        Me.cmdIncluirPasta.UseVisualStyleBackColor = True
        '
        'DialogArquivos
        '
        Me.DialogArquivos.Filter = "Drawings do Inventor (*.idw)|*.idw|Drawings Inventor/CAD(*.dwg)|*.dwg"
        Me.DialogArquivos.Multiselect = True
        Me.DialogArquivos.RestoreDirectory = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSubPastas)
        Me.GroupBox1.Controls.Add(Me.chkIDW)
        Me.GroupBox1.Controls.Add(Me.chkDWG)
        Me.GroupBox1.Controls.Add(Me.cmdIncluirPasta)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(142, 123)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'chkSubPastas
        '
        Me.chkSubPastas.AutoSize = True
        Me.chkSubPastas.Location = New System.Drawing.Point(8, 50)
        Me.chkSubPastas.Name = "chkSubPastas"
        Me.chkSubPastas.Size = New System.Drawing.Size(113, 17)
        Me.chkSubPastas.TabIndex = 2
        Me.chkSubPastas.Text = "Search Subfolders"
        Me.ToolTip1.SetToolTip(Me.chkSubPastas, "Searches for drawing files inside the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "subfolders of the selected folder.")
        Me.chkSubPastas.UseVisualStyleBackColor = True
        '
        'chkIDW
        '
        Me.chkIDW.AutoSize = True
        Me.chkIDW.Checked = True
        Me.chkIDW.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIDW.Location = New System.Drawing.Point(13, 73)
        Me.chkIDW.Name = "chkIDW"
        Me.chkIDW.Size = New System.Drawing.Size(86, 17)
        Me.chkIDW.TabIndex = 2
        Me.chkIDW.Text = "Include I&DW"
        Me.ToolTip1.SetToolTip(Me.chkIDW, "Allows .IDW files to be included.")
        Me.chkIDW.UseVisualStyleBackColor = True
        '
        'chkDWG
        '
        Me.chkDWG.AutoSize = True
        Me.chkDWG.Location = New System.Drawing.Point(13, 96)
        Me.chkDWG.Name = "chkDWG"
        Me.chkDWG.Size = New System.Drawing.Size(91, 17)
        Me.chkDWG.TabIndex = 2
        Me.chkDWG.Text = "Include D&WG"
        Me.ToolTip1.SetToolTip(Me.chkDWG, "Allows .DWG files to be included.")
        Me.chkDWG.UseVisualStyleBackColor = True
        '
        'cmdSaveClose
        '
        Me.cmdSaveClose.Location = New System.Drawing.Point(602, 474)
        Me.cmdSaveClose.Name = "cmdSaveClose"
        Me.cmdSaveClose.Size = New System.Drawing.Size(115, 32)
        Me.cmdSaveClose.TabIndex = 4
        Me.cmdSaveClose.Text = "&Save and Close"
        Me.ToolTip1.SetToolTip(Me.cmdSaveClose, "Saves the changes and closes this window.")
        Me.cmdSaveClose.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Location = New System.Drawing.Point(481, 474)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(115, 32)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.cmdCancelar, "Closes this window and doesn't save the changes.")
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdOpcoesPesquisa)
        Me.GroupBox2.Controls.Add(Me.cmdPesquisa)
        Me.GroupBox2.Controls.Add(Me.txtPesquisa)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cmdPesquisarArquivos)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(142, 209)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'cmdOpcoesPesquisa
        '
        Me.cmdOpcoesPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOpcoesPesquisa.ImageIndex = 4
        Me.cmdOpcoesPesquisa.ImageList = Me.ImageList1
        Me.cmdOpcoesPesquisa.Location = New System.Drawing.Point(13, 164)
        Me.cmdOpcoesPesquisa.Name = "cmdOpcoesPesquisa"
        Me.cmdOpcoesPesquisa.Size = New System.Drawing.Size(116, 29)
        Me.cmdOpcoesPesquisa.TabIndex = 2
        Me.cmdOpcoesPesquisa.Text = "&Search Settings..."
        Me.cmdOpcoesPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdOpcoesPesquisa, "Opens a search settings dialog that'll allow you to change the search folders.")
        Me.cmdOpcoesPesquisa.UseVisualStyleBackColor = True
        '
        'cmdPesquisa
        '
        Me.cmdPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPesquisa.ImageIndex = 3
        Me.cmdPesquisa.ImageList = Me.ImageList1
        Me.cmdPesquisa.Location = New System.Drawing.Point(13, 60)
        Me.cmdPesquisa.Name = "cmdPesquisa"
        Me.cmdPesquisa.Size = New System.Drawing.Size(116, 29)
        Me.cmdPesquisa.TabIndex = 2
        Me.cmdPesquisa.Text = "Individual Search"
        Me.cmdPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdPesquisa, "Searches the search term in the selected search folders." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Changeable through the" &
        " Settings button below)")
        Me.cmdPesquisa.UseVisualStyleBackColor = True
        '
        'txtPesquisa
        '
        Me.txtPesquisa.Location = New System.Drawing.Point(10, 34)
        Me.txtPesquisa.Name = "txtPesquisa"
        Me.txtPesquisa.Size = New System.Drawing.Size(119, 20)
        Me.txtPesquisa.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtPesquisa, "Insert your search term here.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search a file:"
        '
        'cmdPesquisarArquivos
        '
        Me.cmdPesquisarArquivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPesquisarArquivos.ImageKey = "folder-saved-search.ico"
        Me.cmdPesquisarArquivos.ImageList = Me.ImageList1
        Me.cmdPesquisarArquivos.Location = New System.Drawing.Point(13, 129)
        Me.cmdPesquisarArquivos.Name = "cmdPesquisarArquivos"
        Me.cmdPesquisarArquivos.Size = New System.Drawing.Size(116, 29)
        Me.cmdPesquisarArquivos.TabIndex = 1
        Me.cmdPesquisarArquivos.Text = "Multiple search"
        Me.cmdPesquisarArquivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdPesquisarArquivos, "Performs a search of multiple search terms in the same dialog")
        Me.cmdPesquisarArquivos.UseVisualStyleBackColor = True
        '
        'cmdIncluirMontagem
        '
        Me.cmdIncluirMontagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdIncluirMontagem.ImageKey = "iam.png"
        Me.cmdIncluirMontagem.ImageList = Me.ImageList1
        Me.cmdIncluirMontagem.Location = New System.Drawing.Point(8, 50)
        Me.cmdIncluirMontagem.Name = "cmdIncluirMontagem"
        Me.cmdIncluirMontagem.Size = New System.Drawing.Size(135, 32)
        Me.cmdIncluirMontagem.TabIndex = 6
        Me.cmdIncluirMontagem.Text = "&Include Current Assy"
        Me.cmdIncluirMontagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdIncluirMontagem, "Opens all the drawing files referenced in the current assembly." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OBS: Only draw" &
        "ing files whose IDW/DWG filename " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "is the exact same as the IPT/IAM will be adde" &
        "d")
        Me.cmdIncluirMontagem.UseVisualStyleBackColor = True
        '
        'frmListaArquivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(729, 516)
        Me.Controls.Add(Me.cmdIncluirMontagem)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdSaveClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdIncluirArquivos)
        Me.Controls.Add(Me.lstArquivos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListaArquivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Files to Export"
        Me.mnuListaArquivos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstArquivos As System.Windows.Forms.ListView
    Friend WithEvents cmdIncluirArquivos As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdIncluirPasta As System.Windows.Forms.Button
    Friend WithEvents DialogPasta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DialogArquivos As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkIDW As System.Windows.Forms.CheckBox
    Friend WithEvents chkDWG As System.Windows.Forms.CheckBox
    Friend WithEvents chkSubPastas As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSaveClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents mnuListaArquivos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mniFormato As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniPosicao As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPosImprPredef As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniPosImprRetrato As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniPosImprPaisagem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSelecionarTudo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPesquisa As System.Windows.Forms.Button
    Friend WithEvents txtPesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdOpcoesPesquisa As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdPesquisarArquivos As System.Windows.Forms.Button
    Friend WithEvents cmdIncluirMontagem As System.Windows.Forms.Button
End Class
