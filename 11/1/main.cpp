#include <iostream>
#include <fstream>
#include <string>
#include <locale>
#include "rabin-karp.h"

using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");
	string substring;
	cout << "Введите подстроку, которую надо найти: ";
	getline(cin, substring);
	ifstream file("input.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден" << endl;
		return 1;
	}
	string text;
	int i = 1;
	while (!file.eof())
	{
		getline(file, text);
		int position = subsringPositionInLine(text, substring);
		if (position >= 0)
		{
			cout << "Искомая подстрока находится в " << i << " строке, " << position + 1 << " позиции исходного файла" << endl;
			file.close();
			return 0;
		}
			++i;
	}
	cout << "Искомая подстрока не найдена в файле" << endl;
	file.close();
	return 0;
}
/*
Test 1
intput.txt: va ta ga
input: ga
OUTPUT: Искомая подстрока находится в 1 строке, 7 позиции исходного файла
___________________________________
Test 2
intput.txt: Bob and Tom are going to go
He is busy today
input: busy
OUTPUT: Искомая подстрока находится в 2 строке, 7 позиции исходного файла
___________________________________
Test 3
intput.txt: Bob and Tom are going to go
He is busy today
input: too
OUTPUT: Искомая подстрока не найдена в файле
*/