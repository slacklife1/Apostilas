/*
MOON.C
A program to see how much you'd weigh on the moon.
*/

#include <stdio.h>
#include <stdlib.h>

void main(int argc,char *argv[])
{
	float weight;

	if(argc<2)		//no options typed
	{
		printf("This program requires you to type your\n");
		printf("weight after MOON, as in:\n");
		printf("MOON 175\n");
		exit(0);	//quit the program right here
	}
/*
argv[1] contains the user's weight
*/
	weight=atof(argv[1]);	//get their weight
	weight/=6;		//divide weight by 6

	printf("On the moon, you would weigh %.1f pounds.\n",weight);
}
