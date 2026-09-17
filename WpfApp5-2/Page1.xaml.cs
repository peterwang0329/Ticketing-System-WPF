using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Threading;
using static WpfApp5_2.MainWindow;

namespace WpfApp5_2
{
    /// <summary>
    /// Page1.xaml 的互動邏輯
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        Dictionary<int, List<string>> date_dictionary = new Dictionary<int, List<string>>
            {
                { 1,new List<string>{"5:00", "9:20", "11:30", "8:05", "14:30", "18:45", "22:00" }},
                { 2,new List<string> { "6:30", "12:40", "18:45", "23:45" } },
                { 3,new List<string> { "3:00", "8:15", "10:30", "15:30", "19:45", "21:00" } },
                { 4,new List<string> { "6:00", "9:40", "11:05", "13:30", "15:45", "18:45", "22:05" } },
                { 5,new List<string> { "8:00", "10:20", "15:30", "17:05", "17:55", "20:45" } },
                { 6,new List<string> { "7:25", "10:20", "12:30", "14:30", "18:50", "22:05" } },
                { 7,new List<string> { "2:45", "5:20", "9:50", "14:05", "16:30", "20:00", "23:30" } },
                { 8,new List<string> { "8:20", "10:40", "16:05", "18:00", "21:20" } },
                { 9,new List<string> { "6:20", "8:20", "11:00", "15:45", "19:30", "20:45", "23:45" } },
                { 10,new List<string> { "11:30", "15:05", "18:45", "22:00" } },
                { 11,new List<string> { "1:30", "3:20", "11:30", "8:05", "14:30", "18:45", "22:00" } },
                { 12,new List<string> { "7:20", "9:20", "12:50", "16:30", "18:00", "21:30" } },
                { 13,new List<string> { "9:35", "12:00", "13:55", "17:25", "20:20", "22:50" } },
                { 14,new List<string> { "8:20", "10:30", "13:55", "16:40", "18:50", "20:15", "21:20", "23:40"} }
            };

        List<string> list = new List<string>
        {
            "ATRI",
            "Hello World",
            "僕愛君愛：致我深愛的每個妳",
            "僕愛君愛：致深愛妳的那個我",
            "NO GAME NO LIFE 遊戲人生 ZERO",
            "白聖女與黑牧師",
            "老夫老妻重返青春",
            "你的名字",
            "天氣之子",
            "鈴芽之旅",
            "航海王劇場版：紅髮歌姬",
            "劇場版咒術迴戰0",
            "聲之形",
            "Unnamed Memory"
        };

