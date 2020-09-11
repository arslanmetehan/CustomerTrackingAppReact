﻿using CustomerTrackingAppReact.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CustomerTrackingAppReact.Entities
{

    public class CustomerModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Phone { get; set; }
        public CustomerModel(Customer customer)
        {
            this.Id = customer.Id;
            this.FullName = customer.FullName;
            this.Phone = customer.Phone;
        }

    }

}
