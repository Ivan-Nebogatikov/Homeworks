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
		cout << "Файл не найден" << endl;
		return 0;
	}
	Tree *tree = createTree();
	readTree(tree, file);
	fclose(file);
	printTree(tree);
	cout << endl;
	int calculation = calculateTree(tree);
	if (calculation == INT_MAX)
	{
		cout << "Деление на 0" << endl;
	}
	else
	{
		cout << "Результат вычисления обходом дерева: " << calculation << endl;
	}
	deleteTree(tree);
	return 0;
}
/*
Test 1
INPUT: (/ (+ 2 2) (- 2 2))
(/ (+ 2 2 ) (- 2 2 ) )
Деление на 0
__________________________
Test 2
INPUT: (* (+ 1 1) 2)
(* (+ 1 1 ) 2 )
Результат вычисления обходом дерева: 4
__________________________
Test 3
INPUT: (+ (- (/ 4 2) 5) (* 4 (- 8 6)))
(+ (- (/ 4 2 ) 5 ) (* 4 (- 8 6 ) ) )
Результат вычисления обходом дерева: 5
*/