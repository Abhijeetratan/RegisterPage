using Microsoft.AspNetCore.Mvc;
using RegisterPage.Models;
using System;

namespace RegisterPage.Controllers
{
    public class RegController : Controller
    {
        private readonly RegContext _dbContext;
        //here you have to context class object
        public RegController(RegContext dbContext)
        {
            _dbContext = dbContext;//store constructor object into EmpContext obj
        }

        public IActionResult Index()
        {
            var regs = _dbContext.regs.ToList();
            return View(regs);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Reg reg)
        {
            if (ModelState.IsValid)
            {
                _dbContext.regs.Add(reg);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reg);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _dbContext.regs.Find(id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Reg reg)
        {
            if (id != reg.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _dbContext.regs.Update(reg);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(reg);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.regs.Find(id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteComfirmed(int id)
        {
            var entity = _dbContext.regs.Find(id);
            _dbContext.regs.Remove(entity);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
