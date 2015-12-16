#include <iostream>
#include "BinaryTree.h"
#include <locale.h>

using namespace std;

void newNode(Tree *tree)
{
	int number = 0;
	cout << "Введите значение, которое нужно добавить: ";
	while (scanf("%d", &number) != 1)
	{
		cout << "Неправильный ввод, попробуйте еще раз" << endl;
		fseek(stdin, 0, SEEK_END);
	}
	addToTree(tree, number);
	cout << "Элемент добавлен" << endl;
}

void deleteNode(Tree *tree)
{
	int number = 0;
	cout << "Введите значение, которое нужно удалить: ";
	while (scanf("%d", &number) != 1)
	{
		cout << "Неправильный ввод, попробуйте еще раз" << endl;
		fseek(stdin, 0, SEEK_END);
	}
	if (!isTreeEmpty(tree))
	{
		deleteFromTree(tree, number);
		cout << "Если элемент был в множестве, то теперь его нет" << endl;
	}
	else
	{
		cout << "Множество пусто" << endl;
	}
}

void findNode(Tree *tree)
{
	int number = 0;
	cout << "Введите значение, которое нужно найти: ";
	while (scanf("%d", &number) != 1)
	{
		cout << "Неправильный ввод, попробуйте еще раз" << endl;
		fseek(stdin, 0, SEEK_END);
	}
	if (!isTreeEmpty(tree))
	{
		cout << (existInTree(tree, number)? "Такой элемент есть" : "Такого элемента нет") << endl;
	}
	else
	{
		cout << "Множество пусто" << endl;
	}
}

void increasePrint(Tree *tree)
{
	cout << "Множество в возрастающем порядке: ";
	if (!isTreeEmpty(tree))
	{
		printIncreasingTreeNodes(tree);
	}
	else
	{
		cout << "Множество пусто" << endl;
	}
}

void decreasePrint(Tree *tree)
{
	cout << "Множество в убывающем порядке: ";
	if (!isTreeEmpty(tree))
	{
		printDecreasingTreeNodes(tree);
	}
	else
	{
		cout << "Множество пусто" << endl;
	}
}


void userInput(Tree *tree)
{
	while (true)
	{
		cout << "Введите номер команды: " << endl;
		cout << "0 - выйти" << endl;
		cout << "1 - добавить значение целого типа в множество" << endl;
		cout << "2 - удалить значение" << endl;
		cout << "3 - проверить, принадлежит ли значение множеству" << endl;
		cout << "4 - напечатать текущие элементы множества в возрастающем порядке" << endl;
		cout << "5 - напечатать текущие элементы множества в убывающем порядке" << endl;
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
		case 1:
			newNode(tree);
			break;
		case 2:
			deleteNode(tree);
			break;
		case 3:
			findNode(tree);
			break;
		case 4:
			increasePrint(tree);
			break;
		case 5:
			decreasePrint(tree);
			break;
		default:
			cout << "Неверная команда, попробуйте еще раз" << endl;
			break;
		};
	}
}

int main()
{
	setlocale(LC_ALL, "Rus");
	int number = 0;
	Tree *tree = createTree();
	userInput(tree);
	deleteTree(tree);
	return 0;
}
/*
Test 1
Введите номер команды:
0 - выйти
1 - добавить значение целого типа в множество
2 - удалить значение
3 - проверить, принадлежит ли значение множеству
4 - напечатать текущие элементы множества в возрастающем порядке
5 - напечатать текущие элементы множества в возрастающем порядке
INPUT: 1
Введите значение, которое нужно добавить: 40
Элемент добавлен
INPUT: 3
Введите значение, которое нужно найти: 50
Такого элемента нет
INPUT: 1
Введите значение, которое нужно добавить: -2
Элемент добавлен
INPUT: 4
Множество в возрастающем порядке: -2 40
INPUT: 5
Множество в убывающем порядке: 40 -2
INPUT: 2
Введите значение, которое нужно удалить: -2
Если элемент был в множестве, то теперь его нет
INPUT: 0
_______________________________________________
Test 2
Введите номер команды:
0 - выйти
1 - добавить значение целого типа в множество
2 - удалить значение
3 - проверить, принадлежит ли значение множеству
4 - напечатать текущие элементы множества в возрастающем порядке
5 - напечатать текущие элементы множества в возрастающем порядке
INPUT: 1
Введите значение, которое нужно добавить: 333
Элемент добавлен
INPUT: 3
Введите значение, которое нужно найти: 333
Такой элемент есть
INPUT: ds
Неправильный ввод, попробуйте еще раз
INPUT: 2
Введите значение, которое нужно удалить: dsa
Неправильный ввод, попробуйте еще раз
INPUT: 333
Если элемент был в множестве, то теперь его нет
INPUT: 222
Неверная команда, попробуйте еще раз
INPUT: 5
Множество пусто
INPUT: 0
*/