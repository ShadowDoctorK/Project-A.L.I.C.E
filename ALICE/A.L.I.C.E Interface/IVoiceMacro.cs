using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using vmAPI;

namespace ALICE_Interface
{
    public static class IVoiceMacro
    {
        /// <summary>
        /// Private Instance of the Interface that allows access to your ID, and other properites.
        /// It is used in the simple methods below to reduce the need to pass prams.
        /// </summary>
        private static VoiceMacro API = new VoiceMacro();

        /// <summary>
        /// Static Instance of the Active Profile. Used to allow
        /// Query Commands and Check Commands by name for Macros.
        /// </summary>
        public static vmProfile Profile = new vmProfile();

        /// <summary>
        /// Private Static Instance of all the profiles currently loaded.
        /// Allows quick reference and for user checks.
        /// </summary>
        public static List<vmProfile> Profiles = new List<vmProfile>();

        #region vmCommand Methods
        /// <summary>
        /// Interface Method to add a item to Voice Macros Log.
        /// </summary>
        /// <param name="Text">The Text you wish to show in the Log.</param>
        /// <param name="C">(Color) The color you want the text to be. Default is Orange.</param>
        /// <param name="S">(Sign) Single Character Sign. Default "".</param>
        /// <param name="ST">(Status Text) shows in the Voice Macro Status Bar. Default "".</param>
        public static void WriteToLog(string Text, string C = null, string S = "ℙ", string ST = "")
        {
            vmCommand.AddLogEntry(Text, GetColor(C), API.ID, S, ST);
        }

        /// <summary>
        /// Will get the text for the target Global Variable.
        /// </summary>
        /// <param name="S">Global Variable Name.</param>
        /// <returns>Variable Value</returns>
        public static string GetText(string S)
        {
            string MethodName = "IVoiceMacro (Get Variable)";

            try
            {
                //Get Target Variables Value
                return vmCommand.GetVariable(S + "_g");
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "Variable: " + S);
            }

            //Default Return False.
            return null;
        }

