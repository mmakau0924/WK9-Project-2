using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab9_2.Data;
using Lab9_2.Models;

namespace Lab9_2.Pages.BizInfo
{
    public class EditModel : PageModel
    {
        private readonly Lab9_2.Data.ApplicationDbContext _context;

        public EditModel(Lab9_2.Data.ApplicationDbContext context)
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

            var bizinfomodel =  await _context.BizInfoModel.FirstOrDefaultAsync(m => m.Id == id);
            if (bizinfomodel == null)
            {
                return NotFound();
            }
            BizInfoModel = bizinfomodel;
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

            _context.Attach(BizInfoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BizInfoModelExists(BizInfoModel.Id))
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

        private bool BizInfoModelExists(int id)
        {
          return (_context.BizInfoModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
