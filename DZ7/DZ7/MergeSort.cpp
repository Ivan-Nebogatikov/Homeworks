#include "List.h"
#include <string>

List* partOfList(int left, int right, List *list)
{
	List *newList = createList();
	for (int i = left; i < right; ++i)
	{
		insert(getElement(i, list), newList);
	}
	return newList;
}

List* merge(bool isSoringNumbers, List *firstList, List *secondList)
{
	List *result = createList();

	int i = 0;
	int j = 0;

	while (i != getLength(firstList) && j != getLength(secondList))
	{
		TypeListElem firstElement = getElement(i, firstList);
		TypeListElem secondElement = getElement(j, secondList);
		if (isSoringNumbers && firstElement.number < secondElement.number ||
			!isSoringNumbers && firstElement.name < secondElement.name)
		{
			insert(firstElement, result);
			++i;
		}
		else
		{
			insert(secondElement, result);
			++j;
		}
	}

	while (i != getLength(firstList))
	{
		insert(getElement(i, firstList), result);
		++i;
	}

	while (j != getLength(secondList))
	{
		insert(getElement(j, secondList), result);
		++j;
	}

	return result;
}

List* mergeSort(bool isSoringNumbers, List *list)
{
	if (getLength(list) < 2)
		return list;
	List *firstList = partOfList(0, getLength(list) / 2, list);
	List *secondList = partOfList(getLength(list) / 2, getLength(list), list);

	clear(list);
	List *firstSortedList = mergeSort(isSoringNumbers, firstList);
	List *secondSortedList = mergeSort(isSoringNumbers, secondList);
	List *result = merge(isSoringNumbers, firstSortedList, secondSortedList);
	clear(firstSortedList);
	clear(secondSortedList);
	return result;
}