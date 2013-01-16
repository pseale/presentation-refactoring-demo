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

        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}