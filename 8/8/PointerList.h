#pragma once

typedef int TypeListElem;

struct ListElement;

struct PointerList;

//create new list
PointerList* createList();

//add new element to list
void insert(TypeListElem newElement, PointerList *list);

//print all list elements
void printAllList(PointerList *list);

//clear all list
void clear(PointerList *list);

//get list legdth
int getLength(PointerList *list);

//get element with given number
TypeListElem getElement(int number, PointerList *list);