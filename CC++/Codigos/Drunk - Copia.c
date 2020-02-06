/*
This program tries to prove the old "drunk and the lamp post
problem. A character starts out in the middle of the screen
and then moves in random steps: up, down, left or right.
Theoretically, he will always return to the lamp post, never
venturing far away. Will he?
This is based on the DIBBLE.C program, with only the main
function changed, plus a few new DEFINES.
*/

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <dos.h>

#define FACE 0x01	//Face character number
#define BACKSPACE 0x08	//Backspace character
#define BLANK 0x20	//Blank character number
#define LOOP 100	//number of faces to display
#define PAUSE 150000	//pause time (0-16,000,000)
#define VIDEO 0x10	//Video interrupt
#define COLS 80		//Screen width
#define ROWS 25		//Screen rows

void cls(void);
void locate(int row,int col);
int rnd(int range);
void seedrnd(void);

void main()
{
	int t,x,y;
	unsigned long p;	//p=pause loop

	cls();			//clear the screen
	seedrnd();		//set randomizer

// start at the center of the screen
	x=COLS/2;		//half screen width
	y=ROWS/2;		//half screen height

//Move the drunk LOOP number of times
	for(t=0;t<LOOP;t++)
	{
		locate(x,y);	//move cursor
		putchar(FACE);	//be happy
		for(p=0;p<PAUSE;p++);	//pause
/*
The following two statements move the drunk one position
up, down, right or left. The rnd() function returns a random
value between 0 and 2. When you subtract 1 from that value, you
get -1, 0 or 1, which moves the drunk left or up (-1) or right
or down (1) or keeps him in the same spot (0).
*/
		x+=(rnd(3)-1);	//new random X
		y+=(rnd(3)-1);	//new random Y
/*
The following four statements ensure the drunk doesn't
migrate off screen. If the X coordinate is less than 1, it's
changed to 80 and vice-versa. That way he'll move in the same
direction, but won't "disappear." Likewise for the value
of Y.
*/
		if(x<1) x=80;	//wrap to the left
		if(x>80) x=1;	//wrap to the right
		if(y<1) y=25;	//wrap to the bottom
		if(y>25) y=1;	//wrap to the top

/*
It's by erasing the drunk that the animation illustion
is created. First you must backup, then display a blank
character where the drunk was. (The next statement in
the for loop will re-display the drunk in his new
position.)
*/
		putchar(BACKSPACE);	//backup and
		putchar(BLANK);	//erase drunk
	}
}

void cls(void)
{
	union REGS regs;

	regs.h.ah=0x06;		//call function 6, scroll window
	regs.h.al=0x00;		//clear screen
	regs.h.bh=0x07;		//make screen "blank" color
	regs.h.ch=0x00;		//Upper left row
	regs.h.cl=0x00;		//Upper left column
	regs.h.dh=ROWS-1;	//Lower right row
	regs.h.dl=COLS-1;	//Lower right column
	int86(VIDEO,&regs,&regs);

	locate(0,0);		//"Home" the cursor
}

void locate(int row,int col)
{
	union REGS regs;

	regs.h.ah=0x02;		//video function 2, move cursor
	regs.h.bh=0x00;		//video screen (always 0)
	regs.h.dh=col;		//cursor's column position
	regs.h.dl=row;		//cursor's row position
	int86(VIDEO,&regs,&regs);
}
int rnd(int range)
{
	int r;

	r=rand()%range;		//spit up random num.
	return(r);
}

void seedrnd(void)
{
	srand((unsigned)time(NULL));
}
