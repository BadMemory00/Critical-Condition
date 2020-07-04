﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PleaseWorkDamnIt.Data;
using PleaseWorkDamnIt.Models;

namespace PleaseWorkDamnIt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PleaseWorkDamnItDB context;

        public IndexModel(ILogger<IndexModel> logger,PleaseWorkDamnItDB context)
        {
            _logger = logger;
            this.context = context;
        }
        
        [BindProperty]
        public IList<Device> Device { get; set; }


        public async Task OnGetAsync()
        {
            Device = await context.Device.ToListAsync();
        }

    }
}