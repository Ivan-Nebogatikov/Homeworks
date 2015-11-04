#include <iostream>
#include "PointerList.h"
#include "ArrayList.h"
#include <locale.h>

using namespace std;

void WorkWithList(int number)
{
	cout << "Работаем со списом на массиве" << endl; //uncomment when you want to work with ArrayLists
	ArrayList *list = createArrayList(); //uncomment when you want to work with ArrayLists

	//cout << "Работаем со списом на указателях" << endl; //uncomment when you want to work with PointerLists
	//PointerList *list = createPointerList(); //uncomment when you want to work with PointerLists

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
	WorkWithList(number);
	return 0;
}
/*
TEST 1
Введите количество элементов: 4
Работаем со списом на указателях
2 1 3 4
Отсортированный список: 1 2 3 4
____________________________________
TEST 2
Введите количество элементов: 6
Работаем со списом на массиве
4 10 3 4 5 -40
Отсортированный список: -40 3 4 4 5 10
____________________________________
TEST 3
Введите количество элементов: dsa
Неправильный ввод, попробуйте еще раз
2
Работаем со списом на массиве
d d
Неправильный ввод, попробуйте еще раз
2 1
Отсортированный список: 1 2
*/