#include "Stack.h"

struct StackElement {
	TypeStackElement value;
	StackElement *next;
};

struct Stack {
	StackElement *head;
};

Stack* createStack()
{
	Stack *stack = new Stack;
	stack->head = nullptr;
	return stack;
}

void push(Stack *stack, TypeStackElement number)
{
	StackElement *newElement = new StackElement;
	newElement->value = number;
	newElement->next = stack->head;
	stack->head = newElement;
};

TypeStackElement pop(Stack *stack)
{
	if (stack->head == nullptr)
	{
		return -1;
	}
	TypeStackElement value = stack->head->value;
	StackElement *temp = stack->head->next;
	delete stack->head;
	stack->head = temp;
	return value;
}

TypeStackElement top(Stack *stack)
{
	if (stack->head == nullptr)
	{
		return -1;
	}
	return stack->head->value;
}

void deleteStack(Stack *stack)
{
	while (stack->head != nullptr)
	{
		StackElement *temp = stack->head;
		stack->head = stack->head->next;
		delete temp;
	}
}

bool isEmpty(Stack *stack)
{
	if (stack->head != nullptr)
		return false;
	return true;
}