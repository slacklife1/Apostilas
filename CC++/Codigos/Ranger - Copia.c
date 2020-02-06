#include <stdio.h>

#define TRUE 1
#define FALSE !TRUE

void main()
{
	int v,start;

	v=TRUE;
	while(v==TRUE)
	{
		printf("Enter a number between 0 and 10:");
		scanf("%i",&start);
		if(start>0 && start<10)
			v=FALSE;
	}

	printf("Thank you for obeying my instructions.\n");
	printf("You typed %i.\n",start);
}
