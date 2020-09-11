using CustomerTrackingAppReact.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Entities
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentDebt { get; set; }
    }
}
