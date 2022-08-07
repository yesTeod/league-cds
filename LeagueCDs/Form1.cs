using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueCDs
{
    public partial class Form1 : Form
    {
        int TopF = 300, JgF = 300, MidF = 300, AdcF = 300, SuppF = 300;
        public Form1()
        {
            InitializeComponent();
        }
        private string Minutes(int seconds)
        {
            return (seconds / 60).ToString() + ":" + (seconds % 60).ToString();
        }     

        private int FlashCheck(int laneF, string lane)
        {           
            foreach(CheckBox cb in Controls.OfType<CheckBox>())
            {
                bool CL = false;
                bool BL = false;
                if (cb.Name.Contains("Cosmic"+lane))
                {
                    if (cb.Checked == true)
                    {
                        laneF = 254;
                        CL = true;
                    }
                }
                if (cb.Name.Contains("Boots" + lane))
                {
                    if (cb.Checked == true)
                    {
                        laneF = 267;
                        BL = true;
                    }
                }
                if (CL == true && BL == true)
                {
                    laneF = 230;
                }
            }
                       
            foreach(Control c in Controls)
            {
                if (c.Name.Contains(lane + "Flash"))
                {
                    c.Visible = false;
                    c.Enabled = false;
                }
                if (c.Name.Contains("Flash" + lane))
                    c.Visible = true;
            }
            return laneF;
        }        
        private async void buttonTopFlash_Click(object sender, EventArgs e)
        {
            TopF = FlashCheck(TopF, "Top");
            for(int i = TopF; i > 0; i--)
            {                
                labelFlashTop.Text = Minutes(TopF--);
                await Task.Delay(1000);
            }
            buttonTopFlash.Enabled = true;
            buttonTopFlash.Visible = true;
            labelFlashTop.Visible = false;
        }        
        private async void buttonFlashJungle_Click(object sender, EventArgs e)
        {
            JgF = FlashCheck(JgF, "Jungle");
            for (int i = JgF; i > 0; i--)
            {
                labelFlashJungle.Text = Minutes(JgF--);
                await Task.Delay(1000);
            }
            buttonJungleFlash.Enabled = true;
            buttonJungleFlash.Visible = true;
            labelFlashJungle.Visible = false;
        }        
        private async void buttonFlashMid_Click(object sender, EventArgs e)
        {
            MidF = FlashCheck(MidF, "Mid");
            for (int i = MidF; i > 0; i--)
            {
                labelFlashMid.Text = Minutes(MidF--);
                await Task.Delay(1000);
            }
            buttonMidFlash.Enabled = true;
            buttonMidFlash.Visible = true;
            labelFlashMid.Visible = false;
        }        
        private async void buttonFlashAdc_Click(object sender, EventArgs e)
        {
            AdcF = FlashCheck(AdcF, "Adc");
            for (int i = AdcF; i > 0; i--)
            {
                labelFlashAdc.Text = Minutes(AdcF--);
                await Task.Delay(1000);
            }
            buttonAdcFlash.Enabled = true;
            buttonAdcFlash.Visible = true;
            labelFlashAdc.Visible = false;
        }       
        private async void buttonFlashSupp_Click(object sender, EventArgs e)
        {
            SuppF = FlashCheck(SuppF, "Supp");
            for (int i = SuppF; i > 0; i--)
            {
                labelFlashSupp.Text = Minutes(SuppF--);
                await Task.Delay(1000);
            }
            buttonSuppFlash.Enabled = true;
            buttonSuppFlash.Visible = true;
            labelFlashSupp.Visible = false;
        }        
    }
}
