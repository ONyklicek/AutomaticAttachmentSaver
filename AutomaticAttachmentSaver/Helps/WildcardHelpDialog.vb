Imports System.Windows.Forms
Imports System.Drawing

Public Class WildcardHelpDialog
    Inherits Form ' Přidáno dědění z Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        ' Nastavení vlastností formuláře
        Me.Text = "Nápověda - Zástupné znaky"
        Me.Size = New Size(800, 500)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterParent

        ' Vytvoření tabulky
        CreateWildcardTable()

        ' Přidání tlačítka pro zavření
        Dim closeButton As New Button()
        closeButton.Text = "Zavřít"
        closeButton.DialogResult = DialogResult.OK
        closeButton.Size = New Size(100, 30)
        closeButton.Location = New Point((Me.ClientSize.Width - closeButton.Width) \ 2, Me.ClientSize.Height - 50)
        closeButton.Anchor = AnchorStyles.Bottom
        Me.Controls.Add(closeButton)
        Me.AcceptButton = closeButton
    End Sub

    Private Sub CreateWildcardTable()
        ' Vytvoření panelu pro tabulku s možností scrollování
        Dim panel As New Panel()
        panel.AutoScroll = True
        panel.Dock = DockStyle.Top
        panel.Height = Me.ClientSize.Height - 60
        Me.Controls.Add(panel)

        ' Nadpis
        Dim titleLabel As New Label()
        titleLabel.Text = "Zástupné znaky (wildcards)"
        titleLabel.Font = New Font(titleLabel.Font.FontFamily, 14, FontStyle.Bold)
        titleLabel.AutoSize = True
        titleLabel.Location = New Point(10, 10)
        panel.Controls.Add(titleLabel)

        ' Vytvoření tabulky se zástupnými znaky
        Dim tableY As Integer = titleLabel.Bottom + 10
        Dim columnWidths As Integer() = {50, 180, 100, 140, 140}
        Dim rowHeight As Integer = 40

        ' Záhlaví tabulky
        CreateTableHeader(panel, tableY, columnWidths, {"Symbol", "Význam", "Příklad", "Co najde", "Co nenajde"})
        tableY += rowHeight

        ' Řádky tabulky se zástupnými znaky
        CreateTableRow(panel, tableY, columnWidths, {"*", "Libovolný počet znaků", "dok*.txt", "dokument.txt, dok.txt", "dk.txt"})
        tableY += rowHeight

        CreateTableRow(panel, tableY, columnWidths, {"?", "Jeden libovolný znak", "dok?.txt", "dokA.txt, dok1.txt", "dok.txt, dok12.txt"})
        tableY += rowHeight

        CreateTableRow(panel, tableY, columnWidths, {"#", "Jedna číslice (0-9)", "faktura#.pdf", "faktura1.pdf, faktura0.pdf", "fakturaA.pdf, faktura.pdf"})
        tableY += rowHeight

        CreateTableRow(panel, tableY, columnWidths, {"[abc]", "Jeden znak ze seznamu", "zpráva[ABC].doc", "zprávaA.doc, zprávaB.doc", "zprávaD.doc, zpráva1.doc"})
        tableY += rowHeight

        CreateTableRow(panel, tableY, columnWidths, {"[!abc]", "Jeden znak, který není v seznamu", "zpráva[!123].doc", "zprávaA.doc, zprávaB.doc", "zpráva1.doc, zpráva2.doc"})
        tableY += rowHeight

        ' Nadpis druhé části
        Dim examplesTitle As New Label()
        examplesTitle.Text = "Praktické příklady"
        examplesTitle.Font = New Font(examplesTitle.Font.FontFamily, 14, FontStyle.Bold)
        examplesTitle.AutoSize = True
        examplesTitle.Location = New Point(10, tableY + 20)
        panel.Controls.Add(examplesTitle)
        tableY = examplesTitle.Bottom + 10

        ' Záhlaví tabulky příkladů
        Dim exampleColumnWidths As Integer() = {150, 150, 260}
        CreateTableHeader(panel, tableY, exampleColumnWidths, {"Co hledáte", "Vzor pro vyhledávání", "Vysvětlení"})
        tableY += rowHeight

        ' Řádky tabulky s příklady
        CreateTableRow(panel, tableY, exampleColumnWidths, {"Všechny Excel soubory", "*.xlsx", "Jakýkoliv název s příponou xlsx"})
        tableY += rowHeight

        CreateTableRow(panel, tableY, exampleColumnWidths, {"Faktury z roku 2023", "Faktura*2023*.pdf", "Název začíná 'Faktura', někde obsahuje '2023', končí příponou pdf"})
        tableY += rowHeight * 2 ' Větší výška pro delší text

        CreateTableRow(panel, tableY, exampleColumnWidths, {"Dokumenty verze 1-5", "Dokument[12345].docx", "Dokument s číslem verze 1, 2, 3, 4 nebo 5"})
        tableY += rowHeight

        CreateTableRow(panel, tableY, exampleColumnWidths, {"Fotky kromě selfie", "IMG_[!S]*.jpg", "Fotky, které nezačínají písmenem S po předponě IMG_"})
        tableY += rowHeight

        CreateTableRow(panel, tableY, exampleColumnWidths, {"Soubory s konkrétním datem", "*_2023-06-##.*", "Soubory obsahující datum 2023-06 následované dvěma číslicemi"})
    End Sub

    Private Sub CreateTableHeader(panel As Panel, y As Integer, columnWidths As Integer(), headerTexts As String())
        Dim x As Integer = 10

        For i As Integer = 0 To columnWidths.Length - 1
            Dim header As New Label()
            header.Text = headerTexts(i)
            header.Font = New Font(header.Font, FontStyle.Bold)
            header.Size = New Size(columnWidths(i), 30)
            header.Location = New Point(x, y)
            header.TextAlign = ContentAlignment.MiddleLeft
            header.BorderStyle = BorderStyle.FixedSingle
            header.BackColor = Color.LightGray
            panel.Controls.Add(header)
            x += columnWidths(i)
        Next

        ' Přidání horizontální čáry pod záhlavím
        Dim headerLine As New Panel()
        headerLine.Height = 2
        headerLine.Width = x - 10
        headerLine.Location = New Point(10, y + 30)
        headerLine.BackColor = Color.Black
        panel.Controls.Add(headerLine)
    End Sub

    Private Sub CreateTableRow(panel As Panel, y As Integer, columnWidths As Integer(), cellTexts As String())
        Dim x As Integer = 10

        For i As Integer = 0 To columnWidths.Length - 1
            Dim cell As New Label()
            cell.Text = cellTexts(i)
            cell.Size = New Size(columnWidths(i), 40)
            cell.Location = New Point(x, y)
            cell.TextAlign = ContentAlignment.MiddleLeft
            cell.BorderStyle = BorderStyle.FixedSingle
            panel.Controls.Add(cell)
            x += columnWidths(i)
        Next
    End Sub
End Class