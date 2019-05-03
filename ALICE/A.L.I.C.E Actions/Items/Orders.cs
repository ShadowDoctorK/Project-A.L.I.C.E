using ALICE_Response;
using ALICE_Settings;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static Orders Order = new Orders();

        public class Orders
        {
            private string ClassName = "Orders";

            /// <summary>
            /// Provides Updates On The Status Of Orders.
            /// </summary>
            /// <param name="C">(Current) The Current State.</param>
            /// <param name="N">(New) The New State.</param>
            /// <param name="I">(Item) The Orders Name.</param>
            /// <returns></returns>
            public bool Update(bool C, bool N, string I)
            {
                if (C == true)
                {
                    if (N == true)
                    {
                        IResponse.Order.CurrentlyEnabled(I, true);
                    }
                    else if (N == false)
                    {
                        IResponse.Order.Disabled(I, true);
                    }
                }
                else if (C == false)
                {
                    if (N == true)
                    {
                        IResponse.Order.Enabled(I, true);
                    }
                    else if (N == false)
                    {
                        IResponse.Order.CurrentlyDisabled(I, true);
                    }
                }

                return N;
            }

            #region PlugIn
            /// <summary>
            /// Increase or Decrease the Pip Speed by 25ms 
            /// </summary>
            /// <param name="Increase">True = Increase & False = Decrease</param>
            public void PipSpeed(bool Increase)
            {
                //Increase
                if (Increase)
                {
                    ISettings.User.OffsetPips(ClassName, ISettings.User.OffsetPips() + 25, true);
                }

                //Decrease
                else
                {
                    ISettings.User.OffsetPips(ClassName, ISettings.User.OffsetPips() + 25, true);

                    if (ISettings.User.OffsetPips() < 0)
                    {
                        ISettings.User.OffsetPips(ClassName, 0, true);
                    }
                }
            }

            /// <summary>
            /// Increase or Decrease the Panel Speed by 25ms 
            /// </summary>
            /// <param name="Increase">True = Increase & False = Decrease</param>
            public void PanelSpeed(bool Increase)
            {
                //Increase
                if (Increase)
                {
                    ISettings.User.OffsetPanels(ClassName, ISettings.User.OffsetPanels() + 25, true);
                }

                //Decrease
                else
                {
                    ISettings.User.OffsetPanels(ClassName, ISettings.User.OffsetPanels() + 25, true);

                    if (ISettings.User.OffsetPanels() < 0)
                    {
                        ISettings.User.OffsetPanels(ClassName, 0, true);
                    }
                }
            }

            /// <summary>
            /// Increase or Decrease the Fire Group Speed by 25ms 
            /// </summary>
            /// <param name="Increase">True = Increase & False = Decrease</param>
            public void FireGroupSpeed(bool Increase)
            {
                //Increase
                if (Increase)
                {
                    ISettings.User.OffsetFireGroups(ClassName, ISettings.User.OffsetFireGroups() + 25, true);
                }

                //Decrease
                else
                {
                    ISettings.User.OffsetFireGroups(ClassName, ISettings.User.OffsetFireGroups() + 25, true);

                    if (ISettings.User.OffsetFireGroups() < 0)
                    {
                        ISettings.User.OffsetFireGroups(ClassName, 0, true);
                    }
                }
            }

            /// <summary>
            /// Increase or Decrease the Pip Speed by 25ms 
            /// </summary>
            /// <param name="Increase">True = Increase & False = Decrease</param>
            public void ThrottleSpeed(bool Increase)
            {
                //Increase
                if (Increase)
                {
                    ISettings.User.OffsetThrottle(ClassName, ISettings.User.OffsetThrottle() + 25, true);
                }

                //Decrease
                else
                {
                    ISettings.User.OffsetThrottle(ClassName, ISettings.User.OffsetThrottle() + 25, true); 

                    if (ISettings.User.OffsetThrottle() < 0)
                    {
                        ISettings.User.OffsetThrottle(ClassName, 0, true);
                    }
                }
            }
            #endregion

            #region Orders
            public void AutoSystemScans(bool State)
            {
                string Item = "Assisted System Scans";
                ISettings.User.AssistSystemScan(ClassName, Update(ISettings.User.AssistSystemScan(), State, Item), true);
            }

            public void AutoDockingProcedure(bool State)
            {
                string Item = "Assisted Docking Procedures";
                ISettings.User.AssistDocking(ClassName, Update(ISettings.User.AssistDocking(), State, Item), true);                
            }           

            public void AutoHangerEntry(bool State)
            {
                string Item = "Assisted Hanger Entry";
                ISettings.User.AssistHangerEntry(ClassName, Update(ISettings.User.AssistHangerEntry(), State, Item), true);
            }

            public void CombatPower(bool State)
            {
                string Item = "Combat Power Management";
                ISettings.User.CombatPower(ClassName, Update(ISettings.User.CombatPower(), State, Item), true);
            }

            public void PostJumpSafety(bool State)
            {
                string Item = "Post Jump Safeties";
                ISettings.User.PostHyperspaceSafety(ClassName, Update(ISettings.User.PostHyperspaceSafety(), State, Item), true);
            }

            public void WeaponSafety(bool State)
            {
                string Item = "Weapon Safety Interlocks";
                ISettings.User.WeaponSafety(ClassName, Update(ISettings.User.WeaponSafety(), State, Item), true);               
            }
            #endregion
        }
    }
}
