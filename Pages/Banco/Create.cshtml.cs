using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using POO_3B1_30.DTO;
using POO_3B1_30.Data;

namespace POO_3B1_30.Pages.Banco
{
    public class CreateModel : PageModel
    {
        private readonly POO_3B1_30.Data.POO_3B1_30Context _context;

        public CreateModel(POO_3B1_30.Data.POO_3B1_30Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BancoDTO BancoDTO { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BancoDTO.Add(BancoDTO);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
