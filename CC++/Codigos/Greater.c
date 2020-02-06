#include <stdio.h>
#include <conio.h>

void main()
{
	char a,b;

	printf("Which character is greater?");
	printf("\nType a single character:");
	a=_getche();
	printf("\nType another character:");
	b=_getche();

	if(a>b)
	{
		printf("\n%c is greater than %c!\n",a,b);
	}
	else if(b>a)
	{
		printf("\n%c is greater than %c!\n",b,a);
	}
	else
	{
		printf("\nNext time don't type the same character twice.");
	}
}
