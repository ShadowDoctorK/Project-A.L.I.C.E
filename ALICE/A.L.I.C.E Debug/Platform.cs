using ALICE_Debug;

namespace ALICE_DebugItems
{
    public class Platform : Debug
    {        
        /// <summary>
        /// Will get the value for ALICE_EnginePower from the Starting Platform
        /// </summary>
        /// <param name="M">(Method) The Calling Method.</param>
        /// <returns></returns>
        public decimal EnginePower(string M)
        {
            return Retreive(M, ALICE_Interface.IPlatform.IVar.EnginePower, 0,
                "Was Not Set To A Valid Option. (0 - 8)", 0, 8);
        }

        /// <summary>
        /// Will get the value for ALICE_SystemPower from the Starting Platform
        /// </summary>
        /// <param name="M">(Method) The Calling Method.</param>
        /// <returns></returns>
        public decimal SystemPower(string M)
        {
            return Retreive(M, ALICE_Interface.IPlatform.IVar.SystemPower, 0,
                "Was Not Set To A Valid Option. (0 - 8)", 0, 8);
        }

        /// <summary>
        /// Will get the value for ALICE_WeaponPower from the Starting Platform
        /// </summary>
        /// <param name="M">(Method) The Calling Method.</param>
        /// <returns></returns>
        public decimal WeaponPower(string M)
        {
            return Retreive(M, ALICE_Interface.IPlatform.IVar.WeaponPower, 0,
                "Was Not Set To A Valid Option. (0 - 8)", 0, 8);
        }

        /// <summary>
        /// Will get the value for ALICE_RecordPower from the Starting Platform
        /// </summary>
        /// <param name="M">(Method) The Calling Method.</param>
        /// <returns></returns>
        public bool RecordPower(string M)
        {
            return Retreive(M, ALICE_Interface.IPlatform.IVar.RecordPower,
                "Was Not Set To A Valid Option. (true or false)");
        }       
    }
}