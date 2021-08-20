using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoC.CallLogMvc.Web02.Data;
using PoC.CallLogMvc.Web02.Data.Models;

namespace PoC.CallLogMvc.Web02.Controllers
{
    public class CallLogController : Controller
    {
        private readonly HelpDeskDbContext _context;

        public CallLogController(HelpDeskDbContext context)
        {
            _context = context;
        }

        // GET: CallLog
        public async Task<IActionResult> Index()
        {
            var helpDeskDbContext = _context.CallLog.Include(c => c.CallStatus);
            return View(await helpDeskDbContext.ToListAsync());
        }

        // GET: CallLog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callLog = await _context.CallLog
                .Include(c => c.CallStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callLog == null)
            {
                return NotFound();
            }

            return View(callLog);
        }

        // GET: CallLog/Create
        public IActionResult Create()
        {
            ViewData["CallStatusId"] = new SelectList(_context.CallStatus, "Id", "Name");
            return View();
        }

        // POST: CallLog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Caller,Title,Problem,Solution,CallStatusId,WhenCreated")] CallLog callLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(callLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CallStatusId"] = new SelectList(_context.CallStatus, "Id", "Id", callLog.CallStatusId);
            return View(callLog);
        }

        // GET: CallLog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callLog = await _context.CallLog.FindAsync(id);
            if (callLog == null)
            {
                return NotFound();
            }
            ViewData["CallStatusId"] = new SelectList(_context.CallStatus, "Id", "Name", callLog.CallStatusId);
            return View(callLog);
        }

        // POST: CallLog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Caller,Title,Problem,Solution,CallStatusId,WhenCreated")] CallLog callLog)
        {
            if (id != callLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(callLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CallLogExists(callLog.Id))
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
            ViewData["CallStatusId"] = new SelectList(_context.CallStatus, "Id", "Id", callLog.CallStatusId);
            return View(callLog);
        }

        // GET: CallLog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callLog = await _context.CallLog
                .Include(c => c.CallStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callLog == null)
            {
                return NotFound();
            }

            return View(callLog);
        }

        // POST: CallLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var callLog = await _context.CallLog.FindAsync(id);
            _context.CallLog.Remove(callLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CallLogExists(int id)
        {
            return _context.CallLog.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            var callLogs = _context.CallLog
                .Include(c => c.CallStatus)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                callLogs = callLogs.Where(cl => 
                    cl.Caller.Contains(searchString) || cl.Title.Contains(searchString));
            }
            
            return View(await callLogs.ToListAsync());
        }
    }
}
