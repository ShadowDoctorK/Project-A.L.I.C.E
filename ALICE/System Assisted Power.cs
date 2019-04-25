using System.Threading;
using ALICE_Objects;
using ALICE_Interface;
using ALICE_Synthesizer;
using ALICE_Internal;
using ALICE_Debug;

namespace ALICE_Actions
{
    public class System_AssistedPower
    {
        public Settings Setting = new Settings();
        public Wrap Str = new Wrap();

        public class Wrap
        {
            public readonly string Systems = "Systems";
            public readonly string Engines = "Engines";
            public readonly string Weapons = "Weapons";
            public readonly string Heavy = "Heavy";
            public readonly string Balance = "Balance";
            public readonly string Light = "Light";
            public readonly string Maintain_Engines = "Maintain Engines";
            public readonly string Maintain_Systems = "Maintain Systems";
            public readonly string SetNewState = "SetNewState";
        }

        public class Settings
        {
            public string Send_Power_To = "Systems";
            public string Power_Diverted_To;
            public string Maintain_State = "Systems";
            public string Applied_Maintain;
            public string Power_Split = "Balance";
            public string Applied_Split;
            public string Default_State = "Systems";
            public string Applied_State;
            public bool DefaultLevelOne = false;
            public bool DefaultLevelTwo = false;
        }

        public void CombatPowerManagement()
        {
            string MethodName = "Combat Power Manager";

            if (ICheck.Order.CombatPower(MethodName, true) == false)
            {
                Logger.DebugLine(MethodName, "Combat Power Management Disabled", Logger.Yellow);
                return;
            }

            SetNewState:
            if (Setting.Send_Power_To == Setting.Power_Diverted_To)
            {
                if (Setting.Send_Power_To != Str.Weapons)
                {
                    if (Setting.Applied_State != Setting.Default_State)
                    {
                        if (PlugIn.DebugMode == true)
                        {
                            IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: [Applied State] Equals [" + Setting.Applied_State + "]", "Green");
                            IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: [Default State] Equals [" + Setting.Default_State + "]", "Green");
                        }

                        Setting.Send_Power_To = Setting.Default_State;
                        Setting.Power_Diverted_To = Str.SetNewState;
                        goto SetNewState;
                    }
                }
                else if (Setting.Applied_Maintain != Setting.Maintain_State)
                {
                    if (PlugIn.DebugMode == true)
                    {
                        IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: [Applied Maintain] Equals [" + Setting.Applied_Maintain + "]", "Green");
                        IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: [Maintain State]   Equals [" + Setting.Maintain_State + "]", "Green");
                    }

                    Setting.Power_Diverted_To = Str.SetNewState;
                    goto SetNewState;
                }
                else if (Setting.Applied_Split != Setting.Power_Split)
                {
                    if (PlugIn.DebugMode == true)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: [Applied Split] Does Not Equal [Power Split]", "Green"); }

                    Setting.Power_Diverted_To = Str.SetNewState;
                    goto SetNewState;
                }
            }
            else if (Setting.Send_Power_To != Setting.Power_Diverted_To)
            {
                if (Setting.Send_Power_To == Str.Weapons) { Send_Power_To_Weapons(); }
                else if (Setting.Send_Power_To == Str.Systems) { Send_Power_To_Systems(); }
                else if (Setting.Send_Power_To == Str.Engines) { Send_Power_To_Engines(); }
            }
        }

