using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebsiteMathTasks.Data;
using WebsiteMathTasks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;

namespace WebsiteMathTasks.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        public ApplicationDbContext _context;
        public UserManager<IdentityUser> _userManager;

        public SignInManager<IdentityUser> _signInManager;
        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        public IActionResult SetCulture(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
        public async Task <IActionResult> Acc(string sortorder, string searchstring)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortorder) ? "name_desc" : "";
            ViewData["ConditionSortParm"] = sortorder == "condition" ? "condition_desc" : "condition";
            ViewData["ThemeSortParm"] = sortorder == "theme" ? "theme_desc" : "theme";
            ViewData["CurrentFilter"] = searchstring;

            var tasks = from s in _context.Tasks
                           select s;

            if (!String.IsNullOrEmpty(searchstring))
            {
                tasks = tasks.Where(s => s.Name.Contains(searchstring)
                                       || s.Description.Contains(searchstring)
                                       || s.Theme.Contains(searchstring));
            }
            switch (sortorder)
            {
                case "name_desc":
                    tasks = tasks.OrderBy(s => s.Name);
                    break;
                case "condition":
                    tasks = tasks.OrderBy(s => s.Description);
                    break;
                case "condition_desc":
                    tasks = tasks.OrderByDescending(s => s.Description);
                    break;
                case "theme":
                    tasks = tasks.OrderBy(s => s.Theme);
                    break;
                case "theme_desc":
                    tasks = tasks.OrderByDescending(s => s.Theme);
                    break;
                default:
                    tasks = tasks.OrderByDescending(s => s.Name);
                    break;
            }
            return View(await tasks.AsNoTracking().ToListAsync());
        }
        public IActionResult Create()
        {
            string[] theme = {"algebra", "geometry", "number theory", "Java" };
            SelectList selectLists = new SelectList ( theme, theme[0] );
            ViewBag.SelectItems = selectLists;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Models.Task task, string selectedItem)
        {   
            if (ModelState.IsValid)
            {
                task.Theme = selectedItem;
                task.UserName = User.Identity.Name;
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction("Acc");
            }
            else
            {
                Create();
                return View("create");
            }
        }
        
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {

            if (id != null)
            {
                Models.Task task = await _context.Tasks.FirstOrDefaultAsync(p => p.Id == id);

                IndexViewModel indexViewModel = await _context.indexViewModels.FirstOrDefaultAsync(p => p.userAnswerModels.DefendantName == User.Identity.Name && p.tasks.Id == id);
                if (task != null)
                {
                    if (indexViewModel == null )
                    {
                        UserAnswerModel userAnswerModel = new UserAnswerModel { DefendantName = User.Identity.Name, UserTask = task.UserName };
                        _context.UserAnswerModels.Add(userAnswerModel);
                        userAnswerModel.Tasks.Add(task);
                        _context.SaveChanges();
                    }

                    indexViewModel = await _context.indexViewModels.FirstOrDefaultAsync(p => p.userAnswerModels.DefendantName == User.Identity.Name && p.tasks.Id == id);
                    indexViewModel.userAnswerModels = await _context.UserAnswerModels.FirstOrDefaultAsync(p => p.Id == indexViewModel.UserAnswerModelId);
                    return View(indexViewModel);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Details(IndexViewModel indexViewModels, int? id)
        {
            
            Models.Task task = await _context.Tasks.FirstOrDefaultAsync(p => p.Id == id);
            IndexViewModel indexViewModel = await _context.indexViewModels.FirstOrDefaultAsync(p => p.userAnswerModels.DefendantName == User.Identity.Name && p.tasks.Id == id);
            UserAnswerModel userAnswerModel = await _context.UserAnswerModels.FirstOrDefaultAsync(p => p.Id == indexViewModel.UserAnswerModelId);
            if (indexViewModels.userAnswerModels.UserAnswer == null )
            {
                userAnswerModel.isRightAnswer = false;
            }
            else if ( indexViewModels.userAnswerModels.UserAnswer != task.Answer && indexViewModels.userAnswerModels.UserAnswer != task.SecondAnswer && indexViewModels.userAnswerModels.UserAnswer != task.ThirdAnswer )
            {
                userAnswerModel.isRightAnswer = false;
                userAnswerModel.UserAnswer = indexViewModels.userAnswerModels.UserAnswer;
                await _context.SaveChangesAsync();
            }
            else 
            {
                userAnswerModel.isRightAnswer = true;
                userAnswerModel.UserAnswer = indexViewModels.userAnswerModels.UserAnswer;
                await _context.SaveChangesAsync();
            }
            return View(indexViewModel);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                string[] theme = { "algebra", "geometry", "number theory", "Java" };
                SelectList selectLists = new SelectList(theme, theme[0]);
                ViewBag.SelectItems = selectLists;
                Models.Task task = await _context.Tasks.FirstOrDefaultAsync(p => p.Id == id);
                if (task != null)
                    return View(task);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Models.Task task, string selectedItem)
        {
            if (ModelState.IsValid)
            {

                _context.Tasks.Update(task);
                task.Theme = selectedItem;
                task.UserName = User.Identity.Name;
                await _context.SaveChangesAsync();
                return RedirectToAction("Acc");
            }
            else
            {
                string[] theme = { "algebra", "geometry", "number theory", "Java" };
                SelectList selectLists = new SelectList(theme, theme[0]);
                ViewBag.SelectItems = selectLists;
                return View(task);
            }
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Models.Task task = await _context.Tasks.FirstOrDefaultAsync(p => p.Id == id);
                if (task != null)
                    return View(task);
            }
            return NotFound();
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Models.Task task = new() { Id = id.Value };
                _context.Entry(task).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction("Acc");
            }
            return NotFound();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.ToListAsync());
        }
        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            var users = _context.Users.ToList();

            return View(users);
        }
        
        public async Task<IActionResult> AdminDetails(string? Id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            string currentUserId = user.Id ;

            var impersonatedUser = await _userManager.FindByIdAsync(Id);

            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(impersonatedUser);

            userPrincipal.Identities.First().AddClaim(new Claim("OriginalUserId", currentUserId));
            userPrincipal.Identities.First().AddClaim(new Claim("IsImpersonating", "true"));

            await _signInManager.SignOutAsync();

            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, userPrincipal);

            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> AdminReturn()
        {
            var originalUserId = User.FindFirst("OriginalUserId").Value;

            var originalUser = await _userManager.FindByIdAsync(originalUserId);

            await _signInManager.SignOutAsync();

            await _signInManager.SignInAsync(originalUser, isPersistent: true);

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
