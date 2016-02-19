#include <iostream>
#include <fstream>
#include <locale>
#include "List.h"

using namespace std;

bool checkIsReadGoodAndFileRead(List *list)
{
	ifstream file("input.txt", ios::in);
	if (!file.is_open())
	{
		cout << "���� �� ������" << endl;
		return false;
	}
	while (!file.eof())
	{
		int newNumber;
		file >> newNumber;
		if (file.fail())
		{
			cout << "������ ������ �����" << endl;
			return false;
		}
		insert(newNumber, list);
	}
	file.close();
	return true;
}

bool isListSymmetric(List *list)
{
	for (int i = 0; i < getLength(list) / 2; ++i)
	{
		if (getElement(list, i) != getElement(list, getLength(list) - i - 1))
		{
			return false;
		}
	}
	return true;
}

int main()
{
	setlocale(LC_ALL, "Rus");
	List *list = createList();
	if (!checkIsReadGoodAndFileRead(list))
	{
		clear(list);
		return 0;
	}
	if (isListSymmetric(list))
	{
		cout << "������ �����������" << endl;
	}
	else
	{
		cout << "������ �������������" << endl;
	}
	clear(list);
	return 0;
}
/*
Test 1
INPUT: 1 2 2 1
OUTPUT: ������ �����������
____________________________________
Test 2
INPUT: 1 2 3 2 1
OUTPUT: ������ �����������
___________________________________
Test 3
INPUT: 1 2 aaaaa 2 1
OUTPUT: ������ ������ �����
___________________________________
Text 4
INPUT: 4 5 3 4 6 1 2 3 8 9 4 6 66 1 1 3 2
OUTPUT: ������ �������������
*/