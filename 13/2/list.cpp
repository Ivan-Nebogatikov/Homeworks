#include <iostream>
#include "List.h"
#include <string>

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
}

void clearList(List *list)
{
	clear(list);
	list->head = nullptr;
	list->tail = nullptr;
	list->length = 0;
}


void deleteList(List *list)
{
	clear(list);
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

void printAllList(List *list)
{
	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		std::cout << temp->element;
		temp = temp->next;
	}
}