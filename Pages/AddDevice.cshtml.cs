using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PleaseWorkDamnIt.Data;
using PleaseWorkDamnIt.Models;

namespace PleaseWorkDamnIt
{
    public class AddDeviceModel : PageModel
    {
        private readonly PleaseWorkDamnItDB context;

        public AddDeviceModel(PleaseWorkDamnItDB context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Device Device { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            double Importance = Math.Ceiling(((double)Device.Function + (double)Device.Area) / 2);
            Device.DeviceScore = (Device.UtilizationRate() + Device.Unavailability() + Device.AgeFactor()) * ((int)Device.Safety + (int)Importance + Device.FinancialScore()) * (int)Device.Detection;
            context.Device.Add(Device);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}