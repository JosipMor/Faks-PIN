using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baza_automobila.Data;
using BazaAutomobila.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BazaAutomobila.Controllers
{
    [Authorize]
    public class ModelAutomobilaController : Controller
    {
        private readonly ApplicationDbContext context;

        public ModelAutomobilaController(ApplicationDbContext _context)
        {
            context = _context;
        }

        // GET: MarkaAutomobila
        public ActionResult Index()
        {
            List<ModelAutomobila> Automobili = context.ModelAutomobila.Include(x=> x.MarkaAutomobila).ToList();
            return View(Automobili);
        }

        // GET: ModelAutomobila/Details/5
        public ActionResult Details(int id)
        {
            ModelAutomobila automobil = context.ModelAutomobila.Include(x => x.MarkaAutomobila).Where(x => x.Id == id).FirstOrDefault();
            return View(automobil);
        }

        // GET: ModelAutomobila/Create
        public ActionResult Create()
        {
            ViewBag.Marka = context.MarkaAutomobila
                           .Select(u => new SelectListItem
                           {
                               Text = u.Naziv,
                               Value = u.Id.ToString()
                           });
            return View();
        }

        // POST: ModelAutomobila/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelAutomobila automobil)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.ModelAutomobila.Add(automobil);
                    context.SaveChanges();

                }

                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ModelAutomobila/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Marka = context.MarkaAutomobila
               .Select(u => new SelectListItem
               {
                   Text = u.Naziv,
                   Value = u.Id.ToString()
               });

            ModelAutomobila automobil = context.ModelAutomobila.Where(x => x.Id == id).FirstOrDefault();
            return View(automobil);
        }

        // POST: ModelAutomobila/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModelAutomobila automobil)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(automobil).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ModelAutomobila/Delete/5
        public ActionResult Delete(int id)
        {
            ModelAutomobila automobil = context.ModelAutomobila.Include(x => x.MarkaAutomobila).Where(x => x.Id == id).FirstOrDefault();
            return View(automobil);
        }

        // POST: ModelAutomobila/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ModelAutomobila automobil)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.ModelAutomobila.Remove(automobil);
                    context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}