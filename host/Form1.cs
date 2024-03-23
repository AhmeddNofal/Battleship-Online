using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {

        int pScore = 0;
        int eScore = 0;
        
        Player x = new Player();
        Player enemy = new Player();
        TcpListener server = null;
        TcpClient client;
       bool d = false;
        
        // Set the TcpListener on port 13000.
        Int32 port = 13000;
        IPAddress localAddr = IPAddress.Parse("192.168.43.126");
        //172.24.185.221
        // TcpListener server = new TcpListener(port);
        // server = new TcpListener(localAddr, port);

        // Start listening for client requests.


        // Buffer for reading data
        Byte[] bytes = new Byte[256];
        //String data = null;
        
        public Form1()
        {
            InitializeComponent();
          

        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

        }

        private void fireD4_Click(object sender, EventArgs e)
        {

        }

        private void fireA3_Click(object sender, EventArgs e)
        {

        }

        private void a1_Click(object sender, EventArgs e)
        {


        }



        private void press(object sender, EventArgs e)
        {
            
            if (x.Ships.Count < 4)
            {
                bool flag = false;
                foreach (string c in x.Ships)
                {

                    if (c == (sender as Button).Text)
                    {
                        flag = true;

                    }
                }
                    if (flag == false)
                    {
                        x.Ships.Add((sender as Button).Text);
                        (sender as Button).BackColor = Color.Blue;
                    } else if (flag == true)
                {
                    MessageBox.Show("Choose another ship");
                }
                if (x.Ships.Count == 4)
                {
                    // listBox1.Visible = true;
                    host.Visible = true;
                }
               


            }
            else
                MessageBox.Show("max number of ships");


        }

  /*      private void startGame()
        {
          //  comboBox1.Invoke(new veiwDelegate(veiw));
            
        }

      /*  private delegate void veiwDelegate();

        private void veiw()
        {
            if (d == true)
            {
                comboBox1.Visible = true;
                hit.Visible = true;
            }

        }*/


        private void Form1_Load(object sender, EventArgs e)
        {

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Undertale___100___Megalovania);
            player.Play();

        }

        private void host_Click(object sender, EventArgs e)
        {
            
            server = new TcpListener(localAddr, port);
            server.Start();
           // var thread = new Thread(startGame);
           // thread.IsBackground = true;
            //thread.Start();
            // thread.Start();
            // Enter the listening loop.
            try
            {
                
                    MessageBox.Show("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                     client = server.AcceptTcpClient();
                    MessageBox.Show("Connected!");
                // d = true;
                host.Visible = false;


                 foreach(Button btn in this.Controls.OfType<Button>())
                 {
                     btn.Visible = false;
                 }

                comboBox1.Visible = true;
                     hit.Visible = true;

                 //   data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();
                 /*   foreach (string x in x.Ships)
                {
                    data = x;
                    byte[] ship = System.Text.Encoding.ASCII.GetBytes(data);
              
                    stream.Write(ship, 0, ship.Length);
                    data = null;
                }
                */
                string json = JsonConvert.SerializeObject(x);
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(json);
                stream.Write(bytes, 0, bytes.Length);

                Byte[] Byt = new Byte[256];
                Int32 enemyByt = stream.Read(Byt, 0, Byt.Length);
                String enemyJson = System.Text.Encoding.ASCII.GetString(Byt, 0, enemyByt);
                enemy = JsonConvert.DeserializeObject<Player>(enemyJson);

                

                //   int i;


                // Loop to receive all the data sent by the client.
                /*  while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                  {
                      // Translate data bytes to a ASCII string.
                      data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                      //Console.WriteLine("Received: {0}", data);

                      // Process the data sent by the client.
                      //data = data.ToUpper();
                     // Console.WriteLine("Please enter message for client:");
                      data = Console.ReadLine();
                      byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                      // Send back a response.
                      stream.Write(msg, 0, msg.Length);
                      // Console.WriteLine("Sent: {0}", data);            
                  }

                  // Shutdown and end connection
                  client.Close();*/


            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection closed");
            }

        }

        private void hit_Click(object sender, EventArgs e)
        {
        


            hit.Visible = false;
            PictureBox[] pics = new PictureBox[32];

            pics[0] = pa1;
            pics[1] = pa2;
            pics[2] = pa3;
            pics[3] = pa4;
            pics[4] = pb1;
            pics[5] = pb2;
            pics[6] = pb3;
            pics[7] = pb4;
            pics[8] = pc1;
            pics[9] = pc2;
            pics[10] = pc3;
            pics[11] = pc4;
            pics[12] = pd1;
            pics[13] = pd2;
            pics[14] = pd3;
            pics[15] = pd4;
            pics[16] = pw1;
            pics[17] = pw2;
            pics[18] = pw3;
            pics[19] = pw4;
            pics[20] = px1;
            pics[21] = px2;
            pics[22] = px3;
            pics[23] = px4;
            pics[24] = py1;
            pics[25] = py2;
            pics[26] = py3;
            pics[27] = py4;
            pics[28] = pz1;
            pics[29] = pz2;
            pics[30] = pz3;
            pics[31] = pz4;








            Byte[] data = new Byte[256];
           NetworkStream stream = client.GetStream();
            string hitPos = comboBox1.SelectedItem.ToString();
            byte[] hitbyte = System.Text.Encoding.ASCII.GetBytes(hitPos);
            comboBox1.Items.Remove(comboBox1.SelectedItem);

            stream.Write(hitbyte, 0, hitbyte.Length);
            //check enemy board
     
                for (int i = 0; i < pics.Length; i++)
               {
                if (hitPos == pics[i].Tag.ToString())
                {
                    bool flag = false;
                    foreach (string x in enemy.Ships)
                    {
                        
                        if (pics[i].Tag.ToString() == x)
                        {

                            pics[i].Image = Properties.Resources.fireIcon;
                            pics[i].Visible = true;
                            flag = true;
                            pScore++;
                        } 

                     }
                    if (flag == false)
                    {
                        pics[i].Image = Properties.Resources.missIcon;
                        pics[i].Visible = true;
                    }



                    


                }
            }
            


            Int32 bytes = stream.Read(data, 0, data.Length);
            string dmgPos = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            //check player board

                for (int i = 0; i < pics.Length; i++)
                {
                
                    if (dmgPos == pics[i].Tag.ToString())
                    {
                    bool flag = false;
                    foreach (string x in x.Ships)
                    {
                
                        if (pics[i].Tag.ToString() == x )
                        {

                            pics[i].Image = Properties.Resources.fireIcon;
                            pics[i].Visible = true;
                            flag = true;
                            eScore++;
                        }



                    }
                    if (flag == false)
                    {
                        pics[i].Image = Properties.Resources.missIcon;
                        pics[i].Visible = true;
                    }

                }
            }

                if (pScore == 4)
            {
                MessageBox.Show("YOU WON!!");
                this.Close();
            } else if (eScore == 4)
            {
                MessageBox.Show("YOU LOSE");
                this.Close();
            }


            hit.Visible = true;

         




        }
    }
}