        public int[] date_random = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};
        private string date, movie;
        bool movie_picture = false, Date_set = false, mouth_check = false,year_check = false;
        private int tick = 0, runner = 1;
        private DispatcherTimer dispatcherTimer;
        int now_month = DateTime.Now.Month, now_day = DateTime.Now.Day;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Left = (SystemParameters.PrimaryScreenWidth / 2) - (window.Width / 2);
            window.Top = (SystemParameters.PrimaryScreenHeight / 2) - (window.Height / 2);

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(0.1);
            dispatcherTimer.Start();

            Movie.SelectedIndex = -1;
            Date.SelectedIndex = -1;
            Time.SelectedIndex = -1;
            menu_show.Source = null;
            movie_picture = false;
            Movie.ItemsSource = list;
            int seed = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day, temp;
            for (int k = 0; k < DateTime.Now.Day + DateTime.Now.Month; k++)
                for (int i = 0; i < 14; i++)
                {
                    int j = (i + k + seed) % 14;
                    temp = date_random[i];
                    date_random[i] = date_random[j];
                    date_random[j] = temp;
                }
        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            tick++;
            if (tick >= 50)
            {
                runner++;
                tick = 0;
            }
            if (runner >= 4)
                runner = 1;
            string appStartupPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            Uri slideshow = new Uri(appStartupPath + @"\Image\" + "跑馬燈" + runner + ".jpg", UriKind.Absolute);
            BitmapImage bitmapImage = new BitmapImage(slideshow);
            image1.Source = bitmapImage;
            if (Movie.SelectedIndex != -1 && !Date_set)
            {
                if (now_month % 2 == 1 && now_month <= 7)
                    mouth_check = true;
                else if (now_month % 2 == 0 && now_month >= 8)
                    mouth_check = true;

                for (int i = 0; i < 7; i++)
                {
                    now_day++;
                    if (now_day > 29 && now_month == 2 && DateTime.Now.Year % 4 == 0)
                        date = DateTime.Now.Year.ToString() + "/" + (now_month + 1).ToString() + "/" + (now_day - 29).ToString();
                    else if (now_day > 28 && now_month == 2 && DateTime.Now.Year % 4 != 0)
                        date = DateTime.Now.Year.ToString() + "/" + (now_month + 1).ToString() + "/" + (now_day - 28).ToString();
                    else if(now_day > 31 && mouth_check && now_month == 12)
                        date = (DateTime.Now.Year + 1).ToString() + "/" + "1/" + (now_day - 31).ToString();
                    else if (now_day > 31 && mouth_check)
                        date = DateTime.Now.Year.ToString() + "/" + (now_month + 1).ToString() + "/" + (now_day - 31).ToString();
                    else if (now_day > 30 && !mouth_check)
                        date = DateTime.Now.Year.ToString() + "/" + (now_month + 1).ToString() + "/" + (now_day - 30).ToString();
                    else
                        date = DateTime.Now.Year.ToString() + "/" + now_month.ToString() + "/" + now_day.ToString();
                    Date.Items.Add(date);
                }
                Date_set = true;
            }
            if (movie_picture)
            {
                movie = Movie.Text;
                appStartupPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                slideshow = new Uri(appStartupPath + @"\Image\" + Movie.Text + ".jpg", UriKind.Absolute);
                bitmapImage = new BitmapImage(slideshow);
                menu_show.Source = bitmapImage;
                if (Movie.SelectedIndex != -1 && Date.SelectedIndex != -1)
                    Time.ItemsSource = date_dictionary[date_random[Movie.SelectedIndex]];
            }
        }

        private void Textblock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            if (label == left)
                runner++;
            else if (label == right)
                runner--;
            if (runner >= 4)
                runner = 1;
            if (runner <= 0)
                runner = 3;
        }

        private void Movie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == Movie && Movie.SelectedIndex != -1)
                movie_picture = true;
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            if (label == left)
                label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
            else if (label == right)
                label.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            if (label == left)
                label.Background = new SolidColorBrush(Color.FromArgb(5, 255, 255, 255));
            else if (label == right)
                label.Background = new SolidColorBrush(Color.FromArgb(5, 255, 255, 255));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Menu menu;
            Window window = Window.GetWindow(this);
            Page2 page2;
            Page1 page1 = this;
            if (button == get && Time.SelectedIndex != -1)
            {
                DataStore.TicketDataList.Add(new TicketData());
                DataStore.TicketDataList[count].MovieName = movie;
                DataStore.TicketDataList[count].MovieDate = Date.SelectedValue.ToString();
                DataStore.TicketDataList[count].MovieTime = Time.SelectedValue.ToString();
                DataStore.TicketDataList[count].TicketName = movie +" "+ Date.SelectedValue.ToString() +" "+ Time.SelectedValue.ToString() +" ";
                page2 = new Page2(page1,movie, Date.SelectedValue.ToString(), Time.SelectedValue.ToString(),Date.SelectedIndex + 1);
                window.Height = 765;
                window.Width = 1100;
                dispatcherTimer.Stop();
                NavigationService.Navigate(page2);
            }
            if (button == check)
            {
                menu = new Menu(DataStore.TicketDataList);
                dispatcherTimer.Stop();
                menu.Show();
                window.Close();
            }
        }
    }
}
