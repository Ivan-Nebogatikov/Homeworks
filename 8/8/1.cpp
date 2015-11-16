#include <iostream>
#include "MergeSort.h"
#include <locale.h>

using namespace std;

void WorkWithList(int number)
{
	List *list = createList(); 
	TypeListElem newElement;
	for (int i = 0; i < number; ++i)
	{
		while (scanf("%d", &newElement) != 1)
		{
			cout << "������������ ����, ���������� ��� ���" << endl;
			fseek(stdin, 0, SEEK_END);
		}
		insert(newElement, list);
	}
	list = mergeSort(list);
	cout << "��������������� ������: ";
	printAllList(list);
	clear(list);
}

int main()
{
	setlocale(LC_ALL, "Rus");
	int number = 0;
	cout << "������� ���������� ���������: ";
	while (scanf("%d", &number) != 1)
	{
		cout << "������������ ����, ���������� ��� ���" << endl;
		fseek(stdin, 0, SEEK_END);
	}
	WorkWithList(number);
	return 0;
}
/*
TEST 1
�������� �� ������ �� ����������
������� ���������� ���������: 4
2 1 3 4
��������������� ������: 1 2 3 4
____________________________________
TEST 2
�������� �� ������ �� �������
������� ���������� ���������: 6
4 10 3 4 5 -40
��������������� ������: -40 3 4 4 5 10
____________________________________
TEST 3
�������� �� ������ �� �������
������� ���������� ���������: dsa
������������ ����, ���������� ��� ���
2
d d
������������ ����, ���������� ��� ���
2 1
��������������� ������: 1 2
*/