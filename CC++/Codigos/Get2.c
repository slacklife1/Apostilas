#include <stdio.h>
#include <conio.h>

void main()
{
	char a,b;

	printf("Type a character:");
	a = getche();

/* Start this next line with a \n */

	printf("\nType another character:");
	b = getche();

	printf("\nYou typed a %c and a %c.\n",a,b);
}
