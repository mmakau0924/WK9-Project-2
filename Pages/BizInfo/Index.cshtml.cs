using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab9_2.Data;
using Lab9_2.Models;

namespace Lab9_2.Pages.BizInfo
{
    public class IndexModel : PageModel
    {
        private readonly Lab9_2.Data.ApplicationDbContext _context;

        public IndexModel(Lab9_2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BizInfoModel> BizInfoModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BizInfoModel != null)
            {
                BizInfoModel = await _context.BizInfoModel.ToListAsync();
            }
        }
    }
}
