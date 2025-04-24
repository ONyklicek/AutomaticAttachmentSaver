Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class ThisAddIn
    Public Property SettingsManager As SettingsManager
    Private monitoredItems As New List(Of Outlook.MailItem)()

    Private Sub ThisAddIn_Startup() Handles Me.Startup
        SettingsManager = New SettingsManager()

        Dim folderPaths As String() = SettingsManager.MonitoredFolders.Split("|"c)
        Dim session As Outlook.NameSpace = Me.Application.Session

        For Each folderPath As String In folderPaths
            ' #Získání složky podle cesty
            Dim folder As Outlook.MAPIFolder = GetFolderByPath(folderPath.Trim(), session)

            If folder IsNot Nothing Then
                ' #Získání položek ze složky
                Dim items As Outlook.Items = folder.Items

                ' #Přidání položek do seznamu monitoredItems
                'For Each item As Object In items
                '    If TypeOf item Is Outlook.MailItem Then
                '        monitoredItems.Add(CType(item, Outlook.MailItem))
                '    End If
                'Next

                ' #Připojení k eventu ItemAdd pro zachycení nových položek
                AddHandler items.ItemAdd, AddressOf MailItemReceived
            Else
                ' Zobrazení zprávy, pokud složka není nalezena
                MessageBox.Show("Nepodařilo se najít složku: " & folderPath)
            End If
        Next
    End Sub

    Private Sub MailItemReceived(Item As Object)

        ' #Pokud je položka e-mail, zpracovat ji
        If (TypeOf Item IsNot Outlook.MailItem) Or Not SettingsManager.IsActive Then
            Return
        End If

        Dim mail As Outlook.MailItem = CType(Item, Outlook.MailItem)

        If SettingsManager.IsSetSenderAddress And Not mail.SenderEmailAddress = SettingsManager.SenderAddress Then
            Return
        End If

        ' #Přidání e-mailu do seznamu monitoredItems
        'monitoredItems.Add(mail)

        ' #Procesování e-mailu
        ProcessMail(mail)
    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown
        ' #Uvolnění prostředků
        'monitoredItems.Clear()
    End Sub

    Public Sub ProcessMail(mail As Outlook.MailItem)
        Dim FolderPath As String
        Dim OrderNumber As String
        Dim Exported As Boolean = False

        ' #Získat číslo zakázky z předmětu nebo těla
        OrderNumber = ExtractOrderNumber(mail.Subject, SettingsManager.OrderNumberPatternSubject)


        'If OrderNumber = "" Then
        '    OrderNumber = ExtractOrderNumber(mail.Body, SettingsManager.OrderNumberPatternBody)
        'End If

        ' #Pokud číslo zakázky existuje
        If OrderNumber <> "" Then
            ' #Najít složku podle čísla zakázky ve všech složkách "Zakázky*"
            FolderPath = FindFolder(SettingsManager.RootPath, OrderNumber)

            ' #Pokud složka existuje, uložit přílohy
            If FolderPath <> "" Then
                For Each attach As Outlook.Attachment In mail.Attachments
                    If attach.FileName.ToLower().EndsWith(".pdf") Then
                        Dim targetFile As String = Path.Combine(FolderPath, attach.FileName)
                        If Not File.Exists(targetFile) Then
                            attach.SaveAsFile(targetFile)
                            Exported = True
                        End If
                    End If
                Next

                If Exported Then
                    mail.UnRead = False
                    mail.Save()
                End If
            End If
        End If
    End Sub


    Private Function FindFolder(rootPath As String, orderNumber As String) As String
        If Directory.Exists(rootPath) Then
            Dim rootFolders = Directory.GetDirectories(rootPath)

            For Each yearFolder As String In rootFolders
                If Path.GetFileName(yearFolder).StartsWith("Zakázky") Then
                    Dim subFolders = Directory.GetDirectories(yearFolder)
                    For Each subFolder As String In subFolders
                        If Path.GetFileName(subFolder).StartsWith(orderNumber) Then
                            Return subFolder
                        End If
                    Next
                End If
            Next
        End If

        ' #Pokud složka nebyla nalezena
        Return ""
    End Function

    Private Function ExtractOrderNumber(subject As String, pattern As String) As String
        Dim match As Match = Regex.Match(subject, pattern)
        If match.Success Then
            Return match.Value
        Else
            Return ""
        End If
    End Function

    Private Function GetFolderByPath(folderPath As String, session As Outlook.NameSpace) As Outlook.MAPIFolder
        ' #Rozdělit cestu a odstranit prázdné položky
        Dim parts As String() = folderPath.Split("\"c).Where(Function(p) Not String.IsNullOrEmpty(p)).ToArray()

        If parts.Length = 0 Then Return Nothing

        Dim folder As Outlook.MAPIFolder = Nothing

        Try
            ' #Získat root mailbox složku
            For Each rootFolder As Outlook.MAPIFolder In session.Folders
                If String.Equals(rootFolder.Name, parts(0).Trim(), StringComparison.OrdinalIgnoreCase) Then
                    folder = rootFolder
                    Exit For
                End If
            Next

            If folder Is Nothing Then Return Nothing

            ' #Projít zbytek cesty
            For i As Integer = 1 To parts.Length - 1
                Dim subFolderName As String = parts(i).Trim()
                Dim subFolder As Outlook.MAPIFolder = Nothing

                For Each f As Outlook.MAPIFolder In folder.Folders
                    If String.Equals(f.Name, subFolderName, StringComparison.OrdinalIgnoreCase) Then
                        subFolder = f
                        Exit For
                    End If
                Next

                If subFolder Is Nothing Then Return Nothing

                folder = subFolder
            Next

        Catch ex As Exception
            ' #Možné logování chyby sem
            Return Nothing
        End Try

        Return folder
    End Function
End Class
