#include <iostream>
#include <locale>

using namespace std;

bool isRealNumber(std::string number)
{
	int state = 0;
	for (int i = 0; i < number.length(); ++i)
	{
		switch (state)
		{
		case 0:
			if (isdigit(number[i]))
				state = 1;
			else
				return false;
			break;

		case 1:
			if (isdigit(number[i]))
				state = 1;
			else
				if (number[i] == '.')
					state = 2;
				else
					return false;
			break;

		case 2:
			if (isdigit(number[i]))
				state = 3;
			else
				return false;
			break;

		case 3:
			if (isdigit(number[i]))
				state = 3;
			else
				if (number[i] == 'E')
					state = 4;
				else
					return false;
			break;

		case 4:
			if (number[i] == '+' || number[i] == '-')
				state = 5;
			else
				if (isdigit(number[i]))
					state = 6;
				else
					return false;
			break;

		case 5:
			if (isdigit(number[i]))
				state = 6;
			else
				return false;
			break;

		case 6:
			if (isdigit(number[i]))
				state = 6;
			else
				return false;
		}
	}
	return (!(state == 2) && !(state == 4) && !(state == 5));
}

int main()
{
	setlocale(LC_ALL, "Rus");
	string number;
	cout << "������� �����: ";
	cin >> number;
	if (isRealNumber(number))
		cout << "��� ������������ �����!" << endl;
	else
		cout << "��� �������������� �����!" << endl;
	return 0;
}
/*
Test 1
������� �����: 1.1111
��� ������������ �����!
__________________________________
Test 2
������� �����: 1.1E-1
��� ������������ �����!
__________________________________
Test 3
������� �����: 1.3E
��� �������������� �����!
__________________________________
Test 4
������� �����: 6tw
��� �������������� �����!
__________________________________
Test 5
������� �����: 4564.4568E+4645-12
��� �������������� �����!
__________________________________
Test 6
������� �����: 4.55.66
��� �������������� �����!
__________________________________
*/