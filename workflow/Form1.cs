using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace workflow
{

    public partial class main_form : Form
    {

        public bool stopUpdatingMode = false;
        public string currentEnvironment;
        public string currentUnderEnvironment;
        static public UserClass User = new UserClass();

        //remember
        static public int systemScrollPosition;
        static public int maxPrevScrollValue;

        // / remember

        public main_form()
        {
            InitializeComponent();
        }

        public void formSetter()
        {
            using (FileStream fstream = File.OpenRead(System.IO.Path.Combine(Environment.CurrentDirectory, "safe.txt")))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine("Текст из файла: {0}", textFromFile);
                string[] userInfo = textFromFile.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                Server.getUser(userInfo[0], userInfo[1]);
                main_form.User.set_name(main_form.User.name, this);
            }

            screenConstructor.setBox(a_main_screen_box, this);

            Server.updateUsersConversations();
            a_main_screen_main_info_panel_text.Text = Server.getMainNews();

            if (User.getPrivilege("changeMainNews"))
            {
                a_main_screen_main_info_panel_change_button.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(File.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "safe.txt")))
            {
                formSetter();

                this.a_main_screen_left_panel_time.Text = DateTime.Now.ToString("h:mm:ss tt"); //Обновляем значение времени
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer2.Interval = (1 * 1000); // 1 secs
                timer2.Tick += new EventHandler(timer_Tick);
                timer2.Start();

                timer1.Interval = (1 * 1000);
                timer1.Tick += new EventHandler(updateFormByServer);
                timer1.Start();
            }
            else
            {
                screenConstructor.setBox(a_sign_in_box, this);
            }
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

                formSetter();

                this.a_main_screen_left_panel_time.Text = DateTime.Now.ToString("h:mm:ss tt"); //Обновляем значение времени
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer2.Interval = (1 * 1000); // 10 secs
                timer2.Tick += new EventHandler(timer_Tick);
                timer2.Start();

                timer1.Interval = (1 * 1000);
                timer1.Tick += new EventHandler(updateFormByServer);
                timer1.Start();

                screenConstructor.changeBoxes(this.a_sign_in_box, this.a_main_screen_box, this);
            }
            else
            {
                this.a_sign_in_info_box.ForeColor = Color.Red;

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
            screenConstructor.changeBoxes(this.a_sign_in_box, this.a_sign_up_box, this);
        }

        private void a_sign_in_page_button_Click(object sender, EventArgs e)
        {
            screenConstructor.changeBoxes(this.a_sign_up_box, this.a_sign_in_box, this);
        }

        private void a_sign_up_button_Click(object sender, EventArgs e)
        {
            string login = this.a_sign_up_login_text_box.Text;
            string password = this.a_sign_up_password_text_box.Text;

            if(Server.new_user(login, password).Item1)
            {
                this.a_sign_up_info_box.Text = ""; //Убираем окно ошибки
                Console.WriteLine("sign up > " + "password : " + password + " login : " + login);
                screenConstructor.changeBoxes(this.a_sign_up_box, this.a_sign_in_box, this);
                a_sign_in_info_box.ForeColor = Color.Green;
                a_sign_in_info_box.Text = "Вы успешно зарегистрированы. Войдите в систему с новыми данными";
            }
            else
            {
                a_sign_up_info_box.ForeColor = Color.Red;
                this.a_sign_up_info_box.Text = Server.new_user(login, password).Item2;
            }
        }

        private void a_sign_in_forgot_password_button_Click(object sender, EventArgs e)
        {
            this.a_sign_in_forgot_password_button.Visible = false; //Убираем кнопку 'забыли пароль'
            this.a_sign_in_info_box.Text = ""; //Убираем окно ошибки
            screenConstructor.changeBoxes(this.a_sign_in_box, this.a_forgot_password_box, this);
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
                screenConstructor.changeBoxes(this.a_forgot_password_box, this.a_sign_in_box, this);
            }
            else
            {
                this.a_forgot_password_info_box.Text = Server.refresh_password(login).Item2;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.a_main_screen_left_panel_time.Text = DateTime.Now.ToString("H:mm:ss tt");
        }

        private void a_main_screen_main_info_panel_text_Click(object sender, EventArgs e)
        {

        }

        private void a_change_image_set(object sender, CancelEventArgs e)
        {
            stopUpdatingMode = false;
            Console.WriteLine("Image set by user : " + this.a_change_image_dialog.FileName);
            User.set_photo(this.a_change_image_dialog.FileName, this);
        }

        private void a_image_changed_by_user(object sender, EventArgs e)
        {
            this.a_change_image_dialog.ShowDialog();
        }

        private void a_show_change_photo_label(object sender, EventArgs e)
        {
            this.a_main_screen_left_panel_change_image_label.Visible = true;
        }

        private void a_hide_change_photo_label(object sender, EventArgs e)
        {
            this.a_main_screen_left_panel_change_image_label.Visible = false;
        }

        private void a_main_screen_top_panel_button1_Click(object sender, MouseEventArgs e)
        {
            screenConstructor.changeMainScreenEnvironment("main", this);
        }

        private void a_main_screen_top_panel_button2_Click(object sender, MouseEventArgs e)
        {
            screenConstructor.changeMainScreenEnvironment("documents", this);
        }

        private void a_main_screen_top_panel_button3_Click(object sender, MouseEventArgs e)
        {
            screenConstructor.changeMainScreenEnvironment("chats", this);
        }

        public void a_add_news_button_click(object sender, EventArgs e)
        {
            stopUpdatingMode = true;
            Console.WriteLine("Add news");
            a_main_screen_main_box_add_news_panel_info_label.Text = "";
            a_main_screen_main_box_add_news_panel_news_content_text_box.Text = "";
            a_main_screen_main_box_add_news_panel_news_label_text_box.Text = "";
            a_main_screen_main_box_add_news_panel.Visible = true;
            a_dark_background.Visible = true;
        }

        private void a_publish_news(object sender, EventArgs e)
        {
            string label_of_news = a_main_screen_main_box_add_news_panel_news_label_text_box.Text;
            string content_of_news = a_main_screen_main_box_add_news_panel_news_content_text_box.Text;

            if(label_of_news != "" && content_of_news != "")
            {
                Server.addNews(label_of_news, content_of_news);

                a_main_screen_main_box_add_news_panel_info_label.ForeColor = Color.Green;
                a_main_screen_main_box_add_news_panel_info_label.Text = "Успешно опубликовано";
                
                a_main_screen_main_box_add_news_panel_news_content_text_box.Text = ""; //Сбрасываем text и label чтобы пользователь понял, что новость опубликована
                a_main_screen_main_box_add_news_panel_news_label_text_box.Text = "";
            }
            else
            {
                a_main_screen_main_box_add_news_panel_info_label.ForeColor = Color.Red;
                a_main_screen_main_box_add_news_panel_info_label.Text = "Проверьте правильность введенных данных";
            }
        }

        private void a_exit_add_news_panel(object sender, EventArgs e)
        {
            a_main_screen_main_box_add_news_panel.Visible = false;
            a_dark_background.Visible = false;
            stopUpdatingMode = false;
        }

        public void a_deleteNews_button_click(object sender, EventArgs e)
        {
            Button senderButton = sender as Button;
            string news = senderButton.Tag.ToString();

            Server.deleteNews(news);
        }

        private void a_change_main_news_button_click(object sender, EventArgs e)
        {
            stopUpdatingMode = true;
            a_main_screen_main_box_change_news_panel.Visible = true;
            a_dark_background.Visible = true;
            a_main_screen_main_box_change_news_panel_news_content_text_box.Text = a_main_screen_main_info_panel_text.Text;
        }

        private void a_exit_change_news_panel(object sender, EventArgs e)
        {
            stopUpdatingMode = false;
            a_dark_background.Visible = false;
            a_main_screen_main_box_change_news_panel.Visible = false;
        }

        private void a_change_news(object sender, EventArgs e)
        {
            string content_of_news = a_main_screen_main_box_change_news_panel_news_content_text_box.Text;
            Server.changeMainNews(content_of_news);
            a_main_screen_main_box_change_news_panel.Visible = false;
            a_dark_background.Visible = false;
        }

        public void a_documents_left_panel_button_click(object sender, EventArgs e)
        {
            Label senderLabel = sender as Label;
            string senderButton = senderLabel.Tag.ToString();

            screenConstructor.setDocumentsMainScreenVersion(senderButton, this);
        }

        public void a_readDocument_button_click(object sender, EventArgs e)
        {

            Button senderButton = sender as Button;
            string document = senderButton.Tag.ToString();

            Server.downloadDocument(document);
        }

        private void a_exit_add_file_panel(object sender, EventArgs e)
        {
            stopUpdatingMode = false;
            a_main_screen_main_box_add_file_panel.Visible = false;
            a_dark_background.Visible = false;
        }

        private void a_image_changed_by_user(object sender, MouseEventArgs e)
        {
            this.a_change_image_dialog.ShowDialog();
        }

        private void a_file_select_by_user(object sender, EventArgs e)
        {
            this.a_send_file_dialog.ShowDialog();
        }

        private void a_send_file(object sender, EventArgs e)
        {
            string fileLabel = a_main_screen_main_box_add_file_panel_label_text_box.Text;
            string fileName = a_send_file_dialog.FileName;

            if (fileName.Split('.').Length > 2)
            {
                a_main_screen_main_box_add_file_panel_info_label.ForeColor = Color.Red;
                a_main_screen_main_box_add_file_panel_info_label.Text = "Нельзя отправлять на сервер файлы, в имени которых содержатся точки";
                return;
            }

            char[] forbittenSymbols = { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };

            if (fileLabel.IndexOfAny(forbittenSymbols) != -1){
                a_main_screen_main_box_add_file_panel_info_label.ForeColor = Color.Red;
                a_main_screen_main_box_add_file_panel_info_label.Text = "Нельзя отправлять на сервер файлы, c именем, содержащим спец. символы";
                return;
            }

            if(fileLabel != "" && fileName != "a_selected_file")
            {

                Dictionary<string, bool> recipients = new Dictionary<string, bool>();

                foreach (var item in a_main_screen_main_box_add_file_panel_recipients_list_box.SelectedItems)
                {
                    recipients.Add(item.ToString(), false);
                }

                Server.sendFile(fileLabel, fileName, recipients);

                a_main_screen_main_box_add_file_panel_info_label.ForeColor = Color.Green;
                a_main_screen_main_box_add_file_panel_info_label.Text = "Успешно отправлено";
            }
            else
            {
                a_main_screen_main_box_add_file_panel_info_label.ForeColor = Color.Red;
                a_main_screen_main_box_add_file_panel_info_label.Text = "Проверьте правильность введенных данных";
            }
            
        }

        private void a_select_file_set(object sender, CancelEventArgs e)
        {
            a_main_screen_main_box_add_file_panel_file_name_label.Text = a_send_file_dialog.SafeFileName;
        }

        public void a_downloadTemplate_button_click(object sender, EventArgs e)
        {
            Button senderButton = sender as Button;
            string template = senderButton.Tag.ToString();

            Server.downloadTemplate(template);
        }

        private void a_add_template_button_click(object sender, EventArgs e)
        {
            stopUpdatingMode = true;
            a_main_screen_main_box_add_template_panel_info_label.Text = "";
            a_main_screen_main_box_add_template_panel_name_text_box.Text = "";
            a_main_screen_main_box_add_template_panel_file_name_label.Text = "";

            a_main_screen_main_box_add_template_panel.Visible = true;
            a_dark_background.Visible = true;
        }

        private void a_exit_add_template_panel(object sender, EventArgs e)
        {
            stopUpdatingMode = false;
            a_main_screen_main_box_add_template_panel.Visible = false;
            a_dark_background.Visible = false;
        }

        private void a_select_template_set(object sender, CancelEventArgs e)
        {
            a_main_screen_main_box_add_template_panel_file_name_label.Text = a_send_template_dialog.SafeFileName;
        }

        private void a_send_template(object sender, EventArgs e)
        {
            string templateLabel = a_main_screen_main_box_add_template_panel_name_text_box.Text;
            string templateName = a_send_template_dialog.FileName;

            if (templateName.Split('.').Length > 2)
            {
                a_main_screen_main_box_add_template_panel_info_label.ForeColor = Color.Red;
                a_main_screen_main_box_add_template_panel_info_label.Text = "Нельзя отправлять на сервер файлы, в имени которых содержатся точки";
                return;
            }

            char[] forbittenSymbols = { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };

            if (templateLabel.IndexOfAny(forbittenSymbols) != -1)
            {
                a_main_screen_main_box_add_template_panel_info_label.ForeColor = Color.Red;
                a_main_screen_main_box_add_template_panel_info_label.Text = "Нельзя отправлять на сервер файлы, c именем, содержащим спец. символы";
                return;
            }

            if (templateLabel != "" && templateName != "a_selected_file")
            {

                Server.addTemplate(templateLabel, templateName);

                a_main_screen_main_box_add_template_panel_info_label.ForeColor = Color.Green;
                a_main_screen_main_box_add_template_panel_info_label.Text = "Успешно отправлено";

                a_main_screen_main_box_add_template_panel_name_text_box.Text = "";
                a_main_screen_main_box_add_template_panel_file_name_label.Text = "";
            }
            else
            {
                a_main_screen_main_box_add_template_panel_info_label.ForeColor = Color.Red;
                a_main_screen_main_box_add_template_panel_info_label.Text = "Проверьте правильность введенных данных";
            }
        }

        private void a_template_select_by_user(object sender, EventArgs e)
        {
            this.a_send_template_dialog.ShowDialog();
        }

        public void a_deleteTemplate_button_click(object sender, EventArgs e)
        {
            Button senderButton = sender as Button;
            string template = senderButton.Tag.ToString();

            Server.deleteTemplate(template);

        }

        public void a_chats_left_panel_button_click(object sender, EventArgs e)
        {
            Label senderLabel = sender as Label;
            string senderButton = senderLabel.Tag.ToString();

            screenConstructor.setChatsMainScreenVersion(senderButton, this, true);
        }

        private void chats_mode_send_button_click(object sender, EventArgs e)
        {
            string text = a_main_screen_main_box_chats_mode_interface_panel_text_box.Text;
            a_main_screen_main_box_chats_mode_interface_panel_text_box.Text = "";
            Server.sendMessage(text);
            updateFormByServer(null, null);
            stopUpdatingMode = false;
        }

        public void conversation_options_open(object sender, EventArgs e)
        {
            stopUpdatingMode = true;
            Label senderLabel = sender as Label;
            a_conversation_options_panel.Visible = true;
            a_conversation_options_panel.BringToFront();
            a_conversation_options_panel_name_text_box.Text = senderLabel.Text;

            a_conversation_options_panel_add_users_list_box.Items.Clear();

            foreach (string name in Server.getAllUsers())
            {
                a_conversation_options_panel_add_users_list_box.Items.Add(name);
            }

            Console.WriteLine("Conversation options");
        }

        private void a_conversation_options_panel_exit(object sender, EventArgs e)
        {
            stopUpdatingMode = false;
            a_conversation_options_panel.Visible = false;
        }

        private void a_conversation_options_panel_save_new_options(object sender, EventArgs e)
        {
            string newName = a_conversation_options_panel_name_text_box.Text;
            Server.updateConversationName(newName, User.currentConversationId);

            foreach (var item in a_conversation_options_panel_add_users_list_box.SelectedItems)
            {
                Server.addUserToConversation(item.ToString(), User.currentConversationId);
            }

            a_conversation_options_panel.Visible = false;
            stopUpdatingMode = false;
        }

        private void a_conversation_options_panel_leave_conversation(object sender, EventArgs e)
        {
            stopUpdatingMode = false;
            Server.leaveConversation(User.currentConversationId);
            Server.updateUsersConversations();

            if (User.conversations.Count > 0) User.currentConversationId = User.conversations[0].id.ToString();

            a_conversation_options_panel.Visible = false;
        }

        public void a_chats_left_panel_add_chat_button_click(object sender, EventArgs e)
        {
            Server.addNewChat();
            Server.updateUsersConversations();
            if (User.conversations.Count > 0) User.currentConversationId = User.conversations[0].id.ToString();
        }

        public void updateFormByServer(object sender, EventArgs e)
        {
            if (Server.getUpdatesExistence())
            {
                Console.WriteLine("updateFormByServer");
                a_main_screen_main_info_panel_text.Text = Server.getMainNews();

                screenConstructor.changeMainScreenEnvironment(currentEnvironment, this, currentUnderEnvironment);
            }
            else
            {
                Console.WriteLine("noUpdates");
            }
        }

        private void a_chats_mode_message_writing(object sender, EventArgs e)
        {
           // stopUpdatingMode = true;
        }

        private void a_chats_mode_message_stop_writing(object sender, EventArgs e)
        {
            // stopUpdatingMode = false;
        }

        private void exit_from_global_user(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            screenConstructor.setBox(a_sign_in_box, this);

            File.Delete(System.IO.Path.Combine(Environment.CurrentDirectory, "safe.txt"));
        }
    }
}
