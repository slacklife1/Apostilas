#include <stdio.h>
#include <conio.h>

#define ENTER 0x0d		//Enter key

void main()
{
	int x;
	char c;

	printf("You can type up to 40 characters.\n");

	for(x=0;;x++)
	{
		c=getch();
		if(c==ENTER || x==40)	//look for CAPS
			break;		//make it little
		putch(c);		//display character
	}
}