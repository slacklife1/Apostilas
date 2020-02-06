#include <stdio.h>

void here(void);	// silly prototype error avoiding
void there(void);	// technique

void main()
{
	here();
	there();
	here();
        there();
}

void here()
{
	int v;

	v=6*5;
	printf("The value of v here is %i\n",v);
}

void there()
{
	int v;

        v+=5;
	printf("The value of v there is %i\n",v);
}