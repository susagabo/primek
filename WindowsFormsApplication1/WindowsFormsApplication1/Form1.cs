using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        Bitmap buffer;
        Graphics bufferg;

       
        private void panel2_Resize(object sender, EventArgs e)
        {

        }


        Thread t;


        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            t = new Thread(new ThreadStart(szal));
            t.Start();

        }
        void szal()
        {

            bufferg.Clear(Color.White);

            int h, w;

            lock (buffer)
            {
                h = buffer.Height;
                w = buffer.Width;

            }

            for (int j = 0; j < h; j++)
                for (int i = 0; i < w; i++)
                    if ((j * w + i) % 8 == 1)
                        lock (buffer)
                            buffer.SetPixel(i, j, Color.Blue);

            this.Invoke(new Action(() => { button1.Enabled = true; }));

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (buffer == null)
                return;

            using (Graphics g = panel2.CreateGraphics()) 
            {

                lock (buffer)
                    g.DrawImage(buffer, 0, 0);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buffer = new Bitmap(panel2.Width, panel2.Height);
            bufferg = Graphics.FromImage(buffer);
        }
    }
}
