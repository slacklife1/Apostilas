/* Simple array program */

#include <stdio.h>

void main()
{
	int x,f;
	char input[3];	//for storing text input
	int favs[4];	//five items in array

	printf("Please enter five of your favorite numbers\n");
	printf("Between 1 and 100.\n");

	for(x=0;x<5;x++)
	{
		printf("#%i favorite number is:",x+1);
		f=atoi(gets(input));
		favs[x]=f;
	}
}
