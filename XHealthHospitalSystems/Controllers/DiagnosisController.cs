﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XHealthHospitalSystems.Models;

namespace XHealthHospitalSystems.Controllers
{
    public class DiagnosisController : Controller
    {
        private readonly MyDbContext _context;

        public DiagnosisController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Diagnosis
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Diagnoses.Include(d => d.Patient);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Diagnosis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.DiagnosisId == id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            return View(diagnosis);
        }

        // GET: Diagnosis/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            return View();
        }

        // POST: Diagnosis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiagnosisId,Date,Symtoms,Diagnosiss,MedsPres,TestsPres,PatientId")] Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diagnosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", diagnosis.PatientId);
            return View(diagnosis);
        }

        // GET: Diagnosis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if (diagnosis == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", diagnosis.PatientId);
            return View(diagnosis);
        }

        // POST: Diagnosis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiagnosisId,Date,Symtoms,Diagnosiss,MedsPres,TestsPres,PatientId")] Diagnosis diagnosis)
        {
            if (id != diagnosis.DiagnosisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosisExists(diagnosis.DiagnosisId))
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
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", diagnosis.PatientId);
            return View(diagnosis);
        }

        // GET: Diagnosis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.DiagnosisId == id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            return View(diagnosis);
        }

        // POST: Diagnosis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diagnosis = await _context.Diagnoses.FindAsync(id);
            _context.Diagnoses.Remove(diagnosis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiagnosisExists(int id)
        {
            return _context.Diagnoses.Any(e => e.DiagnosisId == id);
        }
    }
}
