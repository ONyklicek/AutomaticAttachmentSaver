Imports System.Reflection
Imports System.Windows.Forms
Imports System.Exception
Imports Microsoft.Win32
Imports Microsoft.Office.Interop.Outlook

Public Class SettingsManager
    Private fileVersionInfo As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString
    Private Const RegistryPath As String = "Software\NyonCode\AutomaticAttachmentSaver"

    Private _SenderAddress As String

    Public Property IsActive As Boolean
    Public Property RootPath As String
    Public Property MonitoredFolders As String
    Public Property SenderAddress As String
        Get
            Return _SenderAddress
        End Get
        Set(value As String)
            _SenderAddress = value
            HasSetSenderAddress()
        End Set
    End Property
    Public Property SearchDirectoryPattern As String
    Public Property OrderNumberPatternSubject As String
    Public Property IsSetSenderAddress As Boolean
    Public Property AppLinkGithub As String
    Public Property AppVersion As String

    Public Sub New()
        LoadSettings()
    End Sub

    ' Načte nastavení z registrů
    Public Sub LoadSettings()
        IsActive = CBool(GetRegistryValue("IsActive", False))
        RootPath = GetRegistryValue("RootPath", "")
        MonitoredFolders = GetRegistryValue("MonitoredFolders", "")
        SenderAddress = GetRegistryValue("SenderAddress", "")
        SearchDirectoryPattern = GetRegistryValue("SearchDirectoryPattern", "")
        OrderNumberPatternSubject = My.Settings.OrderNumberPatternSubject
        IsSetSenderAddress = HasSetSenderAddress()
        AppLinkGithub = My.Settings.AppLinkGithub
        AppVersion = fileVersionInfo
    End Sub

    ' Uloží nastavení do registrů
    Public Sub SaveSettings()
        SetRegistryValue("IsActive", IsActive.ToString())
        SetRegistryValue("RootPath", RootPath)
        SetRegistryValue("MonitoredFolders", MonitoredFolders)
        SetRegistryValue("SenderAddress", SenderAddress)
        SetRegistryValue("SearchDirectoryPattern", SearchDirectoryPattern)
        SetRegistryValue("OrderNumberPatternSubject", OrderNumberPatternSubject)
        'SetRegistryValue("AppLinkGithub", AppLinkGithub)
    End Sub

    ' Vybere složku v Outlooku
    Public Function SelectFolder() As String
        Dim outlookApp As Outlook.Application = Globals.ThisAddIn.Application
        Dim selectedFolder As MAPIFolder = outlookApp.Session.PickFolder()

        Return If(selectedFolder IsNot Nothing, selectedFolder.FolderPath, String.Empty)
    End Function
    ' Vybere kontakt a vrátí email
    Public Function SelectContact() As String
        Try
            Dim outlookApp As Outlook.Application = Globals.ThisAddIn.Application
            Dim session As Outlook.NameSpace = outlookApp.Session

            Dim dialog As Outlook.SelectNamesDialog = session.GetSelectNamesDialog()
            dialog.AllowMultipleSelection = False

            If dialog.Display() Then
                If dialog.Recipients.Count > 0 Then
                    Dim recipient As Outlook.Recipient = dialog.Recipients.Item(1)
                    Dim addressEntry As Outlook.AddressEntry = recipient.AddressEntry

                    If addressEntry Is Nothing Then
                        MessageBox.Show("Nelze získat informace o vybraném příjemci.", "Chyba")
                        Return Nothing
                    End If

                    If addressEntry.AddressEntryUserType = Outlook.OlAddressEntryUserType.olExchangeDistributionListAddressEntry Then
                        MessageBox.Show("Vybraný záznam je distribuční skupina a není povolen.", "Nepovolený výběr")
                        Return Nothing
                    End If

                    Select Case addressEntry.AddressEntryUserType
                        Case Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry
                            Dim exchUser As Outlook.ExchangeUser = addressEntry.GetExchangeUser()
                            If exchUser IsNot Nothing Then Return exchUser.PrimarySmtpAddress

                        Case Outlook.OlAddressEntryUserType.olOutlookContactAddressEntry
                            Dim contact As Outlook.ContactItem = TryCast(addressEntry.GetContact(), Outlook.ContactItem)
                            If contact IsNot Nothing Then Return contact.Email1Address

                        Case Else
                            MessageBox.Show("Vybraný záznam není kontakt, ale skupina nebo jiný typ.", "Nepovolený výběr")
                            SelectContact()
                    End Select
                Else
                    MessageBox.Show("Nebyl vybrán žádný kontakt.", "Informace")
                End If
            End If

        Catch ex As System.Exception
            MessageBox.Show("Chyba při výběru kontaktu: " & ex.Message)
        End Try

        Return Nothing
    End Function

    ' Pomocná funkce pro kontrolu nastavení emailu
    Private Function HasSetSenderAddress() As Boolean
        Return Not String.IsNullOrEmpty(SenderAddress)
    End Function

    ' Zápis do registru
    Private Sub SetRegistryValue(name As String, value As String)
        Dim key = Registry.CurrentUser.CreateSubKey(RegistryPath)
        key.SetValue(name, value)
        key.Close()
    End Sub

    ' Čtení z registru
    Private Function GetRegistryValue(name As String, Optional defaultValue As String = "") As String
        Dim key = Registry.CurrentUser.OpenSubKey(RegistryPath)
        If key Is Nothing Then Return defaultValue

        Dim value = key.GetValue(name, defaultValue).ToString()
        key.Close()
        Return value
    End Function

End Class
