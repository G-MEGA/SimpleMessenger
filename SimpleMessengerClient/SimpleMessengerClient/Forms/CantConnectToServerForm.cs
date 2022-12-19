using SimpleMessenger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMessengerClient.Forms
{
    public partial class CantConnectToServerForm : Form
    {
        public CantConnectToServerForm()
        {
            InitializeComponent();
        }

        public void Terminate(object sender, EventArgs e)
        {
            Program.SetTerminatingFlag();
            Close();
        }
        public void ConnectAgain(object sender, EventArgs e)
        {
            Close();
        }
    }
}
