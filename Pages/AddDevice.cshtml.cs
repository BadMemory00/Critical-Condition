using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public string Safe { get; set; }
        public string[] Safes = { "Negligible", "Minor", "Serious", "Critical", "Catastrophic" };
        [BindProperty]
        public Device Device { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            context.Device.Add(Device);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}