using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Windows.Shapes;
using static ngieu.MainWindow;

namespace ngieu
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Window
    {
        public static string token;
        public login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool authCheck=false;
            token = getToken();

            if (token!="")
            {
                authCheck = auth(tbLogin.Text, tbPass.Text);

                if (authCheck == true)
                {
                    MessageBox.Show("Авторизация успешна", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.DialogResult = false;
                }
            }
            else
            {
                MessageBox.Show("Токен не получен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.DialogResult = false;
            }

            



        }

        string getToken()
        {
            request = (HttpWebRequest)WebRequest.Create("http://ngiei.mcdir.ru/login/index.php");
            request.Method = "GET";
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;
            request.CookieContainer = cook;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";


            response = (HttpWebResponse)request.GetResponse();
            string tmp = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Match pattern;
            pattern = Regex.Match(tmp, "logintoken.*?value=\"(.*?)\"");
          


            return pattern.Groups[1].Value;
        }


        bool auth(string login, string pass)
        {
            String postData = "anchor=&logintoken="+token+"&username="+ login + "&password="+ pass;
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] postDataByte = enc.GetBytes(postData);

            request = (HttpWebRequest)WebRequest.Create("http://ngiei.mcdir.ru/login/index.php");
            request.Method = "POST";
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;
            request.CookieContainer = cook;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataByte.Length;


            Stream stream = request.GetRequestStream();
            StreamWriter sw = new StreamWriter(stream);
            sw.Write(postDataByte);
            stream.Write(postDataByte, 0, postDataByte.Length);
            stream.Close();

            response = (HttpWebResponse)request.GetResponse();
            string tmp = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (tmp.Contains("Текущий пользователь"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void upper_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }    
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            //this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
