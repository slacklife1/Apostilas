#include <stdio.h>

#define WISE 1			//Wise is TRUE
#define SILLY !(WISE)		//Silly is FALSE
#define MILTON WISE		//Milton is Wise
#define MELVIN SILLY		//Melvon is not

void main()
{
	if(MILTON==WISE && MELVIN==SILLY)
		printf("Milton is wise and Melvin is silly.\n");
	if(MILTON==SILLY || MELVIN==SILLY)
		printf("Either Mitlon or Melvin is silly.\n");
	if(MILTON==WISE || MELVIN==WISE)
		printf("Either Milton or Melvin is wise.\n");
	if(MILTON==SILLY && MELVIN==WISE)
		printf("Milton is silly and Mevlin is wise\n");
	if(MILTON==SILLY || MELVIN==WISE)
		printf("Either Milton is silly or Melvin is wise.\n");
}
