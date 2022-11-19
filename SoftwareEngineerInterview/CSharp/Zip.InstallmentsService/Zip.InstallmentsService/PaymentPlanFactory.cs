using System;

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
        public PaymentPlan CreatePaymentPlan(PaymentPlan paymentPlan)
        {   
            Installment installment = new Installment();
            decimal installmentAmount = paymentPlan.PurchaseAmount / paymentPlan.Installment;

            for (int i = 0; i < paymentPlan.Installment; i++)
            {
                installment.Id = paymentPlan.Id;
                installment.DueDate = DateTime.Now.AddDays(paymentPlan.Frequeny);
                installment.Amount= installmentAmount;
                paymentPlan.Installments.Add(installment);
            }

            // TODO
            return paymentPlan;
        }

        public PaymentPlan CreatePaymentPlan1(decimal payment, int installment, int frequency)
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            Installment installments = new Installment();

            paymentPlan.Installment = installment;
            paymentPlan.Frequeny = frequency;
            
            decimal installmentAmount = payment / installment;

            for (int i = 1; i < paymentPlan.Installment; i++)
            {
                installments.Id = Guid.NewGuid();
                installments.DueDate = DateTime.Now.AddDays(paymentPlan.Frequeny);
                installments.Amount = installmentAmount;
                paymentPlan.Installments.Add(installments);
            }

            // TODO
            return paymentPlan;
        }
    }
}
