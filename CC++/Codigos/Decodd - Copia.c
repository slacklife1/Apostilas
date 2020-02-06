#include <stdio.h>

void main()
{
	int a,b;

	a=10;
	b=0;
	printf("A=%i and B=%i before decrementing.\n",a,b);
	b=a--;
	printf("A=%i and B=%i after decrementing.\n",a,b);
}
