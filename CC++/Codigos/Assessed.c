#include <stdio.h>
#include <stdlib.h>

void main()
{
	int houses, hotels, total;
	char temp[4];

	printf("Enter the number of houses:");
	gets(temp);
	houses=atoi(temp);

	printf("Enter the number of hotels:");
	gets(temp);
	hotels=atoi(temp);

	total=houses*40+hotels*115;

	printf("You owe the bank $%i.\n",total);
}
