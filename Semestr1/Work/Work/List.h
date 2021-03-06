#pragma once
#include <string> 

typedef int TypeListElem;

struct ListElement;

struct List;

// create new list
List* createList();

// add new element to list
void insert(TypeListElem const &newElement, List *list);

// print all list elements to file
void printAllListToFile(List *list, std::string const&nameOfFile);

// clear all list
void clear(List *list);