using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIsha_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String st="";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.FileName = "";
            OP.Filter = "RTF Files (*.rtf)|*.rtf|TXT File (*.txt)|*.txt ";
            OP.Title = "Открыть документ";
            if (OP.ShowDialog() != DialogResult.Cancel)
            {
                {
                    try
                    {
                        
                        richTextBox1.LoadFile(OP.FileName, RichTextBoxStreamType.RichText);
                        String st=richTextBox1.AccessibilityObject.Value;
                       richTextBox1.Text = st;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), ex.Source);
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Dictionary<string, string> dict = new Dictionary<string, string>();

           // dict.Add("Вход: запрет смены пользователя без перезагрузки", "Вкл");

            String[] s = { "Вкл", "Да", "5","Выкл", "Нет" };
            int kl = 0;
            for (int i = 26; i < 40; i++)
            {
                String swd = richTextBox1.Lines[i];
                richTextBox2.SelectionColor = Color.Black;
                if (swd == "Политики безопасности:" || swd == "Политики входа:  " || swd == "Политики аудита:  ")
                {
                    richTextBox2.AppendText(swd);
                    richTextBox2.AppendText("\n");

                }

                else
                {
                    if (swd != " " && swd != "" && swd.Length > 0)
                    {

                        String sk = s[kl];


                        //richTextBox2.AppendText(dict.ContainsKey(swd).ToString());
                        if (swd.Contains(sk))
                        {
                            richTextBox2.SelectionColor = Color.Green;
                        }
                        else
                        {

                            richTextBox2.SelectionColor = Color.Red;

                        }
                        richTextBox2.AppendText(swd);
                        richTextBox2.AppendText("\n");
                        kl++;
                    }
                }
                
            }

        }
    }
}
