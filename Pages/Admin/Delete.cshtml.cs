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
    public class DeleteModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext _context;

        public DeleteModel(MyPortfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyPortfolioInfo = await _context.MyPortfolioInfo.FindAsync(id);

            if (MyPortfolioInfo != null)
            {
                _context.MyPortfolioInfo.Remove(MyPortfolioInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
