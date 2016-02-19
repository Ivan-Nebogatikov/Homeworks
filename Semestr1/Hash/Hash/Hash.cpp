#include <iostream>
#include "Hash.h"
#include "List.h"

using namespace std;

int const amount = 150;

struct Table
{
	List *array[amount];
};

Table *createTable()
{
	Table *table = new Table;
	for (int i = 0; i < amount; ++i)
	{
		table->array[i] = createList();
	}
	return table;
}

int hashFunction(string const &name)
{
	int hash = 0;
	int multiplier = 1;
	for (int i = 0; i < name.length(); ++i)
	{
		hash += (int)name[i] * multiplier;
		multiplier *= 31;
	}
	return (hash % amount + amount) % amount;
}

void add(Table *table, string const &word)
{
	List *list = table->array[hashFunction(word)];
	HashElement newElement;
	newElement.name = word;
	newElement.number = 1;
	insert(newElement, list);
}

void printTable(Table *table)
{
	for (int i = 0; i < amount; ++i)
	{
		printAllList(table->array[i]);
	}
}

void deleteHashTable(Table *table)
{
	for (int i = 0; i < amount; ++i)
	{
		clear(table->array[i]);
	}
	delete table;
}