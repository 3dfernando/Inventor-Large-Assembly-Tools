<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAssemblyTools
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssemblyTools))
        Me.tlvMain = New WinControls.ListView.TreeListView()
        Me.mnuTreeList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RenomearArquivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NãoRenomearArquivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.grpOptions = New System.Windows.Forms.GroupBox()
        Me.chkDesenhosVazios = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdTemplate = New System.Windows.Forms.Button()
        Me.txtTemplate = New System.Windows.Forms.TextBox()
        Me.chkLibraryAccess = New System.Windows.Forms.CheckBox()
        Me.ToolTipper = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCsv = New System.Windows.Forms.Button()
        Me.cmdEditPathPanG = New System.Windows.Forms.Button()
        Me.cmdPurge = New System.Windows.Forms.Button()
        Me.cmdPEG = New System.Windows.Forms.Button()
        Me.txtProject = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpPanG = New System.Windows.Forms.GroupBox()
        Me.lblBkp = New System.Windows.Forms.Label()
        Me.txtBkpPath = New System.Windows.Forms.TextBox()
        Me.fldDiag = New System.Windows.Forms.FolderBrowserDialog()
        Me.FOpen = New System.Windows.Forms.OpenFileDialog()
        Me.OpenIDW = New System.Windows.Forms.OpenFileDialog()
        Me.saveFile = New System.Windows.Forms.SaveFileDialog()
        Me.mnuTreeList.SuspendLayout()
        Me.grpOptions.SuspendLayout()
        Me.grpPanG.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlvMain
        '
        Me.tlvMain.AllowDefaultDragDrop = True
        Me.tlvMain.AllowDrop = True
        Me.tlvMain.ContextMenuStrip = Me.mnuTreeList
        Me.tlvMain.EditBackColor = System.Drawing.Color.LightCoral
        Me.tlvMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tlvMain.ImageList = Me.ImageList1
        Me.tlvMain.Location = New System.Drawing.Point(172, 12)
        Me.tlvMain.MultiSelect = True
        Me.tlvMain.Name = "tlvMain"
        Me.tlvMain.Size = New System.Drawing.Size(813, 543)
        Me.tlvMain.TabIndex = 4
        '
        'mnuTreeList
        '
        Me.mnuTreeList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenomearArquivoToolStripMenuItem, Me.NãoRenomearArquivoToolStripMenuItem})
        Me.mnuTreeList.Name = "mnuTreeList"
        Me.mnuTreeList.Size = New System.Drawing.Size(199, 48)
        '
        'RenomearArquivoToolStripMenuItem
        '
        Me.RenomearArquivoToolStripMenuItem.Name = "RenomearArquivoToolStripMenuItem"
        Me.RenomearArquivoToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.RenomearArquivoToolStripMenuItem.Text = "&Renomear Arquivo"
        '
        'NãoRenomearArquivoToolStripMenuItem
        '
        Me.NãoRenomearArquivoToolStripMenuItem.Name = "NãoRenomearArquivoToolStripMenuItem"
        Me.NãoRenomearArquivoToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.NãoRenomearArquivoToolStripMenuItem.Text = "&Não Renomear Arquivo"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "emblem-question-red.ico")
        Me.ImageList1.Images.SetKeyName(1, "iam.png")
        Me.ImageList1.Images.SetKeyName(2, "ipt.png")
        Me.ImageList1.Images.SetKeyName(3, "user-trash-2.ico")
        '
        'cmdApply
        '
        Me.cmdApply.Image = Global.PDFemMassa.My.Resources.Resources.dialog_apply
        Me.cmdApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdApply.Location = New System.Drawing.Point(10, 517)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(156, 37)
        Me.cmdApply.TabIndex = 6
        Me.cmdApply.Text = "Perform &Renaming"
        Me.cmdApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTipper.SetToolTip(Me.cmdApply, "Applies the changes made in the table shown here" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the filesystem. CAUTION - Yo" &
        "u cannot undo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " this operation!")
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'grpOptions
        '
        Me.grpOptions.Controls.Add(Me.chkDesenhosVazios)
        Me.grpOptions.Controls.Add(Me.Label3)
        Me.grpOptions.Controls.Add(Me.cmdTemplate)
        Me.grpOptions.Controls.Add(Me.txtTemplate)
        Me.grpOptions.Controls.Add(Me.chkLibraryAccess)
        Me.grpOptions.Location = New System.Drawing.Point(10, 263)
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.Size = New System.Drawing.Size(156, 189)
        Me.grpOptions.TabIndex = 8
        Me.grpOptions.TabStop = False
        Me.grpOptions.Text = "Other Options"
        '
        'chkDesenhosVazios
        '
        Me.chkDesenhosVazios.AutoSize = True
        Me.chkDesenhosVazios.Location = New System.Drawing.Point(10, 24)
        Me.chkDesenhosVazios.Name = "chkDesenhosVazios"
        Me.chkDesenhosVazios.Size = New System.Drawing.Size(128, 17)
        Me.chkDesenhosVazios.TabIndex = 22
        Me.chkDesenhosVazios.Text = "Create empty idw files"
        Me.ToolTipper.SetToolTip(Me.chkDesenhosVazios, resources.GetString("chkDesenhosVazios.ToolTip"))
        Me.chkDesenhosVazios.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "IDW Template Filepath:"
        '
        'cmdTemplate
        '
        Me.cmdTemplate.Location = New System.Drawing.Point(80, 120)
        Me.cmdTemplate.Name = "cmdTemplate"
        Me.cmdTemplate.Size = New System.Drawing.Size(63, 26)
        Me.cmdTemplate.TabIndex = 20
        Me.cmdTemplate.Text = "Edit..."
        Me.ToolTipper.SetToolTip(Me.cmdTemplate, "Changes the ""empty IDW"" template path.")
        Me.cmdTemplate.UseVisualStyleBackColor = True
        '
        'txtTemplate
        '
        Me.txtTemplate.Enabled = False
        Me.txtTemplate.Location = New System.Drawing.Point(8, 64)
        Me.txtTemplate.Multiline = True
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.Size = New System.Drawing.Size(140, 50)
        Me.txtTemplate.TabIndex = 19
        '
        'chkLibraryAccess
        '
        Me.chkLibraryAccess.AutoSize = True
        Me.chkLibraryAccess.Location = New System.Drawing.Point(10, 158)
        Me.chkLibraryAccess.Name = "chkLibraryAccess"
        Me.chkLibraryAccess.Size = New System.Drawing.Size(132, 17)
        Me.chkLibraryAccess.TabIndex = 18
        Me.chkLibraryAccess.Text = "Change Files in Library"
        Me.ToolTipper.SetToolTip(Me.chkLibraryAccess, "When checked, allow the program to change " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the filenames of files inside the cur" &
        "rent Project's" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Library paths.")
        Me.chkLibraryAccess.UseVisualStyleBackColor = True
        '
        'cmdCsv
        '
        Me.cmdCsv.Image = Global.PDFemMassa.My.Resources.Resources.xlsx
        Me.cmdCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCsv.Location = New System.Drawing.Point(10, 12)
        Me.cmdCsv.Name = "cmdCsv"
        Me.cmdCsv.Size = New System.Drawing.Size(156, 45)
        Me.cmdCsv.TabIndex = 9
        Me.cmdCsv.Text = "&Load Renaming" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Spreadsheet"
        Me.cmdCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTipper.SetToolTip(Me.cmdCsv, resources.GetString("cmdCsv.ToolTip"))
        Me.cmdCsv.UseVisualStyleBackColor = True
        '
        'cmdEditPathPanG
        '
        Me.cmdEditPathPanG.Location = New System.Drawing.Point(80, 80)
        Me.cmdEditPathPanG.Name = "cmdEditPathPanG"
        Me.cmdEditPathPanG.Size = New System.Drawing.Size(63, 26)
        Me.cmdEditPathPanG.TabIndex = 17
        Me.cmdEditPathPanG.Text = "Edit..."
        Me.ToolTipper.SetToolTip(Me.cmdEditPathPanG, resources.GetString("cmdEditPathPanG.ToolTip"))
        Me.cmdEditPathPanG.UseVisualStyleBackColor = True
        '
        'cmdPurge
        '
        Me.cmdPurge.Location = New System.Drawing.Point(8, 81)
        Me.cmdPurge.Name = "cmdPurge"
        Me.cmdPurge.Size = New System.Drawing.Size(63, 26)
        Me.cmdPurge.TabIndex = 18
        Me.cmdPurge.Text = "P&urge"
        Me.ToolTipper.SetToolTip(Me.cmdPurge, "This button will clean the folder selected above" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(All files and folders will be " &
        "deleted)")
        Me.cmdPurge.UseVisualStyleBackColor = True
        '
        'cmdPEG
        '
        Me.cmdPEG.Image = Global.PDFemMassa.My.Resources.Resources.rhythmbox
        Me.cmdPEG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPEG.Location = New System.Drawing.Point(10, 474)
        Me.cmdPEG.Name = "cmdPEG"
        Me.cmdPEG.Size = New System.Drawing.Size(156, 37)
        Me.cmdPEG.TabIndex = 19
        Me.cmdPEG.Text = "Perform a Rapid " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pack&Go Operation"
        Me.cmdPEG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTipper.SetToolTip(Me.cmdPEG, "This command performs a rapid Pack & Go operation, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "where it will only search in" &
        "side the project paths" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (it's faster than the original Inventor Pack&Go)")
        Me.cmdPEG.UseVisualStyleBackColor = True
        '
        'txtProject
        '
        Me.txtProject.Enabled = False
        Me.txtProject.Location = New System.Drawing.Point(10, 85)
        Me.txtProject.Multiline = True
        Me.txtProject.Name = "txtProject"
        Me.txtProject.Size = New System.Drawing.Size(156, 51)
        Me.txtProject.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Current Project Filepath:"
        '
        'grpPanG
        '
        Me.grpPanG.Controls.Add(Me.cmdPurge)
        Me.grpPanG.Controls.Add(Me.cmdEditPathPanG)
        Me.grpPanG.Controls.Add(Me.lblBkp)
        Me.grpPanG.Controls.Add(Me.txtBkpPath)
        Me.grpPanG.Location = New System.Drawing.Point(10, 141)
        Me.grpPanG.Name = "grpPanG"
        Me.grpPanG.Size = New System.Drawing.Size(156, 116)
        Me.grpPanG.TabIndex = 12
        Me.grpPanG.TabStop = False
        Me.grpPanG.Text = "Pack and Go"
        '
        'lblBkp
        '
        Me.lblBkp.AutoSize = True
        Me.lblBkp.Location = New System.Drawing.Point(5, 20)
        Me.lblBkp.Name = "lblBkp"
        Me.lblBkp.Size = New System.Drawing.Size(79, 13)
        Me.lblBkp.TabIndex = 16
        Me.lblBkp.Text = "Backup Folder:"
        '
        'txtBkpPath
        '
        Me.txtBkpPath.Enabled = False
        Me.txtBkpPath.Location = New System.Drawing.Point(8, 39)
        Me.txtBkpPath.Multiline = True
        Me.txtBkpPath.Name = "txtBkpPath"
        Me.txtBkpPath.Size = New System.Drawing.Size(140, 34)
        Me.txtBkpPath.TabIndex = 15
        '
        'FOpen
        '
        Me.FOpen.Filter = "Arquivos CSV|*.csv"
        '
        'OpenIDW
        '
        Me.OpenIDW.Filter = "Arquivos IDW|*.idw"
        '
        'saveFile
        '
        Me.saveFile.Filter = "Arquivos ZIP|*.zip"
        '
        'frmAssemblyTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 567)
        Me.Controls.Add(Me.cmdPEG)
        Me.Controls.Add(Me.grpPanG)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProject)
        Me.Controls.Add(Me.cmdCsv)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.tlvMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAssemblyTools"
        Me.Text = "Batch Renamer"
        Me.mnuTreeList.ResumeLayout(False)
        Me.grpOptions.ResumeLayout(False)
        Me.grpOptions.PerformLayout()
        Me.grpPanG.ResumeLayout(False)
        Me.grpPanG.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlvMain As WinControls.ListView.TreeListView
    Friend WithEvents ImageList1 As Windows.Forms.ImageList
    Friend WithEvents cmdApply As Windows.Forms.Button
    Friend WithEvents grpOptions As Windows.Forms.GroupBox
    Friend WithEvents ToolTipper As Windows.Forms.ToolTip
    Friend WithEvents cmdCsv As Windows.Forms.Button
    Friend WithEvents txtProject As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents grpPanG As Windows.Forms.GroupBox
    Friend WithEvents cmdEditPathPanG As Windows.Forms.Button
    Friend WithEvents lblBkp As Windows.Forms.Label
    Friend WithEvents txtBkpPath As Windows.Forms.TextBox
    Friend WithEvents chkLibraryAccess As Windows.Forms.CheckBox
    Friend WithEvents fldDiag As Windows.Forms.FolderBrowserDialog
    Friend WithEvents mnuTreeList As Windows.Forms.ContextMenuStrip
    Friend WithEvents RenomearArquivoToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents NãoRenomearArquivoToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents FOpen As Windows.Forms.OpenFileDialog
    Friend WithEvents cmdPurge As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cmdTemplate As Windows.Forms.Button
    Friend WithEvents txtTemplate As Windows.Forms.TextBox
    Friend WithEvents OpenIDW As Windows.Forms.OpenFileDialog
    Friend WithEvents chkDesenhosVazios As Windows.Forms.CheckBox
    Friend WithEvents cmdPEG As Windows.Forms.Button
    Friend WithEvents saveFile As Windows.Forms.SaveFileDialog
End Class
