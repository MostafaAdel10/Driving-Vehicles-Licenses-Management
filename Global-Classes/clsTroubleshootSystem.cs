using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DrivingLicenseManagement
{
    public class clsTroubleshootSystem
    {
        public enum enEventType { Information = 1, Warning = 2, Error =3 };

        public static void StoreInEventViewerEventLogs(string Message , enEventType enEventType)
        {
            // Specify the source name for the event log
            string sourceName = "DVLD";

            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            switch (enEventType)
            {
                case enEventType.Information:
                    EventLog.WriteEntry(sourceName, Message, EventLogEntryType.Information);
                    break;
                case enEventType.Warning:
                    EventLog.WriteEntry(sourceName , Message, EventLogEntryType.Warning);
                    break;
                case enEventType.Error:
                    EventLog.WriteEntry(sourceName, Message, EventLogEntryType.Error);
                    break;
            }
        }
    }
}
