Stars Applet

import javax.swing.*;

import java.awt.*;

import java.awt.geom.*;



public class StarApplet extends JApplet

{

  // Initialize the applet

  public void init()

  {

    Container content = getContentPane();



    // Add the panel to the content pane for the applet

    content.add(pane);                 // BorderLayout.CENTER is default position

  }



  // Class defining a pane on which to draw

  class StarPane extends JComponent

  {

    public void paint(Graphics g)

    {

      Graphics2D g2D = (Graphics2D)g;

      Star star = new Star(0,0);                 // Create a star

      float delta = 60f;                         // Increment between stars

      float starty = 0f;                         // Starting y position



      // Draw 3 rows of 4 stars

      for(int yCount = 0; yCount < 3; yCount++)

      {

        starty += delta;                        // Increment row position

        float startx = 0f;                      // Start x position in a row



        // Draw a row of 4 stars

        for(int xCount = 0; xCount<4; xCount++)

          g2D.draw(star.atLocation(startx += delta, starty));

      }

    }

  }



  StarPane pane = new StarPane();              // Pane containing stars

}





//*****************************

//class Star.java

//Create a new file and name it Star.java

//and copy the code below into that file.

//*****************************

import java.awt.geom.*;

import java.awt.*;



class Star

{

  public Star(float x, float y)

  {

    start = new Point2D.Float(x, y);                      // store start point

    createStar();

  }



  // Create the path from start

  void createStar()

  {

    Point2D.float point = start;

    p = new GeneralPath(GeneralPath.WIND_NON_ZERO);

    p.moveTo(point.x, point.y);

    p.lineTo(point.x + 20.0f, point.y - 5.0f);            // Line from start to A

    point = (Point2D.Float)p.getCurrentPoint();

    p.lineTo(point.x + 5.0f, point.y - 20.0f);            // Line from A to B

    point = (Point2D.Float)p.getCurrentPoint();

    p.lineTo(point.x + 5.0f, point.y + 20.0f);            // Line from B to C

    point = (Point2D.Float)p.getCurrentPoint();

    p.lineTo(point.x + 20.0f, point.y + 5.0f);            // Line from C to D

    point = (Point2D.Float)p.getCurrentPoint();

    p.lineTo(point.x - 20.0f, point.y + 5.0f);            // Line from D to E

    point = (Point2D.Float)p.getCurrentPoint();

    p.lineTo(point.x - 5.0f, point.y + 20.0f);            // Line from E to F

    point = (Point2D.Float)p.getCurrentPoint();

    p.lineTo(point.x - 5.0f, point.y - 20.0f);            // Line from F to g

    p.closePath();                                        // Line from G to start

  }



  Shape atLocation(float x, float y)

  {

    start.setLocation(x, y);                              // Store new start

    p.reset();                                            // Erase current path

    createStar();                                         // create new path

    return p;                                             // return the path

  }



  // Make the path available

  Shape getShape()

  { 

    return p; 

  }



  private Point2D.float start;                           // Start point for star

  private GeneralPath p;                                 // Star path

}

