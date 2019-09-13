# Elma
 Electronic document management

Система внутреннего обмена документами. Позволяет делиться документами, их шаблонами и переписываться внутри сети.

### Настройка внутри сети

1) Создать mysql db запустив файл workflowDB.sql
2) Указать актуальные пути к db в config файле workflow_server/DBUtils.cs
3) Указать актуальные настройки сети в файле workflow_server/Program.cs
```c#
IPHostEntry ipHost = Dns.GetHostEntry("localhost");
IPAddress ipAddr = ipHost.AddressList[0];
IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);
```
4) Указать актуальные настройки сети в файле workflow/SocketConnection.cs
```c#
IPHostEntry ipHost = Dns.GetHostEntry("localhost");
IPAddress ipAddr = ipHost.AddressList[0];
IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
```
5) Скомпилировать и запустить сервер, клиентское приложение
