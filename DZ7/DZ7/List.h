#pragma once

struct NumberCase
{
	std::string name;
	unsigned __int64 number;
};

typedef NumberCase TypeListElem;

struct ListElement;

struct List;

//create new list
List* createList();

//add new element to list
void insert(TypeListElem newElement, List *list);

//print all list elements
void printAllList(List *list);

//clear all list
void clear(List *list);

//sorting by merge sort algorithm (isSortingNumbers is true when we should sort by numbers, else we sort by names)
List* mergeSort(bool isSoringNumbers, List *list);