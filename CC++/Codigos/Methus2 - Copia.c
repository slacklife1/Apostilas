#include <stdio.h>

void main()
{
	int age;
	char years[8];

	printf("How old was Methuselah?");
	gets(years);
	age=atoi(years);
	printf("Methuselah was %i years old.\n",age);
}
