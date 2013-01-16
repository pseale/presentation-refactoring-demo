using System.Collections.Generic;
using System.Linq;

namespace RefactoringDemo.Core
{
    public static class DiscountCalculator
    {
        public static decimal Calculate(IEnumerable<int> books)
        {
            //if the book set is empty, return 0
            if (books == null || books.Count() == 0)
                return 0m;

            decimal runningTotal = 0m;
            var remainingBooks = new List<int>(books);
            //while we have books, add to the running total
            while (remainingBooks.Count > 0)
            {
                //create a grouped list of books by book title
                var groups = remainingBooks.GroupBy(bookId => bookId);

                //find the # of book titles we have
                var uniqueBooksCount = groups.Count();

                //calculate the discount for this group
                var percentDiscounted = GetDiscountForSetOfSize(uniqueBooksCount);

                //add to the running total
                runningTotal += uniqueBooksCount * 8m * (1m - percentDiscounted);

                //remove one book for each title
                foreach (var bookIdGroup in groups)
                {
                    int bookId = bookIdGroup.Key;
                    remainingBooks.Remove(bookId);
                }
            }

            //return the sum
            return runningTotal;
        }

        private static decimal GetDiscountForSetOfSize(int bookSetSize)
        {
            decimal percentDiscounted;
            switch (bookSetSize)
            {
                case 2:
                    percentDiscounted = 0.05m;
                    break;
                case 3:
                    percentDiscounted = 0.10m;
                    break;
                case 4:
                    percentDiscounted = 0.20m;
                    break;
                case 5:
                    percentDiscounted = 0.25m;
                    break;
                default:
                    percentDiscounted = 0m;
                    break;
            }

            return percentDiscounted;
        }
    }
}