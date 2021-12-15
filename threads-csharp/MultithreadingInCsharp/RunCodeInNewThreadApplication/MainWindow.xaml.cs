using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RunCodeInNewThreadApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int checkButtonClicksCount;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RunOnMainThreadButton_Click(object sender, RoutedEventArgs e)
        {
            this.SingleThreadResultTextBlock.Text = "Started working...";
            var result = new PdfValidator().ValidateFile();
            this.SingleThreadResultTextBlock.Text = $"Validation result: {result.ResultCode}";
        }

        private async void RunOnSeparateThreadButton_Click(object sender, RoutedEventArgs e)
        {
            this.MultiThreadResultTextBlock.Text = "Started working...";
            var result = await Task.Run(() => new PdfValidator().ValidateFile());
            this.MultiThreadResultTextBlock.Text = $"Validation result: {result.ResultCode}";
        }

        private void CheckUIResponsiveButton_Click(object sender, RoutedEventArgs e)
        {
            checkButtonClicksCount++;
            this.UiCheckResultTextBlock.Text = $"You've checked {checkButtonClicksCount} times already";
        }
    }
}
