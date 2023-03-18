using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matrixSiruriVerticale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Graphics g;
        
        public listadeliste p  = new listadeliste();




        public class lista
        {
            public List<char> list = new List<char>();
            public void add(char c)
            {
                this.list.Add(c);
            }
            public void rotateToLeft()
            {

                char aux;
                aux = list[0];



                for (int i = 0; i < list.Count - 1; i++)
                {
                    list[i] = list[i + 1];

                }
                list[list.Count - 1] = aux;


            }

           

            
            public void rotateToRight()
            {

                
                char aux;

                aux = list[list.Count - 1];

                for (int i = list.Count - 1; i > 0; i--)
                {
                    list[i] = list[i - 1];

                }
                list[0] = aux;


            }

        }

        public class listadeliste
        { 
            public List<lista> matricea = new List<lista>();
            public Random rnd = new Random(255);
            public void loadNLists(int y)
            {

                for (int i = 0; i < y; i++)
                {
                    matricea.Add(new lista());
                }
            }
            public void loadlist(int x)
            {
                
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < 80; j++)
                    {
                        matricea[i].add((char)rnd.Next(0, 255));
                    }
                }

            }
            public void draw(ref Graphics pg)
            {
                for (int j = 0; j < matricea.Count; j++)
                {
                    for (int i = 0; i < 80; i++)
                    {
                        pg.DrawString(matricea[j].list[i].ToString(), new Font("Arial",10), new SolidBrush(Color.White), j * 10, i * 10);
                    }
                }
            }
            public void runlistadeliste(ref Graphics pg) { 
                loadNLists(80);
                loadlist(80);
                draw(ref pg);
            }
            public void animateList(int x) 
            {
                matricea[6].rotateToLeft();
                matricea[1].rotateToLeft();
                matricea[2].rotateToLeft();
                matricea[18].rotateToLeft();
                matricea[21].rotateToLeft();
                matricea[79].rotateToLeft();

            }

        }

       

       

       
        private void Form1_Load(object sender, EventArgs e)
        {
           
            g = this.CreateGraphics();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            p.runlistadeliste(ref this.g);

            for(int i = 0; i < 10; i++)
            {
                p.animateList(i);
               // g.Clear(this.BackColor);
                p.draw(ref g);
            }
           
        }
    }
}
