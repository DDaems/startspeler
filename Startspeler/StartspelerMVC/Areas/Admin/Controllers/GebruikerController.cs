using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartspelerMVC.Data;
using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using StartspelerMVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace StartspelerMVC.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class GebruikerController : Controller
    {
        private readonly StartspelerContext ctx;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CreateModel> _logger;
        private readonly IEmailSender _emailSender;

        List<User> users;
        public GebruikerController(StartspelerContext ctx,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
                ILogger<CreateModel> logger,
                IEmailSender emailSender)
        {
            this.ctx = ctx;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            this.ctx = ctx;
        }

        public async Task<IActionResult> Index()
        {
            users = await ctx.Users.Include(x => x.Drankkaarten).ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Update(string id)
        {
            if (id == null) { return RedirectToAction(nameof(Index)); }

            var user = await ctx.Users.AsNoTracking().FirstAsync(x => x.Id == id);
            if (user == null) { return NotFound(); }
 
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(User model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await ctx.Users.AsNoTracking().FirstAsync(x => x.Id == model.Id);

                    if (user != null)
                    {
                        user.UserName = model.UserName;
                        user.Voornaam = model.Voornaam;
                        user.Achternaam = model.Achternaam;
                        user.Email = model.Email;
                     
                       await _userManager.UpdateAsync(user);
                       await ctx.SaveChangesAsync();

                    }

                }
                catch (Exception e)
                {
                    var txt = e;
                    
                    _logger.LogInformation("Update gebruiker in database is gefaald.");
                }
            }
            return RedirectToAction(nameof(Index));

        }

            public async Task<IActionResult> Delete(string id)
        {
            if (id == null) { return RedirectToAction(nameof(Index)); }

            var user = await ctx.Users.FindAsync(id);
                if (user == null) { return NotFound(); }

            ctx.Users.Remove(user);
            await ctx.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Gebruiker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gebruiker/Create
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateModel model){
            // _userManager.Options.User.RequireUniqueEmail = false;
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Achternaam = model.Achternaam,
                    Voornaam = model.Voornaam,
                    Geboortedatum = Convert.ToDateTime(model.Geboortedatum),
                    UserName = model.Usernaam,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Beheerder created a new account with password.");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                      "/Account/ConfirmEmail",
                      pageHandler: null,
                      values: new { area = "Identity", userId = user.Id, code = code, returnUrl = "Index" },
                      protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(model.Email, "Bevesting je e-mail",
                        $"Alstublieft bevestig uw account door <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>op mij te klikken</a>.");

                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return RedirectToAction(nameof(Index));
        }

    }
}
