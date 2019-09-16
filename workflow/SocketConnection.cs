using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

namespace workflow
{
    class SocketConnection
    {
        public static int port;
        public static string host;

        static public RequestM sendMessageFromSocket(string name, Dictionary<string, object> qParams)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

            // Соединяемся с удаленным устройством

            using (FileStream fstream = new FileStream(System.IO.Path.Combine(Environment.CurrentDirectory, "socketConfig.txt"), FileMode.OpenOrCreate))
            {
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                string[] configInfo = textFromFile.Split(new char[] { ';' });
                host = configInfo[0];
                port = Int32.Parse(configInfo[1]);
            }

            // Устанавливаем удаленную точку для сокета
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);

            string message = JsonConvert.SerializeObject(new RequestM(name, qParams));

            Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
            byte[] msg = Encoding.UTF8.GetBytes(message + "<TheEnd>");

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера

            string block = null;
            string answer = null;

            int bytesRec = 0;

            while (true)
            {

                bytesRec = sender.Receive(bytes);
                block = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                answer += block;
                if (answer.Contains("<TheEnd>")) break;
            }

            answer = answer.Remove(answer.Length - 8);

            // Показываем данные на консоли
            Console.Write("Полученный текст: " + answer + "\n\n");

            RequestM answerSep = JsonConvert.DeserializeObject<RequestM>(answer);

            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();

            return answerSep;
        }
    }

    class RequestM
    {
        public string name;
        public Dictionary<string, object> parameters;

        public RequestM(string _name, Dictionary<string, object> _parametrs)
        {
            name = _name;
            parameters = _parametrs;
        }
    }
}
