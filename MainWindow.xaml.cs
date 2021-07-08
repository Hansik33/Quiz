using System;
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

namespace Quiz
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void MsgInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Quiz" + "\n"
            + "By Adam Franz" + "\n"
            + "Wersja: 1.0" + "\n"
            + "Web page: www.hansik.pl", "Informacje", MessageBoxButton.OK, MessageBoxImage.Information);
            System.Diagnostics.Process.Start("https://www.hansik.pl");
        }
        void Geography(object sender, RoutedEventArgs e)
        {
            Quiz.Window1.title = "Geografia";
            Quiz.Window1.file_path_questions = @"questions/geography.q";
            Quiz.Window1.file_path_audio = @"audio/geography.wav";
            Quiz.Window1.number_questions = 33;
            Window1 window = new Window1();
            this.WindowState = WindowState.Minimized;
            window.ShowDialog();
        }

        void IIWW(object sender, RoutedEventArgs e)
        {
            Quiz.Window1.title = "II Wojna Światowa";
            Quiz.Window1.file_path_questions = @"questions/iiww.q";
            Quiz.Window1.file_path_audio = @"audio/iiww.wav";
            Quiz.Window1.number_questions = 33;
            Window1 window = new Window1();
            this.WindowState = WindowState.Minimized;
            window.ShowDialog();
        }
    }
}
