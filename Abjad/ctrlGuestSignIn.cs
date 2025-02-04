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
    public partial class ctrlGuestSignIn : UserControl
    {
        public ctrlGuestSignIn()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmClientLogin frm=new frmClientLogin();
            frm.Signin += Frm_Signin;
            frm.ShowDialog();
          
        }

     
        public event Action<clsClient> OnSignIn;
        protected virtual void SignIn(clsClient client)
        {
            OnSignIn?.Invoke(client);
        }
        
        private void Frm_Signin(clsClient client)
        {
            SignIn(client);
        }
    }
}
