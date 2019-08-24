using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workflow
{

    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.a_main_screen_left_panel_time.Text = DateTime.Now.ToString("h:mm:ss tt"); //Обновляем значение времени
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (1 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void a_sign_in_button_Click(object sender, EventArgs e)
        {
            string password = this.a_sign_in_password_text_box.Text;
            string login = this.a_sign_in_login_text_box.Text;

            if(Server.check_user_enter(login, password).Item1 == true)
            {
                this.a_sign_in_forgot_password_button.Visible = false; //Убираем кнопку 'забыли пароль'
                this.a_sign_in_info_box.Text = ""; //Убираем окно ошибки
                Console.WriteLine("sign in > " + "password : " + password + " login : " + login);
            }
            else
            {
                this.a_sign_in_info_box.Text = Server.check_user_enter(login, password).Item2;
                this.a_sign_in_forgot_password_button.Visible = true;
            }
        }

        private void a_password_text_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void a_login_text_box_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void a_sign_up_page_button_Click(object sender, EventArgs e)
        {
            screenConstructor.changeBoxes(this.a_sign_in_box, this.a_sign_up_box);
        }

        private void a_sign_in_page_button_Click(object sender, EventArgs e)
        {
            screenConstructor.changeBoxes(this.a_sign_up_box, this.a_sign_in_box);
        }

        private void a_sign_up_button_Click(object sender, EventArgs e)
        {
            string login = this.a_sign_up_login_text_box.Text;
            string password = this.a_sign_up_password_text_box.Text;

            if(Server.new_user(login, password).Item1)
            {
                this.a_sign_up_info_box.Text = ""; //Убираем окно ошибки
                Console.WriteLine("sign up > " + "password : " + password + " login : " + login);
            }
            else
            {
                this.a_sign_up_info_box.Text = Server.new_user(login, password).Item2;
                screenConstructor.changeBoxes(this.a_sign_up_box, this.a_main_screen_box);
            }
        }

        private void a_sign_in_forgot_password_button_Click(object sender, EventArgs e)
        {
            this.a_sign_in_forgot_password_button.Visible = false; //Убираем кнопку 'забыли пароль'
            this.a_sign_in_info_box.Text = ""; //Убираем окно ошибки
            screenConstructor.changeBoxes(this.a_sign_in_box, this.a_forgot_password_box);
        }

        private void a_main_screen_left_panel_name_Click(object sender, EventArgs e)
        {

        }

        private void a_main_screen_top_panel_button1_text_Click(object sender, EventArgs e)
        {
            
        }




        private void a_forgot_password_send_button_Click(object sender, EventArgs e)
        {
            string login = this.a_forgot_password_login_text_box.Text;

            if (Server.refresh_password(login).Item1)
            {
                this.a_forgot_password_info_box.Text = ""; //Убираем окно ошибки
                screenConstructor.changeBoxes(this.a_forgot_password_box, this.a_sign_in_box);
            }
            else
            {
                this.a_forgot_password_info_box.Text = Server.refresh_password(login).Item2;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.a_main_screen_left_panel_time.Text = DateTime.Now.ToString("h:mm:ss tt");
        }
    }
}
