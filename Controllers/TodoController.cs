
using Microsoft.AspNetCore.Mvc;
using TodoCRUD.Models;
using TodoCRUD.Data;
using TodoCRUD.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Azure.Core;

namespace TodoCRUD.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Todos.ToListAsync());
        }

        [HttpPost]
        public PartialViewResult ListFind([FromBody] TodoFilter request)
        {
            if (request.Name == null)
            {
                request.Name = "";
            }
            Expression<Func<Todo, bool>> filter = r => r.Name.Contains(request.Name);
            var datas = _context.Todos.Where(filter).AsEnumerable().ToList();
            if (request.active != null && request.active != 2)
            {
                filter = filter.And(r => r.active.Equals(request.active));
                datas = _context.Todos.Where(filter).AsEnumerable().ToList();
            }
            return PartialView(datas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? itemid)
        {
            var todo = await _context.Todos.FindAsync(itemid);
            if (todo != null) {
                _context.Remove(todo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? itemid)
        {
            var todo = await _context.Todos.FindAsync(itemid);
            if (todo != null)
            {
                short type = (short)(todo.type == 0 ? 1 : 0);
                todo.type = type;
                _context.Update(todo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
