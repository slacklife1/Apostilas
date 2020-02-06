#include <stdio.h>
#include <conio.h>

void main()
{
	char c;

	printf("Try to type a lower case character.\n");
	printf("I dare ya. Double dare ya!\n");
	printf("Press ~ to end.\n");

	for(;;)
	{
		c=getch();
		if(c>='A' && c<='Z')	//look for CAPS
			c+=32;		//make it little
		putch(c);		//display character
		if(c=='~')		//Quit with ~
			break;
	}
}