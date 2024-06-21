using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //ChangeScreen(this, new SettingScreen());

            ChangeScreen(this, new SettingScreen());
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; 

            if (sender is Form)
            {
                f = (Form)sender;                          
            }
            else
            {
                UserControl current = (UserControl)sender;  
                f = current.FindForm();                    
                f.Controls.Remove(current);                
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);
            next.Focus();


            //Form f = current.FindForm();
            //f.Controls.Remove(current);

            //next.Location = new Point((f.ClientSize.Width - next.Width) / 2, (f.ClientSize.Height - next.Height) / 2);

            //next.Focus();
            //f.Controls.Add(next);
        }
    }
}
