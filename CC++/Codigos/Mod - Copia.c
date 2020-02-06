#include <stdio.h>

void main()
{
	int x;

	for(x=0;x<20;x++)
		printf("%i MOD 5 = %i\t5 MOD %i = %i\n",x,x%5,x,5%x);
}
