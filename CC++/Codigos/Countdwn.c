/* An important program for NASA to properly launch
America's spacecraft. */

#include <stdio.h>

void main()
{
	int start;
	long delay;

/* This loop ensures they type in the proper value */

	do
	{
		printf("Please enter the number to start\n");
		printf("the countdown (1 to 100):");
		scanf("%i",&start);
	}
	while(start<1 || start>100);

/* The countdown loop */	//Example of a "nested loop"

	do
	{
		printf("T-minus %i\n",start);
		start--;
		for(delay=0;delay<1000000;delay++);	//delay loop
	}
	while(start>0);

	printf("Zero!\nBlast off!\n");
}
