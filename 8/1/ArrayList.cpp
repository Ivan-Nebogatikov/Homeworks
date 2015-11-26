#include <iostream>
#include "ArrayList.h"

int const MAXNUMBER = 1000;

struct ArrayList
{
	int length;
	TypeListElem element[MAXNUMBER];
};

ArrayList* createList()
{
	ArrayList *list = new ArrayList();
	list->length = 0;
	for (int i = 0; i < MAXNUMBER; ++i)
	{
		list->element[i] = 0;
	}
	return list;
}

void clear(ArrayList *list)
{
	delete list;
}

void insert(TypeListElem newElement, ArrayList *list)
{
	list->element[list->length] = newElement;
	list->length++;
}

void printAllList(ArrayList *list)
{
	for (int i = 0; i < list->length; ++i)
	{
		std::cout << list->element[i] << ' ';
	}
	std::cout << std::endl;
}

int getLength(ArrayList *list)
{
	return list->length;
}

TypeListElem getElement(int number, ArrayList *list)
{
	return list->element[number];
}