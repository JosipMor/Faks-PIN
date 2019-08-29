using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baza_automobila.Data;
using BazaAutomobila.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BazaAutomobila.Controllers
{
    public class MarkaAutomobilaController : Controller
    {
        private readonly ApplicationDbContext context;

        public MarkaAutomobilaController(ApplicationDbContext _context)
        {
            context = _context;
        }
        // GET: MarkaAutomobila

        public ActionResult Index()
        {
            List<MarkaAutomobila> Automobili = context.MarkaAutomobila.ToList();


            return View(Automobili);
        }

        // GET: MarkaAutomobila/Details/5
        public ActionResult Details(int id)
        {
            MarkaAutomobila automobil = context.MarkaAutomobila.Where(x => x.Id == id).FirstOrDefault();

            return View(automobil);
        }

        // GET: MarkaAutomobila/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarkaAutomobila/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarkaAutomobila automobil)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.MarkaAutomobila.Add(automobil);
                    context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MarkaAutomobila/Edit/5
        public ActionResult Edit(int id)
        {
            MarkaAutomobila automobil = context.MarkaAutomobila.Where(x => x.Id == id).FirstOrDefault();

            return View(automobil);
        }

        // POST: MarkaAutomobila/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarkaAutomobila automobil)
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

        // GET: MarkaAutomobila/Delete/5
        public ActionResult Delete(int id)
        {
            MarkaAutomobila automobil = context.MarkaAutomobila.Where(x => x.Id == id).FirstOrDefault();
            return View(automobil);
        }

        // POST: MarkaAutomobila/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MarkaAutomobila automobil)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.MarkaAutomobila.Remove(automobil);
                    context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Modeli(int Id)
        {
            List<ModelAutomobila> ModeliAutomobila = context.ModelAutomobila.Include(a=> a.MarkaAutomobila).Where(x => x.MarkaAutomobilaId == Id).ToList();
            return View(ModeliAutomobila);
        }
    }
}