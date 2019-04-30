using System.Collections.Generic;
using System.Threading;
using ALICE_Actions;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Status;

namespace ALICE_Panels
{
    public class IPanels
    {
        public Dictionary<string, decimal> Bookmarks { get; set; }

        public SystemPanel System { get; set; }
        public TargetPanel Target { get; set; }
        public CommsPanel Comms { get; set; }
        public RolePanel Role { get; set; }
        public GalaxyMapPanel GalaxyMap { get; set; }
        public SystemMapPanel SystemMap { get; set; }

        public IPanels()
        {
            System = new SystemPanel();
            Target = new TargetPanel();
            Comms = new CommsPanel();
            Role = new RolePanel();
            GalaxyMap = new GalaxyMapPanel();
            SystemMap = new SystemMapPanel();

            Bookmarks = new Dictionary<string, decimal>();
        }

        /// <summary>
        /// Will attempt to close all menus to return to the Ships Hud. Monitors the GUI State. 15 Attempts.
        /// </summary>
        /// <returns>returns true when HUD is detected. False when out of attempts</returns>
        public bool HudFocus(int Sleep = 100)
        {
            bool Temp = false; int Count = 15; while (IStatus.GUI_Focus != 0 && Count > 0)
            { IKeyboard.Press(IKey.UI_Back, 500); Count--; }

            if (IStatus.GUI_Focus == 0) { Temp = true; }

            Thread.Sleep(Sleep);

            return Temp;
        }

        public void MainFourIsFalse()
        {
            Call.Panel.System.Open = false;
            Call.Panel.Comms.Open = false;
            Call.Panel.Target.Open = false;
            Call.Panel.Role.Open = false;
        }
    }

    public class BasePanel : BaseShared
    {
        public bool Open { get; set; }
        public decimal Pos { get; set; }
        public string MethodName { get => this.GetType().Name.Replace("Panel", " Panel"); }

        public virtual void Panel(bool State)
        {
            if (CheckEnvironment(MethodName) == false) { return; }
            if (CloseMap(MethodName) == false) { return; }

            if (Name != IEnums.Role) { Call.Panel.Role.Open = false; }
            if (Name != IEnums.Target) { Call.Panel.Target.Open = false; }
            if (Name != IEnums.Comms) { Call.Panel.Comms.Open = false; }
            if (Name != IEnums.System) { Call.Panel.System.Open = false; }

            //Check Role Panel
            if (Name == IEnums.Role && ICheck.Panel.Role.Open(MethodName, !State))
            {
                IKeyboard.Press(IKey.Role_Panel, 400, IKey.DelayPanel);
            }

            //Check Target Panel
            if (Name == IEnums.Target && ICheck.Panel.Target.Open(MethodName, !State))
            {
                IKeyboard.Press(IKey.Target_Panel, 400, IKey.DelayPanel);
            }

            //Check Comms Panel
            if (Name == IEnums.Comms && ICheck.Panel.Comms.Open(MethodName, !State))
            {
                IKeyboard.Press(IKey.Comms_Panel, 400, IKey.DelayPanel);
            }

            //Check System Panel
            if (Name == IEnums.System && ICheck.Panel.System.Open(MethodName, !State))
            {
                IKeyboard.Press(IKey.System_Panel, 400, IKey.DelayPanel);
            }

            //Check Galaxy Map
            if (Name == IEnums.GalaxyMap && ICheck.Panel.GalaxyMap.Open(MethodName, !State))
            {
                IKeyboard.Press(IKey.Open_Galaxy_Map, 400, IKey.DelayPanel);
            }

            //Check System Map
            if (Name == IEnums.SystemMap && ICheck.Panel.SystemMap.Open(MethodName, !State))
            {
                IKeyboard.Press(IKey.Open_System_Map, 400, IKey.DelayPanel);
            }

            Open = State; PanelPrep(State);
        }

        public virtual void PanelPrep(bool State) { }

        public virtual void UpdateTab(decimal Select, int AddDelay = 0)
        {
            if (CheckEnvironment(MethodName) == false) { return; }

            Logger.DebugLine(MethodName, "Update Tabs - Current Position = " + Pos + " | Requested Position = " + Select, Logger.Blue);

            //Previous Tab
            if (Select < Pos)
            {
                decimal Cycle = Pos - Select; while (Cycle != 0 && Cycle > 0)
                { IKeyboard.Press(IKey.Previous_Panel_Tab, 100 + AddDelay, IKey.DelayPanel); Cycle--; }
            }
            //Next Tab
            else if (Select > Pos)
            {
                decimal Cycle = Select - Pos; while (Cycle != 0 && Cycle > 0)
                { IKeyboard.Press(IKey.Next_Panel_Tab, 100 + AddDelay, IKey.DelayPanel); Cycle--; }
            }

            Pos = Select;
            TabPrep(Select);
        }

