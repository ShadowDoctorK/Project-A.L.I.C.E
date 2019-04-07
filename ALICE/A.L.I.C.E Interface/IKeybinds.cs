using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;
using ALICE_Internal;
using ALICE_Interface;
using ALICE_Synthesizer;
using System.Threading;
using ALICE_Settings;

namespace ALICE_Keybinds
{
	public static class IKeyboard
	{
		/// <summary>
		/// Instance of the loaded binds file.
		/// </summary>
		private static XmlDocument AliceBinds { get; set; }

		/// <summary>
		/// Collection of the binds extracted from the .binds files (Xml Document).
		/// </summary>
		private static Dictionary<string, Bind> Keybinds;

		/// <summary>
		/// This function allows you to control the keypress' in a single place
		/// </summary>
		/// <param name="K">(Key) This is the Keybind you wish to activate.</param>
		/// <param name="S">(Sleep) Adds to the timeout in milliseconds after the keypress.</param>
		/// <param name="D">(Delay) If Set to False The Users Panel Delay Will Not Be Counted.</param>
		/// <param name="T">(Time) The Time The Keys Are Held.</param>
		public static void Press(string K, int S = 0, string D = null, int T = 50)
		{
			string MethodName = "Press Key";

			try
			{
				//Select Keypress Method Based On Interface
				switch (IPlatform.Interface)
				{
					case IPlatform.Interfaces.Internal:
						Logger.Log(MethodName, "Internal Operations: " + K, Logger.Yellow);
						return;

					case IPlatform.Interfaces.VoiceAttack:
						IPlatform.ExecuteCommand("(A.L.I.C.E) Keybind: " + K, true);
						return;

					case IPlatform.Interfaces.VoiceMacro:
						IPlatform.ExecuteCommand("(A.L.I.C.E) Keybind: " + K, true);
						return;

					default:
						break;
				}
			}
			catch (Exception ex)
			{
				Logger.Exception(MethodName, "Exception: " + ex);
				return;
			}
			finally
			{
				#region Sleep After KeyPress
				if (D == IKey.DelayPanel) { S = S + ISettings.OffsetPanels; }
				if (D == IKey.DelayFireGroup) { S = S + ISettings.OffsetFireGroups; }
				if (D == IKey.DelayPower) { S = S + ISettings.OffsetPips; }
				if (D == IKey.DelayThrottle) { S = S + ISettings.OffsetThrottle; }
				Thread.Sleep(S);
				#endregion
			}

			#region Write To Log: Keybind Not Found
			IPlatform.WriteToInterface("A.L.I.C.E (Internal Error): Key Action: " + K + " Was Not Found.", "Red");
			#endregion
		}

