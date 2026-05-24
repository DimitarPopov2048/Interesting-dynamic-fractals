using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace FPyt
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
		public static int br = 0;
		public static int brr = 0;
		public static void DrawF(double x, double y, double x1, double y1, double n, Pen p, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if(br == 0)
            {
            	g.DrawLine(p,(float)x,(float)y,(float)x1,(float)y1);
            }
            VR(x,y,ref x1,ref y1,(n-2)/n*180);
            g.DrawLine(p,(float)x,(float)y,(float)x1,(float)y1);
            br++;
            if(br<n-1)
            {
            	DrawF(x1,y1,x,y,n,p,e);
            }
            br = 0;
		}
		public static void VR(double x1, double y1, ref double x2, ref double y2, double ang)
		{
			double x3 =  x1 + (x2-x1)*Math.Cos(ang*Math.PI/180) + (y2-y1)*Math.Sin(ang*Math.PI/180);
            double y3 =  y1 + (y2-y1)*Math.Cos(ang*Math.PI/180) - (x2-x1)*Math.Sin(ang*Math.PI/180);
            x2 = x3; y2 = y3;
            return;
		}
		public static void PLine(double x, double y, double x1, double y1, double len, double ang, Pen p, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
            double xv = x + (x1-x)*Math.Cos(ang/180*Math.PI) - (y1-y)*Math.Sin(ang/180*Math.PI);
            double yv = y + (y1-y)*Math.Cos(ang/180*Math.PI) + (x1-x)*Math.Sin(ang/180*Math.PI);
            x1 = xv; y1 = yv;
			
			double dx = x1-x; double dy = y1-y;
			double x2,x3 = x; double y2,y3 = y; x2 = x; y2 = y;
			if(Math.Round(dx) != 0 && Math.Round(dy) != 0)
			{
				double tg = dy/dx;
				if(dx>0)
				{
					while(x3<x1-2*Math.Cos(Math.Atan(tg))*len)
					{
						x3 += Math.Cos(Math.Atan(tg))*len;
						y3 += Math.Sin(Math.Atan(tg))*len;
						g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
						x2 += 2*Math.Cos(Math.Atan(tg))*len;
						y2 += 2*Math.Sin(Math.Atan(tg))*len;
						x3 += Math.Cos(Math.Atan(tg))*len;
						y3 += Math.Sin(Math.Atan(tg))*len;
					}
					x2 = x3; y2 = y3; x3 = x1; y3 = y1;
					g.DrawLine(new Pen(Color.Black),(float)x2,(float)y2,(float)x3,(float)y3);
				}
				else if(dx<0)
				{
					while(x3>x1+2*Math.Cos(Math.Atan(tg))*len)
					{
						x3 -= Math.Cos(Math.Atan(tg))*len;
						y3 -= Math.Sin(Math.Atan(tg))*len;
						g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
						x2 -= 2*Math.Cos(Math.Atan(tg))*len;
						y2 -= 2*Math.Sin(Math.Atan(tg))*len;
						x3 -= Math.Cos(Math.Atan(tg))*len;
						y3 -= Math.Sin(Math.Atan(tg))*len;
					}
					x2 = x3; y2 = y3; x3 = x1; y3 = y1;
					g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
				}
			}
			else if(Math.Round(dx) == 0)
			{
				if(dy>0)
				{
					while(y3<y1-2*len)
					{
						y3 += len;
						g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
						y2 += 2*len;
						y3 += len;
					}
					y2 = y3; y3 = y1;
					g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
				}
				else
				{
					while(y3>y1+2*len)
					{
						y3 -= len;
						g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
						y2 -= 2*len;
						y3 -= len;
					}
					y2 = y3; y3 = y1;
					g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
				}
			}
			else
			{
				if(dx>0)
				{
					while(x3<x1-len)
					{
						x3 += len;
						g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
						x2 += 2*len;
						x3 += len;
					}
					x2 = x3; x3 = x1;
					g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
				}
				else
				{
					while(x3>x1+len)
					{
						x3 -= len;
						g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
						x2 -= 2*len;
						x3 -= len;
					}
					x2 = x3; x3 = x1;
					g.DrawLine(p,(float)x2,(float)y2,(float)x3,(float)y3);
				}
			}
		}
		public static void FP(double xr, double yr, double a, double r, double ang, Pen p, PaintEventArgs e)
		{
			double x1 = xr-a/2; double y1 = yr-a;
			double x2 = xr+a/2; double y2 = yr-a;
			VR(xr,yr,ref x1,ref y1,ang);
			VR(xr,yr,ref x2,ref y2,ang);
			DrawF(x2,y2,x1,y1,4,p,e);
			DM(x1,y1,x2,y2,r,p,e);
		}
		
		public static void DM(double x1, double y1, double x2, double y2, double r, Pen p, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawLine(p,(float)x1,(float)y1,(float)x2,(float)y2);
			double x3 = x1 + (x2-x1)*r; double y3 = y1 - (y1-y2)*r;
			double h = Math.Sqrt(Math.Sqrt(Math.Pow(x2-x3,2) + Math.Pow(y2-y3,2))*Math.Sqrt(Math.Pow(x1-x3,2) + Math.Pow(y1-y3,2)));
			double xh = x3+h; double yh = y3;
			if(x1 != x2)
			{
				double tg = (y1-y2)/(x2-x1);
				if(x2<x1)
				{
					xh = x3-h;
				}
				VR(x3,y3,ref xh, ref yh,90+Math.Atan(tg)/Math.PI*180);
			}
			else
			{
				if(y2<y1)
				{
					VR(x3,y3,ref xh, ref yh,180);
				}
			}
			DrawF(x1,y1,xh,yh,4,p,e);
			DrawF(xh,yh,x2,y2,4,p,e);
			brr++;
			double lena = Math.Sqrt(Math.Pow(x1-xh,2) + Math.Pow(y1-yh,2));
			double lenb = Math.Sqrt(Math.Pow(x2-xh,2) + Math.Pow(y2-yh,2));
			if(lena>10 && lenb>10 && lena<166 && lenb<166)
			{
				double xhn = xh; double yhn = yh;
				VR(x1,y1,ref xh, ref yh,90);
				VR(xh,yh,ref x1, ref y1,90);
				DM(xh,yh,x1,y1,r,p,e);
				VR(xhn,yhn,ref x2, ref y2,90);
				VR(x2,y2,ref xhn, ref yhn,90);
				DM(x2,y2,xhn,yhn,r,p,e);
			}
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			double r = 0.3;
			double a = 125;
			double ang = 45;
			double xr = panel1.Width/2; double yr = panel1.Height/2;
			FP(xr,yr+a/2+200,a,r,ang,new Pen(Color.Black),e);
			/*var s = new Stopwatch();
			s.Start();
			for(int i = 0; i<360; i++)
			{
				i--;
				if(s.ElapsedMilliseconds%300 == 0)
				{
					FP(xr,yr,a,r,i,new Pen(Color.Bisque),e);
					i += 10;
					FP(xr,yr,a,r,i,new Pen(Color.Black),e);
				}
			}*/
		}

	}
}
