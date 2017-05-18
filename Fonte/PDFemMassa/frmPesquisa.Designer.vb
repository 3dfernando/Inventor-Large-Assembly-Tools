<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPesquisa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPesquisa))
        Me.lstArquivosEncontrados = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelecionarTudoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdAdicionar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblTempo = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstArquivosEncontrados
        '
        Me.lstArquivosEncontrados.CheckBoxes = True
        Me.lstArquivosEncontrados.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstArquivosEncontrados.FullRowSelect = True
        Me.lstArquivosEncontrados.GridLines = True
        Me.lstArquivosEncontrados.Location = New System.Drawing.Point(12, 29)
        Me.lstArquivosEncontrados.Name = "lstArquivosEncontrados"
        Me.lstArquivosEncontrados.Size = New System.Drawing.Size(328, 155)
        Me.lstArquivosEncontrados.SmallImageList = Me.ImageList1
        Me.lstArquivosEncontrados.TabIndex = 0
        Me.lstArquivosEncontrados.UseCompatibleStateImageBehavior = False
        Me.lstArquivosEncontrados.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelecionarTudoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 26)
        '
        'SelecionarTudoToolStripMenuItem
        '
        Me.SelecionarTudoToolStripMenuItem.Name = "SelecionarTudoToolStripMenuItem"
        Me.SelecionarTudoToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SelecionarTudoToolStripMenuItem.Text = "Selecionar Tudo"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Black
        Me.ImageList1.Images.SetKeyName(0, "2rightarrow.png")
        Me.ImageList1.Images.SetKeyName(1, "Inventor_idw.png")
        Me.ImageList1.Images.SetKeyName(2, "Autocad_dwg.png")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Search Results:"
        '
        'cmdAdicionar
        '
        Me.cmdAdicionar.Enabled = False
        Me.cmdAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionar.ImageKey = "2rightarrow.png"
        Me.cmdAdicionar.ImageList = Me.ImageList1
        Me.cmdAdicionar.Location = New System.Drawing.Point(246, 190)
        Me.cmdAdicionar.Name = "cmdAdicionar"
        Me.cmdAdicionar.Size = New System.Drawing.Size(94, 33)
        Me.cmdAdicionar.TabIndex = 2
        Me.cmdAdicionar.Text = "&Add Files"
        Me.cmdAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdicionar.UseVisualStyleBackColor = True
        '
        'lblTempo
        '
        Me.lblTempo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTempo.AutoSize = True
        Me.lblTempo.Location = New System.Drawing.Point(203, 11)
        Me.lblTempo.Name = "lblTempo"
        Me.lblTempo.Size = New System.Drawing.Size(100, 13)
        Me.lblTempo.TabIndex = 3
        Me.lblTempo.Text = "Search Time: 00:00"
        Me.lblTempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(166, 191)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(74, 32)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "C&ancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmPesquisa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 231)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblTempo)
        Me.Controls.Add(Me.cmdAdicionar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstArquivosEncontrados)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPesquisa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstArquivosEncontrados As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdAdicionar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblTempo As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelecionarTudoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
