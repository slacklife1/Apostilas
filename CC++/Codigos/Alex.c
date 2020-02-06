#include <dos.h>

void main()
{
	sound(466); delay(125);
	sound(494); delay(375);
	sound(466); delay(125);
	sound(494); delay(1000);
	nosound();
}