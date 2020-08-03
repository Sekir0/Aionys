# Aionys

## Как запустить проект

+ Для запуска серверной части нужно:
  + В файле appsettings.json найти строку и изменить насвание бд с "DESKTOP-48R6L52" на ваше
  ```c#
  "DefaultConnection": "Server=DESKTOP-48R6L52;Database=Aionys;Trusted_Connection=True;"
  ```
  + Открыть Package Manager Console -> ввести Update-Database
  + F5 или Ctrl + F5 - вуаля, сервер работает
  
![alt text](https://lh3.googleusercontent.com/pw/ACtC-3cUdi1_DNSrO-hPaoVLTIkYdB3QWTBvenzJl6TKiRfGUCHc25nfIq-jHLs1aoyyRgclmhjTuACFFhBJwnkAwUkIKoot_lWlMrdBg7WBLO3gbVvKU_f1w8YPEth1_yTni729W1PnyBu7310pEGy9WFvS=w1279-h799-no?authuser=0)

+ Для запуска UI нужно:
  + В консоли открыть корень проекта ".../Aionys" -> npm i скачиваем пакеты -> npm start ждем пока собираться проект -> откройте ваш браузер на http://localhost:4200/

![alt text](https://lh3.googleusercontent.com/pw/ACtC-3e60X_DQ262oePQEldSjmQc2LKZvV_8v-KBmA0iZzz2kHhLcB-_N3t-kzhbaMHICBGxxQ8xeavK9PYTK52U-Qazd_k5sVAd-F3YLtzrRnfQRG3tK4EN3gz3SnmPlDIdJBtgGngvx4gjKTzeo4LGLTn_=w1279-h799-no?authuser=0)
