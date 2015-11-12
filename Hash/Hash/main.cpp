#include <iostream>
#include <string>
#include "Hash.h"
#include <fstream>
#include <locale>

using namespace std;

void fileRead(Table *table)
{
	ifstream file("hash.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден" << endl;
		exit(0);
	}

	while (!file.eof())
	{
		string newWord;
		file >> newWord;
		add(table, newWord);
	}
	file.close();
}

int main()
{
	setlocale(LC_ALL, "Rus");
	Table *table = createTable();
	fileRead(table);
	printTable(table);
	deleteHashTable(table);
	return 0;
}
/*
Test 1
В папке с программой
_________________________________________
Test 2
INPUT:
no non none
non no no nonono
OUTPUT:
Слово: no встречается 3 раз
Слово: non встречается 2 раз
Слово: none встречается 1 раз
Слово: nonono встречается 1 раз
_________________________________________
Test 3
INPUT:
aaab baaa
baba afks sdadoaskafd
safdso fdsfassdapn aaab dsak
sadasldsdksp aaab
OUTPUT:
Слово: dsak встречается 1 раз
Слово: afks встречается 1 раз
Слово: safdso встречается 1 раз
Слово: sdadoaskafd встречается 1 раз
Слово: fdsfassdapn встречается 1 раз
Слово: sadasldsdksp встречается 1 раз
Слово: aaab встречается 3 раз
Слово: baaa встречается 1 раз
Слово: baba встречается 1 раз
*/