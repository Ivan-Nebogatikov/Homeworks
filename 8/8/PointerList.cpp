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

PointerList* createPointerList()
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
		list->head = list->tail = temp;
	}
	list->length++;
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

PointerList* partOfList(int left, int right, PointerList *list)
{
	PointerList *newList = createPointerList();
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

PointerList* merge(PointerList *firstList, PointerList *secondList)
{
	PointerList *result = createPointerList();
	ListElement *firstTemp = firstList->head;
	ListElement *secondTemp = secondList->head;
	while (firstTemp != nullptr && secondTemp != nullptr)
	{
		if (firstTemp->element < secondTemp->element)
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

PointerList* mergeSort(PointerList *list)
{
	if (list->length < 2)
		return list;
	PointerList *firstList = partOfList(1, list->length / 2, list);
	PointerList *secondList = partOfList(list->length / 2 + 1, list->length, list);

	clear(list);
	PointerList *firstSortedList = mergeSort(firstList);
	PointerList *secondSortedList = mergeSort(secondList);
	PointerList *result = merge(firstSortedList, secondSortedList);
	clear(firstSortedList);
	clear(secondSortedList);
	return result;
}