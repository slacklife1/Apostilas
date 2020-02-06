/*
This program displays some happy faces at random spots on
the screen. It uses the cls() and locate() functions from
Lesson 5.6 and the rnd() and seedrnd() functions from
Lesson 5.7. Other than that, it's pretty silly.
*/

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <dos.h>

#define FACE 0x01	//Face character number
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

	for(t=0;t<LOOP;t++)
	{
		x=rnd(80)+1;	//random column
		y=rnd(25)+1;	//random row
		locate(x,y);	//move cursor there
		putchar(FACE);	//be happy
/*
The following statement is a pause loop, delaying the program
for a few seconds. Values for the PAUSE constant can range from 0 (fast)
up to 16,000,000, which is really slow. Values will differ depending
on how fast your PC is.
The Borland C++ compiler has two pausing functions built-in, both
of which are better than relying on a for loop. The sleep() function
pauses for a given number of seconds; the delay() function pauses
for a given number of microseconds. So sleep(1); pauses for one
second, as does the delay(1000); statement.
*/
		for(p=0;p<PAUSE;p++);	//pause
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
