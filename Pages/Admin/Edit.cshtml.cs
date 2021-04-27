using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext _context;

        public EditModel(MyPortfolio.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MyPortfolioInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyPortfolioInfoExists(MyPortfolioInfo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MyPortfolioInfoExists(int id)
        {
            return _context.MyPortfolioInfo.Any(e => e.Id == id);
        }
    }
}
