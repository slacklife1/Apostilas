/* Display random number in several counting bases */

#include <stdio.h>
#include <stdlib.h>
#include <time.h>		//for seeding randomizer

int rnd(int range);
void seedrnd(void);

void main()
{
	int r;

	seedrnd();
	r=rnd(32000);

	printf("You must send %i pods to San Francisco.\n",r);
	printf("You must send %o (O) pods to San Francisco.\n",r);
	printf("You must send %x (H) pods to San Francisco.\n",r);
	printf("You must send %X (H) pods to San Francisco.\n",r);
}

int rnd(int range)
{
	int r;

	r=rand()%range;		//spit up random num.
	return(r);
}

void seedrnd(void)
{
	srand((unsigned)time(NULL));
}
