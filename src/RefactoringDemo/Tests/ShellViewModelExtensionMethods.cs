using NUnit.Framework;
using RefactoringDemo.UI;

namespace RefactoringDemo.Tests
{
    public static class ShellViewModelExtensionMethods
    {
        public static void GrandTotalShouldEqual(this ShellViewModel viewModel, decimal expectedGrandTotal)
        {
            decimal actualGrandTotal = GetTotalAmountFromViewModel(viewModel);
            Assert.AreEqual(expectedGrandTotal, actualGrandTotal);
        }

        private static decimal GetTotalAmountFromViewModel(ShellViewModel viewModel)
        {
            if (string.IsNullOrWhiteSpace(viewModel.GrandTotal))
                return 0m;

            string grandTotalString = viewModel.GrandTotal.Substring(1);
            decimal grandTotalAmount;
            if (!decimal.TryParse(grandTotalString, out grandTotalAmount))
                return 0m;

            return grandTotalAmount;
        }
    }
}