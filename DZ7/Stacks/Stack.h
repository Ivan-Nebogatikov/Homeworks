#pragma once

typedef char TypeStackElement;

struct StackElement;

struct Stack;

//create clean new stack
Stack* createStack();

//push new element to stack
void push(Stack *stack, TypeStackElement number);

//get top element and delete one
TypeStackElement pop(Stack *stack);

//get top element in the stack
TypeStackElement top(Stack *stack);

//clear all stack
void deleteStack(Stack *stack);

//check is stack empty
bool isEmpty(Stack *stack);