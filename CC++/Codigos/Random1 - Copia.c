#include <stdio.h>
#include <stdlib.h>

int rnd(void);

void main()
{
	int x;
				//display 100 random numbers
	for(x=0;x<100;x++)
		printf("%i\t",rnd());
}

int rnd(void)
{
	int r;

	r=rand();		//spit up random num.
	return(r);
}

