Source Code : Text Tool

import java.awt.*; 

import java.awt.event.*; 



class TextTool implements KeyEventTool {



  public void mousePressed(Point p, ScribbleCanvas canvas) {

    canvas.mouseButtonDown = true;

    canvas.x = p.x; 

    canvas.y = p.y; 

    offscreen = canvas.getOffScreenGraphics(); 

    offscreen.setFont(font); 

    text = new StringBuffer(); 

  }



  public void mouseReleased(Point p, ScribbleCanvas canvas) {

    canvas.mouseButtonDown = false; 

  }



  public void mouseDragged(Point p, ScribbleCanvas canvas) {} 



  public void keyPressed(char c, ScribbleCanvas canvas) { 

    text.append(c); 

    offscreen.drawString(text.toString(), canvas.x, canvas.y); 

    canvas.repaint(canvas.x, canvas.y - ascent - 1, 

             fm.stringWidth(text.toString()) + 1, 

             ascent + descent + 2); 

  }



  protected StringBuffer text; 

  protected Font font = new Font("Helvetica", Font.BOLD, 24);

  protected FontMetrics fm = Toolkit.getDefaultToolkit().getFontMetrics(font);  

  protected int ascent = fm.getAscent();

  protected int descent = fm.getDescent();

  protected Graphics offscreen; 



}