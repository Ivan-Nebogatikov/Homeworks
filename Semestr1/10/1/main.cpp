#include <iostream>
#include <fstream>
#include <locale>
#include "Graph.h"

using namespace std;

const int maxNumber = 50;

void printMatrix(Graph* graph)
{
	for (int i = 0; i < getVertexNumber(graph); ++i)
	{
		for (int j = 0; j < getVertexNumber(graph); ++j)
		{
			cout << getWeight(graph, i, j) << " ";
		}
		cout << endl;
	}
}

int getNearestNeighboringVertex(Graph* graph, bool used[], int start, int &minLength)
{
	int vertex = -1;
	for (int i = 0; i < getVertexNumber(graph); ++i)
	{
		if (hasEdge(graph, i, start) && !used[i])
		{
			if (getVertexColor(graph, i) == getVertexColor(graph, start))
			{
				used[i] = true;
				int newVertex = getNearestNeighboringVertex(graph, used, i, minLength);
				if (newVertex != -1)
				{
					vertex = newVertex;
				}
			}
			else
			{
				if (getVertexColor(graph, i) == -1)
				{
					int newLength = getWeight(graph, start, i);
					if (newLength < minLength)
					{
						minLength = newLength;
						vertex = i;
					}
				}
			}
		}
	}
	return vertex;
}

int getNearestCityToCountry(Graph* graph, int currCountry)
{
	bool used[maxNumber] = {};
	for (int i = 0; i < getVertexNumber(graph); ++i)
	{
		if (getVertexColor(graph, i) == currCountry)
		{
			used[i] = true;
			int minLength = INT_MAX;
			return getNearestNeighboringVertex(graph, used, i, minLength);
		}
	}
}

void setCitiesToCountries(Graph *graph, int k)
{
	int currCountry = 0;
	int count = 0;
	while (count < getVertexNumber(graph) - k)
	{
		int newCity = getNearestCityToCountry(graph, currCountry);
		if (newCity == -1)
		{
			++currCountry;
			currCountry = currCountry % k;
			continue;
		}
		++count;
		setVertexColor(graph, newCity, currCountry);
		++currCountry;
		currCountry = currCountry % k;
	}
}

void printCountry(Graph *graph, int currCountry)
{
	bool used[maxNumber] = {};
	for (int i = 0; i < getVertexNumber(graph); ++i)
	{
		if (!used[i] && getVertexColor(graph, i) == currCountry)
		{
			used[i] = true;
			cout << i + 1 << ' ';
		}
	}
}

void printCountries(Graph *graph, int k)
{
	for (int i = 0; i < k; ++i)
	{
		cout << "Государство номер " << i + 1 << ": ";
		printCountry(graph, i);
		cout << endl;
	}
}

int main()
{
	setlocale(LC_ALL, "Rus");
	int n = 0;
	int m = 0;
	ifstream file("input.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден" << endl;
		return 1;
	}

	file >> n >> m;
	if (file.fail())
	{
		cout << "Ошибка чтения файла" << endl;
		return 1;
	}
	Graph* graph = createGraph(n);
	for (int k = 0; k < m; ++k)
	{
		int i = 0;
		int j = 0;
		int len = 0;
		file >> i >> j >> len;
		if (file.fail())
		{
			cout << "Ошибка чтения файла" << endl;
			return 1;
		}
		setWeight(graph, i - 1, j - 1, len);
	}
	cout << "Граф в виде таблицы смежности: " << endl;
	printMatrix(graph);

	int k = 0;
	file >> k;
	if (file.fail())
	{
		cout << "Ошибка чтения файла" << endl;
		return 1;
	}
	for (int i = 0; i < k; ++i)
	{
		int index = 0;
		file >> index;
		if (file.fail())
		{
			cout << "Ошибка чтения файла" << endl;
			return 1;
		}
		setVertexColor(graph, index - 1, i);
	}
	file.close();
	setCitiesToCountries(graph, k);
	printCountries(graph, k);
	deleteGraph(graph);
	return 0;
}
/*
		TEST 1
input:
5 5
1 2 1
1 3 2
2 3 3
2 4 5
4 5 8
2
1
4
OUTPUT:
Государство номер 1: 1 2 3
Государство номер 2: 4 5
_______________________________________________
		TEST 2
input:
7 9
1 2 5
1 3 8
2 3 4
3 4 3
4 5 5
3 5 2
7 3 10
7 6 4
6 5 6
3
1
3
6
OUTPUT:
Государство номер 1: 1 2
Государство номер 2: 3 4 5
Государство номер 3: 6 7
_______________________________________________
		TEST 3
input:
3 3
1 2 5
2 3 6
1 3 6
1
1
OUTPUT:
Государство номер 1: 1 2 3
*/
