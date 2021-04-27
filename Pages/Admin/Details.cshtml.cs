using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext _context;

        public DetailsModel(MyPortfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MyPortfolioInfo MyPortfolioInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyPortfolioInfo = await _context.MyPortfolioInfo.FirstOrDefaultAsync(m => m.Id == id);

            if (MyPortfolioInfo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
