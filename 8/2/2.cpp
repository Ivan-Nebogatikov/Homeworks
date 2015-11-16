#include <iostream>
#include "BinaryTree.h"
#include <locale.h>

using namespace std;

void newNode(Tree *tree)
{
	int number = 0;
	cout << "������� ��������, ������� ����� ��������: ";
	while (scanf("%d", &number) != 1)
	{
		cout << "������������ ����, ���������� ��� ���" << endl;
		fseek(stdin, 0, SEEK_END);
	}
	addToTree(tree, number);
	cout << "������� ��������" << endl;
}

void deleteNode(Tree *tree)
{
	int number = 0;
	cout << "������� ��������, ������� ����� �������: ";
	while (scanf("%d", &number) != 1)
	{
		cout << "������������ ����, ���������� ��� ���" << endl;
		fseek(stdin, 0, SEEK_END);
	}
	if (!isTreeEmpty(tree))
	{
		deleteFromTree(tree, number);
		cout << "���� ������� ��� � ���������, �� ������ ��� ���" << endl;
	}
	else
	{
		cout << "��������� �����" << endl;
	}
}

void findNode(Tree *tree)
{
	int number = 0;
	cout << "������� ��������, ������� ����� �����: ";
	while (scanf("%d", &number) != 1)
	{
		cout << "������������ ����, ���������� ��� ���" << endl;
		fseek(stdin, 0, SEEK_END);
	}
	if (!isTreeEmpty(tree))
	{
		cout << (existInTree(tree, number)? "����� ������� ����" : "������ �������� ���") << endl;
	}
	else
	{
		cout << "��������� �����" << endl;
	}
}

void increasePrint(Tree *tree)
{
	cout << "��������� � ������������ �������: ";
	if (!isTreeEmpty(tree))
	{
		printIncreasingTreeNodes(tree);
	}
	else
	{
		cout << "��������� �����" << endl;
	}
}

void decreasePrint(Tree *tree)
{
	cout << "��������� � ��������� �������: ";
	if (!isTreeEmpty(tree))
	{
		printDecreasingTreeNodes(tree);
	}
	else
	{
		cout << "��������� �����" << endl;
	}
}


void userInput(Tree *tree)
{
	while (true)
	{
		cout << "������� ����� �������: " << endl;
		cout << "0 - �����" << endl;
		cout << "1 - �������� �������� ������ ���� � ���������" << endl;
		cout << "2 - ������� ��������" << endl;
		cout << "3 - ���������, ����������� �� �������� ���������" << endl;
		cout << "4 - ���������� ������� �������� ��������� � ������������ �������" << endl;
		cout << "5 - ���������� ������� �������� ��������� � ������������ �������" << endl;
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
			cout << "�������� �������, ���������� ��� ���" << endl;
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
������� ����� �������:
0 - �����
1 - �������� �������� ������ ���� � ���������
2 - ������� ��������
3 - ���������, ����������� �� �������� ���������
4 - ���������� ������� �������� ��������� � ������������ �������
5 - ���������� ������� �������� ��������� � ������������ �������
INPUT: 1
������� ��������, ������� ����� ��������: 40
������� ��������
INPUT: 3
������� ��������, ������� ����� �����: 50
������ �������� ���
INPUT: 1
������� ��������, ������� ����� ��������: -2
������� ��������
INPUT: 4
��������� � ������������ �������: -2 40
INPUT: 5
��������� � ��������� �������: 40 -2
INPUT: 2
������� ��������, ������� ����� �������: -2
���� ������� ��� � ���������, �� ������ ��� ���
INPUT: 0
_______________________________________________
Test 2
������� ����� �������:
0 - �����
1 - �������� �������� ������ ���� � ���������
2 - ������� ��������
3 - ���������, ����������� �� �������� ���������
4 - ���������� ������� �������� ��������� � ������������ �������
5 - ���������� ������� �������� ��������� � ������������ �������
INPUT: 1
������� ��������, ������� ����� ��������: 333
������� ��������
INPUT: 3
������� ��������, ������� ����� �����: 333
����� ������� ����
INPUT: ds
������������ ����, ���������� ��� ���
INPUT: 2
������� ��������, ������� ����� �������: dsa
������������ ����, ���������� ��� ���
INPUT: 333
���� ������� ��� � ���������, �� ������ ��� ���
INPUT: 222
�������� �������, ���������� ��� ���
INPUT: 5
��������� �����
INPUT: 0
*/