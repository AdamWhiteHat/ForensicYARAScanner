﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForensicYARAScanner.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>swapfile.sys</string>
  <string>hiberfil.sys</string>
  <string>pagefile.sys</string>
  <string>$Volume</string>
  <string>$Secure</string>
  <string>$BadClus</string>
  <string>$AttrDef</string>
  <string>$MFTMirr</string>
  <string>$Boot</string>
  <string>$UpCase</string>
  <string>$Bitmap</string>
  <string>$LogFile</string>
  <string>$MFT</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection IgnoreTheseRootFiles {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["IgnoreTheseRootFiles"]));
            }
            set {
                this["IgnoreTheseRootFiles"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>$Extend</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection IgnoreTheseRootDirectories {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["IgnoreTheseRootDirectories"]));
            }
            set {
                this["IgnoreTheseRootDirectories"] = value;
            }
        }
    }
}
