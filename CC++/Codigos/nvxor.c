// 

// **********************************************************************

// *                           Code Challenge                           *

// **********************************************************************

//

// Challenge:

//

//	Write an exclusive-OR encryption program.

//	The program should take as input a filename that

//	is then encrypted by the program.  The program

//	should ask the user to input an encryption key,

//	which should be used to encrypt the file.

//	The output of the program should go into a file

//	with the same filename but a .ENC extension

//	(for simplicity sake).

//	All programs should run under DOS. 

//

// Comments and voluntary changes:

// 

//	Added a second argument for output filename,

//  as you cannot encrypt/decrypt a file that already

//	is encrypted and has the .enc extension following

//	the given guidelines. This change to the specifications

//	is optional, so it works as per the specifications as

//	well.

//	The program encrypts the file, not the filename like 

//	stated above, I think it's obvious that this passage 

//	should not be taken by the word.

//	This application uses ANSI commands and standard headers,

//	it should be able to run as a .c file as well. However,

//	I was too lazy to test it on anything but VC as a windows

//	console application.

//	My other programs would probably be commented differently,

//	but as all of us are working at the same problem, much of

//	it will be quite clear from own experience.

//  Edit: Tested ok as pure C.

// 

// Time:

//

//	I received the mail Tuesday, 08.01.2002 15:27.

//  Started coding at roughly 18:00

//  Finished coding at about 18:45, starting to write comment.

//  Sent the reply mail: 19:30

//

// Facts:

//

//	Author:		Niels Voigt

//  EMail:		nvoigt@saz.net 

//	Username:	nvoigt from cprogramming

//	Compiler:	VC 6 SP 5

//	Project:	Console Application, should be 100% DOS compatible

//	Libraries:	ANSI C

//

// Testing:

//  

//  Encrypting a file twice and checking with the FC utility 

//	gives a 100% match. So if there are still mistakes, at 

//	least they are consistent ;-)

//



// standard includes for io and strings

#include <stdio.h>

#include <string.h>



// constants

#define MAX_PATH			1000

#define MAX_ENCRYPT_KEY		100

#define XOR_FILE_EXT		".enc"

#define ERROR_NOERROR		0

#define ERROR_READERROR		1

#define ERROR_WRITEERROR	2



// prototypes, description see below

int CreateFileName( const char* szOldFile, char* szNewFile );

int RemoveUnwantedCharacters( char* szBuffer );



//

// main

//

//	the encryption program itself

//

int main( int argc, char* argv[] ) 

{

	// variable declaration

	FILE*	fpInput;

	FILE*	fpOutput;

	char	szFileName[MAX_PATH+1];

	char	szEncryptionKey[MAX_ENCRYPT_KEY+1];

	int		nEncryptKeyLength;

	int		nByte;

	int     nCount;

	int     nError;



	// check for arguments

	if( argc == 2 )

	{

		// create filename if only source was given

		CreateFileName( argv[1], szFileName );

	}

	else if( argc == 3 )

	{

		// copy given destination 

		strcpy( szFileName, argv[2] );

	}

	else

	{

		// print help if number of arguments are illegal

		printf( "\nWrong number of arguments\n" );

		printf( "USAGE: %s Source [Destination]\n\n", argv[0] );

		return 1;

	}



	// ask for encryption key

	do

	{

		printf( "Please enter encryption key ( 1 - %d characters ):",MAX_ENCRYPT_KEY );

		memset( szEncryptionKey, MAX_ENCRYPT_KEY+1, 0 );

		fgets( szEncryptionKey, MAX_ENCRYPT_KEY, stdin );

		RemoveUnwantedCharacters( szEncryptionKey );

		nEncryptKeyLength = strlen( szEncryptionKey );

	}	

	while( nEncryptKeyLength == 0 );



	// print status and data

	printf( "\n" );

	printf( "Encrypting [%s]\n",argv[1] );

	printf( "        to [%s]\n",szFileName );

	printf( "     using [%s]\n",szEncryptionKey );

	printf( "\n" );

	

	// open input file

	fpInput = fopen( argv[1], "rb" );

	if( fpInput == NULL )

	{

		printf( "Error: Unable to open %s for reading.\n\n", argv[1] );

		return 2;

	}



	// open output

	fpOutput = fopen( szFileName, "wb" );

	if( fpOutput == NULL )

	{

		printf( "Error: Unable to open %s for writing.\n\n", szFileName );

		return 3;

	}



	nCount = 0;

	nError = ERROR_NOERROR;



	// encryption loop:

	// read a byte, encrypt, write, next until no more bytes

	// each byte is encrypted with one letter from the key,

	// when the end of the key is reached, the next byte is

	// encrypted with the first one again.

	while( ( nByte = fgetc( fpInput ) ) != EOF )

	{

		if( fputc( nByte ^ szEncryptionKey[nCount], fpOutput ) == EOF )

		{

			nError = ERROR_WRITEERROR;

			break;

		}



		nCount++;



		if( nCount >= nEncryptKeyLength ) nCount = 0;

	}



	// check if the loop terminated with an end-of-file.

	// after all, somebody may have pulled the

	// plug or the network cable, which will also result 

	// in an EOF condition for fgetc.

	if( ! feof( fpInput ) ) nError = ERROR_READERROR;



	// print end message

	switch( nError )

	{

		case ERROR_NOERROR:

			printf( "Encryption complete.\n\n" );

			break;

		case ERROR_READERROR:

			printf( "Error: unable to perform READ operation on file [%s]\n\n", argv[1] );

			break;

		case ERROR_WRITEERROR:

			printf( "Error: unable to perform WRITE operation on file [%s]\n\n", szFileName );

			break;

		default:

			printf( "Error: Unknown Error, please contact your support.\n\n" );

			break;

	}



	// close files

	fclose( fpInput );

	fclose( fpOutput );



	// done ;-)

	return 0; 

}



//

// CreateFileName

//

//	creates the destination filename from the source

//	by replacing the file extension or adding it if

//	no other extension is found.

//

int CreateFileName( const char* szOldFile, char* szNewFile )

{

	char* szReplace;



	strcpy( szNewFile, szOldFile );



	szReplace = szNewFile + strlen( szNewFile );



	while( szReplace > szNewFile && *szReplace != '\\' && *szReplace != '/' )

	{

		if( *szReplace == '.' )

		{

			strcpy( szReplace, XOR_FILE_EXT );

			return 0;

		}



		szReplace--;

	}



	strcat( szNewFile, XOR_FILE_EXT );



	return 1;

}



//

// RemoveUnwantedCharacters

//

//	removes the 0D characters that are left in the buffer 

//  when reading... I wish there was ONE out-of-the-box

//	simple-to-use input function.

//

int RemoveUnwantedCharacters( char* szBuffer )

{

	while( *szBuffer != 0 )

	{

		if( *szBuffer == 0x0a || *szBuffer == 0x0d ) *szBuffer = 0;

		szBuffer++;

	}



	return 0;

}



//

// END OF FILE

// 