        public virtual void TabPrep(decimal Select) { }
    }

    public class BaseTab : BaseShared
    {
        public decimal Main { get; set; }
        public decimal Tab { get; set; }
        public string MethodName { get => this.GetType().Name.Replace("Tab", ""); }

        public virtual void Open(string MethodName)
        {
            if (CheckEnvironment(MethodName) == false) { return; }
            if (CheckMap(MethodName) == false) { if (CloseMap(MethodName) == false) { return; } }
            CheckOverlays(MethodName);
            Panel_Target();
        }      
    }

    public class BaseShared
    {
        public string Name { get; set; }

        public bool CheckEnvironment(string MethodName)
        {
            return ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace);
        }

        public bool CheckOverlays(string MethodName, bool Answer = true)
        {
            Start:
            bool Recheck = false;
            if (ICheck.Music.MusicTrack(MethodName, false, IEnums.Squadrons, true) == false)
            { Recheck = true; }

            if (ICheck.Music.MusicTrack(MethodName, false, IEnums.GalacticPowers, true) == false)
            { Recheck = true; }

            if (ICheck.Music.MusicTrack(MethodName, false, IEnums.Codex, true) == false)
            { Recheck = true; }

            if (Recheck) { IKeyboard.Press(IKey.UI_Back, 600); goto Start; }

            return Answer;
        }

        /// <summary>
        /// Will Close Maps that are expected to be closed.
        /// </summary>
        /// <param name="MethodName">Name of the method calling this method.</param>
        /// <param name="Answer">Defaulted to True, will change to false as required.</param>
        /// <param name="SystemMap">Expected State for the System Map, Defaulted to False.</param>
        /// <param name="GalaxyMap">Expected State for the Galaxy map, Defaulted to False.</param>
        /// <returns>Returns True once all maps match their state and are closed as needed.</returns>
        public bool CloseMap(string MethodName, bool Answer = true, bool SystemMap = false, bool GalaxyMap = false)
        {
            if (Name == IEnums.MapGalaxy && GalaxyMap == false) { return Answer; }
            if (Name == IEnums.MapSystem && SystemMap == false) { return Answer; }

            Start:
            //Galaxy Map Is Open && Galaxy Map Expected State is False
            if (ICheck.Panel.GalaxyMap.Open(MethodName, false) == false && GalaxyMap == false)
            {
                Call.Panel.GalaxyMap.Panel(false);
                Answer = WaitMap(MethodName, IEnums.MapGalaxy, false);
                goto Start;
            }

            //System Map Is Open && System Map Expected State is False
            if (ICheck.Panel.SystemMap.Open(MethodName, false) == false && SystemMap == false)
            {
                Call.Panel.SystemMap.Panel(false);
                Answer = WaitMap(MethodName, IEnums.MapSystem, false);
                goto Start;
            }

            return Answer;
        }

        /// <summary>
        /// Checks Map States.
        /// </summary>
        /// <param name="MethodName">Name of the method calling this method.</param>
        /// <param name="Answer">Defaulted to True, will change to false as required.</param>
        /// <param name="SystemMap">Expected State for the System Map, Defaulted to False.</param>
        /// <param name="GalaxyMap">Expected State for the Galaxy map, Defaulted to False.</param>
        /// <returns>Returns True if all Maps equal the expected states.</returns>
        public bool CheckMap(string MethodName, bool Answer = true, bool SystemMap = false, bool GalaxyMap = false)
        {
            if (Name == IEnums.MapGalaxy && GalaxyMap == false) { return Answer; }
            if (Name == IEnums.MapSystem && SystemMap == false) { return Answer; }

            //Galaxy Map Is Open && Galaxy Map Expected State is False
            if (ICheck.Panel.GalaxyMap.Open(MethodName, false) == false && GalaxyMap == false)
            {
                Answer = false;
            }

            //System Map Is Open && System Map Expected State is False
            if (ICheck.Panel.SystemMap.Open(MethodName, false) == false && SystemMap == false)
            {
                Answer = false;
            }

            return Answer;
        }

