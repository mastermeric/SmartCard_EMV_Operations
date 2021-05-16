using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SmartCard_islemler_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //  Yeni EVOLIS:Gemplus USB Smart Card Reader 0   CarMAN:OMNIKEY CardMan 2020 0
        static string CardConenctionState = "";
        static string readerName = "OMNIKEY CardMan 2020 0"; 
        byte[] atr = new byte[40];
        public SmartCard mySmartCard = new SmartCard(readerName);


        private void btnConnect_Click(object sender, EventArgs e)
        {            
            //SmartCard mySmartCard = new SmartCard(readerName);
            if (mySmartCard.connect())
            {
                CardConenctionState=" CONNECTED ";                
            }
            else 
                CardConenctionState = " DISCONNECTED ";

            label1.Text = CardConenctionState;
        }
        
        private bool MyWarmReset(ref byte[] Atr)
        {
           // mySmartCard = new SmartCard(readerName);
            return mySmartCard.WarmReset(ref Atr); 
        }

        private void btnATR_Click(object sender, EventArgs e)
        {
            if (!MyWarmReset(ref atr))
            {
                MessageBox.Show("Olmadı");
            }
            else
                label2.Text = BitConverter.ToString(atr);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (mySmartCard.disconnect())
            {
                CardConenctionState = " DISCONNECTED ";
            }
            label1.Text = CardConenctionState;
        }

        private void btnSendAPDU_Click(object sender, EventArgs e)
        {
            //eKart  GetChallengeData   0x00,0x84,0x00,0x00,null,0x0E
            APDUCommand komut1 = new APDUCommand(0x00,0x84,0x00,0x00,null,0x0E);
            APDUResponse myResponse = mySmartCard.transmit(komut1);
            if (myResponse == null)
                MessageBox.Show("HATA !");
            else
            {
                if (myResponse.Data == null)
                {
                    MessageBox.Show("SW: " + myResponse.SW1.ToString("X02") + myResponse.SW2.ToString("X02") + "\n" + "Data =  NULL", "SONUÇ");
                }
                else
                {
                    MessageBox.Show("SW: " + myResponse.SW1.ToString("X02") + myResponse.SW2.ToString("X02") + "\n" + "Data = " + BitConverter.ToString(myResponse.Data).Replace("-",""), "SONUÇ");
                }
            }
        }
    }
}





