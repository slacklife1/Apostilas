Source Code : Form

import java.awt.*;

import java.awt.event.*;

import javax.swing.*;



public class form extends JFrame

     {

          private JPanel bottom,top,centre;

          private JButton b1,b2,OK;

          private JLabel n,e,m;

          private Color color=Color.black;

                private String s1,s2,s3,s4="",s5;

TextField screen=new TextField(20);

                    TextField scr=new TextField(20);

                    TextArea a=new TextArea(6,20);

          

          public form()

          

          {

               super("form");

               

               

               Container c=new Container();

               c=getContentPane();

               

               bottom=new JPanel();



               

               

               bottom.setBorder(BorderFactory.createEtchedBorder(Color.cyan,Color.blue));

                

               JButton b1=new JButton("OK");

               JButton b2=new JButton("Cancel");

               bottom.add(b1);



               bottom.add(b2);

               

               

          

               c.add(bottom,BorderLayout.SOUTH);

          

               

                     top=new JPanel();

                    n=new JLabel("NAME   "); 

                    e=new JLabel("EMAIL ");

                    m=new JLabel("MESS");

                    

                    

               

                    

          

               top.setLayout(new FlowLayout(FlowLayout.LEFT,200,50));

               

               

                    top.add(n);

                    top.add(scr);

                    top.add(e);

                    top.add(screen);

                    top.add(m);

                    top.add(a);

                    c.add(top,BorderLayout.CENTER);

          top.setBorder(BorderFactory.createEtchedBorder(Color.blue,Color.green));

                    

               centre=     new JPanel();

               c.add(centre,BorderLayout.NORTH);

               centre.setBorder(BorderFactory.createEtchedBorder(Color.magenta,Color.pink));

          

               Button b3=new Button("CHANGE COL");

               centre.add(b3);

               b3.addActionListener(new ActionListener()

               {

                    public void actionPerformed(ActionEvent e)

                    {

                         Container c=getContentPane();

                         color=JColorChooser.showDialog(form.this,"Choose a color",color);

                         if (color==null)

                             color=Color.black;

                              centre.setBackground(color);

                              centre.repaint();

                              //top.setBackground(color);

                              //top.repaint();

                              //bottom.setBackground(color);

                              //bottom.repaint();

                         

                    }

               });

               

               

               b1.addActionListener(new ActionListener()

               {

               public void actionPerformed(ActionEvent e)

     {

          s1=scr.getText();

          JOptionPane.showMessageDialog(null,"The name is"+" "+s1);

          s2=screen.getText();

          JOptionPane.showMessageDialog(null,"His E_Mail Addres is"+" "+s2);

          s3=a.getText();

          JOptionPane.showMessageDialog(null,"Message is"+s3);

                s5=color.toString();

          s4+=s1+"  "+" "+s2;

          JOptionPane.showMessageDialog(null,""+s4);          

          JOptionPane.showMessageDialog(null,""+s5);          



     }

                    });



     b2.addActionListener(new ActionListener()

               {

               public void actionPerformed(ActionEvent e)

     {



         dispose();

            System.exit(0);



     }

                    });



               

               setSize(800,500);

               show();

          }

               

               public static void main(String args[])

               

               {

                    form app=new form();

                    

                    app.addWindowListener(

                    new WindowAdapter()

                    {

                         public void windowClosing(WindowEvent e)

                         {

                              System.exit(0);

                         }

                    }

                    

               

               );

               }

               

               

               

     

     }          