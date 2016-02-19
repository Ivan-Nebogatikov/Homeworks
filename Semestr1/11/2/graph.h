#pragma once

struct Graph;

// create new graph
Graph* createGraph(int vertex);

// create or change graph edge
void setWeight(Graph* graph, int vertex1, int vertex2, int weight);

// get edge weight between vertex1 and vertex2
int getWeight(Graph* graph, int vertex1, int vertex2);

// return true if edge between vertex1 and vertex2 is exist
bool hasEdge(Graph* graph, int vertex1, int vertex2);

// get size of graph
int getVertexNumber(Graph* graph);

// set new color for vertex
void setVertexColor(Graph* graph, int vertex, int color);

// get vertex color
int getVertexColor(Graph* graph, int vertex);

// delete graph
void deleteGraph(Graph* graph);