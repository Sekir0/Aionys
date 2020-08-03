# Aionys

##Как запустить проект

+Для запуска серверной части нужно:
  +В файле appsettings.json найти строку и изменить насвание бд с "DESKTOP-48R6L52" на ваше
  ```c#
  "DefaultConnection": "Server=DESKTOP-48R6L52;Database=Aionys;Trusted_Connection=True;"
  ```
  +Открыть Package Manager Console -> ввести Update-Database
  +F5 или Ctrl + F5 - вуаля, сервер работает
  
![alt text](https://photos.google.com/photo/AF1QipPIZCxouNeZinhC0TkO-bX6lBQxz0n7EtosP4cf)

+Для запуска UI нужно:
  +В консоли открыть корень проекта ".../Aionys" -> npm i скачиваем пакеты -> npm start ждем пока собираться проект -> откройте ваш браузер на http://localhost:4200/

![alt text](https://photos.google.com/photo/AF1QipPp5XJ0tVZF3-vlFvf7peTI915JXgd2vJRBM8iN)
