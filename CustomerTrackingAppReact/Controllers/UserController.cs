using CustomerTrackingAppReact.Entities;
using CustomerTrackingAppReact.Models;
using CustomerTrackingAppReact.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Controllers
{
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public ApiResponse<List<UserModel>> GetActiveUsers()
		{
			try
			{
				var users = this._userService.GetAllUsers();

				var response = ApiResponse<List<UserModel>>.WithSuccess(users);

				return response;
			}
			catch (Exception exp)
			{
				return ApiResponse<List<UserModel>>.WithError(exp.ToString());
			}
		}
		[HttpGet]
		public ApiResponse<List<UserModel>> GetUsersByPageNo(int pageNo)
		{
			try
			{
				int limit = 5;
				var users = this._userService.GetUsersByPage(limit, pageNo);

				var response = ApiResponse<List<UserModel>>.WithSuccess(users);

				return response;
			}
			catch (Exception exp)
			{
				return ApiResponse<List<UserModel>>.WithError(exp.ToString());
			}
		}

		[HttpPost]
		public ApiResponse Login([FromBody] UserLoginModel model)
		{
			try
			{
				if (!this._userService.TryLogin(model, this.HttpContext))
				{
					return ApiResponse.WithError("Invalid Username or Password!");
				}

				return ApiResponse.WithSuccess();
			}
			catch (Exception exp)
			{
				return ApiResponse.WithError(exp.ToString());
			}
		}
		[HttpPost]
		public ApiResponse<UserModel> CreateUser([FromBody] CreateUserModel model)
		{
			try
			{
				var onlineUser = this._userService.GetOnlineUser(this.HttpContext);
				if (onlineUser == null)
				{
					return ApiResponse<UserModel>.WithError("Not authorized !");
				}
				if (onlineUser.Type != 0 && model.Type == Enum.Type.Admin || onlineUser.Type != 0 && model.Type == Enum.Type.Manager || onlineUser.Type == Enum.Type.Employee)
				{
					return ApiResponse<UserModel>.WithError("Not authorized !");
				}
				if (model.Username == null || model.Username == "")
				{
					return ApiResponse<UserModel>.WithError("Username is required !");
				}
				if (model.Email == null || model.Email == "")
				{
					return ApiResponse<UserModel>.WithError("Email is required !");
				}
				if (model.Password == null || model.Password == "")
				{
					return ApiResponse<UserModel>.WithError("Password is required !");
				}
				UserModel result = null;

				var newUser = new User();
				newUser.Username = model.Username;
				var usernameControl = _userService.UsernameCounter(model.Username);
				if (usernameControl >= 1)
				{
					return ApiResponse<UserModel>.WithError("This Username has already exist !");
				}
				newUser.Email = model.Email;
				var emailControl = _userService.EmailCounter(model.Email);
				if (emailControl >= 1)
				{
					return ApiResponse<UserModel>.WithError("This Email has already exist !");
				}
				newUser.Password = model.Password;
				newUser.BirthYear = model.BirthYear;
				newUser.FullName = model.FullName;
				newUser.Phone = model.Phone;
				newUser.ManagerId = model.ManagerId;
				newUser.IsActive = Enum.IsActive.Active;
				newUser.Gender = model.Gender;
				newUser.Type = model.Type;




				this._userService.AddNewUser(newUser);
				result = this._userService.GetById(newUser.Id);

				return ApiResponse<UserModel>.WithSuccess(result);
			}
			catch (Exception exp)
			{
				return ApiResponse<UserModel>.WithError(exp.ToString());
			}
		}

		[HttpGet]
		public ApiResponse<UserModel> GetOnlineUser()
		{
			try
			{
				var user = this._userService.GetOnlineUser(this.HttpContext);

				return ApiResponse<UserModel>.WithSuccess(user);
			}
			catch (Exception exp)
			{
				return ApiResponse<UserModel>.WithError(exp.ToString());
			}
		}
		[HttpPost]
		public ApiResponse Logout()
		{
			try
			{
				this._userService.Logout(this.HttpContext);

				return ApiResponse.WithSuccess();
			}
			catch (Exception exp)
			{
				return ApiResponse.WithError(exp.ToString());
			}
		}
	}
}
