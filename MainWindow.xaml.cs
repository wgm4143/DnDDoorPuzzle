using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Anasi_Puzzle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> dict;
        string[,] answer;
        public MainWindow()
        {
            InitializeComponent();

            answer = new string[4, 4]
            {
                {"ni", "chu", "si", "wa" },
                {"chi", "ku", "ha", "vi" },
                {"qi", "dja", "ru", "du" },
                {"shi", "ma", "ka", "ri" },

            };

            dict = new Dictionary<string, string>
            {
                //Answers --

                // Line 1
                { "ni chu", "PROTECT" },
                { "si wa", "(THE) ARTIFACTS" },
                // Line 2
                { "chi", "INSIDE" },
                { "ku", "THIS" },
                { "ha vi", "SANCTUM" },
                // Line 3
                { "qi", "THROUGH" },
                { "dja ru", "(THE) POWER OF" },
                { "du", "OUR" },
                // Line 4
                { "shi", "GOD" },
                { "ma ka ri", "MAKARI" },

                // Herrings --

                // 3 symbol
                { "du ru wa",     "DROW" },
                { "shi ru wa",    "ELVES" },
                { "ha ru wa",     "HUMANS" },
                // 2 symbol
                { "qi du",    "SCHOOL" },
                { "ri ka",    "GREAT" },
                { "ha ka",    "SOME" },
                { "vi ka",    "ALL" },
                { "ni dja",   "TAKE" },
                { "wa ri",    "TIME" },
                { "ka ma",    "YEAR" },
                { "qi ri",    "FUTURE" },
                { "ch uni",   "PAST" },
                { "si ma",    "KNOWLEDGE" },
                { "ni du",    "PRAY" },
                { "ka qi",    "SWORD" },
                { "qi shi",   "MAGIC" },
                { "chu dja",  "AIR" },
                { "si ru",    "WATER" },
                { "ru ka",    "FIRE" },
                { "ku ri",    "EARTH" },
                { "ma ku",    "STRENGTH" },
                { "shi ku",   "DARKNESS" },
                { "chi du",   "LOVE" },
                { "du ha",    "FIGHT" },
                { "wa chi",   "SEE" },
                // 1 symbol
                { "dja",  "NOW" },
                { "ka",   "EAT" },
                { "wa",   "WHO" },
                { "ma",   "WE" },
                { "vi",   "AND" }
            };

            SetTextBoxes();
        }

        private string Translate(string s)
        {
            foreach (KeyValuePair<string, string> kv in dict)
                s = s.Replace(kv.Key, kv.Value);

            for (int i = 0; i < 4; i++)
            {
                s = s.Replace("qi", " ? ");
                s = s.Replace("ru", " ? ");
                s = s.Replace("chi", " ? ");
                s = s.Replace("dja", " ? ");
                s = s.Replace("ka", " ? ");
                s = s.Replace("du", " ? ");
                s = s.Replace("shi", " ? ");
                s = s.Replace("ma", " ? ");
                s = s.Replace("wa", " ? ");
                s = s.Replace("vi", " ? ");
                s = s.Replace("ku", " ? ");
                s = s.Replace("chu", " ? ");
                s = s.Replace("ri", " ? ");
                s = s.Replace("ha", " ? ");
                s = s.Replace("ni", " ? ");
                s = s.Replace("si", " ? ");
            }
            return s;
        }

        private string Img2String(int i)
        {
            switch (i)
            {
                case 1:
                    return "qi";
                case 2:
                    return "ru";
                case 3:
                    return "chi";
                case 4:
                    return "dja";
                case 5:
                    return "ka";
                case 6:
                    return "du";
                case 7:
                    return "shi";
                case 8:
                    return "ma";
                case 9:
                    return "wa";
                case 10:
                    return "vi";
                case 11:
                    return "ku";
                case 12:
                    return "chu";
                case 13:
                    return "ri";
                case 14:
                    return "ha";
                case 15:
                    return "ni";
                case 16:
                    return "si";
            }
            return "";
        }

        private void SetTextBoxes()
        {
            tb0.Text = Img2String(int.Parse(i0.Tag.ToString()));
            tb1.Text = Img2String(int.Parse(i1.Tag.ToString()));
            tb2.Text = Img2String(int.Parse(i2.Tag.ToString()));
            tb3.Text = Img2String(int.Parse(i3.Tag.ToString()));
            tb4.Text = Img2String(int.Parse(i4.Tag.ToString()));
            tb5.Text = Img2String(int.Parse(i5.Tag.ToString()));
            tb6.Text = Img2String(int.Parse(i6.Tag.ToString()));
            tb7.Text = Img2String(int.Parse(i7.Tag.ToString()));
            tb8.Text = Img2String(int.Parse(i8.Tag.ToString()));
            tb9.Text = Img2String(int.Parse(i9.Tag.ToString()));
            tb10.Text = Img2String(int.Parse(i10.Tag.ToString()));
            tb11.Text = Img2String(int.Parse(i11.Tag.ToString()));
            tb12.Text = Img2String(int.Parse(i12.Tag.ToString()));
            tb13.Text = Img2String(int.Parse(i13.Tag.ToString()));
            tb14.Text = Img2String(int.Parse(i14.Tag.ToString()));
            tb15.Text = Img2String(int.Parse(i15.Tag.ToString()));

            string tr0 = tb0.Text +" "+ tb1.Text +" "+ tb2.Text +" "+ tb3.Text;
            string tr1 = tb4.Text +" "+ tb5.Text +" "+ tb6.Text +" "+ tb7.Text;
            string tr2 = tb8.Text +" "+ tb9.Text +" "+ tb10.Text +" "+ tb11.Text;
            string tr3 = tb12.Text +" "+ tb13.Text +" "+ tb14.Text +" "+ tb15.Text;

            translated0.Text = Translate(tr0);
            translated1.Text = Translate(tr1);
            translated2.Text = Translate(tr2);
            translated3.Text = Translate(tr3);
        }

        private void CheckAnswers()
        {
            // Check horizontals
            row0.Visibility = (tb0.Text == answer[0, 0] && tb1.Text == answer[0, 1] && tb2.Text == answer[0, 2] & tb3.Text == answer[0, 3]) ?
                Visibility.Visible : Visibility.Hidden;
            row1.Visibility = (tb4.Text == answer[1, 0] && tb5.Text == answer[1, 1] && tb6.Text == answer[1, 2] & tb7.Text == answer[1, 3]) ?
                Visibility.Visible : Visibility.Hidden;
            row2.Visibility = (tb8.Text == answer[2, 0] && tb9.Text == answer[2, 1] && tb10.Text == answer[2, 2] & tb11.Text == answer[2, 3]) ?
                Visibility.Visible : Visibility.Hidden;
            row3.Visibility = (tb12.Text == answer[3, 0] && tb13.Text == answer[3, 1] && tb14.Text == answer[3, 2] & tb15.Text == answer[3, 3]) ?
                Visibility.Visible : Visibility.Hidden;

            // Check verticals
            col0.Visibility = (tb0.Text == answer[0, 0] && tb4.Text == answer[1, 0] && tb8.Text == answer[2, 0] & tb12.Text == answer[3, 0]) ?
                Visibility.Visible : Visibility.Hidden;
            col1.Visibility = (tb1.Text == answer[0, 1] && tb5.Text == answer[1, 1] && tb9.Text == answer[2, 1] & tb13.Text == answer[3, 1]) ?
                Visibility.Visible : Visibility.Hidden;
            col2.Visibility = (tb2.Text == answer[0, 2] && tb6.Text == answer[1, 2] && tb10.Text == answer[2, 2] & tb14.Text == answer[3, 2]) ?
                Visibility.Visible : Visibility.Hidden;
            col3.Visibility = (tb3.Text == answer[0, 3] && tb7.Text == answer[1, 3] && tb11.Text == answer[2, 3] & tb15.Text == answer[3, 3]) ?
                Visibility.Visible : Visibility.Hidden;

            // Check whole puzzle
            if (row0.Visibility == Visibility.Visible && 
                row1.Visibility == Visibility.Visible && 
                row2.Visibility == Visibility.Visible && 
                row3.Visibility == Visibility.Visible)
                click.Visibility = Visibility.Visible;
            else click.Visibility = Visibility.Hidden;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Add or subtract from tag (0-16) to get next glyph
            Image img = sender as Image;
            int i = int.Parse(img.Tag.ToString());
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                i = i + 1;
                if (i > 16)
                    i = 1;
            }
            if(e.RightButton == MouseButtonState.Pressed)
            {
                i = i - 1;
                if (i < 1)
                    i = 16;
            }
            string s = "glyph/" + i.ToString() + ".png";
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = new Uri(s, UriKind.Relative);
            bmp.EndInit();
            img.Source = bmp;
            img.Tag = i;

            SetTextBoxes();

            CheckAnswers();
        }
    }
}
