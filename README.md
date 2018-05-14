### bsa3
##Binary Studio Academy 2018 2.3




#Car   


Функція			|	Запит	|	Адреса
------------------------|---------------|--------------------
Список всіх машин	|	GET	|	api/car
Деталі однієї машини	|	GET	|	api/car/{id}
Видалити машину		|	DELETE	|	api/car/{id}
Додати машину		|	POST	|	api/car


Приклад JSON об'єкту

```
{
	"type":1
	
	"balance":1000	
}
```





#Parking


Функція			|	Запит	|	Адреса
------------------------|---------------|--------------------
К-сть вільних місць	|	GET	|	api/parking/free
К-сть зайнятих місць	|	GET	|	api/parking/busy
Прибуток		|	GET	|	api/parking/money



#Transaction


Функція			|	Запит	|	Адреса
------------------------|---------------|--------------------
Виведення лог файлу	|	GET	|	api/transactions
Транзакції 1хв усі	|	GET	|	api/transactions/lastminute
Транзакції 1хв {id}	|	GET	|	api/transactions/lastminute/{id}
Поповнити баланс	|	PUT	|	api/transactions


Приклад JSON об'єкту

```
{
	"id":1
	
	"sum":1000	
}
```
