#pragma once
#include <iostream>
#include "PointerList.h"

struct ListElement
{
	ListElement *prev;
	TypeListElem element;
	ListElement *next;
};

struct PointerList
{
	ListElement *head;
	ListElement *tail;
	int length;
};

PointerList* createList()
{
	PointerList *list = new PointerList;
	list->head = nullptr;
	list->tail = nullptr;
	list->length = 0;
	return list;
}

void clear(PointerList *list)
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

void insert(TypeListElem newElement, PointerList *list)
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

int getLength(PointerList *list)
{
	return list->length;
}

TypeListElem getElement(int number, PointerList *list)
{
	ListElement *temp = list->head;
	for (int i = 0; i < number; ++i)
	{
		if (temp != nullptr)
			temp = temp->next;
	}
	return temp->element;
}

void printAllList(PointerList *list)
{
	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		std::cout << temp->element << ' ';
			temp = temp->next;
	}
	std::cout << std::endl;
}