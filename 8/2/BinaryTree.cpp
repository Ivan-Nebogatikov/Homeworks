#include <iostream>

struct Node
{
	int value;
	Node *left;
	Node *right;
};

struct Tree
{
	Node *root;
};

Tree* createTree()
{
	Tree *tree = new Tree;
	tree->root = nullptr;
	return tree;
}

void deleteNodes(Node *node)
{
	if (node != nullptr)
	{
		if (node->left != nullptr)
		{
			deleteNodes(node->left);
		}
		if (node->right != nullptr)
		{
			deleteNodes(node->right);
		}
		delete node;
	}
}

void deleteTree(Tree *tree)
{
	deleteNodes(tree->root);
	delete tree;
}

Node* createNode(int value)
{
	Node *newNode = new Node;
	newNode->value = value;
	newNode->left = nullptr;
	newNode->right = nullptr;
	return newNode;
}

void add(Node *&node, int value)
{
	if (node == nullptr)
	{
		node = createNode(value);
	}
	else
	{
		if (node->value == value)
		{
			return;
		}
		else
		{
			if (node->value < value)
			{
				add(node->right, value);
			}
			else
			{
				add(node->left, value);
			}
		}
	}
}

void addToTree(Tree *&tree, int value)
{
	add(tree->root, value);
}

bool exist(Node *node, int value)
{
	if (node == nullptr)
	{
		return false;
	}
	if (node->value == value)
	{
		return true;
	}
	if (node->value < value)
	{
		return exist(node->right, value);
	}
	else
	{
		return exist(node->left, value);
	}
}

bool existInTree(Tree *tree, int value)
{
	return exist(tree->root, value);
}

int getLeftLeafValueAndDeleteIt(Tree *tree, Node *node, Node *parent)
{
	while (node->left != nullptr || node->right != nullptr)
	{
		parent = node;
		if (node->left != nullptr)
		{
			node = node->left;
		}
		else
		{
			node = node->right;
		}
	}
	if (parent->value < node->value)
	{
		parent->right = nullptr;
	}
	else
	{
		parent->left = nullptr;
	}
	int value = node->value;
	delete node;
	return value;
}

void deleteNode(Tree *tree, Node *node, Node *parent, int value)
{
	if (node->value < value)
	{
		deleteNode(tree, node->right, node, value);
		return;
	}
	if (node->value > value)
	{
		deleteNode(tree, node->left, node, value);
		return;
	}

	if (node->left == nullptr && node->right == nullptr)
	{
		if (parent != nullptr)
		{
			if (parent->value < value)
			{
				parent->right = nullptr;
			}
			else
			{
				parent->left = nullptr;
			}
		}
		else
		{
			tree->root = nullptr;
		}
		delete node;
		return;
	}

	if (node->left != nullptr && node->right == nullptr)
	{
		if (parent != nullptr)
		{
			if (parent->value < value)
			{
				parent->right = node->left;
			}
			else
			{
				parent->left = node->left;
			}
		}
		else
		{
			tree->root = node->left;
		}
		delete node;
		return;
	}

	if (node->left == nullptr && node->right != nullptr)
	{
		if (parent != nullptr)
		{
			if (parent->value < value)
			{
				parent->right = node->right;
			}
			else
			{
				parent->left = node->right;
			}
		}
		else
		{
			tree->root = node->right;
		}
		delete node;
		return;
	}
	node->value = getLeftLeafValueAndDeleteIt(tree, node->right, node);
}

void deleteFromTree(Tree *tree, int value)
{
	deleteNode(tree, tree->root, nullptr, value);
}

void printIncreasingNodes(Node *node)
{
	if (node->left != nullptr)
	{
		printIncreasingNodes(node->left);
	}
	std::cout << node->value << ' ';
	if (node->right != nullptr)
	{
		printIncreasingNodes(node->right);
	}
}

void printIncreasingTreeNodes(Tree *tree)
{
	printIncreasingNodes(tree->root);
	std::cout << std::endl;
}

void printDecreasingNodes(Node *node)
{
	if (node->right != nullptr)
	{
		printDecreasingNodes(node->right);
	}
	std::cout << node->value << ' ';
	if (node->left != nullptr)
	{
		printDecreasingNodes(node->left);
	}
}

void printDecreasingTreeNodes(Tree *tree)
{
	printDecreasingNodes(tree->root);
	std::cout << std::endl;
}

bool isTreeEmpty(Tree *tree)
{
	return tree->root == nullptr;
}