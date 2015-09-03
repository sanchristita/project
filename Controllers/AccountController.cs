using ChemisTrackCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChemisTrackCrud.Controllers
{
    public class AccountController : Controller
    {
        
        private Context db = new Context();

        public int usid = 1;

	    public ActionResult Index()
	    {
		    return View();
	    }

        public bool isLoggedIn() 
        {
            if (FormsAuthentication.IsEnabled)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public ActionResult logOut() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
	
	    public ActionResult LogIn()
	    {
		    return View();
	    }
	
	    [HttpPost]
	    public ActionResult LogIn(AccountModel user)
	    {
		    if (ModelState.IsValid) 
            {
                if (IsValid(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    ModelState.AddModelError("", "Login Data is incorrect");
                }
            }
            
            return View(user);
	    }
	
	    public ActionResult Register()
	    {
		    return View();
	    }
	
	    [HttpPost]
	    public ActionResult Register(AccountModel user)
	    {
		    if (ModelState.IsValid) 
            {
                using (var db = new Context())
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrptPass = crypto.Compute(user.Password);
                    var sysuser = db.UserAccounts.Create();
                    sysuser.UserName = user.UserName;
                    sysuser.Password = encrptPass;
                    sysuser.PasswordSalt = crypto.Salt;
                    sysuser.userID = usid;
                    usid++;
                    //sysuser.Role = user.Role;

                    db.UserAccounts.Add(sysuser);
                    db.SaveChanges();

                    return RedirectToAction("Login", "Account");
                }
               
            }
            else 
            {
                ModelState.AddModelError("", "Login Data is incorrect");
            }
            return View();
	    }
	
	    private bool IsValid(string username, string password)
	    {
            bool isValid = false;
		    
            var crypto = new SimpleCrypto.PBKDF2();
		
		    using(var db = new Context())
		    {
                var user = db.UserAccounts.FirstOrDefault(u => u.UserName == username);

                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt)) 
                    {
                        isValid = true;
                    }
                }
		    }
		    
		
		    return isValid;
	    }
    }
}
