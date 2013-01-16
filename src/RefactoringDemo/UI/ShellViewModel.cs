using System;
using System.Windows;
using Caliburn.Micro;

namespace RefactoringDemo.UI
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            DisplayName = "Discount Calculator";
            Book1Quantity = 0;
            Book2Quantity = 0;
            Book3Quantity = 0;
            Book4Quantity = 0;
            Book5Quantity = 0;
            UpdateRulesVisibility();
        }

        public void Calculate()
        {
            GrandTotal = "$" + new Random().Next(0, 5000).ToString("0.00");
        }
        private int _book1Quantity;
        public int Book1Quantity
        {
            get { return _book1Quantity; }
            set
            {
                if (value == _book1Quantity) return;
                _book1Quantity = value;
                NotifyOfPropertyChange(() => Book1Quantity);
            }
        }

        private int _book2Quantity;
        public int Book2Quantity
        {
            get { return _book2Quantity; }
            set
            {
                if (value == _book2Quantity) return;
                _book2Quantity = value;
                NotifyOfPropertyChange(() => Book2Quantity);
            }
        }


        private int _book3Quantity;
        public int Book3Quantity
        {
            get { return _book3Quantity; }
            set
            {
                if (value == _book3Quantity) return;
                _book3Quantity = value;
                NotifyOfPropertyChange(() => Book3Quantity);
            }
        }


        private int _book4Quantity;
        public int Book4Quantity
        {
            get { return _book4Quantity; }
            set
            {
                if (value == _book4Quantity) return;
                _book4Quantity = value;
                NotifyOfPropertyChange(() => Book4Quantity);
            }
        }


        private int _book5Quantity;
        public int Book5Quantity
        {
            get { return _book5Quantity; }
            set
            {
                if (value == _book5Quantity) return;
                _book5Quantity = value;
                NotifyOfPropertyChange(() => Book5Quantity);
            }
        }

        private string _grandTotal;
        public string GrandTotal
        {
            get { return _grandTotal; }
            set
            {
                if (value == _grandTotal) return;
                _grandTotal = value;
                NotifyOfPropertyChange(() => GrandTotal);
            }
        }

        private bool _isShowRulesChecked;
        public bool IsShowRulesChecked
        {
            get { return _isShowRulesChecked; }
            set
            {
                if (value.Equals(_isShowRulesChecked)) return;
                _isShowRulesChecked = value;
                UpdateRulesVisibility();
                NotifyOfPropertyChange(() => IsShowRulesChecked);
            }
        }

        private Visibility _rulesVisibility;
        public Visibility RulesVisibility
        {
            get { return _rulesVisibility; }
            set
            {
                if (value == _rulesVisibility) return;
                _rulesVisibility = value;
                NotifyOfPropertyChange(() => RulesVisibility);
            }
        }

        private Visibility _calculatorVisibility;
        public Visibility CalculatorVisibility
        {
            get { return _calculatorVisibility; }
            set
            {
                if (value == _calculatorVisibility) return;
                _calculatorVisibility = value;
                NotifyOfPropertyChange(() => CalculatorVisibility);
            }
        }

        private void UpdateRulesVisibility()
        {
            RulesVisibility = IsShowRulesChecked ? Visibility.Visible : Visibility.Collapsed;
            CalculatorVisibility = !IsShowRulesChecked ? Visibility.Visible : Visibility.Collapsed;
        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }

        public string RulesText
        {
            get
            {
                return @" Book discount calculator rules:
 
 1 book     - no discount
 2 book set - 5%
 3 book set - 10%
 4 book set - 20%
 5 book set - 25%
 
 Copies of the same book do NOT count toward a set. 
 
 Examples: 
 If you buy 5 copies of the same book, you get no discount.
 If you buy one copy of book #1, #2, and #3, you get a 10% discount on all books.
 If you buy two copies of book #1 and a copy of book #2, you get a 5% discount
   on the two books, and no discount on the third book.";
            }
        }

        public void ShowRules()
        {
            IsShowRulesChecked = true;
        }
    }
}