using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://" + textBox2.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Host = textBox1.Text;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";
            request.Headers["True-Client-IP"] = textBox3.Text;
            request.Headers["X-Forwarded-For"] = textBox4.Text;
            request.Headers[textBox5.Text] = textBox6.Text;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream,Encoding.GetEncoding(response.CharacterSet));

                string html = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
                File.WriteAllText("page.html", html);
                System.Diagnostics.Process.Start("page.html");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
