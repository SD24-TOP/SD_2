using FirstProgram_Library;
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

namespace AppEquationSolver
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string start = Start_Textbox.Text;
            string end = End_Textbox.Text;
            Even even = new Even();
            string result = string.Join(",",even.EvenList(int.Parse(start), int.Parse(end)));
            Result_Textblock.Text = result;
        }
    }
}