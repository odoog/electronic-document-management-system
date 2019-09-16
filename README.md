# Elma
 Electronic document management

Система внутреннего обмена документами. Позволяет делиться документами, их шаблонами и переписываться внутри сети.

### Настройка внутри сети

1) Создать mysql db запустив файл workflow_server/workflowDB.sql
2) Указать актуальные пути к db в config файле workflow_server/.../dbConfig.txt в формате {host};{port};{dbName};{user};{password} например
```c#
127.0.0.1;3306;workflow;root;
```

3) Указать актуальные настройки сети в файле workflow_server/.../SocketConfig.txt в формате {host};{port}, например
```c#
127.0.0.1;11000
```
4) Указать актуальные настройки сети в файле workflow/.../socketConfig.txt в формате {host};{port}, например
```c#
127.0.0.1;11000
```
5) Запустить сервер, клиентское приложение
