#include <iostream>
#include "Graph.h"

using namespace std;

struct Graph
{
	int **array;
	int vertexNumber;
};

Graph* createGraph(int vertex)
{
	Graph *graph = new Graph;
	graph->array = new int*[vertex];
	for (int i = 0; i < vertex; ++i)
	{
		graph->array[i] = new int[vertex];
	}
	for (int i = 0; i < vertex; ++i)
	{
		for (int j = 0; j < vertex; ++j)
		{
			graph->array[i][j] = 0;
		}
	}
	graph->vertexNumber = vertex;
	return graph;
}

void setWeight(Graph* graph, int vertex1, int vertex2, int weight)
{
	graph->array[vertex1][vertex2] = weight;
	graph->array[vertex2][vertex1] = weight;
}

int getWeight(Graph* graph, int vertex1, int vertex2)
{
	return graph->array[vertex1][vertex2];
}

bool hasEdge(Graph* graph, int vertex1, int vertex2)
{
	return graph->array[vertex1][vertex2] > 0;
}

int getVertexNumber(Graph* graph)
{
	return graph->vertexNumber;
}

void setVertexColor(Graph* graph, int vertex, int color)
{
	graph->array[vertex][vertex] = color + 1;
}

int getVertexColor(Graph* graph, int vertex)
{
	return graph->array[vertex][vertex] - 1;
}

void deleteGraph(Graph* graph)
{
	for (int i = 0; i < graph->vertexNumber; ++i)
	{
		delete graph->array[i];
	}
	delete graph->array;
	delete graph;
}