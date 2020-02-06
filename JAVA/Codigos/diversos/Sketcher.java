Source Code : Sketcher

import java.awt.*;

import java.awt.event.*;

import javax.swing.*;

public class Sketcher implements WindowListener

{

     public static void main(String st[])

     {

     ec=new EventClass();

     ec.init();

     }

    public void init()

         {

               window=new EventClass("Event Class");

               Toolkit tk=window.getToolkit();

               Dimension d=tk.getScreenSize();

               window.setBounds(d.width/3,d.height/3,d.width/3,d.height/3);

               window.addWindowListener(this);

               window.setVisible(true);

               

          }

          public void windowClosing(WindowEvent e)

          {

               window.dispose();

               System.exit(0);

          }

        public void windowOpened(WindowEvent e){}

        public void windowClosed(WindowEvent e){}

        public void windowIconified(WindowEvent e){}

        public void windowDeiconified(WindowEvent e){}

        public void windowActivated(WindowEvent e){}

        public void windowDeactivated(WindowEvent e){}

        private static Sketcher ec;

        private static SketchFrame window;

             

}