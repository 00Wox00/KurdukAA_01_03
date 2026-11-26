using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KurdukAA_01_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Кнопка: объект базового класса
        private void btnBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MobileOperator op = new MobileOperator();
                op.Input(tbName.Text, tbCost.Text, tbArea.Text);
                tbResult.Text = op.Show();
            }
            catch (FormatException)
            {
                tbResult.Text = "Ошибка: введите числа в правильном формате";
            }
            catch (ArgumentException ex)
            {
                tbResult.Text = "Ошибка: " + ex.Message;
            }
        }
        // Кнопка: объект класса-потомка
        private void btnChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MobileOperatorWithFee op = new MobileOperatorWithFee();
                op.Input(tbName.Text, tbCost.Text, tbArea.Text, cbFee.IsChecked == true);
                tbResult.Text = op.Show();
            }
            catch (FormatException)
            {
                tbResult.Text = "Ошибка: введите числа в правильном формате";
            }
            catch (ArgumentException ex)
            {
                tbResult.Text = "Ошибка: " + ex.Message;
            }
        }
    }
}