using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace workflow
{

    public class News
    {

        public string author;
        public string label;
        public string content;
        public string time;

        public News(string _author, string _label, string _content, string _time)
        {
            this.author = _author;
            this.label = _label;
            this.content = _content;
            this.time = _time;
        }

    }


    public static class Server
    {

        public static void getUser()
        {
            User.shedule = new List<string>() { "Русский", "Математика", "Информатика", "Русский", "Математика", "Информатика", "Русский" };
        }

        public static void addNews(string labelOfNews, string contentOfNews)
        {
            Console.WriteLine("Add news : " + labelOfNews + " : " + contentOfNews);
        }

        public static List<News> getNews()
        {

            List<News> contentMain = new List<News>();

            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString()));

            return contentMain;
        }

        public static Tuple<bool, string> check_user_enter(string login, string password)
        {
            if (!(login == "root" && password == "root"))
            {
                return new Tuple<bool, string>(false, "Нет пользователя c такими login и password");
            }
            return new Tuple<bool, string>(true, "accept");
        }

        public static Tuple<bool, string> new_user(string login, string password)
        {
            if (login == "root")
            {
                return new Tuple<bool, string>(false, "Пользователь с таким login уже существует");
            }
            return new Tuple<bool, string>(true, "accept");
        }

        public static Tuple<bool, string> refresh_password(string login)
        {
            if(login != "root")
            {
                return new Tuple<bool, string>(false, "Такой login в системе не зарегистрирован");
            }
            return new Tuple<bool, string>(true, "accept");
        }

    }

    public class User
    {

        static public List<string> shedule;

        static public void set_photo(string photo_src, workflow.login_form connectForm)
        {
            int width = (int)connectForm.a_main_screen_left_panel_picture_box.Size.Width;
            var height = (int)connectForm.a_main_screen_left_panel_picture_box.Size.Height;
            Bitmap original = new Bitmap(connectForm.a_change_image_dialog.FileName);
            connectForm.a_main_screen_left_panel_picture.Image = new Bitmap(original, width, height);
            //Server.update_user_photo();
        }

        static public void set_name(string name, workflow.login_form connectForm)
        {
            connectForm.a_main_screen_left_panel_name.Text = name;
        }

        static public bool getPrivilege(string privilegeName)
        {
            return true;
        }

    }

    public class helpToDraw
    {



    }


    public class screenConstructor
    {

        public static void setBox(Panel box, workflow.login_form connectForm)
        {

            if(box == connectForm.a_main_screen_box)
            {
                screenConstructor.changeMainScreenEnvironment("main", connectForm);
            }

            connectForm.a_main_screen_box.Visible = false;
            connectForm.a_sign_in_box.Visible = false;
            connectForm.a_sign_up_box.Visible = false;
            connectForm.a_forgot_password_box.Visible = false;
            box.Visible = true;
        }

        public static void setBox(GroupBox box, workflow.login_form connectForm)
        {

            connectForm.a_main_screen_box.Visible = false;
            connectForm.a_sign_in_box.Visible = false;
            connectForm.a_sign_up_box.Visible = false;
            connectForm.a_forgot_password_box.Visible = false;
            box.Visible = true;
        }

        public static void changeBoxes(Panel prevBox, GroupBox nextBox, workflow.login_form connectForm)
        {
            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void changeBoxes(Panel prevBox, Panel nextBox, workflow.login_form connectForm)
        {
            if (nextBox == connectForm.a_main_screen_box)
            {
                screenConstructor.changeMainScreenEnvironment("main", connectForm);
            }

            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void changeBoxes(GroupBox prevBox, GroupBox nextBox, workflow.login_form connectForm)
        {
            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void changeBoxes(GroupBox prevBox, Panel nextBox, workflow.login_form connectForm)
        {

            if (nextBox == connectForm.a_main_screen_box)
            {
                screenConstructor.changeMainScreenEnvironment("main", connectForm);
            }

            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void resetTopPanelButtonsColors(Label labelToSetActive, workflow.login_form connectForm)
        {
            connectForm.a_main_screen_top_panel_button1_text.ForeColor = System.Drawing.Color.Black;
            connectForm.a_main_screen_top_panel_button2_text.ForeColor = System.Drawing.Color.Black;
            connectForm.a_main_screen_top_panel_button3_text.ForeColor = System.Drawing.Color.Black;

            labelToSetActive.ForeColor = System.Drawing.Color.Red;
        }

        public static void cleanMainScreenEnvironment(workflow.login_form connectForm)
        {
            connectForm.a_main_screen_left_panel_custom_box.Controls.Clear();

            Panel a_main_screen_main_box_add_news_panel = connectForm.a_main_screen_main_box_add_news_panel;  //Cохраняем панель 'Добавить новость'
            Panel a_main_screen_main_box_add_news_button = connectForm.a_main_screen_main_box_add_news_button; //Cохраняем кнопку 'Добавить новость'

            connectForm.a_main_screen_main_box.Controls.Clear();

            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_news_panel); //Возвращаем панель 'Добавить новость'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_news_button); //Возвращаем кнопку 'Добавить новость'

            connectForm.a_main_screen_main_box_add_news_panel.Visible = false;
            connectForm.a_main_screen_main_box_add_news_button.Visible = false;
        }

        public static void changeMainScreenEnvironment(string environment, workflow.login_form connectForm)
        {

            cleanMainScreenEnvironment(connectForm);

            switch (environment)
            {
                case "main":

                    resetTopPanelButtonsColors(connectForm.a_main_screen_top_panel_button1_text, connectForm);

                    //--------------------------- left screen changes

                    List<string> labelLeft = new List<string>() { "Расписание: " };
                    List<string> contentLeft = User.shedule;
                    List<string> filledLeft = labelLeft.Concat(contentLeft).ToList();

                    Dictionary<int, ContentAlignment> propertiesLeft = new Dictionary<int, ContentAlignment>(filledLeft.Count());

                    propertiesLeft.Add(0, ContentAlignment.MiddleCenter);

                    customBox.addElements(filledLeft, propertiesLeft, connectForm.a_main_screen_left_panel_custom_box);

                    if (User.getPrivilege("addNews"))
                    {
                        connectForm.a_main_screen_main_box_add_news_button.Visible = true;
                    }

                    //--------------------------- main screen changes

                    List<News> labelMain = new List<News>() { new News("Автор", "Тема", "Cодержание", "Время публикации") };
                    List<News> contentMain = Server.getNews();
                    List<News> filledMain = labelMain.Concat(contentMain).ToList();

                    Dictionary<int, Color> propertiesMain = new Dictionary<int, Color>(filledLeft.Count());

                    propertiesMain.Add(0, SystemColors.ControlLight);

                    mainBox.addElements(filledMain, propertiesMain, connectForm.a_main_screen_main_box);


                    Console.WriteLine("Change environment : main");
                    break;

                case "documents":

                    resetTopPanelButtonsColors(connectForm.a_main_screen_top_panel_button2_text, connectForm);

                    Console.WriteLine("Change environment : documents");
                    break;

                case "chats":

                    resetTopPanelButtonsColors(connectForm.a_main_screen_top_panel_button3_text, connectForm);

                    Console.WriteLine("Change environment : chats");
                    break;
            }
        }
    }

    public class customBox
    {

        public static void addElements(List<string> elements, Dictionary<int, ContentAlignment> properties, Panel customBox)
        {
            int countOfElements = elements.Count();

            int width = customBox.Size.Width;
            int height = customBox.Size.Height;

            int widthOfElements = width;
            int heightOfElements = height / countOfElements;

            int xPosition = 0;
            int yPosition = 0;

            for(int num = 0; num < elements.Count(); num ++)
            {
                string stringElement = elements[num];

                Panel element = new Panel();
                element.Size = new Size(widthOfElements, heightOfElements);
                element.BorderStyle = BorderStyle.FixedSingle;
                element.Location = new Point(xPosition, yPosition);

                Label labelOnElement = new Label();

                labelOnElement.AutoSize = false;
                labelOnElement.Size = new Size(widthOfElements, heightOfElements);

                labelOnElement.Font = new Font("Microsoft San Serif", 10);

                if (properties.ContainsKey(num))
                {
                    labelOnElement.TextAlign = properties[num];
                }
                else
                {
                    labelOnElement.TextAlign = ContentAlignment.MiddleLeft;
                }

                labelOnElement.Text = stringElement;

                element.Controls.Add(labelOnElement);

                customBox.Controls.Add(element);

                yPosition += heightOfElements - 1; //Чтобы borders не сливались
            }

        }

    }

    public class mainBox
    {
        public static void addElements(List<News> elements, Dictionary<int, Color> properties, Panel mainBox)
        {
            int countOfElements = elements.Count();

            int width = mainBox.Size.Width;
            int height = mainBox.Size.Height;

            int xMargin = 24;
            int topYMargin = 30;
            int yMargin = -1; //Контролирует отступы между строчками, при -1 border накладываются друг на друга

            int widthOfElements = width - xMargin * 2;
            int heightOfElements = 80;
            int heightOfCustomElements = 40;

            int xPosition = xMargin;
            int yPosition = topYMargin;

            int widthOfElementIncide = 0;

            for (int num = 0; num < elements.Count(); num++)
            {

                Panel element = new Panel();
                element.Location = new Point(xPosition, yPosition);

                if (properties.ContainsKey(num))
                {
                    element.BackColor = properties[num];
                    element.Size = new Size(widthOfElements, heightOfCustomElements);
                }
                else
                {
                    element.Size = new Size(widthOfElements, heightOfElements);
                }

                int xPositionIncide = 0;

                Label author = new Label();
                author.Text = elements[num].author;
                widthOfElementIncide = widthOfElements / 10 * 1;
                author.Size = new Size(widthOfElementIncide, element.Size.Height);
                author.Location = new Point(xPositionIncide, 0);
                author.BorderStyle = BorderStyle.FixedSingle;
                author.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Label time = new Label();
                time.Text = elements[num].time.ToString();
                widthOfElementIncide = widthOfElements / 10 * 1;
                time.Size = new Size(widthOfElementIncide, element.Size.Height);
                time.Location = new Point(xPositionIncide, 0);
                time.BorderStyle = BorderStyle.FixedSingle;
                time.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Label label = new Label();
                label.Text = elements[num].label;
                widthOfElementIncide = widthOfElements / 10 * 1;
                label.Size = new Size(widthOfElementIncide, element.Size.Height);
                label.Location = new Point(xPositionIncide, 0);
                label.BorderStyle = BorderStyle.FixedSingle;
                label.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Label content = new Label();
                content.Text = elements[num].content;
                widthOfElementIncide = widthOfElements / 10 * 7;
                content.Size = new Size(widthOfElementIncide, element.Size.Height);
                content.Location = new Point(xPositionIncide, 0);
                content.BorderStyle = BorderStyle.FixedSingle;
                content.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;


                element.Controls.Add(author);
                element.Controls.Add(time);
                element.Controls.Add(label);
                element.Controls.Add(content);

                yPosition += element.Size.Height + yMargin;
                mainBox.Controls.Add(element);

            }

        }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login_form());
        }
    }
}
