/* This program displays the value 50 three
different ways */

#include <stdio.h>

#define PODS 62

void main()
{
	printf("You must send %i pods to San Francisco.\n",PODS);
	printf("You must send %o pods to San Francisco.\n",PODS);
	printf("You must send %x pods to San Francisco.\n",PODS);
	printf("You must send %X pods to San Francisco.\n",PODS);
}
