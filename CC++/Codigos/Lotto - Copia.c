/* This program is designed to pick out random lotto numbers
from 1 to RANGE, as defined below.
Normally you would think drawing random numbers in a lottery
wouldn't be a problem, however you cannot draw the same number
twice. So there must be a mechanism to make sure the numbers
already drawn are excluded from the pool of available numbers.
Here I solve the problem by bulidng an array -- essentially
an array of lotto balls. The array is initialized to zeros
and when a ball is drawn a 1 is stuck in its place. When
future balls are drawn, the program checks the array to see
if a 1 is in that ball's position. If not, the ball can be
drawn. */

#include <stdio.h>
#include <stdlib.h>
#include <time.h>	//for the seedrnd() function

#define RANGE 50	//number of numbers
#define BALLS 6		//number of balls to draw
#define DELAY 1000000	//delay interval between picks

int rnd(int range);
void seedrnd(void);

void main()
{
	int numbers[RANGE];	//array that holds the balls
	int i,b;
	unsigned long d;	//delay variable

/* set things up */
	printf("L O T T O   P I C K E R\n\n");
	seedrnd();		//seed the randomizer

/* Initialize the array by filling every element with
a zero. This means none of the balls have been drawn
yet */
	for(i=0;i<RANGE;i++)	//initialize the array
		numbers[i]=0;

	printf("Press Enter to pick this week's numbers:");
	getchar();

/* draw the numbers */
	printf("\nHere they come: ");
	for(i=0;i<BALLS;i++)
	{
		for(d=0;d<=DELAY;d++);	//pause here

/* The do-while loop picks a random number, b=rnd(RANGE)
is its only statement. The while part checks to see if a
1 is in that ball's position in the array. Since 1=TRUE,
the loop repeats until a number/ball is drawn with zero
in the array. 0=FALSE, so the loop stops. */
		do
		{
			b=rnd(RANGE);	//draw number
		}
		while(numbers[b]);	//already drawn?

/* After the ball is drawn, a 1 is stuck in its position
in the array. The b+1 in the printf statement accounts for
the fact that the array starts at zero. In real life there
is no zero lotto ball, so we add 1 to that number to get
1 as the lowest ball. Everything else falls into place. */

		numbers[b]=1;		//mark it as drawn
		printf("%i ",b+1);	//add one for zero
	}
	printf("\n\nGood luck in the drawing!\n");
}

/* Generate a random value */

int rnd(int range)
{
	int r;

	r=rand()%range;		//spit up random num.
	return(r);
}

/* Seed the randomizer */

void seedrnd(void)
{
	srand((unsigned)time(NULL));
}
