using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace Механические_часы_GDI_
{
    public partial class Form1 : Form
    {

        int radius;
        public Form1()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 800;
            radius = ClientSize.Width / 2 - 10;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(8, 30, this.ClientSize.Width, this.ClientSize.Height);
            Region region = new Region(path);
            //GraphicsPath path2 = new GraphicsPath();
            //path2.AddEllipse(10, 32, this.ClientSize.Width - 10, this.ClientSize.Height - 10);
            //Region region2 = new Region(path2);
            //region.Exclude(region2);
            this.Region = region;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            using (Pen p = new Pen(Brushes.DarkSlateBlue, 6.0f))
            {
                Font font = new Font("Arial", 36);
                g.DrawEllipse(p, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
                g.DrawLine(p, 580, 50, 560, 75);
                g.DrawString("1", font, Brushes.DarkSlateBlue, 530, 70);
                g.DrawLine(p, 720, 170, 695, 195);
                g.DrawString("2", font, Brushes.DarkSlateBlue, 655, 190);
                g.DrawLine(p, 735, 570, 705, 550);
                g.DrawString("4", font, Brushes.DarkSlateBlue, 665, 510);
                g.DrawLine(p, 587, 707, 575, 680);
                g.DrawString("5", font, Brushes.DarkSlateBlue, 540, 635);
                g.DrawLine(p, 190, 705, 210, 680);
                g.DrawString("7", font, Brushes.DarkSlateBlue, 200, 625);
                g.DrawLine(p, 55, 570, 80, 550);
                g.DrawString("8", font, Brushes.DarkSlateBlue, 80, 500);
                g.DrawLine(p, 55, 180, 85, 200);
                g.DrawString("10", font, Brushes.DarkSlateBlue, 70, 190);
                g.DrawLine(p, 200, 50, 215, 75);
                g.DrawString("11", font, Brushes.DarkSlateBlue, 190, 70);
                g.DrawLine(p, 0, this.ClientSize.Height / 2, 30, this.ClientSize.Height / 2);
                g.DrawString("9", font, Brushes.DarkSlateBlue, 30, this.ClientSize.Height / 2 - 30);
                g.DrawLine(p, this.ClientSize.Width - 30, this.ClientSize.Height / 2, this.ClientSize.Width, this.ClientSize.Height / 2);
                g.DrawString("3", font, Brushes.DarkSlateBlue, this.ClientSize.Width - 70, this.ClientSize.Height / 2 - 30);
                g.DrawLine(p, this.ClientSize.Width / 2, 0, this.ClientSize.Width / 2, 30);
                g.DrawString("12", font, Brushes.DarkSlateBlue, this.ClientSize.Width / 2 - 50, 30);
                g.DrawLine(p, this.ClientSize.Width / 2, this.ClientSize.Height, this.ClientSize.Width / 2, this.ClientSize.Height - 30);
                g.DrawString("6", font, Brushes.DarkSlateBlue, this.ClientSize.Width / 2 - 20, this.ClientSize.Height - 80);

            }
            Tick(g);
        }
        private void Tick(Graphics g)
        {
            DateTime dt = DateTime.Now;
            int seconds = dt.Second;
            int minute = dt.Minute;
            int hour = dt.Hour;

            float angle =( 360f / 60 * seconds)-90;
            float angle2 = (360f / 60 * minute)-90 + (angle / 60);
            float angle3 = (360f /12 * hour)-90 + angle2/12;
            using (Pen p = new Pen(Brushes.White, 2))
            {
                int Lengthsecond = radius - 130;
                int secondX = ClientSize.Width / 2 + (int)(Lengthsecond * Math.Cos(angle * Math.PI / 180));
                int secondY = ClientSize.Height / 2 + (int)(Lengthsecond * Math.Sin(angle * Math.PI / 180));
                g.DrawLine(p, ClientSize.Width / 2, ClientSize.Height / 2, secondX, secondY);
            }
            using (Pen p = new Pen(Brushes.LawnGreen, 4))
            {
                int Lengthminute = radius - 170;
                int secondX = ClientSize.Width / 2 + (int)(Lengthminute * Math.Cos(angle2 * Math.PI / 180));
                int secondY = ClientSize.Height / 2 + (int)(Lengthminute * Math.Sin(angle2 * Math.PI / 180));
                g.DrawLine(p, ClientSize.Width / 2, ClientSize.Height / 2, secondX, secondY);
            }
            using (Pen p = new Pen(Brushes.Gray, 8))
            {
                int Lengthminute = radius - 250;
                int secondX = ClientSize.Width / 2 + (int)(Lengthminute * Math.Cos(angle3 * Math.PI / 180));
                int secondY = ClientSize.Height / 2 + (int)(Lengthminute * Math.Sin(angle3 * Math.PI / 180));
                g.DrawLine(p, ClientSize.Width / 2, ClientSize.Height / 2, secondX, secondY);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int areobeforeclock = radius - 130;
            Rectangle rectangle = new Rectangle(ClientSize.Width / 2 - areobeforeclock, ClientSize.Height / 2 - areobeforeclock, 2 * areobeforeclock, 2 * areobeforeclock);
            Invalidate(rectangle);
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"{e.X},{e.Y}");
        }
    }
}