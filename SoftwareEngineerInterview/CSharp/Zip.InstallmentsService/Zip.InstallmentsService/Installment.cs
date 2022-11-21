using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// Data structure which defines all the properties for an installment.
    /// </summary>
    public class Installment
    {
        public System.Guid InstallmentID { get; set; }
        public System.DateTime DueDate { get; set; }
        public decimal DueAmount { get; set; }
        public System.Guid PaymentID { get; set; }
    }
}
