using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerTrackingAppReact.Entities;
using CustomerTrackingAppReact.Enum;

namespace CustomerTrackingAppReact.Persistence
{
    public interface ILogRepository
    {
        //void Log(LogType type, string message);
        //void Log(LogType ınfo, string v);
        void Log(LogType type, string message);
    }
}
