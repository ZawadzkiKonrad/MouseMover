using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseMover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs ee)
        {
           

            System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

            exitFlag = false;
            this.Cursor = new Cursor(Cursor.Current.Handle);
            //Cursor.Position = new Point(0, 1);

            void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
            {
                //Cursor.Clip = new Rectangle(this.Location, this.Size);

                int posX = (int)numericUpDown2.Value;
                int posY = (int)numericUpDown3.Value;

                if (temp==true)
                {
                    Cursor.Position = new Point(Cursor.Position.X - posX, Cursor.Position.Y - posY);
                    temp = false;
                }
                else
                {
                    Cursor.Position = new Point(Cursor.Position.X + posX, Cursor.Position.Y + posY);
                    temp = true;
                }
            }
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            int mul;
            if (radioButton1.Checked)
            {
                mul = 1000;
            }
            else 
            {
                mul = 1;
            }
            int inter= (int)(numericUpDown1.Value*mul);
            myTimer.Interval = inter;
            myTimer.Start();

            while (exitFlag == false)
            {
                Application.DoEvents();

            }
            if (exitFlag==true)
            {
                myTimer.Stop();
               // Application.Exit();
            }
            

        }




        //private bool nonNumberEntered = false;
        private bool exitFlag;
        private bool temp;


     
       

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                exitFlag = true;
                //MessageBox.Show("wyłaczone");
                
                
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

