using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Settings
{
    public class SettingsPlugIn
    {
        public LoggingSettings Log = new LoggingSettings();
        public DebugSettings Debug = new DebugSettings();
    }

    public class DebugSettings
    {
        public bool Responses { get; set; }
        public bool Keyboard { get; set; }
        public bool Commands { get; set; }
        public bool Actions { get; set; }

        public DebugSettings()
        {
            Responses = false;
            Keyboard = false;
            Commands = false;
            Actions = false;
        }
    }

    public class LoggingSettings
    {
        public bool Extended { get; set; }
        public bool Debug { get; set; }
        public bool Developer { get; set; }

        public LoggingSettings()
        {
            Extended = true;
            Developer = false;
            Debug = false;
        }
    }
}
