using System.Xml.Serialization;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using System.Xml;
using ALICE_Internal;
using ALICE_Interface;
using ALICE_Synthesizer;
using System.Threading;
using ALICE_Objects;
using ALICE_Settings;

namespace ALICE_Keybinds
{
	public class AliceKeys
	{
		#region Key Wrappers

		#region Delays
		public readonly string DelayPanel = "Panel";
		public readonly string DelayFireGroup = "Firegroup";
		public readonly string DelayPower = "Power";
		public readonly string DelayThrottle = "Throttle";
		#endregion

		#region 02 - Flight Rotation
		public readonly string Yaw_Left = "Yaw_Left";
		public readonly string Yaw_Right = "Yaw_Right";
		public readonly string Roll_Left = "Roll_Left";
		public readonly string Roll_Right = "Roll_Right";
		public readonly string Pitch_Up = "Pitch_Up";
		public readonly string Pitch_Down = "Pitch_Down";
		#endregion

		#region 03 - Flight Thrust
		public readonly string Thrust_Left = "Thrust_Left";
		public readonly string Thrust_Right = "Thrust_Right";
		public readonly string Thrust_Up = "Thrust_Up";
		public readonly string Thrust_Up_Press = "Thrust_Up_Press";
		public readonly string Thrust_Up_Release = "Thrust_Up_Release";
		public readonly string Thrust_Down = "Thrust_Down";
		public readonly string Thrust_Forward = "Thrust_Forward";
		public readonly string Thrust_Backward = "Thrust_Backward";
		#endregion

		#region 05 -  Flight Throttle
		public readonly string Decrease_Throttle = "Decrease_Throttle";
		public readonly string Increase_Throttle = "Increase_Throttle";
		public readonly string Set_Speed_To_Minus_100 = "Set_Speed_To_-100";
		public readonly string Set_Speed_To_Minus_75 = "Set_Speed_To_-75";
		public readonly string Set_Speed_To_Minus_50 = "Set_Speed_To_-50";
		public readonly string Set_Speed_To_Minus_25 = "Set_Speed_To_-25";
		public readonly string Set_Speed_To_0 = "Set_Speed_To_0";
		public readonly string Set_Speed_To_25 = "Set_Speed_To_25";
		public readonly string Set_Speed_To_50 = "Set_Speed_To_50";
		public readonly string Set_Speed_To_75 = "Set_Speed_To_75";
		public readonly string Set_Speed_To_100 = "Set_Speed_To_100";
		#endregion

		#region 07 - Fligth Miscellaneous
		public readonly string Toggle_Flight_Assist = "Toggle_Flight_Assist";
		public readonly string Engine_Boost = "Engine_Boost";
		public readonly string Toggle_Frame_Shift_Drive = "Toggle_Frame_Shift_Drive";
		public readonly string Supercruise = "Supercruise";
		public readonly string Hyperspace_Jump = "Hyperspace_Jump";
		public readonly string Toggle_Orbit_Lines = "Toggle_Orbit_Lines";
		#endregion

		#region 08 - Targeting
		public readonly string Select_Target_Ahead = "Select_Target_Ahead";
		public readonly string Cycle_Next_Target = "Cycle_Next_Target";
		public readonly string Cycle_Previous_Ship = "Cycle_Previous_Ship";
		public readonly string Select_Hightest_Threat = "Select_Hightest_Threat";
		public readonly string Cycle_Next_Hostile_Target = "Cycle_Next_Hostile_Target";
		public readonly string Cycle_Previous_Hostile_Ship = "Cycle_Previous_Hostile_Ship";
		public readonly string Select_Wingman_1 = "Select_Wingman_1";
		public readonly string Select_Wingman_2 = "Select_Wingman_2";
		public readonly string Select_Wingman_3 = "Select_Wingman_3";
		public readonly string Select_Wingmans_Target = "Select_Wingmans_Target";
		public readonly string Wingman_NavLock = "Wingman_Nav-Lock";
		public readonly string Cycle_Next_Subsystem = "Cycle_Next_Subsystem";
		public readonly string Cycle_Previous_Subsystem = "Cycle_Previous_Subsystem";
		public readonly string Target_Next_System_In_Route = "Target_Next_System_In_Route";
		#endregion

		#region 09 - Weapons
		public readonly string Primary_Fire = "Primary_Fire";
		public readonly string Secondary_Fire = "Secondary_Fire";
		public readonly string Primary_Fire_Press = "Primary_Fire_Press";
		public readonly string Secondary_Fire_Press = "Secondary_Fire_Press";
		public readonly string Primary_Fire_Release = "Primary_Fire_Release";
		public readonly string Secondary_Fire_Release = "Secondary_Fire_Release";
		public readonly string Cycle_Next_Fire_Group = "Cycle_Next_Fire_Group";
		public readonly string Cycle_Previous_Fire_Group = "Cycle_Previous_Fire_Group";
		public readonly string Deploy_Hardpoints = "Deploy_Hardpoints";
		#endregion

		#region 10 - Cooling
		public readonly string Deploy_Heat_Sink = "Deploy_Heat_Sink";
		public readonly string Silent_Running = "Silent_Running";
		#endregion

		#region 11 - Miscellaneous
		public readonly string Ship_Lights = "Ship_Lights";
		public readonly string Increase_Sensor_Zoom = "Increase_Sensor_Zoom";
		public readonly string Decrease_Sensor_Zoom = "Decrease_Sensor_Zoom";
		public readonly string Divert_Power_To_Engines = "Divert_Power_To_Engines";
		public readonly string Divert_Power_To_Weapons = "Divert_Power_To_Weapons";
		public readonly string Divert_Power_To_Systems = "Divert_Power_To_Systems";
		public readonly string Balance_Power_Distribution = "Balance_Power_Distribution";
		public readonly string Reset_HMD_Orientation = "Reset_HMD_Orientation";
		public readonly string Cargo_Scoop = "Cargo_Scoop";
		public readonly string Landing_Gear = "Landing_Gear";
		public readonly string Use_Shield_Cell = "Use_Shield_Cell";
		public readonly string Use_Chaff_Launcher = "Use_Chaff_Launcher";
		public readonly string Charge_ECM = "Charge_ECM";
		#endregion

		#region 13 - Mode Switches
		public readonly string Target_Panel = "Target_Panel";
		public readonly string Comms_Panel = "Comms_Panel";
		public readonly string Quick_Comms = "Quick_Comms";
		public readonly string Role_Panel = "Role_Panel";
		public readonly string System_Panel = "System_Panel";
		public readonly string Open_Galaxy_Map = "Open_Galaxy_Map";
		public readonly string Open_System_Map = "Open_System_Map";
		public readonly string Game_Menu = "Game_Menu";
		public readonly string Friends_Menu = "Friends_Menu";
		#endregion

		#region 14 - Interface Mode
		public readonly string UI_Panel_Up = "UI_Panel_Up";
		public readonly string UI_Panel_Down = "UI_Panel_Down";
		public readonly string UI_Panel_Left = "UI_Panel_Left";
		public readonly string UI_Panel_Right = "UI_Panel_Right";
		public readonly string UI_Panel_Select = "UI_Panel_Select";
		public readonly string UI_Back = "UI_Back";
		public readonly string Next_Panel_Tab = "Next_Panel_Tab";
		public readonly string Previous_Panel_Tab = "Previous_Panel_Tab";
		public readonly string UI_Panel_Up_Press = "UI_Panel_Up_Press";
		public readonly string UI_Panel_Up_Release = "UI_Panel_Up_Release";
		public readonly string UI_Panel_Down_Press = "UI_Panel_Down_Press";
		public readonly string UI_Panel_Down_Release = "UI_Panel_Down_Release";
		#endregion

		#region 23 - Fighter
		public readonly string Attack_Target = "Attack_Target";
		public readonly string Defend = "Defend";
		public readonly string Engage_At_Will = "Engage_At_Will";
		public readonly string Follow_Me = "Follow_Me";
		public readonly string Hold_Position = "Hold_Position";
		public readonly string Maintain_Formation = "Maintain_Formation";
		public readonly string Recall_Fighter = "Recall_Fighter";
		#endregion

		#region 27 - Galnet Audio
		public readonly string Galnet_Play = "Galnet_Play";
		public readonly string Galnet_Skip_Forward = "Galnet_Skip_Forward";
		public readonly string Galnet_Skip_Backward = "Galnet_Skip_Backward";
		public readonly string Galnet_Clear_Queue = "Galnet_Clear_Queue";
		#endregion

		#region 3.4 Added Items
		public readonly string Night_Vision_Toggle = "Night_Vision_Toggle";
		public readonly string Open_Codex = "Open_Discovery";
		public readonly string Toggle_HUD_Mode = "Swtich_HUD_Mode";
		public readonly string Cycle_Next_Page = "Cycle_Next_Page";
		public readonly string Cycle_Previous_Page = "Cycle_Previous_Page";
		public readonly string FSS_Enter = "Enter_FSS_Mode";
		public readonly string FSS_Exit = "Leave_FSS_Mode";
		#endregion

		#region Custom
		public readonly string ActiveScreenshot = "ActiveScreenCap";
		#endregion

		//End Regon: Key Wrappers
		#endregion

		public XmlDocument AliceBinds;

		private XmlDocument UserBinds;

		public Dictionary<string, Bind> Keybinds;

		//Dictionary containing the Virtual Keys as Int's.
		//Key = Games Key Definition
		//Value = Virtual Key as Int
		public Dictionary<string, int> VirtualKeysNum = new Dictionary<string, int>()
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

		//Dictionary containing the Virtual Keys as Strings.
		//Key = Games Key Definition
		//Value = Virtual Key as Strings
		public Dictionary<string, string> VirtualKeysStr = new Dictionary<string, string>()
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


		public AliceKeys()
		{
			AliceBinds = GetBindsFile(Paths.ALICE_BindsPath);
		}

		/// <summary>
		/// Builds a Dictionary of Keybind controls from the Games Binds File.
		/// </summary>
		public void GetGameBinds()
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
				{ "Leave_FSS_Mode", GetBind("ExplorationFSSQuit") },
				#endregion

