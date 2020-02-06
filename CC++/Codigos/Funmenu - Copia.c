/* A Function Key Menu Program
This program uses a while-select-case loop to run a
little menu program. The system() function is used
to execute a DOS command in this program's doDOS
function. Various function keys are used to select
the commands.
A lot of the function keys have been left blank for
you to fill in with your own commands if you like.
It's cinchy.
*/

#include <stdio.h>
#include <conio.h>
#include <stdlib.h>	//for executing system() function
#include <dos.h>	//For DOS function calls
#include "function.h"	//Function key definitions

#define VIDEO 0x10	//Video interrupt
#define KEYBOARD 0x16	//Keyboard interrupt
#define COLS 80		//Screen width
#define ROWS 25		//Screen rows
#define TRUE 1		//This is true
#define FALSE !TRUE	//This is not true

void screenSetup(void);
void doDOS(char *command);
int getKey(void);
void cls(void);
void locate(int row,int col);

void main()
{
	int done=FALSE;		//while loop variable

	screenSetup();		//Set up the screen

/* The program's main loop is a while-select-case
loop. It scans the keyboard looking for one of
the 10 function keys to be pressed.
Refer to the getKey and doDOS functions later in
the source code for a descirption of how they work */

	while(!done)
	{
		switch(getKey())	//read in a key
		{
			case F1:	//Go to DOS
				locate(0,24);
				puts("Type EXIT to return to the menu.");
				doDOS("COMMAND.COM");
				break;
			case F2:	//Format a disk
				doDOS("FORMAT A:");
				break;
			case F3: 	//[blank] (fill in later)
/*
To add your own functions, stick in a doDOS call, putting the
DOS command in the parenthesis in double quotes. Remember to
change the proper menu item in the screenSetup() function to
reflect your new command.
*/
				break;
			case F4:	//[blank]
				break;
			case F5:	//[blank]
				break;
			case F6: 	//Check disk
				doDOS("CHKDSK");
				break;
			case F7: 	//DIR command
				doDOS("DIR /P");
				break;
			case F8: 	//[blank]
				break;
			case F9:	//[blank]
				break;
			case F10:	//Quit
				done=TRUE;
				break;
		}
	}
	locate(0,24);
	puts("Bye!");
}

/* Set up the screen function
By putting all these commands here in their own function
you make the main function more readable */

void screenSetup(void)
{
	cls();			//Clear the screen
	locate(20,3);		//Move the cursor to x,y
	puts("Function Key Menu Program");
	locate(10,5);
	puts("F1 - Go to DOS");
	locate(10,7);
	puts("F2 - Format a disk");
	locate(10,9);
	puts("F3 - [blank]");
	locate(10,11);
	puts("F4 - [blank]");
	locate(10,13);
	puts("F5 - [blank]");
	locate(40,5);
	puts("F6 - Check disk");
	locate(40,7);
	puts("F7 - DIR command");
	locate(40,9);
	puts("F8 - [blank]");
	locate(40,11);
	puts("F9 - [blank]");
	locate(40,13);
	puts("F10 - QUIT");
	locate(20,16);
	printf("Your Choice:");	//don't display ENTER char here
}

/* This function runs a DOS program or command.
The command is in the string "command" passed to this
function. The system() function prototype is found in
the STDLIB.H header file. It sends whatever text is
in the parenthesis to DOS, just as if you typed it at
the prompt. Here the text is passed in the command
string variable.
Note that the getchar() function by itself will produce
a warning error. It's a nevermind warning error. */

void doDOS(char *command)
{
	locate(0,24);
	system(command);	//run the command
	locate(0,24);
	printf("Press ENTER to return to the menu:");
	getchar();		//press ENTER
	screenSetup();		//repaint the screen
}

/* Read the BIOS key function (to read function keys).
Unfortunately, getch() doesn't read function keys. To do
that you need to phone up the PC's keyboard BIOS interrupt
and get the keyboard character's secret code. The code is a
four digit hexadecimal number unique for each key and key
combination on the keyboard. The KEYBOARD.H file contains
the codes for the functions.
You cannot use this function to read regular keys; use
getch instead. (Well, you can use this function, but it's
really tricky and I may get into it in volume II.) */

int getKey(void)
{
	union REGS regs;

	regs.h.ah=0x00;		//Read keyboard function
	int86(KEYBOARD,&regs,&regs);	//dial up keyboard BIOS

	return(regs.x.ax);	//return keyboard "scan code"
}

/* Clear Screen Function (from ZAPSCRN2.C in Lesson 5.6) */

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

/* LOCATE Function (also from Lesson 5.6) */

void locate(int col,int row)
{
	union REGS regs;

	regs.h.ah=0x02;		//video function 2, move cursor
	regs.h.bh=0x00;		//video screen (always 0)
	regs.h.dh=row;		//cursor's row position
	regs.h.dl=col;		//cursor's column position
	int86(VIDEO,&regs,&regs);
}
