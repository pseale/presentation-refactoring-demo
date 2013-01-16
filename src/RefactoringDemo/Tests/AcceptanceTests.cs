using System.Collections.Generic;
using NUnit.Framework;
using RefactoringDemo.UI;

namespace RefactoringDemo.Tests
{
    [TestFixture]
    public class AcceptanceTests
    {
        [Test]
        public void No_books__should_cost_nothing()
        {
            var vm = CreateViewModelWithBooks(new int[] {});

            vm.GrandTotalShouldEqual(0m);
        }

        [Test]
        public void One_book__should_give_no_discount()
        {
            var vm = CreateViewModelWithBooks(new[] {1});

            vm.GrandTotalShouldEqual(8m);
        }

        [Test]
        public void Two_same_books__should_give_no_discount()
        {
            var vm = CreateViewModelWithBooks(new[] {1, 1});

            vm.GrandTotalShouldEqual(8m + 8m);
        }

        [Test]
        public void Two_different_books__should_give_a_five_percent_discount()
        {
            var vm = CreateViewModelWithBooks(new[] { 1, 2 });

            vm.GrandTotalShouldEqual((8m + 8m) * 0.95m);
        }

        [Test]
        public void Three_same_books__should_give_no_discount()
        {
            var vm = CreateViewModelWithBooks(new[] { 1, 1, 1 });

            vm.GrandTotalShouldEqual(8m + 8m + 8m);
        }

        [Test]
        public void Three_different_books__should_give_a_ten_percent_discount()
        {
            var vm = CreateViewModelWithBooks(new[] { 1, 2, 3 });

            vm.GrandTotalShouldEqual((8m + 8m + 8m) * 0.9m);
        }

        [Test]
        public void Four_different_books__should_give_a_twenty_percent_discount()
        {
            var vm = CreateViewModelWithBooks(new[] { 1, 2, 3, 4 });

            vm.GrandTotalShouldEqual((8m + 8m + 8m + 8m) * 0.8m);
        }

        [Test]
        public void Five_different_books__should_give_a_twenty_five_percent_discount()
        {
            var vm = CreateViewModelWithBooks(new[] { 1, 2, 3, 4, 5 });

            vm.GrandTotalShouldEqual((8m + 8m + 8m + 8m + 8m) * 0.75m);
        }

        [Test]
        public void Two_same_books_and_one_other_book__should_discount_only_the_two_discounted_books()
        {
            var vm = CreateViewModelWithBooks(new[] { 1, 1, 2 });

            vm.GrandTotalShouldEqual((8m + 8m) * .95m + 8m);
        }

        //this is a special case and requires changing the way the cost calculator works.
        [Test, Ignore]
        public void Two_sets_of_four_different_books__should_give_twenty_percent_discount_to_all()
        {
            var vm = CreateViewModelWithBooks(new[] { 1, 2, 3, 4,       2, 3, 4, 5 });

            vm.GrandTotalShouldEqual((8m * 8) * 0.80m);
        }

        private static ShellViewModel CreateViewModelWithBooks(int[] books)
        {
            var vm = new ShellViewModel();
            foreach (var book in books)
            {
                if (book == 1)
                    vm.Book1Quantity++;
                if (book == 2)
                    vm.Book2Quantity++;
                if (book == 3)
                    vm.Book3Quantity++;
                if (book == 4)
                    vm.Book4Quantity++;
                if (book == 5)
                    vm.Book5Quantity++;
            }

            vm.Calculate();

            return vm;
        }

    }
}