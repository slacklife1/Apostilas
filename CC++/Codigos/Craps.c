/* Program to simulate the exciting and confusing game
of casino craps.
Basically you roll two dice and total the number. If it's
a 7 or 11 you win; 2, 3 or 12 and you lose. Easy enough.
If you roll any other number, 4, 5, 6, 8, 9 or 10, it
becomes your "point." You must roll that number again to
win, but if you roll a 7 before that, you lose.
Confused? Play it a while.
This game only plays pass; no other fancy bets that would
confuse you anyway and make it harder to program. */

#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <ctype.h>		//for the toupper() function
#include <time.h>		//for seeding randomizer

#define TRUE 1			//It's true!
#define FALSE !TRUE		//It's false!

int rnd(int range);
void seedrnd(void);
int roll(void);

void main()
{
	int x,YouWannaPlay,pot,bet,point;
	char c;

/* Setup */
	seedrnd();		//randomizer
	printf("\nVegas Craps!\nThe dice game no one understands.\n\n");
	YouWannaPlay=TRUE;
	pot=100;		//start with $100

/* Play the game main loop*/
	while(YouWannaPlay)
	{
/* First get their bet in a do-while loop. The bet must be
greater than $2 and can't be greater than their pot (total).
If the bet is less than 2, the if statement displays a rude
message. */
		do
		{
			printf("You have $%i in your pot.\n",pot);
			printf("Enter your bet: $");
			scanf("%i",&bet);
			if(bet<2)
				printf("Hey! You wanna do that low-ball stuff, go downtown!\n");
		}
		while(bet<2 || bet>pot);

		x=roll();	//roll the dice
		printf("\tThe roll was %i.\n",x);

/* The switch-case loop thing handles all rolls of
the dice: 7 and 11 to win and double your bet, 2, 3 or
12 to lose and lose your bet. */

		switch(x)
		{
			case 7:
			case 11:
				printf("\tYou win!\n");
				pot+=bet;
				break;
			case 2:
			case 3:
			case 12:
				printf("\tCraps! You lose!\n");
				pot-=bet;
				break;
			default:		//everything else
				point=x;	//set point
				printf("\tYour point is now %i.\n",point);

/* The while(TRUE) loop loops forever, but breaks within
the loop get you out of it. Basically you're looking for
x=point, rolling the point again, or x=7, which means
you lose. Both conditions are handled by if statements
within the loop, which adjust the pot and break out of
the loop as necessary */
				while(TRUE)
				{
					x=roll();	//roll the dice
					printf("\tYou rolled %i, point is %i.\n",x,point);
					if(x==point)
					{
						printf("\tYou win!\n");
						pot+=bet;
						break;
					}
					if(x==7)
					{
						printf("\tSeven out, you lose!\n");
						pot-=bet;
						break;
					}
				}
		}

/* Game over stuff */
/* At this point you've either won or lost, but you're still
in a while loop. First, tell the user how much is in their
pot. Then, if the pot is empty, you need to end the game.
Otherwise, ask if they want to play again and repeat the
loop. */

		printf("You now have $%i in your pot.\n",pot);
		if(pot==0)	//outta money
		{
			printf("You're broke!\n");
			printf("Get outta here!\n");
			break;	//quit the loop and the game
		}
		printf("Play again Y/N?");

/* This chunk of code gets Y or N input and quits the loop if
N is pressed. toupper converts the keystroke into upper case.
If they type an N, it's displayed and YouWannaPlay is set to
false, which ends the loop. Otherwise the program assumes you
pressed Y and the loop repeats.*/

		c=toupper(getch());
		if(c=='N')
		{
			printf("N\n");	//display input
			YouWannaPlay=FALSE;
		}
		else
			printf("Y\n\n");	//assume Y pressed
	}

/* Exit routines (there aren't any, but here is where they'd go) */

}

/* The roll function rolls the dice and returns the total */

int roll(void)
{
	int dice1,dice2;

/* One is added to the value rnd() returns since it returns
values from 0 to 5. */

	dice1=rnd(6)+1;		//get random number between 1 and 6
	dice2=rnd(6)+1;
	return(dice1+dice2);
}

/* Generate a random value */

int rnd(int range)
{
	int r;

	r=rand()%range;		//spit up random num.
	return(r);
}

/* Seed the randomizer */

void seedrnd(void)
{
	srand((unsigned)time(NULL));
}

