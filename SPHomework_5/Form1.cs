using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPHomework_5
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>(126000);
        string hint;
        public Form1()
        {
            InitializeComponent();
            using (StreamReader reader = new StreamReader("2.txt"))
            {
                while (!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine());
                }
            }
            list.Sort();
        }

        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {

            }
            else
            {
                string[] words = inputTextBox.Text.Split(' ');
                string lastWord = words[words.Length - 1];
                try
                {
                    int wordPos = list.BinarySearch(lastWord, new MyComparer());
                    if (wordPos >= 0)
                    {
                        hint = list[wordPos];
                        string hintPart = hint.Substring(hint.Length - (hint.Length - lastWord.Length));
                        inputTextBox.Text += hintPart;
                        inputTextBox.Select(inputTextBox.Text.Length - hintPart.Length, hintPart.Length);
                    }
                }
                catch (Exception)
                {

                }
                textBox1.Text = hint;
            }
        }
    }
}
public class MyComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        if (x.StartsWith(y))
        {
            return 0;
        }
        return x.CompareTo(y);
    }
}