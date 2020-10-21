using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using HtmlAgilityPack;

namespace ngieu
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static HttpWebRequest request;
        public static HttpWebResponse response;
        public static CookieContainer cook = new CookieContainer();
        public static List<profile> CurrentUser = new List<profile>();
        public static List<course> myCourse { get; set; }
        public static HtmlWeb web = new HtmlWeb();
        public MainWindow()
        {
            InitializeComponent();
            myCourse = new List<course>();
           
        }

        public class course
        {
            public string nameCourse { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            login login = new login();
            if (login.ShowDialog()==true)
            {
                this.Title = CurrentUser[CurrentUser.Count-1].fio;
                btnAuth.IsEnabled = false;
                getMyCourse();
                this.Show();
            }
            else
            {
                this.Title = "Пользователь не авторизован";
                this.Show();
            }
        }

        void getMyCourse()
        {
            request = (HttpWebRequest)WebRequest.Create("http://ngiei.mcdir.ru/user/profile.php?id=" + CurrentUser[CurrentUser.Count-1].userID + "&showallcourses=1");
            request.Method = "GET";
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;
            request.CookieContainer = cook;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";


            response = (HttpWebResponse)request.GetResponse();
            string tmp = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //var htmldoc = web.Load("");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(tmp);
            var node = doc.DocumentNode.SelectNodes(".//a[contains(@href,'http://ngiei.mcdir.ru/user/view.php?id=" + CurrentUser[CurrentUser.Count-1].userID + "&amp;course=')]");

            for (int i=0;i<node.Count;i++)
            {
                myCourse.Add(new course { nameCourse = node[i].InnerHtml.Trim() });
            }
            DataContext = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            myCourse.Add(new course { nameCourse="dddd"});
            
        }
    }  

}
