#pragma once

typedef int TypeListElem;

int const MAXNUMBER = 1000;

struct ListElement;

struct ArrayList;

//create new list
ArrayList* createList();

//add new element to list
void insert(TypeListElem newElement, ArrayList *list);

//print all list elements
void printAllList(ArrayList *list);

//clear all list
void clear(ArrayList *list);

//get list legdth
int getLength(ArrayList *list);

//get element with given number
TypeListElem getElement(int number, ArrayList *list);