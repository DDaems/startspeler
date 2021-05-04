using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using StartspelerMVC.Models;
using StartspelerMVC.Areas.Identity;

namespace StartspelerMVC.Areas.Admin.Models
{
    [Authorize(Roles = "Admin")]
    public class CreateModel
    {

        public CreateModel()
        {

        }

        //[BindProperty]
        //public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        //public class InputModel
        //{
            [Required]
            [Display(Name = "Alias")]
            public string Usernaam { get; set; }

            [Required]
            [Display(Name = "Naam")]
            public string Achternaam { get; set; }

            [Required]
            [Display(Name = "Voornaam")]
            public string Voornaam { get; set; }

            [Required]
            [DataType(DataType.Date, ErrorMessage = "* geen geldige datum")]
            [Display(Name = "Geboortedatum")]
            public string Geboortedatum { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(4, ErrorMessage = "De pincode moet bestaan uit {2} cijfers", MinimumLength = 4)]
            [DataType(DataType.Password)]
            [Display(Name = "Pincode")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Bevestig pincode")]
            [Compare("Password", ErrorMessage = "De pincode komt niet overeen.")]
            public string ConfirmPassword { get; set; }
       // }
    }
}
