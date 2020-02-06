#include <stdio.h>
#include <dos.h>

#define VIDEO 0x10	//Video interrupt
#define COLS 80		//Screen width
#define ROWS 25		//Screen rows

void cls(void);

void main()
{
	printf("Press Enter to clear the screen");
	getchar();
	cls();
	printf("Ah, how refreshing...");
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
}
