<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPesquisarArquivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPesquisarArquivos))
        Me.dgvTabela = New System.Windows.Forms.DataGridView()
        Me.Arquivos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvResultados = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.lblTempo = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.cmdOpcoesPesquisa = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdAdicionarArquivos = New System.Windows.Forms.Button()
        Me.cmdPesquisa = New System.Windows.Forms.Button()
        CType(Me.dgvTabela, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvResultados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvTabela
        '
        Me.dgvTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTabela.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Arquivos})
        Me.dgvTabela.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTabela.Location = New System.Drawing.Point(0, 0)
        Me.dgvTabela.Name = "dgvTabela"
        Me.dgvTabela.Size = New System.Drawing.Size(158, 367)
        Me.dgvTabela.TabIndex = 0
        '
        'Arquivos
        '
        Me.Arquivos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Arquivos.HeaderText = "Pesquisa"
        Me.Arquivos.Name = "Arquivos"
        '
        'dgvResultados
        '
        Me.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgvResultados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultados.Location = New System.Drawing.Point(0, 0)
        Me.dgvResultados.Name = "dgvResultados"
        Me.dgvResultados.Size = New System.Drawing.Size(957, 367)
        Me.dgvResultados.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1119, 400)
        Me.SplitContainer1.SplitterDistance = 158
        Me.SplitContainer1.TabIndex = 2
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer4.IsSplitterFixed = True
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.dgvTabela)
        Me.SplitContainer4.Size = New System.Drawing.Size(158, 400)
        Me.SplitContainer4.SplitterDistance = 29
        Me.SplitContainer4.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search Terms:"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblTempo)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.dgvResultados)
        Me.SplitContainer3.Size = New System.Drawing.Size(957, 400)
        Me.SplitContainer3.SplitterDistance = 29
        Me.SplitContainer3.TabIndex = 2
        '
        'lblTempo
        '
        Me.lblTempo.AutoSize = True
        Me.lblTempo.Location = New System.Drawing.Point(6, 8)
        Me.lblTempo.Name = "lblTempo"
        Me.lblTempo.Size = New System.Drawing.Size(82, 13)
        Me.lblTempo.TabIndex = 1
        Me.lblTempo.Text = "Search Results:"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmdOpcoesPesquisa)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmdAdicionarArquivos)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmdPesquisa)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1119, 449)
        Me.SplitContainer2.SplitterDistance = 45
        Me.SplitContainer2.TabIndex = 3
        '
        'cmdOpcoesPesquisa
        '
        Me.cmdOpcoesPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOpcoesPesquisa.ImageIndex = 3
        Me.cmdOpcoesPesquisa.ImageList = Me.ImageList1
        Me.cmdOpcoesPesquisa.Location = New System.Drawing.Point(233, 6)
        Me.cmdOpcoesPesquisa.Name = "cmdOpcoesPesquisa"
        Me.cmdOpcoesPesquisa.Size = New System.Drawing.Size(123, 31)
        Me.cmdOpcoesPesquisa.TabIndex = 5
        Me.cmdOpcoesPesquisa.Text = "&Search Settings"
        Me.cmdOpcoesPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOpcoesPesquisa.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "edit-find.ico")
        Me.ImageList1.Images.SetKeyName(1, "dialog-cancel-4.ico")
        Me.ImageList1.Images.SetKeyName(2, "arrow-right-double.ico")
        Me.ImageList1.Images.SetKeyName(3, "application-xp.ico")
        '
        'cmdAdicionarArquivos
        '
        Me.cmdAdicionarArquivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdicionarArquivos.ImageIndex = 2
        Me.cmdAdicionarArquivos.ImageList = Me.ImageList1
        Me.cmdAdicionarArquivos.Location = New System.Drawing.Point(137, 6)
        Me.cmdAdicionarArquivos.Name = "cmdAdicionarArquivos"
        Me.cmdAdicionarArquivos.Size = New System.Drawing.Size(90, 31)
        Me.cmdAdicionarArquivos.TabIndex = 0
        Me.cmdAdicionarArquivos.Text = "Add Files"
        Me.cmdAdicionarArquivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdicionarArquivos.UseVisualStyleBackColor = True
        '
        'cmdPesquisa
        '
        Me.cmdPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPesquisa.ImageIndex = 0
        Me.cmdPesquisa.ImageList = Me.ImageList1
        Me.cmdPesquisa.Location = New System.Drawing.Point(7, 6)
        Me.cmdPesquisa.Name = "cmdPesquisa"
        Me.cmdPesquisa.Size = New System.Drawing.Size(124, 31)
        Me.cmdPesquisa.TabIndex = 0
        Me.cmdPesquisa.Text = "Start search"
        Me.cmdPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPesquisa.UseVisualStyleBackColor = True
        '
        'frmPesquisarArquivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 449)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPesquisarArquivos"
        Me.Text = "Multi-search term search"
        CType(Me.dgvTabela, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvResultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvTabela As System.Windows.Forms.DataGridView
    Friend WithEvents dgvResultados As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdPesquisa As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdAdicionarArquivos As System.Windows.Forms.Button
    Friend WithEvents Arquivos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdOpcoesPesquisa As System.Windows.Forms.Button
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTempo As System.Windows.Forms.Label
End Class
