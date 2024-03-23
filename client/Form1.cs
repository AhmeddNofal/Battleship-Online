using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship_client
{
     
     public partial class Form1 : Form
    {
        Player x = new Player();
        String server = "192.168.1.23";

        Int32 port = 13000;
        TcpClient client;
        NetworkStream stream;
        String responseData;

        public Form1()
        {
            InitializeComponent();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void press(object sender, EventArgs e)
        {
            if (x.Ships.Count < 4)
            {
                
        
                x.Ships.Add((sender as Button).Text);
                (sender as Button).BackColor = Color.Blue;
                if (x.Ships.Count == 4)
                {
                    // listBox1.Visible = true;
                    connect.Visible = true;
                }
                

            }
            else 
                MessageBox.Show("max number of ships");

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

          

        }

        private void host_Click(object sender, EventArgs e)
        {


            client = new TcpClient(server, port);
            stream = client.GetStream();
        }
    }
}
