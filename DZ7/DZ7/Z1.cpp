#include <iostream>
#include "List.h"
#include <fstream>
#include <string>
#include <locale.h>  

using namespace std;

string const fileName = "numbers.txt";

void readFromFile(List *list)
{
	ifstream file(fileName, ios::in);
	if (!file.is_open())
	{
		cout << "Файл numbers.txt не найден, начинаем с пустой базы" << endl;
		return;
	}
	cout << "Считывание базы номеров из файла " << fileName << endl;
	cout << "Сначала должны располагаться имена, затем номера. Последняя строка не должна завршаться переводом строки." << endl;
	while (!file.eof())
	{
		NumberCase bufferCase;

		file >> bufferCase.name >> bufferCase.number;
		if (file.fail())
		{
			cout << "Ошибка при чтении файла" << endl;
			clear(list);
			return;
		}
		insert(bufferCase, list);
	}
	cout << "База считана успешно" << endl;
	file.close();
}

void print(List *list)
{
	system("cls");
	cout << "База номеров: "<< endl;
	printAllList(list);
}

List* numberSort(List *list)
{
	system("cls");
	list = mergeSort(true, list);
	cout << "База номеров отсортированна по номерам" << endl;
	return list;
}

List* nameSort(List *list)
{
	system("cls");
	list = mergeSort(false, list);
	cout << "База номеров отсортированна по именам" << endl;
	return list;
}

void userInput(List *list)
{
	while (true)
	{
		cout << "Введите номер команды: " << endl;
		cout << "0 - выйти" << endl;
		cout << "1 - сортировать по имени" << endl;
		cout << "2 - сортировать по номеру" << endl;
		cout << "3 - вывести список на экран" << endl;

		int command = 0;

		while (scanf("%d", &command) != 1)
		{
			cout << "Неправильный ввод, попробуйте еще раз" << endl;
			fseek(stdin, 0, SEEK_END);
		}
		fseek(stdin, 0, SEEK_END);
		switch (command)
		{
		case 0:
			return;
			break;
		case 1:
			list = nameSort(list);
			break;
		case 2:
			list = numberSort(list);
			break;
		case 3:
			print(list);
			break;
		default:
			system("cls");
			cout << "Неверная команда, попробуйте еще раз" << endl;
			break;
		}
	}
}

int main()
{
	setlocale(LC_ALL, "Rus");
	List *list = createList();
	readFromFile(list);
	userInput(list);
	clear(list);
	return 0;
}
/*
TEST 1
numbers.txt:
a 1
f 2
e 55
d 100
eeel 438131
jfd 6
INPUT: 1
База номеров отсортированна по именам
INPUT: s
Неправильный ввод, попробуйте еще раз
INPUT: 3
База номеров:
a 1
d 100
e 55
eeel 438131
f 2
jfd 6
INPUT: 1
База номеров отсортированна по номерам
INPUT: 3
База номеров:
a 1
f 2
jfd 6
e 55
d 100
eeel 438131
INPUT: 0
__________________________________________________________________________________
TEST 2
numbers.txt:
Ivan 12345
Denis 300500
Dengi 88005553535
Clara 76844
Steeev 1234
Misha 5555555
INPUT: 1
База номеров отсортированна по именам
INPUT: 3
База номеров:
Clara 76844
Dengi 88005553535
Denis 300500
Ivan 12345
Misha 5555555
Steeev 1234
INPUT: 1
База номеров отсортированна по номерам
INPUT: saaa
Неправильный ввод, попробуйте еще раз
INPUT: 3
База номеров:
Clara 76844
Dengi 88005553535
Denis 300500
Ivan 12345
Misha 5555555
Steeev 1234
INPUT: 0
*/