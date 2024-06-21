using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Pokemon
{
    public partial class SettingScreen : UserControl
    {
        int userInput = 1;
        public static string starter;
        private bool button2wasclicked = false;

        public static List<string> pokeTeam = new List<string>();

        public SettingScreen()
        {
            InitializeComponent();

            //text box 
            if (userInput == 1)
            {
                //Console.Clear();
                //Console.WriteLine();
                //Console.WriteLine();
                /*string firstText */
                //foreach (char c in firstText)
                //{
                //    Console.Write(c);
                //    Task.Delay(900);
                //}
                settingTextBox.Text = "";
            }

            if (userInput == 2)
            {
                settingTextBox.Text = "";
            }
            if (userInput == 3)
            {
                settingTextBox.Text = "Which starter pokemon would you like?";
            }


        }

        private void SettingScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                userInput++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //mudkip
            settingTextBox.Text = "Would you like to choose Mudkip?";

            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.None;

            if(button2wasclicked == true)
            {
                starter = "mudkip";
                pokeTeam.Add("mudkip");

                settingTextBox.Text = "";

                Form1.ChangeScreen(this, new RoomScreen());

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //torchic
            settingTextBox.Text = "Would you like to choose Torchic?";

            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.BorderStyle = BorderStyle.None;

            if (button2wasclicked == true)
            {
                starter = "torchic";
                pokeTeam.Add("torchic");

                settingTextBox.Text = "";

                Form1.ChangeScreen(this, new RoomScreen());

            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //treeko
            settingTextBox.Text = "Would you like to choose Treeko?";

            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;

            if (button2wasclicked == true)
            {
                starter = "treecko";
                pokeTeam.Add("treecko");

                settingTextBox.Text = "";

                Form1.ChangeScreen(this, new RoomScreen());
            }
        }

        private void setting2Button_Click(object sender, EventArgs e)
        {
            button2wasclicked = true;
        }
    }
}
