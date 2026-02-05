using Ornytolog.Repository;
using Ornytolog.Service;
using Ornytolog.ViewModel;
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

namespace Ornytolog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel viewModel = new MainViewModel(
            new OrnytologyService(
                new LocalOrnytologyRepository()
                )
            );

        public MainWindow()
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}