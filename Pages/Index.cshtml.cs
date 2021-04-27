using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyPortfolio.Data;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public IList<MyPortfolioInfo> MyInfos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            MyInfos = await _context.MyPortfolioInfo.ToListAsync();


            return Page();
        }

    }
}
