using ALICE_Debug;
using ALICE_Interface;

namespace ALICE_DebugItems
{
    public class Platform : Debug
    {
        /// <summary>
        /// Will Check If The Starting Platform Contains The Target Command.
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="C">(Command) The Target Command Name</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CommandExist(string M, string C, bool L, bool T = true)
        {
            return Evaluate(M, "Command Exist", T, IPlatform.CommandExists(C), L);
        }

        /// <summary>
        /// Will get the value for ALICE_EnginePower from the Starting Platform
        /// </summary>
        /// <param name="M">(Method) The Calling Method.</param>
        /// <returns></returns>
        public decimal EnginePower(string M, bool L)
        {
            return Retreive(M, ALICE_Interface.IPlatform.IVar.EnginePower, 0,
                "Was Not Set To A Valid Option. (0 - 8)", L, 0, 8);
        }

        /// <summary>
        /// Will get the value for ALICE_SystemPower from the Starting Platform
        /// </summary>
        /// <param name="M">(Method) The Calling Method.</param>
        /// <returns></returns>
        public decimal SystemPower(string M, bool L)
        {
            return Retreive(M, ALICE_Interface.IPlatform.IVar.SystemPower, 0,
                "Was Not Set To A Valid Option. (0 - 8)", L , 0, 8);
        }

        /// <summary>
        /// Will get the value for ALICE_WeaponPower from the Starting Platform
        /// </summary>
        /// <param name="M">(Method) The Calling Method.</param>
        /// <returns></returns>
        public decimal WeaponPower(string M, bool L)
        {
            return Retreive(M, ALICE_Interface.IPlatform.IVar.WeaponPower, 0,
                "Was Not Set To A Valid Option. (0 - 8)", L, 0, 8);
        }

        /// <summary>
        /// Will get the value for ALICE_RecordPower from the Starting Platform
        /// </summary>
        /// <param name="M">(Method) The Calling Method.</param>
        /// <returns></returns>
        public bool RecordPower(string M, bool L)
        {
            return Retreive(M, ALICE_Interface.IPlatform.IVar.RecordPower,
                "Was Not Set To A Valid Option. (true or false)", L);
        }       
    }
}