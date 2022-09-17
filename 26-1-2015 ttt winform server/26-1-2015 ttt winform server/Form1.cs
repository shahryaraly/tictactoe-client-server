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

namespace _26_1_2015_ttt_winform_server
{

    public partial class Form1 : Form
    {
        int i = 0;
        Boolean draw, drawchkr;
        int length;
        byte[] recivedturn = new byte[100];
        byte[] sendturn = new byte[100];
        ASCIIEncoding aschi = new ASCIIEncoding();
        string clientturn = "", buttonname = "", report = "";
        TcpListener listner;
        TcpClient client;
        NetworkStream stream;
        Boolean turn = true;
        string flag = "";
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            listner = new TcpListener(IPAddress.Any, 6070);
            listner.Start();
            client = listner.AcceptTcpClient();
            stream = client.GetStream();
            Control.CheckForIllegalCrossThreadCalls = false;
            new Thread(getclientvalues).Start();


        }



        public void getclientvalues()
        {
            try
            {
                while (true)
                {
                    buttonname = string.Empty;
                    clientturn = string.Empty;

                    stream = client.GetStream();

                    length = stream.Read(recivedturn, 0, recivedturn.Length);
                    for (int k = 0; k < length; k++)
                    {
                        clientturn += Convert.ToChar(recivedturn[k]);
                    }

                    flag = clientturn;

                    length = stream.Read(recivedturn, 0, recivedturn.Length);
                    for (int j = 0; j < length; j++)
                    {
                        buttonname += Convert.ToChar(recivedturn[j]);
                    }


                    if (i.Equals("0"))
                    {
                        drawchkr = true;
                    }

                  
                    setclientvalues();
                }
            }

            catch (Exception e)
            {
                stream.Close();
                MessageBox.Show("Game Over");

                this.Close();
            }
        }



