using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using LifePlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace LifePlanner.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<RegistrovaniKorisnik> _userManager;
        private readonly SignInManager<RegistrovaniKorisnik> _signInManager;

        public ConfirmEmailModel(UserManager<RegistrovaniKorisnik> userManager, SignInManager<RegistrovaniKorisnik> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public bool Uspjelo { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            StatusMessage = result.Succeeded ? "Čestitamo. Vaš email je potvrđen." : "Desila se greska prilikom potvrde email-a. Molimo kontaktirajte administratora na lifeplannerdemo@gmail.com";
            Uspjelo = result.Succeeded;
            if (Uspjelo)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return Page();
        }
    }
}
