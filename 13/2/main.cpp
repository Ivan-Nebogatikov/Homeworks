#include <iostream>
#include <locale>
#include <string>
#include "list.h"

using namespace std;

const int states[3][4] = {{ 1, 0, 2, 0 },
						  { 0, 2, 3, 2 },
						  { 0, 0, 2, 2 }
						 };

const bool output[3][4] = { {false, false, true, true},
							{false, true, true, true},
							{false, false, true, true} 
						  };

int gettableIndex(char symbol)
{
	if (symbol == '/')
		return 0;
	else
		if (symbol == '*')
			return 1;
		else
			return 2;
}

int newState(int state, char symbol)
{
	return states[gettableIndex(symbol)][state];
}

bool isOutput(int state, int symbol, List *list)
{
	if (symbol == '*' && state == 1)
		insert('/', list);
	return output[gettableIndex(symbol)][state];
}

int main()
{
	setlocale(LC_ALL, "Rus");
	FILE *file = fopen("input.txt", "r");
	if (file == nullptr)
	{
		cout << "Файл не найден" << endl;
		return 0;
	}
	int state = 0;
	List *list = createList();
	while (!feof(file))
	{
		char newChar;
		newChar = getc(file);
		if (isOutput(state, newChar, list))
			insert(newChar, list);
		else 
		{
			printAllList(list);
			clearList(list);
		}
		state = newState(state, newChar);
	}
	cout << endl;
	return 0;
}