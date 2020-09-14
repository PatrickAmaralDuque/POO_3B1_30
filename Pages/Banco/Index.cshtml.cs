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
    public class IndexModel : PageModel
    {
        private readonly POO_3B1_30.Data.POO_3B1_30Context _context;

        public IndexModel(POO_3B1_30.Data.POO_3B1_30Context context)
        {
            _context = context;
        }

        public IList<BancoDTO> BancoDTO { get;set; }

        public async Task OnGetAsync()
        {
            BancoDTO = await _context.BancoDTO.ToListAsync();
        }
    }
}
