using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesSettings.Models;

namespace RazorPagesSettings.Data
{
    public class RazorPagesSettingsContext : DbContext
    {
        public RazorPagesSettingsContext (DbContextOptions<RazorPagesSettingsContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesSettings.Models.Settings> Settings { get; set; } = default!;
    }
}