using CustomerTrackingAppReact.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Models
{
    public class CreateActivityModel
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentDebt { get; set; }
    }
}
