using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// Data structure which defines all the properties for a purchase installment plan.
    /// </summary>
    public class PaymentPlan
    {
        [Key]
        public System.Guid PaymentID { get; set; }
        public decimal PurchaseAmount { get; set; }
        public int Frequency { get; set; }
        public int NoOfInstallments { get; set; }
    }
}
