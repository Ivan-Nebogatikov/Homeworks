#include <iostream>
#include "Stack.h"
#include <locale.h>  

using namespace std;

bool isStringCorrect(char *bracketSting, Stack *stack)
{
	for (int i = 0; i < strlen(bracketSting); ++i)
	{
		if (bracketSting[i] == '{' || bracketSting[i] == '[' || bracketSting[i] == '(')
		{
			push(stack, bracketSting[i]);
		}
		else
		{
			if ((bracketSting[i] == '}' && top(stack) == '{') ||
				(bracketSting[i] == ')' && top(stack) == '(') ||
				(bracketSting[i] == ']' && top(stack) == '['))
			{
				pop(stack);
			}
			else
			{
				return false;
			}
		}
	}
	return isEmpty(stack);
}

int main()
{
	setlocale(LC_ALL, "Rus");
	Stack *stack = createStack();

	const int maxSymbols = 300;
	char bracketSting[maxSymbols] = {};
	cout << "Введите строку из скобок: ";	
	cin.getline(bracketSting, maxSymbols);

	cout << (isStringCorrect(bracketSting, stack) ? "Скобки правильны!" : "Скобки неправильны!") << endl;
	deleteStack(stack);
	return 0;
}
/*
TEST 1
INPUT: {([])}[][][]()[]{}
OUTPUT: Скобки правильны!
__________________________________________________________________________________
TEST 2
INPUT: {}}{{}{}{
OUTPUT: Скобки неправильны!
__________________________________________________________________________________
TEST 3
INPUT: ]]]]}}}}}))))
OUTPUT: Скобки неправильны!
*/