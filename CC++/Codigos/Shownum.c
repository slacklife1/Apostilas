#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

void shownumber(int val);

void main()
{
	char c;
	int val;

	for(;;)
	{
		printf("\nType in a number or ~ to stop:");
		c=getch();
		if(c=='~')
		{
			break;
		}
		showNumber(c-48);
	}
}

void showNumber(int val)
{
	printf("And %i",val);
}