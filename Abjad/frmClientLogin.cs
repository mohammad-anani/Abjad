using AbjadBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Abjad
{
    public partial class frmClientLogin : Form
    {
        public frmClientLogin()
        {
            InitializeComponent();
        }

        int trials = 3;

        int seconds = 0, minutes = 0;

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpassword.Focus();
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnlogin.PerformClick();
        }

        public delegate void OnSignin(clsClient client);
            public event OnSignin Signin;

       public void GetTimer()
        {
            string LockStartString = Registry.GetValue("Hkey_Current_User\\SOFTWARE\\Abjad", "Lock Start", null) as string;
            DateTime LockStart = Convert.ToDateTime(LockStartString);
            TimeSpan? ts=DateTime.Now - LockStart;

            if(ts.Value.TotalMinutes>=30)
            {
                timer1.Enabled = false;
                txtusername.Enabled = true;
                txtpassword.Enabled = true;
                btnlogin.Enabled = true;
                lbltimer.Visible = false;
                trials = 3;
                return;
            }

            minutes=29-(int)ts.Value.Minutes;
            seconds=60-(int)ts.Value.Seconds;
            lbltimer.Visible=true;
            lbltimer.Text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
            timer1.Enabled=true;

            txtusername.Enabled = false;

            txtpassword.Enabled = false;
            btnlogin.Enabled = false;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if(txtusername.Text=="" || txtpassword.Text=="")
            {
                MessageBox.Show("Missing Fields","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsClient client=clsClient.FindClientByUsernameAndPassword(txtusername.Text,clsClient.ComputeHash( txtpassword.Text));


            if(client.ID==-1)
            {

                MessageBox.Show("Invalid Username/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               txtusername.Clear();
                txtpassword.Clear();
                txtusername.Focus();
                trials--;

                if(trials==0)
                {
                   
                    MessageBox.Show("3 Failed Attempts.\nLogin Locked For 30 Minutes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Registry.SetValue("Hkey_Current_User\\SOFTWARE\\Abjad", "Lock Start", DateTime.Now.ToString(), RegistryValueKind.String);
                    GetTimer();


                }

                return;
            }
            else if (!client.IsActive)
            {
                MessageBox.Show("Client Deactivated.\nContact Admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtusername.Clear();
                txtpassword.Clear();
                return;
            }

            trials = 3;
            Signin?.Invoke(client);
            this.Close();
        }

        private void llsignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateClient frm=new frmAddUpdateClient();
            frm.Adding += Frm_Adding;
            frm.ShowDialog();
        }

        private void Frm_Adding(clsClient client)
        {
            Signin?.Invoke(client);
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds == 0 && minutes == 0)
            {
                timer1.Enabled = false;
                txtusername.Enabled = true;
                txtpassword.Enabled = true;
                btnlogin.Enabled = true;
                lbltimer.Visible = false;
                trials = 3;
                MessageBox.Show("Time Over!\n3 Attempts Left", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (seconds == 0)
            {
                minutes--;
                seconds = 60;
            }
            seconds--;
            lbltimer.Text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }

        private void frmClientLogin_Load(object sender, EventArgs e)
        {
            GetTimer();
        }

        private void lbltimer_Click(object sender, EventArgs e)
        {

        }
    }
}
