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
using Масивы;


namespace _9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Калион Екатерина Максимовна. 9 пр.  Заполнить таблицу анкетных данных на 5 человек с полями: ФИО, пол, год рождения, " +
                "место рождения, национальность. Вывести результат на экран. Вывести средний возраст");
        }

        //Выход из программы
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        Human[] human;
        string[,] matrix;
        public MainWindow()
        {
            InitializeComponent();
            human = new Human[6];
            matrix = new string[5, 6];
        }

        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(N.Text, out int n) && n>0 && n<=5 && FIO.Text != string.Empty && 
                Pol.Text != string.Empty  && int.TryParse(Year.Text, out int year) && year >0
                && Country.Text != string.Empty && Nacion.Text != string.Empty)
            {
                    human[n - 1].N = Convert.ToInt32(N.Text);
                    human[n - 1].FIO = FIO.Text;
                    human[n - 1].Pol = Pol.Text;
                    human[n - 1].Year = Convert.ToInt32(Year.Text);
                    human[n - 1].Country = Country.Text;
                    human[n - 1].Nacion = Nacion.Text;
                
                matrix[n - 1, 0] = human[n - 1].N.ToString();
                matrix[n - 1, 1] = human[n - 1].FIO;
                matrix[n - 1, 2] = human[n - 1].Pol;
                matrix[n - 1, 3] = human[n - 1].Year.ToString();
                matrix[n - 1, 4] = human[n - 1].Country;
                matrix[n - 1, 5] = human[n - 1].Nacion;
 
                dataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                dataGrid.Columns[0].Header = "№";
                dataGrid.Columns[1].Header = "ФИО";
                dataGrid.Columns[2].Header = "Пол";
                dataGrid.Columns[3].Header = "Год рождения";
                dataGrid.Columns[4].Header = "Место рождения";
                dataGrid.Columns[5].Header = "Национальность";
            }
            else MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Расчитать_Click(object sender, RoutedEventArgs e)
        {
           int rez, kol = 0, age, sum = 0;
           for (int j = 0; j < 5; j++)
           {
               age = 2021 - Convert.ToInt32(human[j].Year); //находим возраст
               sum = sum + age;
               kol++;
           }
           rez = sum / kol;
           Rez.Text = rez.ToString();
        }

        private void Очистить_Click(object sender, RoutedEventArgs e)
        {
            N.Clear();
            FIO.Clear();
            Pol.Clear();
            Year.Clear();
            Country.Clear();
            Nacion.Clear();
            Rez.Clear();
          
        }
    }
}
