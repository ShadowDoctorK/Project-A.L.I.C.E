using ALICE_Core;
using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_DebugCheck
{
    public class Environment
    {
        public bool Space(string M, bool T, string C, bool L = true)
        {
            //Set Prefix For Check Value
            string S = ""; if (T == false) { S = "Not "; }
            string N = "Space";
            string P = IEnums.Normal_Space;

            if (IStatus.Hyperspace == true)
            {
                P = IEnums.Hyperspace;
            }
            else if (IStatus.Supercruise == true)
            {
                P = IEnums.Supercruise;
            }

            //Check
            if (T == true && C != P)
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + S + C + ")", Logger.Yellow); }
                return false;
            }

            //Check
            if (T == false && C == P)
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + S + C + ")", Logger.Yellow); }
                return false;
            }

            //Passed
            if (L) { Logger.DebugLine(M, "[Pass]: " + N + " Equals Expected State (" + S + C + ")", Logger.Blue); }
            return true;
        }
    }
}

namespace ALICE_DebugGet
{
    public class Environment
    {
        public string Space(string M)
        {
            string Answer = IEnums.Normal_Space;

            if (IStatus.Hyperspace == true)
            {
                Answer = IEnums.Hyperspace;
            }
            else if (IStatus.Supercruise == true)
            {
                Answer = IEnums.Supercruise;
            }

            //Debug Logger
            Logger.DebugLine(M, "[Get]: Envrionment (Space) Equals - " + Answer, Logger.Yellow);

            return Answer;
        }
    }
}

namespace ALICE_DebugSet
{
    public class Environment
    {

    }
}
