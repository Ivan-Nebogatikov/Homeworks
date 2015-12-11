#pragma once
#include <string>

typedef char TypeListElem;

struct ListElement;

struct List;

// create new list
List* createList();

// add new element to list
void insert(TypeListElem const &newElement, List *list);

// print all list elements
void printAllList(List *list);

// clear all list
void clearList(List *list);

// delete list
void deleteList(List *list);