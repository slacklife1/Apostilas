 //STRIPS CHRS FROM THE START OF THE STRING
string Name = " String Manipulation " ;
//SET OUT CHRS TO STRIP FROM END
char[] MyChar = {' ','S'};
string NewName = Name.TrimStart(MyChar);
//ADD BRACKET SO YOU CAN SEE TRIM HAS WORKED
MessageBox.Show("["+ NewName + "]");