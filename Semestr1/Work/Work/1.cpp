#include <iostream>
#include <fstream>
#include <locale>
#include "List.h"

using namespace std;

const string nameOfOutputFile = "g.txt";

bool checkIsReadGoodAndFileRead(List *listLessA, List *listSegmentAB, List *listMoreB, int a, int b)
{
	ifstream file("input.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден" << endl;
		return false;
	}
	while (!file.eof())
	{
		int newNumber;
		file >> newNumber;
		if (file.fail())
		{
			cout << "Ошибка чтения файла" << endl;
			return false;
		}
		if (newNumber < a)
		{
			insert(newNumber, listLessA);
		}
		else
		{
			if (newNumber >= a && newNumber <= b)
			{
				insert(newNumber, listSegmentAB);
			}
			else
			{
				insert(newNumber, listMoreB);
			}
		}
	}
	file.close();
	return true;
}

void cleanOutputFile()
{
	std::ofstream file(nameOfOutputFile, std::ios::out);
	file.clear();
	file.close();
}

int main()
{
	setlocale(LC_ALL, "Rus");
	cleanOutputFile();
	List *listLessA = createList();
	List *listSegmentAB = createList();
	List *listMoreB = createList();
	int a = 0;
	int b = 0;

	cout << "Введите 2 положительных числа a и b (a<=b): ";
	while (scanf("%d%d", &a, &b) != 2 || a > b || a < 0 || b < 0)
	{
		cout << "Неправильный ввод, попробуйте еще раз" << endl;
		fseek(stdin, 0, SEEK_END);
	}
	if (!checkIsReadGoodAndFileRead(listLessA, listSegmentAB, listMoreB, a, b))
	{
		clear(listLessA);
		clear(listSegmentAB);
		clear(listMoreB);
		return 0;
	}

	printAllListToFile(listLessA, nameOfOutputFile);
	clear(listLessA);
	printAllListToFile(listSegmentAB, nameOfOutputFile);
	clear(listSegmentAB);
	printAllListToFile(listMoreB, nameOfOutputFile);
	clear(listMoreB);
	cout << "Выходные данные находятся в файле " << nameOfOutputFile << endl;
	return 0;
}
/*
Test 1
INPUT:
7 3 5 4 6 8 9 0
a = 5
b = 7
OUTPUT:
3 4 0 7 5 6 8 9
____________________________________
Test 2
INPUT:
5 10 12 7 -789 564 5 0 9
a = 7
b = 6
Неправильный ввод, попробуйте еще раз
a = 10
b = 11
OUTPUT:
5 7 -789 5 0 9 10 12 564
___________________________________
Test 3
INPUT:
1 2 3
a = 5
b = 7
OUTPUT:
1 2 3
*/