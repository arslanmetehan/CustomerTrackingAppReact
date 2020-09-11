using CustomerTrackingAppReact.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Helper
{
    public static class Converter
    {
        public static ActivityModel ToModel(this Activity activityModel)
        {
            return new ActivityModel(activityModel);
        }
        public static UserModel ToModel(this User userModel)
        {
            return new UserModel(userModel);
        }
    }
    
}
