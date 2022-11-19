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
        /// Getting the payment plan
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentPlan>>> GetPaymentPlan()
        {
            return await _context.PaymentPlan.ToListAsync();
        }

        /// <summary>
        /// Getting the payment plan based on Id
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
        /// Updating the payment plan
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentPlan"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentPlan(Guid id, PaymentPlan paymentPlan)
        {
            if (id != paymentPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentPlan).State = EntityState.Modified;

            try
            {
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
        /// Creating the payment plan
        /// </summary>
        /// <param name="paymentPlan"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<ActionResult<PaymentPlan>> PostPaymentPlan(PaymentPlan paymentPlan)
        {
            var paymentPlanFactory = new PaymentPlanFactory();

            //decimal installmentAmount = paymentPlan.PurchaseAmount / paymentPlan.Installment;

            //for (int i = 0; i < paymentPlan.Installment; i++)
            //{
            //    Installment installment = new Installment();
            //    installment.InstallmentId = paymentPlan.Id;
            //    installment.DueDate = DateTime.Now.AddDays(paymentPlan.Frequeny);
            //    installment.Amount = installmentAmount;
            //    paymentPlan.Installments.Add(installment);
            //}

            paymentPlan = paymentPlanFactory.CreatePaymentPlan(paymentPlan);

            _context.PaymentPlan.Add(paymentPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentPlan", new { id = paymentPlan.Id }, paymentPlan);
        }

        /// <summary>
        /// Deleting the payment plan based on id as input
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
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentPlanExists(Guid id)
        {
            return _context.PaymentPlan.Any(e => e.Id == id);
        }
    }
}
