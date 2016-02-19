#pragma once

struct Tree;

struct Node;

// create new empty tree
Tree* createTree();

// delete tree
void deleteTree(Tree *tree);

// add new element to Binary Search Tree
void addToTree(Tree *&tree, int value);

// check is number exist in the Tree
bool existInTree(Tree *tree, int value);

// delete node from tree
void deleteFromTree(Tree *tree, int value);

// print all tree in increasing dependence
void printIncreasingTreeNodes(Tree *tree);

// print all tree in decreasing dependence
void printDecreasingTreeNodes(Tree *tree);

// check is tree empty
bool isTreeEmpty(Tree *tree);