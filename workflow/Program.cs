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

    public static class Server
    {

        public static void getUser()
        {
            User.shedule = new List<string>() { "Русский", "Математика", "Информатика", "Русский", "Математика", "Информатика", "Русский" };
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

        public static Label getAddNewsButton(workflow.login_form connectForm)
        {
            Label add_news_button = new Label();

            add_news_button.Size = new Size(130, 19);
            add_news_button.BackColor = SystemColors.ControlLight;
            add_news_button.BorderStyle = BorderStyle.FixedSingle;
            add_news_button.Location = new Point(670, -1);
            add_news_button.TextAlign = ContentAlignment.MiddleCenter;
            add_news_button.Text = "Добавить новость";
            add_news_button.Cursor = Cursors.Hand;
            add_news_button.Click += new EventHandler(connectForm.a_add_news_button_click);

            return add_news_button;
        }

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
            connectForm.a_main_screen_main_box.Controls.Clear();
        }

        public static void changeMainScreenEnvironment(string environment, workflow.login_form connectForm)
        {

            cleanMainScreenEnvironment(connectForm);

            switch (environment)
            {
                case "main":

                    resetTopPanelButtonsColors(connectForm.a_main_screen_top_panel_button1_text, connectForm);

                    List<string> label = new List<string>() { "Расписание: " };
                    List<string> content = User.shedule;
                    List<string> filled = label.Concat(content).ToList();

                    Dictionary<int, ContentAlignment> properties = new Dictionary<int, ContentAlignment>(filled.Count());

                    properties.Add(0, ContentAlignment.MiddleCenter);

                    customBox.addElements(filled, properties, connectForm.a_main_screen_left_panel_custom_box);

                    if (User.getPrivilege("addNews"))
                    {
                        connectForm.a_main_screen_main_box.Controls.Add(helpToDraw.getAddNewsButton(connectForm));
                    }
                    

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
