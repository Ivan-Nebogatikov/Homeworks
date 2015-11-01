#pragma once
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
	delete list;
}

void insert(TypeListElem newElement, List *list)
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
		list->head = list->tail = temp;
	}
	list->length++;
}

void printAllList(List *list)
{
	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		std::cout << temp->element.name << " " << temp->element.number;
		temp = temp->next;
		std::cout << std::endl;
	}
}

List* partOfList(int left, int right, List *list)
{
	List *newList = createList();
	ListElement *temp = list->head;
	for (int i = 1; i < left; ++i)
	{
		temp = temp->next;
	}
	for (int i = left; i <= right; ++i)
	{
		insert(temp->element, newList);
		temp = temp->next;
	}
	return newList;
}

List* merge(bool isSoringNumbers, List *firstList, List *secondList)
{
	List *result = createList();
	ListElement *firstTemp = firstList->head;
	ListElement *secondTemp = secondList->head;
	while (firstTemp != nullptr && secondTemp != nullptr)
	{
		if (isSoringNumbers && firstTemp->element.number < secondTemp->element.number || 
			!isSoringNumbers && firstTemp->element.name < secondTemp->element.name)
		{
			insert(firstTemp->element, result);
			firstTemp = firstTemp->next;
		}
		else
		{
			insert(secondTemp->element, result);
			secondTemp = secondTemp->next;
		}
	}
	while (firstTemp != nullptr)
	{
		insert(firstTemp->element, result);
		firstTemp = firstTemp->next;
	}
	while (secondTemp != nullptr)
	{
		insert(secondTemp->element, result);
		secondTemp = secondTemp->next;
	}
	return result;
}

List* mergeSort(bool isSoringNumbers, List *list)
{
	if (list->length < 2)
		return list;
	List *firstList = partOfList(1, list->length / 2, list);
	List *secondList = partOfList(list->length / 2 + 1, list->length, list);
	
	clear(list);
	List *firstSortedList = mergeSort(isSoringNumbers, firstList);
	List *secondSortedList = mergeSort(isSoringNumbers, secondList);
	List *result = merge(isSoringNumbers, firstSortedList, secondSortedList);
	clear(firstSortedList);
	clear(secondSortedList);
	return result;
}