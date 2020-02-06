#include <stdio.h>
#include <conio.h>
#include <dos.h>

void dropBomb(void);	//The devious prototype

void main()
{
	char x;

	printf("Press any key to drop bomb:");
	x=getchar();
	dropBomb();
	printf("\nYou pressed the '%c' key to kill all those people!\n",x);
}

void dropBomb()
{
	int x;

	for(x=880;x>440;x-=10)
	{
		sound(x);
		delay(100);
	}
	nosound();
}