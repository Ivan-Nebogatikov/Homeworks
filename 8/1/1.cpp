#include <iostream>
#include "MergeSort.h"
#include <locale.h>

using namespace std;

void workWithList(int number)
{
	List *list = createList(); 
	TypeListElem newElement;
	for (int i = 0; i < number; ++i)
	{
		while (scanf("%d", &newElement) != 1)
		{
			cout << "Неправильный ввод, попробуйте еще раз" << endl;
			fseek(stdin, 0, SEEK_END);
		}
		insert(newElement, list);
	}
	list = mergeSort(list);
	cout << "Отсортированный список: ";
	printAllList(list);
	clear(list);
}

int main()
{
	setlocale(LC_ALL, "Rus");
	int number = 0;
	cout << "Введите количество элементов: ";
	while (scanf("%d", &number) != 1)
	{
		cout << "Неправильный ввод, попробуйте еще раз" << endl;
		fseek(stdin, 0, SEEK_END);
	}
	workWithList(number);
	return 0;
}
/*
TEST 1
Работаем со списом на указателях
Введите количество элементов: 4
2 1 3 4
Отсортированный список: 1 2 3 4
____________________________________
TEST 2
Работаем со списом на массиве
Введите количество элементов: 6
4 10 3 4 5 -40
Отсортированный список: -40 3 4 4 5 10
____________________________________
TEST 3
Работаем со списом на массиве
Введите количество элементов: dsa
Неправильный ввод, попробуйте еще раз
2
d d
Неправильный ввод, попробуйте еще раз
2 1
Отсортированный список: 1 2
*/