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

    public static class User
    {

        public static void set_photo(string photo_src, workflow.login_form connectForm)
        {
            Console.WriteLine("----------- " + photo_src);
            Console.WriteLine("----------- " + @"C:\Users\User\Desktop\fakes\EGЭ.jpg");
            int width = (int)connectForm.a_main_screen_left_panel_picture_box.Size.Width;
            var height = (int)connectForm.a_main_screen_left_panel_picture_box.Size.Height;
            Bitmap original = new Bitmap(connectForm.a_change_image_dialog.FileName);
            connectForm.a_main_screen_left_panel_picture.Image = new Bitmap(original, width, height);
            //Server.update_user_photo();
        }

    }



    public class screenConstructor
    {

        public static void setBox(System.Windows.Forms.Panel box, workflow.login_form connectForm)
        {
            connectForm.a_main_screen_box.Visible = false;
            connectForm.a_sign_in_box.Visible = false;
            connectForm.a_sign_up_box.Visible = false;
            connectForm.a_forgot_password_box.Visible = false;
            box.Visible = true;
        }

        public static void setBox(System.Windows.Forms.GroupBox box, workflow.login_form connectForm)
        {
            connectForm.a_main_screen_box.Visible = false;
            connectForm.a_sign_in_box.Visible = false;
            connectForm.a_sign_up_box.Visible = false;
            connectForm.a_forgot_password_box.Visible = false;
            box.Visible = true;
        }

        public static void changeBoxes(System.Windows.Forms.Panel prevBox, System.Windows.Forms.GroupBox nextBox)
        {
            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void changeBoxes(System.Windows.Forms.Panel prevBox, System.Windows.Forms.Panel nextBox)
        {
            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void changeBoxes(System.Windows.Forms.GroupBox prevBox, System.Windows.Forms.GroupBox nextBox)
        {
            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void changeBoxes(System.Windows.Forms.GroupBox prevBox, System.Windows.Forms.Panel nextBox)
        {
            prevBox.Visible = false;
            nextBox.Visible = true;
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
