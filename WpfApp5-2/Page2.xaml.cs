using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static WpfApp5_2.MainWindow;

namespace WpfApp5_2
{
    /// <summary>
    /// Page2.xaml 的互動邏輯
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2(Page1 page1, string movie, string date, string time, int date_err)
        {
            InitializeComponent();
            _page1 = page1;
            Movie.Content += movie;
            Date.Content += date;
            Time.Content += time;
            movie_name = movie;
            if (Fix_set)
            {
                DataStore.TicketDataList[Select].MovieErr = date_err;
                fix();
            }
            else
                DataStore.TicketDataList[count].MovieErr = date_err;
            if (date_err > 5)
            {
                if (!Fix_set)
                    plus_ticket5.IsEnabled = true;
                early = true;
            }
            if (Free_set && Free_ticket > 0)
                plus_ticket_free.IsEnabled = true;
        }

        private void fix()
        {
            ticket_number1.Content = DataStore.TicketDataList[Select].TicketSave[0];
            if (ticket_number1.Content.ToString() != "0")
                minus_ticket1.IsEnabled = true;
            ticket_number2.Content = DataStore.TicketDataList[Select].TicketSave[1];
            if (ticket_number2.Content.ToString() != "0")
                minus_ticket2.IsEnabled = true;
            ticket_number3.Content = DataStore.TicketDataList[Select].TicketSave[2];
            if (ticket_number3.Content.ToString() != "0")
                minus_ticket3.IsEnabled = true;
            ticket_number4.Content = DataStore.TicketDataList[Select].TicketSave[3];
            if (ticket_number4.Content.ToString() != "0")
                minus_ticket4.IsEnabled = true;
            ticket_number5.Content = DataStore.TicketDataList[Select].TicketSave[4];
            if (ticket_number5.Content.ToString() != "0")
                minus_ticket5.IsEnabled = true;
            ticket_free.Content = DataStore.TicketDataList[Select].TicketSave[5];
            if (ticket_free.Content.ToString() != "0")
                minus_ticket_free.IsEnabled = true;

            tag_number1.Content = DataStore.TicketDataList[Select].TagSave[0];
            if (tag_number1.Content.ToString() != "0")
                minus_tag1.IsEnabled = true;
            tag_number2.Content = DataStore.TicketDataList[Select].TagSave[1];
            if (tag_number2.Content.ToString() != "0")
                minus_tag2.IsEnabled = true;
            tag_number3.Content = DataStore.TicketDataList[Select].TagSave[2];
            if (tag_number3.Content.ToString() != "0")
                minus_tag3.IsEnabled = true;
            tag_number4.Content = DataStore.TicketDataList[Select].TagSave[3];
            if (tag_number4.Content.ToString() != "0")
                minus_tag4.IsEnabled = true;

            combo_number1.Content = DataStore.TicketDataList[Select].ComboSave[0];
            if (combo_number1.Content.ToString() != "0")
                minus_combo1.IsEnabled = true;
            combo_number2.Content = DataStore.TicketDataList[Select].ComboSave[1];
            if (combo_number2.Content.ToString() != "0")
                minus_combo2.IsEnabled = true;
            combo_number3.Content = DataStore.TicketDataList[Select].ComboSave[2];
            if (combo_number3.Content.ToString() != "0")
                minus_combo3.IsEnabled = true;
            combo_number4.Content = DataStore.TicketDataList[Select].ComboSave[3];
            if (combo_number4.Content.ToString() != "0")
                minus_combo4.IsEnabled = true;

            food_number1.Content = DataStore.TicketDataList[Select].FoodSave[0];
            if (food_number1.Content.ToString() != "0")
                minus_food1.IsEnabled = true;
            if (food_number1.Content.ToString() == "10")
                plus_food1.IsEnabled = false;
            food_number2.Content = DataStore.TicketDataList[Select].FoodSave[1];
            if (food_number2.Content.ToString() != "0")
                minus_food2.IsEnabled = true;
            if (food_number2.Content.ToString() == "10")
                plus_food2.IsEnabled = false;
            food_number3.Content = DataStore.TicketDataList[Select].FoodSave[2];
            if (food_number3.Content.ToString() != "0")
                minus_food3.IsEnabled = true;
            if (food_number3.Content.ToString() == "10")
                plus_food3.IsEnabled = false;
            food_number4.Content = DataStore.TicketDataList[Select].FoodSave[3];
            if (food_number4.Content.ToString() != "0")
                minus_food4.IsEnabled = true;
            if (food_number4.Content.ToString() == "10")
                plus_food4.IsEnabled = false;
            food_number5.Content = DataStore.TicketDataList[Select].FoodSave[4];
            if (food_number5.Content.ToString() != "0")
                minus_food5.IsEnabled = true;
            if (food_number5.Content.ToString() == "10")
                plus_food5.IsEnabled = false;
            food_number6.Content = DataStore.TicketDataList[Select].FoodSave[5];
            if (food_number6.Content.ToString() != "0")
                minus_food6.IsEnabled = true;
            if (food_number6.Content.ToString() == "10")
                plus_food6.IsEnabled = false;
            food_number7.Content = DataStore.TicketDataList[Select].FoodSave[6];
            if (food_number7.Content.ToString() != "0")
                minus_food7.IsEnabled = true;
            if (food_number7.Content.ToString() == "10")
                plus_food7.IsEnabled = false;
            food_number8.Content = DataStore.TicketDataList[Select].FoodSave[7];
            if (food_number8.Content.ToString() != "0")
                minus_food8.IsEnabled = true;
            if (food_number8.Content.ToString() == "10")
                plus_food8.IsEnabled = false;
            food_number9.Content = DataStore.TicketDataList[Select].FoodSave[8];
            if (food_number9.Content.ToString() != "0")
                minus_food9.IsEnabled = true;
            if (food_number9.Content.ToString() == "10")
                plus_food9.IsEnabled = false;
            food_number10.Content = DataStore.TicketDataList[Select].FoodSave[9];
            if (food_number10.Content.ToString() != "0")
                minus_food10.IsEnabled = true;
            if (food_number10.Content.ToString() == "10")
                plus_food10.IsEnabled = false;
            ticket.Content = DataStore.TicketDataList[Select].TicketCount;
            if (food_number10.Content.ToString() != "0")
                minus.IsEnabled = true;
            if (food_number10.Content.ToString() == "10")
                plus.IsEnabled = false;
            Total.Content = DataStore.TicketDataList[Select].Total;
            total = int.Parse(Total.Content.ToString());
            ticket_total = int.Parse(ticket.Content.ToString());
            tag_total = int.Parse(ticket.Content.ToString());
            combo_total = int.Parse(combo_number1.Content.ToString()) + int.Parse(combo_number2.Content.ToString()) + int.Parse(combo_number3.Content.ToString()) + int.Parse(combo_number4.Content.ToString());
            if (ticket_total == combo_total)
            {
                plus_combo1.IsEnabled = false;
                plus_combo2.IsEnabled = false;
                plus_combo3.IsEnabled = false;
                plus_combo4.IsEnabled = false;
            }
            plus_ticket1.IsEnabled = false;
            plus_ticket2.IsEnabled = false;
            plus_ticket3.IsEnabled = false;
            plus_ticket4.IsEnabled = false;
            plus_ticket5.IsEnabled = false;
            plus_ticket_free.IsEnabled = false;
            plus_tag1.IsEnabled = false;
            plus_tag2.IsEnabled = false;
            plus_tag3.IsEnabled = false;
            plus_tag4.IsEnabled = false;
        }

