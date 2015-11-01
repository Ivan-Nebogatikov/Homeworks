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
		cout << "���� numbers.txt �� ������, �������� � ������ ����" << endl;
		return;
	}
	cout << "���������� ���� ������� �� ����� " << fileName << endl;
	cout << "������� ������ ������������� �����, ����� ������. ��������� ������ �� ������ ���������� ��������� ������." << endl;
	while (!file.eof())
	{
		NumberCase bufferCase;

		file >> bufferCase.name >> bufferCase.number;
		if (file.fail())
		{
			cout << "������ ��� ������ �����" << endl;
			clear(list);
			return;
		}
		insert(bufferCase, list);
	}
	cout << "���� ������� �������" << endl;
	file.close();
}

void print(List *list)
{
	system("cls");
	cout << "���� �������: "<< endl;
	printAllList(list);
}

List* numberSort(List *list)
{
	system("cls");
	list = mergeSort(true, list);
	cout << "���� ������� �������������� �� �������" << endl;
	return list;
}

List* nameSort(List *list)
{
	system("cls");
	list = mergeSort(false, list);
	cout << "���� ������� �������������� �� ������" << endl;
	return list;
}

void userInput(List *list)
{
	while (true)
	{
		cout << "������� ����� �������: " << endl;
		cout << "0 - �����" << endl;
		cout << "1 - ����������� �� �����" << endl;
		cout << "2 - ����������� �� ������" << endl;
		cout << "3 - ������� ������ �� �����" << endl;

		int command = 0;

		while (scanf("%d", &command) != 1)
		{
			cout << "������������ ����, ���������� ��� ���" << endl;
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
			cout << "�������� �������, ���������� ��� ���" << endl;
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
���� ������� �������������� �� ������
INPUT: s
������������ ����, ���������� ��� ���
INPUT: 3
���� �������:
a 1
d 100
e 55
eeel 438131
f 2
jfd 6
INPUT: 1
���� ������� �������������� �� �������
INPUT: 3
���� �������:
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
���� ������� �������������� �� ������
INPUT: 3
���� �������:
Clara 76844
Dengi 88005553535
Denis 300500
Ivan 12345
Misha 5555555
Steeev 1234
INPUT: 1
���� ������� �������������� �� �������
INPUT: saaa
������������ ����, ���������� ��� ���
INPUT: 3
���� �������:
Clara 76844
Dengi 88005553535
Denis 300500
Ivan 12345
Misha 5555555
Steeev 1234
INPUT: 0
*/