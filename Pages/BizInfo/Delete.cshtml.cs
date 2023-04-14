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
    public class DeleteModel : PageModel
    {
        private readonly Lab9_2.Data.ApplicationDbContext _context;

        public DeleteModel(Lab9_2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BizInfoModel BizInfoModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BizInfoModel == null)
            {
                return NotFound();
            }

            var bizinfomodel = await _context.BizInfoModel.FirstOrDefaultAsync(m => m.Id == id);

            if (bizinfomodel == null)
            {
                return NotFound();
            }
            else 
            {
                BizInfoModel = bizinfomodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BizInfoModel == null)
            {
                return NotFound();
            }
            var bizinfomodel = await _context.BizInfoModel.FindAsync(id);

            if (bizinfomodel != null)
            {
                BizInfoModel = bizinfomodel;
                _context.BizInfoModel.Remove(BizInfoModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
