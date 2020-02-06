Source Code : Demonstration of Linked list in java

//****************************

//LinkedList.java

//****************************

// Modified to support backwards traversal of the list.

// Additions and modifications are marked by ***.



public class LinkedList

{

  private ListItem start;              // First ListIem in the list.

  private ListItem end;                // Last ListIem in the list.

  private ListItem current;            // The current item for iterating.



  // Constructor to create a list containing one object:

  public LinkedList(Object item)

  {

    start = new ListItem(item);           // item is the start

    current = end = start;                // as well as the end and current.

  }



  // Construct a linked list from an array of objects:

  public LinkedList(Object[] items)

  {

    // Create a one item list:

    start = new ListItem(items[0]);       // First item is the start

    end = start;                          // as well as the end.



    // Now add the other items:

    for(int i = 1; i < items.length; i++)

      addItem(items[i]);

  }



  // Add an item object to the list:

  public void addItem(Object item)

  {

    ListItem newEnd = new ListItem(item); // Create a new ListItem.

    end.setNext(newEnd);                  // Set next variable for old end as new end.

    newEnd.setPrevious(end);              // So previous for new item.          ***

    current = end = newEnd;               // Store new item as end and current. ***

  }



  // Get the first object in the list:

  public Object getFirst()

  {

    current = start;

    return start.getObject();

  }



  // Additional method to get the last object in the list:     ***

  public Object getLast()

  {

    current = end;

    return end.getObject();

  }



  // Get the next object in the list:

  public Object getNext()

  {

    current = current.getNext();           // Get the reference to the next item.

    return current == null ? null : current.getObject();

  }



  // Additional method to get the previous object in the list:   ***

  public Object getPrevious()

  {

    current = current.getPrevious();   // Get the reference to the previous item.

    return current == null ? null : current.getObject();

  }

}





//****************************

//ListItem.java

//****************************

// Modified to support backwards traversal of the list.

// Additions and modifications are marked by ***.



public class ListItem

{

  ListItem next;             // Refers to next item in the list.

  ListItem previous;         // Refers to the previous item.       ***

  Object item;               // The item for this ListItem.



  // Constructor: 

  public ListItem(Object item)

  {

    this.item = item;        // Store the item.

    next = previous = null;  // Set next and previous to null.      ***

  }



  // Set the pointer to the next ListItem:

  public void setNext(ListItem next)

  {

    this.next = next;        // Store reference to the next item.

  }

  

  // Additional method to set the pointer to the previous ListItem:  ***

  public void setPrevious(ListItem previous)

  {                                                               

    this.previous = previous; // Store reference to the previous item. 

  }

 

  // Get the next item in the list:

  public ListItem getNext()

  {

    return next;

  }



  // Additional method to get the previous item in the list:         ***

  public ListItem getPrevious()

  {

    return previous;

  }



  // Get the object for this item:

  public Object getObject()

  {

    return item;

  }



  // return class name & object:

  public String toString()

  {

    return "ListItem " + item;

  }

}





//****************************

//Point.java

//****************************



public class Point

{

  double x;

  double y;



// Constructors:



  public Point()

  {

    x = 0.0;

    y = 0.0;

  }



  // Construct a Point from its coordinates:

  public Point(double x, double y)

  {

    this.x = x;

    this.y = y;

  }



  // Construct a Point from another Point:

  public Point(Point point)

  {

    x = point.x;

    y = point.y;

  }



  // Method to return a point defined relative to this

  // point in coordinates:

  public Point add(Point z)

  {

    return new Point(x+z.x,y+z.y);

  }



  // Overrides the method inherited from Object:

  public String toString()

  {

    return "Point: " + x + "," + y;

  }

}



//****************************

//PolyLine.java

//****************************



// MODIFIED TO OUTPUT THE POLYLINE POINTS IN REVERSE ORDER.

public class PolyLine

{

  LinkedList polyline;                     // The linked list of points.



  // Construct a polyline from an array of coordinate pairs:

  public PolyLine(double[][] coords)

  {

    Point[] points = new Point[coords.length];  // Array to hold points.



    // Create points from the coordinates:

    for(int i = 0; i < coords.length ; i++)

      points[i] = new Point(coords[i][0], coords[i][1]);



    // Create the polyline from the array of points:

    polyline = new LinkedList(points); 

  }



  // Construct a polyline from an array of points:

  public PolyLine(Point[] points)

  {

    polyline = new LinkedList(points);           // Create the polyline.

  }

  

  // Add a Point object to the list:

   public void addPoint(Point point)

   {

    polyline.addItem(point);                      // Add the point to the list.

   }



  // Add a point from a coordinate pair to the list:

   public void addPoint(double x, double y)

   {

     polyline.addItem(new Point(x, y));          // Add the point to the list.

  }



  // Output the polyline in reverse order:

  public void show()

  {

    System.out.println("Polyline points are:");



    // Set the 1st point as start:

    Point nextPoint = (Point)polyline.getLast();                 //  ***   



    // Output the points:

    while(nextPoint != null)

    {

      System.out.println(nextPoint);             // Output the current point.

      nextPoint = (Point)polyline.getPrevious(); // Get the next point.

    }

  }

}



//****************************

//TryPolyLine.java

//****************************



public class TryPolyLine

{

   public static void main(String[] args)

   {

      // Create an array of coordinate pairs:

      double[][] coords = { {1., 1.}, {1., 2.}, { 2., 3.},

                            {-3., 5.}, {-5., 1.}, {0., 0.} };



      // Create a polyline from the coordinates and display it:

      PolyLine polygon = new PolyLine(coords);

      polygon.show();



      // Add a point and display the polyline again:

      polygon.addPoint(10., 10.);

      polygon.show();



      // Create Point objects from the coordinate array:

      Point[] points = new Point[coords.length];

      for(int i = 0; i < points.length; i++)

         points[i] = new Point(coords[i][0],coords[i][1]);



      // Use the points to create a new polyline and display it:

      PolyLine newPoly = new PolyLine(points);

      newPoly.show();

   }

}