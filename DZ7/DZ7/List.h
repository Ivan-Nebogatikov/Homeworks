#pragma once
#include <string> 

struct NumberCase
{
	std::string name;
	std::string number;
};

typedef NumberCase TypeListElem;

struct ListElement;

struct List;

//create new list
List* createList();

//add new element to list
void insert(TypeListElem const &newElement, List *list);

//print all list elements
void printAllList(List *list);

//clear all list
void clear(List *list);

//get list legdth
int getLength(List *list);

//get element with given number
TypeListElem getElement(int number, List *list);