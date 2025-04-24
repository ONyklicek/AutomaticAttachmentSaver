<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Formulář přepisuje metodu Dispose, aby vyčistil seznam součástí.
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

    'Vyžadováno Návrhářem Windows Form
    Private components As System.ComponentModel.IContainer

    'POZNÁMKA: Následující procedura je vyžadována Návrhářem Windows Form
    'Může být upraveno pomocí Návrháře Windows Form.  
    'Neupravovat pomocí editoru kódu
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.settingForm_IsActive = New System.Windows.Forms.CheckBox()
        Me.settingForm_RootPathLabel = New System.Windows.Forms.Label()
        Me.settingForm_RootPath = New System.Windows.Forms.TextBox()
        Me.settingForm_RootFolderSelectDialog = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.InfoToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.settingForm_SenderAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.settingForm_MonitoredFolders = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmailGroup = New System.Windows.Forms.GroupBox()
        Me.ButtonSelectContact = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.settingForm_MonitorFolderSelectDialog = New System.Windows.Forms.Button()
        Me.VersionApp = New System.Windows.Forms.Label()
        Me.AppGitHubLink = New System.Windows.Forms.LinkLabel()
        Me.EmailGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'settingForm_IsActive
        '
        Me.settingForm_IsActive.AutoSize = True
        Me.settingForm_IsActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.settingForm_IsActive.Location = New System.Drawing.Point(27, 29)
        Me.settingForm_IsActive.Name = "settingForm_IsActive"
        Me.settingForm_IsActive.Size = New System.Drawing.Size(137, 17)
        Me.settingForm_IsActive.TabIndex = 0
        Me.settingForm_IsActive.Text = "Automaticky exportovat"
        Me.settingForm_IsActive.UseVisualStyleBackColor = True
        '
        'settingForm_RootPathLabel
        '
        Me.settingForm_RootPathLabel.AutoSize = True
        Me.settingForm_RootPathLabel.Location = New System.Drawing.Point(28, 67)
        Me.settingForm_RootPathLabel.Name = "settingForm_RootPathLabel"
        Me.settingForm_RootPathLabel.Size = New System.Drawing.Size(95, 13)
        Me.settingForm_RootPathLabel.TabIndex = 1
        Me.settingForm_RootPathLabel.Text = "Kořenový adresář:"
        '
        'settingForm_RootPath
        '
        Me.settingForm_RootPath.Location = New System.Drawing.Point(150, 64)
        Me.settingForm_RootPath.Name = "settingForm_RootPath"
        Me.settingForm_RootPath.Size = New System.Drawing.Size(319, 20)
        Me.settingForm_RootPath.TabIndex = 2
        '
        'settingForm_RootFolderSelectDialog
        '
        Me.settingForm_RootFolderSelectDialog.Location = New System.Drawing.Point(475, 62)
        Me.settingForm_RootFolderSelectDialog.Name = "settingForm_RootFolderSelectDialog"
        Me.settingForm_RootFolderSelectDialog.Size = New System.Drawing.Size(93, 23)
        Me.settingForm_RootFolderSelectDialog.TabIndex = 3
        Me.settingForm_RootFolderSelectDialog.Text = "Vybrat adresář"
        Me.settingForm_RootFolderSelectDialog.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Button1.Location = New System.Drawing.Point(669, 394)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 31)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Uložit a zavřít"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'InfoToolTip
        '
        Me.InfoToolTip.BackColor = System.Drawing.SystemColors.HighlightText
        Me.InfoToolTip.IsBalloon = True
        Me.InfoToolTip.ShowAlways = True
        Me.InfoToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.InfoToolTip.ToolTipTitle = "Nápověda"
        '
        'settingForm_SenderAddress
        '
        Me.settingForm_SenderAddress.Location = New System.Drawing.Point(139, 49)
        Me.settingForm_SenderAddress.Name = "settingForm_SenderAddress"
        Me.settingForm_SenderAddress.Size = New System.Drawing.Size(319, 20)
        Me.settingForm_SenderAddress.TabIndex = 18
        Me.InfoToolTip.SetToolTip(Me.settingForm_SenderAddress, "E-mail bude kontrolován před každým zpracováním příchozí zprávy. ")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Sledonaný e-mail:"
        Me.InfoToolTip.SetToolTip(Me.Label2, "E-mail bude kontrolován před každým zpracováním příchozí zprávy.")
        '
        'settingForm_MonitoredFolders
        '
        Me.settingForm_MonitoredFolders.Location = New System.Drawing.Point(139, 23)
        Me.settingForm_MonitoredFolders.Name = "settingForm_MonitoredFolders"
        Me.settingForm_MonitoredFolders.Size = New System.Drawing.Size(319, 20)
        Me.settingForm_MonitoredFolders.TabIndex = 15
        Me.InfoToolTip.SetToolTip(Me.settingForm_MonitoredFolders, "Sledovaná složka e-mailové schránky zachytávající příchozí zprávy. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ostatní adre" &
        "sáře budou ignorovány.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Monitorovaný prostor:"
        Me.InfoToolTip.SetToolTip(Me.Label1, "Sledovaná složka e-mailové schránky zachytávající příchozí zprávy. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ostatní adre" &
        "sáře budou ignorovány.")
        '
        'EmailGroup
        '
        Me.EmailGroup.Controls.Add(Me.ButtonSelectContact)
        Me.EmailGroup.Controls.Add(Me.TextBox2)
        Me.EmailGroup.Controls.Add(Me.settingForm_SenderAddress)
        Me.EmailGroup.Controls.Add(Me.Label3)
        Me.EmailGroup.Controls.Add(Me.Label2)
        Me.EmailGroup.Controls.Add(Me.settingForm_MonitoredFolders)
        Me.EmailGroup.Controls.Add(Me.Label1)
        Me.EmailGroup.Controls.Add(Me.settingForm_MonitorFolderSelectDialog)
        Me.EmailGroup.Location = New System.Drawing.Point(27, 105)
        Me.EmailGroup.Name = "EmailGroup"
        Me.EmailGroup.Size = New System.Drawing.Size(747, 135)
        Me.EmailGroup.TabIndex = 13
        Me.EmailGroup.TabStop = False
        Me.EmailGroup.Text = "Nastavení filtru"
        '
        'ButtonSelectContact
        '
        Me.ButtonSelectContact.Location = New System.Drawing.Point(464, 47)
        Me.ButtonSelectContact.Name = "ButtonSelectContact"
        Me.ButtonSelectContact.Size = New System.Drawing.Size(93, 23)
        Me.ButtonSelectContact.TabIndex = 20
        Me.ButtonSelectContact.Text = "Vybrat kontakt"
        Me.ButtonSelectContact.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(139, 75)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(319, 20)
        Me.TextBox2.TabIndex = 19
        Me.TextBox2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'settingForm_MonitorFolderSelectDialog
        '
        Me.settingForm_MonitorFolderSelectDialog.Location = New System.Drawing.Point(464, 21)
        Me.settingForm_MonitorFolderSelectDialog.Name = "settingForm_MonitorFolderSelectDialog"
        Me.settingForm_MonitorFolderSelectDialog.Size = New System.Drawing.Size(93, 23)
        Me.settingForm_MonitorFolderSelectDialog.TabIndex = 13
        Me.settingForm_MonitorFolderSelectDialog.Text = "Vybrat složku"
        Me.settingForm_MonitorFolderSelectDialog.UseVisualStyleBackColor = True
        '
        'VersionApp
        '
        Me.VersionApp.AutoSize = True
        Me.VersionApp.Location = New System.Drawing.Point(12, 403)
        Me.VersionApp.Name = "VersionApp"
        Me.VersionApp.Size = New System.Drawing.Size(42, 13)
        Me.VersionApp.TabIndex = 14
        Me.VersionApp.Text = "Version"
        '
        'AppGitHubLink
        '
        Me.AppGitHubLink.AutoSize = True
        Me.AppGitHubLink.Location = New System.Drawing.Point(12, 428)
        Me.AppGitHubLink.Name = "AppGitHubLink"
        Me.AppGitHubLink.Size = New System.Drawing.Size(40, 13)
        Me.AppGitHubLink.TabIndex = 15
        Me.AppGitHubLink.TabStop = True
        Me.AppGitHubLink.Text = "GitHub"
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.AppGitHubLink)
        Me.Controls.Add(Me.VersionApp)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.settingForm_RootFolderSelectDialog)
        Me.Controls.Add(Me.settingForm_RootPath)
        Me.Controls.Add(Me.settingForm_RootPathLabel)
        Me.Controls.Add(Me.settingForm_IsActive)
        Me.Controls.Add(Me.EmailGroup)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsForm"
        Me.ShowIcon = False
        Me.Text = "Nastavení"
        Me.EmailGroup.ResumeLayout(False)
        Me.EmailGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents settingForm_IsActive As Windows.Forms.CheckBox
    Friend WithEvents settingForm_RootPathLabel As Windows.Forms.Label
    Friend WithEvents settingForm_RootPath As Windows.Forms.TextBox
    Friend WithEvents settingForm_RootFolderSelectDialog As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents InfoToolTip As Windows.Forms.ToolTip
    Friend WithEvents EmailGroup As Windows.Forms.GroupBox
    Friend WithEvents ButtonSelectContact As Windows.Forms.Button
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
    Friend WithEvents settingForm_SenderAddress As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents settingForm_MonitoredFolders As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents settingForm_MonitorFolderSelectDialog As Windows.Forms.Button
    Friend WithEvents VersionApp As Windows.Forms.Label
    Friend WithEvents AppGitHubLink As Windows.Forms.LinkLabel
End Class
