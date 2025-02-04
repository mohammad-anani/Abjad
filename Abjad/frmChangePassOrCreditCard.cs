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

namespace Abjad
{
    public partial class frmChangePassOrCreditCard : Form
    {
        clsClient client =new clsClient();
        public frmChangePassOrCreditCard(clsClient client ,bool isChangeCreditCard)
        {
            InitializeComponent();
            if(isChangeCreditCard )
            {
                panel1.Visible = true;
            }
            else
                panel1.Visible=false;

            this.client = client;
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                if (clsClient.SymmetricEncryption(txtoldcreditcard.Text) != client.CreditCardNumber)
                {
                    MessageBox.Show("Old Credit Card Incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtoldcreditcard.Clear();
                    return;
                }

                if (frmAddUpdateClient.ValidateCreditCardNumber(txtcreditcard.Text))
                {
                    MessageBox.Show("Invalid Credit Card Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                client.CreditCardNumber = txtcreditcard.Text;
                if (!client.ChangeCreditCardNumber())
                {
                    MessageBox.Show("Error:Data Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (clsClient.ComputeHash(txtpassword.Text) != client.Password)
                {
                    MessageBox.Show("Old Password Incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpassword.Clear();
                    return;
                }

                if (txtnewpassword.Text != txtconfirm.Text)
                {
                    MessageBox.Show("Passwords Don't Match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                client.Password = txtnewpassword.Text;
                if (!client.ChangePassword())
                {
                    MessageBox.Show("Error:Data Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Data Successfully Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtconfirm.Focus();
        }

        private void txtconfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtnewpassword.Focus();
        }

        private void txtoldcreditcard_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)txtcreditcard.Focus();
        }
    }
}
