﻿using System;
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
        public int id;

        public News(string _author, string _label, string _content, string _time, int _id)
        {
            this.author = _author;
            this.label = _label;
            this.content = _content;
            this.time = _time;
            this.id = _id;
        }

    }

    public class Documents
    {
        public string read;
        public string author;
        public string label;
        public int id;

        public Documents(string _read, string _author, string _label, int _id)
        {
            this.read = _read;
            this.author = _author;
            this.label = _label;
            this.id = _id;
        }
    }

    public class Templates
    {
        public string author;
        public string name;
        public int id;

        public Templates(string _author, string _name, int _id)
        {
            this.author = _author;
            this.name = _name;
            this.id = _id;
        }
    }

    public static class Server
    {

        public static List<string> getAllUsers()
        {
            return new List<string>() { "Иванов И.И.", "Андропов И.К.", "Зарубин М.Ф.", "Добролюбов М.З.", "Панин М.И.", "Алексеев С.С." };
        }

        public static void downloadDocument(string document)
        {
            Console.WriteLine("Download document " + document);
        }

        public static void downloadTemplate(string template)
        {
            Console.WriteLine("Download template " + template);
        }

        public static void sendFile(string label, string path, string recipient)
        {
            Console.WriteLine("Send file " + path + "(" + label + ")" + " to " + recipient);
        }

        public static void addTemplate(string name, string path)
        {
            Console.WriteLine("Add template " + name + " (" + path + ")");
        }

        public static void getUser()
        {
            User.shedule = new List<string>() { "Русский", "Математика", "Информатика", "Русский", "Математика", "Информатика", "Русский" };
            User.name = "Иванов И.И";
        }

        public static void addNews(string labelOfNews, string contentOfNews)
        {
            Console.WriteLine("Add news : " + labelOfNews + " : " + contentOfNews);
        }

        public static void changeMainNews(string contentOfNews)
        {
            Console.WriteLine("Change news : " + contentOfNews);
        }

        public static void deleteNews(string newsId)
        {

            Console.WriteLine("Delete news : " + newsId);
        }

        public static void deleteTemplate(string templateId)
        {
            Console.WriteLine("Delete template : " + templateId);
        }

        public static List<News> getNews()
        {

            List<News> contentMain = new List<News>();

            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 1));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 2));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 3));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 4));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 5));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 6));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 7));
            contentMain.Add(new News("Фролов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 8));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 9));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 10));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 11));
            contentMain.Add(new News("Иванова И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 12));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 13));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 14));
            contentMain.Add(new News("Антонов К.А", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 15));
            contentMain.Add(new News("Иванов И.И", "Кому на руси жить хорошо", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation", DateTime.Now.ToString(), 16));

            return contentMain;
        }

        public static List<Documents> getDocuments()
        {
            List<Documents> contentMain = new List<Documents>();

            contentMain.Add(new Documents("Новое", "Иванов И.И", "Справка о посещаемости", 1));
            contentMain.Add(new Documents("Новое", "Иванов И.И", "Справка о посещаемости", 2));
            contentMain.Add(new Documents("Новое", "Иванов И.И", "Справка о посещаемости", 3));
            contentMain.Add(new Documents("Новое", "Иванов И.И", "Справка о посещаемости", 4));
            contentMain.Add(new Documents("Новое", "Иванов И.И", "Справка о посещаемости", 5));
            contentMain.Add(new Documents("Новое", "Иванов И.И", "Справка о посещаемости", 6));
            contentMain.Add(new Documents("Новое", "Иванов И.И", "Справка о посещаемости", 7));
            contentMain.Add(new Documents("Новое", "Иванов И.И", "Справка о посещаемости", 8));
            contentMain.Add(new Documents("Новое", "Иванов И.И", "Справка о посещаемости", 9));
            contentMain.Add(new Documents("Новое", "Иванов И.И", "Справка о посещаемости", 10));

            return contentMain;
        }

        public static List<Templates> getTemplates()
        {
            List<Templates> contentMain = new List<Templates>();

            contentMain.Add(new Templates("Иванов И.И", "Шаблон заполнения ИРЗ", 1));
            contentMain.Add(new Templates("Иванов И.И", "Шаблон заполнения ИРЗ", 2));
            contentMain.Add(new Templates("Иванов И.И", "Шаблон заполнения ИРЗ", 3));
            contentMain.Add(new Templates("Иванов И.И", "Шаблон заполнения ИРЗ", 4));
            contentMain.Add(new Templates("Иванов И.И", "Шаблон заполнения ИРЗ", 5));
            contentMain.Add(new Templates("Петров И.И", "Шаблон заполнения ИРЗ", 6));
            contentMain.Add(new Templates("Иванов И.И", "Шаблон заполнения ИРЗ", 7));
            contentMain.Add(new Templates("Петров И.И", "Шаблон заполнения ИРЗ", 8));
            contentMain.Add(new Templates("Петров И.И", "Шаблон заполнения ИРЗ", 9));
            contentMain.Add(new Templates("Иванов И.И", "Шаблон заполнения ИРЗ", 10));
            contentMain.Add(new Templates("Иванов И.И", "Шаблон заполнения ИРЗ", 11));
            contentMain.Add(new Templates("Иванов И.И", "Шаблон заполнения ИРЗ", 12));

            return contentMain;
        }

        public static string getMainNews()
        {
            return "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
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
        static public Dictionary<string, Label> systemData; //Хранятся указатели на DocumentsLeftPanelButtons

        static public List<string> shedule;
        static public string name;


        static public void set_photo(string photo_src, workflow.main_form connectForm)
        {
            int width = (int)connectForm.a_main_screen_left_panel_picture_box.Size.Width;
            var height = (int)connectForm.a_main_screen_left_panel_picture_box.Size.Height;
            Bitmap original = new Bitmap(connectForm.a_change_image_dialog.FileName);
            connectForm.a_main_screen_left_panel_picture.Image = new Bitmap(original, width, height);
            //Server.update_user_photo();
        }

        static public void set_name(string name, workflow.main_form connectForm)
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

        public static void setDocumentsMainScreenVersion(string senderButton, workflow.main_form connectForm)
        {
            cleanMainScreenEnvironment(connectForm, false);

            resetDocumentsLeftPanelButtonsColors(senderButton, connectForm);

            switch (senderButton)
            {
                case "a_incoming_messages_button":

                    List<Documents> labelDocuments = new List<Documents>() { new Documents("Cтатус", "Автор", "Тема", 0) };
                    List<Documents> contentDocuments = Server.getDocuments();
                    List<Documents> filledDocuments = labelDocuments.Concat(contentDocuments).ToList();

                    Dictionary<int, Color> propertiesDocuments = new Dictionary<int, Color>(filledDocuments.Count());

                    propertiesDocuments.Add(0, SystemColors.ControlLight);

                    mainBox.addElementsDocuments(filledDocuments, propertiesDocuments, connectForm.a_main_screen_main_box, connectForm);

                    break;

                case "a_send_message_button":

                    connectForm.a_main_screen_main_box_add_file_panel_info_label.Text = "";
                    connectForm.a_main_screen_main_box_add_file_panel_label_text_box.Text = "";
                    connectForm.a_main_screen_main_box_add_file_panel_file_name_label.Text = "";

                    connectForm.a_main_screen_main_box_add_file_panel_recipients_list_box.Items.Clear();

                    foreach(string name in Server.getAllUsers())
                    {
                        connectForm.a_main_screen_main_box_add_file_panel_recipients_list_box.Items.Add(name);
                    }

                    connectForm.a_main_screen_main_box_add_file_panel.Visible = true;

                    break;

                case "a_document_templates_button":

                    if (User.getPrivilege("addTemplates"))
                    {
                        connectForm.a_main_screen_main_box_add_template_button.Visible = true;
                    }

                    List<Templates> labelTemplates = new List<Templates>() { new Templates("Автор", "Название", 0) };
                    List<Templates> contentTemplates = Server.getTemplates();
                    List<Templates> filledTemplates = labelTemplates.Concat(contentTemplates).ToList();

                    Dictionary<int, Color> propertiesTemplates = new Dictionary<int, Color>(filledTemplates.Count());

                    propertiesTemplates.Add(0, SystemColors.ControlLight);

                    mainBox.addElementsTemplates(filledTemplates, propertiesTemplates, connectForm.a_main_screen_main_box, connectForm);

                    break;
            }
        }

        public static void setBox(Panel box, workflow.main_form connectForm)
        {

            if (box == connectForm.a_main_screen_box)
            {
                screenConstructor.changeMainScreenEnvironment("main", connectForm);
            }

            connectForm.a_main_screen_box.Visible = false;
            connectForm.a_sign_in_box.Visible = false;
            connectForm.a_sign_up_box.Visible = false;
            connectForm.a_forgot_password_box.Visible = false;
            box.Visible = true;
        }

        public static void setBox(GroupBox box, workflow.main_form connectForm)
        {

            connectForm.a_main_screen_box.Visible = false;
            connectForm.a_sign_in_box.Visible = false;
            connectForm.a_sign_up_box.Visible = false;
            connectForm.a_forgot_password_box.Visible = false;
            box.Visible = true;
        }

        public static void changeBoxes(Panel prevBox, GroupBox nextBox, workflow.main_form connectForm)
        {
            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void changeBoxes(Panel prevBox, Panel nextBox, workflow.main_form connectForm)
        {
            if (nextBox == connectForm.a_main_screen_box)
            {
                screenConstructor.changeMainScreenEnvironment("main", connectForm);
            }

            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void changeBoxes(GroupBox prevBox, GroupBox nextBox, workflow.main_form connectForm)
        {
            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void changeBoxes(GroupBox prevBox, Panel nextBox, workflow.main_form connectForm)
        {

            if (nextBox == connectForm.a_main_screen_box)
            {
                screenConstructor.changeMainScreenEnvironment("main", connectForm);
            }

            prevBox.Visible = false;
            nextBox.Visible = true;
        }

        public static void resetTopPanelButtonsColors(Label labelToSetActive, workflow.main_form connectForm)
        {
            connectForm.a_main_screen_top_panel_button1_text.ForeColor = System.Drawing.Color.Black;
            connectForm.a_main_screen_top_panel_button2_text.ForeColor = System.Drawing.Color.Black;
            connectForm.a_main_screen_top_panel_button3_text.ForeColor = System.Drawing.Color.Black;

            labelToSetActive.ForeColor = System.Drawing.Color.Red;
        }

        public static void resetDocumentsLeftPanelButtonsColors(string labelToSetActive, workflow.main_form connectForm)
        {
            User.systemData["a_send_message_button"].ForeColor = System.Drawing.Color.Black;
            User.systemData["a_incoming_messages_button"].ForeColor = System.Drawing.Color.Black;
            User.systemData["a_document_templates_button"].ForeColor = System.Drawing.Color.Black;

            User.systemData[labelToSetActive].ForeColor = System.Drawing.Color.Red;
        }

        public static void cleanMainScreenEnvironment(workflow.main_form connectForm, bool clearLeft = true)
        {
            if(clearLeft) connectForm.a_main_screen_left_panel_custom_box.Controls.Clear();

            connectForm.a_main_screen_main_box.AutoScrollPosition = new Point(0, 0);

            Panel a_main_screen_main_box_add_template_panel = connectForm.a_main_screen_main_box_add_template_panel; //Сохраняем панель 'Добавить шаблон'
            Panel a_main_screen_main_box_add_file_panel = connectForm.a_main_screen_main_box_add_file_panel; //Сохраняем панель 'Добавить файл'
            Panel a_main_screen_main_box_change_news_panel = connectForm.a_main_screen_main_box_change_news_panel; //Cохраняем панель 'Изменить новость'
            Panel a_main_screen_main_box_add_news_panel = connectForm.a_main_screen_main_box_add_news_panel;  //Cохраняем панель 'Добавить новость'
            Panel a_main_screen_main_box_add_news_button = connectForm.a_main_screen_main_box_add_news_button; //Cохраняем кнопку 'Добавить новость'
            Panel a_main_screen_main_box_add_template_button = connectForm.a_main_screen_main_box_add_template_button; //Сохраняем кнопку 'Добавить шаблон'

            connectForm.a_main_screen_main_box.Controls.Clear();

            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_template_panel); //Возвращаем панель 'Добавить шаблон'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_file_panel); //Возвращаем панель 'Добавить файл'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_change_news_panel); //Возвращаем панель 'Изменить новость'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_news_panel); //Возвращаем панель 'Добавить новость'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_news_button); //Возвращаем кнопку 'Добавить новость'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_template_button); //Возвращаем кнопку 'Добавить шаблон'

            connectForm.a_main_screen_main_box_add_template_panel.Visible = false;
            connectForm.a_main_screen_main_box_add_file_panel.Visible = false;
            connectForm.a_main_screen_main_box_change_news_panel.Visible = false;
            connectForm.a_main_screen_main_box_add_news_panel.Visible = false;
            connectForm.a_main_screen_main_box_add_news_button.Visible = false;
            connectForm.a_main_screen_main_box_add_template_button.Visible = false;
        }

        public static void changeMainScreenEnvironment(string environment, workflow.main_form connectForm)
        {

            cleanMainScreenEnvironment(connectForm);

            switch (environment)
            {
                case "main":

                    resetTopPanelButtonsColors(connectForm.a_main_screen_top_panel_button1_text, connectForm);

                    //--------------------------- left screen changes

                    List<string> labelLeftMain = new List<string>() { "Расписание: " };
                    List<string> contentLeftMain = User.shedule;
                    List<string> filledLeftMain = labelLeftMain.Concat(contentLeftMain).ToList();

                    Dictionary<int, ContentAlignment> propertiesLeftMain = new Dictionary<int, ContentAlignment>(filledLeftMain.Count());

                    propertiesLeftMain.Add(0, ContentAlignment.MiddleCenter);

                    customBox.addElements(filledLeftMain, propertiesLeftMain, connectForm.a_main_screen_left_panel_custom_box, connectForm, environment);

                    if (User.getPrivilege("addNews"))
                    {
                        connectForm.a_main_screen_main_box_add_news_button.Visible = true;
                    }

                    //--------------------------- main screen changes

                    List<News> labelMain = new List<News>() { new News("Автор", "Тема", "Cодержание", "Время публикации", 0) };
                    List<News> contentMain = Server.getNews();
                    List<News> filledMain = labelMain.Concat(contentMain).ToList();

                    Dictionary<int, Color> propertiesMain = new Dictionary<int, Color>(filledLeftMain.Count());

                    propertiesMain.Add(0, SystemColors.ControlLight);

                    mainBox.addElementsMain(filledMain, propertiesMain, connectForm.a_main_screen_main_box, connectForm);

                    Console.WriteLine("Change environment : main");
                    break;

                case "documents":

                    User.systemData.Clear(); //Очищаем указатели на кнопки с прошлой сессии

                    resetTopPanelButtonsColors(connectForm.a_main_screen_top_panel_button2_text, connectForm);

                    //--------------------------- left screen changes

                    List<string> filledLeftDocuments = new List<string>() { "Отправить документ", "Входящие документы", "Шаблоны документов" };
                    List<string> filledLeftDocumentsNames = new List<string>() { "a_send_message_button", "a_incoming_messages_button", "a_document_templates_button" };

                    Dictionary<int, ContentAlignment> propertiesLeftDocuments = new Dictionary<int, ContentAlignment>(filledLeftDocuments.Count());

                    propertiesLeftDocuments.Add(0, ContentAlignment.MiddleCenter);
                    propertiesLeftDocuments.Add(1, ContentAlignment.MiddleCenter);
                    propertiesLeftDocuments.Add(2, ContentAlignment.MiddleCenter);

                    customBox.addElements(filledLeftDocuments, propertiesLeftDocuments, connectForm.a_main_screen_left_panel_custom_box, connectForm, environment, filledLeftDocumentsNames);

                    //--------------------------- main screen changes

                    screenConstructor.setDocumentsMainScreenVersion("a_incoming_messages_button", connectForm);

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

        public static void addElements(List<string> elements, Dictionary<int, ContentAlignment> properties, Panel customBox, workflow.main_form connectForm , string environment, List<string> customNames = null)
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
                labelOnElement.Font = new Font("Microsoft San Serif", 8);

                if (environment == "documents")
                {
                    labelOnElement.Tag = customNames[num];
                    labelOnElement.Cursor = Cursors.Hand;
                    labelOnElement.Click += new EventHandler(connectForm.a_documents_left_panel_button_click);
                    User.systemData.Add(customNames[num], labelOnElement);
                }

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
        public static void addElementsMain(List<News> elements, Dictionary<int, Color> properties, Panel mainBox, workflow.main_form connectForm)
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
            int heightOfElementIncide = 0;

            
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
                heightOfElementIncide = element.Size.Height;
                author.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                author.Location = new Point(xPositionIncide, 0);
                author.BorderStyle = BorderStyle.FixedSingle;
                author.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Label time = new Label();
                time.Text = elements[num].time.ToString();
                widthOfElementIncide = widthOfElements / 10 * 1;
                heightOfElementIncide = element.Size.Height;
                time.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                time.Location = new Point(xPositionIncide, 0);
                time.BorderStyle = BorderStyle.FixedSingle;
                time.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Label label = new Label();
                label.Text = elements[num].label;
                widthOfElementIncide = widthOfElements / 10 * 1;
                heightOfElementIncide = element.Size.Height;
                label.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                label.Location = new Point(xPositionIncide, 0);
                label.BorderStyle = BorderStyle.FixedSingle;
                label.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Label content = new Label();
                Panel buttonBox = new Panel();
                Button deleteNews = new Button();

                if (User.name == elements[num].author)
                {
                    //Добавляем content

                    content.Text = elements[num].content;
                    widthOfElementIncide = widthOfElements / 10 * 6;
                    heightOfElementIncide = element.Size.Height;
                    content.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    content.Location = new Point(xPositionIncide, 0);
                    content.BorderStyle = BorderStyle.FixedSingle;
                    content.TextAlign = ContentAlignment.MiddleCenter;
                    xPositionIncide += widthOfElementIncide - 1;

                    //Добавляем панель для кнопки удаления

                    widthOfElementIncide = widthOfElements / 10 * 1 + 1;
                    heightOfElementIncide = element.Size.Height;
                    buttonBox.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    buttonBox.Location = new Point(xPositionIncide, 0);
                    buttonBox.BorderStyle = BorderStyle.FixedSingle;
                    xPositionIncide += widthOfElementIncide - 1;

                    //Добавляем кнопку удаления

                    deleteNews.FlatStyle = FlatStyle.Flat;
                    deleteNews.Text = "x";
                    widthOfElementIncide = 22;
                    heightOfElementIncide = 22;
                    deleteNews.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    deleteNews.Location = new Point(buttonBox.Size.Width / 2 - widthOfElementIncide / 2, element.Size.Height / 2 - heightOfElementIncide / 2);
                    deleteNews.Tag = elements[num].id;
                    deleteNews.Cursor = Cursors.Hand;
                    deleteNews.BackColor = SystemColors.ControlLight;

                    deleteNews.Click += new EventHandler(connectForm.a_deleteNews_button_click);

                    buttonBox.Controls.Add(deleteNews);
                    element.Controls.Add(buttonBox);

                }
                else
                {
                    content.Text = elements[num].content;
                    widthOfElementIncide = widthOfElements / 10 * 7;
                    heightOfElementIncide = element.Size.Height;
                    content.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    content.Location = new Point(xPositionIncide, 0);
                    content.BorderStyle = BorderStyle.FixedSingle;
                    content.TextAlign = ContentAlignment.MiddleCenter;
                    xPositionIncide += widthOfElementIncide - 1;
                }

                element.Controls.Add(author);
                element.Controls.Add(time);
                element.Controls.Add(label);
                element.Controls.Add(content);

                yPosition += element.Size.Height + yMargin;
                mainBox.Controls.Add(element);

            }
        }

        public static void addElementsDocuments(List<Documents> elements, Dictionary<int, Color> properties, Panel mainBox, workflow.main_form connectForm)
        {
            int countOfElements = elements.Count();

            int width = mainBox.Size.Width;
            int height = mainBox.Size.Height;

            int xMargin = 24;
            int topYMargin = 30;
            int yMargin = -1; //Контролирует отступы между строчками, при -1 border накладываются друг на друга

            int widthOfElements = width - xMargin * 2;
            int heightOfElements = 50;
            int heightOfCustomElements = 50;

            int xPosition = xMargin;
            int yPosition = topYMargin;

            int widthOfElementIncide = 0;
            int heightOfElementIncide = 0;


            for (int num = 0; num < elements.Count(); num++)
            {

                Panel element = new Panel();
                element.Location = new Point(xPosition, yPosition);
                element.Size = new Size(widthOfElements, heightOfElements);

                int xPositionIncide = 0;

                Label read = new Label();
                read.Text = elements[num].read;
                widthOfElementIncide = widthOfElements / 10 * 2;
                heightOfElementIncide = element.Size.Height;
                read.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                read.Location = new Point(xPositionIncide, 0);
                read.BorderStyle = BorderStyle.FixedSingle;
                read.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Label author = new Label();
                author.Text = elements[num].author;
                widthOfElementIncide = widthOfElements / 10 * 3;
                heightOfElementIncide = element.Size.Height;
                author.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                author.Location = new Point(xPositionIncide, 0);
                author.BorderStyle = BorderStyle.FixedSingle;
                author.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Label label = new Label();
                label.Text = elements[num].label;
                widthOfElementIncide = widthOfElements / 10 * 4;
                heightOfElementIncide = element.Size.Height;
                label.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                label.Location = new Point(xPositionIncide, 0);
                label.BorderStyle = BorderStyle.FixedSingle;
                label.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Panel buttonBox = new Panel();
                widthOfElementIncide = widthOfElements / 10 * 1;
                heightOfElementIncide = element.Size.Height;
                buttonBox.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                buttonBox.Location = new Point(xPositionIncide, 0);
                buttonBox.BorderStyle = BorderStyle.FixedSingle;
                xPositionIncide += widthOfElementIncide;

                Button readDocument = new Button();
                readDocument.FlatStyle = FlatStyle.Flat;
                readDocument.Text = ">";
                widthOfElementIncide = 22;
                heightOfElementIncide = 22;
                readDocument.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                readDocument.Location = new Point(buttonBox.Size.Width / 2 - widthOfElementIncide / 2, element.Size.Height / 2 - heightOfElementIncide / 2);
                readDocument.Tag = elements[num].id;
                readDocument.Cursor = Cursors.Hand;
                readDocument.BackColor = SystemColors.ControlLight;

                readDocument.Click += new EventHandler(connectForm.a_readDocument_button_click);

                if (properties.ContainsKey(num))
                {
                    element.BackColor = properties[num];
                    element.Size = new Size(widthOfElements, heightOfCustomElements);
                }
                else
                {
                    element.Size = new Size(widthOfElements, heightOfElements);
                    buttonBox.Controls.Add(readDocument); //Если не служебный элемент - добавляем кнопку
                }

                element.Controls.Add(author);
                element.Controls.Add(read);
                element.Controls.Add(label);
                element.Controls.Add(buttonBox);

                yPosition += element.Size.Height + yMargin;
                mainBox.Controls.Add(element);

            }
        }

        public static void addElementsTemplates(List<Templates> elements, Dictionary<int, Color> properties, Panel mainBox, workflow.main_form connectForm)
        {

            int countOfElements = elements.Count();

            int width = mainBox.Size.Width;
            int height = mainBox.Size.Height;

            int xMargin = 24;
            int topYMargin = 30;
            int yMargin = -1; //Контролирует отступы между строчками, при -1 border накладываются друг на друга

            int widthOfElements = width - xMargin * 2;
            int heightOfElements = 50;
            int heightOfCustomElements = 50;

            int xPosition = xMargin;
            int yPosition = topYMargin;

            int widthOfElementIncide = 0;
            int heightOfElementIncide = 0;


            for (int num = 0; num < elements.Count(); num++)
            {

                Panel element = new Panel();
                element.Location = new Point(xPosition, yPosition);
                element.Size = new Size(widthOfElements, heightOfElements);

                int xPositionIncide = 0;

                Label author = new Label();
                author.Text = elements[num].author;
                widthOfElementIncide = widthOfElements / 10 * 4;
                heightOfElementIncide = element.Size.Height;
                author.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                author.Location = new Point(xPositionIncide, 0);
                author.BorderStyle = BorderStyle.FixedSingle;
                author.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Label name = new Label();
                name.Text = elements[num].name;
                widthOfElementIncide = widthOfElements / 10 * 4;
                heightOfElementIncide = element.Size.Height;
                name.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                name.Location = new Point(xPositionIncide, 0);
                name.BorderStyle = BorderStyle.FixedSingle;
                name.TextAlign = ContentAlignment.MiddleCenter;
                xPositionIncide += widthOfElementIncide - 1;

                Panel buttonBox = new Panel();
                Panel deleteButtonBox = new Panel();
                Button downloadTemplate = new Button();
                Button deleteTemplate = new Button();

                if (User.name == elements[num].author)
                {

                    //Добавляем панель для кнопки загрузки

                    widthOfElementIncide = widthOfElements / 10 * 1;
                    heightOfElementIncide = element.Size.Height;
                    buttonBox.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    buttonBox.Location = new Point(xPositionIncide, 0);
                    buttonBox.BorderStyle = BorderStyle.FixedSingle;
                    xPositionIncide += widthOfElementIncide - 1;

                    //Добавляем кнопку загрузки

                    downloadTemplate.FlatStyle = FlatStyle.Flat;
                    downloadTemplate.Text = ">";
                    widthOfElementIncide = 22;
                    heightOfElementIncide = 22;
                    downloadTemplate.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    downloadTemplate.Location = new Point(buttonBox.Size.Width / 2 - widthOfElementIncide / 2, element.Size.Height / 2 - heightOfElementIncide / 2);
                    downloadTemplate.Tag = elements[num].id;
                    downloadTemplate.Cursor = Cursors.Hand;
                    downloadTemplate.BackColor = SystemColors.ControlLight;

                    downloadTemplate.Click += new EventHandler(connectForm.a_downloadTemplate_button_click);

                    //Добавляем панель для кнопки удаления

                    widthOfElementIncide = widthOfElements / 10 * 1 + 1;
                    heightOfElementIncide = element.Size.Height;
                    deleteButtonBox.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    deleteButtonBox.Location = new Point(xPositionIncide, 0);
                    deleteButtonBox.BorderStyle = BorderStyle.FixedSingle;
                    xPositionIncide += widthOfElementIncide;

                    //Добавляем кнопку удаления

                    deleteTemplate.FlatStyle = FlatStyle.Flat;
                    deleteTemplate.Text = "x";
                    widthOfElementIncide = 22;
                    heightOfElementIncide = 22;
                    deleteTemplate.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    deleteTemplate.Location = new Point(deleteButtonBox.Size.Width / 2 - widthOfElementIncide / 2, element.Size.Height / 2 - heightOfElementIncide / 2);
                    deleteTemplate.Tag = elements[num].id;
                    deleteTemplate.Cursor = Cursors.Hand;
                    deleteTemplate.BackColor = SystemColors.ControlLight;

                    deleteTemplate.Click += new EventHandler(connectForm.a_deleteTemplate_button_click);
                    deleteButtonBox.Controls.Add(deleteTemplate);
                }
                else
                {

                    //Добавляем панель для кнопки загрузки

                    widthOfElementIncide = widthOfElements / 10 * 2;
                    heightOfElementIncide = element.Size.Height;
                    buttonBox.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    buttonBox.Location = new Point(xPositionIncide, 0);
                    buttonBox.BorderStyle = BorderStyle.FixedSingle;
                    xPositionIncide += widthOfElementIncide;

                    //Добавляем кнопку загрузки

                    downloadTemplate.FlatStyle = FlatStyle.Flat;
                    downloadTemplate.Text = ">";
                    widthOfElementIncide = 22;
                    heightOfElementIncide = 22;
                    downloadTemplate.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    downloadTemplate.Location = new Point(buttonBox.Size.Width / 2 - widthOfElementIncide / 2, element.Size.Height / 2 - heightOfElementIncide / 2);
                    downloadTemplate.Tag = elements[num].id;
                    downloadTemplate.Cursor = Cursors.Hand;
                    downloadTemplate.BackColor = SystemColors.ControlLight;
                }

                element.Controls.Add(author);
                element.Controls.Add(name);
                element.Controls.Add(buttonBox);
                element.Controls.Add(deleteButtonBox);

                if (properties.ContainsKey(num))
                {
                    element.BackColor = properties[num];
                    element.Size = new Size(widthOfElements, heightOfCustomElements);
                }
                else
                {
                    element.Size = new Size(widthOfElements, heightOfElements);
                    buttonBox.Controls.Add(downloadTemplate); //Если не служебный элемент - добавляем кнопку
                }

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
            Application.Run(new main_form());
        }
    }
}
