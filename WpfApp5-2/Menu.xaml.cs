using System.Windows;
using System.Windows.Controls;
using static WpfApp5_2.MainWindow;

namespace WpfApp5_2
{
    /// <summary>
    /// Menu.xaml 的互動邏輯
    /// </summary>
    public partial class Menu : Window
    {
        public Menu(List<TicketData> TicketDataList)
        {
            InitializeComponent();
            for (int i = 0; i < count; i++)
                listbox1.Items.Add(TicketDataList[i].TicketName);
            for (int i = 0; i < count; i++)
                total += int.Parse(DataStore.TicketDataList[i].Total);
            Total.Content = total;
        }

        private int total = 0;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button == back)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            if (button == fix)
            {
                if (listbox1.SelectedIndex != -1)
                {
                    Fix_set = true;
                    Select = listbox1.SelectedIndex;
                    Page1 page1 = new Page1();
                    Page2 page2;
                    Window menu = Window.GetWindow(this);
                    page2 = new Page2(page1, DataStore.TicketDataList[listbox1.SelectedIndex].MovieName, DataStore.TicketDataList[listbox1.SelectedIndex].MovieDate, DataStore.TicketDataList[listbox1.SelectedIndex].MovieTime, DataStore.TicketDataList[Select].MovieErr);
                    menu.Height = 765;
                    menu.Width = 1100;
                    MainFrame.Navigate(page2);
                }
            }
            if (button == delete)
            {
                if (listbox1.SelectedIndex != -1)
                {
                    total -= int.Parse(DataStore.TicketDataList[listbox1.SelectedIndex].Total);
                    if (DataStore.TicketDataList[listbox1.SelectedIndex]._Free)
                        Free_ticket++;
                    DataStore.TicketDataList.RemoveAt(listbox1.SelectedIndex);
                    listbox1.Items.Remove(listbox1.SelectedItem);
                    count--;
                    Total.Content = total;
                }

            }
            if (button == submit)
            {
                if (count == 0)
                {
                    MessageBox.Show("!!!請先訂票!!!");
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("確定送出?", "", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            DataStore.TicketDataList.Clear();
                            Fin fin = new Fin(DataStore.TicketDataList);
                            fin.Show();
                            this.Close();
                            break;
                        case MessageBoxResult.No:
                            break;
                        case MessageBoxResult.Cancel:
                            break;
                    }
                }
            }
        }
    }
}
