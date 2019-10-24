using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Telerik;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Threading;
namespace TelerikWinFormsApp1
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {



        float pos_x, pos_y;


        Pen myPen;
        Color[] k = { Color.Red, Color.Yellow, Color.Green, Color.Gray, Color.Black, Color.Blue, Color.Brown, Color.Aqua, Color.Pink, Color.DarkOliveGreen };
        Graphics g;

        Thread t;
        public RadForm1()
        {
            InitializeComponent();
            
            pos_x = panel1.Width / 2;
            pos_y = panel1.Height / 2;
        }
        



        private void draw(int n, float x, float y, float r)
        {
            if (n > 0)
            {
                myPen = new Pen(k[n - 1]);

                for (int i = 0; i < 5; i++)
                {
                    g.DrawLine(myPen, x,y, (float)(x + r * System.Math.Cos((i * 1.256))),(float)(y - r * System.Math.Sin(i * 1.256)));
                }
                if (n > 1)
                {

                    for (int i = 0; i < 5; i++)
                    {
                        float x1 =(float) (x + r * System.Math.Cos((i * 1.256)));
                        float y1 = (float)(y - r * System.Math.Sin(i * 1.256));
                        float r1 = r / 3;
                        draw(n - 1,x1, y1, r1);
                      
                    }
                }
            }
        }

     

     

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (radTextBox1.Text != "" && radTextBox2.Text != "")
            {
                g = panel1.CreateGraphics();
                int n = Int32.Parse(radTextBox1.Text);
                float r = float.Parse(radTextBox2.Text);
              t =new Thread(new ThreadStart(()=>  draw(n, pos_x, pos_y, r)));
                t.Start();
               
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            panel1.Refresh();

        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            t.Abort();
        }

    
    }
}
