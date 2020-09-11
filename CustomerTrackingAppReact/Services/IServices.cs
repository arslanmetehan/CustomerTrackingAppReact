﻿using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Services
{
    public interface IServices
    {
        IUserService UserService { get; }
        IViewService ViewService { get; }
    }
}
