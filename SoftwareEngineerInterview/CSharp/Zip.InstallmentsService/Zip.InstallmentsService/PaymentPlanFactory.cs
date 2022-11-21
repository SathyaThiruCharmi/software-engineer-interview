using System;
using System.Collections.Generic;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the Zip product definition.
    /// </summary>
    public class PaymentPlanFactory
    {
        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="purchaseAmount">The total amount for the purchase that the customer is making.</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public List<Installment> CreatePaymentPlan(PaymentPlan paymentPlan)
        {   
            paymentPlan.PaymentID = Guid.NewGuid();
            DateTime date = DateTime.Now;

            List<Installment> installments = new List<Installment>();

            for (int i = 0; i < paymentPlan.NoOfInstallments; i++)
            {
                Installment installment = new Installment();
                installment.InstallmentID = Guid.NewGuid();
                installment.PaymentID = paymentPlan.PaymentID;
                installment.DueDate = date;
                date = date.AddDays(paymentPlan.Frequency);
                installment.DueAmount = paymentPlan.PurchaseAmount / paymentPlan.NoOfInstallments;
                installments.Add(installment);
            }

            // TODO
            return installments;
        }

        public List<Installment> CreatePaymentPlan1(decimal PurchaseAmount, int Frequency, int NoofInstallments)
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            paymentPlan.PaymentID = Guid.NewGuid();
            DateTime date = DateTime.Now;

            List<Installment> installments = new List<Installment>();

            for (int i = 0; i < paymentPlan.NoOfInstallments; i++)
            {
                Installment installment = new Installment();
                installment.InstallmentID = Guid.NewGuid();
                installment.PaymentID = paymentPlan.PaymentID;
                installment.DueDate = date;
                date = date.AddDays(paymentPlan.Frequency);
                installment.DueAmount = paymentPlan.PurchaseAmount / paymentPlan.NoOfInstallments;
                installments.Add(installment);
            }

            // TODO
            return installments;
        }
    }
}
