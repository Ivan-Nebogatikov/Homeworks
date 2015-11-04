#pragma once
#include <cstdio>

struct Tree;

struct Node;

//create new empty tree
Tree* createTree();

//delete all tree
void deleteTree(Tree *tree);

//read tree from file
void readTree(Tree *tree, FILE *file);

//print all tree
void printTree(Tree *tree);

//calculate expression in the tree
int calculateTree(Tree *tree);