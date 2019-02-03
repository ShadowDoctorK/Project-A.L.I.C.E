using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vmAPI;

namespace ALICE_Interface
{
    public static class IVoiceMacro
    {
        public static VoiceMacro API = new VoiceMacro();
    }

    public class VoiceMacro : vmInterface
    {
        //This is a custom internal logging string I use. It is not part of the interface
        static readonly string MethodName = "Voice Macro Interface";

        /// <summary>
        ///Plugin name displayed in VoiceMacro
        /// </summary>
        public string DisplayName
        {
            get => "Project A.L.I.C.E Interface - " + IPlatform.Version;
        }

        /// <summary>
        /// Description for your plugin.
        /// </summary>
        public string Description
        {
            get => "Project A.L.I.C.E Interface - " + IPlatform.Version;
        }

        /// <summary>
        /// GUID for your Plugin.
        /// </summary>
        public string ID
        {
            get => "A1C09FFD-1996-41F4-90EF-BDB0DABC0473";
        }

        /// <summary>
        /// This is called when the plugin gets actiavted.
        /// </summary>
        void vmInterface.Init()
        {
            try
            {
                PlugIn.Respond = PlugIn.Output.TTS;
                Paths.CreateDir();
                Paths.Load_UpdateBindsFile();
                IPlatform.Interface = IPlatform.Interfaces.VoiceMacro;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Start-up Hamsters Reported An Issue: " + ex);
                Logger.Exception(MethodName, "Initialization Exception: " + ex);
            }

            Logger.Simple("Configured For Voice Attack. Standing By To Initialize...", Logger.Purple);
        }

        /// <summary>
        /// This is invoked when you use the SendToPlugin action from your Voice Macro Profile.
        /// </summary>
        /// <param name="Param1">Item 1 Passed from Voice Macro.</param>
        /// <param name="Param2">Item 1 Passed from Voice Macro.</param>
        /// <param name="Param3">Item 1 Passed from Voice Macro.</param>
        /// <param name="Synchron">Wait to complete.</param>
        void vmInterface.ReceiveParams(string Param1, string Param2, string Param3, bool Synchron)
        {
            // Write received Parameters to Log for example.
            vmCommand.AddLogEntry("Sample plugin received new Parameters, Param1: " + Param1 + " / Param2: " + Param2 + " / Param3: " + Param3, Color.Yellow, ID);
        }

        //This is invoked when a profile is switched
        void vmInterface.ProfileSwitched(string ProfileGUID, string ProfileName)
        {
            vmCommand.AddLogEntry("Profile Swtich " + ProfileName, Color.Black, ID);
            vmCommand.AddLogEntry("Profile Swtich " + ProfileGUID, Color.Black, ID);
        }

        //This is started when VoiceMacro is terminated
        void vmInterface.Dispose()
        {
            // Stop activities because VoiceMacro is shutting down
        }
    }

    #region Notes
    /*
    vmAPI.My.Resources.Resources
    A strongly-typed resource class, for looking up localized strings, etc. 

    vmAPI.My.Resources.Resources.ResourceManager
    Returns the cached ResourceManager instance used by this class. 

    vmAPI.My.Resources.Resources.Culture
    Overrides the current thread's CurrentUICulture property for allresource lookups using this strongly typed resource class. 

    vmAPI.vmInterface.DisplayName
    The Display name of your plugin. 

    vmAPI.vmInterface.Description
    The Description of your plugin. 

    vmAPI.vmInterface.ID
    The ID (GUID) of your plugin. 

    vmAPI.vmInterface.Init
    This is invoked when your plugin is loaded. 

    vmAPI.vmInterface.Dispose
    This is invoked when VoiceMacro is terminated. 

    vmAPI.vmInterface.ReceiveParams(System.String,System.String,System.String,System.Boolean)
    This is invoked when a macro is sending parameters. 

    vmAPI.vmInterface.ProfileSwitched(System.String,System.String)
    This is invoked when a profile is switched. 

    vmAPI.vmProfile
    This is the structure for a profile. 

    vmAPI.vmProfile.ProfileName
    The name of a profile. 

    vmAPI.vmProfile.GUID
    Unique ID of the profile. 

    vmAPI.vmProfile.Commands
    A list of commands. 

    vmAPI.Commands
    This is the structure for a command. 

    vmAPI.Commands.RecocnitionText
    The name and recognitiontext of a command. 

    vmAPI.Commands.GUID
    unique ID of the command. 

    vmAPI.vmCommand.APIClass
    Used to store VoiceMacro's API class, not used by plugins. 

    vmAPI.vmCommand.zRegistervmclass(System.Object)
    Registers VoiceMacro's API class, not used by plugins. 

    vmAPI.vmCommand.GetVariable(System.String)
    Returns the value of a variable by name.Returns "ERR!" if variable is not existing.Note: Only works for profile (_p), global (_g) and saved (_s) variables. 

    vmAPI.vmCommand.SetVariable(System.String,System.String)
    Sets the value of a variable by name.Creates the variable if not existing.Note: Only works for profile (_p), global (_g) and saved (_s) variables. 

    vmAPI.vmCommand.AddLogEntry(System.String,System.Drawing.Color,System.String,System.String,System.String)
    Writes a text to the log file with a specific color.text is the message, color is the color of the log sign, ID is your plugin ID, sign is your sign (only 1 character allowed), statusText is showed in the status bar of the main window. 

    vmAPI.vmCommand.GetProfiles
    Returns all the profiles and commands as List(Of vmProfile). 

    vmAPI.vmCommand.ExecuteMacro(System.String)
    Starts a macro by Profile/Macro GUID. 

    vmAPI.vmCommand.GetActiveProfileGUID
    Gets active Profile GUID. "No Profile" is returned if there is none. 

    vmAPI.vmCommand.CommandExists(System.String)
    Checks if a command exists.Returns Profile GUID/Macro GUID of the command

    vmAPI.vmCommand.GetDataDirectory
    Returns VoiceMacro's Data Directory 
    */
    #endregion
}
