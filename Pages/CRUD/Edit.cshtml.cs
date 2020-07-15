using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PleaseWorkDamnIt.Data;
using PleaseWorkDamnIt.Models;

namespace PleaseWorkDamnIt
{
    public class EditModel : PageModel
    {
        private readonly PleaseWorkDamnItDB _context;

        public EditModel(PleaseWorkDamnItDB context)
        {
            _context = context;
        }

        [BindProperty]
        public Device Device { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device = await _context.Device.FirstOrDefaultAsync(m => m.ID == id);

            if (Device == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Device).State = EntityState.Modified;

            try
            {
                double Importance = Math.Ceiling(((double)Device.Function + (double)Device.Area) / 2);
                Device.DeviceScore = (Device.UtilizationRate() + Device.Unavailability() + Device.AgeFactor()) * ((int)Device.Safety + (int)Importance + Device.FinancialScore()) * (int)Device.Detection;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(Device.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }

        private bool DeviceExists(int id)
        {
            return _context.Device.Any(e => e.ID == id);
        }
    }
}
