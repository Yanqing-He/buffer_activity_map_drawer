using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_drawing
{
    public partial class MainWindow : Form
    {
        private ProcElem[] procElems;
        private Register[] registers;

        private Form1 figure;

        double titr;

        string ver;

        public MainWindow()
        {
            InitializeComponent();

            ver = "freq. selection Ver. 0.4 ---- By Yanqing He (MOODY_Y)";
            this.Text = ver;

            procElems = new ProcElem[4];
            registers = new Register[5];

            int i;

            for (i = 0; i < 4; i++)
            {
                procElems[i] = new ProcElem();
            }
            for (i = 0; i < 5; i++)
            {
                registers[i] = new Register();
            }
            
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (figure == null)
            {
                figure = new Form1();
                figure.Show();
            }

            int initWidth = 15;
            string[] labels = new string[10];
            labels[0] = "B1\nw";
            labels[1] = "B4\nw";
            labels[2] = "B1\nr";
            labels[3] = "B3\nr";
            labels[4] = "B4\nr";
            labels[5] = "B2\nw";
            labels[6] = "B5\nw";
            labels[7] = "B2\nr";
            labels[8] = "B5\nr";
            labels[9] = "B3\nw";

            Graphics formGraphics = figure.CreateGraphics();
            formGraphics.Clear(Color.White);
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.RoyalBlue);
            int i;
            for (i = 1; i < this.figure.Width / initWidth; i++)
            {
                string dispStr = i.ToString();
                Font strFont = new Font("Consolas", 6);
                SolidBrush strBrush = new SolidBrush(System.Drawing.Color.Black);
                formGraphics.DrawString(dispStr, strFont, strBrush, (i + 1) * initWidth - 10, 0);
                formGraphics.DrawLine(myPen, i * initWidth, 20, i * initWidth, this.figure.Height);
                strFont.Dispose();
                strBrush.Dispose();
            }
            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(myPen, 0, 20 + 40 * i,
                    this.figure.Width, 20 + 40 * i);
                if (i < 10)
                {
                    Font strFont = new Font("Consolas", 9);
                    SolidBrush strBrush = new SolidBrush(System.Drawing.Color.Black);
                    formGraphics.DrawString(labels[i], strFont, strBrush, 0, 30 + 40 * i);
                    strFont.Dispose();
                    strBrush.Dispose();
                }
            }

            // drawing bars
            double curDelay;

            // B1 Write
            formGraphics.FillRectangle(new SolidBrush(Color.Green), 
                new Rectangle(System.Convert.ToInt32(initWidth), 
                    20, System.Convert.ToInt32(initWidth / procElems[0].Freq * 10), 20));
            label12.Text = "Start: " + System.Convert.ToString(0);
            label13.Text = "End: " + System.Convert.ToString((initWidth / procElems[0].Freq * 10) / initWidth);
            if (label12.Text.Length > 13)
            {
                label12.Text = label12.Text.Substring(0, 13);
            }
            if (label13.Text.Length > 13)
            {
                label13.Text = label13.Text.Substring(0, 13);
            }

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black), System.Convert.ToInt32(initWidth + initWidth / procElems[0].Freq * i),
                    20, System.Convert.ToInt32(initWidth + initWidth / procElems[0].Freq * i), 60);
            }

            //B4 Write
            formGraphics.FillRectangle(new SolidBrush(Color.Green),
                new Rectangle(System.Convert.ToInt32(initWidth),
                    20 + 40 * 1, System.Convert.ToInt32(initWidth / procElems[0].Freq * 10), 20));

            label14.Text = "Start: " + System.Convert.ToString(0);
            label15.Text = "End: " + System.Convert.ToString((initWidth / procElems[0].Freq * 10) / initWidth);
            if (label14.Text.Length > 13)
            {
                label14.Text = label14.Text.Substring(0, 13);
            }
            if (label15.Text.Length > 13)
            {
                label15.Text = label15.Text.Substring(0, 13);
            }

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black), 
                    System.Convert.ToInt32(initWidth + initWidth / procElems[0].Freq * i),
                    20 + 40 * 1, 
                    System.Convert.ToInt32(initWidth + initWidth / procElems[0].Freq * i), 
                    60 + 40 * 1);
            }

            curDelay = initWidth;

            // B1 Read
            formGraphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(
                    System.Convert.ToInt32(initWidth + (initWidth / procElems[1].Freq) * registers[0].Delay),
                    20 + 40 * 2, 
                    System.Convert.ToInt32(initWidth / procElems[1].Freq * 10), 
                    20));

            label17.Text = "Start: " +
                System.Convert.ToString((initWidth / procElems[1].Freq) * registers[0].Delay / initWidth);
            label16.Text = "End: " + System.Convert.ToString(((initWidth / procElems[1].Freq) * registers[0].Delay) / initWidth
                + (initWidth / procElems[1].Freq * 10) / initWidth);
            if (label16.Text.Length > 13)
            {
                label16.Text = label16.Text.Substring(0, 13);
            }
            if (label17.Text.Length > 13)
            {
                label17.Text = label17.Text.Substring(0, 13);
            }

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black), 
                    System.Convert.ToInt32(initWidth 
                    + (initWidth / procElems[1].Freq) * registers[0].Delay
                    + (initWidth / procElems[1].Freq) * i),
                    20 + 40 * 2, System.Convert.ToInt32(initWidth 
                    + (initWidth / procElems[1].Freq) * registers[0].Delay
                    + (initWidth / procElems[1].Freq) * i), 60 + 40 * 2);
            }

            // B3 Read
            formGraphics.FillRectangle(new SolidBrush(Color.Red),
                new Rectangle(System.Convert.ToInt32(initWidth + (initWidth / procElems[1].Freq) * registers[0].Delay),
                    20 + 40 * 3, System.Convert.ToInt32(initWidth / procElems[1].Freq * 10), 20));

            label19.Text = "Start: " +
                System.Convert.ToString(((initWidth / procElems[1].Freq) * registers[0].Delay) / initWidth);
            label18.Text = "End: " + 
                System.Convert.ToString(((initWidth / procElems[1].Freq) * registers[0].Delay) / initWidth + 
                System.Convert.ToInt32(initWidth / procElems[1].Freq * 10) / initWidth);
            if (label18.Text.Length > 13)
            {
                label18.Text = label18.Text.Substring(0, 13);
            }
            if (label19.Text.Length > 13)
            {
                label19.Text = label19.Text.Substring(0, 13);
            }

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black), 
                    System.Convert.ToInt32(initWidth + (initWidth / procElems[1].Freq * registers[0].Delay)
                    + (initWidth / procElems[1].Freq) * i),
                    20 + 40 * 3,
                    System.Convert.ToInt32(initWidth + (initWidth / procElems[1].Freq * registers[0].Delay)
                    + (initWidth / procElems[1].Freq) * i), 60 + 40 * 3);
            }

            //B4 Read
            formGraphics.FillRectangle(new SolidBrush(Color.Orange),
                new Rectangle(System.Convert.ToInt32(initWidth + (initWidth / procElems[3].Freq) * registers[3].Delay),
                    20 + 40 * 4, System.Convert.ToInt32(initWidth / procElems[3].Freq * 10), 20));

            label21.Text = "Start: " +
                System.Convert.ToString(((initWidth / procElems[3].Freq) * registers[3].Delay) / initWidth);
            label20.Text = "End: " +
                System.Convert.ToString(((initWidth / procElems[3].Freq) * registers[3].Delay) / initWidth +
                (initWidth / procElems[3].Freq * 10) / initWidth);
            if (label20.Text.Length > 13)
            {
                label20.Text = label20.Text.Substring(0, 13);
            }
            if (label21.Text.Length > 13)
            {
                label21.Text = label21.Text.Substring(0, 13);
            }

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth + (initWidth / procElems[3].Freq * registers[3].Delay)
                    + (initWidth / procElems[3].Freq) * i),
                    20 + 40 * 4,
                    System.Convert.ToInt32(initWidth + (initWidth / procElems[3].Freq * registers[3].Delay)
                    + (initWidth / procElems[3].Freq) * i), 
                60 + 40 * 4);
            }

            curDelay = (initWidth / procElems[1].Freq) * registers[0].Delay;

            // B2 Write
            formGraphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(
                    System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[1].Freq)) * initWidth / procElems[1].Freq
                    + (initWidth / procElems[1].Freq) * procElems[1].Latency),
                    20 + 40 * 5, 
                    System.Convert.ToInt32(initWidth / procElems[1].Freq * 10), 20));

            label23.Text = "Start: " + 
                System.Convert.ToString((Math.Ceiling(curDelay / (initWidth / procElems[1].Freq)) * initWidth / procElems[1].Freq
                    + (initWidth / procElems[1].Freq) * procElems[1].Latency) / initWidth);
            label22.Text = "End: " +
                System.Convert.ToString((Math.Ceiling(curDelay / (initWidth / procElems[1].Freq)) * initWidth / procElems[1].Freq
                    + (initWidth / procElems[1].Freq) * procElems[1].Latency + (initWidth / procElems[1].Freq * 10)) / initWidth);
            if (label22.Text.Length > 13)
            {
                label22.Text = label22.Text.Substring(0, 13);
            }
            if (label23.Text.Length > 13)
            {
                label23.Text = label23.Text.Substring(0, 13);
            }

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[1].Freq)) * initWidth / procElems[1].Freq
                    + (initWidth / procElems[1].Freq) * procElems[1].Latency
                    + (initWidth / procElems[1].Freq) * i),
                    20 + 40 * 5,
                   System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[1].Freq)) * initWidth / procElems[1].Freq
                    + (initWidth / procElems[1].Freq) * procElems[1].Latency
                    + (initWidth / procElems[1].Freq) * i),
                60 + 40 * 5);
            }

            curDelay = (initWidth / procElems[3].Freq) * registers[3].Delay;

            // B5 Write
            formGraphics.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(
                System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                + (initWidth / procElems[3].Freq) * procElems[3].Latency),
                    20 + 40 * 6, 
                    System.Convert.ToInt32(initWidth / procElems[3].Freq * 10), 
                    20));

            label25.Text = "Start: " +
                System.Convert.ToString((Math.Ceiling(curDelay / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                + (initWidth / procElems[3].Freq) * procElems[3].Latency) / initWidth);
            label24.Text = "End: " +
                System.Convert.ToString((Math.Ceiling(curDelay / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                + (initWidth / procElems[3].Freq) * procElems[3].Latency + (initWidth / procElems[3].Freq * 10)) / initWidth);
            if (label24.Text.Length > 13)
            {
                label24.Text = label24.Text.Substring(0, 13);
            }
            if (label25.Text.Length > 13)
            {
                label25.Text = label25.Text.Substring(0, 13);
            }

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                + (initWidth / procElems[3].Freq) * procElems[3].Latency
                    + (initWidth / procElems[3].Freq) * i),
                    20 + 40 * 6,
                    System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                + (initWidth / procElems[3].Freq) * procElems[3].Latency
                    + (initWidth / procElems[3].Freq) * i),
                60 + 40 * 6);
            }

            curDelay = (initWidth / procElems[3].Freq) * registers[3].Delay
                + (initWidth / procElems[1].Freq) * procElems[1].Latency;

            // B2 Read
            formGraphics.FillRectangle(new SolidBrush(Color.DeepPink),
                new Rectangle(System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay),
                    20 + 40 * 7, System.Convert.ToInt32(initWidth / procElems[2].Freq * 10), 20));

            label27.Text = "Start: " + 
                System.Convert.ToString((Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay) / initWidth);
            label26.Text = "End: " +
                System.Convert.ToString((Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay + (initWidth / procElems[2].Freq * 10)) / initWidth);
            if (label26.Text.Length > 13)
            {
                label26.Text = label26.Text.Substring(0, 13);
            }
            if (label27.Text.Length > 13)
            {
                label27.Text = label27.Text.Substring(0, 13);
            }

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                   System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay
                    + (initWidth / procElems[2].Freq) * i),
                    20 + 40 * 7,
                    System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay
                    + (initWidth / procElems[2].Freq) * i),
                60 + 40 * 7);
            }


            //curDelay = (initWidth / procElems[3].Freq) * registers[3].Delay
                //+ (initWidth / procElems[1].Freq) * procElems[1].Latency;
            // B5 Read
            formGraphics.FillRectangle(new SolidBrush(Color.DeepPink),
                new Rectangle(System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay),
                    20 + 40 * 8, System.Convert.ToInt32(initWidth / procElems[2].Freq * 10), 20));

            label29.Text = "Start: " +
                System.Convert.ToString((Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[4].Delay) / initWidth);
            label28.Text = "End: " + 
                System.Convert.ToString((Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[4].Delay + (initWidth / procElems[2].Freq * 10)) / initWidth);
            if (label28.Text.Length > 13)
            {
                label28.Text = label28.Text.Substring(0, 13);
            }
            if (label29.Text.Length > 13)
            {
                label29.Text = label29.Text.Substring(0, 13);
            }

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[4].Delay
                    + (initWidth / procElems[2].Freq) * i),
                    20 + 40 * 8,
                    System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[4].Delay
                    + (initWidth / procElems[2].Freq) * i),
                60 + 40 * 8);
            }

            curDelay = (initWidth / procElems[3].Freq) * registers[3].Delay
                + (initWidth / procElems[1].Freq) * procElems[1].Latency
                + (initWidth / procElems[2].Freq) * registers[1].Delay;
            // B3 Write
            formGraphics.FillRectangle(new SolidBrush(Color.DeepPink),
                new Rectangle(System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * procElems[2].Latency),
                    20 + 40 * 9, System.Convert.ToInt32(initWidth / procElems[2].Freq * 10), 20));

            label31.Text = "Start: " + 
                System.Convert.ToString((Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * procElems[2].Latency) / initWidth);
            label30.Text = "Start: " + 
                System.Convert.ToString((Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * procElems[2].Latency + (initWidth / procElems[2].Freq * 10)) / initWidth);
            if (label30.Text.Length > 13)
            {
                label30.Text = label30.Text.Substring(0, 13);
            }
            if (label31.Text.Length > 13)
            {
                label31.Text = label31.Text.Substring(0, 13);
            }

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                   System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * procElems[2].Latency
                    + (initWidth / procElems[2].Freq) * i),
                    20 + 40 * 9,
                    System.Convert.ToInt32(initWidth + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * procElems[2].Latency
                    + (initWidth / procElems[2].Freq) * i),
                60 + 40 * 9);
            }

            // end drawing bars

            // drawing second iteration

            formGraphics.FillRectangle(new SolidBrush(Color.Green),
    new Rectangle(System.Convert.ToInt32(initWidth + 
        Math.Ceiling(titr * initWidth / (initWidth / procElems[0].Freq)) * (initWidth / procElems[0].Freq)),
        20, System.Convert.ToInt32(initWidth / procElems[0].Freq * 10), 20));

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black), 
                    System.Convert.ToInt32(initWidth + 
        Math.Ceiling(titr * initWidth / (initWidth / procElems[0].Freq)) * (initWidth / procElems[0].Freq)
                    + initWidth / procElems[0].Freq * i),
                    20, 
                    System.Convert.ToInt32(initWidth + 
        Math.Ceiling(titr * initWidth / (initWidth / procElems[0].Freq)) * (initWidth / procElems[0].Freq)
                    + initWidth / procElems[0].Freq * i), 60);
            }

            formGraphics.FillRectangle(new SolidBrush(Color.Green),
                new Rectangle(System.Convert.ToInt32(initWidth +
                    Math.Ceiling(titr * initWidth / (initWidth / procElems[0].Freq)) * (initWidth / procElems[0].Freq)),
                    20 + 40 * 1, System.Convert.ToInt32(initWidth / procElems[0].Freq * 10), 20));

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth + 
                    Math.Ceiling(titr * initWidth / (initWidth / procElems[0].Freq)) * (initWidth / procElems[0].Freq)
                    + initWidth / procElems[0].Freq * i),
                    20 + 40 * 1,
                    System.Convert.ToInt32(initWidth + 
                    Math.Ceiling(titr * initWidth / (initWidth / procElems[0].Freq)) * (initWidth / procElems[0].Freq)
                    + initWidth / procElems[0].Freq * i),
                    60 + 40 * 1);
            }

            curDelay = initWidth;

            formGraphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[1].Freq)) * (initWidth / procElems[1].Freq)
                    + (initWidth / procElems[1].Freq) * registers[0].Delay),
                    20 + 40 * 2,
                    System.Convert.ToInt32(initWidth / procElems[1].Freq * 10),
                    20));

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[1].Freq)) * (initWidth / procElems[1].Freq)
                    + (initWidth / procElems[1].Freq) * registers[0].Delay
                    + (initWidth / procElems[1].Freq) * i),
                    20 + 40 * 2, System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[1].Freq)) * (initWidth / procElems[1].Freq)
                    + (initWidth / procElems[1].Freq) * registers[0].Delay
                    + (initWidth / procElems[1].Freq) * i), 60 + 40 * 2);
            }

            formGraphics.FillRectangle(new SolidBrush(Color.Red),
                new Rectangle(System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[1].Freq)) * (initWidth / procElems[1].Freq)
                    + (initWidth / procElems[1].Freq) * registers[0].Delay),
                    20 + 40 * 3, System.Convert.ToInt32(initWidth / procElems[1].Freq * 10), 20));

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth + 
                    Math.Ceiling(titr * initWidth / (initWidth / procElems[1].Freq)) * (initWidth / procElems[1].Freq)
                    + (initWidth / procElems[1].Freq * registers[0].Delay)
                    + (initWidth / procElems[1].Freq) * i),
                    20 + 40 * 3,
                    System.Convert.ToInt32(initWidth +
                    Math.Ceiling(titr * initWidth / (initWidth / procElems[1].Freq)) * (initWidth / procElems[1].Freq)
                    + (initWidth / procElems[1].Freq * registers[0].Delay)
                    + (initWidth / procElems[1].Freq) * i),
                    60 + 40 * 3);
            }

            formGraphics.FillRectangle(new SolidBrush(Color.Orange),
                new Rectangle(System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                    + (initWidth / procElems[3].Freq) * registers[3].Delay),
                    20 + 40 * 4, System.Convert.ToInt32(initWidth / procElems[3].Freq * 10), 20));

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                    + (initWidth / procElems[3].Freq * registers[3].Delay)
                    + (initWidth / procElems[3].Freq) * i),
                    20 + 40 * 4,
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                    + (initWidth / procElems[3].Freq * registers[3].Delay)
                    + (initWidth / procElems[3].Freq) * i),
                60 + 40 * 4);
            }

            curDelay = (initWidth / procElems[1].Freq) * registers[0].Delay;

            formGraphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[1].Freq)) * (initWidth / procElems[1].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[1].Freq)) * initWidth / procElems[1].Freq
                    + (initWidth / procElems[1].Freq) * procElems[1].Latency),
                    20 + 40 * 5,
                    System.Convert.ToInt32(initWidth / procElems[1].Freq * 10), 20));

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[1].Freq)) * (initWidth / procElems[1].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[1].Freq)) * initWidth / procElems[1].Freq
                    + (initWidth / procElems[1].Freq) * procElems[1].Latency
                    + (initWidth / procElems[1].Freq) * i),
                    20 + 40 * 5,
                   System.Convert.ToInt32(initWidth
                   + Math.Ceiling(titr * initWidth / (initWidth / procElems[1].Freq)) * (initWidth / procElems[1].Freq)
                   + Math.Ceiling(curDelay / (initWidth / procElems[1].Freq)) * initWidth / procElems[1].Freq
                    + (initWidth / procElems[1].Freq) * procElems[1].Latency
                    + (initWidth / procElems[1].Freq) * i),
                60 + 40 * 5);
            }

            curDelay = (initWidth / procElems[3].Freq) * registers[3].Delay;

            formGraphics.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(
                System.Convert.ToInt32(initWidth
                + Math.Ceiling(titr * initWidth / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                + Math.Ceiling(curDelay / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                + (initWidth / procElems[3].Freq) * procElems[3].Latency),
                    20 + 40 * 6,
                    System.Convert.ToInt32(initWidth / procElems[3].Freq * 10),
                    20));

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                + (initWidth / procElems[3].Freq) * procElems[3].Latency
                    + (initWidth / procElems[3].Freq) * i),
                    20 + 40 * 6,
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[3].Freq)) * (initWidth / procElems[3].Freq)
                + (initWidth / procElems[3].Freq) * procElems[3].Latency
                    + (initWidth / procElems[3].Freq) * i),
                60 + 40 * 6);
            }

            curDelay = (initWidth / procElems[3].Freq) * registers[3].Delay
                + (initWidth / procElems[1].Freq) * procElems[1].Latency;

            formGraphics.FillRectangle(new SolidBrush(Color.DeepPink),
                new Rectangle(System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay),
                    20 + 40 * 7, System.Convert.ToInt32(initWidth / procElems[2].Freq * 10), 20));

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                   System.Convert.ToInt32(initWidth
                   + Math.Ceiling(titr * initWidth / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                   + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay
                    + (initWidth / procElems[2].Freq) * i),
                    20 + 40 * 7,
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay
                    + (initWidth / procElems[2].Freq) * i),
                60 + 40 * 7);
            }


            //curDelay = (initWidth / procElems[3].Freq) * registers[3].Delay
                //+ (initWidth / procElems[3].Freq) * procElems[3].Latency;

            formGraphics.FillRectangle(new SolidBrush(Color.DeepPink),
                new Rectangle(System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay),
                    20 + 40 * 8, System.Convert.ToInt32(initWidth / procElems[2].Freq * 10), 20));

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay
                    + (initWidth / procElems[2].Freq) * i),
                    20 + 40 * 8,
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * registers[1].Delay
                    + (initWidth / procElems[2].Freq) * i),
                60 + 40 * 8);
            }

            curDelay = (initWidth / procElems[3].Freq) * registers[3].Delay
                + (initWidth / procElems[1].Freq) * procElems[1].Latency
                + (initWidth / procElems[2].Freq) * registers[1].Delay;

            formGraphics.FillRectangle(new SolidBrush(Color.DeepPink),
                new Rectangle(System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * procElems[2].Latency),
                    20 + 40 * 9, System.Convert.ToInt32(initWidth / procElems[2].Freq * 10), 20));

            for (i = 0; i < 11; i++)
            {
                formGraphics.DrawLine(new Pen(Color.Black),
                   System.Convert.ToInt32(initWidth
                   + Math.Ceiling(titr * initWidth / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                   + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * procElems[2].Latency
                    + (initWidth / procElems[2].Freq) * i),
                    20 + 40 * 9,
                    System.Convert.ToInt32(initWidth
                    + Math.Ceiling(titr * initWidth / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + Math.Ceiling(curDelay / (initWidth / procElems[2].Freq)) * (initWidth / procElems[2].Freq)
                    + (initWidth / procElems[2].Freq) * procElems[2].Latency
                    + (initWidth / procElems[2].Freq) * i),
                60 + 40 * 9);
            }
            
            // end drawing second iteration
        }


        private void PoneLat_TextChanged(object sender, EventArgs e)
        {
            if (PoneLat.Text != "")
            {
                this.procElems[0].Freq = System.Convert.ToDouble(PoneLat.Text.ToString());
            }
        }

        private void PtweLat_TextChanged(object sender, EventArgs e)
        {
            if (PtwoLat.Text != "")
            {
                this.procElems[1].Freq = System.Convert.ToDouble(PtwoLat.Text.ToString());
            }
        }

        private void PthrLat_TextChanged(object sender, EventArgs e)
        {
            if (PthrLat.Text != "")
            {
                this.procElems[2].Freq = System.Convert.ToDouble(PthrLat.Text.ToString());
            }
        }

        private void PfourLat_TextChanged(object sender, EventArgs e)
        {
            if (PfourLat.Text != "")
            {
                this.procElems[3].Freq = System.Convert.ToDouble(PfourLat.Text.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (RoneDel.Text != "")
            {
                this.registers[0].Delay = System.Convert.ToDouble(RoneDel.Text.ToString());
                this.registers[2].Delay = System.Convert.ToDouble(RoneDel.Text.ToString());
            }
        }

        private void PoneDel_TextChanged(object sender, EventArgs e)
        {
            if (RtwoDel.Text != "")
            {
                this.registers[1].Delay = System.Convert.ToDouble(RtwoDel.Text.ToString());
                this.registers[4].Delay = System.Convert.ToDouble(RtwoDel.Text.ToString());
            }
        }

        private void RfourDel_TextChanged(object sender, EventArgs e)
        {
            if (RfourDel.Text != "")
            {
                this.registers[3].Delay = System.Convert.ToDouble(RfourDel.Text.ToString());
            }
        }

        private void Titr_TextChanged(object sender, EventArgs e)
        {
            if (Titr.Text != "")
            {
                this.titr = System.Convert.ToDouble(Titr.Text.ToString());
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                procElems[i].Latency = System.Convert.ToInt32(textBox1.Text);
            }
        }
    }
}
