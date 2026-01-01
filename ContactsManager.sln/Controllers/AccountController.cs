using Entities.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System.Threading.Tasks;

namespace ContactsManager.Controllers
{
    [AllowAnonymous]
    [Route("[Controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage).ToList();
                return View(registerDTO);
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.Phone,
                PersonName = registerDTO.PersonName
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registerDTO.Password);

            if (result.Succeeded)
            {
                //Check status of radio buttons
                if (registerDTO.UserType==UserTypeOptions.Admin)
                {
                    //Check if role exists
                    if (await _roleManager.FindByNameAsync(UserTypeOptions.Admin.ToString()) is null)
                    {
                        // Create the role
                        ApplicationRole applicationRole = new ApplicationRole()
                        {
                            Name = UserTypeOptions.Admin.ToString()                        
                        };
                        await _roleManager.CreateAsync(applicationRole);

                    }
                    //Add user to role
                    await _userManager.AddToRoleAsync(newUser, UserTypeOptions.Admin.ToString());
                }
                else
                {
                    //Check if role exists
                    if (await _roleManager.FindByNameAsync(UserTypeOptions.User.ToString()) is null)
                    {
                        // Create the role
                        ApplicationRole applicationRole = new ApplicationRole()
                        {
                            Name = UserTypeOptions.User.ToString()
                        };
                        await _roleManager.CreateAsync(applicationRole);

                    }
                    //Add user to role
                    await _userManager.AddToRoleAsync(newUser, UserTypeOptions.User.ToString());
                }

                // Sign in the user
                await _signInManager.SignInAsync(newUser, isPersistent: false);
                return RedirectToAction(nameof(PersonsController.Index),"Persons");                
            }
            else
            {

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                    ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage).ToList();
                }
            }

            return View(registerDTO);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage).ToList();
                return View(loginDTO);
            }


            // Sign in the user

            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email,loginDTO.Password,isPersistent:false,lockoutOnFailure:false);

            if (result.Succeeded)
            {                
                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                {
                    return LocalRedirect(ReturnUrl); // safely redirection to avoid post-side attack
                }
                return RedirectToAction(nameof(PersonsController.Index), "Persons");
            }


            ModelState.AddModelError("Login", "Invalid Email or Password");
            ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage).ToList();            
            return View();
        }

        [Route("[action]")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(PersonsController.Index), "Persons");
        }

        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return Json(user == null ? true  : false); //true = not in use(Valid), false = in use(Invalid)
        }
    }
}
