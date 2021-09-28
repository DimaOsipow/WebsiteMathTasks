using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebsiteMathTasks.Data;
using WebsiteMathTasks.Models;


namespace WebsiteMathTasks.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        public ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewData["ConditionSortParm"] = sortOrder == "Сondition" ? "Сondition_desc" : "Сondition";
            ViewData["ThemeSortParm"] = sortOrder == "theme" ? "theme_desc" : "theme";
            ViewData["CurrentFilter"] = searchString;
            var tasks = from s in _context.Tasks
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                tasks = tasks.Where(s => s.Name.Contains(searchString)
                                       || s.Сondition.Contains(searchString)
                                       || s.theme.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    tasks = tasks.OrderBy(s => s.Name);
                    break;
                case "Сondition":
                    tasks = tasks.OrderBy(s => s.Сondition);
                    break;
                case "Сondition_desc":
                    tasks = tasks.OrderByDescending(s => s.Сondition);
                    break;
                case "theme":
                    tasks = tasks.OrderBy(s => s.theme);
                    break;
                case "theme_desc":
                    tasks = tasks.OrderByDescending(s => s.theme);
                    break;
                default:
                    tasks = tasks.OrderByDescending(s => s.Name);
                    break;
            }
            return View(await tasks.AsNoTracking().ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Models.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Models.Task task = await _context.Tasks.FirstOrDefaultAsync(p => p.Id == id);
                if (task != null)
                    return View(task);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(Models.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
