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

namespace WpfApp5_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Page1());
        }

        public static bool Fix_set { get; set; } = false;
        public static bool Free_set { get; set; } = false;
        public static int count { get; set; } = 0;
        public static int Select { get; set; } = -1;
        public static int Free_ticket { get; set; } = 0;

        public class TicketData
        {
            public string[] TicketSave { get; set; }
            public string[] TagSave { get; set; }
            public string[] ComboSave { get; set; }
            public string[] FoodSave { get; set; }
            public string MovieName { get; set; }
            public string MovieDate { get; set; }
            public string MovieTime { get; set; }
            public int MovieErr { get; set; }
            public string TicketName { get; set; }
            public string TicketCount { get; set; }
            public string Total { get; set; }   
            public bool _Free { get; set; }

            public TicketData()
            {
                TicketSave = new string[6];
                TagSave = new string[4];
                ComboSave = new string[4];
                FoodSave = new string[10];
                MovieName = ""; 
                MovieDate = ""; 
                MovieTime = "";
                MovieErr = 0;
                TicketName = "";
                TicketCount = "";
                Total = "";
                _Free = false;
            }
        }

        public static class DataStore
        {
            public static List<TicketData> TicketDataList { get; } = new List<TicketData>();
        }
    }
}