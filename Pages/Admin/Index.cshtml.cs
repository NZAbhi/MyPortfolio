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
    public class IndexModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext _context;

        public IndexModel(MyPortfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MyPortfolioInfo> MyPortfolioInfo { get;set; }

        public async Task OnGetAsync()
        {
            MyPortfolioInfo = await _context.MyPortfolioInfo.ToListAsync();
        }
    }
}
