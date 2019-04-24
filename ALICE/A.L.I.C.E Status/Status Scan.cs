using ALICE_Debug;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Settings;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Status
{
    public class Status_Scan
    {
        private readonly string MethodName = "Scan Report";

        //Get Scanned Body Data
        Object_StellarBody Body;

        public void Evaluate(decimal BodyID)
        {           
            //Get Scanned Body Data
            Body = IObjects.SystemCurrent.Get_StellarBody(BodyID);

            //Track Range
            bool OutOfRange = false;

            //Track Terraforming
            bool Terraforamable = false;

            //Check ScanTypes:
            //Not Processing AutoScan To Prevent Overloading User With Reports.
            if (Body.ScanType == "AutoScan")
            {
                Logger.DebugLine(MethodName, "Scan Type Is AutoScan.", Logger.Yellow);
                return;
            }
            
            //Check If Body Was Surface Scanned.
            if (Body.SurfaceScanned == true)
            {
                Logger.DebugLine(MethodName, "Body Surface Scanned.", Logger.Yellow);
                return;
            }

            //Check Body Is A Planet
            if (Body.BodyType != IEnums.Planet)
            {
                Logger.DebugLine(MethodName, "Body Type Is Not A Planet", Logger.Yellow);
                return;
            }

            //Check Body Is A Planet
            if (ReportCheck(Body) == false)
            {
                Logger.DebugLine(MethodName, Body.PlanetClass + "Is Set To False.", Logger.Yellow);
                return;
            }

            //Check Distance From Arrival Against User Settings
            if (Body.DistFromArrival > GetScanDistLimit())
            {
                Logger.DebugLine(MethodName, GetPlanetName(Body) + " Is Outside Of Players Desired Travel Distance.", Logger.Yellow);
                OutOfRange = true;
            }

            //Check Distance From Arrival Against User Settings
            if (Body.TerraformState != "None")
            {
                Logger.DebugLine(MethodName, GetPlanetName(Body) + " Is Terraformable.", Logger.Blue);
                Terraforamable = true;
            }

            //Report Scan If Event Triggers Are Enabled.
            Report(Terraforamable, OutOfRange, ICheck.Initialized(MethodName));

            //Clear Body Data
            Body = new Object_StellarBody();
        }

        #region Audio
        public void Report(bool T, bool D, bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, GetPlanetName(Body) + "Is A Detailed Scan Target.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EVT_Scan.Target_Aquired) //Tokens: Name, Type
                .Phrase(EVT_Scan.Terraformable, false, T)
                .Phrase(EVT_Scan.Outside_Distance, false, (D && ISettings.ScanTravelDist))
                .Phrase(EVT_Scan.Est_Detailed_Scan, true) //Tokens: Number
                .Token("[NAME]", GetPlanetName(Body))
                .Token("[TYPE]", Body.PlanetClass)
                .Token("[NUMBER]", GetDetailScanEstimate(Body)),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion

        #region Support Methods
        public decimal GetFSSEstimate(Object_StellarBody O)
        {
            string MethodName = "Stellar Body (FFS Value Estimate)";

            switch (O.PlanetClass)
            {
                case "Earthlike body":
                    return 270000;

                case "Water world":

                    //Check If Terraformable
                    if (O.TerraformState != "None")
                    {
                        return 270000;
                    }

                    //Normal
                    return 100000;

                case "High metal content body":

                    //Check If Terraformable
                    if (O.TerraformState != "None")
                    {
                        return 160000;
                    }

                    //Normal
                    return 14000;

                case "Ammonia body":
                    return 140000;

                case "Rocky body":

                    //Check If Terraformable
                    if (O.TerraformState != "None")
                    {
                        return 130000;
                    }

                    //Normal
                    return 500;

                case "Metal rich body":
                    return 30000;

                case "Sudarsky class I gas giant":
                    return 3800;

                case "Sudarsky class II gas giant":
                    return 28000;

                case "Sudarsky class III gas giant":
                    return 1000;

                case "Sudarsky class IV gas giant":
                    return 1100;

                case "Sudarsky class V gas giant":
                    return 1000;

                case "Gas giant with water based life":
                    return 880;

                case "Gas giant with ammonia based life":
                    return 770;

                case "Helium rich gas giant":
                    return 900;

                case "Helium gas giant":
                    return 900;

                case "Water giant":
                    return 670;

                case "Water giant with life":
                    return 670;

                case "Rocky ice body":
                    return 500;

                case "Icy body":
                    return 500;

                default:
                    Logger.DevUpdateLog(MethodName, "New Untracked Body: " + O.PlanetClass + " | Terraform State" + O.TerraformState, Logger.Purple);
                    return 0;
            }
        }

        public decimal GetDetailScanEstimate(Object_StellarBody O)
        {
            string MethodName = "Stellar Body (FFS Value Estimate)";

            switch (O.PlanetClass)
            {
                case "Earthlike body":
                    return 830000;

                case "Water world":

                    //Check If Terraformable
                    if (O.TerraformState != "None")
                    {
                        return 830000;
                    }

                    //Normal
                    return 320000;

                case "High metal content body":

                    //Check If Terraformable
                    if (O.TerraformState != "None")
                    {
                        return 520000;
                    }

                    //Normal
                    return 46000;

                case "Ammonia body":
                    return 460000;

                case "Ammonia world":
                    return 460000;

                case "Rocky body":

                    //Check If Terraformable
                    if (O.TerraformState != "None")
                    {
                        return 410000;
                    }

                    //Normal
                    return 1000;

                case "Metal rich body":
                    return 100000;

                case "Sudarsky class I gas giant":
                    return 12300;

                case "Sudarsky class II gas giant":
                    return 92000;

                case "Sudarsky class III gas giant":
                    return 3000;

                case "Sudarsky class IV gas giant":
                    return 3600;

                case "Sudarsky class V gas giant":
                    return 3000;

                case "Gas giant with water based life":
                    return 2820;

                case "Gas giant with ammonia based life":
                    return 2430;

                case "Helium rich gas giant":
                    return 2900;

                case "Helium gas giant":
                    return 2900;

                case "Water giant":
                    return 2130;

                case "Water giant with life":
                    return 2130;

                case "Rocky ice body":
                    return 1100;

                case "Icy body":
                    return 1000;

                default:
                    Logger.DevUpdateLog(MethodName, "New Untracked Body: " + O.PlanetClass + " | Terraform State" + O.TerraformState, Logger.Purple);
                    return 0;
            }
        }

        public decimal GetScanDistLimit()
        {
            string MethodName = "Scan Distance Limit";

            switch (ISettings.ScanDistLimit)
            {
                //Unlimited
                case 0:
                    return 100000000000;

                //1:00 Min
                case 1:
                    return 1000;

                //2:20 Min                    
                case 2:                 
                    return 5000;

                //2:50 Min
                case 3:                 
                    return 10000;       
                                        
                //3:50 Min
                case 4:                 
                    return 25000;       
                                        
                //5:00 Min
                case 5:                 
                    return 50000;       
                                        
                //6:25 Min
                case 6:                 
                    return 100000;      
                                        
                //7:30 Min
                case 7:                 
                    return 150000;      
                                        
                //8:30 Min
                case 8:                 
                    return 200000;      
                                        
                //10:12 Min
                case 9:                 
                    return 300000;      
                                        
                //11:45 Min
                case 10:                
                    return 400000;

                //13:10 Min
                case 11:
                    return 500000;

                //14:20 Min
                case 12:
                    return 600000;

                //15:50 Min
                case 13:
                    return 700000;

                //17:20 Min
                case 14:
                    return 800000;

                //18:05 Min
                case 15:
                    return 900000;

                //19:25 Min
                case 16:
                    return 1000000;

                //20:33 Min
                case 17:
                    return 1100000;

                //21:40 Min
                case 18:
                    return 1200000;

                //22:46 Min
                case 19:
                    return 1300000;

                //23:51 Min
                case 20:
                    return 1400000;

                //24:54 Min
                case 21:
                    return 1500000;

                //25:58 Min
                case 22:
                    return 1600000;

                //27:00 Min
                case 23:
                    return 1700000;

                //28:00 Min
                case 24:
                    return 1800000;

                //29:00 Min
                case 25:
                    return 1900000;

                //30:00 Min
                case 26:
                    return 2000000;

                //Unlimited
                default:
                    Logger.Error(MethodName, "Returned Using Default Switch. Returing Unlimited Distance", Logger.Red);
                    return 100000000000;
            }
        }  

        private bool ReportCheck(Object_StellarBody O)
        {
            string MethodName = "Scan Report (Check)";

            switch (O.PlanetClass)
            {
                case "Earthlike body":
                    return ISettings.BodyEarthLike;

                case "Water world":

                    //Check If Terraformable
                    if (O.TerraformState != "None")
                    {
                        return ISettings.BodyWaterTerra;
                    }

                    //Normal
                    return ISettings.BodyWater;

                case "High metal content body":

                    //Check If Terraformable
                    if (O.TerraformState != "None")
                    {
                        return ISettings.BodyHMCTerra;
                    }

                    //Normal
                    return ISettings.BodyHMC;

                case "Ammonia world":
                    return ISettings.BodyAmmonia;

                case "Ammonia body":
                    return ISettings.BodyAmmonia;

                case "Rocky body":

                    //Check If Terraformable
                    if (O.TerraformState != "None")
                    {
                        return ISettings.BodyRockyTerra;
                    }

                    //Normal
                    return false;

                case "Metal rich body":
                    return ISettings.BodyMetalRich;

                case "Sudarsky class I gas giant":
                    return false;

                case "Sudarsky class II gas giant":
                    return ISettings.BodyGasGiantII;

                case "Sudarsky class III gas giant":
                    return false;

                case "Sudarsky class IV gas giant":
                    return false;

                case "Sudarsky class V gas giant":
                    return false;

                case "Gas giant with water based life":
                    return false;

                case "Gas giant with ammonia based life":
                    return false;

                case "Helium rich gas giant":
                    return false;

                case "Helium gas giant":
                    return false;

                case "Water giant":
                    return false;

                case "Water giant with life":
                    return false;

                case "Rocky ice body":
                    return false;

                case "Icy body":
                    return false;

                default:
                    Logger.DevUpdateLog(MethodName, "New Untracked Body: " + O.PlanetClass + " | Terraform State" + O.TerraformState, Logger.Purple);
                    return false;
            }
        }

        private string GetPlanetName(Object_StellarBody O)
        {
            string PlanetName = O.Name;
            string SystemName = IObjects.SystemCurrent.Name;

            //Remove System Name From Planet
            //If Planet Has A Unique Name This Will Fail Returning The Whole Name
            if (PlanetName.Contains(SystemName))
            {                
                PlanetName = "Planet " + PlanetName.Replace(SystemName, "");
            }

            return PlanetName;
        }
        #endregion

    }
}
