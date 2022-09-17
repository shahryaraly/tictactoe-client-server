using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace _26_1_2015_ttt_winform_client
{
    public partial class Form1 : Form
    {
        int i = 0;
        Boolean draw,drawchkr;
        int length;
        byte[] sendbyte = new byte[100];
        byte[] rcvbyte = new byte[100];
        ASCIIEncoding aschi = new ASCIIEncoding();
        TcpClient client;
        NetworkStream stream;
        string report = "", btnname = "", serverturn = "";
        Boolean turn = true;
        string flag = "";
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string ipadrs = textBox1.Text;
            client = new TcpClient(ipadrs, 6070);
            stream = client.GetStream();
            Control.CheckForIllegalCrossThreadCalls = false;

            new Thread(getservervalues).Start();


        }

        public void getservervalues()
        {
            try
            {
                while (true)
                {
                    btnname = string.Empty;
                    serverturn = string.Empty;
                    stream = client.GetStream();
                    length = stream.Read(rcvbyte, 0, rcvbyte.Length);
                    for (int k = 0; k < length; k++)
                    {
                        serverturn += Convert.ToChar(rcvbyte[k]);

                    }

                    flag = serverturn;
                    length = stream.Read(rcvbyte, 0, rcvbyte.Length);
                    for (int j = 0; j < length; j++)
                    {
                        btnname += Convert.ToChar(rcvbyte[j]);
                    }

                    if(i == 0)
                    {
                        drawchkr = true;
                    }

                    if (drawchkr == true)
                    {
                        if (i == 4 && draw == false)
                        {
                            stream.Close();
                            MessageBox.Show("Client : game Draw");

                            this.Close();
                        }
                    }

                    setservervalues();
                }
            }
            catch (Exception e)
            {
                stream.Close();
                MessageBox.Show("Game Over");
                
                this.Close();
            }

        }

        public void setservervalues()
        {
            this.Enabled = true;

            if (btnname.Equals("btn_button1"))
            {
                btn_button1.Text = serverturn;
                btn_button1.Enabled = false;

            }

            if (btnname.Equals("btn_button2"))
            {
                btn_button2.Text = serverturn;
                btn_button2.Enabled = false;
            }

            if (btnname.Equals("btn_button3"))
            {
                btn_button3.Text = serverturn;
                btn_button3.Enabled = false;
            }

            if (btnname.Equals("btn_button4"))
            {
                btn_button4.Text = serverturn;
                btn_button4.Enabled = false;
            }

            if (btnname.Equals("btn_button5"))
            {
                btn_button5.Text = serverturn;
                btn_button5.Enabled = false;
            }

            if (btnname.Equals("btn_button6"))
            {
                btn_button6.Text = serverturn;
                btn_button6.Enabled = false;
            }

            if (btnname.Equals("btn_button7"))
            {
                btn_button7.Text = serverturn;
                btn_button7.Enabled = false;
            }

            if (btnname.Equals("btn_button8"))
            {
                btn_button8.Text = serverturn;
                btn_button8.Enabled = false;
            }

            if (btnname.Equals("btn_button9"))
            {

                btn_button9.Text = serverturn;
                btn_button9.Enabled = false;
            }

            if (btn_button1.Text.Equals("0") && btn_button2.Text.Equals("0") && btn_button3.Text.Equals("0") || btn_button4.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button6.Text.Equals("0") || btn_button7.Text.Equals("0") && btn_button8.Text.Equals("0") && btn_button9.Text.Equals("0"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Client : You Lose");
                
                this.Close();
            }

            if (btn_button1.Text.Equals("0") && btn_button4.Text.Equals("0") && btn_button7.Text.Equals("0") || btn_button3.Text.Equals("0") && btn_button6.Text.Equals("0") && btn_button9.Text.Equals("0") || btn_button2.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button8.Text.Equals("0"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Client : You Lose");
                
                this.Close();
            }
            if (btn_button1.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button9.Text.Equals("0") || btn_button3.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button7.Text.Equals("0"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Client : You Lose");
                
                this.Close();
            }

            if (btn_button1.Text.Equals("X") && btn_button2.Text.Equals("X") && btn_button3.Text.Equals("X") || btn_button4.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button6.Text.Equals("X") || btn_button7.Text.Equals("X") && btn_button8.Text.Equals("X") && btn_button9.Text.Equals("X"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Client : You Lose");
                
                this.Close();
            }

            if (btn_button1.Text.Equals("X") && btn_button4.Text.Equals("X") && btn_button7.Text.Equals("X") || btn_button3.Text.Equals("X") && btn_button6.Text.Equals("X") && btn_button9.Text.Equals("X") || btn_button2.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button8.Text.Equals("X"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Client : You Lose");
                
                this.Close();
            }
            if (btn_button1.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button9.Text.Equals("X") || btn_button3.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button7.Text.Equals("X"))
            {
                draw = true;
                MessageBox.Show("Client : You Lose");
                stream.Close();
                this.Close();
            }


            if (drawchkr == true)
            {
                if (i == 4 && draw == false)
                {
                    
                    MessageBox.Show("Client : game Draw");
                    stream.Close();
                    this.Close();
                }
            }

            if (i == 5 && draw == false)
            {
                
                MessageBox.Show("Client : game Draw");
                stream.Close();
                this.Close();
            }


        }


        private void btn_button1_Click(object sender, EventArgs e)
        {
            btn_button1.Enabled = false;
            i++;
            if (flag.Equals("0"))
            {
                btn_button1.Text = "X";
                report = btn_button1.Text;
            }
            else
            {
                btn_button1.Text = "0";
                report = btn_button1.Text;
            }
            turn = !turn;

            sendbyte = aschi.GetBytes(report);
            stream.Write(sendbyte, 0, sendbyte.Length);

            sendbyte = aschi.GetBytes(btn_button1.Name);
            stream.Write(sendbyte, 0, sendbyte.Length);

            getwinner();

        }

        private void btn_button2_Click(object sender, EventArgs e)
        {
            btn_button2.Enabled = false;
            i++;
            if (flag.Equals("0"))
            {
                btn_button2.Text = "X";
                report = btn_button2.Text;
            }

            else
            {
                btn_button2.Text = "0";
                report = btn_button2.Text;
            }
            turn = !turn;

            sendbyte = aschi.GetBytes(report);
            stream.Write(sendbyte, 0, sendbyte.Length);

            sendbyte = aschi.GetBytes(btn_button2.Name);
            stream.Write(sendbyte, 0, sendbyte.Length);
            getwinner();

        }

        private void btn_button3_Click(object sender, EventArgs e)
        {
            btn_button3.Enabled = false;
            i++;
            if (flag.Equals("0"))
            {
                btn_button3.Text = "X";
                report = btn_button3.Text;
            }

            else
            {
                btn_button3.Text = "0";
                report = btn_button3.Text;
            }
            turn = !turn;

            sendbyte = aschi.GetBytes(report);
            stream.Write(sendbyte, 0, sendbyte.Length);

            sendbyte = aschi.GetBytes(btn_button3.Name);
            stream.Write(sendbyte, 0, sendbyte.Length);
            getwinner();
        }

        private void btn_button4_Click(object sender, EventArgs e)
        {
            btn_button4.Enabled = false;
            i++;
            if (flag.Equals("0"))
            {
                btn_button4.Text = "X";
                report = btn_button4.Text;
            }

            else
            {
                btn_button4.Text = "0";
                report = btn_button4.Text;
            }
            turn = !turn;

            sendbyte = aschi.GetBytes(report);
            stream.Write(sendbyte, 0, sendbyte.Length);

            sendbyte = aschi.GetBytes(btn_button4.Name);
            stream.Write(sendbyte, 0, sendbyte.Length);
            getwinner();
        }

        private void btn_button5_Click(object sender, EventArgs e)
        {
            btn_button5.Enabled = false;
            i++;
            if (flag.Equals("0"))
            {
                btn_button5.Text = "X";
                report = btn_button5.Text;
            }

            else
            {
                btn_button5.Text = "0";
                report = btn_button5.Text;
            }
            turn = !turn;

            sendbyte = aschi.GetBytes(report);
            stream.Write(sendbyte, 0, sendbyte.Length);

            sendbyte = aschi.GetBytes(btn_button5.Name);
            stream.Write(sendbyte, 0, sendbyte.Length);
            getwinner();
        }

        private void btn_button6_Click(object sender, EventArgs e)
        {
            btn_button6.Enabled = false;
            i++;
            if (flag.Equals("0"))
            {
                btn_button6.Text = "X";
                report = btn_button6.Text;
            }

            else
            {
                btn_button6.Text = "0";
                report = btn_button6.Text;
            }
            turn = !turn;

            sendbyte = aschi.GetBytes(report);
            stream.Write(sendbyte, 0, sendbyte.Length);

            sendbyte = aschi.GetBytes(btn_button6.Name);
            stream.Write(sendbyte, 0, sendbyte.Length);
            getwinner();
        }

        private void btn_button7_Click(object sender, EventArgs e)
        {
            btn_button7.Enabled = false;
            i++;
            if (flag.Equals("0"))
            {
                btn_button7.Text = "X";
                report = btn_button7.Text;
            }

            else
            {
                btn_button7.Text = "0";
                report = btn_button7.Text;
            }
            turn = !turn;

            sendbyte = aschi.GetBytes(report);
            stream.Write(sendbyte, 0, sendbyte.Length);

            sendbyte = aschi.GetBytes(btn_button7.Name);
            stream.Write(sendbyte, 0, sendbyte.Length);
            getwinner();
        }

        private void btn_button8_Click(object sender, EventArgs e)
        {
            btn_button8.Enabled = false;
            i++;
            if (flag.Equals("0"))
            {
                btn_button8.Text = "X";
                report = btn_button8.Text;
            }

            else
            {
                btn_button8.Text = "0";
                report = btn_button8.Text;
            }
            turn = !turn;

            sendbyte = aschi.GetBytes(report);
            stream.Write(sendbyte, 0, sendbyte.Length);

            sendbyte = aschi.GetBytes(btn_button8.Name);
            stream.Write(sendbyte, 0, sendbyte.Length);
            getwinner();
        }

        private void btn_button9_Click(object sender, EventArgs e)
        {
            btn_button9.Enabled = false;
            i++;
            if (flag.Equals("0"))
            {
                btn_button9.Text = "X";
                report = btn_button9.Text;
            }

            else
            {
                btn_button9.Text = "0";
                report = btn_button9.Text;
            }
            turn = !turn;

            sendbyte = aschi.GetBytes(report);
            stream.Write(sendbyte, 0, sendbyte.Length);

            sendbyte = aschi.GetBytes(btn_button9.Name);
            stream.Write(sendbyte, 0, sendbyte.Length);
            getwinner();
        }



        public void getwinner()
        {
            this.Enabled = false;
            if (btn_button1.Text.Equals("0") && btn_button2.Text.Equals("0") && btn_button3.Text.Equals("0") || btn_button4.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button6.Text.Equals("0") || btn_button7.Text.Equals("0") && btn_button8.Text.Equals("0") && btn_button9.Text.Equals("0"))
            {
                stream.Close();
                MessageBox.Show("Client : You Win");
                
                this.Close();
                draw = true;
            }

            if (btn_button1.Text.Equals("0") && btn_button4.Text.Equals("0") && btn_button7.Text.Equals("0") || btn_button3.Text.Equals("0") && btn_button6.Text.Equals("0") && btn_button9.Text.Equals("0") || btn_button2.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button8.Text.Equals("0"))
            {
                stream.Close();
                MessageBox.Show("Client : You Win");
                
                this.Close();
                draw = true;
            }
            if (btn_button1.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button9.Text.Equals("0") || btn_button3.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button7.Text.Equals("0"))
            {
                stream.Close();
                MessageBox.Show("Client : You Win");
                
                this.Close();
                draw = true;
            }




            if (btn_button1.Text.Equals("X") && btn_button2.Text.Equals("X") && btn_button3.Text.Equals("X") || btn_button4.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button6.Text.Equals("X") || btn_button7.Text.Equals("X") && btn_button8.Text.Equals("X") && btn_button9.Text.Equals("X"))
            {
                stream.Close();
                MessageBox.Show("Client : You Win");
                
                this.Close();
                draw = true;
            }

            if (btn_button1.Text.Equals("X") && btn_button4.Text.Equals("X") && btn_button7.Text.Equals("X") || btn_button3.Text.Equals("X") && btn_button6.Text.Equals("X") && btn_button9.Text.Equals("X") || btn_button2.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button8.Text.Equals("X"))
            {
                stream.Close();
                MessageBox.Show("Client : You Win");
                
                this.Close();
                draw = true;
            }
            if (btn_button1.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button9.Text.Equals("X") || btn_button3.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button7.Text.Equals("X"))
            {
                stream.Close();
                MessageBox.Show("Client : You Win");
                
                this.Close();
                draw = true;
            }


            //if (drawchkr == true)
            //{
            //    if (i == 4 && draw == false)
            //    {
            //        stream.Close();
            //        MessageBox.Show("Client : game Draw");

            //        this.Close();
            //    }
            //}

            //if (i == 5 && draw == false)
            //{
            //    stream.Close();
            //    MessageBox.Show("Client : game Draw");

            //    this.Close();
            //}

        }

    }
}
