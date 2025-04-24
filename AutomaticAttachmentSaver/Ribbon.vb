'TODO:  Následujícím postupem povolíte položku pásu karet (XML):

'1: Zkopírujte následující blok kódu do třídy ThisAddin, ThisWorkbook nebo ThisDocument.

'Protected Overrides Function CreateRibbonExtensibilityObject() As Microsoft.Office.Core.IRibbonExtensibility
'    Return New Ribbon()
'End Function

'2. Vytvořte metody zpětného volání v oblasti „Zpětná volání pásu karet” této třídy, které budou zpracovávat
'   akce uživatele, jako je kliknutí na tlačítko. Poznámka: pokud jste tento pás karet exportovali z návrháře pásu karet,
'   přesuňte váš kód z obslužných rutin události do metod zpětného volání a upravte kód tak, aby fungoval s
'   programovacím modelem RibbonX (Ribbon extensibility).

'3. Přiřazením atributů značkám řízení v souboru XML pásu karet identifikujte příslušné metody zpětného volání ve vašem kódu.

'Další informace najdete v dokumentaci ke kódu XML pásu karet v nápovědě k Visual Studio Tools for Office.

<Runtime.InteropServices.ComVisible(True)> _
Public Class Ribbon
    Implements Office.IRibbonExtensibility

    Private ribbon As Office.IRibbonUI

    Public Sub New()
    End Sub

    Public Function GetCustomUI(ByVal ribbonID As String) As String Implements Office.IRibbonExtensibility.GetCustomUI
        Return GetResourceText("AutomaticAttachmentSaver.Ribbon.xml")
    End Function

#Region "Zpětná volání pásu karet"
    'Tady můžete vytvářet metody zpětného volání. Další informace o přidání metod zpětného volání najdete na adrese https://go.microsoft.com/fwlink/?LinkID=271226.
    Public Sub Ribbon_Load(ByVal ribbonUI As Office.IRibbonUI)
        Me.ribbon = ribbonUI
    End Sub



#End Region

#Region "Pomocníci"

    Private Shared Function GetResourceText(ByVal resourceName As String) As String
        Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        Dim resourceNames() As String = asm.GetManifestResourceNames()
        For i As Integer = 0 To resourceNames.Length - 1
            If String.Compare(resourceName, resourceNames(i), StringComparison.OrdinalIgnoreCase) = 0 Then
                Using resourceReader As IO.StreamReader = New IO.StreamReader(asm.GetManifestResourceStream(resourceNames(i)))
                    If resourceReader IsNot Nothing Then
                        Return resourceReader.ReadToEnd()
                    End If
                End Using
            End If
        Next
        Return Nothing
    End Function

#End Region

End Class
