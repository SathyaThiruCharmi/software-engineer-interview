using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Xunit;

namespace Zip.InstallmentsService.Test
{
    [TestClass]
    public class PaymentPlanFactoryTests
    {
        [TestMethod]
        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();

            PaymentPlan Payment = new PaymentPlan();
            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan1(100,4,14);

            // Assert
            paymentPlan.ShouldNotBeNull();
        }
    }
}
