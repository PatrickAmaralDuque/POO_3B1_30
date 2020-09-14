using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POO_3B1_30.DTO;
using POO_3B1_30.Data;

namespace POO_3B1_30.Pages.Banco
{
    public class EditModel : PageModel
    {
        private readonly POO_3B1_30.Data.POO_3B1_30Context _context;

        public EditModel(POO_3B1_30.Data.POO_3B1_30Context context)
        {
            _context = context;
        }

        [BindProperty]
        public BancoDTO BancoDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BancoDTO = await _context.BancoDTO.FirstOrDefaultAsync(m => m.ID == id);

            if (BancoDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BancoDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BancoDTOExists(BancoDTO.ID))
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

        private bool BancoDTOExists(int id)
        {
            return _context.BancoDTO.Any(e => e.ID == id);
        }
    }
}