        public bool WaitMap(string MethodName, string Map, bool State)
        {
            if (Map == IEnums.MapGalaxy)
            {
                if (State == true)
                {
                    //Watch For Galaxy Map To Open / Soft Exit Timer.
                    int Count = 50; while (ICheck.Music.MusicTrack(MethodName, true, IEnums.GalaxyMap, true) == false)                        
                    {
                        Logger.DebugLine(MethodName, "Galaxy Map: Wait Timer = " + Count, Logger.Blue);
                        Thread.Sleep(100); if (Count <= 0)
                        {
                            Logger.DebugLine(MethodName, "Galaxy Map: Looks Like The Galaxy Map Failed To Open. Try Again...", Logger.Red);
                            return false;
                        } Count--;
                    }
                }
                else if (State == false)
                {
                    //Watch For Galaxy Map To Close / Soft Exit Timer.
                    int Count = 50; while (ICheck.Music.MusicTrack(MethodName, false, IEnums.GalaxyMap, true) == false)
                    {
                        Logger.DebugLine(MethodName, "Galaxy Map: Wait Timer = " + Count, Logger.Blue);
                        Thread.Sleep(100); if (Count <= 0)
                        {
                            Logger.DebugLine(MethodName, "Galaxy Map: Looks Like The Galaxy Map Failed To Close. Try Again...", Logger.Red);
                            return false;
                        } Count--;
                    }
                }
            }

            if (Map == IEnums.MapSystem)
            {
                if (State == true)
                {
                    //Watch For System Map To Open / Soft Exit Timer.
                    int Count = 50; while (Call.Panel.SystemMap.Open != true)
                    {
                        Logger.DebugLine(MethodName, "System Map: Wait Timer = " + Count, Logger.Blue);
                        Thread.Sleep(100); if (Count <= 0)
                        {
                            Logger.DebugLine(MethodName, "System Map: Looks Like The System Map Failed To Open. Try Again...", Logger.Red);
                            return false;
                        }
                        Count--;
                    }
                }
                else if (State == false)
                {
                    //Watch For System Map To Close / Soft Exit Timer.
                    int Count = 50; while (Call.Panel.SystemMap.Open != false)
                    {
                        Logger.DebugLine(MethodName, "System Map: Wait Timer = " + Count, Logger.Blue);
                        Thread.Sleep(100); if (Count <= 0)
                        {
                            Logger.DebugLine(MethodName, "System Map: Looks Like The System Map Failed To Close. Try Again...", Logger.Red);
                            return false;
                        }
                        Count--;
                    }
                }
            }

            return true;
        }

        public decimal UpdateCursor(decimal Sel, decimal Cur, bool Vert, int Pause = 0)
        {
            string MethodName = "Update UI Position";

            Logger.DebugLine(MethodName, "Update UI - Current Position = " + Cur + " | Requested Position = " + Sel + " | Verticle = " + Vert.ToString(), Logger.Blue);

            //Up / Left
            if (Sel < Cur)
            {
                decimal Cycle = Cur - Sel; while (Cycle != 0 && Cycle > 0)
                {
                    if (Vert == true) { IKeyboard.Press(IKey.UI_Panel_Up, 100 + Pause, IKey.DelayPanel); }
                    else if (Vert == false) { IKeyboard.Press(IKey.UI_Panel_Left, 100 + Pause, IKey.DelayPanel); }
                    Cycle--;
                }
            }
            //Down / Right
            else if (Sel > Cur)
            {
                decimal Cycle = Sel - Cur; while (Cycle != 0 && Cycle > 0)
                {
                    if (Vert == true) { IKeyboard.Press(IKey.UI_Panel_Down, 100 + Pause, IKey.DelayPanel); }
                    else if (Vert == false) { IKeyboard.Press(IKey.UI_Panel_Right, 100 + Pause, IKey.DelayPanel); }
                    Cycle--;
                }
            }

            return Sel;
        }

        public void Select(int Pause = 0) { IKeyboard.Press(IKey.UI_Panel_Select, Pause); }

        public void Back(int Pause = 0) { IKeyboard.Press(IKey.UI_Back, Pause); }

        public void MainFourIsFalse()
        {
            Call.Panel.System.Open = false;
            Call.Panel.Comms.Open = false;
            Call.Panel.Target.Open = false;
            Call.Panel.Role.Open = false;
        }

        public virtual void Panel_Target() { }
    }
}