		/// <summary>
		/// Function to load keybinds based on the interface that started the project.
		/// </summary>
		public static void LoadKeybinds()
		{
			//Logger
			IPlatform.WriteToInterface("A.L.I.C.E: Targeting Keybinds File: " + ISettings.User.BindsFile, "Purple");

			//Load Target Binds File
			AliceBinds = GetBindsFile(ISettings.User.BindsFile);

			//Update Binds
			GetGameBinds();

			//Load Keybinds
			switch (IPlatform.Interface)
			{
				case IPlatform.Interfaces.Internal:
					break;
				case IPlatform.Interfaces.VoiceAttack:
					VoiceAttack();
					break;
				case IPlatform.Interfaces.VoiceMacro:
					VoiceMacro();
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Function to format and load keybinds into Voice Attack as variables.
		/// </summary>
		private static void VoiceAttack()
		{
			string MethodName = "Voice Attack (Load Keybinds)";

			bool AlertAudio = false;

			//Loops though the Binds Collection Building Virtual Keybinds.
			foreach (KeyValuePair<string, Bind> bind in Keybinds)
			{
				try
				{
					//Checks First Key Isn't Default or Null.
					if (bind.Value.Key1 != "" && bind.Value.Key1 != null)
					{
						if (bind.Value.Primary == true)
						{
							Logger.Log(MethodName, bind.Key + "Is Using The Primary Column's (Users) Keybind Because No Useable Keybind Was Set Up In The Secondary (Alice) Column", Logger.Yellow);
						}

						//Virtual Keybinds For Voice Attack Are Formatted With "[" & "]" To Encapsulate The Key.
						//Example "Key_LeftControl" + "Key_K" In The Below Function Would Be Set As A Text 
						//Variable Equal To "[162][75]". Note There Is No Space Between Them. A Space Is
						//Another Way To Indicate "Key_Space". The Keys Are Pressed From Left To Right
						//And Released Right To Left. So "L Ctrl" (down), "K" (down), (pause for duration),
						//"K" (release), "L Ctrl" (release).

						string Variable = "[" + IKey.VirtualNumber[bind.Value.Key1] + "]";
						if (bind.Value.Key2 != null && bind.Value.Key2 != "") { Variable = Variable + "[" + IKey.VirtualNumber[bind.Value.Key2] + "]"; }
						if (bind.Value.Key3 != null && bind.Value.Key3 != "") { Variable = Variable + "[" + IKey.VirtualNumber[bind.Value.Key3] + "]"; }
						if (bind.Value.Key4 != null && bind.Value.Key4 != "") { Variable = Variable + "[" + IKey.VirtualNumber[bind.Value.Key4] + "]"; }

						//Debug Logger
						if (PlugIn.DebugMode == true)
						{ IPlatform.WriteToInterface("A.L.I.C.E: " + bind.Key.ToString() + " Virtual Keys = " + Variable, "Green"); }

						//Pass Key To Voice Attack Via The Platform Interface.
						IPlatform.SetText(bind.Key.ToString(), Variable);
					}
					else
					{
						IPlatform.WriteToInterface("A.L.I.C.E: No Keybind Detected For \"" + bind.Key.ToString(), "Red");
						AlertAudio = true;
					}
				}
				catch (KeyNotFoundException)
				{
					Logger.Exception(MethodName, "Propblem Occured Loading " + bind.Key);

					AlertAudio = true;

					if (bind.Value.Key1 != null && bind.Value.Key1 != "")
					{
						if (IKey.VirtualNumber.ContainsKey(bind.Value.Key1) == false)
						{
							Logger.Exception(MethodName, bind.Value.Key1.Replace("Key_", "") + " Was Not Converted. Try Using A Different Key Please.");
						}
					}
					if (bind.Value.Key2 != null && bind.Value.Key2 != "")
					{
						if (IKey.VirtualNumber.ContainsKey(bind.Value.Key2) == false)
						{
							Logger.Exception(MethodName, bind.Value.Key2.Replace("Key_", "") + " Was Not Converted. Try Using A Different Key Please.");
						}
					}
					if (bind.Value.Key3 != null && bind.Value.Key3 != "")
					{
						if (IKey.VirtualNumber.ContainsKey(bind.Value.Key3) == false)
						{
							Logger.Exception(MethodName, bind.Value.Key3.Replace("Key_", "") + " Was Not Converted. Try Using A Different Key Please.");
						}
					}
					if (bind.Value.Key4 != null && bind.Value.Key4 != "")
					{
						if (IKey.VirtualNumber.ContainsKey(bind.Value.Key4) == false)
						{
							Logger.Exception(MethodName, bind.Value.Key4.Replace("Key_", "") + " Was Not Converted. Try Using A Different Key Please.");
						}
					}
				}
				catch (Exception ex)
				{
					Logger.Exception(MethodName, "Exception: " + ex);
					Logger.Exception(MethodName, "Propblem Occured Loading " + bind.Key);
				}
			}

			#region Audio: Missing Keybinds
			if (AlertAudio == true)
			{
				string Line = "I Detected Missing Keybinds, This Will Limit Functions Requiring Those Keybinds. " +
					"I've Written Them To The Log. Please Add Them In Game And I Will Automatically Detect Them.";

				#region Audio
				if (PlugIn.Audio == "TTS")
				{
					Speech.Speak(Line, true);
				}
				else if (PlugIn.Audio == "File") { }
				else if (PlugIn.Audio == "External") { }
				#endregion
			}
			#endregion

			IPlatform.WriteToInterface("A.L.I.C.E: Loading Keybinds Complete...", "Purple");
		}

		/// <summary>
		/// Function to format and load keybinds in to Voice Macro as variables.
		/// </summary>
		private static void VoiceMacro()
		{
			string MethodName = "Voice Macro (Load Keybinds)";

			bool AlertAudio = false;

			//Loops though the Binds Collection Building Virtual Keybinds.
			foreach (KeyValuePair<string, Bind> bind in Keybinds)
			{
				try
				{
					//Checks First Key Isn't Default or Null.
					if (bind.Value.Key1 != "" && bind.Value.Key1 != null)
					{
						if (bind.Value.Primary == true)
						{
							Logger.Log(MethodName, bind.Key + " Is Using The Primary Column's (Users) Keybind Because No Useable Keybind Was Set Up In The Secondary (Alice) Column", Logger.Yellow);
						}

						string P = IKey.VirtualString[bind.Value.Key1] + "_D;";
						string R = IKey.VirtualString[bind.Value.Key1] + "_U;";

						if (bind.Value.Key2 != null && bind.Value.Key2 != "")
						{
							P = P + IKey.VirtualString[bind.Value.Key2] + "_D;";
							R = IKey.VirtualString[bind.Value.Key2] + "_U;" + R;
						}

						if (bind.Value.Key3 != null && bind.Value.Key3 != "")
						{
							P = P + IKey.VirtualString[bind.Value.Key3] + "_D;";
							R = IKey.VirtualString[bind.Value.Key3] + "_U;" + R;
						}

						if (bind.Value.Key4 != null && bind.Value.Key4 != "")
						{
							P = P + IKey.VirtualString[bind.Value.Key4] + "_D;";
							R = IKey.VirtualString[bind.Value.Key4] + "_U;" + R;
						}

						Logger.DebugLine(MethodName, bind.Key.ToString() + " Release : " + R, Logger.Blue);
						Logger.DebugLine(MethodName, bind.Key.ToString() + " Press   : " + P, Logger.Blue);

						//Pass Key To Voice Macro Via The Platform Interface.
						IPlatform.SetText(bind.Key.ToString() + "_Press", P);
						IPlatform.SetText(bind.Key.ToString() + "_Release", R);
					}
					else
					{
						IPlatform.WriteToInterface("A.L.I.C.E: No Keybind Detected For \"" + bind.Key.ToString(), "Red");
						AlertAudio = true;
					}
				}
				catch (KeyNotFoundException)
				{
					Logger.Exception(MethodName, "Propblem Occured Loading " + bind.Key);

					AlertAudio = true;

					if (bind.Value.Key1 != null && bind.Value.Key1 != "")
					{
						if (IKey.VirtualNumber.ContainsKey(bind.Value.Key1) == false)
						{
							Logger.Exception(MethodName, bind.Value.Key1.Replace("Key_", "") + " Was Not Converted. Try Using A Different Key Please.");
						}
					}
					if (bind.Value.Key2 != null && bind.Value.Key2 != "")
					{
						if (IKey.VirtualNumber.ContainsKey(bind.Value.Key2) == false)
						{
							Logger.Exception(MethodName, bind.Value.Key2.Replace("Key_", "") + " Was Not Converted. Try Using A Different Key Please.");
						}
					}
					if (bind.Value.Key3 != null && bind.Value.Key3 != "")
					{
						if (IKey.VirtualNumber.ContainsKey(bind.Value.Key3) == false)
						{
							Logger.Exception(MethodName, bind.Value.Key3.Replace("Key_", "") + " Was Not Converted. Try Using A Different Key Please.");
						}
					}
					if (bind.Value.Key4 != null && bind.Value.Key4 != "")
					{
						if (IKey.VirtualNumber.ContainsKey(bind.Value.Key4) == false)
						{
							Logger.Exception(MethodName, bind.Value.Key4.Replace("Key_", "") + " Was Not Converted. Try Using A Different Key Please.");
						}
					}
				}
				catch (Exception ex)
				{
					Logger.Exception(MethodName, "Exception: " + ex);
					Logger.Exception(MethodName, "Propblem Occured Loading " + bind.Key);
				}
			}

			#region Audio: Missing Keybinds
			if (AlertAudio == true)
			{
				string Line = "I Detected Missing Keybinds, I've Written Them To The Log.";

				#region Audio
				if (PlugIn.Audio == "TTS")
				{
					Speech.Speak(Line, true);
				}
				else if (PlugIn.Audio == "File") { }
				else if (PlugIn.Audio == "External") { }
				#endregion
			}
			#endregion
		}

		/// <summary>
		/// Fucntion to build and update "Keybinds" which is a Dictionary of Keybind controls from the Games Binds File.
		/// </summary>
		private static void GetGameBinds()
		{
			Keybinds = new Dictionary<string, Bind>()
			{
				#region Flight Rotation
				{ "Yaw_Left", GetBind("YawLeftButton") },
				{ "Yaw_Right", GetBind("YawRightButton") },
				{ "Roll_Left", GetBind("RollLeftButton") },
				{ "Roll_Right", GetBind("SetSpeedZero") },
				{ "Pitch_Up", GetBind("PitchUpButton") },
				{ "Pitch_Down", GetBind("PitchDownButton") },
				#endregion

				#region Flight Thrust
				{ "Thrust_Left", GetBind("LeftThrustButton") },
				{ "Thrust_Right", GetBind("RightThrustButton") },
				{ "Thrust_Up", GetBind("UpThrustButton") },
				{ "Thrust_Down", GetBind("DownThrustButton") },
				{ "Thrust_Forward", GetBind("ForwardThrustButton") },
				{ "Thrust_Backward", GetBind("BackwardThrustButton") },
				#endregion

				#region Flight Throttle
				{ "Forward_Only_Throttle_Reverse", GetBind("ToggleReverseThrottleInput") },
				{ "Increase_Throttle", GetBind("ForwardKey") },
				{ "Decrease_Throttle", GetBind("BackwardKey") },
				{ "Set_Speed_To_-100", GetBind("SetSpeedMinus100") },
				{ "Set_Speed_To_-75", GetBind("SetSpeedMinus75") },
				{ "Set_Speed_To_-50", GetBind("SetSpeedMinus50") },
				{ "Set_Speed_To_-25", GetBind("SetSpeedMinus25") },
				{ "Set_Speed_To_0", GetBind("SetSpeedZero") },
				{ "Set_Speed_To_25", GetBind("SetSpeed25") },
				{ "Set_Speed_To_50", GetBind("SetSpeed50") },
				{ "Set_Speed_To_75", GetBind("SetSpeed75") },
				{ "Set_Speed_To_100", GetBind("SetSpeed100") },
				#endregion

				#region Flight Miscellaneous
				{ "Toggle_Flight_Assist", GetBind("ToggleFlightAssist") },
				{ "Engine_Boost", GetBind("UseBoostJuice") },
				{ "Toggle_Frame_Shift_Drive", GetBind("HyperSuperCombination") },
				{ "Supercruise_Jump", GetBind("Supercruise") },
				{ "Hyperspace_Jump", GetBind("Hyperspace") },
				{ "Toggle_Orbit_Lines", GetBind("OrbitLinesToggle") },
				#endregion

				#region Targeting
				{ "Select_Target_Ahead", GetBind("SelectTarget") },
				{ "Cycle_Next_Target", GetBind("CycleNextTarget") },
				{ "Cycle_Previous_Target", GetBind("CyclePreviousTarget") },
				{ "Select_Highest_Threat", GetBind("SelectHighestThreat") },
				{ "Cycle_Next_Hostile_Target", GetBind("CycleNextHostileTarget") },
				{ "Cycle_Previous_Hostile_Target", GetBind("CyclePreviousHostileTarget") },
				{ "Target_Wingman_1", GetBind("TargetWingman0") },
				{ "Target_Wingman_2", GetBind("TargetWingman1") },
				{ "Target_Wingman_3", GetBind("TargetWingman2") },
				{ "Select_Wingmans_Target", GetBind("SelectTargetsTarget") },
				{ "Wingman_Nav-Lock", GetBind("WingNavLock") },
				{ "Cycle_Next_Subsystem", GetBind("CycleNextSubsystem") },
				{ "Cycle_Previous_Subsystem", GetBind("CyclePreviousSubsystem") },
				{ "Target_Next_System_In_Route", GetBind("TargetNextRouteSystem") },
				#endregion

				#region Weapons
				{ "Primary_Fire", GetBind("PrimaryFire") },
				{ "Secondary_Fire", GetBind("SecondaryFire") },
				{ "Cycle_Next_Fire_Group", GetBind("CycleFireGroupNext") },
				{ "Cycle_Previous_Fire_Group", GetBind("CycleFireGroupPrevious") },
				{ "Deploy_Hardpoints", GetBind("DeployHardpointToggle") },
				#endregion

				#region Cooling
				{ "Silent_Running", GetBind("ToggleButtonUpInput") },
				{ "Deploy_HeatSink", GetBind("DeployHeatSink") },
				#endregion

				#region Miscellaneous
				{ "Ship_Lights", GetBind("ShipSpotLightToggle") },
				{ "Increase_Sensor_Zoom", GetBind("RadarIncreaseRange") },
				{ "Decrease_Sensor_Zoom", GetBind("RadarDecreaseRange") },
				{ "Divert_Power_To_Engines", GetBind("IncreaseEnginesPower") },
				{ "Divert_Power_To_Weapons", GetBind("IncreaseWeaponsPower") },
				{ "Divert_Power_To_Systems", GetBind("IncreaseSystemsPower") },
				{ "Balance_Power_Distribution", GetBind("ResetPowerDistribution") },
				{ "Reset_HMD_Orientation", GetBind("HMDReset") },
				{ "Cargo_Scoop", GetBind("ToggleCargoScoop") },
				{ "Jettison_All_Cargo", GetBind("EjectAllCargo") },
				{ "Landing_Gear", GetBind("LandingGearToggle") },
				{ "Use_Shield_Cell", GetBind("UseShieldCell") },
				{ "Use_Chaff_Launcher", GetBind("FireChaffLauncher") },
				{ "Charge_ECM", GetBind("ChargeECM") },
				{ "Weapon_Color", GetBind("WeaponColourToggle") },
				{ "Engine_Color", GetBind("EngineColourToggle") },
				#endregion

				#region Mode Switches
				{ "Target_Panel", GetBind("FocusLeftPanel") },
				{ "Comms_Panel", GetBind("FocusCommsPanel") },
				{ "Quick_Comms", GetBind("QuickCommsPanel") },
				{ "Role_Panel", GetBind("FocusRadarPanel") },
				{ "Systems_Panel", GetBind("FocusRightPanel") },
				{ "Open_Galaxy_Map", GetBind("GalaxyMapOpen") },
				{ "Open_System_Map", GetBind("SystemMapOpen") },
				{ "Show_CQB_Score_Screen", GetBind("ShowPGScoreSummaryInput") },
				{ "Head_Look_Toggle", GetBind("HeadLookToggle") },
				{ "Game_Menu", GetBind("Pause") },
				{ "Friends_Menu", GetBind("FriendsMenu") },
				#endregion

				#region Interface Mode
				{ "UI_Panel_Up", GetBind("UI_Up") },
				{ "UI_Panel_Down", GetBind("UI_Down") },
				{ "UI_Panel_Left", GetBind("UI_Left") },
				{ "UI_Panel_Right", GetBind("UI_Right") },
				{ "UI_Panel_Select", GetBind("UI_Select") },
				{ "UI_Back", GetBind("UI_Back") },
				{ "Next_Panel_Tab", GetBind("CycleNextPanel") },
				{ "Previous_Panel_Tab", GetBind("CyclePreviousPanel") },
				#endregion

				#region Driving Miscellaneous (SRV)
				{ "SRV_Jettison_All_Cargo", GetBind("EjectAllCargo_Buggy") },
				{ "Recall_Dismiss_Ship", GetBind("RecallDismissShip") },
				#endregion

				#region Fighter Orders
				{ "Recall_Fighter", GetBind("OrderRequestDock") },
				{ "Defend", GetBind("OrderDefensiveBehaviour") },
				{ "Engage_At_Will", GetBind("OrderAggressiveBehaviour") },
				{ "Attack_Target", GetBind("OrderFocusTarget") },
				{ "Maintain_Formation", GetBind("OrderHoldFire") },
				{ "Hold_Position", GetBind("OrderHoldPosition") },
				{ "Follow_Me", GetBind("OrderFollow") },
				{ "Open_Orders", GetBind("OpenOrders") },
				#endregion

				#region Galnet Audio
				{ "Galnet_Play", GetBind("GalnetAudio_Play_Pause") },
				{ "Galnet_Skip_Forward", GetBind("GalnetAudio_SkipForward") },
				{ "Galnet_Skip_Backward", GetBind("GalnetAudio_SkipBackward") },
				{ "Galnet_Clear_Queue", GetBind("GalnetAudio_ClearQueue") },
				#endregion

				#region 3.4 Added Binds
				{ "Night_Vision_Toggle", GetBind("NightVisionToggle") },
				{ "Open_Discovery", GetBind("OpenCodexGoToDiscovery") },
				{ "Swtich_HUD_Mode", GetBind("PlayerHUDModeToggle") },
				{ "Cycle_Next_Page", GetBind("CycleNextPage") },
				{ "Cycle_Previous_Page", GetBind("CyclePreviousPage") },
				{ "Enter_FSS_Mode", GetBind("ExplorationFSSEnter") },
				{ "Leave_FSS_Mode", GetBind("ExplorationFSSQuit") }
				#endregion
			};
		}

		/// <summary>
		/// Loads and returns the target binds file by name.
		/// </summary>
		/// <param name="F">(File Name) The name of the target file.</param>
		/// <returns></returns>
		private static XmlDocument GetBindsFile(string F)
		{
			string MethodName = "Keybinds (Load)";

			//Create Full File Name.
			string Path = Paths.Binds_Location + F;

			//Check File Exists
			if (File.Exists(Path) == false)
			{
				//Doesn't Exist, Load Default Alice Binds File
				Logger.Error(MethodName, F + "Does Not Exist, Loading A.L.I.C.E Profile.3.0.binds", Logger.Red);
				Path = Paths.ALICE_BindsPath;
			}

			//Load Target Keybinds File
			XmlDocument file; using (XmlReader Reader = XmlReader.Create(Path))
			{
				file = new XmlDocument();
				file.Load(Path);
			}

			//Return Loaded File
			return file;
		}

		/// <summary>
		/// Function used to search the loaded bind file for the target bind. This function is used by during the construction of 
		/// the new Keybinds dictionary in the GetGameBinds() method.
		/// </summary>
		/// <param name="XMLElementName"></param>
		/// <returns></returns>
		private static Bind GetBind(string XMLElementName)
		{
			string MethodName = "Get Bind";

			Bind bind = new Bind();

			try
			{
				foreach (XmlNode node in AliceBinds.DocumentElement)
				{
					if (node.Name == XMLElementName)
					{
						if ( //Check Secondary Bind
							node.HasChildNodes == true &&                                   //Has Child Node Means Its a Keybind
							node.ChildNodes[1].Name == "Secondary" &&                       //Target Secondary Bind
							node.ChildNodes[1].Attributes["Device"].Value == "Keyboard" &&  //Only Use If Its A Keyboard Bind
							node.ChildNodes[1].Attributes["Key"].Value != "")               //Check Secondary Keybind Is Set
						{

							//Record Bind Name
							bind.Name = XMLElementName;
							List<string> Keys = new List<string>(new string[5])
							{
								[0] = node.ChildNodes[1].Attributes[1].Value
							};

							foreach (XmlNode modifier in node.ChildNodes[1])
							{
								if (Keys[2] == null) { Keys[1] = modifier.Attributes[1].Value; }
								else if (Keys[3] == null) { Keys[2] = modifier.Attributes[1].Value; }
								else if (Keys[4] == null) { Keys[3] = modifier.Attributes[1].Value; }
								else { IPlatform.WriteToInterface("A.L.I.C.E: (" + node.Name + ") More Than 4 Keys To Assign... Please Use Less Keys", "Red"); }
							}

							for (int i = Keys.Count - 1; i >= 0; i--)
							{
								if (bind.Key1 == null) { bind.Key1 = Keys[i]; }
								else if (bind.Key2 == null) { bind.Key2 = Keys[i]; }
								else if (bind.Key3 == null) { bind.Key3 = Keys[i]; }
								else if (bind.Key4 == null) { bind.Key4 = Keys[i]; }
							}
						}
						else if ( //Secondary Bind Was Not Set, Check Primary
							node.HasChildNodes == true &&                                   //Has Child Node Means Its a Keybind
							node.ChildNodes[0].Name == "Primary" &&                         //Target Primary Bind
							node.ChildNodes[0].Attributes["Device"].Value == "Keyboard" &&  //Only Use If Its A Keyboard Bind
							node.ChildNodes[0].Attributes["Key"].Value != "")               //Check Primary Keybind Is Set
						{
							//Mark Bind As A Primary Bind
							bind.Primary = true;

							//Record Bind Name
							bind.Name = XMLElementName;
							List<string> Keys = new List<string>(new string[5])
							{
								[0] = node.ChildNodes[0].Attributes[1].Value
							};

							foreach (XmlNode modifier in node.ChildNodes[0])
							{
								if (Keys[2] == null) { Keys[1] = modifier.Attributes[1].Value; }
								else if (Keys[3] == null) { Keys[2] = modifier.Attributes[1].Value; }
								else if (Keys[4] == null) { Keys[3] = modifier.Attributes[1].Value; }
								else { IPlatform.WriteToInterface("A.L.I.C.E: (" + node.Name + ") More Than 4 Keys To Assign... Please Use Less Keys", "Red"); }
							}

							for (int i = Keys.Count - 1; i >= 0; i--)
							{
								if (bind.Key1 == null) { bind.Key1 = Keys[i]; }
								else if (bind.Key2 == null) { bind.Key2 = Keys[i]; }
								else if (bind.Key3 == null) { bind.Key3 = Keys[i]; }
								else if (bind.Key4 == null) { bind.Key4 = Keys[i]; }
							}
						}
						else
						{
							//IPlatform.WriteToInterface("A.L.I.C.E: (" + node.Name + ") Does Not Have A Secondary Keyboard Bind.", "Red");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Exception(MethodName, "Exception: " + ex);
				Logger.Exception(MethodName, "Problem Occured While Loading " + XMLElementName);
			}

			return bind;
		}

		/// <summary>
		/// Class defining the standard Bind object.
		/// </summary>
		public class Bind
		{
			public bool Primary = false;
			public string Name { get; set; }
			public string Key1 { get; set; }
			public string Key2 { get; set; }
			public string Key3 { get; set; }
			public string Key4 { get; set; }
		}
	}

	public static class IKey
	{
		#region Key Wrappers        

		//Constants used to allow a single source for calling string information related to
		//key calls. This also allows us to utilize Intelesense, Error Catching, and Debugging.

		#region Delays
		public const string DelayPanel = "Panel";
		public const string DelayFireGroup = "Firegroup";
		public const string DelayPower = "Power";
		public const string DelayThrottle = "Throttle";
		#endregion

		#region 02 - Flight Rotation
		public const string Yaw_Left = "Yaw_Left";
		public const string Yaw_Right = "Yaw_Right";
		public const string Roll_Left = "Roll_Left";
		public const string Roll_Right = "Roll_Right";
		public const string Pitch_Up = "Pitch_Up";
		public const string Pitch_Down = "Pitch_Down";
		#endregion

		#region 03 - Flight Thrust
		public const string Thrust_Left = "Thrust_Left";
		public const string Thrust_Right = "Thrust_Right";
		public const string Thrust_Up = "Thrust_Up";
		public const string Thrust_Up_Press = "Thrust_Up_Press";
		public const string Thrust_Up_Release = "Thrust_Up_Release";
		public const string Thrust_Down = "Thrust_Down";
		public const string Thrust_Forward = "Thrust_Forward";
		public const string Thrust_Backward = "Thrust_Backward";
		#endregion

		#region 05 -  Flight Throttle
		public const string Decrease_Throttle = "Decrease_Throttle";
		public const string Increase_Throttle = "Increase_Throttle";
		public const string Set_Speed_To_Minus_100 = "Set_Speed_To_-100";
		public const string Set_Speed_To_Minus_75 = "Set_Speed_To_-75";
		public const string Set_Speed_To_Minus_50 = "Set_Speed_To_-50";
		public const string Set_Speed_To_Minus_25 = "Set_Speed_To_-25";
		public const string Set_Speed_To_0 = "Set_Speed_To_0";
		public const string Set_Speed_To_25 = "Set_Speed_To_25";
		public const string Set_Speed_To_50 = "Set_Speed_To_50";
		public const string Set_Speed_To_75 = "Set_Speed_To_75";
		public const string Set_Speed_To_100 = "Set_Speed_To_100";
		#endregion

		#region 07 - Fligth Miscellaneous
		public const string Toggle_Flight_Assist = "Toggle_Flight_Assist";
		public const string Engine_Boost = "Engine_Boost";
		public const string Toggle_Frame_Shift_Drive = "Toggle_Frame_Shift_Drive";
		public const string Supercruise = "Supercruise";
		public const string Hyperspace_Jump = "Hyperspace_Jump";
		public const string Toggle_Orbit_Lines = "Toggle_Orbit_Lines";
		#endregion

		#region 08 - Targeting
		public const string Select_Target_Ahead = "Select_Target_Ahead";
		public const string Cycle_Next_Target = "Cycle_Next_Target";
		public const string Cycle_Previous_Ship = "Cycle_Previous_Ship";
		public const string Select_Hightest_Threat = "Select_Hightest_Threat";
		public const string Cycle_Next_Hostile_Target = "Cycle_Next_Hostile_Target";
		public const string Cycle_Previous_Hostile_Ship = "Cycle_Previous_Hostile_Ship";
		public const string Select_Wingman_1 = "Select_Wingman_1";
		public const string Select_Wingman_2 = "Select_Wingman_2";
		public const string Select_Wingman_3 = "Select_Wingman_3";
		public const string Select_Wingmans_Target = "Select_Wingmans_Target";
		public const string Wingman_NavLock = "Wingman_Nav-Lock";
		public const string Cycle_Next_Subsystem = "Cycle_Next_Subsystem";
		public const string Cycle_Previous_Subsystem = "Cycle_Previous_Subsystem";
		public const string Target_Next_System_In_Route = "Target_Next_System_In_Route";
		#endregion

		#region 09 - Weapons
		public const string Primary_Fire = "Primary_Fire";
		public const string Secondary_Fire = "Secondary_Fire";
		public const string Primary_Fire_Press = "Primary_Fire_Press";
		public const string Secondary_Fire_Press = "Secondary_Fire_Press";
		public const string Primary_Fire_Release = "Primary_Fire_Release";
		public const string Secondary_Fire_Release = "Secondary_Fire_Release";
		public const string Cycle_Next_Fire_Group = "Cycle_Next_Fire_Group";
		public const string Cycle_Previous_Fire_Group = "Cycle_Previous_Fire_Group";
		public const string Deploy_Hardpoints = "Deploy_Hardpoints";
		#endregion

		#region 10 - Cooling
		public const string Deploy_Heat_Sink = "Deploy_Heat_Sink";
		public const string Silent_Running = "Silent_Running";
		#endregion

		#region 11 - Miscellaneous
		public const string Ship_Lights = "Ship_Lights";
		public const string Increase_Sensor_Zoom = "Increase_Sensor_Zoom";
		public const string Decrease_Sensor_Zoom = "Decrease_Sensor_Zoom";
		public const string Divert_Power_To_Engines = "Divert_Power_To_Engines";
		public const string Divert_Power_To_Weapons = "Divert_Power_To_Weapons";
		public const string Divert_Power_To_Systems = "Divert_Power_To_Systems";
		public const string Balance_Power_Distribution = "Balance_Power_Distribution";
		public const string Reset_HMD_Orientation = "Reset_HMD_Orientation";
		public const string Cargo_Scoop = "Cargo_Scoop";
		public const string Landing_Gear = "Landing_Gear";
		public const string Use_Shield_Cell = "Use_Shield_Cell";
		public const string Use_Chaff_Launcher = "Use_Chaff_Launcher";
		public const string Charge_ECM = "Charge_ECM";
		#endregion

		#region 13 - Mode Switches
		public const string Target_Panel = "Target_Panel";
		public const string Comms_Panel = "Comms_Panel";
		public const string Quick_Comms = "Quick_Comms";
		public const string Role_Panel = "Role_Panel";
		public const string System_Panel = "System_Panel";
		public const string Open_Galaxy_Map = "Open_Galaxy_Map";
		public const string Open_System_Map = "Open_System_Map";
		public const string Game_Menu = "Game_Menu";
		public const string Friends_Menu = "Friends_Menu";
		#endregion

		#region 14 - Interface Mode
		public const string UI_Panel_Up = "UI_Panel_Up";
		public const string UI_Panel_Down = "UI_Panel_Down";
		public const string UI_Panel_Left = "UI_Panel_Left";
		public const string UI_Panel_Right = "UI_Panel_Right";
		public const string UI_Panel_Select = "UI_Panel_Select";
		public const string UI_Back = "UI_Back";
		public const string Next_Panel_Tab = "Next_Panel_Tab";
		public const string Previous_Panel_Tab = "Previous_Panel_Tab";
		public const string UI_Panel_Up_Press = "UI_Panel_Up_Press";
		public const string UI_Panel_Up_Release = "UI_Panel_Up_Release";
		public const string UI_Panel_Down_Press = "UI_Panel_Down_Press";
		public const string UI_Panel_Down_Release = "UI_Panel_Down_Release";
		#endregion

		#region 23 - Fighter
		public const string Attack_Target = "Attack_Target";
		public const string Defend = "Defend";
		public const string Engage_At_Will = "Engage_At_Will";
		public const string Follow_Me = "Follow_Me";
		public const string Hold_Position = "Hold_Position";
		public const string Maintain_Formation = "Maintain_Formation";
		public const string Recall_Fighter = "Recall_Fighter";
		#endregion

		#region 27 - Galnet Audio
		public const string Galnet_Play = "Galnet_Play";
		public const string Galnet_Skip_Forward = "Galnet_Skip_Forward";
		public const string Galnet_Skip_Backward = "Galnet_Skip_Backward";
		public const string Galnet_Clear_Queue = "Galnet_Clear_Queue";
		#endregion

		#region 3.4 Added Items
		public const string Night_Vision_Toggle = "Night_Vision_Toggle";
		public const string Open_Codex = "Open_Discovery";
		public const string Toggle_HUD_Mode = "Swtich_HUD_Mode";
		public const string Cycle_Next_Page = "Cycle_Next_Page";
		public const string Cycle_Previous_Page = "Cycle_Previous_Page";
		public const string FSS_Enter = "Enter_FSS_Mode";
		public const string FSS_Exit = "Leave_FSS_Mode";
		#endregion

		//End Regon: Key Wrappers
		#endregion

		/// <summary>
		/// Dictionary containing the Virtual Keys as Strings. Used to convert the game keycode to virtual.
		/// Key = Games Key Definition
		/// Value = Virtual Key as Int
		/// </summary>
		public static readonly Dictionary<string, int> VirtualNumber = new Dictionary<string, int>()
		{
			{ "Key_Backspace", 8 },
			{ "Key_Tab", 9 },
			{ "Key_Enter", 13 },
			{ "Key_Pause", 19 },
			{ "Key_CapsLock", 20 },
			{ "Key_Kana", 21 },
			{ "Key_Kanji", 25 },
			{ "Key_Escape", 27 },
			{ "Key_Convert", 28 },
			{ "Key_NoConvert", 29 },
			{ "Key_Space", 32 },
			{ "Key_PageUp", 33 },
			{ "Key_PageDown", 34 },
			{ "Key_End", 35 },
			{ "Key_Home", 36 },
			{ "Key_LeftArrow", 37 },
			{ "Key_UpArrow", 38 },
			{ "Key_RightArrow", 39 },
			{ "Key_DownArrow", 40 },
			{ "Key_SYSRQ", 44 },                    //Print Screen
			{ "Key_Insert", 45 },                   //Insert
			{ "Key_Delete", 46 },                   //Delete
			{ "Key_0", 48 },
			{ "Key_1", 49 },
			{ "Key_2", 50 },
			{ "Key_3", 51 },
			{ "Key_4", 52 },
			{ "Key_5", 53 },
			{ "Key_6", 54 },
			{ "Key_7", 55 },
			{ "Key_8", 56 },
			{ "Key_9", 57 },
			{ "Key_A", 65 },
			{ "Key_B", 66 },
			{ "Key_C", 67 },
			{ "Key_D", 68 },
			{ "Key_E", 69 },
			{ "Key_F", 70 },
			{ "Key_G", 71 },
			{ "Key_H", 72 },
			{ "Key_I", 73 },
			{ "Key_J", 74 },
			{ "Key_K", 75 },
			{ "Key_L", 76 },
			{ "Key_M", 77 },
			{ "Key_N", 78 },
			{ "Key_O", 79 },
			{ "Key_P", 80 },
			{ "Key_Q", 81 },
			{ "Key_R", 82 },
			{ "Key_S", 83 },
			{ "Key_T", 84 },
			{ "Key_U", 85 },
			{ "Key_V", 86 },
			{ "Key_W", 87 },
			{ "Key_X", 88 },
			{ "Key_Y", 89 },
			{ "Key_Z", 90 },
			{ "Key_LeftWin", 91 },
			{ "Key_RightWin", 92 },
			{ "Key_Apps", 93 },
			{ "Key_Sleep", 95 },
			{ "Key_Numpad_0", 96 },
			{ "Key_Numpad_1", 97 },
			{ "Key_Numpad_2", 98 },
			{ "Key_Numpad_3", 99 },
			{ "Key_Numpad_4", 100 },
			{ "Key_Numpad_5", 101 },
			{ "Key_Numpad_6", 102 },
			{ "Key_Numpad_7", 103 },
			{ "Key_Numpad_8", 104 },
			{ "Key_Numpad_9", 105 },
			{ "Key_Numpad_Multiply", 106 },
			{ "Key_Numpad_Add", 107 },
			{ "Key_Numpad_Subtract", 109 },
			{ "Key_Numpad_Decimal", 110 },
			{ "Key_Numpad_Comma", 110 },
			{ "Key_Numpad_Divide", 111 },
			{ "Key_Numpad_Enter", 156 },
			{ "Key_F1", 112 },
			{ "Key_F2", 113 },
			{ "Key_F3", 114 },
			{ "Key_F4", 115 },
			{ "Key_F5", 116 },
			{ "Key_F6", 117 },
			{ "Key_F7", 118 },
			{ "Key_F8", 119 },
			{ "Key_F9", 120 },
			{ "Key_F10", 121 },
			{ "Key_F11", 122 },
			{ "Key_F12", 123 },
			{ "Key_F13", 124 },
			{ "Key_F14", 125 },
			{ "Key_F15", 126 },
			{ "Key_F16", 127 },
			{ "Key_F17", 128 },
			{ "Key_F18", 129 },
			{ "Key_F19", 130 },
			{ "Key_F20", 131 },
			{ "Key_F21", 132 },
			{ "Key_F22", 133 },
			{ "Key_F23", 134 },
			{ "Key_F24", 135 },
			{ "Key_NumLock", 144 },
			{ "Key_ScrollLock", 145 },
			{ "Key_LeftShift", 160 },
			{ "Key_RightShift", 161 },
			{ "Key_LeftControl", 162 },
			{ "Key_RightControl", 163 },
			{ "Key_LeftAlt", 164 },
			{ "Key_RightAlt", 165 },
			{ "Key_WebBack", 166 },
			{ "Key_WebForward", 167 },
			{ "Key_WebRefresh", 168 },
			{ "Key_WebStop", 169 },
			{ "Key_WebSearch", 170 },
			{ "Key_WebFavourites", 171 },
			{ "Key_WebHome", 172 },
			{ "Key_Mute", 173 },
			{ "Key_VolumeDown", 174 },
			{ "Key_VolumeUp", 175 },
			{ "Key_NextTrack", 176 },
			{ "Key_PrevTrack", 177 },
			{ "Key_MediaStop", 178 },
			{ "Key_Stop", 178 },
			{ "Key_PlayPause", 179 },
			{ "Key_Mail", 180 },
			{ "Key_MediaSelect", 181 },
			{ "Key_SemiColon", 186 },
			{ "Key_Plus", 187 },
			{ "Key_Equals", 187 },
			{ "Key_Comma", 188 },
			{ "Key_Minus", 189 },
			{ "Key_Period", 190 },
			{ "Key_Slash", 191 },
			{ "Key_Grave", 192 },
			{ "Key_LeftBracket", 219 },
			{ "Key_BackSlash", 220 },
			{ "Key_RightBracket", 221 },
			{ "Key_Apostrophe", 222 },
			{ "Key_OEM_102", 226 },
			{ "Key_ä", 222 },
			{ "Key_ö", 192 },
			{ "Key_ü", 186 },
			{ "Key_ß", 219 },
			{ "Key_Acute", 221 },
			{ "Key_LessThan", 226 },
			{ "Key_Circumflex", 220 },
			{ "Key_Hash", 191 },
			{ "Key_Colon", 186 },
		};

		/// <summary>
		/// Dictionary containing the Virtual Keys as Strings. Used to convert the game keycode to virtual.
		/// Key = Games Key Definition
		/// Value = Virtual Key as Strings
		/// </summary>
		public static readonly Dictionary<string, string> VirtualString = new Dictionary<string, string>()
		{
			{ "Key_Backspace", "VK_BACK" },                     //008 - Backspace
			{ "Key_Tab", "VK_TAB" },                            //009 - Tab
			{ "Key_Enter", "VK_RETURN" },                       //013 - Enter
			{ "Key_Pause", "VK_PAUSE" },                        //019 - Pause
			{ "Key_CapsLock", "VK_CAPITAL" },                   //020 - Caps Lock
			{ "Key_Kana", "VK_KANA" },                          //021
			{ "Key_Kanji", "VK_KANJI" },                        //025
			{ "Key_Escape", "VK_ESCAPE" },                      //027 - Escape
			{ "Key_Convert", "VK_CONVERT" },                    //028
			{ "Key_NoConvert", "VK_NONCONVERT" },               //029 
			{ "Key_Space", "VK_SPACE" },                        //032 - Spacebar
			{ "Key_PageUp", "VK_PRIOR" },                       //033 - Page Up
			{ "Key_PageDown", "VK_NEXT" },                      //034 - Page Down
			{ "Key_End", "VK_END" },                            //035 - End
			{ "Key_Home", "VK_HOME" },                          //036 - Home
			{ "Key_LeftArrow", "VK_LEFT" },                     //037 - Left Arrow
			{ "Key_UpArrow", "VK_UP" },                         //038 - Up Arrow
			{ "Key_RightArrow", "VK_RIGHT" },                   //039 - Right Arrow
			{ "Key_DownArrow", "VK_DOWN" },                     //040 - Down Arrow
			{ "Key_SYSRQ", "VK_SNAPSHOT" },                     //044 - Print Screen
			{ "Key_Insert", "VK_INSERT" },                      //045 - Insert
			{ "Key_Delete", "VK_DELETE" },                      //046 - Delete
			{ "Key_0", "VK_0" },                                //048 - 0
			{ "Key_1", "VK_1" },                                //049 - 1
			{ "Key_2", "VK_2" },                                //050 - 2
			{ "Key_3", "VK_3" },                                //051 - 3
			{ "Key_4", "VK_4" },                                //052 - 4
			{ "Key_5", "VK_5" },                                //053 - 5
			{ "Key_6", "VK_6" },                                //054 - 6
			{ "Key_7", "VK_7" },                                //055 - 7
			{ "Key_8", "VK_8" },                                //056 - 8
			{ "Key_9", "VK_9" },                                //057 - 9
			{ "Key_A", "VK_A" },                                //065 - A
			{ "Key_B", "VK_B" },                                //066 - B
			{ "Key_C", "VK_C" },                                //067 - C
			{ "Key_D", "VK_D" },                                //068 - D
			{ "Key_E", "VK_E" },                                //069 - E
			{ "Key_F", "VK_F" },                                //070 - F
			{ "Key_G", "VK_G" },                                //071 - G
			{ "Key_H", "VK_H" },                                //072 - H
			{ "Key_I", "VK_I" },                                //073 - I
			{ "Key_J", "VK_J" },                                //074 - J
			{ "Key_K", "VK_K" },                                //075 - K
			{ "Key_L", "VK_L" },                                //076 - L
			{ "Key_M", "VK_M" },                                //077 - M
			{ "Key_N", "VK_N" },                                //078 - N
			{ "Key_O", "VK_O" },                                //079 - O
			{ "Key_P", "VK_P" },                                //080 - P
			{ "Key_Q", "VK_Q" },                                //081 - Q
			{ "Key_R", "VK_R" },                                //082 - R
			{ "Key_S", "VK_S" },                                //083 - S
			{ "Key_T", "VK_T" },                                //084 - T
			{ "Key_U", "VK_U" },                                //085 - U
			{ "Key_V", "VK_V" },                                //086 - V
			{ "Key_W", "VK_W" },                                //087 - W
			{ "Key_X", "VK_X" },                                //088 - X
			{ "Key_Y", "VK_Y" },                                //089 - Y
			{ "Key_Z", "VK_Z" },                                //090 - Z
			{ "Key_LeftWin", "VK_LWIN" },                       //091 - Left Windows
			{ "Key_RightWin", "VK_RWIN" },                      //092 - Right Windows
			{ "Key_Apps", "VK_APPS" },                          //093 - Applications
			{ "Key_Sleep", "VK_SLEEP" },                        //095 - Computer Sleep
			{ "Key_Numpad_0", "VK_NUMPAD0" },                   //096 - Numeric Keypad 0 
			{ "Key_Numpad_1", "VK_NUMPAD1" },                   //097 - Numeric Keypad 1 
			{ "Key_Numpad_2", "VK_NUMPAD2" },                   //098 - Numeric Keypad 2 
			{ "Key_Numpad_3", "VK_NUMPAD3" },                   //099 - Numeric Keypad 3 
			{ "Key_Numpad_4", "VK_NUMPAD4" },                   //100 - Numeric Keypad 4 
			{ "Key_Numpad_5", "VK_NUMPAD5" },                   //101 - Numeric Keypad 5 
			{ "Key_Numpad_6", "VK_NUMPAD6" },                   //102 - Numeric Keypad 6 
			{ "Key_Numpad_7", "VK_NUMPAD7" },                   //103 - Numeric Keypad 7 
			{ "Key_Numpad_8", "VK_NUMPAD8" },                   //104 - Numeric Keypad 8 
			{ "Key_Numpad_9", "VK_NUMPAD9" },                   //105 - Numeric Keypad 9 
			{ "Key_Numpad_Multiply", "VK_MULTIPLY" },           //106 - Numeric Keypad Multiply 
			{ "Key_Numpad_Add", "VK_ADD" },                     //107 - Numeric Keypad Add
			{ "Key_Numpad_Subtract", "VK_SUBTRACT" },           //109 - Numeric Keypad Subtract 
			{ "Key_Numpad_Decimal", "VK_DECIMAL" },             //110 - Numeric Keypad Decimal 
			{ "Key_Numpad_Comma", "VK_DECIMAL" },               //110 - Numeric Keypad Decimal 
			{ "Key_Numpad_Divide", "VK_DIVIDE" },               //111 - Numeric Keypad Divide 
			//{ "Key_Numpad_Enter", "?" },                      //156 - Numeric Keypad Enter
			{ "Key_F1", "VK_F1" },                              //112 - F1 
			{ "Key_F2", "VK_F2" },                              //113 - F2 
			{ "Key_F3", "VK_F3" },                              //114 - F3 
			{ "Key_F4", "VK_F4" },                              //115 - F4 
			{ "Key_F5", "VK_F5" },                              //116 - F5 
			{ "Key_F6", "VK_F6" },                              //117 - F6 
			{ "Key_F7", "VK_F7" },                              //118 - F7 
			{ "Key_F8", "VK_F8" },                              //119 - F8 
			{ "Key_F9", "VK_F9" },                              //120 - F9 
			{ "Key_F10", "VK_F10" },                            //121 - F10 
			{ "Key_F11", "VK_F11" },                            //122 - F11
			{ "Key_F12", "VK_F12" },                            //123 - F12 
			{ "Key_F13", "VK_F13" },                            //124 - F13 
			{ "Key_F14", "VK_F14" },                            //125 - F14 
			{ "Key_F15", "VK_F15" },                            //126 - F15 
			{ "Key_F16", "VK_F16" },                            //127 - F16 
			{ "Key_F17", "VK_F17" },                            //128 - F17 
			{ "Key_F18", "VK_F18" },                            //129 - F18 
			{ "Key_F19", "VK_F19" },                            //130 - F19 
			{ "Key_F20", "VK_F20" },                            //131 - F20 
			{ "Key_F21", "VK_F21" },                            //132 - F21 
			{ "Key_F22", "VK_F22" },                            //133 - F22 
			{ "Key_F23", "VK_F23" },                            //134 - F23 
			{ "Key_F24", "VK_F24" },                            //135 - F24 
			{ "Key_NumLock", "VK_NUMLOCK" },                    //144 - 
			{ "Key_ScrollLock", "VK_SCROLL" },                  //145 - 
			{ "Key_LeftShift", "VK_LSHIFT" },                   //160 - 
			{ "Key_RightShift", "VK_RSHIFT" },                  //161 - 
			{ "Key_LeftControl", "VK_LCONTROL" },               //162 - 
			{ "Key_RightControl", "VK_RCONTROL" },              //163 - 
			{ "Key_LeftAlt", "VK_LMENU" },                      //164 - 
			{ "Key_RightAlt", "VK_RMENU" },                     //165 - 
			{ "Key_WebBack", "VK_BROWSER_BACK" },               //166 - 
			{ "Key_WebForward", "VK_BROWSER_FORWARD" },         //167 - 
			{ "Key_WebRefresh", "VK_BROWSER_REFRESH" },         //168 - 
			{ "Key_WebStop", "VK_BROWSER_STOP" },               //169 - 
			{ "Key_WebSearch", "VK_BROWSER_SEARCH" },           //170 - 
			{ "Key_WebFavourites", "VK_BROWSER_FAVORITES" },    //171 - 
			{ "Key_WebHome", "VK_BROWSER_HOME" },               //172 - 
			{ "Key_Mute", "VK_VOLUME_MUTE" },                   //173 - 
			{ "Key_VolumeDown", "VK_VOLUME_DOWN" },             //174 - 
			{ "Key_VolumeUp", "VK_VOLUME_UP" },                 //175 - 
			{ "Key_NextTrack", "VK_MEDIA_NEXT_TRACK" },         //176 - 
			{ "Key_PrevTrack", "VK_MEDIA_PREV_TRACK" },         //177 - 
			{ "Key_MediaStop", "VK_MEDIA_STOP" },               //178 - 
			{ "Key_Stop", "VK_MEDIA_STOP" },                    //178 - 
			{ "Key_PlayPause", "VK_MEDIA_PLAY_PAUSE" },         //179 - 
			{ "Key_Mail", "VK_LAUNCH_MAIL" },                   //180 - 
			{ "Key_MediaSelect", "VK_LAUNCH_MEDIA_SELECT" },    //181 - 
			{ "Key_SemiColon", "VK_OEM_1" },                    //186 - 
			{ "Key_Plus", "VK_OEM_PLUS" },                      //187 - 
			{ "Key_Equals", "VK_OEM_PLUS" },                    //187 - 
			{ "Key_Comma", "VK_OEM_COMMA" },                    //188 - 
			{ "Key_Minus", "VK_OEM_MINUS" },                    //189 - 
			{ "Key_Period", "VK_OEM_PERIOD" },                  //190 - 
			{ "Key_Slash", "VK_OEM_2" },                        //191 - 
			{ "Key_Grave", "VK_OEM_3" },                        //192 - 
			{ "Key_LeftBracket", "VK_OEM_4" },                  //219 - 
			{ "Key_BackSlash", "VK_OEM_5" },                    //220 - 
			{ "Key_RightBracket", "VK_OEM_6" },                 //221 - 
			{ "Key_Apostrophe", "VK_OEM_7" },                   //222 - 
			{ "Key_OEM_102", "VK_OEM_102" },                    //226 - 
			//{ "Key_ä", "" },                                  //222 - 
			//{ "Key_ö", "" },                                  //192 - 
			//{ "Key_ü", "" },                                  //186 - 
			//{ "Key_ß", "" },                                  //219 - 
			{ "Key_Acute", "VK_OEM_6" },                        //221 - 
			{ "Key_LessThan", "VK_OEM_102" },                   //226 - 
			{ "Key_Circumflex", "VK_OEM_5" },                   //220 - 
			{ "Key_Hash", "VK_OEM_2" },                         //191 - 
			{ "Key_Colon", "VK_OEM_1" },                        //186 - 
		};
	}
}