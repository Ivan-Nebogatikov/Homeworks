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
};

List* createList()
{
	List *list = new List;
	list->head = nullptr;
	list->tail = nullptr;
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

bool existInList(TypeListElem const &sample, List *list)
{
	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		if (temp->element.name == sample.name)
		{
			return true;
		}
		temp = temp->next;
	}
	return false;
}

void IncNumber(TypeListElem const &sample, List *list)
{
	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		if (temp->element.name == sample.name)
		{
			temp->element.number++;
			return;
		}
		temp = temp->next;
	}
}

void insert(TypeListElem const &newElement, List *list)
{
	ListElement *temp = new ListElement;
	temp->next = nullptr;
	temp->element = newElement;

	if (list->head != nullptr)
	{
		if (existInList(newElement, list))
		{
			delete temp;
			IncNumber(newElement, list);
			return;
		}
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
}

void printAllList(List *list)
{
	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		std::cout <<"�����: " << temp->element.name << " ����������� " << temp->element.number << " ���";
		temp = temp->next;
		std::cout << std::endl;
	}
}