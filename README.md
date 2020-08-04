# Aionys

## Как запустить проект

+ Для запуска серверной части нужно:
  + В файле appsettings.json найти строку и изменить насвание бд с "DESKTOP-48R6L52" на ваше
  ```c#
  "DefaultConnection": "Server=DESKTOP-48R6L52;Database=Aionys;Trusted_Connection=True;"
  ```
  + Открыть Package Manager Console -> ввести Update-Database
  + "F5" или "Ctrl + F5" - вуаля, сервер работает
  
![alt text](https://lh3.googleusercontent.com/pw/ACtC-3cUdi1_DNSrO-hPaoVLTIkYdB3QWTBvenzJl6TKiRfGUCHc25nfIq-jHLs1aoyyRgclmhjTuACFFhBJwnkAwUkIKoot_lWlMrdBg7WBLO3gbVvKU_f1w8YPEth1_yTni729W1PnyBu7310pEGy9WFvS=w1279-h799-no?authuser=0)

+ Для запуска UI нужно:
  + В консоли открыть корень проекта ".../Aionys" -> вводим "npm i" скачиваем пакеты -> "npm start" ждем билд проект -> открываем браузер -> http://localhost:4200/

![alt text](https://lh3.googleusercontent.com/pw/ACtC-3d5cXHYoiIgdx9LG2txMp3PDC2vNvhMbcy2DoLkH9d4qVGTcj5O0JKYrhOYMgY3erWhIjpTcbGKEtduW8DlXsLvLal0WRpYtB207eXF0JAfTXWOoDRNQoX11xeqt0ZvI4qRwGyyn84LnDsSFZXPN_uk=w1321-h799-no?authuser=0)