        /// <summary>
        /// Will set the text for the target Global Variable.
        /// </summary>
        /// <param name="S">Global Variable Name.</param>
        /// <param name="V">Variable Value</param>
        public static void SetText(string S, string V)
        {
            string MethodName = "IVoiceMacro (Set Variable)";

            try
            {
                //Set Target Global Variable
                vmCommand.SetVariable(S + "_g", V);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "Variable: " + S + " | Value: " + V);
            }
        }

        /// <summary>
        /// Simple Check to see if the Current Profile Contains the target Command.
        /// </summary>
        /// <param name="GUID">The GUID of the Command.</param>
        /// <returns>true if exists, false if does not exist.</returns>
        public static bool CommandExists(string GUID)
        {
            //Check For An Active Profile, Return False If None Is Found.
            if (ActiveProfile() == "No Profile") { return false; }

            //Prepare String With The Active Profile GUID.
            //Example f9d3dbd6-034c-49a9-a649-deeba0654f02/0d84f818-c3ca-41c0-b076-708e3a7f0720
            GUID = ActiveProfile() + "/" + GUID;

            //Check For Command, Return True If Exists.
            if (vmCommand.CommandExists(GUID) != "")
            { return true; }

            //Does Not Exist, Return False.
            return false;
        }

        /// <summary>
        /// Simple Check to see if the Target Profile Contains the target Command.
        /// </summary>
        /// <param name="GUID">The GUID of the Command.</param>
        /// <param name="ProfileGUID">The GUID of the Profile.</param>
        /// <returns>true if exists, false if does not exist.</returns>
        public static bool CommandExists(string GUID, string ProfileGUID)
        {
            //Prepare String With The Active Profile GUID.
            //Example f9d3dbd6-034c-49a9-a649-deeba0654f02/0d84f818-c3ca-41c0-b076-708e3a7f0720
            GUID = ProfileGUID + "/" + GUID;

            //Check For Command, Return True If Exists.
            if (vmCommand.CommandExists(GUID) != "")
            { return true; }

            //Does Not Exist, Return False.
            return false;
        }

        /// <summary>
        /// Executes a command in the Active Profile by GUID if it exists.
        /// </summary>
        /// <param name="GUID">The Macros GUID</param>
        public static void CommandExecute(string GUID)
        {
            //Check For An Active Profile, Return If None Is Found.
            if (ActiveProfile() == "No Profile") { return; }

            //Prepare String With The Active Profile GUID.
            //Example f9d3dbd6-034c-49a9-a649-deeba0654f02/0d84f818-c3ca-41c0-b076-708e3a7f0720
            GUID = ActiveProfile() + "/" + GUID;

            //Execute Macro
            vmCommand.ExecuteMacro(GUID);
        }

        /// <summary>
        /// Executes a command from the Target Profile by GUID if it exists.
        /// </summary>
        /// <param name="GUID">The Macros GUID</param>
        public static void CommandExecute(string GUID, string ProfileGUID)
        {
            //Check For An Active Profile, Return If None Is Found.
            if (ActiveProfile() == "No Profile") { return; }

            //Prepare String With The Active Profile GUID.
            //Example f9d3dbd6-034c-49a9-a649-deeba0654f02/0d84f818-c3ca-41c0-b076-708e3a7f0720
            GUID = ActiveProfile() + "/" + GUID;

            //Execute Macro
            vmCommand.ExecuteMacro(GUID);
        }

        /// <summary>
        /// Executes a command by name if it exists in the Active Profile.
        /// </summary>
        /// <param name="">Macro Name</param>
        /// <param name="B">Set to "true" to execute by name.</param>
        public static void CommandExecute(string Name, bool B)
        {
            string MethodName = "IVoiceMacro (Execute Command)";

            //Check Name Is Not Null
            if (Name == null) { return; }

            //Get Command GUID
            string GUID = CommandGUID(Name);

            //Debug Logger
            Logger.DebugLine(MethodName, "Executing: " + GUID, Logger.Blue);

            try
            {
                //GUID Is Null If The Command Doesn't Exist.
                if (GUID != null)
                {
                    //Execute Command
                    CommandExecute(GUID);
                }
            }
            catch (Exception) { }            
        }

        /// <summary>
        /// Get the GUID of the Acive Profile.
        /// </summary>
        /// <returns>GUID of the Active Profile, or "No Profile" is none is selected.</returns>
        public static string ActiveProfile()
        {
            //Example: f9d3dbd6-034c-49a9-a649-deeba0654001
            //Example: No Profile
            return vmCommand.GetActiveProfileGUID();
        }

        /// <summary>
        /// Checks if the Active Profile's Name Contains the target string.
        /// </summary>
        /// <param name="Name">String you want to check.</param>
        /// <returns>True or False.</returns>
        public static bool CheckAcivteProfile(string Name)
        {
            string ProfileGUID = ActiveProfile();

            if (ProfileGUID != "No Profile")
            {
                foreach (var Profile in Profiles)
                {
                    if (Profile.ProfileName.Contains(Name) && Profile.GUID == ProfileGUID)
                    { return true; }
                }
            }

            return false;
        }

        /// <summary>
        /// Function to check for a command by name in the Active Profile.
        /// </summary>
        /// <param name="Name">Commands "Name" which is the Recocnition/Acivation Text.</param>
        /// <param name="B">Set to "true" to execute by name.</param>
        /// <returns>True if found, False if not found.</returns>
        public static bool CommandExists(string Name, bool B)
        {
            string MethodName = "IVoiceMacro (Command Exists)";

            try
            {
                if (Profile.GUID == null || Profile.GUID != ActiveProfile())
                {
                    Profile = GetProfile(ActiveProfile());
                }

                //Debug Logger
                Logger.DebugLine(MethodName, "Target Command: " + Name, Logger.Blue);

                //Debug Logger
                Logger.DebugLine(MethodName, "Total Commands: " + Profile.Commands.Count(), Logger.Blue);

                //Search For Command By Name
                var Temp = Profile.Commands.FirstOrDefault(X => X.RecocnitionText == Name);

                //Debug Logger
                Logger.DebugLine(MethodName, "Target GUID: " + Temp.GUID, Logger.Blue);

                //Check If We Found A Match, Return True.
                if (string.IsNullOrWhiteSpace(Temp.GUID) == false) { return true; }

                //No Match, Return False.
                return false;
            }
            catch (Exception ex)
            {
                //Debug Logger
                Logger.Exception(MethodName, "Exception: " + ex);

                //Exception Occured, Return False
                return false;
            }
        }

        /// <summary>
        /// Checks Command Exists, Then returns the GUID of the Command.
        /// </summary>
        /// <param name="Name">Commands "Name" which is the Recocnition/Acivation Text.</param>
        /// <returns>Null if not found, GUID as string if found.</returns>
        private static string CommandGUID(string Name)
        {
            try
            {
                //Check Command Exists
                if (CommandExists(Name, true))
                {
                    //Get Command
                    var Temp = Profile.Commands.FirstOrDefault(X => X.RecocnitionText == Name);

                    //Return GUID
                    return Temp.GUID;
                }
            }
            catch (Exception) { }

            //Default Return Null
            return null;
        }

        /// <summary>
        /// Private Function to return the desired Color.
        /// </summary>
        /// <param name="C">Color as a String</param>
        /// <returns>The Desired Color if exists. Orange if does not exist.</returns>
        private static Color GetColor(string C)
        {
            if (IPlatform.Colors.ContainsKey(C))
            {
                return IPlatform.Colors[C];
            }
            else
            {
                return IPlatform.Colors["Orange"];
            }
        }
        #endregion

        #region vmInterface Methods
        /// <summary>
        /// Searches Profiles for the Target Profile.
        /// </summary>
        /// <param name="GUID">Profiles GUID</param>
        /// <returns>Blank Profile if not found, Target Profile if found.</returns>
        public static vmProfile GetProfile(string GUID)
        {
            string MethodName = "IVoiceMacro (Get Profile)";

            //Debug Logger
            Logger.DebugLine(MethodName, "Total Profiles: " + Profiles.Count(), Logger.Blue);

            //Search Profiles For GUID
            vmProfile Temp = Profiles.SingleOrDefault(X => X.GUID == GUID);

            //Debug Logger
            Logger.DebugLine(MethodName, "Target Profile: " + Temp.ProfileName, Logger.Blue);

            //Return Profile
            return Temp;
        }
        #endregion
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
            get => "Project A.L.I.C.E: Command Interface - " + IPlatform.Version;
        }

        /// <summary>
        /// Description for your plugin.
        /// </summary>
        public string Description
        {
            get => "Allows Sending Requests To The Plugin To Perform Actions Based On The Game State. " +
                   "More Information Can Be Found On The Wiki Page Located Here: " +
                   "https://github.com/ShadowDoctorK/Project-A.L.I.C.E/wiki";
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
                //Set Platform
                IPlatform.Interface = IPlatform.Interfaces.VoiceMacro;

                //Populate IVoiceMacro.Profiles Property
                IVoiceMacro.Profiles = vmCommand.GetProfiles();

                if (IVoiceMacro.Profiles == null)
                {
                    Logger.Error(MethodName, "No Profiles Detected!", Logger.Red);
                    Logger.Error(MethodName, "Load An A.L.I.C.E Compatible Profile A Restart", Logger.Red);
                    return;
                }

                //Custom Initialization Items
                PlugIn.Respond = PlugIn.Output.TTS;
                Paths.CreateDir();
                Paths.Load_UpdateBindsFile();

                //Initialize Plugin
                Thread Plugin =
                new Thread((ThreadStart)(() =>
                {
                    try { PlugIn.Initialize(true, true, true); }
                    catch (Exception) { Logger.Error(MethodName, "Something Went Wrong While Initializing The Plugin...", Logger.Red); }
                }))
                { IsBackground = true }; Plugin.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Start-up Hamsters Reported An Issue: " + ex);
                Logger.Exception(MethodName, "Initialization Exception: " + ex);
            }
        }

        /// <summary>
        /// This is invoked when you use the SendToPlugin action from your Voice Macro Profile.
        /// </summary>
        /// <param name="Param1">(ICommands) Item 1 Passed from Voice Macro.</param>
        /// <param name="Param2">(ISynthesizer) Item 2 Passed from Voice Macro.</param>
        /// <param name="Param3">(Unallocated) Item 3 Passed from Voice Macro.</param>
        /// <param name="Synchron">(Unused) Wait to complete.</param>
        void vmInterface.ReceiveParams(string Param1, string Param2, string Param3, bool Synchron)
        {
            //Pass To ICommands
            if (Param1 != null || Param1 != "")
            {
                //Debug Logger
                Logger.DebugLine(MethodName, "(" + IPlatform.Interface.ToString() + ") Sent Command: " + Param1, Logger.Blue);

                //Pass Command
                ICommands.Invoke(Param1);
            }
            //Pass to ISynthesizer
            else if (Param2 != null || Param2 != "")
            {

            }
            //Unallocated
            else if (Param3 != null || Param3 != "")
            {

            }
        }

        //This is invoked when a profile is switched
        void vmInterface.ProfileSwitched(string ProfileGUID, string ProfileName)
        {
            IVoiceMacro.Profile = IVoiceMacro.GetProfile(ProfileGUID);

            //Debug Logger
            Logger.DebugLine(MethodName, "Target GUID: " + ProfileGUID, Logger.Blue);
            Logger.DebugLine(MethodName, "Target Profile: " + IVoiceMacro.Profile.ProfileName, Logger.Blue);
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
