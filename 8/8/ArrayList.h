#pragma once

typedef int TypeListElem;

int const MAXNUMBER = 1000;

struct ArrayList;

//create new list
ArrayList* createArrayList();

//add new element to list
void insert(TypeListElem newElement, ArrayList *list);

//print all list elements
void printAllList(ArrayList *list);

//clear all list
void clear(ArrayList *list);

//sorting by merge sort algorithm
ArrayList* mergeSort(ArrayList *list);