        private void Send_Power_To_Weapons()
        {
            if (PlugIn.DebugMode == true)
            { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Send Power To Weapons", "Green"); }

            Setting.DefaultLevelOne = false;

            if (Setting.Maintain_State == Str.Engines)
            {
                if (PlugIn.DebugMode == true)
                { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Maintain Engines", "Green"); }

                if (Setting.Power_Split == Str.Heavy)
                {
                    if (PlugIn.DebugMode == true)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Power Split Heavy", "Green"); }

                    Call.Power.Set(8, 0, 4);

                    Setting.Applied_Split = Setting.Power_Split;
                    Setting.Applied_Maintain = Setting.Maintain_State;
                    Setting.Power_Diverted_To = Setting.Send_Power_To;

                    return;
                }
                else if (Setting.Power_Split == Str.Balance)
                {
                    if (PlugIn.DebugMode == true)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Power Split Balance", "Green"); }

                    Call.Power.Set(6, 0, 6);

                    Setting.Applied_Split = Setting.Power_Split;
                    Setting.Applied_Maintain = Setting.Maintain_State;
                    Setting.Power_Diverted_To = Setting.Send_Power_To;
                    return;
                }
                else if (Setting.Power_Split == Str.Light)
                {
                    if (PlugIn.DebugMode == true)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Power Split Light", "Green"); }

                    Call.Power.Set(4, 0, 8);

                    Setting.Applied_Split = Setting.Power_Split;
                    Setting.Applied_Maintain = Setting.Maintain_State;
                    Setting.Power_Diverted_To = Setting.Send_Power_To;
                    return;
                }
            }
            else if (Setting.Maintain_State == Str.Systems)
            {
                if (PlugIn.DebugMode == true)
                { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Maintain Systems", "Green"); }

                if (Setting.Power_Split == Str.Heavy)
                {
                    if (PlugIn.DebugMode == true)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Power Split Heavy", "Green"); }

                    Call.Power.Set(8, 4, 0);

                    Setting.Applied_Split = Setting.Power_Split;
                    Setting.Applied_Maintain = Setting.Maintain_State;
                    Setting.Power_Diverted_To = Setting.Send_Power_To;
                    return;
                }
                else if (Setting.Power_Split == Str.Balance)
                {
                    if (PlugIn.DebugMode == true)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Power Split Balance", "Green"); }

                    Call.Power.Set(6, 6, 0);

                    Setting.Applied_Split = Setting.Power_Split;
                    Setting.Applied_Maintain = Setting.Maintain_State;
                    Setting.Power_Diverted_To = Setting.Send_Power_To;
                    return;
                }
                else if (Setting.Power_Split == Str.Light)
                {
                    if (PlugIn.DebugMode == true)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Power Split Light", "Green"); }

                    Call.Power.Set(4, 8, 0);

                    Setting.Applied_Split = Setting.Power_Split;
                    Setting.Applied_Maintain = Setting.Maintain_State;
                    Setting.Power_Diverted_To = Setting.Send_Power_To;
                    return;
                }
            }
        }

        private void Send_Power_To_Engines()
        {
            if (PlugIn.DebugMode == true)
            { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Send Power To Engines", "Green"); }

            if (Setting.DefaultLevelOne == false)
            {
                Thread.Sleep(2500);
                if (Setting.Send_Power_To != Str.Engines)
                { return; }

                Call.Power.Set(3, 3, 6);

                Setting.Applied_State = Setting.Default_State;
                Setting.Power_Diverted_To = Setting.Send_Power_To;
                Setting.DefaultLevelOne = true;
            }

            Thread.Sleep(2500);
            if (Setting.Send_Power_To != Str.Engines)
            { return; }

            Call.Power.Set(1, 4, 7);
        }

        private void Send_Power_To_Systems()
        {
            Setting.Power_Diverted_To = Setting.Send_Power_To;

            if (PlugIn.DebugMode == true)
            { IPlatform.WriteToInterface("A.L.I.C.E: Combat Power Management: Send Power To Systems", "Green"); }

            if (Setting.DefaultLevelOne == false)
            {
                Thread.Sleep(2500);
                if (Setting.Send_Power_To != Str.Systems)
                { return; }

                Call.Power.Set(3, 6, 3);

                Setting.Applied_State = Setting.Default_State;
                Setting.Power_Diverted_To = Setting.Send_Power_To;
                Setting.DefaultLevelOne = true;
            }

            Thread.Sleep(2500);
            if (Setting.Send_Power_To != Str.Systems)
            { return; }

            Call.Power.Set(1, 7, 4);
        }

        public void Maintain_Engines(bool CommandAudio)
        {
            string MethodName = "Maintain Engines";

            if (ICheck.Order.CombatPower(MethodName, true) == false)
            {
                Logger.DebugLine(MethodName, "Combat Power Management Disabled", Logger.Yellow);
                return;
            }

            Assisted.Power.Setting.Maintain_State = Assisted.Power.Str.Engines;

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(GN_Combat_Power.Maintain_Engines, true),
                    CommandAudio,
                    ICheck.Order.CombatPower(MethodName, true, true),
                    ICheck.Status.Hardpoints(MethodName, true)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Maintain_Systems(bool CommandAudio)
        {
            string MethodName = "Maintain Systems";

            if (ICheck.Order.CombatPower(MethodName, true) == false)
            {
                Logger.DebugLine(MethodName, "Combat Power Management Disabled", Logger.Yellow);
                return;
            }

            Assisted.Power.Setting.Maintain_State = Assisted.Power.Str.Systems;

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(GN_Combat_Power.Maintain_Systems, true),
                    CommandAudio,
                    ICheck.Order.CombatPower(MethodName, true, true),
                    ICheck.Status.Hardpoints(MethodName, false)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Defense_Engines(bool CommandAudio)
        {
            string MethodName = "Defense Engines";

            if (ICheck.Order.CombatPower(MethodName, true) == false)
            {
                Logger.DebugLine(MethodName, "Combat Power Management Disabled", Logger.Yellow);
                return;
            }

            Assisted.Power.Setting.Default_State = Assisted.Power.Str.Engines;

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(GN_Combat_Power.Defense_Engines, true),
                    CommandAudio,
                    ICheck.Order.CombatPower(MethodName, true, true),
                    ICheck.Status.Hardpoints(MethodName, true)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Defense_Systems(bool CommandAudio)
        {
            string MethodName = "Defense Systems";

            if (ICheck.Order.CombatPower(MethodName, true) == false)
            {
                Logger.DebugLine(MethodName, "Combat Power Management Disabled", Logger.Yellow);
                return;
            }

            Assisted.Power.Setting.Default_State = Assisted.Power.Str.Systems;

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(GN_Combat_Power.Defense_Systems, true),
                    CommandAudio,
                    ICheck.Order.CombatPower(MethodName, true, true),
                    ICheck.Status.Hardpoints(MethodName, true)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Weapons_Light(bool CommandAudio)
        {
            string MethodName = "Weapons Light";

            if (ICheck.Order.CombatPower(MethodName, true) == false)
            {
                Logger.DebugLine(MethodName, "Combat Power Management Disabled", Logger.Yellow);
                return;
            }

            Assisted.Power.Setting.Power_Split = Assisted.Power.Str.Light;

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(GN_Combat_Power.Weapons_Light, true),
                    CommandAudio,
                    ICheck.Order.CombatPower(MethodName, true, true),
                    ICheck.Status.Hardpoints(MethodName, true)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Weapons_Balance(bool CommandAudio)
        {
            string MethodName = "Weapons Balance";

            if (ICheck.Order.CombatPower(MethodName, true) == false)
            {
                Logger.DebugLine(MethodName, "Combat Power Management Disabled", Logger.Yellow);
                return;
            }

            Assisted.Power.Setting.Power_Split = Assisted.Power.Str.Balance;

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(GN_Combat_Power.Weapons_Balance, true),
                    CommandAudio,
                    ICheck.Order.CombatPower(MethodName, true, true),
                    ICheck.Status.Hardpoints(MethodName, true)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Weapons_Heavy(bool CommandAudio)
        {
            string MethodName = "Weapons Heavy";

            if (ICheck.Order.CombatPower(MethodName, true) == false)
            {
                Logger.DebugLine(MethodName, "Combat Power Management Disabled", Logger.Yellow);
                return;
            }

            Assisted.Power.Setting.Power_Split = Assisted.Power.Str.Heavy;

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(GN_Combat_Power.Weapons_Heavy, true),
                    CommandAudio,
                    ICheck.Order.CombatPower(MethodName, true, true),
                    ICheck.Status.Hardpoints(MethodName, true)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }
    }
}
