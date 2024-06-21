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
    public partial class FinalBattleScreen : UserControl
    {
        int health1, attack1, defense1, speed1; //trainer pokemon
        int profHealth, profAttack, profDefense, profSpeed; //proffesor pokemon
        int turn;

        public static string chosenPoke;

        Random randGen = new Random();
        int chance;
        int attackDecider;
        int totalDamage;

        Rectangle healthbar1 = new Rectangle();
        Rectangle healthbar2 = new Rectangle();

        Rectangle bottomBar1 = new Rectangle();
        Rectangle topBar1 = new Rectangle();
        Rectangle bottomBar2 = new Rectangle();
        Rectangle topBar2 = new Rectangle();


        public FinalBattleScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void enableButtons()
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
        private void enableButtons2()
        {
            button9.Visible = true;
            button9.Enabled = true;
            button10.Visible = true;
            button10.Enabled = true;
            button11.Visible = true;
            button11.Enabled = true;
            button12.Visible = true;
            button12.Enabled = true;
        }
        private void disableButtons()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        private void disableButtons2()
        {
            button9.Visible = false;
            button9.Enabled = false;
            button10.Visible = false;
            button10.Enabled = false;
            button11.Visible = false;
            button11.Enabled = false;
            button12.Visible = false;
            button12.Enabled = false;
        }

        private void InitializeGame()
        {
            //chosenPoke = SettingScreen.pokeTeam.IndexOf(String);
        }

    }
}
