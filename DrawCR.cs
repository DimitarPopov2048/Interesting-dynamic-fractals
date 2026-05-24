using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FractalCR
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		static int br = 0;
        static Pen [] A = new Pen[7]
        {new Pen(Color.Yellow),new Pen(Color.Red), new Pen(Color.White),
        new Pen(Color.LightGreen), new Pen(Color.Cyan), new Pen(Color.Blue), new Pen(Color.Purple)};
        static double ang2 = 0;
        static double xs = 0; static double ys = 0;
        void DrawC(double x, float y, double R, double ang, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawEllipse(A[br%7],new RectangleF((float)(x-R),(float)(y-R),(float)(2*R),(float)(2*R)));
            g.DrawEllipse(A[br%7],new RectangleF((float)(x-R*Math.Cos(ang*Math.PI/180)-R/2),(float)(y+R*Math.Sin(ang*Math.PI/180)-R/2),(float)R,(float)R));
            g.DrawEllipse(A[br%7],new RectangleF((float)(x+R*Math.Cos(ang*Math.PI/180)-R/2),(float)(y-R*Math.Sin(ang*Math.PI/180)-R/2),(float)R,(float)R));
            if(R>20)
            {
                DrawC((float)(x-R*Math.Cos(ang*Math.PI/180)),(float)(y+R*Math.Sin(ang*Math.PI/180)),R/2,ang,e);
                DrawC((float)(x+R*Math.Cos(ang*Math.PI/180)),(float)(y-R*Math.Sin(ang*Math.PI/180)),R/2,ang,e);
            }
        }
        void DrawCR(double x, float y, double R, double ang, double n, double R2, PaintEventArgs e)
        {
            if(br<n)
            {
                //x += 1;
                if(br == 0)
                {
                    xs = x;
                    ys = y-R2;
                }
                if(x>=xs)
                {
                    x += (float)(-(x-xs)*Math.Cos((n-2)/(2*n)*Math.PI) + (y-ys)*Math.Sin((n-2)/(n)*Math.PI));
                    y += (float)(-(y-ys)*Math.Cos((n-2)/(2*n)*Math.PI) - (x-xs)*Math.Sin((n-2)/(n)*Math.PI));
                }
                else
                {
                    x -= (float)((x-xs)*Math.Cos((n-2)/(2*n)*Math.PI) - (y-ys)*Math.Sin((n-2)/(n)*Math.PI));
                    y += (float)((y-ys)*Math.Cos((n-2)/(2*n)*Math.PI) + (x-xs)*Math.Sin((n-2)/(n)*Math.PI));
                }
                DrawC(x,y,R,ang+ang2,e);
                br++;
                ang2 += (n-2)/n*180;
                DrawCR(x,y,R,ang+ang2,n,R2,e);
            }
        }
        void Panel1Paint(object sender, PaintEventArgs e)
        {
            //DrawC(panel1.Width/2,panel1.Height/2,200,0,e);
        	DrawCR(panel1.Width/2,panel1.Height/2,150,0,500,150,e);
        }
	}
}
