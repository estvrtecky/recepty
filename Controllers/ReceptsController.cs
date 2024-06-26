﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReceptModel;
using Recepty.Data;

namespace Recepty.Controllers
{
    public class ReceptsController : Controller
    {
        private readonly ReceptDbContext _context;

        public ReceptsController(ReceptDbContext context)
        {
            _context = context;
        }

        // GET: Recepts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recept.ToListAsync());
        }

        // GET: Recepts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recept = await _context.Recept
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recept == null)
            {
                return NotFound();
            }

            return View(recept);
        }

        // GET: Recepts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recepts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Ingredients,Instructions,Category,Difficulty,Time,Servings,Author")] Recept recept)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recept);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recept);
        }

        // GET: Recepts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recept = await _context.Recept.FindAsync(id);
            if (recept == null)
            {
                return NotFound();
            }
            return View(recept);
        }

        // POST: Recepts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Ingredients,Instructions,Category,Difficulty,Time,Servings,Author")] Recept recept)
        {
            if (id != recept.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recept);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceptExists(recept.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recept);
        }

        // GET: Recepts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recept = await _context.Recept
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recept == null)
            {
                return NotFound();
            }

            return View(recept);
        }

        // POST: Recepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recept = await _context.Recept.FindAsync(id);
            if (recept != null)
            {
                _context.Recept.Remove(recept);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceptExists(int id)
        {
            return _context.Recept.Any(e => e.Id == id);
        }
    }
}
