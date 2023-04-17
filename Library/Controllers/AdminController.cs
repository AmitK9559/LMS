using Library.DBContext;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Controllers
{
    public class AdminController : Controller
    {
        private ResultDB _context;

        public AdminController(ResultDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AdminLogin model)
        {
            try
            {
                var user = await _context.AdminLog.SingleOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user == null)
                {
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("ID", user.ID.ToString());
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Email", user.Email);
                    return RedirectToAction( "Dashboard", "CMSDashboard");
                }
            }
            catch (Exception ex)
            {
                string Message=ex.Message;
                return View();

            }        
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("ID");
            return RedirectToAction("Index");
        }
    }
}
