#include <stdio.h>

void main()
{
	char kitty[20];

	printf("What would you like to name your cat?");
	gets(kitty);
	printf("%s is a nice name. What else do you have in mind?",kitty);
	gets(kitty);
	printf("%s is nice, too.\n",kitty);
}