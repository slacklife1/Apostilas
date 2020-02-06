#include <stdio.h>

void main()
{
	char name[20];
	char color[20];

	printf("What is your name?");
	scanf("%s",name);
	printf("What is your favorite color?");
	scanf("%s",color);
	printf("%s's favorite color is %s\n",color,name);
}	