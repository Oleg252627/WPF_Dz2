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

namespace DZ2zad1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool Flag_Caps_Lock = true;
        private int Lehgt_Text = 105;
        private int Lengt_Apper_Text = 90;
        private int namber_Slaider = 1;
        private int fails = 0;
        private bool Flag_Backspase = true;
        private bool Flag_Pravilnay_Stroka = true;
        private DateTime dateTime;
        Random random;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            this.Text_Box_Simvoli.Text = null;
            this.Slider_Slognosti.IsEnabled = false;
            this.Chec_Boks_Shift.IsEnabled = false;
            this.Speed.Text = $"Speed: {0} chars/min";
            fails = 0;
            this.Fails.Text = $"Fails: {fails}";
            this.Button_Stop.IsEnabled = true;
            this.Button_Start.IsEnabled = false;
            this.Text_Box_Nabor.IsReadOnly = false;
            dateTime = DateTime.Now;
            Zapolnenie_TextBox();
            this.Text_Box_Nabor.Text = null;
            this.Text_Box_Nabor.Focus();
        }

        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            Stop();
        }
        private void Stop()
        {
            this.Slider_Slognosti.IsEnabled = true;
            this.Chec_Boks_Shift.IsEnabled = true;
            this.Button_Stop.IsEnabled = false;
            this.Button_Start.IsEnabled = true;
            this.Text_Box_Nabor.IsReadOnly = true;
        }
        private void Slider_Slognosti_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            namber_Slaider = (int)this.Slider_Slognosti.Value;
            this.Text_Block_Slognost.Text = $"Difficulty: {namber_Slaider.ToString()}";
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            foreach (var i in this.grid_global.Children)
            {
                if(i is Grid)
                {
                    foreach (var j in (i as Grid).Children)
                    {
                        if(j is Grid)
                        {
                            foreach (var item in (j as Grid).Children)
                            {
                                if(item is Button)
                                {
                                    if((item as Button).Name==e.Key.ToString())
                                    {
                                        (item as Button).Opacity = 0.5;
                                        if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                        {
                                            ToApper_Nambers();
                                            if(Flag_Caps_Lock)
                                            {
                                                ToApper_Text();
                                            }
                                            else
                                            {
                                                ToLover_Text();
                                            }
                                            
                                        }
                                        else if(e.Key.ToString() == "Capital")
                                        {
                                            if(Flag_Caps_Lock)
                                            {
                                                ToApper_Text();
                                                Flag_Caps_Lock = false;
                                            }
                                            else
                                            {
                                                ToLover_Text();
                                                Flag_Caps_Lock = true;
                                            }
                                        }
                                        else if(e.Key.ToString()== "Back")
                                        {
                                            Flag_Backspase = false;
                                        }
                                        else
                                        {
                                            Flag_Backspase = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            foreach (var i in this.grid_global.Children)
            {
                if (i is Grid)
                {
                    foreach (var j in (i as Grid).Children)
                    {
                        if (j is Grid)
                        {
                            foreach (var item in (j as Grid).Children)
                            {
                                if (item is Button)
                                {
                                    if ((item as Button).Name == e.Key.ToString())
                                    {
                                        (item as Button).Opacity = 1;
                                        if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                        {
                                            ToLover_Nambers();
                                            if (!Flag_Caps_Lock)
                                            {
                                                ToApper_Text();
                                            }
                                            else
                                            {
                                                ToLover_Text();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ToApper_Text()
        {  
            this.Q.Content = "Q";
            this.W.Content = "W";
            this.E.Content = "E";
            this.R.Content = "R";
            this.T.Content = "T";
            this.Y.Content = "Y";
            this.U.Content = "U";
            this.I.Content = "I";
            this.O.Content = "O";
            this.P.Content = "P";
            this.A.Content = "A";
            this.S.Content = "S";
            this.D.Content = "D";
            this.F.Content = "F";
            this.G.Content = "G";
            this.H.Content = "H";
            this.J.Content = "J";
            this.K.Content = "K";
            this.L.Content = "L";
            this.Z.Content = "Z";
            this.X.Content = "X";
            this.C.Content = "C";
            this.V.Content = "V";
            this.B.Content = "B";
            this.N.Content = "N";
            this.M.Content = "M";
            
        }

        private void ToLover_Text()
        {
            this.Q.Content = "q";
            this.W.Content = "w";
            this.E.Content = "e";
            this.R.Content = "r";
            this.T.Content = "t";
            this.Y.Content = "y";
            this.U.Content = "u";
            this.I.Content = "i";
            this.O.Content = "o";
            this.P.Content = "p";
            this.A.Content = "a";
            this.S.Content = "s";
            this.D.Content = "d";
            this.F.Content = "f";
            this.G.Content = "g";
            this.H.Content = "h";
            this.J.Content = "j";
            this.K.Content = "k";
            this.L.Content = "l";
            this.Z.Content = "z";
            this.X.Content = "x";
            this.C.Content = "c";
            this.V.Content = "v";
            this.B.Content = "b";
            this.N.Content = "n";
            this.M.Content = "m";
            
        }

        private void ToApper_Nambers()
        {
            this.Oem3.Content = "~";
            this.D1.Content = "!";
            this.D2.Content = "@";
            this.D3.Content = "#";
            this.D4.Content = "$";
            this.D5.Content = "%";
            this.D6.Content = "^";
            this.D7.Content = "&";
            this.D8.Content = "*";
            this.D9.Content = "(";
            this.D0.Content = ")";
            this.OemMinus.Content = "_";
            this.OemPlus.Content = "+";
            this.OemOpenBrackets.Content = "{";
            this.Oem6.Content = "}";
            this.Oem5.Content = "|";
            this.Oem1.Content = ":";
            this.OemQuotes.Content = "\"";
            this.OemComma.Content = "<";
            this.OemPeriod.Content = ">";
            this.OemQuestion.Content = "?";
        }
        private void ToLover_Nambers()
        {
            this.Oem3.Content = "`";
            this.D1.Content = "1";
            this.D2.Content = "2";
            this.D3.Content = "3";
            this.D4.Content = "4";
            this.D5.Content = "5";
            this.D6.Content = "6";
            this.D7.Content = "7";
            this.D8.Content = "8";
            this.D9.Content = "9";
            this.D0.Content = "0";
            this.OemMinus.Content = "-";
            this.OemPlus.Content = "=";
            this.OemOpenBrackets.Content = "[";
            this.Oem6.Content = "]";
            this.Oem5.Content = "\\";
            this.Oem1.Content = ";";
            this.OemQuotes.Content = "'";
            this.OemComma.Content = ",";
            this.OemPeriod.Content = ".";
            this.OemQuestion.Content = "/";
        }

        private void Zapolnenie_TextBox()
        {
            random = new Random();
            List<char> Simvol_Lover = new List<char> { '`','1','2','q','a','z','9','i','k',',',' ','3','w','s','x',
            '0','o','l','.',' ','4','e','d','c','-','=','p','[',']','\\',';','\'','/',' ','5','6','r','t','f','g','v','b',
            ' ','7','8','y','u','h','j','n','m',' '};
            List<char> Simvol_Upper = new List<char> { '~','!','@','Q','A','Z','(','I','K','<',' ','#','W','S','X',
            ')','O','L','>',' ','$','E','D','C','_','+','P','{','}','|',':','\"','?',' ','%','^','R','T','F','G','V','B',
            ' ','&','*','Y','U','H','J','N','M',' '};
            List<char> Stroca_Rand = new List<char> { };
            if(namber_Slaider==1)
            {
                for (int i = 0; i < 11; i++)
                {
                    Stroca_Rand.Add(Simvol_Lover[i]);
                }
                if(this.Chec_Boks_Shift.IsChecked==true)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        Stroca_Rand.Add(Simvol_Upper[i]);
                    }
                }
            }
            else if(namber_Slaider == 2)
            {
                for (int i = 0; i < 20; i++)
                {
                    Stroca_Rand.Add(Simvol_Lover[i]);
                }
                if (this.Chec_Boks_Shift.IsChecked == true)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Stroca_Rand.Add(Simvol_Upper[i]);
                    }
                }
            }
            else if(namber_Slaider == 3)
            {
                for (int i = 0; i < 34; i++)
                {
                    Stroca_Rand.Add(Simvol_Lover[i]);
                }
                if (this.Chec_Boks_Shift.IsChecked == true)
                {
                    for (int i = 0; i < 34; i++)
                    {
                        Stroca_Rand.Add(Simvol_Upper[i]);
                    }
                }
            }
            else if(namber_Slaider == 4)
            {
                for (int i = 0; i < 43; i++)
                {
                    Stroca_Rand.Add(Simvol_Lover[i]);
                }
                if (this.Chec_Boks_Shift.IsChecked == true)
                {
                    for (int i = 0; i < 43; i++)
                    {
                        Stroca_Rand.Add(Simvol_Upper[i]);
                    }
                }
            }
            else if(namber_Slaider == 5)
            {
                for (int i = 0; i < 52; i++)
                {
                    Stroca_Rand.Add(Simvol_Lover[i]);
                }
                if (this.Chec_Boks_Shift.IsChecked == true)
                {
                    for (int i = 0; i < 52; i++)
                    {
                        Stroca_Rand.Add(Simvol_Upper[i]);
                    }
                }
            }
            String str="";
            if(this.Chec_Boks_Shift.IsChecked==true)
            {
                for (int i = 0; i < Lengt_Apper_Text; i++)
                {
                    str += Stroca_Rand[random.Next(Stroca_Rand.Count)];
                }
            }
            else
            {
                for (int i = 0; i < Lehgt_Text; i++)
                {
                    str += Stroca_Rand[random.Next(Stroca_Rand.Count)];
                }
            }
            this.Text_Box_Simvoli.Text = str;
        }
        private void Text_Box_Nabor_TextChanged(object sender, TextChangedEventArgs e)
        {
            int start = 0;
            int Text_Lengt = this.Text_Box_Nabor.Text.Length;
            String str = this.Text_Box_Simvoli.Text.Substring(start, Text_Lengt);
            if (this.Text_Box_Nabor.Text.Equals(str))
            {
                if(Flag_Backspase)
                {
                    this.Speed.Text = "Speed: " + Math.Round(this.Text_Box_Nabor.Text.Length / (DateTime.Now - dateTime).TotalMinutes).ToString() + " chars/min";
                }
                this.Text_Box_Nabor.Foreground = new SolidColorBrush(Colors.Black);
                Flag_Pravilnay_Stroka = true;
            }
            else
            {
                if(Flag_Backspase)
                {
                    fails++;
                }
                this.Text_Box_Nabor.Foreground = new SolidColorBrush(Colors.Red);
                this.Fails.Text = $"Fails: {fails}";
                Flag_Pravilnay_Stroka = false;
            }
            if(Flag_Pravilnay_Stroka && this.Text_Box_Simvoli.Text.Length==this.Text_Box_Nabor.Text.Length)
            {
                this.Speed.Text= "Speed: " + Math.Round(this.Text_Box_Nabor.Text.Length / (DateTime.Now - dateTime).TotalMinutes).ToString()+ " chars/min";
                MessageBox.Show("Мои поздравления вы красавчик!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                Stop();
            }
        }

    }
}
