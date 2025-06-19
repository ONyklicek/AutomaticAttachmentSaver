Imports System.Resources
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security

' Obecné informace o sestavení se řídí přes následující 
' sadu atributů. Změnou hodnot těchto atributů se upraví informace
' přidružené k sestavení.

' Zkontrolujte hodnoty atributů sestavení.

<Assembly: AssemblyTitle("AutomaticAttachmentSaver")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("NyonCode")>
<Assembly: AssemblyProduct("AutomaticAttachmentSaver")>
<Assembly: AssemblyCopyright("Copyright © NyonCode 2025")>
<Assembly: AssemblyTrademark("")>

' Nastavení atributu ComVisible na hodnotu False udělá typy v tomto sestavení neviditelné 
' pro komponenty modelu COM.  Pokud potřebujete přistupovat k typům tohoto sestavení z 
' modelu COM, nastavte atribut ComVisible daného typu na hodnotu True.
<Assembly: ComVisible(False)>

'Následující GUID se používá pro ID knihovny typů, pokud je tento projekt vystavený pro COM.
<Assembly: Guid("00734d9b-df5f-415c-97be-999879c5a76d")>

' Informace o verzi sestavení se skládá z těchto čtyř hodnot:
'
'      Hlavní verze
'      Dílčí verze 
'      Číslo sestavení
'      Revize
'
' Můžete zadat všechny hodnoty nebo nechat nastavená výchozí čísla sestavení a revize 
' pomocí zástupného znaku * takto:
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("1.0.1.0")>
<Assembly: AssemblyFileVersion("1.0.1.0")>
<Assembly: NeutralResourcesLanguage("cs-CZ")>
Friend Module DesignTimeConstants
    Public Const RibbonTypeSerializer As String = "Microsoft.VisualStudio.Tools.Office.Ribbon.Serialization.RibbonTypeCodeDomSerializer, Microsoft.VisualStudio.Tools.Office.Designer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Public Const RibbonBaseTypeSerializer As String = "System.ComponentModel.Design.Serialization.TypeCodeDomSerializer, System.Design"
    Public Const RibbonDesigner As String = "Microsoft.VisualStudio.Tools.Office.Ribbon.Design.RibbonDesigner, Microsoft.VisualStudio.Tools.Office.Designer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
End Module
