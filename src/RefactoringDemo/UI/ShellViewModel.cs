using System.Windows;
using Caliburn.Micro;

namespace RefactoringDemo.UI
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            DisplayName = "Discount Calculator";
        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}