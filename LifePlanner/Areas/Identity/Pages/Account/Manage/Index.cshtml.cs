using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LifePlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifePlanner.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<RegistrovaniKorisnik> _userManager;
        private readonly SignInManager<RegistrovaniKorisnik> _signInManager;

        public IndexModel(
            UserManager<RegistrovaniKorisnik> userManager,
            SignInManager<RegistrovaniKorisnik> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Ime")]
            public string Ime { get; set; }

            [Display(Name = "Prezime")]
            public string Prezime { get; set; }
        }

        private async Task LoadAsync(RegistrovaniKorisnik user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Ime = user.Ime,
                Prezime = user.Prezime
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var ime = user.Ime;
            var prezime = user.Prezime;
            if (Input.Ime != ime || Input.Prezime != prezime)
            {
                user.Ime = Input.Ime;
                user.Prezime = Input.Prezime;
                var rezultat = await _userManager.UpdateAsync(user);
                if (!rezultat.Succeeded)
                {
                    StatusMessage = "Neočekivana greška prilikom izmjene imena i prezimena";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
