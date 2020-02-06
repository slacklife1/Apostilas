#include <stdio.h>

void intro(char *name);

void main()
{
	char me[20];

	printf("What is your name?");
	scanf("%s",me);
	intro(me);
}

void intro(char *name)
{
	printf("Darn glad to meet you, %s!\n",name);
}