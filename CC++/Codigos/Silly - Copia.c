#include <stdio.h>
#include <conio.h>

void main()
{
	char key;

	printf("Press a key:");
	key=getch();
	printf("Ouch!\nYou pressed the '%c' key.\n",key);
}
