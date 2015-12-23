#include <string>

const int base = 101;

unsigned __int64 getSubstringHash(std::string substring)
{
	unsigned __int64 hash = 0;
	for (int i = 0; i < substring.length(); ++i)
	{
		hash += substring[substring.length() - i - 1] * pow(base, i);
	}
	return hash;
}

int subsringPositionInLine(std::string text, std::string substring)
{
	unsigned __int64 substringHash = getSubstringHash(substring);
	unsigned __int64 stringHash = 0;
	for (int i = 0; i < substring.length(); ++i)
	{
		stringHash += text[substring.length() - i - 1] * pow(base, i);
	}
	for (int i = 0; i < text.length() - substring.length() + 1; ++i)
	{
		if (stringHash == substringHash)
		{
			return i;
		}
		stringHash -= text[i] * pow(base, substring.length() - 1);
		stringHash = stringHash * base + text[substring.length() + i];
	}
	return -1;
}