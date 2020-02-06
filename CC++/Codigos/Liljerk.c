#include <stdio.h>

void jerk(char *name);

void main()
{
	char whoever[15];

	printf("Enter the name of a jerk you know:");
	gets(whoever);
	jerk(whoever);
}

void jerk(char *name)
{
	int i;

	for(i=0;i<3;i++)
		printf("%s is a jerk\n",name);
}
