﻿using CustomerTrackingAppReact.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Models
{
    public class CreateUserModel
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public Gender Gender { get; set; }
        public IsActive IsActive { get; set; }
        public Enum.Type Type { get; set; }
        public int BirthYear { get; set; }
        public int ManagerId { get; set; }
    }
}
