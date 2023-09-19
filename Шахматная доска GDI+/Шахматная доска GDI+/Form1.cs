using System.Data;

namespace Шахматная_доска_GDI_
{
    public partial class Шахматы : Form
    {
        Image bR,bK,bN,bP,bQ,bB,
              wR,wK,wN,wP,wQ,wB;
        public Шахматы()
        {
            InitializeComponent();

            bR = Image.FromFile("bR.png");
            bK = Image.FromFile("bK.png");
            bN = Image.FromFile("bN.png");
            bP = Image.FromFile("bP.png");
            bQ = Image.FromFile("bQ.png");
            bB = Image.FromFile("bB.png");

            wR = Image.FromFile("wR.png");
            wK = Image.FromFile("wK.png");
            wN = Image.FromFile("wN.png");
            wP = Image.FromFile("wP.png");
            wQ = Image.FromFile("wQ.png");
            wB = Image.FromFile("wB.png");
        }

        private void Шахматы_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = Graphics.FromHwnd(this.Handle);
            Brush brush;
            g.DrawRectangle(new Pen(Brushes.Black, 1.5f), 77, 77, 625, 625);
            int cells = 8;
            int pixcels = this.ClientSize.Width / (cells + 2);
            for (int i = 0; i < cells; i++)
            {
                char letter = (char)('A' + i);
                g.DrawString(letter.ToString(), new Font("Arial", 18), Brushes.Black, (i + 1) * pixcels + pixcels / 2 - 10, pixcels / 2);
            }
            for (int i = 0; i < cells; i++)
            {
                g.DrawString((i + 1).ToString(), new Font("Arial", 18), Brushes.Black, pixcels / 2, (i + 1) * pixcels + pixcels / 2 - 10);
            }
            for (int i = 0; i < cells; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    brush = (i + j) % 2 == 0 ? Brushes.White : Brushes.Black;
                    g.FillRectangle(brush, (i + 1) * pixcels, (j + 1) * pixcels, pixcels, pixcels);
                }
            }
            Graphics gi = e.Graphics;
            gi.DrawImage(bR, 77, 77);
            gi.DrawImage(bN, 155, 77);
            gi.DrawImage(bB, 233, 77);
            gi.DrawImage(bQ, 311, 77);
            gi.DrawImage(bK, 389, 77);
            gi.DrawImage(bB, 467, 77);
            gi.DrawImage(bN, 545, 77);
            gi.DrawImage(bR, 623, 77);
            gi.DrawImage(bP, 77, 155);
            gi.DrawImage(bP, 155, 155);
            gi.DrawImage(bP, 233, 155);
            gi.DrawImage(bP, 311, 155);
            gi.DrawImage(bP, 389, 155);
            gi.DrawImage(bP, 467, 155);
            gi.DrawImage(bP, 545, 155);
            gi.DrawImage(bP, 623, 155);

            gi.DrawImage(wR, 77, 623);
            gi.DrawImage(wN, 155, 623);
            gi.DrawImage(wB, 233, 623);
            gi.DrawImage(wQ, 311, 623);
            gi.DrawImage(wK, 389, 623);
            gi.DrawImage(wB, 467, 623);
            gi.DrawImage(wN, 545, 623);
            gi.DrawImage(wR, 623, 623);
            gi.DrawImage(wP, 77,  545);
            gi.DrawImage(wP, 155, 545);
            gi.DrawImage(wP, 233, 545);
            gi.DrawImage(wP, 311, 545);
            gi.DrawImage(wP, 389, 545);
            gi.DrawImage(wP, 467, 545);
            gi.DrawImage(wP, 545, 545);
            gi.DrawImage(wP, 623, 545);
        }
    }
}