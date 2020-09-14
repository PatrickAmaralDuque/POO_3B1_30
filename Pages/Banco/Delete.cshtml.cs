using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POO_3B1_30.DTO;
using POO_3B1_30.Data;

namespace POO_3B1_30.Pages.Banco
{
    public class DeleteModel : PageModel
    {
        private readonly POO_3B1_30.Data.POO_3B1_30Context _context;

        public DeleteModel(POO_3B1_30.Data.POO_3B1_30Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BancoDTO = await _context.BancoDTO.FindAsync(id);

            if (BancoDTO != null)
            {
                _context.BancoDTO.Remove(BancoDTO);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
