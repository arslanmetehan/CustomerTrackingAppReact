using CustomerTrackingAppReact.Entities;
using CustomerTrackingAppReact.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Services
{
    public interface IUserService
    {
        void AddNewUser(User user);
        void UpdateUser(User user);
        UserModel GetOnlineUser(HttpContext httpContext);
        bool TryLogin(UserLoginModel loginData, HttpContext httpContext);
        void Logout(HttpContext httpContext);
        List<UserModel> GetAllUsers();
        List<UserModel> GetUsersByPage(int limit,int pageNo);
        int UsernameCounter(string username);
        UserModel GetById(int id);
        int EmailCounter(string username);
    }
}
