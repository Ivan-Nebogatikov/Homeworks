#include <iostream>
#include <fstream>
#include <locale>
#include "graph.h"

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

struct Edge
{
	int start;
	int destination;
	int length;
};

Edge getNearestNeighboringVertex(Graph* graph, bool used[], int start, int minLength)
{
	Edge vertex;
	vertex.destination = -1;
	vertex.start = start;
	vertex.length = minLength;
	for (int i = 0; i < getVertexNumber(graph); ++i)
	{
		if (hasEdge(graph, i, start) && !used[i])
		{
			if (getVertexColor(graph, i) == getVertexColor(graph, start))
			{
				used[i] = true;
				Edge newVertex = getNearestNeighboringVertex(graph, used, i, minLength);
				if (newVertex.destination != -1 && newVertex.length < minLength)
				{
					vertex = newVertex;
					minLength = newVertex.length;
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
						vertex.destination = i;
						vertex.start = start;
					}
				}
			}
		}
	}
	vertex.length = minLength;
	return vertex;
}

Graph* prim(Graph *graph)
{
	Graph* newGraph = createGraph(getVertexNumber(graph));
	setVertexColor(graph, 0, 1);
	for (int i = 0; i < getVertexNumber(graph) - 1; ++i)
	{
		bool used[maxNumber] = {};
		used[0] = true;
		Edge newVertex = getNearestNeighboringVertex(graph, used, 0, INT_MAX);
		if (newVertex.destination != -1 && newVertex.length != INT_MAX)
		{
			setVertexColor(graph, newVertex.destination, 1);
			setWeight(newGraph, newVertex.start, newVertex.destination, newVertex.length);
		}
	}
	return newGraph;
}

int main()
{
	setlocale(LC_ALL, "Rus");
	int n = 0;
	ifstream file("input.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден" << endl;
		return 0;
	}

	file >> n;
	if (file.fail())
	{
		cout << "Ошибка чтения файла" << endl;
		return 1;
	}
	Graph* graph = createGraph(n);
	for (int i  = 0; i < n; ++i)
	{
		for (int j = 0; j < n; ++j)
		{
			int newWeight = 0;
			file >> newWeight;
			if (file.fail())
			{
				cout << "Ошибка чтения файла" << endl;
				return 0;
			}
			setWeight(graph, i, j, newWeight);
		}
	}
	file.close();
	Graph* minTree = prim(graph);
	cout << "Минимальное остовное дерево в виде таблицы смежности: " << endl;
	printMatrix(minTree);
	deleteGraph(minTree);
	deleteGraph(graph);
	return 0;
}

/*
TEST 1
input:
5
0 1 2 0 0
1 0 3 5 0
2 3 0 0 0
0 5 0 0 8
0 0 0 8 0
OUTPUT:
Минимальное остовное дерево в виде таблицы смежности:
0 1 2 0 0
1 0 0 5 0
2 0 0 0 0
0 5 0 0 8
0 0 0 8 0
_______________________________________________
TEST 2
input:
7
0 7 0 5 0 0 0
7 0 8 9 7 0 0
0 8 0 0 5 0 0
5 9 0 0 15 6 0
0 7 5 15 0 8 9
0 0 0 6 8 0 4
0 0 0 0 9 4 0
OUTPUT:
Минимальное остовное дерево в виде таблицы смежности:
0 7 0 5 0 0 0
7 0 0 0 7 0 0
0 0 0 0 5 0 0
5 0 0 0 0 6 0
0 7 5 0 0 0 0
0 0 0 6 0 0 4
0 0 0 0 0 4 0
*/