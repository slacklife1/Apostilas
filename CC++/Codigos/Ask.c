/* YORN - a program to get a yes or no answer */

#include <stdio.h>
#include <conio.h>

#define TRUE 1		//this is "true" in C
#define FALSE !TRUE	//this is "not true"

void main()
{
	char c;

	printf("Please answer Y for Yes or N for No:");

	while(TRUE)	//this means "loop forever"
	{
		c=getch();
		if(c=='Y' || c=='y')	break;
		if(c=='N' || c=='n')	break;
	}
	printf("%c\n",c);
}
