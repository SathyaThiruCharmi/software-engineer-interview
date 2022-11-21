using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Zip.InstallmentService.Api.Data
{
    public class ZipInstallmentServiceApiContext : DbContext
    {
        public ZipInstallmentServiceApiContext (DbContextOptions<ZipInstallmentServiceApiContext> options)
            : base(options)
        {
        }

        public DbSet<Zip.InstallmentsService.PaymentPlan> PaymentPlan { get; set; } = default!;

        public DbSet<Zip.InstallmentsService.Installment> Installment { get; set; } = default!;

    }
}
