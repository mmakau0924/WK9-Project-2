using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab9_2.Data;
using Lab9_2.Models;

namespace Lab9_2.Pages.BizInfo
{
    public class CreateModel : PageModel
    {
        private readonly Lab9_2.Data.ApplicationDbContext _context;

        public CreateModel(Lab9_2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BizInfoModel BizInfoModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BizInfoModel == null || BizInfoModel == null)
            {
                return Page();
            }

            _context.BizInfoModel.Add(BizInfoModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
