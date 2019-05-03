using ALICE_Response;
using ALICE_Settings;

namespace ALICE_Actions
{
    public partial class IActions
    {
        public static Reports Report = new Reports();

        public class Reports
        {
            private string ClassName = "Reports";

            /// <summary>
            /// Provides Updates On The Status Of Reports.
            /// </summary>
            /// <param name="C">(Current) The Current State.</param>
            /// <param name="N">(New) The New State.</param>
            /// <param name="I">(Item) The Reports Name.</param>
            /// <returns></returns>
            public  bool Update(bool C, bool N, string I)
            {
                if (C == true)
                {
                    if (N == true)
                    {
                        IResponse.Report.CurrentlyEnabled(I, true);
                    }
                    else if (N == false)
                    {
                        IResponse.Report.Disabled(I, true);
                    }
                }
                else if (C == false)
                {
                    if (N == true)
                    {
                        IResponse.Report.Enabled(I, true);
                    }
                    else if (N == false)
                    {
                        IResponse.Report.CurrentlyDisabled(I, true);
                    }
                }

                return N;
            }

            #region Reports
            public void FuelScoop(bool State)
            {
                string Item = "Fuel Scooping";
                ISettings.User.FuelScoop(ClassName, Update(ISettings.User.FuelScoop(), State, Item), true);                
            }

            public void FuelStatus(bool State)
            {
                string Item = "Fuel Status";
                ISettings.User.FuelStatus(ClassName, Update(ISettings.User.FuelStatus(), State, Item), true);
            }

            public void MaterialCollected(bool State)
            {
                string Item = "Material Collection";
                ISettings.User.MaterialCollected(ClassName, Update(ISettings.User.MaterialCollected(), State, Item), true);
            }

            public void MaterialRefined(bool State)
            {
                string Item = "Material Refining";
                ISettings.User.MaterialRefined(ClassName, Update(ISettings.User.MaterialRefined(), State, Item), true);
            }

            public void NoFireZone(bool State)
            {
                string Item = "No Fire Zone";
                ISettings.User.NoFireZone(ClassName, Update(ISettings.User.NoFireZone(), State, Item), true);
            }

            public void StationStatus(bool State)
            {
                string Item = "Station Status";
                ISettings.User.StationStatus(ClassName, Update(ISettings.User.StationStatus(), State, Item), true);
            }

            public void ShieldState(bool State)
            {
                string Item = "Shield State";
                ISettings.User.ShieldState(ClassName, Update(ISettings.User.ShieldState(), State, Item), true);
            }

            public void CollectedBounty(bool State)
            {
                string Item = "Target Bounty";
                ISettings.User.CollectedBounty(ClassName, Update(ISettings.User.CollectedBounty(), State, Item), true);
            }

            public void TargetEnemy(bool State)
            {
                string Item = "Enemy Faction";
                ISettings.User.TargetEnemy(ClassName, Update(ISettings.User.TargetEnemy(), State, Item), true);
            }

            public void TargetWanted(bool State)
            {
                string Item = "Wanted Target";
                ISettings.User.TargetWanted(ClassName, Update(ISettings.User.TargetWanted(), State, Item), true);
            }

            public void Masslock(bool State)
            {
                string Item = "Masslock";
                ISettings.User.Masslock(ClassName, Update(ISettings.User.Masslock(), State, Item), true);
            }

            public void GlideStatus(bool State)
            {
                string Item = "Glide Status";
                ISettings.User.GlideStatus(ClassName, Update(ISettings.User.GlideStatus(), State, Item), true);
            }

            public void HighGravDescent(bool State)
            {
                string Item = "High Gravity Descent";
                ISettings.User.HighGravDescent(ClassName, Update(ISettings.User.HighGravDescent(), State, Item), true);
            }

            public void LandableVolcanism(bool State)
            {
                string Item = "Landable Volcanism";
                ISettings.User.LandableVolcanism(ClassName, Update(ISettings.User.LandableVolcanism(), State, Item), true);
            }
            #endregion

            #region Navigation
            public void ScanTravelDist(bool State)
            {
                string Item = "Travel Distance Threshold";
                ISettings.User.ScanTravelDist(ClassName, Update(ISettings.User.ScanTravelDist(), State, Item), true);
            }

            public void ScanDistLimit(int D)
            {
                string Item = "Scan Distance Limit";
                ISettings.User.ScanDistLimit(ClassName, D, true);
            }

            public void BodyAmmonia(bool V)
            {
                string Item = "Ammonia World";
                ISettings.User.BodyAmmonia(ClassName, Update(ISettings.User.BodyAmmonia(), V, Item), true);
            }

            public void BodyEarthLike(bool V)
            {
                string Item = "Earthlike World";
                ISettings.User.BodyEarthLike(ClassName, Update(ISettings.User.BodyEarthLike(), V, Item), true);
            }

            public void BodyGasGiantII(bool V)
            {
                string Item = "Gas Giant 2";
                ISettings.User.BodyGasGiantII(ClassName, Update(ISettings.User.BodyGasGiantII(), V, Item), true);
            }

            public void BodyHMC(bool V)
            {
                string Item = "High Metal Content World";
                ISettings.User.BodyHMC(ClassName, Update(ISettings.User.BodyHMC(), V, Item), true);
            }

            public void BodyHMCTerra(bool V)
            {
                string Item = "Terraformable High Metal Content World";
                ISettings.User.BodyHMCTerra(ClassName, Update(ISettings.User.BodyHMCTerra(), V, Item), true);
            }

            public void BodyMetalRich(bool V)
            {
                string Item = "Metal Rich World";
                ISettings.User.BodyMetalRich(ClassName, Update(ISettings.User.BodyMetalRich(), V, Item), true);
            }

            public void BodyRockyTerra(bool V)
            {
                string Item = "Rocky Body (Terraformable)";
                ISettings.User.BodyRockyTerra(ClassName, Update(ISettings.User.BodyRockyTerra(), V, Item), true);
            }

            public void BodyWater(bool V)
            {
                string Item = "Water World";
                ISettings.User.BodyWater(ClassName, Update(ISettings.User.BodyWater(), V, Item), true);
            }

            public void BodyWaterTerra(bool V)
            {
                string Item = "Water World Terraformable";
                ISettings.User.BodyWaterTerra(ClassName, Update(ISettings.User.BodyWaterTerra(), V, Item), true);
            }
            #endregion
        }
    }
}
