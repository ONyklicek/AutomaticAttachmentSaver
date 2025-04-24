Imports System.Windows.Forms

Public Class SettingsForm
    Private settings As SettingsManager

    Public Sub New()
        InitializeComponent()
        settings = New SettingsManager()
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        settingForm_IsActive.Checked = settings.IsActive
        settingForm_RootPath.Text = settings.RootPath
        settingForm_MonitoredFolders.Text = settings.MonitoredFolders
        settingForm_SenderAddress.Text = settings.SenderAddress
    End Sub

    Private Sub settingForm_IsActive_CheckedChanged(sender As Object, e As EventArgs) Handles settingForm_IsActive.CheckedChanged
        settings.IsActive = settingForm_IsActive.Checked
    End Sub

    Private Sub settingForm_RootFolderSelectDialog_Click(sender As Object, e As EventArgs) Handles settingForm_RootFolderSelectDialog.Click
        Using dialog As New FolderBrowserDialog()
            dialog.Description = "Select root folder"
            dialog.SelectedPath = settings.RootPath
            dialog.ShowNewFolderButton = True

            If dialog.ShowDialog() = DialogResult.OK Then
                settings.RootPath = dialog.SelectedPath
                settingForm_RootPath.Text = dialog.SelectedPath
            End If
        End Using
    End Sub

    Private Sub settingForm_MonitorFolderSelectDialog_Click(sender As Object, e As EventArgs) Handles settingForm_MonitorFolderSelectDialog.Click
        Dim path = settings.SelectFolder()
        If Not String.IsNullOrEmpty(path) Then
            Dim folders As List(Of String) = New List(Of String)()

            If Not String.IsNullOrEmpty(settings.MonitoredFolders) Then
                folders = settings.MonitoredFolders.Split("|"c).Where(Function(f) Not String.IsNullOrWhiteSpace(f)).ToList()
            End If


            If Not folders.Contains(path) Then
                folders.Add(path)
            End If

            settings.MonitoredFolders = path 'String.Join("|", folders)
            settingForm_MonitoredFolders.Text = settings.MonitoredFolders
        End If
    End Sub

    Private Sub ButtonSelectContact_Click(sender As Object, e As EventArgs) Handles ButtonSelectContact.Click
        Dim email = settings.SelectContact()
        If Not String.IsNullOrEmpty(email) Then
            settings.SenderAddress = email
            settingForm_SenderAddress.Text = email
        End If
    End Sub

    Private Sub settingForm_SenderAddress_TextChange(sender As Object, e As EventArgs) Handles settingForm_SenderAddress.TextChanged
        settings.SenderAddress = settingForm_SenderAddress.Text
    End Sub

    Private Sub settingForm_MonitoredFolders_TextChanged(sender As Object, e As EventArgs) Handles settingForm_MonitoredFolders.TextChanged
        settings.MonitoredFolders = settingForm_MonitoredFolders.Text
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles Button1.Click
        settings.SaveSettings()
        Close()
    End Sub
End Class
