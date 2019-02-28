using ALICE_Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Interface
{
    public static class INewtownSoft
    {
        /// <summary>
        /// Configurable Save Method For Serializing Objects Into Json Data.
        /// </summary>
        /// <typeparam name="T">(Type) The Type Of Object</typeparam>
        /// <param name="O">(Object) The Object Data You're Saving</param>
        /// <param name="F">(File) The Name Of The Target File.</param>
        /// <param name="P">(Path) The Folder Path The Target File Is At</param>
        /// <param name="D">(Directory) Enable / Disable Creation Of New Directories</param>
        /// <param name="L">(Logging) Enable / Disable Logging</param>
        public static void Save<T>(object O, string F, string P, bool D = true, bool L = true)
        {
            string MethodName = "Object Data (Save)";

            //Check Folder Path
            if (P == null)
            {
                if (L) { Logger.Error(MethodName, "Target Folder Was Not Defined. Data Not Saved.", Logger.Red); }
                return;
            }

            //Check File Name
            if (P == null)
            {
                if (L) { Logger.Error(MethodName, "Target File Was Not Defined. Data Not Saved.", Logger.Red); }
                return;
            }
            
            //Check Directory
            if (Directory.Exists(P) == false)
            {
                if (D) { Directory.CreateDirectory(P); }
                else
                {
                    if (L) { Logger.Error(MethodName, "Target Directory Does Not Exist & Permission Was Not Given To Create It. Data Not Saved.", Logger.Red); }
                    return;
                }
            }

            //Save Data
            try
            {
                using (StreamWriter SR = new StreamWriter(
                    new FileStream(P + F, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)))
                {
                    var Line = JsonConvert.SerializeObject((T)O);
                    SR.WriteLine(Line);
                }
            }
            catch (Exception ex)
            {
                if (L) { Logger.Exception(MethodName, "Execption: " + ex); }
            }
        }

        /// <summary>
        /// Configurable Load Method For Deserializing Json Data.
        /// </summary>
        /// <typeparam name="T">(Type) The Type Of Object</typeparam>
        /// <param name="F">(File) The Name Of The Target File.</param>
        /// <param name="P">(Path) The Folder Path The Target File Is At</param>
        /// <param name="L">(Logging) Enable / Disable Logging</param>
        /// <returns></returns>
        public static object Load<T>(string F, string P, bool L = true)
        {
            string MethodName = "Object Data (Load)";

            //Default Object Instance
            T Temp = default(T);

            //Check Folder Path
            if (P == null)
            {
                if (L) { Logger.Error(MethodName, "Target Folder Was Not Defined.", Logger.Red); }
                return null;
            }

            //Check File Name
            if (P == null)
            {
                if (L) { Logger.Error(MethodName, "Target File Was Not Defined.", Logger.Red); }
                return null;
            }

            //
            try
            {
                if (File.Exists(P + F))
                {
                    using (StreamReader SR = new StreamReader(
                        new FileStream(P + F, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                    {
                        while (!SR.EndOfStream)
                        {
                            string Line = SR.ReadLine();
                            Temp = JsonConvert.DeserializeObject<T>(Line);
                        }
                    }
                }

                return Temp;
            }
            catch (Exception ex)
            {
                if (L) { Logger.Exception(MethodName, "Execption: " + ex); }
                return Temp;
            }
        }
    }
}