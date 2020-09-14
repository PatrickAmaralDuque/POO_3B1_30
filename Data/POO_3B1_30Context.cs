using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POO_3B1_30.DTO;

namespace POO_3B1_30.Data
{
    public class POO_3B1_30Context : DbContext
    {
        public POO_3B1_30Context (DbContextOptions<POO_3B1_30Context> options)
            : base(options)
        {
        }

        public DbSet<POO_3B1_30.DTO.BancoDTO> BancoDTO { get; set; }
    }
}
