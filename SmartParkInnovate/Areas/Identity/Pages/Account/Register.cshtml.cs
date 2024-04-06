#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartParkInnovate.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

namespace SmartParkInnovate.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Worker> _signInManager;
        private readonly UserManager<Worker> _userManager;
        private readonly IUserStore<Worker> _userStore;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<Worker> userManager,
            IUserStore<Worker> userStore,
            SignInManager<Worker> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(WorkerDataConstants.MaxPasswordLength, ErrorMessage = WorkerErrorMessages.InvalidPasswordErrorMessage, MinimumLength = WorkerDataConstants.MinPasswordLength)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = WorkerErrorMessages.PasswordAndConfirmedPasswordDoesNotMatchErrorMessage)]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(WorkerDataConstants.FirstNameMaxLength, ErrorMessage = WorkerErrorMessages.FirstNameCharactersErrorMessage, MinimumLength = WorkerDataConstants.FirstNameMinLength)]
            public string FirstName { get; set; }

            [Required]
            [StringLength(WorkerDataConstants.LastNameMaxLength, ErrorMessage = WorkerErrorMessages.LastNameCharactersErrorMessage, MinimumLength = WorkerDataConstants.LastNameMinLength)]
            public string LastName { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                Worker user = CreateUser();

                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);

                IdentityResult result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        private Worker CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Worker>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Worker)}'. " +
                    $"Ensure that '{nameof(Worker)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<Worker> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Worker>)_userStore;
        }
    }
}
