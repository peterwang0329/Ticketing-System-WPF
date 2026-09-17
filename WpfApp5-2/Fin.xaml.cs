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
using System.Windows.Shapes;
using static WpfApp5_2.MainWindow;

namespace WpfApp5_2
{
    /// <summary>
    /// Fin.xaml 的互動邏輯
    /// </summary>
    public partial class Fin : Window
    {
        public Fin(List<TicketData> TicketDataList)
        {
            InitializeComponent();
            if(Free_set)
                free.Visibility = Visibility.Hidden;
        }

        private void free_Click(object sender, RoutedEventArgs e)
        {
            Free_set = true;
            Free_ticket++;
            count = 0;
            MainWindow mainWindow = new MainWindow();
            MessageBox.Show("恭喜你獲得一張免費兌換卷!");
            mainWindow.Show();
            this.Close();
        }
    }
}
