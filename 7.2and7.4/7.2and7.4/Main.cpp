#include <iostream>
#include "Stack.h"
#include <locale.h>

using namespace std;

const int stringLength = 300;

int shuntingYard(char *string, char *postfixForm, Stack *stack)
{
	int length = 0;
	for (int i = 0; i < strlen(string); ++i)
	{
		switch (string[i])
		{
		case '1':
		case '2':
		case '3':
		case '4':
		case '5':
		case '6':
		case '7':
		case '8':
		case '9':
		case '0':
			postfixForm[length] = string[i];
			++length;
			break;
		case '+':
		case '-':
			while (top(stack) == '+' || top(stack) == '-' || top(stack) == '*' || top(stack) == '/')
			{
				postfixForm[length] = top(stack);
				++length;
				pop(stack);
			}
		case '*':
		case '/':
			while (!isEmpty(stack))
			{
				if (top(stack) == '*' || top(stack) == '/')
				{
					postfixForm[length] = top(stack);
					++length;
					pop(stack);
				}
				else
				{
					break;
				}
			}
			push(stack, string[i]);
			break;
		case '(':
			push(stack, '(');
			break;
		case ')':
			while (top(stack) != '(')
			{
				if (isEmpty(stack))
				{
					return -1;
				}
				postfixForm[length] = top(stack);
				++length;
				pop(stack);
			}
			pop(stack);
			break;
		case ' ':
			break;
		default:
			return -1;
			break;
		}
	}

	while (!isEmpty(stack))
	{
		if (top(stack) == '(')
		{
			return -1;
		}
		postfixForm[length] = top(stack);
		pop(stack);
		++length;
	}
	return length;
}

int calculation(char *postfixForm, Stack *stack, int length)
{
	int firstTop = 0;
	int secondTop = 0;
	for (int i = 0; i < length; ++i)
	{
		switch (postfixForm[i])
		{
		case '1':
		case '2':
		case '3':
		case '4':
		case '5':
		case '6':
		case '7':
		case '8':
		case '9':
		case '0':
			push(stack, postfixForm[i] - '0');
			break;
		case '+':
			firstTop = pop(stack);
			secondTop = pop(stack);
			push(stack, secondTop + firstTop);
			break;
		case '-':
			firstTop = pop(stack);
			secondTop = pop(stack);
			push(stack, secondTop - firstTop);
			break;
		case '*':
			firstTop = pop(stack);
			secondTop = pop(stack);
			push(stack, secondTop * firstTop);
			break;
		case '/':
			firstTop = pop(stack);
			secondTop = pop(stack);
			if (firstTop != 0)
			{
				push(stack, secondTop / firstTop);
			}
			else
			{
				return 2147483647;
			}
			break;
		}
	}
	return top(stack);
}

int main()
{
	setlocale(LC_ALL, "Rus");
	Stack *stack = createStack();
	cout << "������� ������ ��� ����������: ";
	char string[stringLength];
	cin.getline(string, stringLength);
	char postfixForm[stringLength];
	int length = shuntingYard(string, postfixForm, stack);
	if (length == -1)
	{
		cout << "������������ ���������" << endl;
		return 0;
	}
	cout << "����������� �����: ";
	for (int i = 0; i < length; ++i)
	{
		cout << postfixForm[i] << ' ';
	}
	cout << endl;

	deleteStack(stack);
	stack = createStack();
	int result = calculation(postfixForm, stack, length);
	if (result == 2147483647)
	{
		cout << "������: ������� �� 0"<< endl;
	}
	else
	{
		cout << "��������� ����������: " << result << endl;
	}
	deleteStack(stack);
	return 0;
}
/*
TEST 1
INPUT: 2+2+2+2
OUTPUT:
����������� �����: 2 2 + 2 + 2 +
��������� ����������: 8
_________________________________________
TEST 2
INPUT: 2/(2-3+1)
OUTPUT:
����������� �����: 2 2 3 - 1 + /
������: ������� �� 0
_________________________________________
TEST 3
INPUT: (2+2-4/5
OUTPUT:
������������ ���������
_________________________________________
TEST 4
INPUT:  2+4-8+(6/3-7)*3-0+8
OUTPUT:
����������� �����: 2 4 + 8 - 6 3 / 7 - 3 * + 0 - 8 +
��������� ����������: -9
*/