using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zip.InstallmentService.Api.Data;
using Zip.InstallmentsService;

namespace Zip.InstallmentService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentPlansController : ControllerBase
    {
        private readonly ZipInstallmentServiceApiContext _context;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="context"></param>
        public PaymentPlansController(ZipInstallmentServiceApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Getting all the payment plans and corresponding installments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentPlan>>> GetPaymentPlan()
        {
            return await _context.PaymentPlan.ToListAsync();
        }

        /// <summary>
        /// Getting the payment plan and installments based on Payment Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentPlan>> GetPaymentPlan(Guid id)
        {
            var paymentPlan = await _context.PaymentPlan.FindAsync(id);

            if (paymentPlan == null)
            {
                return NotFound();
            }

            return paymentPlan;
        }

        /// <summary>
        /// Updating the payment plan and corresponding installment details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentPlan"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentPlan(Guid id, PaymentPlan paymentPlan)
        {
            if (id != paymentPlan.PaymentID)
            {
                return BadRequest();
            }

            _context.Entry(paymentPlan).State = EntityState.Modified;

            try
            {
                DateTime date = DateTime.Now;

                foreach (Installment installment1 in _context.Installment)
                {
                    if (installment1.PaymentID == id)
                    {
                        installment1.DueDate = date;
                        date = date.AddDays(paymentPlan.Frequency);
                        installment1.DueAmount = paymentPlan.PurchaseAmount / paymentPlan.NoOfInstallments;
                        _context.Installment.Update(installment1);
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentPlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentPlans
        /// <summary>
        /// Posting the payment plan and Installment detailsbased on payment plan
        /// </summary>
        /// <param name="paymentPlan"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<ActionResult<PaymentPlan>> PostPaymentPlan(PaymentPlan paymentPlan)
        {
            if (ModelState.IsValid)
            {
                paymentPlan.PaymentID = Guid.NewGuid();
                var paymentPlanFactory = new PaymentPlanFactory();

                List<Installment> installments = paymentPlanFactory.CreatePaymentPlan(paymentPlan);

                foreach(Installment installment in installments)
                {
                    _context.Installment.Add(installment);
                }

                _context.PaymentPlan.Add(paymentPlan);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetPaymentPlan", new { id = paymentPlan.PaymentID }, paymentPlan);
        }

        /// <summary>
        /// Deleting the payment plan and associated installments based on provided payment id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeletePaymentPlan(Guid id)
        {
            var paymentPlan = await _context.PaymentPlan.FindAsync(id);
            if (paymentPlan == null)
            {
                return NotFound();
            }

            _context.PaymentPlan.Remove(paymentPlan);

            foreach(Installment installment1 in _context.Installment)
            {
                if (installment1.PaymentID == id)
                {
                    _context.Installment.Remove(installment1);
                }
            }
 
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Checking if Payment Plan exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool PaymentPlanExists(Guid id)
        {
            return _context.PaymentPlan.Any(e => e.PaymentID == id);
        }
    }
}
