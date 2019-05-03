//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2019-01-18T08:44:28Z", "event":"ProspectedAsteroid", "Materials":[ { "Name":"HydrogenPeroxide", "Name_Localised":"Hydrogen Peroxide", "Proportion":10.668694 }, { "Name":"water", "Proportion":5.129156 }, { "Name":"liquidoxygen", "Name_Localised":"Liquid oxygen", "Proportion":4.222730 } ], "Content":"$AsteroidMaterialContent_Low;", "Content_Localised":"Material Content: Low", "Remaining":100.000000 }

using System;
using System.Collections.Generic;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ProspectedAsteroid : Base
    {
        public List<Material> Materials { get; set; }
        public string Content { get; set; }
        public string Content_Localised { get; set; }
        public string MotherlodeMaterial { get; set; }
        public string MotherlodeMaterial_Localised { get; set; }
        public decimal Remaining { get; set; }
        
        //Default Constructor
        public ProspectedAsteroid()
        {
            Content = Str();
            Content_Localised = Str();
            MotherlodeMaterial = Str();
            MotherlodeMaterial_Localised = Str();
            Remaining = Dec();
        }

        public class Material : Catch
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public decimal Proportion { get; set; }

            public Material()
            {
                Name = Str();
                Name_Localised = Str();
                Proportion = Dec();
            }
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_ProspectedAsteroid : Event
    {
        //Event Instance
        public ProspectedAsteroid I { get; set; } = new ProspectedAsteroid();

        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                Variables.Record(Name + "_Yeild", I.Content_Localised);
                Variables.Record(Name + "_Remaining", I.Remaining);
                Variables.Switch(Name + "_Core", I.MotherlodeMaterial_Localised, I.MotherlodeMaterial);

                int C = 1; foreach (var Mat in I.Materials)
                {
                    Variables.Record(Name + "_Material" + C, Mat.Name_Localised);
                    Variables.Record(Name + "_Percent" + C, Mat.Proportion);
                    C++;
                }
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }

        //Plugin Logic Preparations
        public override void Prepare(object O)
        {
            try
            {
                //Update Event Instance
                I = (ProspectedAsteroid)O;
            }
            catch (Exception ex)
            {
                ExceptionPrepare(Name, ex);
            }
        }
    }
}