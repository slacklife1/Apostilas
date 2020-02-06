Source Code : Calculator

import java.awt.*;

import java.awt.event.*;

import javax.swing.*;



public  class CalculatorFormat implements WindowListener 

{

     private JButton b7,b8,b9,on,off,b4,b5,b6,mult,div,b1,b2,b3,add,sub,b0,dot,exp,ans,equals;

     private JTextField textField;

     private Container container;

     private FlowLayout layout;

     

     

     public CalculatorFormat() 

     {

                    

          super("My calculator");

          layout=new FlowLayout();

          

          

          container=getContentPane();

          container.setLayout(layout);

          

          

          textField=new JTextField(25);

          container.add(textField);

          

          

          b7=new JButton("7 ");

          container.add(b7);

          

          b8=new JButton("8 ");

          container.add(b8);                    

          

          b9=new JButton("9 ");

          container.add(b9);

          

          on=new JButton("ON");

          container.add(on);

          on.setBackground(Color.pink);

          off=new JButton("OFF");

          container.add(off);

          off.setBackground(Color.pink);          

          b4=new JButton(" 4 ");

          container.add(b4);

                    

          b5=new JButton(" 5 ");

          container.add(b5);

                    

          b6=new JButton(" 6 ");

          container.add(b6);

                    

          mult=new JButton(" * ");

          container.add(mult);

          mult.setBackground(Color.pink);          

          div=new JButton(" / ");

          container.add(div);

          div.setBackground(Color.pink);          

          b1=new JButton(" 1 ");

          container.add(b1);

                    

          b2=new JButton(" 2 ");

          container.add(b2);

                    

          b3=new JButton(" 3 ");

          container.add(b3);

                    

          add=new JButton(" + ");

          container.add(add);

          add.setBackground(Color.pink);          

          sub=new JButton(" - ");

          container.add(sub);

          sub.setBackground(Color.pink);          

          b0=new JButton("0");

          container.add(b0);

                    

          dot=new JButton(".");

          container.add(dot);

                    

          exp=new JButton("EXP");

          container.add(exp);

          exp.setBackground(Color.pink);          

          ans=new JButton("ANS");

          container.add(ans);

          ans.setBackground(Color.pink);                    

          equals=new JButton("=");

          container.add(equals);

          equals.setBackground(Color.pink);          

          

          setBounds(300,200,300,250);

          setVisible(true);          

     }

     

public void windowClosing(WindowEvent e)

{

     window.dispose();

     system.exit(0);

}



public void windowOpened(WindowEvent e){ }

public void windowClosed(WindowEvent e){ }

public void windowIconified(WindowEvent e){ }

public void windowDeiconified(WindowEvent e){ }

public void windowActivated(WindowEvent e){ }

public void windowDectivated(WindowEvent e){ }



public static void main(String args[])

     {

          CalculatorFormat ob1=new CalculatorFormat();

          ob1.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

     }



}