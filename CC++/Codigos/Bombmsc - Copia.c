#include <stdio.h>
#include <windows.h>

void dropBomb(void);	//The devious prototype

void main()
{
	printf("Press any key to drop bomb:");
	getchar();
	dropBomb();
	printf("\nYikes!\n");
}

void dropBomb()
{
	int x;

	for(x=0;x<15;x++)
	{
		printf("\nWeee!");
	}
	printf("\nSplat!!");
}