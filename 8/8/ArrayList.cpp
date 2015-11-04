#include <iostream>
#include <algorithm>
#include "ArrayList.h"

struct ArrayList
{
	int length;
	TypeListElem element[MAXNUMBER];
};

ArrayList* createArrayList()
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

ArrayList* partOfList(int left, int right, ArrayList *list)
{
	ArrayList *newList = createArrayList();
	for (int i = left; i < right; ++i)
	{
		insert(list->element[i], newList);
	}
	return newList;
}

ArrayList* merge(ArrayList *firstList, ArrayList *secondList)
{
	ArrayList *result = createArrayList();
	int i = 0;
	int j = 0;
	while (i < std::min(firstList->length, secondList->length) && j < std::min(firstList->length, secondList->length))
	{
		if (firstList->element[i] < secondList->element[j])
		{
			insert(firstList->element[i], result);
			++i;
		}
		else
		{
			insert(secondList->element[j], result);
			++j;
		}
	}
	while (i < firstList->length)
	{
		insert(firstList->element[i], result);
		++i;
	}
	while (j < secondList->length)
	{
		insert(secondList->element[j], result);
		++j;
	}
	return result;
}

ArrayList* mergeSort(ArrayList *list)
{
	if (list->length < 2)
		return list;
	ArrayList *firstList = partOfList(0, list->length / 2, list);
	ArrayList *secondList = partOfList(list->length / 2, list->length, list);

	clear(list);
	ArrayList *firstSortedList = mergeSort(firstList);
	ArrayList *secondSortedList = mergeSort(secondList);
	ArrayList *result = merge(firstSortedList, secondSortedList);
	clear(firstSortedList);
	clear(secondSortedList);
	return result;
}