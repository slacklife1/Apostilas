Source Code : Photo


import java.awt.event.ActionListener;

import java.awt.event.*;

import java.awt.Graphics2D;

import java.awt.Graphics;

import java.awt.*;

import java.io.File;

import java.net.*;

//import java.media.*;

import javax.swing.*;

import java.awt.geom.*;





public   class Photo extends JFrame

{

public static JFrame frame;

public static Image img;

public static     JFileChooser f;

public static JPanel panel;

public static JButton button;

public static     Graphics2D g2d;

public static     Graphics g;

public static myPanel p;





     public static void main(String st[])     

     

      {

      

         frame=new JFrame("FIAZ GUL KHAN JADOON");

        Toolkit kk=frame.getToolkit();

          Dimension dd=kk.getScreenSize();

          dd.width=800;

          dd.height=570;

           frame.setBounds(0,0,dd.width,dd.height);

          frame.getContentPane().setBackground(Color.black);

          frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

          

     



                                        

f=new JFileChooser();

f.showOpenDialog(frame);

File fc=f.getSelectedFile();

String str=fc.getPath();

ImageIcon icon=new ImageIcon(str);

img=icon.getImage();

myPanel p=new myPanel();





frame.getContentPane().add(p);





     frame.setVisible(true);     

      }

      

     static class myPanel extends JPanel

      {

           public void paint(Graphics g)

           {

               g.drawImage(img,0,0,this);

      }

     }



     

}