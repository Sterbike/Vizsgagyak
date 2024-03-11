using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Konyvek
{
    public partial class Form1 : Form
    {
            List<Books> books = new List<Books>();
        public Form1()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines("books.txt");
            foreach (var i in lines)
            {
                string[] items = i.Split(',');
                Books books_object = new Books(items[0], items[1], items[2], items[3], items[4]);
                books.Add(books_object);
            }
            int db_konyv = 0;
            foreach (var i in books)
            {
                db_konyv += i.db;
            }
            label1.Text = $" Összesen {db_konyv} darab könyv van";

            List<Books> expensives = new List<Books>();
            Books expensive = books[0];
            expensives.Add(expensive);
            foreach (var i in books)
            {
                if (i.ar > expensive.ar)
                {
                    expensives.Clear();
                    expensive = i;
                    expensives.Add(expensive);
                }
                else if (i.ar == expensive.ar)
                {
                    expensives.Add(i);
                }
            }
            foreach (var i in expensives)
            {
                dataGridView1.Rows.Add(i.kategoria, i.cim, i.ar);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var i in books)
            {
                if (i.kategoria == comboBox1.SelectedItem.ToString())
                {
               
                    listBox1.Items.Add($"Cím: {i.cim}, Ár: {i.ar}, Darabszám: {i.db}");
                }
            }
            
        }
    }
}
