// SocketServer.cs
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {

            //Попытка подключения к дб

            Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            mysql.conn = conn;

            // Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

            // Создаем сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);

                // Начинаем слушать соединения
                while (true)
                {
                    Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

                    // Программа приостанавливается, ожидая входящее соединение
                    Socket handler = sListener.Accept();
                    string data = null;

                    // Мы дождались клиента, пытающегося с нами соединиться

                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);

                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    // Показываем данные на консоли
                    Console.Write("Полученный текст: " + data + "\n\n");

                    // Отправляем ответ клиенту
                    string reply = connectionHandel.getAnswer(data);
                    byte[] msg = Encoding.UTF8.GetBytes(reply);

                    int bytesSent = 0;
                    int bytesLeft = package.Length;
                    while (bytesLeft > 0)
                    {
                        int nextPacketSize = (bytesLeft > 1024) ? 1024 : bytesLeft;
                        handler.Send(msg);
                        bytesSent += nextPacketSize;
                        bytesLeft -= nextPacketSize;
                    }

                    if (data.IndexOf("<TheEnd>") > -1)
                    {
                        Console.WriteLine("Сервер завершил соединение с клиентом.");
                        break;
                    }

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }

    class mysql
    {

        public static MySqlDataReader lastReader;

        public static MySqlConnection conn;

        public static MySqlDataReader q(string sql)
        {
            Console.WriteLine("DBQUEST: " + sql);

            if(!(lastReader is null)) lastReader.Close();

            Console.WriteLine("Database request");

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            lastReader = reader;

            return reader;
        }
    }


    class RequestM
    {
        public string name;
        public Dictionary<string, object> parameters = new Dictionary<string, object>();

        public RequestM()
        {

        }
    }


    class connectionHandel
    {

        public static string getAnswer(string request)
        {

            RequestM requestSepr = JsonConvert.DeserializeObject<RequestM>(request);

            RequestM answer = new RequestM();

            MySqlDataReader reader = null;

            string login;
            string password;
            string content;
            string author;
            string label;
            string name;
            string id;
            string userName;

            bool entryVar = false;

            switch (requestSepr.name)
            {

                case "new_user":

                    login = requestSepr.parameters["login"] as string;
                    password = requestSepr.parameters["password"] as string;

                    reader = mysql.q($"SELECT * FROM `users` WHERE `name`='{login}'");

                    bool isInSystem = false;

                    while (reader.Read())
                    {
                        isInSystem = true;
                        break;
                    }

                    if (isInSystem)
                    {
                        answer.name = "Denied";
                    }
                    else
                    {
                        Dictionary<string, bool> startPrivileges = new Dictionary<string, bool>();

                        startPrivileges.Add("changeMainNews", false);
                        startPrivileges.Add("addTemplates", false);
                        startPrivileges.Add("addNews", false);

                        string startPrivilegesString = JsonConvert.SerializeObject(startPrivileges);

                        List<string> shedule = new List<string>();

                        string startSheduleString = JsonConvert.SerializeObject(shedule);

                        List<Conversation> conversations = new List<Conversation>();

                        string startConversationsString = JsonConvert.SerializeObject(conversations);

                        mysql.q($"INSERT INTO users(name,password,privileges,shedule,conversations) VALUES ('{login}','{password}', '{startPrivilegesString}', '{startSheduleString}', '{startConversationsString}')");

                        answer.name = "Ok";
                    }

                    break;

                case "check_user_enter":

                    entryVar = false;

                    login = requestSepr.parameters["login"] as string;
                    password = requestSepr.parameters["password"] as string;

                    reader = mysql.q($"SELECT * FROM `users` WHERE `name`='{login}' AND `password`='{password}'");

                    while (reader.Read())
                    {
                        entryVar = true;
                        break;
                    }

                    if (entryVar)
                    {
                        answer.name = "Accepted";
                    }
                    else
                    {
                        answer.name = "Denied";
                    }

                    break;

                case "getMainNews":

                    reader = mysql.q($"SELECT `value` FROM `variables` WHERE `name`='main_news'");

                    answer.name = "Ok";

                    while (reader.Read())
                    {
                        answer.parameters.Add("main_news", reader[0].ToString());
                    }

                    break;


                case "getTemplates":

                    reader = mysql.q($"SELECT * FROM `templates`");

                    answer.name = "Ok";

                    List<Templates> answerListGetTemplates = new List<Templates>();

                    while (reader.Read())
                    {
                        Templates template = new Templates();

                        template.author = reader[0].ToString();
                        template.name = reader[1].ToString();
                        template.id = Int32.Parse(reader[2].ToString());

                        answerListGetTemplates.Add(template);
                    }

                    string answerListGetTemplatesString = JsonConvert.SerializeObject(answerListGetTemplates);

                    answer.parameters.Add("templates", answerListGetTemplatesString);

                    break;

                case "getDocuments":

                    string sender = requestSepr.parameters["sender"] as string;

                    reader = mysql.q($"SELECT * FROM `documents`");

                    answer.name = "Ok";

                    List<Documents> answerListGetDocuments = new List<Documents>();

                    while (reader.Read())
                    {


                        List<string> recipients = JsonConvert.DeserializeObject<List<string>>(reader[3].ToString());


                        if (recipients.IndexOf(sender) == -1) //Если у документа пользователь не в рассылке - пропускаем
                        {
                            continue;
                        }

                        Documents document = new Documents();

                        document.author = reader[0].ToString();
                        document.label = reader[1].ToString();
                        document.id = Int32.Parse(reader[2].ToString());

                        answerListGetDocuments.Add(document);
                    }

                    answer.parameters.Add("documents", JsonConvert.SerializeObject(answerListGetDocuments));

                    break;

                case "getNews":

                    reader = mysql.q($"SELECT * FROM `news`");

                    answer.name = "Ok";

                    List<News> answerListGetNews = new List<News>();

                    while (reader.Read())
                    {
                        News news = new News();

                        news.author = reader[0].ToString();
                        news.label = reader[1].ToString();
                        news.content = reader[2].ToString();
                        news.time = reader[3].ToString();
                        news.id = Int32.Parse(reader[4].ToString());

                        answerListGetNews.Add(news);
                    }

                    answer.parameters.Add("news", JsonConvert.SerializeObject(answerListGetNews));

                    break;

                case "deleteTemplate":

                    string templateId = requestSepr.parameters["id"] as string;

                    reader = mysql.q($"DELETE FROM `templates` WHERE `id`={templateId}");

                    answer.name = "Ok";

                    break;

                case "deleteNews":

                    string newsId = requestSepr.parameters["id"] as string;

                    reader = mysql.q($"DELETE FROM `news` WHERE `id`={newsId}");

                    answer.name = "Ok";

                    break;

                case "changeMainNews":

                    content = requestSepr.parameters["content"] as string;

                    reader = mysql.q($"UPDATE `variables` SET `value`='{content}' WHERE `name`='main_news'");

                    answer.name = "Ok";

                    break;

                case "addNews":

                    content = requestSepr.parameters["content"] as string;
                    label = requestSepr.parameters["label"] as string;
                    author = requestSepr.parameters["author"] as string;

                    reader = mysql.q($"INSERT INTO news(author,label,content) VALUES ('{author}','{label}','{content}')");

                    answer.name = "Ok";

                    break;

                case "getUser":

                    login = requestSepr.parameters["login"] as string;
                    password = requestSepr.parameters["password"] as string;

                    reader = mysql.q($"SELECT * FROM `users` WHERE `name`='{login}' AND `password`='{password}'");

                    while (reader.Read())
                    {
                        name = reader[0].ToString();
                        Dictionary<string, bool>  privileges = JsonConvert.DeserializeObject<Dictionary<string, bool>>(reader[2].ToString());
                        List<string> shedule = JsonConvert.DeserializeObject<List<string>>(reader[3].ToString());

                        Dictionary<string, object> answerUser = new Dictionary<string, object>();

                        answer.parameters.Add("name", name);
                        answer.parameters.Add("privileges", JsonConvert.SerializeObject(privileges));
                        answer.parameters.Add("shedule", JsonConvert.SerializeObject(shedule));

                        break;
                    }

                    answer.name = "Ok";

                    break;

                case "getAllUsers":

                    reader = mysql.q($"SELECT * FROM `users`");

                    List<string> answerList = new List<string>();

                    while (reader.Read())
                    {
                        answerList.Add(reader[0].ToString());
                    }

                    answer.name = "Ok";

                    answer.parameters.Add("users", JsonConvert.SerializeObject(answerList));

                    break;

                case "updateUsersConversations":

                    reader = mysql.q($"SELECT * FROM `conversations`");

                    string nameOfSender = requestSepr.parameters["sender"] as string;

                    answer.parameters.Add("conversations", new List<Conversation>());

                    List<Conversation> userConversations = new List<Conversation>();

                    while (reader.Read())
                    {
                        Conversation currentConversation = new Conversation();
                        currentConversation.name = reader[0].ToString();
                        currentConversation.id = Int32.Parse(reader[1].ToString());
                        currentConversation.messages = JsonConvert.DeserializeObject<List<Message>>(reader[2].ToString());
                        List<string> users = JsonConvert.DeserializeObject<List<String>>(reader[3].ToString());

                        if (users.IndexOf(nameOfSender) != -1)
                        {
                            userConversations.Add(currentConversation);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    answer.parameters["conversations"] = JsonConvert.SerializeObject(userConversations);

                    answer.name = "Ok";

                    break;

                case "sendMessage":

                    string text = requestSepr.parameters["text"] as string;
                    author = requestSepr.parameters["author"] as string;
                    id = requestSepr.parameters["id"] as string;

                    reader = mysql.q($"SELECT * FROM `conversations` WHERE `id`={id}");

                    while (reader.Read())
                    {
                        List<Message> conversationMessages = JsonConvert.DeserializeObject<List<Message>>(reader[2].ToString());

                        Message newMessage = new Message(author, text);

                        conversationMessages.Add(newMessage);

                        mysql.q($"UPDATE conversations SET messages='{JsonConvert.SerializeObject(conversationMessages)}' WHERE id={id}");

                        break;

                    }

                    answer.name = "Ok";

                    break;

                case "leaveConversation":

                    id = requestSepr.parameters["id"] as string;
                    name = requestSepr.parameters["sender"] as string;

                    reader = mysql.q($"SELECT * FROM `conversations` WHERE `id`={id}");

                    while (reader.Read())
                    {
                        List<string> usersInConversation = JsonConvert.DeserializeObject<List<string>>(reader[3].ToString());

                        usersInConversation.Remove(name);

                        mysql.q($"UPDATE conversations SET users='{JsonConvert.SerializeObject(usersInConversation)}' WHERE id={id}");

                        break;
                    }

                    answer.name = "Ok";

                    break;

                case "updateConversationName":

                    id = requestSepr.parameters["id"] as string;
                    string newName = requestSepr.parameters["newName"] as string;

                    reader = mysql.q($"UPDATE conversations SET name='{newName}' WHERE id={id}");

                    answer.name = "Ok";

                    break;

                case "addUserToConversation":

                    id = requestSepr.parameters["id"] as string;
                    userName = requestSepr.parameters["userName"] as string;

                    reader = mysql.q($"SELECT * FROM `conversations` WHERE `id`={id}");

                    while (reader.Read())
                    {
                        List<string> usersInConversation = JsonConvert.DeserializeObject<List<string>>(reader[3].ToString());

                        usersInConversation.Add(userName);

                        mysql.q($"UPDATE conversations SET users='{JsonConvert.SerializeObject(usersInConversation)}' WHERE id={id}");

                        break;
                    }

                    answer.name = "Ok";

                    break;

                case "addNewChat":

                    userName = requestSepr.parameters["userName"] as string;

                    List<string> userInConversation = new List<string>();
                    userInConversation.Add(userName);

                    List<Message> messagesInConversation = new List<Message>();

                    mysql.q($"INSERT INTO conversations(name,messages,users) VALUES ('No name','{JsonConvert.SerializeObject(messagesInConversation)}','{JsonConvert.SerializeObject(userInConversation)}')");

                    answer.name = "Ok";

                    break;

                case "addTemplate":

                    name = requestSepr.parameters["name"] as string;
                    author = requestSepr.parameters["author"] as string;

                    mysql.q($"INSERT INTO templates(name,author) VALUES ('{name}','{author}')");


                    break;

                default:

                    answer.name = "Error. Invalid type of question";

                    break;

                

            }

            return JsonConvert.SerializeObject(answer);

        }

        private static string makeTextAnswer()
        {
            return "1";
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

        public Message()
        {

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

        public Conversation()
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

        public Templates()
        {

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

        public Documents()
        {

        }
    }

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

        public News()
        {

        }

    }

    public class UserClassClipped
    {
        public List<string> shedule;
        public string name;
        public Dictionary<string, bool> privileges;
        public List<Conversation> conversations;

        public UserClassClipped()
        {

        }
    }





}