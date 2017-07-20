namespace BankSystem_v2.Controllers
{
    using Models;
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class UsersController : Controller
    {
        private BankSystemDbContext context = new BankSystemDbContext();

        [Authorize(Roles = "User")]
        public ActionResult MySettings()
        {
            var user = context.Users.FirstOrDefault(u => u.Username == User.Identity.Name);

            var view = new UserSettingsView
            {
                Address = user.Address,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Id = user.Id,
                Username = user.Username,
            };


            return View(view);
        }

        [HttpPost]
        public ActionResult MySettings(UserSettingsView view)
        {
            var user = context.Users.Find(view.Id);

            user.Address = view.Address;
            user.FirstName = view.FirstName;
            user.MiddleName = view.MiddleName;
            user.LastName = view.LastName;

            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        [Authorize(Roles = "Admin")]
        public ActionResult OnOffAdministrator(int id)
        {
            var user = context.Users.Find(id);

            if (user != null)
            {
                var userContext = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userASP = userManager.FindByEmail(user.Username);

                if (userASP != null)
                {
                    if (userManager.IsInRole(userASP.Id, "Admin"))
                    {
                        userManager.RemoveFromRole(userASP.Id, "Admin");
                    }
                    else
                    {
                        userManager.AddToRole(userASP.Id, "Admin");
                    }
                }

            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        // GET: Users
        public ActionResult Index()
        {
            var userContext = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            var users = context.Users.ToList();
            var usersView = new List<UserIndexView>();

            //por cada usuario que hay en la coleccion users:
            foreach (var user in users)
            {
                var userASP = userManager.FindByEmail(user.Username);

                usersView.Add(new UserIndexView
                {
                    Address = user.Address,
                    FirstName = user.FirstName,
                    IsAdmin = userASP != null && userManager.IsInRole(userASP.Id, "Admin"),
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    Id = user.Id,
                    Username = user.Username,


                });
            }

            return View(usersView);
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserView userView)
        {
            if (!ModelState.IsValid)
            {
                return View(userView);
            }

            //Save record:
            var user = new User
            {
                Address = userView.Address,
                FirstName = userView.FirstName,
                MiddleName = userView.MiddleName,
                LastName = userView.LastName,
                Username = userView.userName
            };

            context.Users.Add(user);

            try
            {
                context.SaveChanges();
                createASPUser(userView);

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null
                    && ex.InnerException.InnerException.Message.Contains("userNameIndex"))
                {
                    ViewBag.Error = "The Email has already used for another User.";
                }
                else
                {
                    ViewBag.Error = ex.Message;
                }

                return View(userView);
            }

            return RedirectToAction("Index");


        }

        private void createASPUser(UserView userView)
        {
            //User management:
            var userContext = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

            //Create User Role:
            string roleName = "User";

            //Check to see if Role Exist, if not create it:
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));

            }

            //Create the ASP NET User:
            var userASP = new ApplicationUser
            {
                UserName = userView.userName,
                Email = userView.userName,
            };

            userManager.Create(userASP, userASP.UserName);

            //Add user to role:
            userASP = userManager.FindByName(userView.userName);
            userManager.AddToRole(userASP.Id, "User");
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userView = new UserView
            {
                UserId = user.Id,
                Address = user.Address,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                userName = user.Username,
            };

            return View(userView);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserView userView)
        {
            if (!ModelState.IsValid)
            {

                return View(userView);

            }

            var user = context.Users.Find(userView.UserId);

            user.Address = userView.Address;
            user.FirstName = userView.FirstName;
            user.MiddleName = userView.MiddleName;
            user.LastName = userView.LastName;

            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = context.Users.Find(id);
            context.Users.Remove(user);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null && ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {

                    ModelState.AddModelError(string.Empty, "The record can't be deleted, because has related records");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                return View(user);
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

