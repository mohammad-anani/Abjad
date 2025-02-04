using AbjadBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Abjad
{
    public partial class frmAddUpdateClient : Form
    {
        public frmAddUpdateClient()
        {
            InitializeComponent();
            pnlAdd.Visible = true;
            pnlUpdate.Visible = false;
        }

        clsClient Client = new clsClient();

        public frmAddUpdateClient(clsClient client,bool ReadOnly)
        {
            InitializeComponent();
            Client = client;
            txtname.Text = client.FullName;
            txtusername.Text = client.Username;
            txtaddress.Text = client.Address;
            pnlUpdate.Visible = true;
            pnlAdd.Visible = false;
            pbimage.ImageLocation = client.ImagePath;
            
            if(Registry.GetValue("HKEY_Current_User\\SOFTWARE\\Abjad","Username",null)!=null)
            {
               chkautologin.Checked= true;
            }
            else
            chkautologin.Checked = false;

            if(ReadOnly)
            {
                txtaddress.ReadOnly = true;
                txtname.ReadOnly = true;
                txtusername.ReadOnly = true;
                pnlUpdate.Visible = false;
                btnsave.Visible = false;
                llimage.Visible = false;
            }

        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtusername.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                txtaddress.Focus();
        }

        public delegate void OnUpdate(clsClient client);
        public delegate void OnAdd(clsClient client);
        public event OnUpdate Updating;
        public event OnAdd Adding;

        bool ValidateTxtBoxes()
        {
            return txtname.TextLength==0?false:txtusername.Text.Length==0?false:
                txtaddress.TextLength==0?false:pbimage.ImageLocation.Length==0?false:true;
        }

        bool ValidateAddTxtBoxes()
        {
            return txtname.TextLength == 0 ? false : txtusername.Text.Length == 0 ? false :
                txtaddress.TextLength == 0 ? false : txtpassword.TextLength == 0 ? false :
                txtconfirm.TextLength == 0 ? false:
                txtcreditcard.TextLength==0?false: pbimage.ImageLocation.Length == 0 ? false : true;
        }

        public static bool ValidateCreditCardNumber(string cardNumber)
        {
            //Simulating
            return cardNumber.Length==16;
        }

        private void statefulButton1_Click(object sender, EventArgs e)
        {
            if(clsClient.UsernameExists(txtusername.Text) && txtusername.Text!=Client.Username)
            {
                MessageBox.Show("Username Already Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pnlUpdate.Visible)
            {
                {
                    if (!ValidateTxtBoxes())
                    {
                        MessageBox.Show("Missing Fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Client.FullName = txtname.Text;
                    Client.Address = txtaddress.Text;
                    Client.Username = txtusername.Text;
                    Client.ImagePath = pbimage.ImageLocation;

                    //AutoLogin

                    if (!Client.UpdateClient())
                    {
                        MessageBox.Show("Error:Data Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Updating?.Invoke(Client);
                }
            }
            else if (pnlAdd.Visible)
            {
                if (!ValidateAddTxtBoxes())
                {
                    MessageBox.Show("Missing Fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(txtpassword.Text != txtconfirm.Text)
                {

                    MessageBox.Show("Passwords Don't Match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(!ValidateCreditCardNumber(txtcreditcard.Text))
                {
                    MessageBox.Show("Invalid Credit Card Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                Client.FullName = txtname.Text;
                Client.Address = txtaddress.Text;
                Client.Username = txtusername.Text;
                Client.ImagePath = pbimage.ImageLocation;
                Client.Password = txtpassword.Text;
                Client.CreditCardNumber=txtcreditcard.Text;

                if(!Client.AddClient())
                {
                    MessageBox.Show("Error:Data Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Adding?.Invoke(Client);

            }

            Registry.SetValue("HKEY_Current_User\\SOFTWARE\\Abjad", "Username", Client.Username, RegistryValueKind.String);

            if (pnlUpdate.Visible)
            { Registry.SetValue("HKEY_Current_User\\SOFTWARE\\Abjad", "Password", Client.Password, RegistryValueKind.String); }
            else if (pnlAdd.Visible)
            { Registry.SetValue("HKEY_Current_User\\SOFTWARE\\Abjad", clsClient.ComputeHash("Password"), Client.Password, RegistryValueKind.String); }


            if (!chkautologin.Checked)
            {
                try
                {
                    using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    {
                        using (RegistryKey key = baseKey.OpenSubKey("SOFTWARE\\Abjad", true))
                        {
                            if (key != null)
                            {

                                key.DeleteValue("Username");
                                key.DeleteValue("Password");

                            }
                            else
                            {

                            }
                        }
                    }
                }
                catch(UnauthorizedAccessException)
                {
                    MessageBox.Show("Delete From Registry Unauthorized");
                }
            }

            MessageBox.Show("Data Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void llimage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Title = "Select An Image";
            openFileDialog1.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbimage.ImageLocation = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("You Should Select An Image","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtconfirm.Focus();
        }

        private void txtconfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                txtcreditcard.Focus();
        }

        private void llpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmChangePassOrCreditCard(Client, false);
            frm.ShowDialog();
        }

        private void llcredit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmChangePassOrCreditCard(Client, true);
            frm.ShowDialog();
        }

        private void txtconfirm_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void chkautologin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
