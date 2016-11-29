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
        Me.dgvTabela = New System.Windows.Forms.DataGridView
        Me.Arquivos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ccc = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvTabela, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTabela
        '
        Me.dgvTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTabela.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Arquivos})
        Me.dgvTabela.Location = New System.Drawing.Point(12, 12)
        Me.dgvTabela.Name = "dgvTabela"
        Me.dgvTabela.Size = New System.Drawing.Size(215, 218)
        Me.dgvTabela.TabIndex = 0
        '
        'Arquivos
        '
        Me.Arquivos.HeaderText = "Column1"
        Me.Arquivos.Name = "Arquivos"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ccc})
        Me.DataGridView1.Location = New System.Drawing.Point(241, 37)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(219, 328)
        Me.DataGridView1.TabIndex = 1
        '
        'ccc
        '
        Me.ccc.HeaderText = "Column1"
        Me.ccc.Name = "ccc"
        '
        'frmPesquisarArquivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 432)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.dgvTabela)
        Me.Name = "frmPesquisarArquivos"
        Me.Text = "Form1"
        CType(Me.dgvTabela, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvTabela As System.Windows.Forms.DataGridView
    Friend WithEvents Arquivos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ccc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