        private int ticket_number = 1, ticket_total = 0, tag_total = 0, combo_total = 0
            , total = 0, food_price = 0, set;
        private string movie_name;
        private bool free = false, early = false;
        Page1 _page1;
        DispatcherTimer holdTimer = new DispatcherTimer();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Left = (SystemParameters.PrimaryScreenWidth / 2) - (window.Width / 2);
            window.Top = (SystemParameters.PrimaryScreenHeight / 2) - (window.Height / 2) - 20;

            string appStartupPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            Uri uri = new Uri(appStartupPath + @"/Image/" + movie_name + ".jpg", UriKind.Absolute);
            BitmapImage bitmapImage = new BitmapImage(uri);
            image.Source = bitmapImage;
        }

        private void Ticket_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Regex regex = new Regex(@"\d+");    // 定義一個正則表達式来匹配數字
            int price = 0;
            if (button.Content.ToString() == "+")
            {
                if (button == plus_ticket1)
                {
                    price = ExtractPrice(ticket1, regex);
                    ticket_number1.Content = int.Parse(ticket_number1.Content.ToString()) + 1;
                    minus_ticket1.IsEnabled = true;
                }
                else if (button == plus_ticket2)
                {
                    price = ExtractPrice(ticket2, regex);
                    ticket_number2.Content = int.Parse(ticket_number2.Content.ToString()) + 1;
                    minus_ticket2.IsEnabled = true;
                }
                else if (button == plus_ticket3)
                {
                    price = ExtractPrice(ticket3, regex);
                    ticket_number3.Content = int.Parse(ticket_number3.Content.ToString()) + 1;
                    minus_ticket3.IsEnabled = true;
                }
                else if (button == plus_ticket4)
                {
                    price = ExtractPrice(ticket4, regex);
                    ticket_number4.Content = int.Parse(ticket_number4.Content.ToString()) + 1;
                    minus_ticket4.IsEnabled = true;
                }
                else if (button == plus_ticket5)
                {
                    price = ExtractPrice(ticket5, regex);
                    ticket_number5.Content = int.Parse(ticket_number5.Content.ToString()) + 1;
                    minus_ticket5.IsEnabled = true;
                }
                else if (button == plus_ticket_free)
                {
                    ticket_free.Content = int.Parse(ticket_free.Content.ToString()) + 1;
                    minus_ticket_free.IsEnabled = true;
                    Free_ticket--;
                }
                total += price;
                ticket_total++;
            }
            else if (button.Content.ToString() == "-")
            {
                if (button == minus_ticket1)
                {
                    price = ExtractPrice(ticket1, regex);
                    ticket_number1.Content = int.Parse(ticket_number1.Content.ToString()) - 1;
                    if (ticket_number1.Content.ToString() == "0")
                        minus_ticket1.IsEnabled = false;
                    plus_ticket1.IsEnabled = true;
                }
                else if (button == minus_ticket2)
                {
                    price = ExtractPrice(ticket2, regex);
                    ticket_number2.Content = int.Parse(ticket_number2.Content.ToString()) - 1;
                    if (ticket_number2.Content.ToString() == "0")
                        minus_ticket2.IsEnabled = false;
                    plus_ticket2.IsEnabled = true;
                }
                else if (button == minus_ticket3)
                {
                    price = ExtractPrice(ticket3, regex);
                    ticket_number3.Content = int.Parse(ticket_number3.Content.ToString()) - 1;
                    if (ticket_number3.Content.ToString() == "0")
                        minus_ticket3.IsEnabled = false;
                    plus_ticket3.IsEnabled = true;
                }
                else if (button == minus_ticket4)
                {
                    price = ExtractPrice(ticket4, regex);
                    ticket_number4.Content = int.Parse(ticket_number4.Content.ToString()) - 1;
                    if (ticket_number4.Content.ToString() == "0")
                        minus_ticket4.IsEnabled = false;
                    plus_ticket4.IsEnabled = true;
                }
                else if (button == minus_ticket5)
                {
                    price = ExtractPrice(ticket5, regex);
                    ticket_number5.Content = int.Parse(ticket_number5.Content.ToString()) - 1;
                    if (ticket_number5.Content.ToString() == "0")
                        minus_ticket5.IsEnabled = false;
                    plus_ticket5.IsEnabled = true;
                }
                else if (button == minus_ticket_free)
                {
                    ticket_free.Content = int.Parse(ticket_free.Content.ToString()) - 1;
                    if (ticket_free.Content.ToString() == "0")
                        minus_ticket_free.IsEnabled = false;
                    plus_ticket_free.IsEnabled = true;
                    Free_ticket++;
                }
                total -= price;
                ticket_total--;
            }
            if (ticket_total >= int.Parse(ticket.Content.ToString()))
            {
                plus_ticket1.IsEnabled = false;
                plus_ticket2.IsEnabled = false;
                plus_ticket3.IsEnabled = false;
                plus_ticket4.IsEnabled = false;
                plus_ticket5.IsEnabled = false;
                plus_ticket_free.IsEnabled = false;
            }
            else
            {
                plus_ticket1.IsEnabled = true;
                plus_ticket2.IsEnabled = true;
                plus_ticket3.IsEnabled = true;
                plus_ticket4.IsEnabled = true;
                if (early)
                    plus_ticket5.IsEnabled = true;
                if(Free_set && Free_ticket > 0)
                    plus_ticket_free.IsEnabled = true;
            }
            if (Free_ticket <= 0)
                plus_ticket_free.IsEnabled = false;
            Total.Content = total.ToString();
        }

        private void Tag_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int price = 0;
            if (button.Content.ToString() == "+")
            {
                if (button == plus_tag1)
                {
                    tag_number1.Content = int.Parse(tag_number1.Content.ToString()) + 1;
                    minus_tag1.IsEnabled = true;
                }
                else if (button == plus_tag2)
                {
                    price = ExtractPrice2(tag2);
                    tag_number2.Content = int.Parse(tag_number2.Content.ToString()) + 1;
                    minus_tag2.IsEnabled = true;
                }
                else if (button == plus_tag3)
                {
                    price = ExtractPrice2(tag3);
                    tag_number3.Content = int.Parse(tag_number3.Content.ToString()) + 1;
                    minus_tag3.IsEnabled = true;
                }
                else if (button == plus_tag4)
                {
                    price = ExtractPrice2(tag4);
                    tag_number4.Content = int.Parse(tag_number4.Content.ToString()) + 1;
                    minus_tag4.IsEnabled = true;
                }
                total += price;
                tag_total++;
            }
            else if (button.Content.ToString() == "-")
            {
                if (button == minus_tag1)
                {
                    tag_number1.Content = int.Parse(tag_number1.Content.ToString()) - 1;
                    if (tag_number1.Content.ToString() == "0")
                        minus_tag1.IsEnabled = false;
                    plus_tag1.IsEnabled = true;
                }
                else if (button == minus_tag2)
                {
                    price = ExtractPrice2(tag2);
                    tag_number2.Content = int.Parse(tag_number2.Content.ToString()) - 1;
                    if (tag_number2.Content.ToString() == "0")
                        minus_tag2.IsEnabled = false;
                    plus_tag2.IsEnabled = true;
                }
                else if (button == minus_tag3)
                {
                    price = ExtractPrice2(tag3);
                    tag_number3.Content = int.Parse(tag_number3.Content.ToString()) - 1;
                    if (tag_number3.Content.ToString() == "0")
                        minus_tag3.IsEnabled = false;
                    plus_tag3.IsEnabled = true;
                }
                else if (button == minus_tag4)
                {
                    price = ExtractPrice2(tag4);
                    tag_number4.Content = int.Parse(tag_number4.Content.ToString()) - 1;
                    if (tag_number4.Content.ToString() == "0")
                        minus_tag4.IsEnabled = false;
                    plus_tag4.IsEnabled = true;
                }
                total -= price;
                tag_total--;
            }
            if (tag_total >= int.Parse(ticket.Content.ToString()))
            {
                plus_tag1.IsEnabled = false;
                plus_tag2.IsEnabled = false;
                plus_tag3.IsEnabled = false;
                plus_tag4.IsEnabled = false;
            }
            else
            {
                plus_tag1.IsEnabled = true;
                plus_tag2.IsEnabled = true;
                plus_tag3.IsEnabled = true;
                plus_tag4.IsEnabled = true;
            }
            Total.Content = total.ToString();
        }

        private void Combo_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Regex regex = new Regex(@"\d+");
            int price = 0;
            if (button.Content.ToString() == "+")
            {
                if (button == plus_combo1)
                {
                    price = ExtractPrice(combo1, regex);
                    combo_number1.Content = int.Parse(combo_number1.Content.ToString()) + 1;
                    minus_combo1.IsEnabled = true;
                }
                else if (button == plus_combo2)
                {
                    price = ExtractPrice(combo2, regex);
                    combo_number2.Content = int.Parse(combo_number2.Content.ToString()) + 1;
                    minus_combo2.IsEnabled = true;
                }
                else if (button == plus_combo3)
                {
                    price = ExtractPrice(combo3, regex);
                    combo_number3.Content = int.Parse(combo_number3.Content.ToString()) + 1;
                    minus_combo3.IsEnabled = true;
                }
                else if (button == plus_combo4)
                {
                    price = ExtractPrice(combo4, regex);
                    combo_number4.Content = int.Parse(combo_number4.Content.ToString()) + 1;
                    minus_combo4.IsEnabled = true;
                }
                total += price;
                combo_total++;
            }
            else if (button.Content.ToString() == "-")
            {
                if (button == minus_combo1)
                {
                    price = ExtractPrice(combo1, regex);
                    combo_number1.Content = int.Parse(combo_number1.Content.ToString()) - 1;
                    if (combo_number1.Content.ToString() == "0")
                        minus_combo1.IsEnabled = false;
                    plus_combo1.IsEnabled = true;
                }
                else if (button == minus_combo2)
                {
                    price = ExtractPrice(combo2, regex);
                    combo_number2.Content = int.Parse(combo_number2.Content.ToString()) - 1;
                    if (combo_number2.Content.ToString() == "0")
                        minus_combo2.IsEnabled = false;
                    plus_combo2.IsEnabled = true;
                }
                else if (button == minus_combo3)
                {
                    price = ExtractPrice(combo3, regex);
                    combo_number3.Content = int.Parse(combo_number3.Content.ToString()) - 1;
                    if (combo_number3.Content.ToString() == "0")
                        minus_combo3.IsEnabled = false;
                    plus_combo3.IsEnabled = true;
                }
                else if (button == minus_combo4)
                {
                    price = ExtractPrice(combo4, regex);
                    combo_number4.Content = int.Parse(combo_number4.Content.ToString()) - 1;
                    if (combo_number4.Content.ToString() == "0")
                        minus_combo4.IsEnabled = false;
                    plus_combo4.IsEnabled = true;
                }
                total -= price;
                combo_total--;
            }
            if (combo_total >= int.Parse(ticket.Content.ToString()))
            {
                plus_combo1.IsEnabled = false;
                plus_combo2.IsEnabled = false;
                plus_combo3.IsEnabled = false;
                plus_combo4.IsEnabled = false;
            }
            else
            {
                plus_combo1.IsEnabled = true;
                plus_combo2.IsEnabled = true;
                plus_combo3.IsEnabled = true;
                plus_combo4.IsEnabled = true;
            }
            Total.Content = total.ToString();
        }

        private void Food_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Regex regex = new Regex(@"\d+");    // 定義一個正則表達式来匹配數字
            int price = 0;
            if (button.Content.ToString() == "+")
            {
                if (button == plus_food1)
                {
                    price = ExtractPrice(food1, regex);
                    food_number1.Content = int.Parse(food_number1.Content.ToString()) + 1;
                    if (food_number1.Content.ToString() == "10")
                        plus_food1.IsEnabled = false;
                    minus_food1.IsEnabled = true;
                }
                else if (button == plus_food2)
                {
                    price = ExtractPrice(food2, regex);
                    food_number2.Content = int.Parse(food_number2.Content.ToString()) + 1;
                    if (food_number2.Content.ToString() == "10")
                        plus_food2.IsEnabled = false;
                    minus_food2.IsEnabled = true;
                }
                else if (button == plus_food3)
                {
                    price = ExtractPrice(food3, regex);
                    food_number3.Content = int.Parse(food_number3.Content.ToString()) + 1;
                    if (food_number3.Content.ToString() == "10")
                        plus_food3.IsEnabled = false;
                    minus_food3.IsEnabled = true;
                }
                else if (button == plus_food4)
                {
                    price = ExtractPrice(food4, regex);
                    food_number4.Content = int.Parse(food_number4.Content.ToString()) + 1;
                    if (food_number4.Content.ToString() == "10")
                        plus_food4.IsEnabled = false;
                    minus_food4.IsEnabled = true;
                }
                else if (button == plus_food5)
                {
                    price = ExtractPrice(food5, regex);
                    food_number5.Content = int.Parse(food_number5.Content.ToString()) + 1;
                    if (food_number5.Content.ToString() == "10")
                        plus_food5.IsEnabled = false;
                    minus_food5.IsEnabled = true;
                }
                else if (button == plus_food6)
                {
                    price = ExtractPrice(food6, regex);
                    food_number6.Content = int.Parse(food_number6.Content.ToString()) + 1;
                    if (food_number6.Content.ToString() == "10")
                        plus_food6.IsEnabled = false;
                    minus_food6.IsEnabled = true;
                }
                else if (button == plus_food7)
                {
                    price = ExtractPrice(food7, regex);
                    food_number7.Content = int.Parse(food_number7.Content.ToString()) + 1;
                    if (food_number7.Content.ToString() == "10")
                        plus_food7.IsEnabled = false;
                    minus_food7.IsEnabled = true;
                }
                else if (button == plus_food8)
                {
                    price = ExtractPrice(food8, regex);
                    food_number8.Content = int.Parse(food_number8.Content.ToString()) + 1;
                    if (food_number8.Content.ToString() == "10")
                        plus_food8.IsEnabled = false;
                    minus_food8.IsEnabled = true;
                }
                else if (button == plus_food9)
                {
                    price = ExtractPrice(food9, regex);
                    food_number9.Content = int.Parse(food_number9.Content.ToString()) + 1;
                    if (food_number9.Content.ToString() == "10")
                        plus_food9.IsEnabled = false;
                    minus_food9.IsEnabled = true;
                }
                else if (button == plus_food10)
                {
                    price = ExtractPrice(food10, regex);
                    food_number10.Content = int.Parse(food_number10.Content.ToString()) + 1;
                    if (food_number10.Content.ToString() == "10")
                        plus_food10.IsEnabled = false;
                    minus_food10.IsEnabled = true;
                }
                food_price += price;
                total += price;
            }
            else if (button.Content.ToString() == "-")
            {
                if (button == minus_food1)
                {
                    price = ExtractPrice(food1, regex);
                    food_number1.Content = int.Parse(food_number1.Content.ToString()) - 1;
                    if (food_number1.Content.ToString() == "0")
                        minus_food1.IsEnabled = false;
                    plus_food1.IsEnabled = true;
                }
                else if (button == minus_food2)
                {
                    price = ExtractPrice(food2, regex);
                    food_number2.Content = int.Parse(food_number2.Content.ToString()) - 1;
                    if (food_number2.Content.ToString() == "0")
                        minus_food2.IsEnabled = false;
                    plus_food2.IsEnabled = true;
                }
                else if (button == minus_food3)
                {
                    price = ExtractPrice(food3, regex);
                    food_number3.Content = int.Parse(food_number3.Content.ToString()) - 1;
                    if (food_number3.Content.ToString() == "0")
                        minus_food3.IsEnabled = false;
                    plus_food3.IsEnabled = true;
                }
                else if (button == minus_food4)
                {
                    price = ExtractPrice(food4, regex);
                    food_number4.Content = int.Parse(food_number4.Content.ToString()) - 1;
                    if (food_number4.Content.ToString() == "0")
                        minus_food4.IsEnabled = false;
                    plus_food4.IsEnabled = true;
                }
                else if (button == minus_food5)
                {
                    price = ExtractPrice(food5, regex);
                    food_number5.Content = int.Parse(food_number5.Content.ToString()) - 1;
                    if (food_number5.Content.ToString() == "0")
                        minus_food5.IsEnabled = false;
                    plus_food5.IsEnabled = true;
                }
                else if (button == minus_food6)
                {
                    price = ExtractPrice(food6, regex);
                    food_number6.Content = int.Parse(food_number6.Content.ToString()) - 1;
                    if (food_number6.Content.ToString() == "0")
                        minus_food6.IsEnabled = false;
                    plus_food6.IsEnabled = true;
                }
                else if (button == minus_food7)
                {
                    price = ExtractPrice(food7, regex);
                    food_number7.Content = int.Parse(food_number7.Content.ToString()) - 1;
                    if (food_number7.Content.ToString() == "0")
                        minus_food7.IsEnabled = false;
                    plus_food7.IsEnabled = true;
                }
                else if (button == minus_food8)
                {
                    price = ExtractPrice(food8, regex);
                    food_number8.Content = int.Parse(food_number8.Content.ToString()) - 1;
                    if (food_number8.Content.ToString() == "0")
                        minus_food8.IsEnabled = false;
                    plus_food8.IsEnabled = true;
                }
                else if (button == minus_food9)
                {
                    price = ExtractPrice(food9, regex);
                    food_number9.Content = int.Parse(food_number9.Content.ToString()) - 1;
                    if (food_number9.Content.ToString() == "0")
                        minus_food9.IsEnabled = false;
                    plus_food9.IsEnabled = true;
                }
                else if (button == minus_food10)
                {
                    price = ExtractPrice(food10, regex);
                    food_number10.Content = int.Parse(food_number10.Content.ToString()) - 1;
                    if (food_number10.Content.ToString() == "0")
                        minus_food10.IsEnabled = false;
                    plus_food10.IsEnabled = true;
                }
                food_price -= price;
                total -= price;
            }
            Total.Content = total.ToString();
        }

        private int ExtractPrice(Label label, Regex regex)
        {
            Match match = regex.Match(label.Content.ToString());
            if (match.Success)
                return int.Parse(match.Value);
            return 0;
        }

        private int ExtractPrice2(Label label)
        {
            int price = int.Parse(label.Content.ToString().Substring(label.Content.ToString().IndexOf("+") + 1, label.Content.ToString().IndexOf("元") - label.Content.ToString().IndexOf("+") - 1));
            if (price >= 0)
                return price;
            return 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Menu menu;
            Window window = Window.GetWindow(this);
            Page1 page1;
            if (button == minus)
            {
                ticket_number--;
                ticket.Content = ticket_number.ToString();
                plus.IsEnabled = true;
                if (int.Parse(ticket.Content.ToString()) <= 1)
                    minus.IsEnabled = false;
                min_reset();
            }
            else if (button == plus)
            {
                ticket_number++;
                ticket.Content = ticket_number.ToString();
                minus.IsEnabled = true;
                if (int.Parse(ticket.Content.ToString()) >= 10)
                    plus.IsEnabled = false;
                max_reset();
            }
            else if (button == back)
            {
                window.Height = 650;
                window.Width = 700;
                if(Free_set && Free_ticket <= 0 && ticket_free.Content.ToString() != "0")
                    Free_ticket++;
                NavigationService.Navigate(_page1);
            }
            else if (button == check)
            {
                if (Fix_set)
                    Fix_set = false; 
                if (Free_set && Free_ticket <= 0 && ticket_free.Content.ToString() != "0")
                    Free_ticket++;
                menu = new Menu(DataStore.TicketDataList);
                menu.Show();
                window.Close();
            }
            else if (button == add)
            {
                if (ticket_total != int.Parse(ticket.Content.ToString()) || tag_total != int.Parse(ticket.Content.ToString()))
                {
                    Error1.Height = 28;
                    Error1.Content = "◆您還有 " + (int.Parse(ticket.Content.ToString())- ticket_total)+" 張票種 和 " + (int.Parse(ticket.Content.ToString()) - tag_total) + " 個電影類型 未做選擇◆";
                }
                else
                {
                    save();
                    if (Fix_set)
                    {
                        DataStore.TicketDataList[Select].Total = Total.Content.ToString();
                        DataStore.TicketDataList[Select].TicketName ="$" + DataStore.TicketDataList[Select].Total + " " + DataStore.TicketDataList[Select].MovieName + " " + DataStore.TicketDataList[Select].MovieDate + " " + DataStore.TicketDataList[Select].MovieTime + " ";
                        DataStore.TicketDataList[Select].TicketName += "X" + ticket.Content.ToString();
                        Fix_set = false;
                        if(Free_set && DataStore.TicketDataList[Select].TicketSave[5] != "0")
                        {
                            DataStore.TicketDataList[Select].TicketName += "(有使用免費兌換卷)";
                            DataStore.TicketDataList[Select]._Free = true;
                        }
                        else
                            DataStore.TicketDataList[Select]._Free = false;
                    }
                    else
                    {
                        DataStore.TicketDataList[count].Total = Total.Content.ToString();
                        DataStore.TicketDataList[count].TicketName = "$" + DataStore.TicketDataList[count].Total + " " + DataStore.TicketDataList[count].TicketName;
                        DataStore.TicketDataList[count].TicketName += "X" + ticket.Content.ToString();
                        if (Free_set && DataStore.TicketDataList[count].TicketSave[5] != "0") 
                        { 
                            DataStore.TicketDataList[count].TicketName += "(有使用免費兌換卷)";
                            DataStore.TicketDataList[count]._Free = true;
                        }
                        else
                            DataStore.TicketDataList[count]._Free = false;
                        count++;
                    }
                    menu = new Menu(DataStore.TicketDataList);
                    menu.Show();
                    window.Close();
                }
            }
        }

        private void save()
        {
            if (Fix_set)
                set = Select;
            else
                set = count;
            DataStore.TicketDataList[set].TicketSave[0] = ticket_number1.Content.ToString();
            DataStore.TicketDataList[set].TicketSave[1] = ticket_number2.Content.ToString();
            DataStore.TicketDataList[set].TicketSave[2] = ticket_number3.Content.ToString();
            DataStore.TicketDataList[set].TicketSave[3] = ticket_number4.Content.ToString();
            DataStore.TicketDataList[set].TicketSave[4] = ticket_number5.Content.ToString();
            DataStore.TicketDataList[set].TicketSave[5] = ticket_free.Content.ToString();
            DataStore.TicketDataList[set].TagSave[0] = tag_number1.Content.ToString();
            DataStore.TicketDataList[set].TagSave[1] = tag_number2.Content.ToString();
            DataStore.TicketDataList[set].TagSave[2] = tag_number3.Content.ToString();
            DataStore.TicketDataList[set].TagSave[3] = tag_number4.Content.ToString();
            DataStore.TicketDataList[set].ComboSave[0] = combo_number1.Content.ToString();
            DataStore.TicketDataList[set].ComboSave[1] = combo_number2.Content.ToString();
            DataStore.TicketDataList[set].ComboSave[2] = combo_number3.Content.ToString();
            DataStore.TicketDataList[set].ComboSave[3] = combo_number4.Content.ToString();
            DataStore.TicketDataList[set].FoodSave[0] = food_number1.Content.ToString();
            DataStore.TicketDataList[set].FoodSave[1] = food_number2.Content.ToString();
            DataStore.TicketDataList[set].FoodSave[2] = food_number3.Content.ToString();
            DataStore.TicketDataList[set].FoodSave[3] = food_number4.Content.ToString();
            DataStore.TicketDataList[set].FoodSave[4] = food_number5.Content.ToString();
            DataStore.TicketDataList[set].FoodSave[5] = food_number6.Content.ToString();
            DataStore.TicketDataList[set].FoodSave[6] = food_number7.Content.ToString();
            DataStore.TicketDataList[set].FoodSave[7] = food_number8.Content.ToString();
            DataStore.TicketDataList[set].FoodSave[8] = food_number9.Content.ToString();
            DataStore.TicketDataList[set].FoodSave[9] = food_number10.Content.ToString();
            DataStore.TicketDataList[set].TicketCount = ticket.Content.ToString();
            DataStore.TicketDataList[set].Total = Total.Content.ToString();
        }

        private void min_reset()
        {
            ticket_number1.Content = "0";
            ticket_number2.Content = "0";
            ticket_number3.Content = "0";
            ticket_number4.Content = "0";
            ticket_number5.Content = "0";
            ticket_free.Content = "0";
            tag_number1.Content = "0";
            tag_number2.Content = "0";
            tag_number3.Content = "0";
            tag_number4.Content = "0";
            combo_number1.Content = "0";
            combo_number2.Content = "0";
            combo_number3.Content = "0";
            combo_number4.Content = "0";
            minus_ticket1.IsEnabled = false;
            minus_ticket2.IsEnabled = false;
            minus_ticket3.IsEnabled = false;
            minus_ticket4.IsEnabled = false;
            if (early)
                minus_ticket5.IsEnabled = false;
            minus_ticket_free.IsEnabled = false;
            minus_tag1.IsEnabled = false;
            minus_tag2.IsEnabled = false;
            minus_tag3.IsEnabled = false;
            minus_tag4.IsEnabled = false;
            minus_combo1.IsEnabled = false;
            minus_combo2.IsEnabled = false;
            minus_combo3.IsEnabled = false;
            minus_combo4.IsEnabled = false;
            plus_ticket1.IsEnabled = true;
            plus_ticket2.IsEnabled = true;
            plus_ticket3.IsEnabled = true;
            plus_ticket4.IsEnabled = true;
            if (early)
                plus_ticket5.IsEnabled = true;
            plus_tag1.IsEnabled = true;
            plus_tag2.IsEnabled = true;
            plus_tag3.IsEnabled = true;
            plus_tag4.IsEnabled = true;
            plus_combo1.IsEnabled = true;
            plus_combo2.IsEnabled = true;
            plus_combo3.IsEnabled = true;
            plus_combo4.IsEnabled = true;
            ticket_total = 0;
            tag_total = 0;
            combo_total = 0;
            total = food_price;
            Total.Content = total.ToString();
        }

        private void max_reset()
        {
            plus_ticket1.IsEnabled = true;
            plus_ticket2.IsEnabled = true;
            plus_ticket3.IsEnabled = true;
            plus_ticket4.IsEnabled = true;
            if (early)
                plus_ticket5.IsEnabled = true;
            plus_tag1.IsEnabled = true;
            plus_tag2.IsEnabled = true;
            plus_tag3.IsEnabled = true;
            plus_tag4.IsEnabled = true;
            plus_combo1.IsEnabled = true;
            plus_combo2.IsEnabled = true;
            plus_combo3.IsEnabled = true;
            plus_combo4.IsEnabled = true;
        }

    }
}
