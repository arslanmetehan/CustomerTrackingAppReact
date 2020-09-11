using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Phone { get; set; }
    }
}
