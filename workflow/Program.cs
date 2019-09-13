using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Diagnostics;
using System.Net.Sockets;
using System.Xml.Serialization;

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
        public bool status;

        public Documents(string _read, string _author, string _label, int _id, bool _status)
        {
            this.read = _read;
            this.author = _author;
            this.label = _label;
            this.id = _id;
            this.status = _status;
        }

        public Documents()
        {

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

        public static bool getUpdatesExistence()
        {
            string name = main_form.User.name;

            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("name", main_form.User.name);
            RequestM answer = SocketConnection.sendMessageFromSocket("getUpdateExistence", qParams);

            return (bool)answer.parameters["updates"];
        }

        public static void addNewChat()
        {
            Console.WriteLine("Add new chat");

            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("userName", main_form.User.name);
            RequestM answer = SocketConnection.sendMessageFromSocket("addNewChat", qParams);
        }

        public static void addUserToConversation(string user, string conversationId)
        {
            Console.WriteLine("Add user " + user + " to conversation with id " + conversationId);

            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("id", conversationId);
            qParams.Add("userName", user);
            RequestM answer = SocketConnection.sendMessageFromSocket("addUserToConversation", qParams);
        }

        public static void updateConversationName(string newName, string conversationId)
        {
            Console.WriteLine("Change name to " + newName + " in conversation with id " + conversationId);

            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("id", conversationId);
            qParams.Add("newName", newName);
            RequestM answer = SocketConnection.sendMessageFromSocket("updateConversationName", qParams);
        }

        public static void leaveConversation(string conversationId)
        {
            Console.WriteLine("Leave conversation for " + main_form.User.name + " in conversation with id " + conversationId);

            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("id", conversationId);
            qParams.Add("sender", main_form.User.name);
            RequestM answer = SocketConnection.sendMessageFromSocket("leaveConversation", qParams);
        }

        public static void sendMessage(string text)
        {
            Console.WriteLine("Send '" + text + "' to conversation with id " + main_form.User.currentConversationId);

            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("text", text);
            qParams.Add("author", main_form.User.name);
            qParams.Add("id", main_form.User.currentConversationId);
            RequestM answer = SocketConnection.sendMessageFromSocket("sendMessage", qParams);
        }

        public static void updateUsersConversations()
        {
            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("sender", main_form.User.name);
            RequestM answer = SocketConnection.sendMessageFromSocket("updateUsersConversations", qParams);

            main_form.User.conversations = JsonConvert.DeserializeObject<List<Conversation>>(answer.parameters["conversations"].ToString());
        }

        public static List<string> getAllUsers()
        {
            RequestM answer = SocketConnection.sendMessageFromSocket("getAllUsers", new Dictionary<string, object>());

            return JsonConvert.DeserializeObject<List<string>>(answer.parameters["users"].ToString());
        }

        public static void downloadDocument(string document)
        {
            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("name", main_form.User.name);
            qParams.Add("id", document);
            RequestM answer = SocketConnection.sendMessageFromSocket("downloadDocument", qParams);

            string file = answer.parameters["file"] as string;
            string type = answer.parameters["type"] as string;
            string label = answer.parameters["label"] as string;

            byte[] fileInBytes = Convert.FromBase64String(file);

            if (!System.IO.Directory.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "files")))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(Environment.CurrentDirectory, "files"));
            }

            Console.WriteLine("PATH : " + Environment.CurrentDirectory + "\\files\\" + label + type);

            File.WriteAllBytes(Environment.CurrentDirectory + "\\files\\" + label + type, fileInBytes);

            Process.Start(Environment.CurrentDirectory + "\\files\\" + label + type);
        }

        public static void downloadTemplate(string template)
        {
            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("id", template);
            RequestM answer = SocketConnection.sendMessageFromSocket("downloadTemplate", qParams);

            string file = answer.parameters["file"] as string;
            string type = answer.parameters["type"] as string;
            string label = answer.parameters["label"] as string;

            byte[] fileInBytes = Convert.FromBase64String(file);

            if (!System.IO.Directory.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "templates")))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(Environment.CurrentDirectory, "templates"));
            }

            Console.WriteLine("PATH : " + Environment.CurrentDirectory + "\\templates\\" + label + type);

            File.WriteAllBytes(Environment.CurrentDirectory + "\\templates\\" + label + type, fileInBytes);

            Process.Start(Environment.CurrentDirectory + "\\templates\\" + label + type);
        }

        public static void sendFile(string label, string path, Dictionary<string, bool> recipients)
        {
            //Console.WriteLine("Send file " + path + "(" + label + ")" + " to " + recipient);

            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("label", label);
            qParams.Add("recipients", JsonConvert.SerializeObject(recipients));

            byte[] data = File.ReadAllBytes(path);
            string file = Convert.ToBase64String(data);

            qParams.Add("file", file);
            qParams.Add("sender", main_form.User.name);
            qParams.Add("type", "." + path.Split('.')[1]);

            RequestM answer = SocketConnection.sendMessageFromSocket("sendFile", qParams);
        }

        public static void addTemplate(string name, string path)
        {
            string author = main_form.User.name;
            string templateName = name;

            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("author", author);
            qParams.Add("name", name);
            qParams.Add("type", "." + path.Split('.')[1]);

            byte[] data = File.ReadAllBytes(path);
            string file = Convert.ToBase64String(data);

            qParams.Add("file", file);
            RequestM answer = SocketConnection.sendMessageFromSocket("addTemplate", qParams);

            Console.WriteLine("Add template " + name + " (" + path + ")");
        }

        public static void getUser(string login, string password)
        {
            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("login", login);
            qParams.Add("password", password);
            RequestM answer = SocketConnection.sendMessageFromSocket("getUser", qParams);

            main_form.User = new UserClass();

            main_form.User.name = answer.parameters["name"] as string;
            main_form.User.privileges = JsonConvert.DeserializeObject<Dictionary<string, bool>>(answer.parameters["privileges"] as string);
            main_form.User.shedule = JsonConvert.DeserializeObject<List<string>>(answer.parameters["shedule"] as string);
            main_form.User.systemData = new Dictionary<string, Label>();
        }

        public static void addNews(string labelOfNews, string contentOfNews)
        {
            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("content", contentOfNews);
            qParams.Add("label", labelOfNews);
            qParams.Add("author", main_form.User.name);
            RequestM answer = SocketConnection.sendMessageFromSocket("addNews", qParams);
        }

        public static void changeMainNews(string contentOfNews)
        {
            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("content", contentOfNews);
            RequestM answer = SocketConnection.sendMessageFromSocket("changeMainNews", qParams);
        }

        public static void deleteNews(string newsId)
        {
            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("id", newsId);
            RequestM answer = SocketConnection.sendMessageFromSocket("deleteNews", qParams);
        }

        public static void deleteTemplate(string templateId)
        {
            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("id", templateId);
            RequestM answer = SocketConnection.sendMessageFromSocket("deleteTemplate", qParams);
        }

        public static List<News> getNews()
        {
            RequestM answer = SocketConnection.sendMessageFromSocket("getNews", new Dictionary<string, object>());

            return JsonConvert.DeserializeObject<List<News>>(answer.parameters["news"].ToString());
        }

        public static List<Documents> getDocuments()
        {
            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("sender", main_form.User.name);
            RequestM answer = SocketConnection.sendMessageFromSocket("getDocuments", qParams);

            return JsonConvert.DeserializeObject<List<Documents>>(answer.parameters["documents"].ToString());
        }

        public static List<Templates> getTemplates()
        {
            RequestM answer = SocketConnection.sendMessageFromSocket("getTemplates", new Dictionary<string, object>());

            return JsonConvert.DeserializeObject<List<Templates>>(answer.parameters["templates"].ToString());
        }

        public static string getMainNews()
        {
            RequestM answer = SocketConnection.sendMessageFromSocket("getMainNews", new Dictionary<string, object>());

            if(answer.name == "Ok")
            {
                return answer.parameters["main_news"] as string;
            }
            else
            {
                return "Ошибка на стороне сервера";
            }
        }

        public static Tuple<bool, string> check_user_enter(string login, string password)
        {
            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("login", login);
            qParams.Add("password", password);
            RequestM answer = SocketConnection.sendMessageFromSocket("check_user_enter", qParams);

            if (answer.name == "Denied")
            {
                return new Tuple<bool, string>(false, "Нет пользователя c такими login и password");
            }
            if(answer.name == "Accepted")
            {
                using (FileStream fstream = new FileStream(System.IO.Path.Combine(Environment.CurrentDirectory, "safe.txt"), FileMode.OpenOrCreate))
                {
                    string text = login.ToString() + ";" + password.ToString(); 

                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    // запись массива байтов в файл
                    fstream.Write(array, 0, array.Length);
                    Console.WriteLine("Логин и пароль записаны в файл");
                }

                return new Tuple<bool, string>(true, "accept");
            }
            return new Tuple<bool, string>(false, "Ошибка на стороне сервера");
        }

        public static Tuple<bool, string> new_user(string login, string password)
        {

            Dictionary<string, object> qParams = new Dictionary<string, object>();
            qParams.Add("login", login);
            qParams.Add("password", password);
            RequestM answer = SocketConnection.sendMessageFromSocket("new_user", qParams);

            if (answer.name == "Denied")
            {
                return new Tuple<bool, string>(false, "Пользователь с таким login уже существует");
            }
            if(answer.name == "Ok")
            {
                return new Tuple<bool, string>(true, "accept");
            }
            return new Tuple<bool, string>(false, "Ошибка на стороне сервера");
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

    public class Message
    {
        public string author;
        public string text;

        public Message(string _author, string _text)
        {
            this.author = _author;
            this.text = _text;
        }
    }

    public class Conversation
    {

        public List<Message> messages;
        public string name;
        public int id;

        public Conversation(string _name, List<Message> _messages, int _id)
        {
            this.name = _name;
            this.messages = _messages;
            this.id = _id;
        }
    }

    public class UserClass
    {
        public Dictionary<string, Label> systemData; //Хранятся указатели на DocumentsLeftPanelButtons
        public List<Conversation> conversations;
        public List<string> shedule;
        public string name;
        public string currentConversationId;
        public Dictionary<string, bool> privileges;

        public void set_photo(string photo_src, workflow.main_form connectForm)
        {
            int width = (int)connectForm.a_main_screen_left_panel_picture_box.Size.Width;
            var height = (int)connectForm.a_main_screen_left_panel_picture_box.Size.Height;
            Bitmap original = new Bitmap(connectForm.a_change_image_dialog.FileName);
            connectForm.a_main_screen_left_panel_picture.Image = new Bitmap(original, width, height);
            //Server.update_user_photo();
        }

        public void set_name(string name, workflow.main_form connectForm)
        {
            connectForm.a_main_screen_left_panel_name.Text = name;
        }

        public bool getPrivilege(string privilegeName)
        {
            Console.Write("Get privilege " + privilegeName);

            return main_form.User.privileges[privilegeName];
        }

        public UserClass(string _name, Dictionary<string, bool> _privileges, List<string> _shedule)
        {
            name = _name;
            privileges = _privileges;
            shedule = _shedule;
        }

        public UserClass()
        {

        }

    }

    public class UserClassClipped
    {
        public List<string> shedule;
        public string name;
        public Dictionary<string, bool> privileges;

        public UserClassClipped()
        {

        }
    }

    public class screenConstructor
    {

        public static void setChatsLeftPanel(workflow.main_form connectForm)
        {
            List<string> labelLeftChats = new List<string>() { "Беседы: " };
            List<string> conversationNames = new List<string>();
            List<string> labelLeftChatsAfter = new List<string>() { "+ Добавить беседу" };
            List<string> filledLeftChatsNames = new List<string>();

            Server.updateUsersConversations();

            foreach (var item in main_form.User.conversations)
            {
                conversationNames.Add(item.name);
                filledLeftChatsNames.Add(item.id.ToString());
            }

            List<string> contentLeftChats = conversationNames;

            List<string> filledLeftChats = new List<string>();

            if (!(contentLeftChats is null) && contentLeftChats.Count() > 0)
            {
                filledLeftChats = labelLeftChats.Concat(contentLeftChats).Concat(labelLeftChatsAfter).ToList();
            }
            else
            {
                filledLeftChats = labelLeftChats.Concat(labelLeftChatsAfter).ToList();
            }

            Dictionary<int, ContentAlignment> propertiesLeftChats = new Dictionary<int, ContentAlignment>(filledLeftChats.Count());

            propertiesLeftChats.Add(0, ContentAlignment.MiddleCenter);
            propertiesLeftChats.Add(filledLeftChats.Count() - 1, ContentAlignment.MiddleCenter);

            customBox.addElements(filledLeftChats, propertiesLeftChats, connectForm.a_main_screen_left_panel_custom_box, connectForm, "chats", filledLeftChatsNames);
        }

        public static void setDocumentsLeftPanel(workflow.main_form connectForm)
        {
            List<string> filledLeftDocuments = new List<string>() { "Отправить документ", "Входящие документы", "Шаблоны документов" };
            List<string> filledLeftDocumentsNames = new List<string>() { "a_send_message_button", "a_incoming_messages_button", "a_document_templates_button" };

            Dictionary<int, ContentAlignment> propertiesLeftDocuments = new Dictionary<int, ContentAlignment>(filledLeftDocuments.Count());

            propertiesLeftDocuments.Add(0, ContentAlignment.MiddleCenter);
            propertiesLeftDocuments.Add(1, ContentAlignment.MiddleCenter);
            propertiesLeftDocuments.Add(2, ContentAlignment.MiddleCenter);

            customBox.addElements(filledLeftDocuments, propertiesLeftDocuments, connectForm.a_main_screen_left_panel_custom_box, connectForm, "documents", filledLeftDocumentsNames);
        }

        public static void setMainLeftPanel(workflow.main_form connectForm)
        {

            connectForm.currentUnderEnvironment = "main";

            List<string> labelLeftMain = new List<string>() { "Расписание: " };
            List<string> contentLeftMain = main_form.User.shedule;

            List<string> filledLeftMain = new List<string>();

            if (!(contentLeftMain is null) && contentLeftMain.Count() > 0)
            {
                filledLeftMain = labelLeftMain.Concat(contentLeftMain).ToList();
            }
            else
            {
                filledLeftMain = labelLeftMain;
            }

            Dictionary<int, ContentAlignment> propertiesLeftMain = new Dictionary<int, ContentAlignment>(filledLeftMain.Count());

            propertiesLeftMain.Add(0, ContentAlignment.MiddleCenter);

            customBox.addElements(filledLeftMain, propertiesLeftMain, connectForm.a_main_screen_left_panel_custom_box, connectForm, "main");
        }

        public static void setDocumentsMainScreenVersion(string senderButton, workflow.main_form connectForm)
        {

            connectForm.currentUnderEnvironment = senderButton;

            cleanMainScreenEnvironment(connectForm, false);

            resetDocumentsLeftPanelButtonsColors(senderButton, connectForm);

            connectForm.a_dark_background.Visible = false;

            switch (senderButton)
            {
                case "a_incoming_messages_button":

                    Server.getTemplates();

                    connectForm.stopUpdatingMode = false;

                    List<Documents> labelDocuments = new List<Documents>() { new Documents("Cтатус", "Автор", "Тема", 0, false) };
                    List<Documents> contentDocuments = Server.getDocuments();

                    List<Documents> filledDocuments = new List<Documents>();

                    if (!(contentDocuments is null) && contentDocuments.Count() > 0)
                    {
                        filledDocuments = labelDocuments.Concat(contentDocuments).ToList();
                    }
                    else
                    {
                        filledDocuments = labelDocuments;
                    }

                    Dictionary<int, Color> propertiesDocuments = new Dictionary<int, Color>(filledDocuments.Count());

                    propertiesDocuments.Add(0, SystemColors.ControlLight);

                    mainBox.addElementsDocuments(filledDocuments, propertiesDocuments, connectForm.a_main_screen_main_box, connectForm);

                    break;

                case "a_send_message_button":

                    connectForm.stopUpdatingMode = true;

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

                    connectForm.stopUpdatingMode = false;

                    if (main_form.User.getPrivilege("addTemplates"))
                    {
                        connectForm.a_main_screen_main_box_add_template_button.Visible = true;
                    }

                    List<Templates> labelTemplates = new List<Templates>() { new Templates("Автор", "Название", 0) };
                    List<Templates> contentTemplates = Server.getTemplates();

                    List<Templates> filledTemplates = new List<Templates>();

                    if (!(contentTemplates is null) && contentTemplates.Count() > 0)
                    {
                        filledTemplates = labelTemplates.Concat(contentTemplates).ToList();
                    }
                    else
                    {
                        filledTemplates = labelTemplates;
                    }

                    Dictionary<int, Color> propertiesTemplates = new Dictionary<int, Color>(filledTemplates.Count());

                    propertiesTemplates.Add(0, SystemColors.ControlLight);

                    mainBox.addElementsTemplates(filledTemplates, propertiesTemplates, connectForm.a_main_screen_main_box, connectForm);

                    break;
            }
        }

        public static void setChatsMainScreenVersion(string senderButton, workflow.main_form connectForm, bool isUserCalledUpdate, bool alreadySetId = false)
        {
            connectForm.currentUnderEnvironment = senderButton;

            if(!alreadySetId) main_form.User.currentConversationId = senderButton;
            Console.WriteLine("ID : " + senderButton);

            cleanMainScreenEnvironment(connectForm, false);

            resetChatsLeftPanelButtonsColors(connectForm);

            connectForm.a_main_screen_main_box_chats_mode_main_panel.Visible = true;
            connectForm.a_main_screen_main_box_chats_mode_interface_panel.Visible = true;

            connectForm.a_main_screen_main_box_chats_mode_main_panel.Controls.Clear(); //Удаляем все прошлые сообщения

            Conversation currentConversation = null;

            foreach (Conversation conversation in main_form.User.conversations)
            {
                if(conversation.id.ToString() == main_form.User.currentConversationId)
                {
                    currentConversation = conversation;
                    break;
                }
            }

            List<Message> messagesInDialog = currentConversation.messages;

            int yPosition = mainBox.addElementsChats(messagesInDialog, currentConversation, connectForm.a_main_screen_main_box_chats_mode_main_panel, connectForm);
            main_form.maxPrevScrollValue = yPosition;

            if (isUserCalledUpdate)
            {
                connectForm.a_main_screen_main_box_chats_mode_main_panel.AutoScrollPosition = new Point(0, yPosition);
            }
            else
            {
                connectForm.a_main_screen_main_box_chats_mode_main_panel.AutoScrollPosition = new Point(0, main_form.systemScrollPosition);
            }
        }

        public static void setMainScreenVersion(workflow.main_form connectForm)
        {

            if (main_form.User.getPrivilege("addNews"))
            {
                connectForm.a_main_screen_main_box_add_news_button.Visible = true;
            }

            List<News> labelMain = new List<News>() { new News("Автор", "Тема", "Cодержание", "Время публикации", 0) };
            List<News> contentMain = Server.getNews();

            List<News> filledMain = new List<News>();

            if (!(contentMain is null) && contentMain.Count() > 0)
            {
                filledMain = labelMain.Concat(contentMain).ToList();
            }
            else
            {
                filledMain = labelMain;
            }

            Dictionary<int, Color> propertiesMain = new Dictionary<int, Color>(filledMain.Count());

            propertiesMain.Add(0, SystemColors.ControlLight);

            mainBox.addElementsMain(filledMain, propertiesMain, connectForm.a_main_screen_main_box, connectForm);
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
            main_form.User.systemData["a_send_message_button"].ForeColor = System.Drawing.Color.Black;
            main_form.User.systemData["a_incoming_messages_button"].ForeColor = System.Drawing.Color.Black;
            main_form.User.systemData["a_document_templates_button"].ForeColor = System.Drawing.Color.Black;

            main_form.User.systemData[labelToSetActive].ForeColor = System.Drawing.Color.Red;
        }

        public static void resetChatsLeftPanelButtonsColors(workflow.main_form connectForm)
        {
            foreach(Conversation conversation in main_form.User.conversations)
            {
                main_form.User.systemData[conversation.id.ToString()].ForeColor = System.Drawing.Color.Black;
            }

            main_form.User.systemData[main_form.User.currentConversationId].ForeColor = System.Drawing.Color.Red;
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
            Panel a_dark_background = connectForm.a_dark_background; //Сохраняем dark background
            Panel a_conversation_options_panel = connectForm.a_conversation_options_panel;

            Panel a_main_screen_main_box_chats_mode_main_panel = connectForm.a_main_screen_main_box_chats_mode_main_panel; //Сохраняем панель 'Чаты -> главная'
            Panel a_main_screen_main_box_chats_mode_interface_panel = connectForm.a_main_screen_main_box_chats_mode_interface_panel; //Сохраняем панель 'Чаты -> интерфейс'

            connectForm.a_main_screen_main_box.Controls.Clear();

            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_template_panel); //Возвращаем панель 'Добавить шаблон'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_file_panel); //Возвращаем панель 'Добавить файл'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_change_news_panel); //Возвращаем панель 'Изменить новость'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_news_panel); //Возвращаем панель 'Добавить новость'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_news_button); //Возвращаем кнопку 'Добавить новость'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_add_template_button); //Возвращаем кнопку 'Добавить шаблон'
            connectForm.a_main_screen_main_box.Controls.Add(a_dark_background); //Возвращаем dark background
            connectForm.a_main_screen_main_box.Controls.Add(a_conversation_options_panel);

            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_chats_mode_main_panel); //Возвращаем панель 'Чаты -> главная'
            connectForm.a_main_screen_main_box.Controls.Add(a_main_screen_main_box_chats_mode_interface_panel); //Возвращаем панель 'Чаты -> интерфейс'

            connectForm.a_main_screen_main_box_add_template_panel.Visible = false;
            connectForm.a_main_screen_main_box_add_file_panel.Visible = false;
            connectForm.a_main_screen_main_box_change_news_panel.Visible = false;
            connectForm.a_main_screen_main_box_add_news_panel.Visible = false;
            connectForm.a_main_screen_main_box_add_news_button.Visible = false;
            connectForm.a_main_screen_main_box_add_template_button.Visible = false;
            connectForm.a_conversation_options_panel.Visible = false;

            connectForm.a_main_screen_main_box_chats_mode_main_panel.Visible = false;
            connectForm.a_main_screen_main_box_chats_mode_interface_panel.Visible = false;
        }

        public static void changeMainScreenEnvironment(string environment, workflow.main_form connectForm, string underEnvironment = null)
        {

            if (!(underEnvironment is null) && connectForm.stopUpdatingMode) return;

            cleanMainScreenEnvironment(connectForm);

            connectForm.currentEnvironment = environment;

            switch (environment)
            {
                case "main":

                    resetTopPanelButtonsColors(connectForm.a_main_screen_top_panel_button1_text, connectForm);

                    //--------------------------- left screen changes

                    //screenConstructor.setMainLeftPanel(connectForm);

                    //--------------------------- main screen changes

                    screenConstructor.setMainScreenVersion(connectForm);

                    Console.WriteLine("Change environment : main");
                    break;

                case "documents":

                    resetTopPanelButtonsColors(connectForm.a_main_screen_top_panel_button2_text, connectForm);

                    //--------------------------- left screen changes

                    //if(underEnvironment is null) //Если смена, а не обновление с сервера
                    //{
                        main_form.User.systemData.Clear(); //Очищаем указатели на кнопки с прошлой сессии
                        screenConstructor.setDocumentsLeftPanel(connectForm);
                    //}

                    //--------------------------- main screen changes

                    if(underEnvironment is null)
                    {
                        screenConstructor.setDocumentsMainScreenVersion("a_incoming_messages_button", connectForm);
                    }
                    else
                    {
                        screenConstructor.setDocumentsMainScreenVersion(underEnvironment, connectForm);
                    }

                    Console.WriteLine("Change environment : documents");
                    break;

                case "chats":

                    main_form.User.systemData.Clear(); //Очищаем указатели на кнопки с прошлой сессии

                    resetTopPanelButtonsColors(connectForm.a_main_screen_top_panel_button3_text, connectForm);

                    //--------------------------- left screen changes

                    screenConstructor.setChatsLeftPanel(connectForm);

                    //--------------------------- main screen changes

                    connectForm.a_main_screen_main_box_chats_mode_interface_panel.Visible = true;
                    connectForm.a_main_screen_main_box_chats_mode_main_panel.Visible = true;

                    if (main_form.User.conversations.Count() > 0)
                    {
                        if(underEnvironment is null)
                        {
                            screenConstructor.setChatsMainScreenVersion(main_form.User.conversations[0].id.ToString(), connectForm, true);
                        }
                        else
                        {
                            main_form.systemScrollPosition = connectForm.a_main_screen_main_box_chats_mode_main_panel.VerticalScroll.Value;

                            Console.WriteLine("BOX HEIGHT = " + (main_form.maxPrevScrollValue - connectForm.a_main_screen_main_box_chats_mode_main_panel.Size.Height).ToString());
                            Console.WriteLine("SCROLL POS = " + main_form.systemScrollPosition.ToString());

                            if (main_form.systemScrollPosition > main_form.maxPrevScrollValue - connectForm.a_main_screen_main_box_chats_mode_main_panel.Size.Height - 5) //Если мы итак внизу - перекидывать
                            {
                                screenConstructor.setChatsMainScreenVersion(underEnvironment, connectForm, true, true);
                            }
                            else
                            {
                                screenConstructor.setChatsMainScreenVersion(underEnvironment, connectForm, false, true);
                            }
                        }
                    }

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

            int heightOfElements = 0;

            int notServiceElementsCount = 0;

            if(environment == "chats" && elements.Count() * 40 > height)
            {
                heightOfElements = 40; //fixed size у названий чатов
                widthOfElements = widthOfElements - 17; //Полоса прокрутки сьедает 17px
            }
            else
            {
                heightOfElements = height / countOfElements;
            }

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
                    main_form.User.systemData.Add(customNames[num], labelOnElement);
                }

                if(environment == "chats" && !properties.ContainsKey(num))//Если есть в properties - то он служебный
                {
                    main_form.User.systemData.Add(customNames[notServiceElementsCount], labelOnElement);
                    labelOnElement.Tag = customNames[notServiceElementsCount]; //Скипаем служебные элементы, поэтому собственный счетчик
                    notServiceElementsCount++;
                    labelOnElement.Cursor = Cursors.Hand;
                    labelOnElement.Click += new EventHandler(connectForm.a_chats_left_panel_button_click);
                }

                if(environment == "chats" && num == elements.Count() - 1)
                {
                    labelOnElement.Click += new EventHandler(connectForm.a_chats_left_panel_add_chat_button_click);
                    labelOnElement.Cursor = Cursors.Hand;
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

                if (main_form.User.name == elements[num].author)
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
                    deleteNews.FlatAppearance.BorderSize = 0;
                    deleteNews.Text = "x";
                    widthOfElementIncide = 22;
                    heightOfElementIncide = 22;
                    deleteNews.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    deleteNews.Location = new Point(buttonBox.Size.Width / 2 - widthOfElementIncide / 2, element.Size.Height / 2 - heightOfElementIncide / 2);
                    deleteNews.Tag = elements[num].id;
                    deleteNews.Cursor = Cursors.Hand;

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
                if(num == 0) //Первый элемент
                {
                    read.Text = elements[num].read;
                }
                else
                {
                    read.Text = elements[num].status ? "Прочитано" : "Новое";
                }
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
                readDocument.FlatAppearance.BorderSize = 0;
                readDocument.Text = ">";
                widthOfElementIncide = 22;
                heightOfElementIncide = 22;
                readDocument.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                readDocument.Location = new Point(buttonBox.Size.Width / 2 - widthOfElementIncide / 2, element.Size.Height / 2 - heightOfElementIncide / 2);
                readDocument.Tag = elements[num].id;
                readDocument.Cursor = Cursors.Hand;

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

                if (main_form.User.name == elements[num].author)
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
                    downloadTemplate.FlatAppearance.BorderSize = 0;
                    downloadTemplate.Text = ">";
                    widthOfElementIncide = 22;
                    heightOfElementIncide = 22;
                    downloadTemplate.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    downloadTemplate.Location = new Point(buttonBox.Size.Width / 2 - widthOfElementIncide / 2, element.Size.Height / 2 - heightOfElementIncide / 2);
                    downloadTemplate.Tag = elements[num].id;
                    downloadTemplate.Cursor = Cursors.Hand;

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
                    deleteTemplate.FlatAppearance.BorderSize = 0;
                    deleteTemplate.Text = "x";
                    widthOfElementIncide = 22;
                    heightOfElementIncide = 22;
                    deleteTemplate.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    deleteTemplate.Location = new Point(deleteButtonBox.Size.Width / 2 - widthOfElementIncide / 2, element.Size.Height / 2 - heightOfElementIncide / 2);
                    deleteTemplate.Tag = elements[num].id;
                    deleteTemplate.Cursor = Cursors.Hand;

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
                    downloadTemplate.FlatAppearance.BorderSize = 0;
                    downloadTemplate.Text = ">";
                    widthOfElementIncide = 22;
                    heightOfElementIncide = 22;
                    downloadTemplate.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                    downloadTemplate.Location = new Point(buttonBox.Size.Width / 2 - widthOfElementIncide / 2, element.Size.Height / 2 - heightOfElementIncide / 2);
                    downloadTemplate.Tag = elements[num].id;
                    downloadTemplate.Cursor = Cursors.Hand;

                    downloadTemplate.Click += new EventHandler(connectForm.a_downloadTemplate_button_click);
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

        public static int addElementsChats(List<Message> elements, Conversation conversation, Panel mainBox, workflow.main_form connectForm)
        {
            int countOfElements = elements.Count();

            int width = mainBox.Size.Width;
            int height = mainBox.Size.Height;

            int yMargin = 3; //Контролирует отступы между строчками, при -1 border накладываются друг на друга

            int widthOfElements = width / 3;

            Func<int, int> xPositionAuthor1 = (x) => 0;
            Func<int, int> xPositionAuthor2 = (x) => width - x - 17;

            int widthOfElementIncide = 0;
            int heightOfElementIncide = 0;

            int yPositionIncide = 0;

            int yPosition = yMargin;

            for (int num = 0; num < elements.Count(); num++)
            {

                yPositionIncide = 0;

                Panel element = new Panel();

                Label text = new Label();
                text.Text = elements[num].text;

                element.Size = new Size(text.GetPreferredSize(new Size(widthOfElements, 0)).Width + 30, text.GetPreferredSize(new Size(widthOfElements, 0)).Height + 40);
                element.BorderStyle = BorderStyle.FixedSingle;

                if (elements[num].author == main_form.User.name)
                {
                    element.Location = new Point(xPositionAuthor1(element.Size.Width), yPosition);
                }
                else
                {
                    element.Location = new Point(xPositionAuthor2(element.Size.Width), yPosition);
                }

                Label author = new Label();
                author.Text = elements[num].author;
                widthOfElementIncide = element.Size.Width;
                heightOfElementIncide = 20;
                author.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                author.Location = new Point(0, yPositionIncide);
                author.TextAlign = ContentAlignment.MiddleCenter;
                author.BackColor = SystemColors.ControlLight;

                yPositionIncide += heightOfElementIncide;

                widthOfElementIncide = element.Size.Width;
                heightOfElementIncide = element.Size.Height - 20;
                text.Size = new Size(widthOfElementIncide, heightOfElementIncide);
                text.Location = new Point(0, yPositionIncide);
                text.TextAlign = ContentAlignment.TopLeft;
                Console.WriteLine("preffered size : " + text.GetPreferredSize(text.Size));

                element.Controls.Add(text);
                element.Controls.Add(author);

                yPosition += element.Size.Height + yMargin;
                mainBox.Controls.Add(element);

            }

            Label nameOfConversation = new Label();
            nameOfConversation.Text = conversation.name;
            nameOfConversation.Size = new Size(180, 20);
            nameOfConversation.BackColor = SystemColors.ControlLight;
            nameOfConversation.TextAlign = ContentAlignment.MiddleCenter;
            nameOfConversation.Font = new Font("Microsoft San Serif", 10);
            nameOfConversation.Location = new Point(connectForm.a_main_screen_main_box.Size.Width / 2 - nameOfConversation.Size.Width / 2, 0);
            nameOfConversation.Tag = conversation.id;
            nameOfConversation.Cursor = Cursors.Hand;
            nameOfConversation.Click += connectForm.conversation_options_open;
            connectForm.a_main_screen_main_box.Controls.Add(nameOfConversation);

            return yPosition;
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
