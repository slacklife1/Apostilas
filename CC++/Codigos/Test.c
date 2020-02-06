#include <stdio.h>

void main()
{
	int c=5;
	int z;

	if(c>0)
		z=1;
	else
		z=0;
	printf("Z=%i\n",z);

	z=(c>0) ? 1 : 0;
	printf("Z=%i\n",z);
}
