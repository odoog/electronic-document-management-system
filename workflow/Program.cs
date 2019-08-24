using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workflow
{

    public static class Server
    {
        public static Tuple<bool, string> check_user_enter(string login, string password)
        {
            if (login != "root" && password != "root")
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

    public class screenConstructor
    {
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
