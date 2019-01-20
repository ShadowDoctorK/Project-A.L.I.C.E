//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-09-16T11:42:23Z", "event":"EngineerProgress", "Engineer":"Elvira Martuuk", "EngineerID":300160, "Progress":"Unlocked", "Rank":1 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;
using ALICE_EventLogic;

namespace ALICE_Events
{
    public class Event_EngineerProgress : Event_Base
    {
        public Event_EngineerProgress()
        {
            Name = "EngineerProgress";
        }

        public void Logic()
        {
            if (IEvents.WriteVariables && WriteVariables)
            {
                try
                {
                    Variables_Clear();
                    Variables_Generate();
                    Variables_Write();
                }
                catch (Exception ex)
                {
                    Logger.Exception(Name, "An Exception Occured While Updating Variables");
                    Logger.Exception(Name, "Exception: " + ex);
                }
            }

            Process.EngineerProgress((EngineerProgress)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            EngineerProgress Event = (EngineerProgress)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            foreach (var Eng in Event.Engineers)
            {                
                Variable_Craft(Eng.Engineer.Variable() + "_EngineerID", Eng.EngineerID.Variable());
                Variable_Craft(Eng.Engineer.Variable() + "_Progress", Eng.Progress.Variable());
                Variable_Craft(Eng.Engineer.Variable() + "_RankProgress", Eng.RankProgress.Variable());
                Variable_Craft(Eng.Engineer.Variable() + "_Rank", Eng.Rank.Variable());
            }            
            #endregion
        }
    }

    #region EngineerProgress Event
    public class EngineerProgress : Base
    {
        public List<Eng> Engineers { get; set; }

        public EngineerProgress()
        {
            Engineers = new List<Eng>();
        }

        public class Eng
        {
            public string Engineer { get; set; }
            public decimal EngineerID { get; set; }
            public string Progress { get; set; }
            public decimal RankProgress { get; set; }
            public decimal Rank { get; set; }

            public Eng()
            {
                Engineer = Default.String;
                EngineerID = Default.Decimal;
                Progress = Default.String;
                RankProgress = Default.Decimal;
                Rank = Default.Decimal;
            }
        }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == "EngineerProgress")
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.EngineerProgress>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }
