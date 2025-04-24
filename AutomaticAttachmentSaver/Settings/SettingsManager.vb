Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Outlook

Public Class SettingsManager
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
    Public Property MailFilterPattern As String
    Public Property OrderNumberPatternSubject As String
    Public Property IsSetSenderAddress As Boolean

    Public Sub New()
        LoadSettings()
    End Sub


    Public Sub LoadSettings()
        IsActive = My.Settings.isActive
        RootPath = My.Settings.RootPath
        MonitoredFolders = My.Settings.MonitoredFolders
        SenderAddress = My.Settings.senderAddress
        MailFilterPattern = My.Settings.mailFilterPattern
        OrderNumberPatternSubject = My.Settings.OrderNumberPatternSubject
        IsSetSenderAddress = HasSetSenderAddress()
    End Sub

    Public Sub SaveSettings()
        My.Settings.isActive = IsActive
        My.Settings.RootPath = RootPath
        My.Settings.MonitoredFolders = MonitoredFolders
        My.Settings.senderAddress = SenderAddress
        My.Settings.mailFilterPattern = MailFilterPattern
        My.Settings.OrderNumberPatternSubject = OrderNumberPatternSubject
        My.Settings.Save()
    End Sub

    Public Function SelectFolder() As String
        Dim outlookApp As Outlook.Application = Globals.ThisAddIn.Application
        Dim selectedFolder As MAPIFolder = outlookApp.Session.PickFolder()

        Return If(selectedFolder IsNot Nothing, selectedFolder.FolderPath, String.Empty)
    End Function

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

                    ' Ochrana proti výběru skupiny (Distribution List)
                    If addressEntry.AddressEntryUserType = Outlook.OlAddressEntryUserType.olExchangeDistributionListAddressEntry Then
                        MessageBox.Show("Vybraný záznam je distribuční skupina a není povolen.", "Nepovolený výběr")
                        Return Nothing
                    End If

                    Select Case addressEntry.AddressEntryUserType
                        Case Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry
                            Dim exchUser As Outlook.ExchangeUser = addressEntry.GetExchangeUser()
                            If exchUser IsNot Nothing Then
                                Return exchUser.PrimarySmtpAddress
                            End If

                        Case Outlook.OlAddressEntryUserType.olOutlookContactAddressEntry
                            Dim contact As Outlook.ContactItem = TryCast(addressEntry.GetContact(), Outlook.ContactItem)
                            If contact IsNot Nothing Then
                                Return contact.Email1Address
                            End If

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

    Private Function HasSetSenderAddress() As Boolean
        If SenderAddress = String.Empty Then
            Return False
        End If

        Return True
    End Function
End Class
