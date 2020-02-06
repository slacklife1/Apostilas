#include <stdio.h>

void counter(int start, int stop);

void main()
{
	counter(1,10);
	counter(2,8);
	counter(123,144);
}

void counter(int start, int stop)
{
	int i;

	for(i=start;i<stop;i++)
		printf("%i ",i);
}