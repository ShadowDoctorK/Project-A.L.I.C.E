﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ALICE.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
    internal sealed partial class Miscellanous : global::System.Configuration.ApplicationSettingsBase {
        
        private static Miscellanous defaultInstance = ((Miscellanous)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Miscellanous())));
        
        public static Miscellanous Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal FireGroup_Total {
            get {
                return ((decimal)(this["FireGroup_Total"]));
            }
            set {
                this["FireGroup_Total"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal FireGroup_Default {
            get {
                return ((decimal)(this["FireGroup_Default"]));
            }
            set {
                this["FireGroup_Default"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool NPC_Crew {
            get {
                return ((bool)(this["NPC_Crew"]));
            }
            set {
                this["NPC_Crew"] = value;
            }
        }
    }
}
