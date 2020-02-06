01:  Hashtable colors = new Hashtable();
02:  colors.Add("red", Color.Red);
03:  colors.Add("green", Color.Green);
04:  colors.Add("blue", Color.Blue);
05:
06:  Color color = (Color)colors["red"];   // <<< casting needed
07:  Console.WriteLine("{0} in RGB is {1}:{2}:{3}",
08:                    color, color.R, color.G, color.B);
09:
10:  IDictionaryEnumerator ie = colors.GetEnumerator();
11:  while (ie.MoveNext())
12:  {
13:    color = (Color)ie.Value;            // <<< casting needed
14:    string key = (string) ie.Key;       // <<< casting needed
15:    Console.WriteLine("{0} in RGB is {1}:{2}:{3}", 
16:                      color, color.R, color.G, color.B);
17:  }

