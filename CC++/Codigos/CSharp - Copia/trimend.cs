 //STRIPS CHRS FROM THE END OF THE STRING
string Name = " String Manipulation " ;
//SET OUT CHRS TO STRIP FROM END
char[] MyChar = {' ','n'};
string NewName = Name.TrimEnd(MyChar);
//ADD BRACKET SO YOU CAN SEE TRIM HAS WORKED
MessageBox.Show("["+ NewName + "]");