				#region Custom / Miscellaneous
				{ "ActiveScreenCap", IScreenshot.ActiveScreenCap() }
				#endregion
			};
		}

		/// <summary>
		/// This function allows you to control the keypress' in a single place
		/// </summary>
		/// <param name="Key">This is the Keybind you with to activate.</param>
		/// <param name="ExtraSleep">Adds to the timeout in milliseconds after the keypress.</param>
		/// <param name="PanelDelay">If Set to False The Users Panel Delay Will Not Be Counted.</param>
		public void Press(string Key, int ExtraSleep = 0, string Delay = null, int Duration = 50)
		{
			string MethodName = "Press Key";

			try
			{
				//Select Keypress Method Based On Interface
				switch (IPlatform.Interface)
				{
					case IPlatform.Interfaces.Internal:
						Logger.Log(MethodName, "Internal Operations: " + Key, Logger.Yellow);
						return;

					case IPlatform.Interfaces.VoiceAttack:
						IPlatform.ExecuteCommand("(A.L.I.C.E) Keybind: " + Key, true);
						return;

					case IPlatform.Interfaces.VoiceMacro:
						IPlatform.ExecuteCommand("(A.L.I.C.E) Keybind: " + Key, true);
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
				if (Delay == DelayPanel) { ExtraSleep = ExtraSleep + ISettings.OffsetPanels; }
				if (Delay == DelayFireGroup) { ExtraSleep = ExtraSleep + ISettings.OffsetFireGroups; }
				if (Delay == DelayPower) { ExtraSleep = ExtraSleep + ISettings.OffsetPips; }
				if (Delay == DelayThrottle) { ExtraSleep = ExtraSleep + ISettings.OffsetThrottle; }
				Thread.Sleep(ExtraSleep);
				#endregion
			}

			#region Write To Log: Keybind Not Found
			IPlatform.WriteToInterface("A.L.I.C.E (Internal Error): Key Action: " + Key + " Was Not Found.", "Red");
			#endregion
		}

		//public void Keypress(int Duration, Bind bind)
		//{
		//    if (PlugIn.DebugMode == true)
		//    {
		//        IPlatform.WriteToInterface("A.L.I.C.E (Debug Mode): Processing Keybind " + bind.Name, "Yellow");
		//        IPlatform.WriteToInterface("A.L.I.C.E (Debug Mode): Key #1: " + bind.Key1 + " | Key #2: " + bind.Key2 + " | Key #3: " + bind.Key3 + " | Key #4: " + bind.Key4, "Yellow");
		//    }

		//    int Key1 = -1; int Key2 = -1; int Key3 = -1; int Key4 = -1;

		//    try
		//    {
		//        if (bind.Key1 != null && bind.Key1 != "") { Key1 = KeyBinds.VirtualKeys[bind.Key1]; }
		//        if (bind.Key2 != null && bind.Key2 != "") { Key2 = KeyBinds.VirtualKeys[bind.Key2]; }
		//        if (bind.Key3 != null && bind.Key3 != "") { Key3 = KeyBinds.VirtualKeys[bind.Key3]; }
		//        if (bind.Key4 != null && bind.Key4 != "") { Key4 = KeyBinds.VirtualKeys[bind.Key4]; }
		//    }
		//    catch (Exception ex)
		//    {
		//        IPlatform.WriteToInterface("A.L.I.C.E (Internal Error): Virtual Key Assignment " + ex, "Red");
		//    }

		//    if (PlugIn.DebugMode == true)
		//    { IPlatform.WriteToInterface("A.L.I.C.E (Debug Mode): Virtual Key #1: " + Key1 + " | Virtual Key #2: " + Key2 + " | Virtual Key #3: " + Key3 + " | Virtual Key #4: " + Key4, "Yellow"); }

		//    KeyboardAction key1 = new KeyboardAction(); KeyboardAction key2 = new KeyboardAction();
		//    KeyboardAction key3 = new KeyboardAction(); KeyboardAction key4 = new KeyboardAction();

		//    #region Initiate Keypress
		//    if (Key1 != -1) { key1.Key = (Keys)Key1; key1.ClickDownUp = 1; vmCommand.SendKey(key1); }
		//    if (Key2 != -1) { key2.Key = (Keys)Key2; key2.ClickDownUp = 1; vmCommand.SendKey(key2); }
		//    if (Key3 != -1) { key3.Key = (Keys)Key3; key3.ClickDownUp = 1; vmCommand.SendKey(key3); }
		//    if (Key4 != -1) { key4.Key = (Keys)Key4; key4.ClickDownUp = 1; vmCommand.SendKey(key4); }
		//    #endregion

		//    if (PlugIn.DebugMode == true)
		//    { IPlatform.WriteToInterface("A.L.I.C.E: Key Duration: " + Duration + " ms", "Yellow"); }

		//    Thread.Sleep(Duration);

		//    #region Release Keypress
		//    // Add Keycounter for Commands currently using keys if needed. Only Release Key if Counter is Zero.

		//    if (Key4 != -1) { key4.ClickDownUp = 2; vmCommand.SendKey(key4); }
		//    if (Key3 != -1) { key3.ClickDownUp = 2; vmCommand.SendKey(key3); }
		//    if (Key2 != -1) { key2.ClickDownUp = 2; vmCommand.SendKey(key2); }
		//    if (Key1 != -1) { key1.ClickDownUp = 2; vmCommand.SendKey(key1); }
		//    #endregion
		//}

		public void Load_VoiceAttackVariables()
		{
			string MethodName = "Voice Attack (Load Keybinds)";

			bool AlertAudio = false;

			//Loops though the Binds Collection Building Virtual Keybinds.
			foreach (KeyValuePair<string, Bind> bind in Keybinds)
			{
				//Checks First Key Isn't Default or Null.
				if (bind.Value.Key1 != "" && bind.Value.Key1 != null)
				{
					//Virtual Keybinds For Voice Attack Are Formatted With "[" & "]" To Encapsulate The Key.
					//Example "Key_LeftControl" + "Key_K" In The Below Function Would Be Set As A Text 
					//Variable Equal To "[162][75]". Note There Is No Space Between Them. A Space Will
					//Is Another Way To Indicate "Key_Space". The Keys Are Pressed From Left To Right
					//And Released Right To Left. So "L Ctrl" (down), "K" (down), (pause for duration),
					//"K" (release), "L Ctrl" (release).

					string Variable = "[" + VirtualKeysNum[bind.Value.Key1] + "]";
					if (bind.Value.Key2 != null && bind.Value.Key2 != "") { Variable = Variable + "[" + VirtualKeysNum[bind.Value.Key2] + "]"; }
					if (bind.Value.Key3 != null && bind.Value.Key3 != "") { Variable = Variable + "[" + VirtualKeysNum[bind.Value.Key3] + "]"; }
					if (bind.Value.Key4 != null && bind.Value.Key4 != "") { Variable = Variable + "[" + VirtualKeysNum[bind.Value.Key4] + "]"; }

					//Debug Logger
					if (PlugIn.DebugMode == true)
					{ IPlatform.WriteToInterface("A.L.I.C.E: " + bind.Key.ToString() + " Virtual Keys = " + Variable, "Green"); }

					//Pass Key To Voice Attack Via The Platform Interface.
					IPlatform.SetText(bind.Key.ToString(), Variable);
				}
				else
				{
					IPlatform.WriteToInterface("A.L.I.C.E: No Keybind Detected For \"" + bind.Key.ToString() + " Please Add A Keybind And Restart.", "Red");
					AlertAudio = true;
				}
			}

			#region Audio: Missing Keybinds
			if (AlertAudio == true)
			{
				string Line = "I Detected Missing Keybinds, This Will Limit Functions Requiring Those Keybinds. I've Written Them To The Log. Please Add Them And Restart.";

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

		public void Load_VoiceMacroVariables()
		{
			string MethodName = "Voice Macro (Load Keybinds)";

			bool AlertAudio = false;
			
			//Loops though the Binds Collection Building Virtual Keybinds.
			foreach (KeyValuePair<string, Bind> bind in Keybinds)
			{
				//Checks First Key Isn't Default or Null.
				if (bind.Value.Key1 != "" && bind.Value.Key1 != null)
				{


					string P = VirtualKeysStr[bind.Value.Key1] + "_D;";
					string R = VirtualKeysStr[bind.Value.Key1] + "_U;";

					if (bind.Value.Key2 != null && bind.Value.Key2 != "")
					{
						P = P + VirtualKeysStr[bind.Value.Key2] + "_D;";
						R = VirtualKeysStr[bind.Value.Key2] + "_U;" + R;
					}

					if (bind.Value.Key3 != null && bind.Value.Key3 != "")
					{
						P = P + VirtualKeysStr[bind.Value.Key3] + "_D;";
						R = VirtualKeysStr[bind.Value.Key3] + "_U;" + R;
					}

					if (bind.Value.Key4 != null && bind.Value.Key4 != "")
					{
						P = P + VirtualKeysStr[bind.Value.Key4] + "_D;";
						R = VirtualKeysStr[bind.Value.Key4] + "_U;" + R;
					}                   

					Logger.DebugLine(MethodName, bind.Key.ToString() + " Release : " + R, Logger.Blue);
					Logger.DebugLine(MethodName, bind.Key.ToString() + " Press   : " + P, Logger.Blue);                    

					//Pass Key To Voice Macro Via The Platform Interface.
					IPlatform.SetText(bind.Key.ToString() + "_Press", P);
					IPlatform.SetText(bind.Key.ToString() + "_Release", R);
				}
				else
				{
					IPlatform.WriteToInterface("A.L.I.C.E: No Keybind Detected For \"" + bind.Key.ToString() + " Please Add A Keybind And Restart.", "Red");
					AlertAudio = true;
				}
			}

			#region Audio: Missing Keybinds
			if (AlertAudio == true)
			{
				string Line = "I Detected Missing Keybinds, This Will Limit Functions Requiring Those Keybinds. I've Written Them To The Log. Please Add Them And Restart.";

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

		public XmlDocument GetBindsFile(string Path)
		{
			XmlDocument file;
			using (XmlReader Reader = XmlReader.Create(Path))
			{
				file = new XmlDocument();
				file.Load(Path);
			}

			return file;
		}

		public Bind GetBind(string XMLElementName)
		{
			Bind bind = new Bind();

			foreach (XmlNode node in AliceBinds.DocumentElement)
			{
				if (node.Name == XMLElementName)
				{
					if (node.HasChildNodes == true && node.ChildNodes[1].Name == "Secondary" && 
						node.ChildNodes[1].Attributes["Device"].Value == "Keyboard")
					{
						//if (PlugIn.DebugMode == true)
						//{ IPlatform.WriteToInterface("Keybind = " + node.Name, "Green"); }

						bind.Name = XMLElementName;
						List<string> Keys = new List<string>(new string[5])
						{
							[0] = node.ChildNodes[1].Attributes[1].Value
						};

						foreach (XmlNode modifier in node.ChildNodes[1])
						{
							if (Keys[2] == null) { Keys[2] = modifier.Attributes[1].Value; }
							else if (Keys[3] == null) { Keys[3] = modifier.Attributes[1].Value; }
							else if (Keys[4] == null) { Keys[4] = modifier.Attributes[1].Value; }
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
			return bind;
		}

		public void ImportUserBinds(string FilePath)
		{
			string MethodName = "Import User Binds";

			try
			{
				if (FilePath != "")
				{
					UserBinds = GetBindsFile(FilePath);

					XmlControl.Root AliceBind = (XmlControl.Root)XmlControl.Deserialize(AliceBinds);
					XmlControl.Root UserBind = (XmlControl.Root)XmlControl.Deserialize(UserBinds);

					Logger.Log(MethodName, "Selected Binds File Loaded. Importing User Binds From The First Column...", Logger.Purple);

					#region Copy User Binds
					AliceBind.KeyboardLayout = UserBind.KeyboardLayout;
					AliceBind.MouseXMode = UserBind.MouseXMode;
					AliceBind.MouseXDecay = UserBind.MouseXDecay;
					AliceBind.MouseYMode = UserBind.MouseYMode;
					AliceBind.MouseYDecay = UserBind.MouseYDecay;
					AliceBind.MouseReset.Primary = UserBind.MouseReset.Primary;
					AliceBind.MouseSensitivity = UserBind.MouseSensitivity;
					AliceBind.MouseDecayRate = UserBind.MouseDecayRate;
					AliceBind.MouseDeadzone = UserBind.MouseDeadzone;
					AliceBind.MouseLinearity = UserBind.MouseLinearity;
					AliceBind.MouseGUI = UserBind.MouseGUI;
					AliceBind.YawAxisRaw = UserBind.YawAxisRaw;
					AliceBind.YawLeftButton.Primary = UserBind.YawLeftButton.Primary;
					AliceBind.YawRightButton.Primary = UserBind.YawRightButton.Primary;
					AliceBind.YawToRollMode = UserBind.YawToRollMode;
					AliceBind.YawToRollSensitivity = UserBind.YawToRollSensitivity;
					AliceBind.YawToRollMode_FAOff = UserBind.YawToRollMode_FAOff;
					AliceBind.YawToRollButton.Primary = UserBind.YawToRollButton.Primary;
					AliceBind.YawToRollButton.ToggleOn = UserBind.YawToRollButton.ToggleOn;
					AliceBind.RollAxisRaw = UserBind.RollAxisRaw;
					AliceBind.RollLeftButton.Primary = UserBind.RollLeftButton.Primary;
					AliceBind.RollRightButton.Primary = UserBind.RollRightButton.Primary;
					AliceBind.PitchAxisRaw = UserBind.PitchAxisRaw;
					AliceBind.PitchUpButton.Primary = UserBind.PitchUpButton.Primary;
					AliceBind.PitchDownButton.Primary = UserBind.PitchDownButton.Primary;
					AliceBind.LateralThrustRaw = UserBind.LateralThrustRaw;
					AliceBind.LeftThrustButton.Primary = UserBind.LeftThrustButton.Primary;
					AliceBind.RightThrustButton.Primary = UserBind.RightThrustButton.Primary;
					AliceBind.VerticalThrustRaw = UserBind.VerticalThrustRaw;
					AliceBind.UpThrustButton.Primary = UserBind.UpThrustButton.Primary;
					AliceBind.DownThrustButton.Primary = UserBind.DownThrustButton.Primary;
					AliceBind.AheadThrust = UserBind.AheadThrust;
					AliceBind.ForwardThrustButton.Primary = UserBind.ForwardThrustButton.Primary;
					AliceBind.BackwardThrustButton.Primary = UserBind.BackwardThrustButton.Primary;
					AliceBind.UseAlternateFlightValuesToggle.Primary = UserBind.UseAlternateFlightValuesToggle.Primary;
					AliceBind.UseAlternateFlightValuesToggle.ToggleOn = UserBind.UseAlternateFlightValuesToggle.ToggleOn;
					AliceBind.YawAxisAlternate = UserBind.YawAxisAlternate;
					AliceBind.RollAxisAlternate = UserBind.RollAxisAlternate;
					AliceBind.PitchAxisAlternate = UserBind.PitchAxisAlternate;
					AliceBind.LateralThrustAlternate = UserBind.LateralThrustAlternate;
					AliceBind.VerticalThrustAlternate = UserBind.VerticalThrustAlternate;
					AliceBind.ThrottleAxis = UserBind.ThrottleAxis;
					AliceBind.ThrottleRange = UserBind.ThrottleRange;
					AliceBind.ToggleReverseThrottleInput.Primary = UserBind.ToggleReverseThrottleInput.Primary;
					AliceBind.ToggleReverseThrottleInput.ToggleOn = UserBind.ToggleReverseThrottleInput.ToggleOn;
					AliceBind.ForwardKey.Primary = UserBind.ForwardKey.Primary;
					AliceBind.BackwardKey.Primary = UserBind.BackwardKey.Primary;
					AliceBind.ThrottleIncrement = UserBind.ThrottleIncrement;
					AliceBind.SetSpeedMinus100.Primary = UserBind.SetSpeedMinus100.Primary;
					AliceBind.SetSpeedMinus75.Primary = UserBind.SetSpeedMinus75.Primary;
					AliceBind.SetSpeedMinus50.Primary = UserBind.SetSpeedMinus50.Primary;
					AliceBind.SetSpeedMinus25.Primary = UserBind.SetSpeedMinus25.Primary;
					AliceBind.SetSpeedZero.Primary = UserBind.SetSpeedZero.Primary;
					AliceBind.SetSpeed25.Primary = UserBind.SetSpeed25.Primary;
					AliceBind.SetSpeed50.Primary = UserBind.SetSpeed50.Primary;
					AliceBind.SetSpeed75.Primary = UserBind.SetSpeed75.Primary;
					AliceBind.SetSpeed100.Primary = UserBind.SetSpeed100.Primary;
					AliceBind.YawAxis_Landing = UserBind.YawAxis_Landing;
					AliceBind.YawLeftButton_Landing.Primary = UserBind.YawLeftButton_Landing.Primary;
					AliceBind.YawRightButton_Landing.Primary = UserBind.YawRightButton_Landing.Primary;
					AliceBind.YawToRollMode_Landing = UserBind.YawToRollMode_Landing;
					AliceBind.PitchAxis_Landing = UserBind.PitchAxis_Landing;
					AliceBind.PitchUpButton_Landing.Primary = UserBind.PitchUpButton_Landing.Primary;
					AliceBind.PitchDownButton_Landing.Primary = UserBind.PitchDownButton_Landing.Primary;
					AliceBind.RollAxis_Landing = UserBind.RollAxis_Landing;
					AliceBind.RollLeftButton_Landing.Primary = UserBind.RollLeftButton_Landing.Primary;
					AliceBind.RollRightButton_Landing.Primary = UserBind.RollRightButton_Landing.Primary;
					AliceBind.LateralThrust_Landing = UserBind.LateralThrust_Landing;
					AliceBind.LeftThrustButton_Landing.Primary = UserBind.LeftThrustButton_Landing.Primary;
					AliceBind.RightThrustButton_Landing.Primary = UserBind.RightThrustButton_Landing.Primary;
					AliceBind.VerticalThrust_Landing = UserBind.VerticalThrust_Landing;
					AliceBind.UpThrustButton_Landing.Primary = UserBind.UpThrustButton_Landing.Primary;
					AliceBind.DownThrustButton_Landing.Primary = UserBind.DownThrustButton_Landing.Primary;
					AliceBind.AheadThrust_Landing = UserBind.AheadThrust_Landing;
					AliceBind.ForwardThrustButton_Landing.Primary = UserBind.ForwardThrustButton_Landing.Primary;
					AliceBind.BackwardThrustButton_Landing.Primary = UserBind.BackwardThrustButton_Landing.Primary;
					AliceBind.ToggleFlightAssist.Primary = UserBind.ToggleFlightAssist.Primary;
					AliceBind.ToggleFlightAssist.ToggleOn = UserBind.ToggleFlightAssist.ToggleOn;
					AliceBind.UseBoostJuice.Primary = UserBind.UseBoostJuice.Primary;
					AliceBind.HyperSuperCombination.Primary = UserBind.HyperSuperCombination.Primary;
					AliceBind.Supercruise.Primary = UserBind.Supercruise.Primary;
					AliceBind.Hyperspace.Primary = UserBind.Hyperspace.Primary;
					AliceBind.DisableRotationCorrectToggle.Primary = UserBind.DisableRotationCorrectToggle.Primary;
					AliceBind.DisableRotationCorrectToggle.ToggleOn = UserBind.DisableRotationCorrectToggle.ToggleOn;
					AliceBind.OrbitLinesToggle.Primary = UserBind.OrbitLinesToggle.Primary;
					AliceBind.SelectTarget.Primary = UserBind.SelectTarget.Primary;
					AliceBind.CycleNextTarget.Primary = UserBind.CycleNextTarget.Primary;
					AliceBind.CyclePreviousTarget.Primary = UserBind.CyclePreviousTarget.Primary;
					AliceBind.SelectHighestThreat.Primary = UserBind.SelectHighestThreat.Primary;
					AliceBind.CycleNextHostileTarget.Primary = UserBind.CycleNextHostileTarget.Primary;
					AliceBind.CyclePreviousHostileTarget.Primary = UserBind.CyclePreviousHostileTarget.Primary;
					AliceBind.TargetWingman0.Primary = UserBind.TargetWingman0.Primary;
					AliceBind.TargetWingman1.Primary = UserBind.TargetWingman1.Primary;
					AliceBind.TargetWingman2.Primary = UserBind.TargetWingman2.Primary;
					AliceBind.SelectTargetsTarget.Primary = UserBind.SelectTargetsTarget.Primary;
					AliceBind.WingNavLock.Primary = UserBind.WingNavLock.Primary;
					AliceBind.CycleNextSubsystem.Primary = UserBind.CycleNextSubsystem.Primary;
					AliceBind.CyclePreviousSubsystem.Primary = UserBind.CyclePreviousSubsystem.Primary;
					AliceBind.TargetNextRouteSystem.Primary = UserBind.TargetNextRouteSystem.Primary;
					AliceBind.PrimaryFire.Primary = UserBind.PrimaryFire.Primary;
					AliceBind.SecondaryFire.Primary = UserBind.SecondaryFire.Primary;
					AliceBind.CycleFireGroupNext.Primary = UserBind.CycleFireGroupNext.Primary;
					AliceBind.CycleFireGroupPrevious.Primary = UserBind.CycleFireGroupPrevious.Primary;
					AliceBind.DeployHardpointToggle.Primary = UserBind.DeployHardpointToggle.Primary;
					AliceBind.DeployHardpointsOnFire = UserBind.DeployHardpointsOnFire;
					AliceBind.ToggleButtonUpInput.Primary = UserBind.ToggleButtonUpInput.Primary;
					AliceBind.ToggleButtonUpInput.ToggleOn = UserBind.ToggleButtonUpInput.ToggleOn;
					AliceBind.DeployHeatSink.Primary = UserBind.DeployHeatSink.Primary;
					AliceBind.ShipSpotLightToggle.Primary = UserBind.ShipSpotLightToggle.Primary;
					AliceBind.RadarRangeAxis = UserBind.RadarRangeAxis;
					AliceBind.RadarIncreaseRange.Primary = UserBind.RadarIncreaseRange.Primary;
					AliceBind.RadarDecreaseRange.Primary = UserBind.RadarDecreaseRange.Primary;
					AliceBind.IncreaseEnginesPower.Primary = UserBind.IncreaseEnginesPower.Primary;
					AliceBind.IncreaseWeaponsPower.Primary = UserBind.IncreaseWeaponsPower.Primary;
					AliceBind.IncreaseSystemsPower.Primary = UserBind.IncreaseSystemsPower.Primary;
					AliceBind.ResetPowerDistribution.Primary = UserBind.ResetPowerDistribution.Primary;
					AliceBind.HMDReset.Primary = UserBind.HMDReset.Primary;
					AliceBind.ToggleCargoScoop.Primary = UserBind.ToggleCargoScoop.Primary;
					AliceBind.ToggleCargoScoop.ToggleOn = UserBind.ToggleCargoScoop.ToggleOn;
					AliceBind.EjectAllCargo.Primary = UserBind.EjectAllCargo.Primary;
					AliceBind.LandingGearToggle.Primary = UserBind.LandingGearToggle.Primary;
					AliceBind.MicrophoneMute.Primary = UserBind.MicrophoneMute.Primary;
					AliceBind.MicrophoneMute.ToggleOn = UserBind.MicrophoneMute.ToggleOn;
					AliceBind.MuteButtonMode = UserBind.MuteButtonMode;
					AliceBind.CqcMuteButtonMode = UserBind.CqcMuteButtonMode;
					AliceBind.UseShieldCell.Primary = UserBind.UseShieldCell.Primary;
					AliceBind.FireChaffLauncher.Primary = UserBind.FireChaffLauncher.Primary;
					AliceBind.ChargeECM.Primary = UserBind.ChargeECM.Primary;
					AliceBind.EnableRumbleTrigger = UserBind.EnableRumbleTrigger;
					AliceBind.EnableMenuGroups = UserBind.EnableMenuGroups;
					AliceBind.MouseGUI = UserBind.MouseGUI;
					AliceBind.WeaponColourToggle.Primary = UserBind.WeaponColourToggle.Primary;
					AliceBind.EngineColourToggle.Primary = UserBind.EngineColourToggle.Primary;
					AliceBind.UIFocus.Primary = UserBind.UIFocus.Primary;
					AliceBind.UIFocusMode = UserBind.UIFocusMode;
					AliceBind.FocusLeftPanel.Primary = UserBind.FocusLeftPanel.Primary;
					AliceBind.FocusCommsPanel.Primary = UserBind.FocusCommsPanel.Primary;
					AliceBind.FocusOnTextEntryField = UserBind.FocusOnTextEntryField;
					AliceBind.QuickCommsPanel.Primary = UserBind.QuickCommsPanel.Primary;
					AliceBind.FocusRadarPanel.Primary = UserBind.FocusRadarPanel.Primary;
					AliceBind.FocusRightPanel.Primary = UserBind.FocusRightPanel.Primary;
					AliceBind.LeftPanelFocusOptions = UserBind.LeftPanelFocusOptions;
					AliceBind.CommsPanelFocusOptions = UserBind.CommsPanelFocusOptions;
					AliceBind.RolePanelFocusOptions = UserBind.RolePanelFocusOptions;
					AliceBind.RightPanelFocusOptions = UserBind.RightPanelFocusOptions;
					AliceBind.EnableCameraLockOn = UserBind.EnableCameraLockOn;
					AliceBind.GalaxyMapOpen.Primary = UserBind.GalaxyMapOpen.Primary;
					AliceBind.SystemMapOpen.Primary = UserBind.SystemMapOpen.Primary;
					AliceBind.ShowPGScoreSummaryInput.Primary = UserBind.ShowPGScoreSummaryInput.Primary;
					AliceBind.ShowPGScoreSummaryInput.ToggleOn = UserBind.ShowPGScoreSummaryInput.ToggleOn;
					AliceBind.HeadLookToggle.Primary = UserBind.HeadLookToggle.Primary;
					AliceBind.HeadLookToggle.ToggleOn = UserBind.HeadLookToggle.ToggleOn;
					AliceBind.Pause.Primary = UserBind.Pause.Primary;
					AliceBind.FriendsMenu.Primary = UserBind.FriendsMenu.Primary;
					AliceBind.UI_Up.Primary = UserBind.UI_Up.Primary;
					AliceBind.UI_Down.Primary = UserBind.UI_Down.Primary;
					AliceBind.UI_Left.Primary = UserBind.UI_Left.Primary;
					AliceBind.UI_Right.Primary = UserBind.UI_Right.Primary;
					AliceBind.UI_Select.Primary = UserBind.UI_Select.Primary;
					AliceBind.UI_Back.Primary = UserBind.UI_Back.Primary;
					AliceBind.UI_Toggle.Primary = UserBind.UI_Toggle.Primary;
					AliceBind.CycleNextPanel.Primary = UserBind.CycleNextPanel.Primary;
					AliceBind.CyclePreviousPanel.Primary = UserBind.CyclePreviousPanel.Primary;
					AliceBind.MouseHeadlook = UserBind.MouseHeadlook;
					AliceBind.MouseHeadlookInvert = UserBind.MouseHeadlookInvert;
					AliceBind.MouseHeadlookSensitivity = UserBind.MouseHeadlookSensitivity;
					AliceBind.HeadlookDefault = UserBind.HeadlookDefault;
					AliceBind.HeadlookIncrement = UserBind.HeadlookIncrement;
					AliceBind.HeadlookMode = UserBind.HeadlookMode;
					AliceBind.HeadlookResetOnToggle = UserBind.HeadlookResetOnToggle;
					AliceBind.HeadlookSensitivity = UserBind.HeadlookSensitivity;
					AliceBind.HeadlookSmoothing = UserBind.HeadlookSmoothing;
					AliceBind.HeadLookReset.Primary = UserBind.HeadLookReset.Primary;
					AliceBind.HeadLookPitchUp.Primary = UserBind.HeadLookPitchUp.Primary;
					AliceBind.HeadLookPitchDown.Primary = UserBind.HeadLookPitchDown.Primary;
					AliceBind.HeadLookPitchAxisRaw = UserBind.HeadLookPitchAxisRaw;
					AliceBind.HeadLookYawLeft.Primary = UserBind.HeadLookYawLeft.Primary;
					AliceBind.HeadLookYawRight.Primary = UserBind.HeadLookYawRight.Primary;
					AliceBind.HeadLookYawAxis = UserBind.HeadLookYawAxis;
					AliceBind.MotionHeadlook = UserBind.MotionHeadlook;
					AliceBind.HeadlookMotionSensitivity = UserBind.HeadlookMotionSensitivity;
					//AliceBind.yawRotateHeadlook = UserBind.yawRotateHeadlook;
					AliceBind.CamPitchAxis = UserBind.CamPitchAxis;
					AliceBind.CamPitchUp.Primary = UserBind.CamPitchUp.Primary;
					AliceBind.CamPitchDown.Primary = UserBind.CamPitchDown.Primary;
					AliceBind.CamYawAxis = UserBind.CamYawAxis;
					AliceBind.CamYawLeft.Primary = UserBind.CamYawLeft.Primary;
					AliceBind.CamYawRight.Primary = UserBind.CamYawRight.Primary;
					AliceBind.CamTranslateYAxis = UserBind.CamTranslateYAxis;
					AliceBind.CamTranslateForward.Primary = UserBind.CamTranslateForward.Primary;
					AliceBind.CamTranslateBackward.Primary = UserBind.CamTranslateBackward.Primary;
					AliceBind.CamTranslateXAxis = UserBind.CamTranslateXAxis;
					AliceBind.CamTranslateLeft.Primary = UserBind.CamTranslateLeft.Primary;
					AliceBind.CamTranslateRight.Primary = UserBind.CamTranslateRight.Primary;
					AliceBind.CamTranslateZAxis = UserBind.CamTranslateZAxis;
					AliceBind.CamTranslateUp.Primary = UserBind.CamTranslateUp.Primary;
					AliceBind.CamTranslateDown.Primary = UserBind.CamTranslateDown.Primary;
					AliceBind.CamZoomAxis = UserBind.CamZoomAxis;
					AliceBind.CamZoomIn.Primary = UserBind.CamZoomIn.Primary;
					AliceBind.CamZoomOut.Primary = UserBind.CamZoomOut.Primary;
					AliceBind.CamTranslateZHold.Primary = UserBind.CamTranslateZHold.Primary;
					AliceBind.CamTranslateZHold.ToggleOn = UserBind.CamTranslateZHold.ToggleOn;
					AliceBind.ToggleDriveAssist.Primary = UserBind.ToggleDriveAssist.Primary;
					AliceBind.ToggleDriveAssist.ToggleOn = UserBind.ToggleDriveAssist.ToggleOn;
					AliceBind.DriveAssistDefault = UserBind.DriveAssistDefault;
					AliceBind.MouseBuggySteeringXMode = UserBind.MouseBuggySteeringXMode;
					AliceBind.MouseBuggySteeringXDecay = UserBind.MouseBuggySteeringXDecay;
					AliceBind.MouseBuggyRollingXMode = UserBind.MouseBuggyRollingXMode;
					AliceBind.MouseBuggyRollingXDecay = UserBind.MouseBuggyRollingXDecay;
					AliceBind.MouseBuggyYMode = UserBind.MouseBuggyYMode;
					AliceBind.MouseBuggyYDecay = UserBind.MouseBuggyYDecay;
					AliceBind.SteeringAxis = UserBind.SteeringAxis;
					AliceBind.SteerLeftButton.Primary = UserBind.SteerLeftButton.Primary;
					AliceBind.SteerRightButton.Primary = UserBind.SteerRightButton.Primary;
					AliceBind.BuggyRollAxisRaw = UserBind.BuggyRollAxisRaw;
					AliceBind.BuggyRollLeftButton.Primary = UserBind.BuggyRollLeftButton.Primary;
					AliceBind.BuggyRollRightButton.Primary = UserBind.BuggyRollRightButton.Primary;
					AliceBind.BuggyPitchAxis = UserBind.BuggyPitchAxis;
					AliceBind.BuggyPitchUpButton.Primary = UserBind.BuggyPitchUpButton.Primary;
					AliceBind.BuggyPitchDownButton.Primary = UserBind.BuggyPitchDownButton.Primary;
					AliceBind.VerticalThrustersButton.Primary = UserBind.VerticalThrustersButton.Primary;
					AliceBind.VerticalThrustersButton.ToggleOn = UserBind.VerticalThrustersButton.ToggleOn;
					AliceBind.BuggyPrimaryFireButton.Primary = UserBind.BuggyPrimaryFireButton.Primary;
					AliceBind.BuggySecondaryFireButton.Primary = UserBind.BuggySecondaryFireButton.Primary;
					AliceBind.AutoBreakBuggyButton.Primary = UserBind.AutoBreakBuggyButton.Primary;
					AliceBind.AutoBreakBuggyButton.ToggleOn = UserBind.AutoBreakBuggyButton.ToggleOn;
					AliceBind.HeadlightsBuggyButton.Primary = UserBind.HeadlightsBuggyButton.Primary;
					AliceBind.ToggleBuggyTurretButton.Primary = UserBind.ToggleBuggyTurretButton.Primary;
					AliceBind.SelectTarget_Buggy.Primary = UserBind.SelectTarget_Buggy.Primary;
					AliceBind.MouseTurretXMode = UserBind.MouseTurretXMode;
					AliceBind.MouseTurretXDecay = UserBind.MouseTurretXDecay;
					AliceBind.MouseTurretYMode = UserBind.MouseTurretYMode;
					AliceBind.MouseTurretYDecay = UserBind.MouseTurretYDecay;
					AliceBind.BuggyTurretYawAxisRaw = UserBind.BuggyTurretYawAxisRaw;
					AliceBind.BuggyTurretYawLeftButton.Primary = UserBind.BuggyTurretYawLeftButton.Primary;
					AliceBind.BuggyTurretYawRightButton.Primary = UserBind.BuggyTurretYawRightButton.Primary;
					AliceBind.BuggyTurretPitchAxisRaw = UserBind.BuggyTurretPitchAxisRaw;
					AliceBind.BuggyTurretPitchUpButton.Primary = UserBind.BuggyTurretPitchUpButton.Primary;
					AliceBind.BuggyTurretPitchDownButton.Primary = UserBind.BuggyTurretPitchDownButton.Primary;
					AliceBind.DriveSpeedAxis = UserBind.DriveSpeedAxis;
					AliceBind.BuggyThrottleRange = UserBind.BuggyThrottleRange;
					AliceBind.BuggyToggleReverseThrottleInput.Primary = UserBind.BuggyToggleReverseThrottleInput.Primary;
					AliceBind.BuggyToggleReverseThrottleInput.ToggleOn = UserBind.BuggyToggleReverseThrottleInput.ToggleOn;
					AliceBind.BuggyThrottleIncrement = UserBind.BuggyThrottleIncrement;
					AliceBind.IncreaseSpeedButtonMax.Primary = UserBind.IncreaseSpeedButtonMax.Primary;
					AliceBind.DecreaseSpeedButtonMax.Primary = UserBind.DecreaseSpeedButtonMax.Primary;
					AliceBind.IncreaseSpeedButtonPartial = UserBind.IncreaseSpeedButtonPartial;
					AliceBind.DecreaseSpeedButtonPartial = UserBind.DecreaseSpeedButtonPartial;
					AliceBind.IncreaseEnginesPower_Buggy.Primary = UserBind.IncreaseEnginesPower_Buggy.Primary;
					AliceBind.IncreaseWeaponsPower_Buggy.Primary = UserBind.IncreaseWeaponsPower_Buggy.Primary;
					AliceBind.IncreaseSystemsPower_Buggy.Primary = UserBind.IncreaseSystemsPower_Buggy.Primary;
					AliceBind.ResetPowerDistribution_Buggy.Primary = UserBind.ResetPowerDistribution_Buggy.Primary;
					AliceBind.ToggleCargoScoop_Buggy.Primary = UserBind.ToggleCargoScoop_Buggy.Primary;
					AliceBind.ToggleCargoScoop_Buggy.ToggleOn = UserBind.ToggleCargoScoop_Buggy.ToggleOn;
					AliceBind.EjectAllCargo_Buggy.Primary = UserBind.EjectAllCargo_Buggy.Primary;
					AliceBind.RecallDismissShip.Primary = UserBind.RecallDismissShip.Primary;
					AliceBind.UIFocus_Buggy.Primary = UserBind.UIFocus_Buggy.Primary;
					AliceBind.FocusLeftPanel_Buggy.Primary = UserBind.FocusLeftPanel_Buggy.Primary;
					AliceBind.FocusCommsPanel_Buggy.Primary = UserBind.FocusCommsPanel_Buggy.Primary;
					AliceBind.QuickCommsPanel_Buggy.Primary = UserBind.QuickCommsPanel_Buggy.Primary;
					AliceBind.FocusRadarPanel_Buggy.Primary = UserBind.FocusRadarPanel_Buggy.Primary;
					AliceBind.FocusRightPanel_Buggy.Primary = UserBind.FocusRightPanel_Buggy.Primary;
					AliceBind.GalaxyMapOpen_Buggy.Primary = UserBind.GalaxyMapOpen_Buggy.Primary;
					AliceBind.SystemMapOpen_Buggy.Primary = UserBind.SystemMapOpen_Buggy.Primary;
					AliceBind.HeadLookToggle_Buggy.Primary = UserBind.HeadLookToggle_Buggy.Primary;
					AliceBind.HeadLookToggle_Buggy.ToggleOn = UserBind.HeadLookToggle_Buggy.ToggleOn;
					AliceBind.MultiCrewToggleMode.Primary = UserBind.MultiCrewToggleMode.Primary;
					AliceBind.MultiCrewPrimaryFire.Primary = UserBind.MultiCrewPrimaryFire.Primary;
					AliceBind.MultiCrewSecondaryFire.Primary = UserBind.MultiCrewSecondaryFire.Primary;
					AliceBind.MultiCrewPrimaryUtilityFire.Primary = UserBind.MultiCrewPrimaryUtilityFire.Primary;
					AliceBind.MultiCrewSecondaryUtilityFire.Primary = UserBind.MultiCrewSecondaryUtilityFire.Primary;
					AliceBind.MultiCrewThirdPersonMouseXMode = UserBind.MultiCrewThirdPersonMouseXMode;
					AliceBind.MultiCrewThirdPersonMouseXDecay = UserBind.MultiCrewThirdPersonMouseXDecay;
					AliceBind.MultiCrewThirdPersonMouseYMode = UserBind.MultiCrewThirdPersonMouseYMode;
					AliceBind.MultiCrewThirdPersonMouseYDecay = UserBind.MultiCrewThirdPersonMouseYDecay;
					AliceBind.MultiCrewThirdPersonYawAxisRaw = UserBind.MultiCrewThirdPersonYawAxisRaw;
					AliceBind.MultiCrewThirdPersonYawLeftButton.Primary = UserBind.MultiCrewThirdPersonYawLeftButton.Primary;
					AliceBind.MultiCrewThirdPersonYawRightButton.Primary = UserBind.MultiCrewThirdPersonYawRightButton.Primary;
					AliceBind.MultiCrewThirdPersonPitchAxisRaw = UserBind.MultiCrewThirdPersonPitchAxisRaw;
					AliceBind.MultiCrewThirdPersonPitchUpButton.Primary = UserBind.MultiCrewThirdPersonPitchUpButton.Primary;
					AliceBind.MultiCrewThirdPersonPitchDownButton.Primary = UserBind.MultiCrewThirdPersonPitchDownButton.Primary;
					AliceBind.MultiCrewThirdPersonMouseSensitivity = UserBind.MultiCrewThirdPersonMouseSensitivity;
					AliceBind.MultiCrewThirdPersonFovAxisRaw = UserBind.MultiCrewThirdPersonFovAxisRaw;
					AliceBind.MultiCrewThirdPersonFovOutButton.Primary = UserBind.MultiCrewThirdPersonFovOutButton.Primary;
					AliceBind.MultiCrewThirdPersonFovInButton.Primary = UserBind.MultiCrewThirdPersonFovInButton.Primary;
					AliceBind.MultiCrewCockpitUICycleForward.Primary = UserBind.MultiCrewCockpitUICycleForward.Primary;
					AliceBind.MultiCrewCockpitUICycleBackward.Primary = UserBind.MultiCrewCockpitUICycleBackward.Primary;
					AliceBind.OrderRequestDock.Primary = UserBind.OrderRequestDock.Primary;
					AliceBind.OrderDefensiveBehaviour.Primary = UserBind.OrderDefensiveBehaviour.Primary;
					AliceBind.OrderAggressiveBehaviour.Primary = UserBind.OrderAggressiveBehaviour.Primary;
					AliceBind.OrderFocusTarget.Primary = UserBind.OrderFocusTarget.Primary;
					AliceBind.OrderHoldFire.Primary = UserBind.OrderHoldFire.Primary;
					AliceBind.OrderHoldPosition.Primary = UserBind.OrderHoldPosition.Primary;
					AliceBind.OrderFollow.Primary = UserBind.OrderFollow.Primary;
					AliceBind.OpenOrders.Primary = UserBind.OpenOrders.Primary;
					AliceBind.PhotoCameraToggle.Primary = UserBind.PhotoCameraToggle.Primary;
					AliceBind.PhotoCameraToggle_Buggy.Primary = UserBind.PhotoCameraToggle_Buggy.Primary;
					AliceBind.VanityCameraScrollLeft.Primary = UserBind.VanityCameraScrollLeft.Primary;
					AliceBind.VanityCameraScrollRight.Primary = UserBind.VanityCameraScrollRight.Primary;
					AliceBind.ToggleFreeCam.Primary = UserBind.ToggleFreeCam.Primary;
					AliceBind.VanityCameraOne.Primary = UserBind.VanityCameraOne.Primary;
					AliceBind.VanityCameraTwo.Primary = UserBind.VanityCameraTwo.Primary;
					AliceBind.VanityCameraThree.Primary = UserBind.VanityCameraThree.Primary;
					AliceBind.VanityCameraFour.Primary = UserBind.VanityCameraFour.Primary;
					AliceBind.VanityCameraFive.Primary = UserBind.VanityCameraFive.Primary;
					AliceBind.VanityCameraSix.Primary = UserBind.VanityCameraSix.Primary;
					AliceBind.VanityCameraSeven.Primary = UserBind.VanityCameraSeven.Primary;
					AliceBind.VanityCameraEight.Primary = UserBind.VanityCameraEight.Primary;
					AliceBind.VanityCameraNine.Primary = UserBind.VanityCameraNine.Primary;
					AliceBind.FreeCamToggleHUD.Primary = UserBind.FreeCamToggleHUD.Primary;
					AliceBind.FreeCamSpeedInc.Primary = UserBind.FreeCamSpeedInc.Primary;
					AliceBind.FreeCamSpeedDec.Primary = UserBind.FreeCamSpeedDec.Primary;
					AliceBind.MoveFreeCamY = UserBind.MoveFreeCamY;
					AliceBind.ThrottleRangeFreeCam = UserBind.ThrottleRangeFreeCam;
					AliceBind.ToggleReverseThrottleInputFreeCam.Primary = UserBind.ToggleReverseThrottleInputFreeCam.Primary;
					AliceBind.ToggleReverseThrottleInputFreeCam.ToggleOn = UserBind.ToggleReverseThrottleInputFreeCam.ToggleOn;
					AliceBind.MoveFreeCamForward.Primary = UserBind.MoveFreeCamForward.Primary;
					AliceBind.MoveFreeCamBackwards.Primary = UserBind.MoveFreeCamBackwards.Primary;
					AliceBind.MoveFreeCamX = UserBind.MoveFreeCamX;
					AliceBind.MoveFreeCamRight.Primary = UserBind.MoveFreeCamRight.Primary;
					AliceBind.MoveFreeCamLeft.Primary = UserBind.MoveFreeCamLeft.Primary;
					AliceBind.MoveFreeCamZ = UserBind.MoveFreeCamZ;
					AliceBind.MoveFreeCamUpAxis = UserBind.MoveFreeCamUpAxis;
					AliceBind.MoveFreeCamDownAxis = UserBind.MoveFreeCamDownAxis;
					AliceBind.MoveFreeCamUp.Primary = UserBind.MoveFreeCamUp.Primary;
					AliceBind.MoveFreeCamDown.Primary = UserBind.MoveFreeCamDown.Primary;
					AliceBind.PitchCameraMouse = UserBind.PitchCameraMouse;
					AliceBind.YawCameraMouse = UserBind.YawCameraMouse;
					AliceBind.PitchCamera = UserBind.PitchCamera;
					AliceBind.FreeCamMouseSensitivity = UserBind.FreeCamMouseSensitivity;
					AliceBind.FreeCamMouseYDecay = UserBind.FreeCamMouseYDecay;
					AliceBind.PitchCameraUp.Primary = UserBind.PitchCameraUp.Primary;
					AliceBind.PitchCameraDown.Primary = UserBind.PitchCameraDown.Primary;
					AliceBind.YawCamera = UserBind.YawCamera;
					AliceBind.FreeCamMouseXDecay = UserBind.FreeCamMouseXDecay;
					AliceBind.YawCameraLeft.Primary = UserBind.YawCameraLeft.Primary;
					AliceBind.YawCameraRight.Primary = UserBind.YawCameraRight.Primary;
					AliceBind.RollCamera = UserBind.RollCamera;
					AliceBind.RollCameraLeft.Primary = UserBind.RollCameraLeft.Primary;
					AliceBind.RollCameraRight.Primary = UserBind.RollCameraRight.Primary;
					AliceBind.ToggleRotationLock.Primary = UserBind.ToggleRotationLock.Primary;
					AliceBind.FixCameraRelativeToggle.Primary = UserBind.FixCameraRelativeToggle.Primary;
					AliceBind.FixCameraWorldToggle.Primary = UserBind.FixCameraWorldToggle.Primary;
					AliceBind.QuitCamera.Primary = UserBind.QuitCamera.Primary;
					AliceBind.ToggleAdvanceMode.Primary = UserBind.ToggleAdvanceMode.Primary;
					AliceBind.FreeCamZoomIn.Primary = UserBind.FreeCamZoomIn.Primary;
					AliceBind.FreeCamZoomOut.Primary = UserBind.FreeCamZoomOut.Primary;
					AliceBind.FStopDec.Primary = UserBind.FStopDec.Primary;
					AliceBind.FStopInc.Primary = UserBind.FStopInc.Primary;
					AliceBind.CommanderCreator_Undo.Primary = UserBind.CommanderCreator_Undo.Primary;
					AliceBind.CommanderCreator_Redo.Primary = UserBind.CommanderCreator_Redo.Primary;
					AliceBind.CommanderCreator_Rotation_MouseToggle.Primary = UserBind.CommanderCreator_Rotation_MouseToggle.Primary;
					AliceBind.CommanderCreator_Rotation = UserBind.CommanderCreator_Rotation;
					#endregion

					AliceBind.NightVisionToggle.Primary = UserBind.NightVisionToggle.Primary;
					AliceBind.OpenCodexGoToDiscovery.Primary = UserBind.OpenCodexGoToDiscovery.Primary;
					AliceBind.PlayerHUDModeToggle.Primary = UserBind.PlayerHUDModeToggle.Primary;
					AliceBind.CycleNextPage.Primary = UserBind.CycleNextPage.Primary;
					AliceBind.CyclePreviousPage.Primary = UserBind.CyclePreviousPage.Primary;


					try
					{
						AliceBinds = XmlControl.Serialize(AliceBind);
						AliceBinds.Save(Paths.ALICE_BindsPath);
					}
					catch (Exception ex)
					{
						Logger.Exception(MethodName, "Excception: " + ex);
						Logger.Exception(MethodName, "An Error Occured While Trying To Save Your New Binds File. Please Try Again...");
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Exception(MethodName, "Excception: " + ex);
				Logger.Exception(MethodName, "An Error Occured While Generating Your New Binds File.");
			}

			Logger.Log(MethodName, "Sucessfully Imported User Keybinds.", Logger.Purple);
		}

		public class Bind
		{
			public string Name { get; set; }
			public string Key1 { get; set; }
			public string Key2 { get; set; }
			public string Key3 { get; set; }
			public string Key4 { get; set; }

			public Bind() { }
		}
	}

	#region Serialize / Deserialize
	public class XmlControl
	{
		/// <summary>
		/// Deserializes an xml document back into an object
		/// </summary>
		/// <param name="xml">The xml data to deserialize</param>
		/// <param name="type">The type of the object being deserialized</param>
		/// <returns>A deserialized object</returns>
		public static object Deserialize(XmlDocument xml)
		{
			XmlSerializer Serializer = new XmlSerializer(typeof(Root));
			string xmlString = xml.OuterXml.ToString();
			byte[] buffer = ASCIIEncoding.UTF8.GetBytes(xmlString);
			MemoryStream ms = new MemoryStream(buffer);
			//XmlReader Reader = new XmlTextReader(ms);
			try
			{
				Root Binds = (Root)Serializer.Deserialize(ms);
				return Binds;
			}

			catch (Exception ex)
			{

			}
			finally
			{
				//Reader.Close();
			}
			return null;
		}

		/// <summary>
		/// Serializes an object into an Xml Document
		/// </summary>
		/// <param name="o">The object to serialize</param>
		/// <returns>An Xml Document consisting of said object's data</returns>
		public static XmlDocument Serialize(Root Binds)
		{
			XmlSerializer Serializer = new XmlSerializer(typeof(Root));

			MemoryStream Stream = new MemoryStream();
			XmlTextWriter Writer = new XmlTextWriter(Stream, new UTF8Encoding())
			{
				Formatting = Formatting.Indented,
				IndentChar = ' ',
				Indentation = 5
			};

			try
			{
				Serializer.Serialize(Writer, Binds);
				XmlDocument xml = new XmlDocument();
				string xmlString = ASCIIEncoding.UTF8.GetString(Stream.ToArray());
				xml.LoadXml(xmlString);
				return xml;
			}
			catch (Exception ex)
			{

			}
			finally
			{
				Writer.Close();
				Stream.Close();
			}
			return null;
		}


		#region Elements
		[XmlRoot(ElementName = "MouseXMode")]
		public class MouseXMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseXDecay")]
		public class MouseXDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseYMode")]
		public class MouseYMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseYDecay")]
		public class MouseYDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Primary")]
		public class Primary
		{
			[XmlAttribute(AttributeName = "Device")]
			public string Device { get; set; }
			[XmlAttribute(AttributeName = "Key")]
			public string Key { get; set; }
			[XmlAttribute(AttributeName = "DeviceIndex")]
			public string DeviceIndex { get; set; }
			[XmlElement(ElementName = "Modifier")]
			public List<Modifier> Modifier { get; set; }
		}

		[XmlRoot(ElementName = "Secondary")]
		public class Secondary
		{
			[XmlAttribute(AttributeName = "Device")]
			public string Device { get; set; }
			[XmlAttribute(AttributeName = "Key")]
			public string Key { get; set; }
			[XmlElement(ElementName = "Modifier")]
			public Modifier Modifier { get; set; }
		}

		[XmlRoot(ElementName = "MouseReset")]
		public class MouseReset
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MouseSensitivity")]
		public class MouseSensitivity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseDecayRate")]
		public class MouseDecayRate
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseDeadzone")]
		public class MouseDeadzone
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseLinearity")]
		public class MouseLinearity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseGUI")]
		public class MouseGUI
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Binding")]
		public class Binding
		{
			[XmlAttribute(AttributeName = "Device")]
			public string Device { get; set; }
			[XmlAttribute(AttributeName = "DeviceIndex")]
			public string DeviceIndex { get; set; }
			[XmlAttribute(AttributeName = "Key")]
			public string Key { get; set; }
		}

		[XmlRoot(ElementName = "Inverted")]
		public class Inverted
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Deadzone")]
		public class Deadzone
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "YawAxisRaw")]
		public class YawAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "YawLeftButton")]
		public class YawLeftButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "YawRightButton")]
		public class YawRightButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "YawToRollMode")]
		public class YawToRollMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "YawToRollSensitivity")]
		public class YawToRollSensitivity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "YawToRollMode_FAOff")]
		public class YawToRollMode_FAOff
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "ToggleOn")]
		public class ToggleOn
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "YawToRollButton")]
		public class YawToRollButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "RollAxisRaw")]
		public class RollAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "RollLeftButton")]
		public class RollLeftButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "RollRightButton")]
		public class RollRightButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "PitchAxisRaw")]
		public class PitchAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "PitchUpButton")]
		public class PitchUpButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "PitchDownButton")]
		public class PitchDownButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "LateralThrustRaw")]
		public class LateralThrustRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "LeftThrustButton")]
		public class LeftThrustButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "RightThrustButton")]
		public class RightThrustButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VerticalThrustRaw")]
		public class VerticalThrustRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "UpThrustButton")]
		public class UpThrustButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "DownThrustButton")]
		public class DownThrustButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "AheadThrust")]
		public class AheadThrust
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "ForwardThrustButton")]
		public class ForwardThrustButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BackwardThrustButton")]
		public class BackwardThrustButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UseAlternateFlightValuesToggle")]
		public class UseAlternateFlightValuesToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "YawAxisAlternate")]
		public class YawAxisAlternate
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "RollAxisAlternate")]
		public class RollAxisAlternate
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "PitchAxisAlternate")]
		public class PitchAxisAlternate
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "LateralThrustAlternate")]
		public class LateralThrustAlternate
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "VerticalThrustAlternate")]
		public class VerticalThrustAlternate
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "ThrottleAxis")]
		public class ThrottleAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "ThrottleRange")]
		public class ThrottleRange
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Modifier")]
		public class Modifier
		{
			[XmlAttribute(AttributeName = "Device")]
			public string Device { get; set; }
			[XmlAttribute(AttributeName = "Key")]
			public string Key { get; set; }
		}

		[XmlRoot(ElementName = "ToggleReverseThrottleInput")]
		public class ToggleReverseThrottleInput
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "ForwardKey")]
		public class ForwardKey
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BackwardKey")]
		public class BackwardKey
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ThrottleIncrement")]
		public class ThrottleIncrement
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "SetSpeedMinus100")]
		public class SetSpeedMinus100
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SetSpeedMinus75")]
		public class SetSpeedMinus75
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SetSpeedMinus50")]
		public class SetSpeedMinus50
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SetSpeedMinus25")]
		public class SetSpeedMinus25
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SetSpeedZero")]
		public class SetSpeedZero
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SetSpeed25")]
		public class SetSpeed25
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SetSpeed50")]
		public class SetSpeed50
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SetSpeed75")]
		public class SetSpeed75
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SetSpeed100")]
		public class SetSpeed100
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "YawAxis_Landing")]
		public class YawAxis_Landing
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "YawLeftButton_Landing")]
		public class YawLeftButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "YawRightButton_Landing")]
		public class YawRightButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "YawToRollMode_Landing")]
		public class YawToRollMode_Landing
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "PitchAxis_Landing")]
		public class PitchAxis_Landing
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "PitchUpButton_Landing")]
		public class PitchUpButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "PitchDownButton_Landing")]
		public class PitchDownButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "RollAxis_Landing")]
		public class RollAxis_Landing
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "RollLeftButton_Landing")]
		public class RollLeftButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "RollRightButton_Landing")]
		public class RollRightButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "LateralThrust_Landing")]
		public class LateralThrust_Landing
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "LeftThrustButton_Landing")]
		public class LeftThrustButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "RightThrustButton_Landing")]
		public class RightThrustButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VerticalThrust_Landing")]
		public class VerticalThrust_Landing
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "UpThrustButton_Landing")]
		public class UpThrustButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "DownThrustButton_Landing")]
		public class DownThrustButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "AheadThrust_Landing")]
		public class AheadThrust_Landing
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "ForwardThrustButton_Landing")]
		public class ForwardThrustButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BackwardThrustButton_Landing")]
		public class BackwardThrustButton_Landing
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ToggleFlightAssist")]
		public class ToggleFlightAssist
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "UseBoostJuice")]
		public class UseBoostJuice
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "HyperSuperCombination")]
		public class HyperSuperCombination
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "Supercruise")]
		public class Supercruise
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "Hyperspace")]
		public class Hyperspace
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "DisableRotationCorrectToggle")]
		public class DisableRotationCorrectToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "OrbitLinesToggle")]
		public class OrbitLinesToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SelectTarget")]
		public class SelectTarget
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CycleNextTarget")]
		public class CycleNextTarget
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CyclePreviousTarget")]
		public class CyclePreviousTarget
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SelectHighestThreat")]
		public class SelectHighestThreat
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CycleNextHostileTarget")]
		public class CycleNextHostileTarget
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CyclePreviousHostileTarget")]
		public class CyclePreviousHostileTarget
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "TargetWingman0")]
		public class TargetWingman0
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "TargetWingman1")]
		public class TargetWingman1
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "TargetWingman2")]
		public class TargetWingman2
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SelectTargetsTarget")]
		public class SelectTargetsTarget
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "WingNavLock")]
		public class WingNavLock
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CycleNextSubsystem")]
		public class CycleNextSubsystem
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CyclePreviousSubsystem")]
		public class CyclePreviousSubsystem
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "TargetNextRouteSystem")]
		public class TargetNextRouteSystem
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "PrimaryFire")]
		public class PrimaryFire
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SecondaryFire")]
		public class SecondaryFire
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CycleFireGroupNext")]
		public class CycleFireGroupNext
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CycleFireGroupPrevious")]
		public class CycleFireGroupPrevious
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "DeployHardpointToggle")]
		public class DeployHardpointToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "DeployHardpointsOnFire")]
		public class DeployHardpointsOnFire
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "ToggleButtonUpInput")]
		public class ToggleButtonUpInput
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "DeployHeatSink")]
		public class DeployHeatSink
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ShipSpotLightToggle")]
		public class ShipSpotLightToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "RadarRangeAxis")]
		public class RadarRangeAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "RadarIncreaseRange")]
		public class RadarIncreaseRange
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "RadarDecreaseRange")]
		public class RadarDecreaseRange
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "IncreaseEnginesPower")]
		public class IncreaseEnginesPower
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "IncreaseWeaponsPower")]
		public class IncreaseWeaponsPower
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "IncreaseSystemsPower")]
		public class IncreaseSystemsPower
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ResetPowerDistribution")]
		public class ResetPowerDistribution
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "HMDReset")]
		public class HMDReset
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ToggleCargoScoop")]
		public class ToggleCargoScoop
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "EjectAllCargo")]
		public class EjectAllCargo
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "LandingGearToggle")]
		public class LandingGearToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MicrophoneMute")]
		public class MicrophoneMute
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "MuteButtonMode")]
		public class MuteButtonMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "CqcMuteButtonMode")]
		public class CqcMuteButtonMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "UseShieldCell")]
		public class UseShieldCell
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FireChaffLauncher")]
		public class FireChaffLauncher
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ChargeECM")]
		public class ChargeECM
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "EnableRumbleTrigger")]
		public class EnableRumbleTrigger
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "EnableMenuGroups")]
		public class EnableMenuGroups
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "WeaponColourToggle")]
		public class WeaponColourToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "EngineColourToggle")]
		public class EngineColourToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "NightVisionToggle")]
		public class NightVisionToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UIFocus")]
		public class UIFocus
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UIFocusMode")]
		public class UIFocusMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "FocusLeftPanel")]
		public class FocusLeftPanel
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FocusCommsPanel")]
		public class FocusCommsPanel
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FocusOnTextEntryField")]
		public class FocusOnTextEntryField
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "QuickCommsPanel")]
		public class QuickCommsPanel
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FocusRadarPanel")]
		public class FocusRadarPanel
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FocusRightPanel")]
		public class FocusRightPanel
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "LeftPanelFocusOptions")]
		public class LeftPanelFocusOptions
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "CommsPanelFocusOptions")]
		public class CommsPanelFocusOptions
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "RolePanelFocusOptions")]
		public class RolePanelFocusOptions
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "RightPanelFocusOptions")]
		public class RightPanelFocusOptions
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "EnableCameraLockOn")]
		public class EnableCameraLockOn
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "GalaxyMapOpen")]
		public class GalaxyMapOpen
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SystemMapOpen")]
		public class SystemMapOpen
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ShowPGScoreSummaryInput")]
		public class ShowPGScoreSummaryInput
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "HeadLookToggle")]
		public class HeadLookToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "Pause")]
		public class Pause
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FriendsMenu")]
		public class FriendsMenu
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "OpenCodexGoToDiscovery")]
		public class OpenCodexGoToDiscovery
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "PlayerHUDModeToggle")]
		public class PlayerHUDModeToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UI_Up")]
		public class UI_Up
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UI_Down")]
		public class UI_Down
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UI_Left")]
		public class UI_Left
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UI_Right")]
		public class UI_Right
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UI_Select")]
		public class UI_Select
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UI_Back")]
		public class UI_Back
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UI_Toggle")]
		public class UI_Toggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CycleNextPanel")]
		public class CycleNextPanel
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CyclePreviousPanel")]
		public class CyclePreviousPanel
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CycleNextPage")]
		public class CycleNextPage
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CyclePreviousPage")]
		public class CyclePreviousPage
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MouseHeadlook")]
		public class MouseHeadlook
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseHeadlookInvert")]
		public class MouseHeadlookInvert
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseHeadlookSensitivity")]
		public class MouseHeadlookSensitivity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "HeadlookDefault")]
		public class HeadlookDefault
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "HeadlookIncrement")]
		public class HeadlookIncrement
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "HeadlookMode")]
		public class HeadlookMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "HeadlookResetOnToggle")]
		public class HeadlookResetOnToggle
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "HeadlookSensitivity")]
		public class HeadlookSensitivity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "HeadlookSmoothing")]
		public class HeadlookSmoothing
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "HeadLookReset")]
		public class HeadLookReset
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "HeadLookPitchUp")]
		public class HeadLookPitchUp
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "HeadLookPitchDown")]
		public class HeadLookPitchDown
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "HeadLookPitchAxisRaw")]
		public class HeadLookPitchAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "HeadLookYawLeft")]
		public class HeadLookYawLeft
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "HeadLookYawRight")]
		public class HeadLookYawRight
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "HeadLookYawAxis")]
		public class HeadLookYawAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "MotionHeadlook")]
		public class MotionHeadlook
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "HeadlookMotionSensitivity")]
		public class HeadlookMotionSensitivity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "yawRotateHeadlook")]
		public class YawRotateHeadlook
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "CamPitchAxis")]
		public class CamPitchAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "CamPitchUp")]
		public class CamPitchUp
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamPitchDown")]
		public class CamPitchDown
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamYawAxis")]
		public class CamYawAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "CamYawLeft")]
		public class CamYawLeft
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamYawRight")]
		public class CamYawRight
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamTranslateYAxis")]
		public class CamTranslateYAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "CamTranslateForward")]
		public class CamTranslateForward
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamTranslateBackward")]
		public class CamTranslateBackward
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamTranslateXAxis")]
		public class CamTranslateXAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "CamTranslateLeft")]
		public class CamTranslateLeft
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamTranslateRight")]
		public class CamTranslateRight
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamTranslateZAxis")]
		public class CamTranslateZAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "CamTranslateUp")]
		public class CamTranslateUp
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamTranslateDown")]
		public class CamTranslateDown
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamZoomAxis")]
		public class CamZoomAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "CamZoomIn")]
		public class CamZoomIn
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamZoomOut")]
		public class CamZoomOut
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CamTranslateZHold")]
		public class CamTranslateZHold
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "ToggleDriveAssist")]
		public class ToggleDriveAssist
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "DriveAssistDefault")]
		public class DriveAssistDefault
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseBuggySteeringXMode")]
		public class MouseBuggySteeringXMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseBuggySteeringXDecay")]
		public class MouseBuggySteeringXDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseBuggyRollingXMode")]
		public class MouseBuggyRollingXMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseBuggyRollingXDecay")]
		public class MouseBuggyRollingXDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseBuggyYMode")]
		public class MouseBuggyYMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseBuggyYDecay")]
		public class MouseBuggyYDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "SteeringAxis")]
		public class SteeringAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "SteerLeftButton")]
		public class SteerLeftButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SteerRightButton")]
		public class SteerRightButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BuggyRollAxisRaw")]
		public class BuggyRollAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "BuggyRollLeftButton")]
		public class BuggyRollLeftButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BuggyRollRightButton")]
		public class BuggyRollRightButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BuggyPitchAxis")]
		public class BuggyPitchAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "BuggyPitchUpButton")]
		public class BuggyPitchUpButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BuggyPitchDownButton")]
		public class BuggyPitchDownButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VerticalThrustersButton")]
		public class VerticalThrustersButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "BuggyPrimaryFireButton")]
		public class BuggyPrimaryFireButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BuggySecondaryFireButton")]
		public class BuggySecondaryFireButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "AutoBreakBuggyButton")]
		public class AutoBreakBuggyButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "HeadlightsBuggyButton")]
		public class HeadlightsBuggyButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ToggleBuggyTurretButton")]
		public class ToggleBuggyTurretButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SelectTarget_Buggy")]
		public class SelectTarget_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MouseTurretXMode")]
		public class MouseTurretXMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseTurretXDecay")]
		public class MouseTurretXDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseTurretYMode")]
		public class MouseTurretYMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MouseTurretYDecay")]
		public class MouseTurretYDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "BuggyTurretYawAxisRaw")]
		public class BuggyTurretYawAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "BuggyTurretYawLeftButton")]
		public class BuggyTurretYawLeftButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BuggyTurretYawRightButton")]
		public class BuggyTurretYawRightButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BuggyTurretPitchAxisRaw")]
		public class BuggyTurretPitchAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "BuggyTurretPitchUpButton")]
		public class BuggyTurretPitchUpButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "BuggyTurretPitchDownButton")]
		public class BuggyTurretPitchDownButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "DriveSpeedAxis")]
		public class DriveSpeedAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "BuggyThrottleRange")]
		public class BuggyThrottleRange
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "BuggyToggleReverseThrottleInput")]
		public class BuggyToggleReverseThrottleInput
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "BuggyThrottleIncrement")]
		public class BuggyThrottleIncrement
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "IncreaseSpeedButtonMax")]
		public class IncreaseSpeedButtonMax
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "DecreaseSpeedButtonMax")]
		public class DecreaseSpeedButtonMax
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "IncreaseSpeedButtonPartial")]
		public class IncreaseSpeedButtonPartial
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "DecreaseSpeedButtonPartial")]
		public class DecreaseSpeedButtonPartial
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "IncreaseEnginesPower_Buggy")]
		public class IncreaseEnginesPower_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "IncreaseWeaponsPower_Buggy")]
		public class IncreaseWeaponsPower_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "IncreaseSystemsPower_Buggy")]
		public class IncreaseSystemsPower_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ResetPowerDistribution_Buggy")]
		public class ResetPowerDistribution_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ToggleCargoScoop_Buggy")]
		public class ToggleCargoScoop_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "EjectAllCargo_Buggy")]
		public class EjectAllCargo_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "RecallDismissShip")]
		public class RecallDismissShip
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "UIFocus_Buggy")]
		public class UIFocus_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FocusLeftPanel_Buggy")]
		public class FocusLeftPanel_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FocusCommsPanel_Buggy")]
		public class FocusCommsPanel_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "QuickCommsPanel_Buggy")]
		public class QuickCommsPanel_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FocusRadarPanel_Buggy")]
		public class FocusRadarPanel_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FocusRightPanel_Buggy")]
		public class FocusRightPanel_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "GalaxyMapOpen_Buggy")]
		public class GalaxyMapOpen_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SystemMapOpen_Buggy")]
		public class SystemMapOpen_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "HeadLookToggle_Buggy")]
		public class HeadLookToggle_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewToggleMode")]
		public class MultiCrewToggleMode
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewPrimaryFire")]
		public class MultiCrewPrimaryFire
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewSecondaryFire")]
		public class MultiCrewSecondaryFire
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewPrimaryUtilityFire")]
		public class MultiCrewPrimaryUtilityFire
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewSecondaryUtilityFire")]
		public class MultiCrewSecondaryUtilityFire
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonMouseXMode")]
		public class MultiCrewThirdPersonMouseXMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonMouseXDecay")]
		public class MultiCrewThirdPersonMouseXDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonMouseYMode")]
		public class MultiCrewThirdPersonMouseYMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonMouseYDecay")]
		public class MultiCrewThirdPersonMouseYDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
		public class MultiCrewThirdPersonYawAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonYawLeftButton")]
		public class MultiCrewThirdPersonYawLeftButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonYawRightButton")]
		public class MultiCrewThirdPersonYawRightButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
		public class MultiCrewThirdPersonPitchAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonPitchUpButton")]
		public class MultiCrewThirdPersonPitchUpButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonPitchDownButton")]
		public class MultiCrewThirdPersonPitchDownButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
		public class MultiCrewThirdPersonMouseSensitivity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
		public class MultiCrewThirdPersonFovAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonFovOutButton")]
		public class MultiCrewThirdPersonFovOutButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewThirdPersonFovInButton")]
		public class MultiCrewThirdPersonFovInButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewCockpitUICycleForward")]
		public class MultiCrewCockpitUICycleForward
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MultiCrewCockpitUICycleBackward")]
		public class MultiCrewCockpitUICycleBackward
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "OrderRequestDock")]
		public class OrderRequestDock
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "OrderDefensiveBehaviour")]
		public class OrderDefensiveBehaviour
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "OrderAggressiveBehaviour")]
		public class OrderAggressiveBehaviour
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "OrderFocusTarget")]
		public class OrderFocusTarget
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "OrderHoldFire")]
		public class OrderHoldFire
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "OrderHoldPosition")]
		public class OrderHoldPosition
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "OrderFollow")]
		public class OrderFollow
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "OpenOrders")]
		public class OpenOrders
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "PhotoCameraToggle")]
		public class PhotoCameraToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "PhotoCameraToggle_Buggy")]
		public class PhotoCameraToggle_Buggy
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraScrollLeft")]
		public class VanityCameraScrollLeft
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraScrollRight")]
		public class VanityCameraScrollRight
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ToggleFreeCam")]
		public class ToggleFreeCam
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraOne")]
		public class VanityCameraOne
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraTwo")]
		public class VanityCameraTwo
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraThree")]
		public class VanityCameraThree
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraFour")]
		public class VanityCameraFour
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraFive")]
		public class VanityCameraFive
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraSix")]
		public class VanityCameraSix
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraSeven")]
		public class VanityCameraSeven
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraEight")]
		public class VanityCameraEight
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "VanityCameraNine")]
		public class VanityCameraNine
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FreeCamToggleHUD")]
		public class FreeCamToggleHUD
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FreeCamSpeedInc")]
		public class FreeCamSpeedInc
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FreeCamSpeedDec")]
		public class FreeCamSpeedDec
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamY")]
		public class MoveFreeCamY
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "ThrottleRangeFreeCam")]
		public class ThrottleRangeFreeCam
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "ToggleReverseThrottleInputFreeCam")]
		public class ToggleReverseThrottleInputFreeCam
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamForward")]
		public class MoveFreeCamForward
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamBackwards")]
		public class MoveFreeCamBackwards
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamX")]
		public class MoveFreeCamX
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamRight")]
		public class MoveFreeCamRight
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamLeft")]
		public class MoveFreeCamLeft
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamZ")]
		public class MoveFreeCamZ
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamUpAxis")]
		public class MoveFreeCamUpAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamDownAxis")]
		public class MoveFreeCamDownAxis
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamUp")]
		public class MoveFreeCamUp
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "MoveFreeCamDown")]
		public class MoveFreeCamDown
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "PitchCameraMouse")]
		public class PitchCameraMouse
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "YawCameraMouse")]
		public class YawCameraMouse
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "PitchCamera")]
		public class PitchCamera
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "FreeCamMouseSensitivity")]
		public class FreeCamMouseSensitivity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "FreeCamMouseYDecay")]
		public class FreeCamMouseYDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "PitchCameraUp")]
		public class PitchCameraUp
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "PitchCameraDown")]
		public class PitchCameraDown
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "YawCamera")]
		public class YawCamera
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "FreeCamMouseXDecay")]
		public class FreeCamMouseXDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "YawCameraLeft")]
		public class YawCameraLeft
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "YawCameraRight")]
		public class YawCameraRight
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "RollCamera")]
		public class RollCamera
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "RollCameraLeft")]
		public class RollCameraLeft
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "RollCameraRight")]
		public class RollCameraRight
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ToggleRotationLock")]
		public class ToggleRotationLock
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FixCameraRelativeToggle")]
		public class FixCameraRelativeToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FixCameraWorldToggle")]
		public class FixCameraWorldToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "QuitCamera")]
		public class QuitCamera
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ToggleAdvanceMode")]
		public class ToggleAdvanceMode
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FreeCamZoomIn")]
		public class FreeCamZoomIn
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FreeCamZoomOut")]
		public class FreeCamZoomOut
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FStopDec")]
		public class FStopDec
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FStopInc")]
		public class FStopInc
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CommanderCreator_Undo")]
		public class CommanderCreator_Undo
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CommanderCreator_Redo")]
		public class CommanderCreator_Redo
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CommanderCreator_Rotation_MouseToggle")]
		public class CommanderCreator_Rotation_MouseToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "CommanderCreator_Rotation")]
		public class CommanderCreator_Rotation
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "GalnetAudio_Play_Pause")]
		public class GalnetAudio_Play_Pause
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "GalnetAudio_SkipForward")]
		public class GalnetAudio_SkipForward
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "GalnetAudio_SkipBackward")]
		public class GalnetAudio_SkipBackward
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "GalnetAudio_ClearQueue")]
		public class GalnetAudio_ClearQueue
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSEnter")]
		public class ExplorationFSSEnter
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSCameraPitch")]
		public class ExplorationFSSCameraPitch
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSCameraPitchIncreaseButton")]
		public class ExplorationFSSCameraPitchIncreaseButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSCameraPitchDecreaseButton")]
		public class ExplorationFSSCameraPitchDecreaseButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSCameraYaw")]
		public class ExplorationFSSCameraYaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSCameraYawIncreaseButton")]
		public class ExplorationFSSCameraYawIncreaseButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSCameraYawDecreaseButton")]
		public class ExplorationFSSCameraYawDecreaseButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSZoomIn")]
		public class ExplorationFSSZoomIn
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSZoomOut")]
		public class ExplorationFSSZoomOut
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSMiniZoomIn")]
		public class ExplorationFSSMiniZoomIn
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSMiniZoomOut")]
		public class ExplorationFSSMiniZoomOut
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Raw")]
		public class ExplorationFSSRadioTuningX_Raw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Increase")]
		public class ExplorationFSSRadioTuningX_Increase
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Decrease")]
		public class ExplorationFSSRadioTuningX_Decrease
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSRadioTuningAbsoluteX")]
		public class ExplorationFSSRadioTuningAbsoluteX
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "FSSTuningSensitivity")]
		public class FSSTuningSensitivity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSDiscoveryScan")]
		public class ExplorationFSSDiscoveryScan
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSQuit")]
		public class ExplorationFSSQuit
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "FSSMouseXMode")]
		public class FSSMouseXMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "FSSMouseXDecay")]
		public class FSSMouseXDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "FSSMouseYMode")]
		public class FSSMouseYMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "FSSMouseYDecay")]
		public class FSSMouseYDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "FSSMouseSensitivity")]
		public class FSSMouseSensitivity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSTarget")]
		public class ExplorationFSSTarget
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationFSSShowHelp")]
		public class ExplorationFSSShowHelp
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationSAAChangeScannedAreaViewToggle")]
		public class ExplorationSAAChangeScannedAreaViewToggle
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
			[XmlElement(ElementName = "ToggleOn")]
			public ToggleOn ToggleOn { get; set; }
		}

		[XmlRoot(ElementName = "ExplorationSAAExitThirdPerson")]
		public class ExplorationSAAExitThirdPerson
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonMouseXMode")]
		public class SAAThirdPersonMouseXMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonMouseXDecay")]
		public class SAAThirdPersonMouseXDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonMouseYMode")]
		public class SAAThirdPersonMouseYMode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonMouseYDecay")]
		public class SAAThirdPersonMouseYDecay
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonMouseSensitivity")]
		public class SAAThirdPersonMouseSensitivity
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonYawAxisRaw")]
		public class SAAThirdPersonYawAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonYawLeftButton")]
		public class SAAThirdPersonYawLeftButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonYawRightButton")]
		public class SAAThirdPersonYawRightButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonPitchAxisRaw")]
		public class SAAThirdPersonPitchAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonPitchUpButton")]
		public class SAAThirdPersonPitchUpButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonPitchDownButton")]
		public class SAAThirdPersonPitchDownButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonFovAxisRaw")]
		public class SAAThirdPersonFovAxisRaw
		{
			[XmlElement(ElementName = "Binding")]
			public Binding Binding { get; set; }
			[XmlElement(ElementName = "Inverted")]
			public Inverted Inverted { get; set; }
			[XmlElement(ElementName = "Deadzone")]
			public Deadzone Deadzone { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonFovOutButton")]
		public class SAAThirdPersonFovOutButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}

		[XmlRoot(ElementName = "SAAThirdPersonFovInButton")]
		public class SAAThirdPersonFovInButton
		{
			[XmlElement(ElementName = "Primary")]
			public Primary Primary { get; set; }
			[XmlElement(ElementName = "Secondary")]
			public Secondary Secondary { get; set; }
		}
		#endregion

		[Serializable]
		[XmlRoot(ElementName = "Root")]
		public class Root
		{
			#region Orig Keybinds
			[XmlElement(ElementName = "KeyboardLayout")]
			public string KeyboardLayout { get; set; }
			[XmlElement(ElementName = "MouseXMode")]
			public MouseXMode MouseXMode { get; set; }
			[XmlElement(ElementName = "MouseXDecay")]
			public MouseXDecay MouseXDecay { get; set; }
			[XmlElement(ElementName = "MouseYMode")]
			public MouseYMode MouseYMode { get; set; }
			[XmlElement(ElementName = "MouseYDecay")]
			public MouseYDecay MouseYDecay { get; set; }
			[XmlElement(ElementName = "MouseReset")]
			public MouseReset MouseReset { get; set; }
			[XmlElement(ElementName = "MouseSensitivity")]
			public MouseSensitivity MouseSensitivity { get; set; }
			[XmlElement(ElementName = "MouseDecayRate")]
			public MouseDecayRate MouseDecayRate { get; set; }
			[XmlElement(ElementName = "MouseDeadzone")]
			public MouseDeadzone MouseDeadzone { get; set; }
			[XmlElement(ElementName = "MouseLinearity")]
			public MouseLinearity MouseLinearity { get; set; }
			[XmlElement(ElementName = "MouseGUI")]
			public List<MouseGUI> MouseGUI { get; set; }
			[XmlElement(ElementName = "YawAxisRaw")]
			public YawAxisRaw YawAxisRaw { get; set; }
			[XmlElement(ElementName = "YawLeftButton")]
			public YawLeftButton YawLeftButton { get; set; }
			[XmlElement(ElementName = "YawRightButton")]
			public YawRightButton YawRightButton { get; set; }
			[XmlElement(ElementName = "YawToRollMode")]
			public YawToRollMode YawToRollMode { get; set; }
			[XmlElement(ElementName = "YawToRollSensitivity")]
			public YawToRollSensitivity YawToRollSensitivity { get; set; }
			[XmlElement(ElementName = "YawToRollMode_FAOff")]
			public YawToRollMode_FAOff YawToRollMode_FAOff { get; set; }
			[XmlElement(ElementName = "YawToRollButton")]
			public YawToRollButton YawToRollButton { get; set; }
			[XmlElement(ElementName = "RollAxisRaw")]
			public RollAxisRaw RollAxisRaw { get; set; }
			[XmlElement(ElementName = "RollLeftButton")]
			public RollLeftButton RollLeftButton { get; set; }
			[XmlElement(ElementName = "RollRightButton")]
			public RollRightButton RollRightButton { get; set; }
			[XmlElement(ElementName = "PitchAxisRaw")]
			public PitchAxisRaw PitchAxisRaw { get; set; }
			[XmlElement(ElementName = "PitchUpButton")]
			public PitchUpButton PitchUpButton { get; set; }
			[XmlElement(ElementName = "PitchDownButton")]
			public PitchDownButton PitchDownButton { get; set; }
			[XmlElement(ElementName = "LateralThrustRaw")]
			public LateralThrustRaw LateralThrustRaw { get; set; }
			[XmlElement(ElementName = "LeftThrustButton")]
			public LeftThrustButton LeftThrustButton { get; set; }
			[XmlElement(ElementName = "RightThrustButton")]
			public RightThrustButton RightThrustButton { get; set; }
			[XmlElement(ElementName = "VerticalThrustRaw")]
			public VerticalThrustRaw VerticalThrustRaw { get; set; }
			[XmlElement(ElementName = "UpThrustButton")]
			public UpThrustButton UpThrustButton { get; set; }
			[XmlElement(ElementName = "DownThrustButton")]
			public DownThrustButton DownThrustButton { get; set; }
			[XmlElement(ElementName = "AheadThrust")]
			public AheadThrust AheadThrust { get; set; }
			[XmlElement(ElementName = "ForwardThrustButton")]
			public ForwardThrustButton ForwardThrustButton { get; set; }
			[XmlElement(ElementName = "BackwardThrustButton")]
			public BackwardThrustButton BackwardThrustButton { get; set; }
			[XmlElement(ElementName = "UseAlternateFlightValuesToggle")]
			public UseAlternateFlightValuesToggle UseAlternateFlightValuesToggle { get; set; }
			[XmlElement(ElementName = "YawAxisAlternate")]
			public YawAxisAlternate YawAxisAlternate { get; set; }
			[XmlElement(ElementName = "RollAxisAlternate")]
			public RollAxisAlternate RollAxisAlternate { get; set; }
			[XmlElement(ElementName = "PitchAxisAlternate")]
			public PitchAxisAlternate PitchAxisAlternate { get; set; }
			[XmlElement(ElementName = "LateralThrustAlternate")]
			public LateralThrustAlternate LateralThrustAlternate { get; set; }
			[XmlElement(ElementName = "VerticalThrustAlternate")]
			public VerticalThrustAlternate VerticalThrustAlternate { get; set; }
			[XmlElement(ElementName = "ThrottleAxis")]
			public ThrottleAxis ThrottleAxis { get; set; }
			[XmlElement(ElementName = "ThrottleRange")]
			public ThrottleRange ThrottleRange { get; set; }
			[XmlElement(ElementName = "ToggleReverseThrottleInput")]
			public ToggleReverseThrottleInput ToggleReverseThrottleInput { get; set; }
			[XmlElement(ElementName = "ForwardKey")]
			public ForwardKey ForwardKey { get; set; }
			[XmlElement(ElementName = "BackwardKey")]
			public BackwardKey BackwardKey { get; set; }
			[XmlElement(ElementName = "ThrottleIncrement")]
			public ThrottleIncrement ThrottleIncrement { get; set; }
			[XmlElement(ElementName = "SetSpeedMinus100")]
			public SetSpeedMinus100 SetSpeedMinus100 { get; set; }
			[XmlElement(ElementName = "SetSpeedMinus75")]
			public SetSpeedMinus75 SetSpeedMinus75 { get; set; }
			[XmlElement(ElementName = "SetSpeedMinus50")]
			public SetSpeedMinus50 SetSpeedMinus50 { get; set; }
			[XmlElement(ElementName = "SetSpeedMinus25")]
			public SetSpeedMinus25 SetSpeedMinus25 { get; set; }
			[XmlElement(ElementName = "SetSpeedZero")]
			public SetSpeedZero SetSpeedZero { get; set; }
			[XmlElement(ElementName = "SetSpeed25")]
			public SetSpeed25 SetSpeed25 { get; set; }
			[XmlElement(ElementName = "SetSpeed50")]
			public SetSpeed50 SetSpeed50 { get; set; }
			[XmlElement(ElementName = "SetSpeed75")]
			public SetSpeed75 SetSpeed75 { get; set; }
			[XmlElement(ElementName = "SetSpeed100")]
			public SetSpeed100 SetSpeed100 { get; set; }
			[XmlElement(ElementName = "YawAxis_Landing")]
			public YawAxis_Landing YawAxis_Landing { get; set; }
			[XmlElement(ElementName = "YawLeftButton_Landing")]
			public YawLeftButton_Landing YawLeftButton_Landing { get; set; }
			[XmlElement(ElementName = "YawRightButton_Landing")]
			public YawRightButton_Landing YawRightButton_Landing { get; set; }
			[XmlElement(ElementName = "YawToRollMode_Landing")]
			public YawToRollMode_Landing YawToRollMode_Landing { get; set; }
			[XmlElement(ElementName = "PitchAxis_Landing")]
			public PitchAxis_Landing PitchAxis_Landing { get; set; }
			[XmlElement(ElementName = "PitchUpButton_Landing")]
			public PitchUpButton_Landing PitchUpButton_Landing { get; set; }
			[XmlElement(ElementName = "PitchDownButton_Landing")]
			public PitchDownButton_Landing PitchDownButton_Landing { get; set; }
			[XmlElement(ElementName = "RollAxis_Landing")]
			public RollAxis_Landing RollAxis_Landing { get; set; }
			[XmlElement(ElementName = "RollLeftButton_Landing")]
			public RollLeftButton_Landing RollLeftButton_Landing { get; set; }
			[XmlElement(ElementName = "RollRightButton_Landing")]
			public RollRightButton_Landing RollRightButton_Landing { get; set; }
			[XmlElement(ElementName = "LateralThrust_Landing")]
			public LateralThrust_Landing LateralThrust_Landing { get; set; }
			[XmlElement(ElementName = "LeftThrustButton_Landing")]
			public LeftThrustButton_Landing LeftThrustButton_Landing { get; set; }
			[XmlElement(ElementName = "RightThrustButton_Landing")]
			public RightThrustButton_Landing RightThrustButton_Landing { get; set; }
			[XmlElement(ElementName = "VerticalThrust_Landing")]
			public VerticalThrust_Landing VerticalThrust_Landing { get; set; }
			[XmlElement(ElementName = "UpThrustButton_Landing")]
			public UpThrustButton_Landing UpThrustButton_Landing { get; set; }
			[XmlElement(ElementName = "DownThrustButton_Landing")]
			public DownThrustButton_Landing DownThrustButton_Landing { get; set; }
			[XmlElement(ElementName = "AheadThrust_Landing")]
			public AheadThrust_Landing AheadThrust_Landing { get; set; }
			[XmlElement(ElementName = "ForwardThrustButton_Landing")]
			public ForwardThrustButton_Landing ForwardThrustButton_Landing { get; set; }
			[XmlElement(ElementName = "BackwardThrustButton_Landing")]
			public BackwardThrustButton_Landing BackwardThrustButton_Landing { get; set; }
			[XmlElement(ElementName = "ToggleFlightAssist")]
			public ToggleFlightAssist ToggleFlightAssist { get; set; }
			[XmlElement(ElementName = "UseBoostJuice")]
			public UseBoostJuice UseBoostJuice { get; set; }
			[XmlElement(ElementName = "HyperSuperCombination")]
			public HyperSuperCombination HyperSuperCombination { get; set; }
			[XmlElement(ElementName = "Supercruise")]
			public Supercruise Supercruise { get; set; }
			[XmlElement(ElementName = "Hyperspace")]
			public Hyperspace Hyperspace { get; set; }
			[XmlElement(ElementName = "DisableRotationCorrectToggle")]
			public DisableRotationCorrectToggle DisableRotationCorrectToggle { get; set; }
			[XmlElement(ElementName = "OrbitLinesToggle")]
			public OrbitLinesToggle OrbitLinesToggle { get; set; }
			[XmlElement(ElementName = "SelectTarget")]
			public SelectTarget SelectTarget { get; set; }
			[XmlElement(ElementName = "CycleNextTarget")]
			public CycleNextTarget CycleNextTarget { get; set; }
			[XmlElement(ElementName = "CyclePreviousTarget")]
			public CyclePreviousTarget CyclePreviousTarget { get; set; }
			[XmlElement(ElementName = "SelectHighestThreat")]
			public SelectHighestThreat SelectHighestThreat { get; set; }
			[XmlElement(ElementName = "CycleNextHostileTarget")]
			public CycleNextHostileTarget CycleNextHostileTarget { get; set; }
			[XmlElement(ElementName = "CyclePreviousHostileTarget")]
			public CyclePreviousHostileTarget CyclePreviousHostileTarget { get; set; }
			[XmlElement(ElementName = "TargetWingman0")]
			public TargetWingman0 TargetWingman0 { get; set; }
			[XmlElement(ElementName = "TargetWingman1")]
			public TargetWingman1 TargetWingman1 { get; set; }
			[XmlElement(ElementName = "TargetWingman2")]
			public TargetWingman2 TargetWingman2 { get; set; }
			[XmlElement(ElementName = "SelectTargetsTarget")]
			public SelectTargetsTarget SelectTargetsTarget { get; set; }
			[XmlElement(ElementName = "WingNavLock")]
			public WingNavLock WingNavLock { get; set; }
			[XmlElement(ElementName = "CycleNextSubsystem")]
			public CycleNextSubsystem CycleNextSubsystem { get; set; }
			[XmlElement(ElementName = "CyclePreviousSubsystem")]
			public CyclePreviousSubsystem CyclePreviousSubsystem { get; set; }
			[XmlElement(ElementName = "TargetNextRouteSystem")]
			public TargetNextRouteSystem TargetNextRouteSystem { get; set; }
			[XmlElement(ElementName = "PrimaryFire")]
			public PrimaryFire PrimaryFire { get; set; }
			[XmlElement(ElementName = "SecondaryFire")]
			public SecondaryFire SecondaryFire { get; set; }
			[XmlElement(ElementName = "CycleFireGroupNext")]
			public CycleFireGroupNext CycleFireGroupNext { get; set; }
			[XmlElement(ElementName = "CycleFireGroupPrevious")]
			public CycleFireGroupPrevious CycleFireGroupPrevious { get; set; }
			[XmlElement(ElementName = "DeployHardpointToggle")]
			public DeployHardpointToggle DeployHardpointToggle { get; set; }
			[XmlElement(ElementName = "DeployHardpointsOnFire")]
			public DeployHardpointsOnFire DeployHardpointsOnFire { get; set; }
			[XmlElement(ElementName = "ToggleButtonUpInput")]
			public ToggleButtonUpInput ToggleButtonUpInput { get; set; }
			[XmlElement(ElementName = "DeployHeatSink")]
			public DeployHeatSink DeployHeatSink { get; set; }
			[XmlElement(ElementName = "ShipSpotLightToggle")]
			public ShipSpotLightToggle ShipSpotLightToggle { get; set; }
			[XmlElement(ElementName = "RadarRangeAxis")]
			public RadarRangeAxis RadarRangeAxis { get; set; }
			[XmlElement(ElementName = "RadarIncreaseRange")]
			public RadarIncreaseRange RadarIncreaseRange { get; set; }
			[XmlElement(ElementName = "RadarDecreaseRange")]
			public RadarDecreaseRange RadarDecreaseRange { get; set; }
			[XmlElement(ElementName = "IncreaseEnginesPower")]
			public IncreaseEnginesPower IncreaseEnginesPower { get; set; }
			[XmlElement(ElementName = "IncreaseWeaponsPower")]
			public IncreaseWeaponsPower IncreaseWeaponsPower { get; set; }
			[XmlElement(ElementName = "IncreaseSystemsPower")]
			public IncreaseSystemsPower IncreaseSystemsPower { get; set; }
			[XmlElement(ElementName = "ResetPowerDistribution")]
			public ResetPowerDistribution ResetPowerDistribution { get; set; }
			[XmlElement(ElementName = "HMDReset")]
			public HMDReset HMDReset { get; set; }
			[XmlElement(ElementName = "ToggleCargoScoop")]
			public ToggleCargoScoop ToggleCargoScoop { get; set; }
			[XmlElement(ElementName = "EjectAllCargo")]
			public EjectAllCargo EjectAllCargo { get; set; }
			[XmlElement(ElementName = "LandingGearToggle")]
			public LandingGearToggle LandingGearToggle { get; set; }
			[XmlElement(ElementName = "MicrophoneMute")]
			public MicrophoneMute MicrophoneMute { get; set; }
			[XmlElement(ElementName = "MuteButtonMode")]
			public MuteButtonMode MuteButtonMode { get; set; }
			[XmlElement(ElementName = "CqcMuteButtonMode")]
			public CqcMuteButtonMode CqcMuteButtonMode { get; set; }
			[XmlElement(ElementName = "UseShieldCell")]
			public UseShieldCell UseShieldCell { get; set; }
			[XmlElement(ElementName = "FireChaffLauncher")]
			public FireChaffLauncher FireChaffLauncher { get; set; }
			[XmlElement(ElementName = "ChargeECM")]
			public ChargeECM ChargeECM { get; set; }
			[XmlElement(ElementName = "EnableRumbleTrigger")]
			public EnableRumbleTrigger EnableRumbleTrigger { get; set; }
			[XmlElement(ElementName = "EnableMenuGroups")]
			public EnableMenuGroups EnableMenuGroups { get; set; }
			[XmlElement(ElementName = "WeaponColourToggle")]
			public WeaponColourToggle WeaponColourToggle { get; set; }
			[XmlElement(ElementName = "EngineColourToggle")]
			public EngineColourToggle EngineColourToggle { get; set; }
			[XmlElement(ElementName = "UIFocus")]
			public UIFocus UIFocus { get; set; }
			[XmlElement(ElementName = "UIFocusMode")]
			public UIFocusMode UIFocusMode { get; set; }
			[XmlElement(ElementName = "FocusLeftPanel")]
			public FocusLeftPanel FocusLeftPanel { get; set; }
			[XmlElement(ElementName = "FocusCommsPanel")]
			public FocusCommsPanel FocusCommsPanel { get; set; }
			[XmlElement(ElementName = "FocusOnTextEntryField")]
			public FocusOnTextEntryField FocusOnTextEntryField { get; set; }
			[XmlElement(ElementName = "QuickCommsPanel")]
			public QuickCommsPanel QuickCommsPanel { get; set; }
			[XmlElement(ElementName = "FocusRadarPanel")]
			public FocusRadarPanel FocusRadarPanel { get; set; }
			[XmlElement(ElementName = "FocusRightPanel")]
			public FocusRightPanel FocusRightPanel { get; set; }
			[XmlElement(ElementName = "LeftPanelFocusOptions")]
			public LeftPanelFocusOptions LeftPanelFocusOptions { get; set; }
			[XmlElement(ElementName = "CommsPanelFocusOptions")]
			public CommsPanelFocusOptions CommsPanelFocusOptions { get; set; }
			[XmlElement(ElementName = "RolePanelFocusOptions")]
			public RolePanelFocusOptions RolePanelFocusOptions { get; set; }
			[XmlElement(ElementName = "RightPanelFocusOptions")]
			public RightPanelFocusOptions RightPanelFocusOptions { get; set; }
			[XmlElement(ElementName = "EnableCameraLockOn")]
			public EnableCameraLockOn EnableCameraLockOn { get; set; }
			[XmlElement(ElementName = "GalaxyMapOpen")]
			public GalaxyMapOpen GalaxyMapOpen { get; set; }
			[XmlElement(ElementName = "SystemMapOpen")]
			public SystemMapOpen SystemMapOpen { get; set; }
			[XmlElement(ElementName = "ShowPGScoreSummaryInput")]
			public ShowPGScoreSummaryInput ShowPGScoreSummaryInput { get; set; }
			[XmlElement(ElementName = "HeadLookToggle")]
			public HeadLookToggle HeadLookToggle { get; set; }
			[XmlElement(ElementName = "Pause")]
			public Pause Pause { get; set; }
			[XmlElement(ElementName = "FriendsMenu")]
			public FriendsMenu FriendsMenu { get; set; }
			[XmlElement(ElementName = "UI_Up")]
			public UI_Up UI_Up { get; set; }
			[XmlElement(ElementName = "UI_Down")]
			public UI_Down UI_Down { get; set; }
			[XmlElement(ElementName = "UI_Left")]
			public UI_Left UI_Left { get; set; }
			[XmlElement(ElementName = "UI_Right")]
			public UI_Right UI_Right { get; set; }
			[XmlElement(ElementName = "UI_Select")]
			public UI_Select UI_Select { get; set; }
			[XmlElement(ElementName = "UI_Back")]
			public UI_Back UI_Back { get; set; }
			[XmlElement(ElementName = "UI_Toggle")]
			public UI_Toggle UI_Toggle { get; set; }
			[XmlElement(ElementName = "CycleNextPanel")]
			public CycleNextPanel CycleNextPanel { get; set; }
			[XmlElement(ElementName = "CyclePreviousPanel")]
			public CyclePreviousPanel CyclePreviousPanel { get; set; }
			[XmlElement(ElementName = "MouseHeadlook")]
			public MouseHeadlook MouseHeadlook { get; set; }
			[XmlElement(ElementName = "MouseHeadlookInvert")]
			public MouseHeadlookInvert MouseHeadlookInvert { get; set; }
			[XmlElement(ElementName = "MouseHeadlookSensitivity")]
			public MouseHeadlookSensitivity MouseHeadlookSensitivity { get; set; }
			[XmlElement(ElementName = "HeadlookDefault")]
			public HeadlookDefault HeadlookDefault { get; set; }
			[XmlElement(ElementName = "HeadlookIncrement")]
			public HeadlookIncrement HeadlookIncrement { get; set; }
			[XmlElement(ElementName = "HeadlookMode")]
			public HeadlookMode HeadlookMode { get; set; }
			[XmlElement(ElementName = "HeadlookResetOnToggle")]
			public HeadlookResetOnToggle HeadlookResetOnToggle { get; set; }
			[XmlElement(ElementName = "HeadlookSensitivity")]
			public HeadlookSensitivity HeadlookSensitivity { get; set; }
			[XmlElement(ElementName = "HeadlookSmoothing")]
			public HeadlookSmoothing HeadlookSmoothing { get; set; }
			[XmlElement(ElementName = "HeadLookReset")]
			public HeadLookReset HeadLookReset { get; set; }
			[XmlElement(ElementName = "HeadLookPitchUp")]
			public HeadLookPitchUp HeadLookPitchUp { get; set; }
			[XmlElement(ElementName = "HeadLookPitchDown")]
			public HeadLookPitchDown HeadLookPitchDown { get; set; }
			[XmlElement(ElementName = "HeadLookPitchAxisRaw")]
			public HeadLookPitchAxisRaw HeadLookPitchAxisRaw { get; set; }
			[XmlElement(ElementName = "HeadLookYawLeft")]
			public HeadLookYawLeft HeadLookYawLeft { get; set; }
			[XmlElement(ElementName = "HeadLookYawRight")]
			public HeadLookYawRight HeadLookYawRight { get; set; }
			[XmlElement(ElementName = "HeadLookYawAxis")]
			public HeadLookYawAxis HeadLookYawAxis { get; set; }
			[XmlElement(ElementName = "MotionHeadlook")]
			public MotionHeadlook MotionHeadlook { get; set; }
			[XmlElement(ElementName = "HeadlookMotionSensitivity")]
			public HeadlookMotionSensitivity HeadlookMotionSensitivity { get; set; }
			[XmlElement(ElementName = "yawRotateHeadlook")]
			public YawRotateHeadlook YawRotateHeadlook { get; set; }
			[XmlElement(ElementName = "CamPitchAxis")]
			public CamPitchAxis CamPitchAxis { get; set; }
			[XmlElement(ElementName = "CamPitchUp")]
			public CamPitchUp CamPitchUp { get; set; }
			[XmlElement(ElementName = "CamPitchDown")]
			public CamPitchDown CamPitchDown { get; set; }
			[XmlElement(ElementName = "CamYawAxis")]
			public CamYawAxis CamYawAxis { get; set; }
			[XmlElement(ElementName = "CamYawLeft")]
			public CamYawLeft CamYawLeft { get; set; }
			[XmlElement(ElementName = "CamYawRight")]
			public CamYawRight CamYawRight { get; set; }
			[XmlElement(ElementName = "CamTranslateYAxis")]
			public CamTranslateYAxis CamTranslateYAxis { get; set; }
			[XmlElement(ElementName = "CamTranslateForward")]
			public CamTranslateForward CamTranslateForward { get; set; }
			[XmlElement(ElementName = "CamTranslateBackward")]
			public CamTranslateBackward CamTranslateBackward { get; set; }
			[XmlElement(ElementName = "CamTranslateXAxis")]
			public CamTranslateXAxis CamTranslateXAxis { get; set; }
			[XmlElement(ElementName = "CamTranslateLeft")]
			public CamTranslateLeft CamTranslateLeft { get; set; }
			[XmlElement(ElementName = "CamTranslateRight")]
			public CamTranslateRight CamTranslateRight { get; set; }
			[XmlElement(ElementName = "CamTranslateZAxis")]
			public CamTranslateZAxis CamTranslateZAxis { get; set; }
			[XmlElement(ElementName = "CamTranslateUp")]
			public CamTranslateUp CamTranslateUp { get; set; }
			[XmlElement(ElementName = "CamTranslateDown")]
			public CamTranslateDown CamTranslateDown { get; set; }
			[XmlElement(ElementName = "CamZoomAxis")]
			public CamZoomAxis CamZoomAxis { get; set; }
			[XmlElement(ElementName = "CamZoomIn")]
			public CamZoomIn CamZoomIn { get; set; }
			[XmlElement(ElementName = "CamZoomOut")]
			public CamZoomOut CamZoomOut { get; set; }
			[XmlElement(ElementName = "CamTranslateZHold")]
			public CamTranslateZHold CamTranslateZHold { get; set; }
			[XmlElement(ElementName = "ToggleDriveAssist")]
			public ToggleDriveAssist ToggleDriveAssist { get; set; }
			[XmlElement(ElementName = "DriveAssistDefault")]
			public DriveAssistDefault DriveAssistDefault { get; set; }
			[XmlElement(ElementName = "MouseBuggySteeringXMode")]
			public MouseBuggySteeringXMode MouseBuggySteeringXMode { get; set; }
			[XmlElement(ElementName = "MouseBuggySteeringXDecay")]
			public MouseBuggySteeringXDecay MouseBuggySteeringXDecay { get; set; }
			[XmlElement(ElementName = "MouseBuggyRollingXMode")]
			public MouseBuggyRollingXMode MouseBuggyRollingXMode { get; set; }
			[XmlElement(ElementName = "MouseBuggyRollingXDecay")]
			public MouseBuggyRollingXDecay MouseBuggyRollingXDecay { get; set; }
			[XmlElement(ElementName = "MouseBuggyYMode")]
			public MouseBuggyYMode MouseBuggyYMode { get; set; }
			[XmlElement(ElementName = "MouseBuggyYDecay")]
			public MouseBuggyYDecay MouseBuggyYDecay { get; set; }
			[XmlElement(ElementName = "SteeringAxis")]
			public SteeringAxis SteeringAxis { get; set; }
			[XmlElement(ElementName = "SteerLeftButton")]
			public SteerLeftButton SteerLeftButton { get; set; }
			[XmlElement(ElementName = "SteerRightButton")]
			public SteerRightButton SteerRightButton { get; set; }
			[XmlElement(ElementName = "BuggyRollAxisRaw")]
			public BuggyRollAxisRaw BuggyRollAxisRaw { get; set; }
			[XmlElement(ElementName = "BuggyRollLeftButton")]
			public BuggyRollLeftButton BuggyRollLeftButton { get; set; }
			[XmlElement(ElementName = "BuggyRollRightButton")]
			public BuggyRollRightButton BuggyRollRightButton { get; set; }
			[XmlElement(ElementName = "BuggyPitchAxis")]
			public BuggyPitchAxis BuggyPitchAxis { get; set; }
			[XmlElement(ElementName = "BuggyPitchUpButton")]
			public BuggyPitchUpButton BuggyPitchUpButton { get; set; }
			[XmlElement(ElementName = "BuggyPitchDownButton")]
			public BuggyPitchDownButton BuggyPitchDownButton { get; set; }
			[XmlElement(ElementName = "VerticalThrustersButton")]
			public VerticalThrustersButton VerticalThrustersButton { get; set; }
			[XmlElement(ElementName = "BuggyPrimaryFireButton")]
			public BuggyPrimaryFireButton BuggyPrimaryFireButton { get; set; }
			[XmlElement(ElementName = "BuggySecondaryFireButton")]
			public BuggySecondaryFireButton BuggySecondaryFireButton { get; set; }
			[XmlElement(ElementName = "AutoBreakBuggyButton")]
			public AutoBreakBuggyButton AutoBreakBuggyButton { get; set; }
			[XmlElement(ElementName = "HeadlightsBuggyButton")]
			public HeadlightsBuggyButton HeadlightsBuggyButton { get; set; }
			[XmlElement(ElementName = "ToggleBuggyTurretButton")]
			public ToggleBuggyTurretButton ToggleBuggyTurretButton { get; set; }
			[XmlElement(ElementName = "SelectTarget_Buggy")]
			public SelectTarget_Buggy SelectTarget_Buggy { get; set; }
			[XmlElement(ElementName = "MouseTurretXMode")]
			public MouseTurretXMode MouseTurretXMode { get; set; }
			[XmlElement(ElementName = "MouseTurretXDecay")]
			public MouseTurretXDecay MouseTurretXDecay { get; set; }
			[XmlElement(ElementName = "MouseTurretYMode")]
			public MouseTurretYMode MouseTurretYMode { get; set; }
			[XmlElement(ElementName = "MouseTurretYDecay")]
			public MouseTurretYDecay MouseTurretYDecay { get; set; }
			[XmlElement(ElementName = "BuggyTurretYawAxisRaw")]
			public BuggyTurretYawAxisRaw BuggyTurretYawAxisRaw { get; set; }
			[XmlElement(ElementName = "BuggyTurretYawLeftButton")]
			public BuggyTurretYawLeftButton BuggyTurretYawLeftButton { get; set; }
			[XmlElement(ElementName = "BuggyTurretYawRightButton")]
			public BuggyTurretYawRightButton BuggyTurretYawRightButton { get; set; }
			[XmlElement(ElementName = "BuggyTurretPitchAxisRaw")]
			public BuggyTurretPitchAxisRaw BuggyTurretPitchAxisRaw { get; set; }
			[XmlElement(ElementName = "BuggyTurretPitchUpButton")]
			public BuggyTurretPitchUpButton BuggyTurretPitchUpButton { get; set; }
			[XmlElement(ElementName = "BuggyTurretPitchDownButton")]
			public BuggyTurretPitchDownButton BuggyTurretPitchDownButton { get; set; }
			[XmlElement(ElementName = "DriveSpeedAxis")]
			public DriveSpeedAxis DriveSpeedAxis { get; set; }
			[XmlElement(ElementName = "BuggyThrottleRange")]
			public BuggyThrottleRange BuggyThrottleRange { get; set; }
			[XmlElement(ElementName = "BuggyToggleReverseThrottleInput")]
			public BuggyToggleReverseThrottleInput BuggyToggleReverseThrottleInput { get; set; }
			[XmlElement(ElementName = "BuggyThrottleIncrement")]
			public BuggyThrottleIncrement BuggyThrottleIncrement { get; set; }
			[XmlElement(ElementName = "IncreaseSpeedButtonMax")]
			public IncreaseSpeedButtonMax IncreaseSpeedButtonMax { get; set; }
			[XmlElement(ElementName = "DecreaseSpeedButtonMax")]
			public DecreaseSpeedButtonMax DecreaseSpeedButtonMax { get; set; }
			[XmlElement(ElementName = "IncreaseSpeedButtonPartial")]
			public IncreaseSpeedButtonPartial IncreaseSpeedButtonPartial { get; set; }
			[XmlElement(ElementName = "DecreaseSpeedButtonPartial")]
			public DecreaseSpeedButtonPartial DecreaseSpeedButtonPartial { get; set; }
			[XmlElement(ElementName = "IncreaseEnginesPower_Buggy")]
			public IncreaseEnginesPower_Buggy IncreaseEnginesPower_Buggy { get; set; }
			[XmlElement(ElementName = "IncreaseWeaponsPower_Buggy")]
			public IncreaseWeaponsPower_Buggy IncreaseWeaponsPower_Buggy { get; set; }
			[XmlElement(ElementName = "IncreaseSystemsPower_Buggy")]
			public IncreaseSystemsPower_Buggy IncreaseSystemsPower_Buggy { get; set; }
			[XmlElement(ElementName = "ResetPowerDistribution_Buggy")]
			public ResetPowerDistribution_Buggy ResetPowerDistribution_Buggy { get; set; }
			[XmlElement(ElementName = "ToggleCargoScoop_Buggy")]
			public ToggleCargoScoop_Buggy ToggleCargoScoop_Buggy { get; set; }
			[XmlElement(ElementName = "EjectAllCargo_Buggy")]
			public EjectAllCargo_Buggy EjectAllCargo_Buggy { get; set; }
			[XmlElement(ElementName = "RecallDismissShip")]
			public RecallDismissShip RecallDismissShip { get; set; }
			[XmlElement(ElementName = "UIFocus_Buggy")]
			public UIFocus_Buggy UIFocus_Buggy { get; set; }
			[XmlElement(ElementName = "FocusLeftPanel_Buggy")]
			public FocusLeftPanel_Buggy FocusLeftPanel_Buggy { get; set; }
			[XmlElement(ElementName = "FocusCommsPanel_Buggy")]
			public FocusCommsPanel_Buggy FocusCommsPanel_Buggy { get; set; }
			[XmlElement(ElementName = "QuickCommsPanel_Buggy")]
			public QuickCommsPanel_Buggy QuickCommsPanel_Buggy { get; set; }
			[XmlElement(ElementName = "FocusRadarPanel_Buggy")]
			public FocusRadarPanel_Buggy FocusRadarPanel_Buggy { get; set; }
			[XmlElement(ElementName = "FocusRightPanel_Buggy")]
			public FocusRightPanel_Buggy FocusRightPanel_Buggy { get; set; }
			[XmlElement(ElementName = "GalaxyMapOpen_Buggy")]
			public GalaxyMapOpen_Buggy GalaxyMapOpen_Buggy { get; set; }
			[XmlElement(ElementName = "SystemMapOpen_Buggy")]
			public SystemMapOpen_Buggy SystemMapOpen_Buggy { get; set; }
			[XmlElement(ElementName = "HeadLookToggle_Buggy")]
			public HeadLookToggle_Buggy HeadLookToggle_Buggy { get; set; }
			[XmlElement(ElementName = "MultiCrewToggleMode")]
			public MultiCrewToggleMode MultiCrewToggleMode { get; set; }
			[XmlElement(ElementName = "MultiCrewPrimaryFire")]
			public MultiCrewPrimaryFire MultiCrewPrimaryFire { get; set; }
			[XmlElement(ElementName = "MultiCrewSecondaryFire")]
			public MultiCrewSecondaryFire MultiCrewSecondaryFire { get; set; }
			[XmlElement(ElementName = "MultiCrewPrimaryUtilityFire")]
			public MultiCrewPrimaryUtilityFire MultiCrewPrimaryUtilityFire { get; set; }
			[XmlElement(ElementName = "MultiCrewSecondaryUtilityFire")]
			public MultiCrewSecondaryUtilityFire MultiCrewSecondaryUtilityFire { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonMouseXMode")]
			public MultiCrewThirdPersonMouseXMode MultiCrewThirdPersonMouseXMode { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonMouseXDecay")]
			public MultiCrewThirdPersonMouseXDecay MultiCrewThirdPersonMouseXDecay { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonMouseYMode")]
			public MultiCrewThirdPersonMouseYMode MultiCrewThirdPersonMouseYMode { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonMouseYDecay")]
			public MultiCrewThirdPersonMouseYDecay MultiCrewThirdPersonMouseYDecay { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
			public MultiCrewThirdPersonYawAxisRaw MultiCrewThirdPersonYawAxisRaw { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonYawLeftButton")]
			public MultiCrewThirdPersonYawLeftButton MultiCrewThirdPersonYawLeftButton { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonYawRightButton")]
			public MultiCrewThirdPersonYawRightButton MultiCrewThirdPersonYawRightButton { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
			public MultiCrewThirdPersonPitchAxisRaw MultiCrewThirdPersonPitchAxisRaw { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonPitchUpButton")]
			public MultiCrewThirdPersonPitchUpButton MultiCrewThirdPersonPitchUpButton { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonPitchDownButton")]
			public MultiCrewThirdPersonPitchDownButton MultiCrewThirdPersonPitchDownButton { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
			public MultiCrewThirdPersonMouseSensitivity MultiCrewThirdPersonMouseSensitivity { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
			public MultiCrewThirdPersonFovAxisRaw MultiCrewThirdPersonFovAxisRaw { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonFovOutButton")]
			public MultiCrewThirdPersonFovOutButton MultiCrewThirdPersonFovOutButton { get; set; }
			[XmlElement(ElementName = "MultiCrewThirdPersonFovInButton")]
			public MultiCrewThirdPersonFovInButton MultiCrewThirdPersonFovInButton { get; set; }
			[XmlElement(ElementName = "MultiCrewCockpitUICycleForward")]
			public MultiCrewCockpitUICycleForward MultiCrewCockpitUICycleForward { get; set; }
			[XmlElement(ElementName = "MultiCrewCockpitUICycleBackward")]
			public MultiCrewCockpitUICycleBackward MultiCrewCockpitUICycleBackward { get; set; }
			[XmlElement(ElementName = "OrderRequestDock")]
			public OrderRequestDock OrderRequestDock { get; set; }
			[XmlElement(ElementName = "OrderDefensiveBehaviour")]
			public OrderDefensiveBehaviour OrderDefensiveBehaviour { get; set; }
			[XmlElement(ElementName = "OrderAggressiveBehaviour")]
			public OrderAggressiveBehaviour OrderAggressiveBehaviour { get; set; }
			[XmlElement(ElementName = "OrderFocusTarget")]
			public OrderFocusTarget OrderFocusTarget { get; set; }
			[XmlElement(ElementName = "OrderHoldFire")]
			public OrderHoldFire OrderHoldFire { get; set; }
			[XmlElement(ElementName = "OrderHoldPosition")]
			public OrderHoldPosition OrderHoldPosition { get; set; }
			[XmlElement(ElementName = "OrderFollow")]
			public OrderFollow OrderFollow { get; set; }
			[XmlElement(ElementName = "OpenOrders")]
			public OpenOrders OpenOrders { get; set; }
			[XmlElement(ElementName = "PhotoCameraToggle")]
			public PhotoCameraToggle PhotoCameraToggle { get; set; }
			[XmlElement(ElementName = "PhotoCameraToggle_Buggy")]
			public PhotoCameraToggle_Buggy PhotoCameraToggle_Buggy { get; set; }
			[XmlElement(ElementName = "VanityCameraScrollLeft")]
			public VanityCameraScrollLeft VanityCameraScrollLeft { get; set; }
			[XmlElement(ElementName = "VanityCameraScrollRight")]
			public VanityCameraScrollRight VanityCameraScrollRight { get; set; }
			[XmlElement(ElementName = "ToggleFreeCam")]
			public ToggleFreeCam ToggleFreeCam { get; set; }
			[XmlElement(ElementName = "VanityCameraOne")]
			public VanityCameraOne VanityCameraOne { get; set; }
			[XmlElement(ElementName = "VanityCameraTwo")]
			public VanityCameraTwo VanityCameraTwo { get; set; }
			[XmlElement(ElementName = "VanityCameraThree")]
			public VanityCameraThree VanityCameraThree { get; set; }
			[XmlElement(ElementName = "VanityCameraFour")]
			public VanityCameraFour VanityCameraFour { get; set; }
			[XmlElement(ElementName = "VanityCameraFive")]
			public VanityCameraFive VanityCameraFive { get; set; }
			[XmlElement(ElementName = "VanityCameraSix")]
			public VanityCameraSix VanityCameraSix { get; set; }
			[XmlElement(ElementName = "VanityCameraSeven")]
			public VanityCameraSeven VanityCameraSeven { get; set; }
			[XmlElement(ElementName = "VanityCameraEight")]
			public VanityCameraEight VanityCameraEight { get; set; }
			[XmlElement(ElementName = "VanityCameraNine")]
			public VanityCameraNine VanityCameraNine { get; set; }
			[XmlElement(ElementName = "FreeCamToggleHUD")]
			public FreeCamToggleHUD FreeCamToggleHUD { get; set; }
			[XmlElement(ElementName = "FreeCamSpeedInc")]
			public FreeCamSpeedInc FreeCamSpeedInc { get; set; }
			[XmlElement(ElementName = "FreeCamSpeedDec")]
			public FreeCamSpeedDec FreeCamSpeedDec { get; set; }
			[XmlElement(ElementName = "MoveFreeCamY")]
			public MoveFreeCamY MoveFreeCamY { get; set; }
			[XmlElement(ElementName = "ThrottleRangeFreeCam")]
			public ThrottleRangeFreeCam ThrottleRangeFreeCam { get; set; }
			[XmlElement(ElementName = "ToggleReverseThrottleInputFreeCam")]
			public ToggleReverseThrottleInputFreeCam ToggleReverseThrottleInputFreeCam { get; set; }
			[XmlElement(ElementName = "MoveFreeCamForward")]
			public MoveFreeCamForward MoveFreeCamForward { get; set; }
			[XmlElement(ElementName = "MoveFreeCamBackwards")]
			public MoveFreeCamBackwards MoveFreeCamBackwards { get; set; }
			[XmlElement(ElementName = "MoveFreeCamX")]
			public MoveFreeCamX MoveFreeCamX { get; set; }
			[XmlElement(ElementName = "MoveFreeCamRight")]
			public MoveFreeCamRight MoveFreeCamRight { get; set; }
			[XmlElement(ElementName = "MoveFreeCamLeft")]
			public MoveFreeCamLeft MoveFreeCamLeft { get; set; }
			[XmlElement(ElementName = "MoveFreeCamZ")]
			public MoveFreeCamZ MoveFreeCamZ { get; set; }
			[XmlElement(ElementName = "MoveFreeCamUpAxis")]
			public MoveFreeCamUpAxis MoveFreeCamUpAxis { get; set; }
			[XmlElement(ElementName = "MoveFreeCamDownAxis")]
			public MoveFreeCamDownAxis MoveFreeCamDownAxis { get; set; }
			[XmlElement(ElementName = "MoveFreeCamUp")]
			public MoveFreeCamUp MoveFreeCamUp { get; set; }
			[XmlElement(ElementName = "MoveFreeCamDown")]
			public MoveFreeCamDown MoveFreeCamDown { get; set; }
			[XmlElement(ElementName = "PitchCameraMouse")]
			public PitchCameraMouse PitchCameraMouse { get; set; }
			[XmlElement(ElementName = "YawCameraMouse")]
			public YawCameraMouse YawCameraMouse { get; set; }
			[XmlElement(ElementName = "PitchCamera")]
			public PitchCamera PitchCamera { get; set; }
			[XmlElement(ElementName = "FreeCamMouseSensitivity")]
			public FreeCamMouseSensitivity FreeCamMouseSensitivity { get; set; }
			[XmlElement(ElementName = "FreeCamMouseYDecay")]
			public FreeCamMouseYDecay FreeCamMouseYDecay { get; set; }
			[XmlElement(ElementName = "PitchCameraUp")]
			public PitchCameraUp PitchCameraUp { get; set; }
			[XmlElement(ElementName = "PitchCameraDown")]
			public PitchCameraDown PitchCameraDown { get; set; }
			[XmlElement(ElementName = "YawCamera")]
			public YawCamera YawCamera { get; set; }
			[XmlElement(ElementName = "FreeCamMouseXDecay")]
			public FreeCamMouseXDecay FreeCamMouseXDecay { get; set; }
			[XmlElement(ElementName = "YawCameraLeft")]
			public YawCameraLeft YawCameraLeft { get; set; }
			[XmlElement(ElementName = "YawCameraRight")]
			public YawCameraRight YawCameraRight { get; set; }
			[XmlElement(ElementName = "RollCamera")]
			public RollCamera RollCamera { get; set; }
			[XmlElement(ElementName = "RollCameraLeft")]
			public RollCameraLeft RollCameraLeft { get; set; }
			[XmlElement(ElementName = "RollCameraRight")]
			public RollCameraRight RollCameraRight { get; set; }
			[XmlElement(ElementName = "ToggleRotationLock")]
			public ToggleRotationLock ToggleRotationLock { get; set; }
			[XmlElement(ElementName = "FixCameraRelativeToggle")]
			public FixCameraRelativeToggle FixCameraRelativeToggle { get; set; }
			[XmlElement(ElementName = "FixCameraWorldToggle")]
			public FixCameraWorldToggle FixCameraWorldToggle { get; set; }
			[XmlElement(ElementName = "QuitCamera")]
			public QuitCamera QuitCamera { get; set; }
			[XmlElement(ElementName = "ToggleAdvanceMode")]
			public ToggleAdvanceMode ToggleAdvanceMode { get; set; }
			[XmlElement(ElementName = "FreeCamZoomIn")]
			public FreeCamZoomIn FreeCamZoomIn { get; set; }
			[XmlElement(ElementName = "FreeCamZoomOut")]
			public FreeCamZoomOut FreeCamZoomOut { get; set; }
			[XmlElement(ElementName = "FStopDec")]
			public FStopDec FStopDec { get; set; }
			[XmlElement(ElementName = "FStopInc")]
			public FStopInc FStopInc { get; set; }
			[XmlElement(ElementName = "CommanderCreator_Undo")]
			public CommanderCreator_Undo CommanderCreator_Undo { get; set; }
			[XmlElement(ElementName = "CommanderCreator_Redo")]
			public CommanderCreator_Redo CommanderCreator_Redo { get; set; }
			[XmlElement(ElementName = "CommanderCreator_Rotation_MouseToggle")]
			public CommanderCreator_Rotation_MouseToggle CommanderCreator_Rotation_MouseToggle { get; set; }
			[XmlElement(ElementName = "CommanderCreator_Rotation")]
			public CommanderCreator_Rotation CommanderCreator_Rotation { get; set; }
			[XmlElement(ElementName = "GalnetAudio_Play_Pause")]
			public GalnetAudio_Play_Pause GalnetAudio_Play_Pause { get; set; }
			[XmlElement(ElementName = "GalnetAudio_SkipForward")]
			public GalnetAudio_SkipForward GalnetAudio_SkipForward { get; set; }
			[XmlElement(ElementName = "GalnetAudio_SkipBackward")]
			public GalnetAudio_SkipBackward GalnetAudio_SkipBackward { get; set; }
			[XmlElement(ElementName = "GalnetAudio_ClearQueue")]
			public GalnetAudio_ClearQueue GalnetAudio_ClearQueue { get; set; }
			[XmlAttribute(AttributeName = "PresetName")]
			public string PresetName { get; set; }
			[XmlAttribute(AttributeName = "MajorVersion")]
			public string MajorVersion { get; set; }
			[XmlAttribute(AttributeName = "MinorVersion")]
			public string MinorVersion { get; set; }
			#endregion

			#region 3.4 Added Keybinds
			[XmlElement(ElementName = "NightVisionToggle")]
			public NightVisionToggle NightVisionToggle { get; set; }
		  
			[XmlElement(ElementName = "OpenCodexGoToDiscovery")]
			public OpenCodexGoToDiscovery OpenCodexGoToDiscovery { get; set; }
			[XmlElement(ElementName = "PlayerHUDModeToggle")]
			public PlayerHUDModeToggle PlayerHUDModeToggle { get; set; }
	   
			[XmlElement(ElementName = "CycleNextPage")]
			public CycleNextPage CycleNextPage { get; set; }
			[XmlElement(ElementName = "CyclePreviousPage")]
			public CyclePreviousPage CyclePreviousPage { get; set; }

			[XmlElement(ElementName = "ExplorationFSSEnter")]
			public ExplorationFSSEnter ExplorationFSSEnter { get; set; }
			[XmlElement(ElementName = "ExplorationFSSCameraPitch")]
			public ExplorationFSSCameraPitch ExplorationFSSCameraPitch { get; set; }
			[XmlElement(ElementName = "ExplorationFSSCameraPitchIncreaseButton")]
			public ExplorationFSSCameraPitchIncreaseButton ExplorationFSSCameraPitchIncreaseButton { get; set; }
			[XmlElement(ElementName = "ExplorationFSSCameraPitchDecreaseButton")]
			public ExplorationFSSCameraPitchDecreaseButton ExplorationFSSCameraPitchDecreaseButton { get; set; }
			[XmlElement(ElementName = "ExplorationFSSCameraYaw")]
			public ExplorationFSSCameraYaw ExplorationFSSCameraYaw { get; set; }
			[XmlElement(ElementName = "ExplorationFSSCameraYawIncreaseButton")]
			public ExplorationFSSCameraYawIncreaseButton ExplorationFSSCameraYawIncreaseButton { get; set; }
			[XmlElement(ElementName = "ExplorationFSSCameraYawDecreaseButton")]
			public ExplorationFSSCameraYawDecreaseButton ExplorationFSSCameraYawDecreaseButton { get; set; }
			[XmlElement(ElementName = "ExplorationFSSZoomIn")]
			public ExplorationFSSZoomIn ExplorationFSSZoomIn { get; set; }
			[XmlElement(ElementName = "ExplorationFSSZoomOut")]
			public ExplorationFSSZoomOut ExplorationFSSZoomOut { get; set; }
			[XmlElement(ElementName = "ExplorationFSSMiniZoomIn")]
			public ExplorationFSSMiniZoomIn ExplorationFSSMiniZoomIn { get; set; }
			[XmlElement(ElementName = "ExplorationFSSMiniZoomOut")]
			public ExplorationFSSMiniZoomOut ExplorationFSSMiniZoomOut { get; set; }
			[XmlElement(ElementName = "ExplorationFSSRadioTuningX_Raw")]
			public ExplorationFSSRadioTuningX_Raw ExplorationFSSRadioTuningX_Raw { get; set; }
			[XmlElement(ElementName = "ExplorationFSSRadioTuningX_Increase")]
			public ExplorationFSSRadioTuningX_Increase ExplorationFSSRadioTuningX_Increase { get; set; }
			[XmlElement(ElementName = "ExplorationFSSRadioTuningX_Decrease")]
			public ExplorationFSSRadioTuningX_Decrease ExplorationFSSRadioTuningX_Decrease { get; set; }
			[XmlElement(ElementName = "ExplorationFSSRadioTuningAbsoluteX")]
			public ExplorationFSSRadioTuningAbsoluteX ExplorationFSSRadioTuningAbsoluteX { get; set; }
			[XmlElement(ElementName = "FSSTuningSensitivity")]
			public FSSTuningSensitivity FSSTuningSensitivity { get; set; }
			[XmlElement(ElementName = "ExplorationFSSDiscoveryScan")]
			public ExplorationFSSDiscoveryScan ExplorationFSSDiscoveryScan { get; set; }
			[XmlElement(ElementName = "ExplorationFSSQuit")]
			public ExplorationFSSQuit ExplorationFSSQuit { get; set; }
			[XmlElement(ElementName = "FSSMouseXMode")]
			public FSSMouseXMode FSSMouseXMode { get; set; }
			[XmlElement(ElementName = "FSSMouseXDecay")]
			public FSSMouseXDecay FSSMouseXDecay { get; set; }
			[XmlElement(ElementName = "FSSMouseYMode")]
			public FSSMouseYMode FSSMouseYMode { get; set; }
			[XmlElement(ElementName = "FSSMouseYDecay")]
			public FSSMouseYDecay FSSMouseYDecay { get; set; }
			[XmlElement(ElementName = "FSSMouseSensitivity")]
			public FSSMouseSensitivity FSSMouseSensitivity { get; set; }
			[XmlElement(ElementName = "ExplorationFSSTarget")]
			public ExplorationFSSTarget ExplorationFSSTarget { get; set; }
			[XmlElement(ElementName = "ExplorationFSSShowHelp")]
			public ExplorationFSSShowHelp ExplorationFSSShowHelp { get; set; }
			[XmlElement(ElementName = "ExplorationSAAChangeScannedAreaViewToggle")]
			public ExplorationSAAChangeScannedAreaViewToggle ExplorationSAAChangeScannedAreaViewToggle { get; set; }
			[XmlElement(ElementName = "ExplorationSAAExitThirdPerson")]
			public ExplorationSAAExitThirdPerson ExplorationSAAExitThirdPerson { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonMouseXMode")]
			public SAAThirdPersonMouseXMode SAAThirdPersonMouseXMode { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonMouseXDecay")]
			public SAAThirdPersonMouseXDecay SAAThirdPersonMouseXDecay { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonMouseYMode")]
			public SAAThirdPersonMouseYMode SAAThirdPersonMouseYMode { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonMouseYDecay")]
			public SAAThirdPersonMouseYDecay SAAThirdPersonMouseYDecay { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonMouseSensitivity")]
			public SAAThirdPersonMouseSensitivity SAAThirdPersonMouseSensitivity { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonYawAxisRaw")]
			public SAAThirdPersonYawAxisRaw SAAThirdPersonYawAxisRaw { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonYawLeftButton")]
			public SAAThirdPersonYawLeftButton SAAThirdPersonYawLeftButton { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonYawRightButton")]
			public SAAThirdPersonYawRightButton SAAThirdPersonYawRightButton { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonPitchAxisRaw")]
			public SAAThirdPersonPitchAxisRaw SAAThirdPersonPitchAxisRaw { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonPitchUpButton")]
			public SAAThirdPersonPitchUpButton SAAThirdPersonPitchUpButton { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonPitchDownButton")]
			public SAAThirdPersonPitchDownButton SAAThirdPersonPitchDownButton { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonFovAxisRaw")]
			public SAAThirdPersonFovAxisRaw SAAThirdPersonFovAxisRaw { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonFovOutButton")]
			public SAAThirdPersonFovOutButton SAAThirdPersonFovOutButton { get; set; }
			[XmlElement(ElementName = "SAAThirdPersonFovInButton")]
			public SAAThirdPersonFovInButton SAAThirdPersonFovInButton { get; set; }
			#endregion
		}
	}
	#endregion
}