#pragma once
#include <iostream>
#include "Hash.h"
#include <string>

struct Table;

//create new hash Table
Table* createTable();

//add new word to hash table
void add(Table *table, std::string const &word);

//print all elements from hash table
void printTable(Table *table);

//delete hash table
void deleteHashTable(Table *table);