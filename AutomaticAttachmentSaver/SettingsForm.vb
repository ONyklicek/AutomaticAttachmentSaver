Imports System.Windows.Forms

Public Class SettingsForm
    Private SettingsManager As SettingsManager
    Dim helpDialog As New WildcardHelpDialog()


    Public Sub New()
        InitializeComponent()
        SettingsManager = New SettingsManager()
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        settingForm_IsActive.Checked = SettingsManager.IsActive
        settingForm_RootPath.Text = SettingsManager.RootPath
        settingForm_MonitoredFolders.Text = SettingsManager.MonitoredFolders
        settingForm_SenderAddress.Text = SettingsManager.SenderAddress
        VersionApp.Text = "Version: " & SettingsManager.AppVersion
    End Sub

    Private Sub SettingForm_IsActive_CheckedChanged(sender As Object, e As EventArgs) Handles settingForm_IsActive.CheckedChanged
        SettingsManager.IsActive = settingForm_IsActive.Checked
    End Sub

    Private Sub SettingForm_RootFolderSelectDialog_Click(sender As Object, e As EventArgs) Handles settingForm_RootFolderSelectDialog.Click
        Using dialog As New FolderBrowserDialog()
            dialog.Description = "Select root folder"
            dialog.SelectedPath = SettingsManager.RootPath
            dialog.ShowNewFolderButton = True

            If dialog.ShowDialog() = DialogResult.OK Then
                SettingsManager.RootPath = dialog.SelectedPath
                settingForm_RootPath.Text = dialog.SelectedPath
            End If
        End Using
    End Sub

    Private Sub SettingForm_MonitorFolderSelectDialog_Click(sender As Object, e As EventArgs) Handles settingForm_MonitorFolderSelectDialog.Click
        Dim path = SettingsManager.SelectFolder()
        If Not String.IsNullOrEmpty(path) Then
            Dim folders As List(Of String) = New List(Of String)()

            If Not String.IsNullOrEmpty(SettingsManager.MonitoredFolders) Then
                folders = SettingsManager.MonitoredFolders.Split("|"c).Where(Function(f) Not String.IsNullOrWhiteSpace(f)).ToList()
            End If


            If Not folders.Contains(path) Then
                folders.Add(path)
            End If

            SettingsManager.MonitoredFolders = path 'String.Join("|", folders)
            settingForm_MonitoredFolders.Text = SettingsManager.MonitoredFolders
        End If
    End Sub

    Private Sub ButtonSelectContact_Click(sender As Object, e As EventArgs) Handles ButtonSelectContact.Click
        Dim email = SettingsManager.SelectContact()
        If Not String.IsNullOrEmpty(email) Then
            SettingsManager.SenderAddress = email
            settingForm_SenderAddress.Text = email
        End If
    End Sub

    Private Sub SettingForm_SenderAddress_TextChange(sender As Object, e As EventArgs) Handles settingForm_SenderAddress.TextChanged
        SettingsManager.SenderAddress = settingForm_SenderAddress.Text
    End Sub

    Private Sub SettingForm_MonitoredFolders_TextChanged(sender As Object, e As EventArgs) Handles settingForm_MonitoredFolders.TextChanged
        SettingsManager.MonitoredFolders = settingForm_MonitoredFolders.Text
    End Sub


    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SettingsManager.SaveSettings()
        Close()
    End Sub

    Private Sub AppGitHubLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles AppGitHubLink.LinkClicked
        System.Diagnostics.Process.Start(SettingsManager.AppLinkGithub)
    End Sub

    Private Sub SettingForm_searchDirectoryPattern_Text_TextChanged(sender As Object, e As EventArgs) Handles settingForm_searchDirectoryPattern_Text.TextChanged
        SettingsManager.SearchDirectoryPattern = settingForm_searchDirectoryPattern_Text.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        helpDialog.ShowDialog(Me)
    End Sub
End Class
