#include <stdio.h>
#include <conio.h>
#include <dos.h>

void dropBomb(void);	//The devious prototype

int killed;		//A global variable

void main()
{
	char x;

	killed=0;

	while(x!='~')
	{
		printf("Press ~ to end your mission\n");
		printf("Press any key to drop bomb:");
		x=getch();
		dropBomb();
		printf("\n%i people killed!\n",killed);
	}
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
	killed+=15;
}