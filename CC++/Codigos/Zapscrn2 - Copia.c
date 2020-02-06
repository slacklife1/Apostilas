#include <stdio.h>
#include <dos.h>

#define VIDEO 0x10	//Video interrupt
#define COLS 80		//Screen width
#define ROWS 25		//Screen rows

void cls(void);
void locate(int row,int col);

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

	locate(0,0);		//"Home" the cursor
}

/* LOCATE Function
Move the cursor to position row,col, where row ranges from 0
to 79 and col from 0 to 24. Upper left corner = 0,0; lower right
corner = 79,24
*/

void locate(int row,int col)
{
	union REGS regs;

	regs.h.ah=0x02;		//video function 2, move cursor
	regs.h.bh=0x00;		//video screen (always 0)
	regs.h.dh=col;		//cursor's column position
	regs.h.dl=row;		//cursor's row position
	int86(VIDEO,&regs,&regs);
}
