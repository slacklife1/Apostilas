#include <stdio.h>
#include <dos.h>

void whistle(void);	//The devious prototype

void main()
{
	printf("Press any key to hear annoying whistle:");
	getch();
	whistle();
	printf("\nYikes!\n");
}

void whistle()
{
	int x;

	for(x=880;x>440;x-=5)
	{
		sound(x);
		delay(125);
	}
	nosound();
}