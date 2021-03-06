#include <iostream>
#include "List.h"
#include <fstream>

struct ListElement
{
	ListElement *prev;
	TypeListElem element;
	ListElement *next;
};

struct List
{
	ListElement *head;
	ListElement *tail;
	int length;
};

List* createList()
{
	List *list = new List;
	list->head = nullptr;
	list->tail = nullptr;
	list->length = 0;
	return list;
}

void clear(List *list)
{
	ListElement *temp = list->head;
	ListElement *secTemp = temp;
	while (temp != nullptr)
	{
		secTemp = temp->next;
		delete temp;
		temp = secTemp;
	}
	delete temp;
	delete secTemp;
	delete list;
}

void insert(TypeListElem const &newElement, List *list)
{
	ListElement *temp = new ListElement;
	temp->next = nullptr;
	temp->element = newElement;

	if (list->head != nullptr)
	{
		temp->prev = list->tail;
		list->tail->next = temp;
		list->tail = temp;
	}
	else
	{
		temp->prev = nullptr;
		list->head = temp;
		list->tail = temp;
	}
	list->length++;
}

void printAllListToFile(List *list, std::string const&nameOfFile)
{
	std::ofstream file(nameOfFile, std::ios::app);
	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		file << temp->element << ' ';
		temp = temp->next;
	}
	file.close();
}

int getLength(List *list)
{
	return list->length;
}

TypeListElem getElement(List *list, int number)
{
	ListElement *temp = list->head;
	for (int i = 0; i < number; ++i)
	{
		temp = temp->next;
		if (temp == nullptr)
		{
			return -1;
		}
	}
	return temp->element;
}