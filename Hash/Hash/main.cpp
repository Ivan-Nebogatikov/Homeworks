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
		cout << "���� �� ������" << endl;
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
� ����� � ����������
_________________________________________
Test 2
INPUT:
no non none
non no no nonono
OUTPUT:
�����: no ����������� 3 ���
�����: non ����������� 2 ���
�����: none ����������� 1 ���
�����: nonono ����������� 1 ���
_________________________________________
Test 3
INPUT:
aaab baaa
baba afks sdadoaskafd
safdso fdsfassdapn aaab dsak
sadasldsdksp aaab
OUTPUT:
�����: dsak ����������� 1 ���
�����: afks ����������� 1 ���
�����: safdso ����������� 1 ���
�����: sdadoaskafd ����������� 1 ���
�����: fdsfassdapn ����������� 1 ���
�����: sadasldsdksp ����������� 1 ���
�����: aaab ����������� 3 ���
�����: baaa ����������� 1 ���
�����: baba ����������� 1 ���
*/