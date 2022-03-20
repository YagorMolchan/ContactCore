using ContactCore.Interfaces;
using ContactCore.Models;
using ContactCore.Models.Entities;
using ContactCore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ContactCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(IUserRepository userRepo, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Index()
        {
            //List<string> controllerNames = new List<string>();
            //List<Type> controllers = GetSubClasses<Controller>();
            //GetSubClasses<Controller>().ForEach(
            //    type => controllerNames.Add(type.Name.Replace("Controller","")));

            //foreach(var controller in controllers)
            //{
            //    var methods = controller.GetMethods(BindingFlags.Public)
            //        .Where(method => typeof(ActionResult).IsAssignableFrom(method.ReturnType)).ToList();
            //    foreach(var method in methods)
            //    {

            //    }
            //}


            var list = _userRepo.Users;
            return View(list);
        }


        public JsonResult GetRoleList()
        {
            var list = _roleManager.Roles.ToList();                 
            return Json(list);
        }


        [HttpGet]
        public async Task<ActionResult> UpdateRolesOfUser(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            ChangeRoleViewModel model = new ChangeRoleViewModel
            {
                UserId = userId,
                UserName = user.UserName,
                AllRoles = _roleManager.Roles.ToList(),
                UserRoles = await _userManager.GetRolesAsync(user) as List<string>
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateRolesOfUser(ChangeRoleViewModel model, List<string> roles)
        {
            ApplicationUser user = _userRepo.GetUser(model.UserId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles).ToList();
                var removedRoles = userRoles.Except(roles).ToList();

                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        private static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }

    }
}
