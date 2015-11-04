#pragma once

typedef int TypeListElem;

struct ListElement;

struct PointerList;

//create new list
PointerList* createPointerList();

//add new element to list
void insert(TypeListElem newElement, PointerList *list);

//print all list elements
void printAllList(PointerList *list);

//clear all list
void clear(PointerList *list);

//sorting by merge sort algorithm
PointerList* mergeSort(PointerList *list);