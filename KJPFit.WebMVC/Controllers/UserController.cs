using KJPFit.Models;
using KJPFit.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KJPFit.WebMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            var model = service.GetUser();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateUserService();

            if (service.CreateUser(model))
            {
                TempData["SaveResult"] = "User was created.";
                return RedirectToAction("Index");
            };
            
            ModelState.AddModelError("", "User could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateUserService();
            var detail = service.GetUserById(id);
            var model =
                new UserEdit
                {
                    UserId = detail.UserId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    HeightInInches = detail.HeightInInches
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.UserId != id)
            {
                ModelState.AddModelError("", "Id Doesn't Match");
                return View(model);
            }

            var service = CreateUserService();

            if (service.UpdateUser(model))
            {
                TempData["SaveResult"] = "User info was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "User info could not be updated.");
            return View(model);
        }

        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            return service;
        }
    }
    
}