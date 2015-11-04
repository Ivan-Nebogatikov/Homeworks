#include <iostream>
#include <locale>
#include "Tree.h"

using namespace std;

const int maxNumber = 300;

int main()
{
	setlocale(LC_ALL, "Rus");
	FILE *file = fopen("tree.txt", "r");
	if (file == nullptr)
	{
		cout << "���� �� ������" << endl;
		return 0;
	}
	Tree *tree = createTree();
	readTree(tree, file);
	fclose(file);
	printTree(tree);
	cout << endl;
	int calculation = calculateTree(tree);
	if (calculation == 2147483647)
	{
		cout << "������� �� 0" << endl;
	}
	else
	{
		cout << "��������� ���������� ������� ������: " << calculation << endl;
	}
	deleteTree(tree);
	return 0;
}
/*
Test 1
INPUT: (/ (+ 2 2) (- 2 2))
(/ (+ 2 2 ) (- 2 2 ) )
������� �� 0
__________________________
Test 2
INPUT: (* (+ 1 1) 2)
(* (+ 1 1 ) 2 )
��������� ���������� ������� ������: 4
__________________________
Test 3
INPUT: (+ (- (/ 4 2) 5) (* 4 (- 8 6)))
(+ (- (/ 4 2 ) 5 ) (* 4 (- 8 6 ) ) )
��������� ���������� ������� ������: 5
*/