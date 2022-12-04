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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int scores;//переменная счётчика правильных ответов
        int errors;//переменная счётчика неправильных ответов
        int rb;//переменная, указвающая, какой radiobutton содержит правильный ответ на задачу
        public MainWindow()
        {
            InitializeComponent();
            rb = generator();//генерируем условие при запуске программы

        }


        private int generator()//создаёт условие и варианты ответов
        {
            var1.IsChecked = false;//убираем выделение из всех radiobutton
            var2.IsChecked = false;
            var3.IsChecked = false;
            var4.IsChecked = false;
            char[] opers = { '-', '+', '-', '+' };//это костыль для того чтобы выбирались разные значения. Если сделать 2 элемента то значение будет одно.
            Random rnd = new Random();
            char op = opers[rnd.Next(0, 3)];//выбор знака: + или -
            int x = rnd.Next(1, 50);//генератор чисел
            int y = rnd.Next(1, 50);
            urav.Content = string.Format("{1} {0} {2} = ?", op, x, y);//генерация задания
            int vopr = 0;//переменная для хранения результата
            switch (op)
            {
                case '+':
                    vopr = x + y;
                    break;

                case '-':
                    vopr = x - y;
                    break;
            }
            int rb = rnd.Next(1, 4);//выбор radiobutton в котором будет правильный ответ
            switch (rb)//подписываем все radiobutton в выбранном будет правильный ответ, в остальных случайные числа
            {
                case 1:
                    var1.Content = vopr;
                    var2.Content = rnd.Next(-100, 100);
                    var3.Content = rnd.Next(-100, 100);
                    var4.Content = rnd.Next(-100, 100);
                    break;
                case 2:
                    var2.Content = vopr;
                    var1.Content = rnd.Next(-100, 100);
                    var3.Content = rnd.Next(-100, 100);
                    var4.Content = rnd.Next(-100, 100);
                    break;
                case 3:
                    var3.Content = vopr;
                    var1.Content = rnd.Next(-100, 100);
                    var2.Content = rnd.Next(-100, 100);
                    var4.Content = rnd.Next(-100, 100);
                    break;
                case 4:
                    var4.Content = vopr;
                    var1.Content = rnd.Next(-100, 100);
                    var2.Content = rnd.Next(-100, 100);
                    var3.Content = rnd.Next(-100, 100);
                    break;
            }
            return rb;//возвращаем номер radiobutton с правильным ответом
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (rb)//проверяем что выбрана кнопка с правильным ответом
            {
                case 1:
                    if(var1.IsChecked ==true)
                    {
                        scores++;//изменяем счётчик
                        res.Content = "Верно";//выводим что ответ вернвый
                    }
                    else
                    {
                        errors++;//изменяем счётчик
                        res.Content = "Неверно";//выводим что ответ неверный
                    }
                    break;
                case 2:
                    if (var2.IsChecked == true)
                    {
                        scores++;
                        res.Content = "Верно";
                    }
                    else
                    {
                        errors++;
                        res.Content = "Неверно";
                    }
                    break;

                case 3:
                    if (var3.IsChecked == true)
                    {
                        scores++;
                        res.Content = "Верно";
                    }
                    else
                    {
                        errors++;
                        res.Content = "Неверно";
                    }
                    break;

                case 4:
                    if (var4.IsChecked == true)
                    {
                        scores++;
                        res.Content = "Верно";
                    }
                    else
                    {
                        errors++;
                        res.Content = "Неверно";
                    }
                    break;


            }

            score.Content = string.Format("Счёт: {0}", scores);//обновляем счётчики
            error.Content = string.Format("Ошибок: {0}", errors);
            rb = generator();//генерируем новое задание

        }
    }
}
