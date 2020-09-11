using CustomerTrackingAppReact.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Services
{
    public interface IViewService
    {
        TModel CreateViewModel<TModel>(HttpContext httpContext, string pageTitle) where TModel : BaseViewModel, new();
    }
}