        public void setclientvalues()
        {

            this.Enabled = true;


            if (buttonname.Equals("btn_button1"))
            {
                btn_button1.Text = clientturn;
                btn_button1.Enabled = false;
            }

            if (buttonname.Equals("btn_button2"))
            {
                btn_button2.Text = clientturn;
                btn_button2.Enabled = false;
            }

            if (buttonname.Equals("btn_button3"))
            {
                btn_button3.Text = clientturn;
                btn_button3.Enabled = false;
            }

            if (buttonname.Equals("btn_button4"))
            {
                btn_button4.Text = clientturn;
                btn_button4.Enabled = false;
            }

            if (buttonname.Equals("btn_button5"))
            {
                btn_button5.Text = clientturn;
                btn_button5.Enabled = false;
            }

            if (buttonname.Equals("btn_button6"))
            {
                btn_button6.Text = clientturn;
                btn_button6.Enabled = false;
            }

            if (buttonname.Equals("btn_button7"))
            {
                btn_button7.Text = clientturn;
                btn_button7.Enabled = false;
            }

            if (buttonname.Equals("btn_button8"))
            {
                btn_button8.Text = clientturn;
                btn_button8.Enabled = false;
            }

            if (buttonname.Equals("btn_button9"))
            {
                btn_button9.Text = clientturn;
                btn_button9.Enabled = false;
            }


            if (btn_button1.Text.Equals("0") && btn_button2.Text.Equals("0") && btn_button3.Text.Equals("0") || btn_button4.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button6.Text.Equals("0") || btn_button7.Text.Equals("0") && btn_button8.Text.Equals("0") && btn_button9.Text.Equals("0"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Server : You Lose");

                this.Close();
            }

            if (btn_button1.Text.Equals("0") && btn_button4.Text.Equals("0") && btn_button7.Text.Equals("0") || btn_button3.Text.Equals("0") && btn_button6.Text.Equals("0") && btn_button9.Text.Equals("0") || btn_button2.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button8.Text.Equals("0"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Server : You Lose");

                this.Close();
            }
            if (btn_button1.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button9.Text.Equals("0") || btn_button3.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button7.Text.Equals("0"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Server : You Lose");

                this.Close();
            }


            if (btn_button1.Text.Equals("X") && btn_button2.Text.Equals("X") && btn_button3.Text.Equals("X") || btn_button4.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button6.Text.Equals("X") || btn_button7.Text.Equals("X") && btn_button8.Text.Equals("X") && btn_button9.Text.Equals("X"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Server :You Lose");

                this.Close();
            }

            if (btn_button1.Text.Equals("X") && btn_button4.Text.Equals("X") && btn_button7.Text.Equals("X") || btn_button3.Text.Equals("X") && btn_button6.Text.Equals("X") && btn_button9.Text.Equals("X") || btn_button2.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button8.Text.Equals("X"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Server :You Lose");

                this.Close();
            }
            if (btn_button1.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button9.Text.Equals("X") || btn_button3.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button7.Text.Equals("X"))
            {
                draw = true;
                stream.Close();
                MessageBox.Show("Server :You Lose");

                this.Close();
            }

            if (drawchkr == true)
            {
                if (i == 4 && draw == false)
                {
                    
                    MessageBox.Show("Server : game Draw");
                    stream.Close();
                    this.Close();
                }
            }

            if (i == 5 && draw == false)
            {
                
                MessageBox.Show("Server : game Draw");
                stream.Close();
                this.Close();
            }




        }

        private void btn_button1_Click(object sender, EventArgs e)
        {
            i++;



            if (flag.Equals("X"))
            {
                btn_button1.Text = "0";
                report = btn_button1.Text;

            }
            else
            {
                btn_button1.Text = "X";
                report = btn_button1.Text;
            }
            turn = !turn;

            stream = client.GetStream();
            sendturn = aschi.GetBytes(report);
            stream.Write(sendturn, 0, sendturn.Length);
            sendturn = aschi.GetBytes(btn_button1.Name);
            stream.Write(sendturn, 0, sendturn.Length);
            btn_button1.Enabled = false;
            getwinner();

        }

        private void btn_button2_Click(object sender, EventArgs e)
        {
            btn_button2.Enabled = false;
            i++;
            if (flag.Equals("X"))
            {
                btn_button2.Text = "0";
                report = btn_button2.Text;

            }
            else
            {
                btn_button2.Text = "X";
                report = btn_button2.Text;
            }
            turn = !turn;

            stream = client.GetStream();
            sendturn = aschi.GetBytes(report);
            stream.Write(sendturn, 0, sendturn.Length);
            sendturn = aschi.GetBytes(btn_button2.Name);
            stream.Write(sendturn, 0, sendturn.Length);

            getwinner();

        }

        private void btn_button3_Click(object sender, EventArgs e)
        {
            btn_button3.Enabled = false;
            i++;
            if (flag.Equals("X"))
            {
                btn_button3.Text = "0";
                report = btn_button3.Text;

            }
            else
            {
                btn_button3.Text = "X";
                report = btn_button3.Text;
            }
            turn = !turn;

            stream = client.GetStream();
            sendturn = aschi.GetBytes(report);
            stream.Write(sendturn, 0, sendturn.Length);
            sendturn = aschi.GetBytes(btn_button3.Name);
            stream.Write(sendturn, 0, sendturn.Length);

            getwinner();

        }

        private void btn_button4_Click(object sender, EventArgs e)
        {
            btn_button4.Enabled = false;
            i++;
            if (flag.Equals("X"))
            {
                btn_button4.Text = "0";
                report = btn_button4.Text;

            }
            else
            {
                btn_button4.Text = "X";
                report = btn_button4.Text;
            }
            turn = !turn;

            stream = client.GetStream();
            sendturn = aschi.GetBytes(report);
            stream.Write(sendturn, 0, sendturn.Length);
            sendturn = aschi.GetBytes(btn_button4.Name);
            stream.Write(sendturn, 0, sendturn.Length);

            getwinner();
        }

        private void btn_button5_Click(object sender, EventArgs e)
        {
            btn_button5.Enabled = false;
            i++;
            if (flag.Equals("X"))
            {
                btn_button5.Text = "0";
                report = btn_button5.Text;

            }
            else
            {
                btn_button5.Text = "X";
                report = btn_button5.Text;
            }
            turn = !turn;

            stream = client.GetStream();
            sendturn = aschi.GetBytes(report);
            stream.Write(sendturn, 0, sendturn.Length);
            sendturn = aschi.GetBytes(btn_button5.Name);
            stream.Write(sendturn, 0, sendturn.Length);

            getwinner();
        }

        private void btn_button6_Click(object sender, EventArgs e)
        {
            btn_button6.Enabled = false;
            i++;
            if (flag.Equals("X"))
            {
                btn_button6.Text = "0";
                report = btn_button6.Text;

            }
            else
            {
                btn_button6.Text = "X";
                report = btn_button6.Text;
            }
            turn = !turn;

            stream = client.GetStream();
            sendturn = aschi.GetBytes(report);
            stream.Write(sendturn, 0, sendturn.Length);
            sendturn = aschi.GetBytes(btn_button6.Name);
            stream.Write(sendturn, 0, sendturn.Length);

            getwinner();
        }

        private void btn_button7_Click(object sender, EventArgs e)
        {
            btn_button7.Enabled = false;
            i++;
            if (flag.Equals("X"))
            {
                btn_button7.Text = "0";
                report = btn_button7.Text;

            }
            else
            {
                btn_button7.Text = "X";
                report = btn_button7.Text;
            }
            turn = !turn;

            stream = client.GetStream();
            sendturn = aschi.GetBytes(report);
            stream.Write(sendturn, 0, sendturn.Length);
            sendturn = aschi.GetBytes(btn_button7.Name);
            stream.Write(sendturn, 0, sendturn.Length);

            getwinner();
        }

        private void btn_button8_Click(object sender, EventArgs e)
        {
            btn_button8.Enabled = false;
            i++;
            if (flag.Equals("X"))
            {
                btn_button8.Text = "0";
                report = btn_button8.Text;

            }
            else
            {
                btn_button8.Text = "X";
                report = btn_button8.Text;
            }
            turn = !turn;

            stream = client.GetStream();
            sendturn = aschi.GetBytes(report);
            stream.Write(sendturn, 0, sendturn.Length);
            sendturn = aschi.GetBytes(btn_button8.Name);
            stream.Write(sendturn, 0, sendturn.Length);

            getwinner();
        }

        private void btn_button9_Click(object sender, EventArgs e)
        {
            btn_button9.Enabled = false;
            i++;
            if (flag.Equals("X"))
            {
                btn_button9.Text = "0";
                report = btn_button9.Text;

            }
            else
            {
                btn_button9.Text = "X";
                report = btn_button9.Text;
            }
            turn = !turn;

            stream = client.GetStream();
            sendturn = aschi.GetBytes(report);
            stream.Write(sendturn, 0, sendturn.Length);
            sendturn = aschi.GetBytes(btn_button9.Name);
            stream.Write(sendturn, 0, sendturn.Length);

            getwinner();
        }



        public void getwinner()
        {
            this.Enabled = false;
            if (btn_button1.Text.Equals("0") && btn_button2.Text.Equals("0") && btn_button3.Text.Equals("0") || btn_button4.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button6.Text.Equals("0") || btn_button7.Text.Equals("0") && btn_button8.Text.Equals("0") && btn_button9.Text.Equals("0"))
            {
                stream.Close();
                MessageBox.Show("Server : You Win");

                this.Close();
                draw = true;
            }

            if (btn_button1.Text.Equals("0") && btn_button4.Text.Equals("0") && btn_button7.Text.Equals("0") || btn_button3.Text.Equals("0") && btn_button6.Text.Equals("0") && btn_button9.Text.Equals("0") || btn_button2.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button8.Text.Equals("0"))
            {
                stream.Close();
                draw = true;
                MessageBox.Show("Server : You Win");

                this.Close();
            }
            if (btn_button1.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button9.Text.Equals("0") || btn_button3.Text.Equals("0") && btn_button5.Text.Equals("0") && btn_button7.Text.Equals("0"))
            {
                stream.Close();
                draw = true;
                MessageBox.Show("Server : You Win");

                this.Close();
            }




            if (btn_button1.Text.Equals("X") && btn_button2.Text.Equals("X") && btn_button3.Text.Equals("X") || btn_button4.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button6.Text.Equals("X") || btn_button7.Text.Equals("X") && btn_button8.Text.Equals("X") && btn_button9.Text.Equals("X"))
            {
                stream.Close();
                draw = true;
                MessageBox.Show("Server : You Win");

                this.Close();
            }

            if (btn_button1.Text.Equals("X") && btn_button4.Text.Equals("X") && btn_button7.Text.Equals("X") || btn_button3.Text.Equals("X") && btn_button6.Text.Equals("X") && btn_button9.Text.Equals("X") || btn_button2.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button8.Text.Equals("X"))
            {
                stream.Close();
                draw = true;
                MessageBox.Show("Server : You Win");

                this.Close();
            }
            if (btn_button1.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button9.Text.Equals("X") || btn_button3.Text.Equals("X") && btn_button5.Text.Equals("X") && btn_button7.Text.Equals("X"))
            {
                stream.Close();
                draw = true;
                MessageBox.Show("Server : You Win");

                this.Close();
            }

            //if (drawchkr == true)
            //{
            //    if (i == 4 && draw == false)
            //    {
            //        stream.Close();
            //        MessageBox.Show("Server : game Draw");

            //        this.Close();
            //    }
            //}

            //if (i == 5 && draw == false)
            //{
            //    stream.Close();
            //    MessageBox.Show("Server : game Draw");

            //    this.Close();
            //}


        }


    }
}
