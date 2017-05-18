<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicio))
        Me.OrigemArquivos = New System.Windows.Forms.GroupBox()
        Me.cmdListaArquivos = New System.Windows.Forms.Button()
        Me.optArquivosSelecionados = New System.Windows.Forms.RadioButton()
        Me.optEstaSecao = New System.Windows.Forms.RadioButton()
        Me.DestinoArquivos = New System.Windows.Forms.GroupBox()
        Me.txtCaminhoPasta = New System.Windows.Forms.TextBox()
        Me.cmdEscolherPasta = New System.Windows.Forms.Button()
        Me.optPastaSelecionada = New System.Windows.Forms.RadioButton()
        Me.optPastaOrigem = New System.Windows.Forms.RadioButton()
        Me.TiposArquivo = New System.Windows.Forms.GroupBox()
        Me.cmdOpcoesDWG = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.chkPlanifDXF = New System.Windows.Forms.CheckBox()
        Me.chkDWG = New System.Windows.Forms.CheckBox()
        Me.chkDXF = New System.Windows.Forms.CheckBox()
        Me.chkPDF = New System.Windows.Forms.CheckBox()
        Me.GrupoImprimir = New System.Windows.Forms.GroupBox()
        Me.cmdOpcoesImpressao = New System.Windows.Forms.Button()
        Me.cmbImpressoras2 = New System.Windows.Forms.ComboBox()
        Me.chkImprimir2 = New System.Windows.Forms.CheckBox()
        Me.cmbImpressoras = New System.Windows.Forms.ComboBox()
        Me.chkImprimir = New System.Windows.Forms.CheckBox()
        Me.pgbProgresso = New System.Windows.Forms.ProgressBar()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdExecutar = New System.Windows.Forms.Button()
        Me.cmdOpcoes = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DialogoPasta = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblProgresso = New System.Windows.Forms.Label()
        Me.OrigemArquivos.SuspendLayout()
        Me.DestinoArquivos.SuspendLayout()
        Me.TiposArquivo.SuspendLayout()
        Me.GrupoImprimir.SuspendLayout()
        Me.SuspendLayout()
        '
        'OrigemArquivos
        '
        Me.OrigemArquivos.Controls.Add(Me.cmdListaArquivos)
        Me.OrigemArquivos.Controls.Add(Me.optArquivosSelecionados)
        Me.OrigemArquivos.Controls.Add(Me.optEstaSecao)
        Me.OrigemArquivos.Location = New System.Drawing.Point(9, 9)
        Me.OrigemArquivos.Name = "OrigemArquivos"
        Me.OrigemArquivos.Size = New System.Drawing.Size(222, 98)
        Me.OrigemArquivos.TabIndex = 0
        Me.OrigemArquivos.TabStop = False
        Me.OrigemArquivos.Text = "Files to be Exported"
        '
        'cmdListaArquivos
        '
        Me.cmdListaArquivos.Location = New System.Drawing.Point(26, 64)
        Me.cmdListaArquivos.Name = "cmdListaArquivos"
        Me.cmdListaArquivos.Size = New System.Drawing.Size(110, 26)
        Me.cmdListaArquivos.TabIndex = 1
        Me.cmdListaArquivos.Text = "File List..."
        Me.ToolTip1.SetToolTip(Me.cmdListaArquivos, "Opens a window to select files to export/print.")
        Me.cmdListaArquivos.UseVisualStyleBackColor = True
        '
        'optArquivosSelecionados
        '
        Me.optArquivosSelecionados.AutoSize = True
        Me.optArquivosSelecionados.Location = New System.Drawing.Point(13, 41)
        Me.optArquivosSelecionados.Name = "optArquivosSelecionados"
        Me.optArquivosSelecionados.Size = New System.Drawing.Size(76, 17)
        Me.optArquivosSelecionados.TabIndex = 0
        Me.optArquivosSelecionados.Text = "&Select files"
        Me.ToolTip1.SetToolTip(Me.optArquivosSelecionados, "Exports the selected files in the list accessible by the button below.")
        Me.optArquivosSelecionados.UseVisualStyleBackColor = True
        '
        'optEstaSecao
        '
        Me.optEstaSecao.AutoSize = True
        Me.optEstaSecao.Checked = True
        Me.optEstaSecao.Location = New System.Drawing.Point(13, 18)
        Me.optEstaSecao.Name = "optEstaSecao"
        Me.optEstaSecao.Size = New System.Drawing.Size(108, 17)
        Me.optEstaSecao.TabIndex = 0
        Me.optEstaSecao.TabStop = True
        Me.optEstaSecao.Text = "All open drawings"
        Me.ToolTip1.SetToolTip(Me.optEstaSecao, "Exports the open drawings in this session.")
        Me.optEstaSecao.UseVisualStyleBackColor = True
        '
        'DestinoArquivos
        '
        Me.DestinoArquivos.Controls.Add(Me.txtCaminhoPasta)
        Me.DestinoArquivos.Controls.Add(Me.cmdEscolherPasta)
        Me.DestinoArquivos.Controls.Add(Me.optPastaSelecionada)
        Me.DestinoArquivos.Controls.Add(Me.optPastaOrigem)
        Me.DestinoArquivos.Location = New System.Drawing.Point(9, 118)
        Me.DestinoArquivos.Name = "DestinoArquivos"
        Me.DestinoArquivos.Size = New System.Drawing.Size(222, 131)
        Me.DestinoArquivos.TabIndex = 1
        Me.DestinoArquivos.TabStop = False
        Me.DestinoArquivos.Text = "Exported Files Destination"
        '
        'txtCaminhoPasta
        '
        Me.txtCaminhoPasta.Enabled = False
        Me.txtCaminhoPasta.Location = New System.Drawing.Point(26, 97)
        Me.txtCaminhoPasta.Name = "txtCaminhoPasta"
        Me.txtCaminhoPasta.Size = New System.Drawing.Size(177, 20)
        Me.txtCaminhoPasta.TabIndex = 2
        '
        'cmdEscolherPasta
        '
        Me.cmdEscolherPasta.Location = New System.Drawing.Point(26, 65)
        Me.cmdEscolherPasta.Name = "cmdEscolherPasta"
        Me.cmdEscolherPasta.Size = New System.Drawing.Size(110, 26)
        Me.cmdEscolherPasta.TabIndex = 1
        Me.cmdEscolherPasta.Text = "Choose Folder..."
        Me.ToolTip1.SetToolTip(Me.cmdEscolherPasta, "Opens a window to choose the target folder.")
        Me.cmdEscolherPasta.UseVisualStyleBackColor = True
        '
        'optPastaSelecionada
        '
        Me.optPastaSelecionada.AutoSize = True
        Me.optPastaSelecionada.Location = New System.Drawing.Point(13, 42)
        Me.optPastaSelecionada.Name = "optPastaSelecionada"
        Me.optPastaSelecionada.Size = New System.Drawing.Size(96, 17)
        Me.optPastaSelecionada.TabIndex = 0
        Me.optPastaSelecionada.TabStop = True
        Me.optPastaSelecionada.Text = "Selected folder"
        Me.ToolTip1.SetToolTip(Me.optPastaSelecionada, "Save all files to the same selected folder.")
        Me.optPastaSelecionada.UseVisualStyleBackColor = True
        '
        'optPastaOrigem
        '
        Me.optPastaOrigem.AutoSize = True
        Me.optPastaOrigem.Checked = True
        Me.optPastaOrigem.Location = New System.Drawing.Point(13, 19)
        Me.optPastaOrigem.Name = "optPastaOrigem"
        Me.optPastaOrigem.Size = New System.Drawing.Size(172, 17)
        Me.optPastaOrigem.TabIndex = 0
        Me.optPastaOrigem.TabStop = True
        Me.optPastaOrigem.Text = "Same folder as the original file's"
        Me.ToolTip1.SetToolTip(Me.optPastaOrigem, "Saves the exported files to the same folder as the original files belonged." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(In " &
        "the case they belong to multiple folders, each exported file will be in " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the co" &
        "rresponding folder)")
        Me.optPastaOrigem.UseVisualStyleBackColor = True
        '
        'TiposArquivo
        '
        Me.TiposArquivo.Controls.Add(Me.cmdOpcoesDWG)
        Me.TiposArquivo.Controls.Add(Me.chkPlanifDXF)
        Me.TiposArquivo.Controls.Add(Me.chkDWG)
        Me.TiposArquivo.Controls.Add(Me.chkDXF)
        Me.TiposArquivo.Controls.Add(Me.chkPDF)
        Me.TiposArquivo.Location = New System.Drawing.Point(237, 9)
        Me.TiposArquivo.Name = "TiposArquivo"
        Me.TiposArquivo.Size = New System.Drawing.Size(188, 140)
        Me.TiposArquivo.TabIndex = 3
        Me.TiposArquivo.TabStop = False
        Me.TiposArquivo.Text = "Export File Types"
        '
        'cmdOpcoesDWG
        '
        Me.cmdOpcoesDWG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOpcoesDWG.ImageKey = "tooloptions.png"
        Me.cmdOpcoesDWG.ImageList = Me.ImageList1
        Me.cmdOpcoesDWG.Location = New System.Drawing.Point(80, 25)
        Me.cmdOpcoesDWG.Name = "cmdOpcoesDWG"
        Me.cmdOpcoesDWG.Size = New System.Drawing.Size(93, 32)
        Me.cmdOpcoesDWG.TabIndex = 1
        Me.cmdOpcoesDWG.Text = "Options..."
        Me.cmdOpcoesDWG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdOpcoesDWG, "Configurações para exportação...")
        Me.cmdOpcoesDWG.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "lin_agt_wrench.png")
        Me.ImageList1.Images.SetKeyName(1, "list.png")
        Me.ImageList1.Images.SetKeyName(2, "tooloptions.png")
        '
        'chkPlanifDXF
        '
        Me.chkPlanifDXF.AutoSize = True
        Me.chkPlanifDXF.Location = New System.Drawing.Point(13, 109)
        Me.chkPlanifDXF.Name = "chkPlanifDXF"
        Me.chkPlanifDXF.Size = New System.Drawing.Size(116, 17)
        Me.chkPlanifDXF.TabIndex = 0
        Me.chkPlanifDXF.Text = "&Flat Pattern to DXF"
        Me.ToolTip1.SetToolTip(Me.chkPlanifDXF, "Exports the flat pattern of the IDWs that contain sheet metal files" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to DXF.")
        Me.chkPlanifDXF.UseVisualStyleBackColor = True
        '
        'chkDWG
        '
        Me.chkDWG.AutoSize = True
        Me.chkDWG.Location = New System.Drawing.Point(13, 81)
        Me.chkDWG.Name = "chkDWG"
        Me.chkDWG.Size = New System.Drawing.Size(53, 17)
        Me.chkDWG.TabIndex = 0
        Me.chkDWG.Text = "D&WG"
        Me.ToolTip1.SetToolTip(Me.chkDWG, "When checked will export the files to DWG.")
        Me.chkDWG.UseVisualStyleBackColor = True
        '
        'chkDXF
        '
        Me.chkDXF.AutoSize = True
        Me.chkDXF.Location = New System.Drawing.Point(13, 52)
        Me.chkDXF.Name = "chkDXF"
        Me.chkDXF.Size = New System.Drawing.Size(47, 17)
        Me.chkDXF.TabIndex = 0
        Me.chkDXF.Text = "D&XF"
        Me.ToolTip1.SetToolTip(Me.chkDXF, "When checked will export the files to DXF.")
        Me.chkDXF.UseVisualStyleBackColor = True
        '
        'chkPDF
        '
        Me.chkPDF.AutoSize = True
        Me.chkPDF.Location = New System.Drawing.Point(13, 25)
        Me.chkPDF.Name = "chkPDF"
        Me.chkPDF.Size = New System.Drawing.Size(47, 17)
        Me.chkPDF.TabIndex = 0
        Me.chkPDF.Text = "&PDF"
        Me.ToolTip1.SetToolTip(Me.chkPDF, "When checked will export the files to PDF.")
        Me.chkPDF.UseVisualStyleBackColor = True
        '
        'GrupoImprimir
        '
        Me.GrupoImprimir.Controls.Add(Me.cmdOpcoesImpressao)
        Me.GrupoImprimir.Controls.Add(Me.cmbImpressoras2)
        Me.GrupoImprimir.Controls.Add(Me.chkImprimir2)
        Me.GrupoImprimir.Controls.Add(Me.cmbImpressoras)
        Me.GrupoImprimir.Controls.Add(Me.chkImprimir)
        Me.GrupoImprimir.Location = New System.Drawing.Point(237, 155)
        Me.GrupoImprimir.Name = "GrupoImprimir"
        Me.GrupoImprimir.Size = New System.Drawing.Size(188, 155)
        Me.GrupoImprimir.TabIndex = 4
        Me.GrupoImprimir.TabStop = False
        Me.GrupoImprimir.Text = "Print"
        '
        'cmdOpcoesImpressao
        '
        Me.cmdOpcoesImpressao.Location = New System.Drawing.Point(39, 122)
        Me.cmdOpcoesImpressao.Name = "cmdOpcoesImpressao"
        Me.cmdOpcoesImpressao.Size = New System.Drawing.Size(134, 24)
        Me.cmdOpcoesImpressao.TabIndex = 2
        Me.cmdOpcoesImpressao.Text = "Print Options..."
        Me.ToolTip1.SetToolTip(Me.cmdOpcoesImpressao, "Opens a print settings window.")
        Me.cmdOpcoesImpressao.UseVisualStyleBackColor = True
        '
        'cmbImpressoras2
        '
        Me.cmbImpressoras2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpressoras2.FormattingEnabled = True
        Me.cmbImpressoras2.Location = New System.Drawing.Point(13, 95)
        Me.cmbImpressoras2.Name = "cmbImpressoras2"
        Me.cmbImpressoras2.Size = New System.Drawing.Size(160, 21)
        Me.cmbImpressoras2.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmbImpressoras2, "Selects the printer to print the files on.")
        '
        'chkImprimir2
        '
        Me.chkImprimir2.AutoSize = True
        Me.chkImprimir2.Checked = True
        Me.chkImprimir2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImprimir2.Location = New System.Drawing.Point(13, 72)
        Me.chkImprimir2.Name = "chkImprimir2"
        Me.chkImprimir2.Size = New System.Drawing.Size(87, 17)
        Me.chkImprimir2.TabIndex = 0
        Me.chkImprimir2.Text = "Use Printer &2"
        Me.ToolTip1.SetToolTip(Me.chkImprimir2, "Prints the files in the Printer 2 (selectable below)")
        Me.chkImprimir2.UseVisualStyleBackColor = True
        '
        'cmbImpressoras
        '
        Me.cmbImpressoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpressoras.FormattingEnabled = True
        Me.cmbImpressoras.Location = New System.Drawing.Point(13, 42)
        Me.cmbImpressoras.Name = "cmbImpressoras"
        Me.cmbImpressoras.Size = New System.Drawing.Size(160, 21)
        Me.cmbImpressoras.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmbImpressoras, "Selects the printer to print the files on.")
        '
        'chkImprimir
        '
        Me.chkImprimir.AutoSize = True
        Me.chkImprimir.Location = New System.Drawing.Point(13, 19)
        Me.chkImprimir.Name = "chkImprimir"
        Me.chkImprimir.Size = New System.Drawing.Size(87, 17)
        Me.chkImprimir.TabIndex = 0
        Me.chkImprimir.Text = "Use Printer &1"
        Me.ToolTip1.SetToolTip(Me.chkImprimir, "Prints the files in the Printer 1 (selectable below)")
        Me.chkImprimir.UseVisualStyleBackColor = True
        '
        'pgbProgresso
        '
        Me.pgbProgresso.Location = New System.Drawing.Point(121, 315)
        Me.pgbProgresso.Name = "pgbProgresso"
        Me.pgbProgresso.Size = New System.Drawing.Size(306, 23)
        Me.pgbProgresso.Step = 1
        Me.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pgbProgresso.TabIndex = 5
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Location = New System.Drawing.Point(319, 344)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(108, 33)
        Me.cmdCancelar.TabIndex = 6
        Me.cmdCancelar.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.cmdCancelar, "Fecha esta janela.")
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdExecutar
        '
        Me.cmdExecutar.Location = New System.Drawing.Point(176, 344)
        Me.cmdExecutar.Name = "cmdExecutar"
        Me.cmdExecutar.Size = New System.Drawing.Size(137, 33)
        Me.cmdExecutar.TabIndex = 6
        Me.cmdExecutar.Text = "&Start"
        Me.ToolTip1.SetToolTip(Me.cmdExecutar, "Executa a exportação/impressão dos arquivos conforme configuração.")
        Me.cmdExecutar.UseVisualStyleBackColor = True
        '
        'cmdOpcoes
        '
        Me.cmdOpcoes.Location = New System.Drawing.Point(17, 344)
        Me.cmdOpcoes.Name = "cmdOpcoes"
        Me.cmdOpcoes.Size = New System.Drawing.Size(79, 33)
        Me.cmdOpcoes.TabIndex = 6
        Me.cmdOpcoes.Text = "&Settings..."
        Me.ToolTip1.SetToolTip(Me.cmdOpcoes, "Abre uma janela com as opções do programa.")
        Me.cmdOpcoes.UseVisualStyleBackColor = True
        '
        'lblProgresso
        '
        Me.lblProgresso.AutoSize = True
        Me.lblProgresso.Location = New System.Drawing.Point(14, 320)
        Me.lblProgresso.Name = "lblProgresso"
        Me.lblProgresso.Size = New System.Drawing.Size(57, 13)
        Me.lblProgresso.TabIndex = 7
        Me.lblProgresso.Text = "Progress: -"
        '
        'frmInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(438, 385)
        Me.Controls.Add(Me.lblProgresso)
        Me.Controls.Add(Me.cmdOpcoes)
        Me.Controls.Add(Me.cmdExecutar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.pgbProgresso)
        Me.Controls.Add(Me.GrupoImprimir)
        Me.Controls.Add(Me.TiposArquivo)
        Me.Controls.Add(Me.DestinoArquivos)
        Me.Controls.Add(Me.OrigemArquivos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInicio"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Batch Exporter V0.2"
        Me.OrigemArquivos.ResumeLayout(False)
        Me.OrigemArquivos.PerformLayout()
        Me.DestinoArquivos.ResumeLayout(False)
        Me.DestinoArquivos.PerformLayout()
        Me.TiposArquivo.ResumeLayout(False)
        Me.TiposArquivo.PerformLayout()
        Me.GrupoImprimir.ResumeLayout(False)
        Me.GrupoImprimir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OrigemArquivos As System.Windows.Forms.GroupBox
    Friend WithEvents cmdListaArquivos As System.Windows.Forms.Button
    Friend WithEvents optArquivosSelecionados As System.Windows.Forms.RadioButton
    Friend WithEvents optEstaSecao As System.Windows.Forms.RadioButton
    Friend WithEvents DestinoArquivos As System.Windows.Forms.GroupBox
    Friend WithEvents cmdEscolherPasta As System.Windows.Forms.Button
    Friend WithEvents optPastaSelecionada As System.Windows.Forms.RadioButton
    Friend WithEvents optPastaOrigem As System.Windows.Forms.RadioButton
    Friend WithEvents txtCaminhoPasta As System.Windows.Forms.TextBox
    Friend WithEvents TiposArquivo As System.Windows.Forms.GroupBox
    Friend WithEvents chkDXF As System.Windows.Forms.CheckBox
    Friend WithEvents chkPDF As System.Windows.Forms.CheckBox
    Friend WithEvents chkDWG As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdOpcoesDWG As System.Windows.Forms.Button
    Friend WithEvents GrupoImprimir As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOpcoesImpressao As System.Windows.Forms.Button
    Friend WithEvents cmbImpressoras As System.Windows.Forms.ComboBox
    Friend WithEvents chkImprimir As System.Windows.Forms.CheckBox
    Friend WithEvents pgbProgresso As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdExecutar As System.Windows.Forms.Button
    Friend WithEvents cmdOpcoes As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DialogoPasta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblProgresso As System.Windows.Forms.Label
    Friend WithEvents chkPlanifDXF As System.Windows.Forms.CheckBox
    Friend WithEvents cmbImpressoras2 As System.Windows.Forms.ComboBox
    Friend WithEvents chkImprimir2 As System.Windows.Forms.CheckBox
End Class
