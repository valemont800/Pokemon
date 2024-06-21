using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.Security.Cryptography;

namespace Pokemon
{
    public partial class RandEncounterScreen : UserControl
    {
        //poke stats
        int health1, defense1, speed1; //trainer pokemon
        int attack1, attack2, attack3, attack4;

        int health2, attackMatch, defense2, speed2; // random pokemon
        int turn = 1;
        public static string area;
        public static string chosenPoke;
        int increase, decrease;
        int drainingKissHealth;

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



        public RandEncounterScreen()
        {
            InitializeComponent();
            InitializeGame();
            //music
        }

        private void InitializeGame()
        {
            //trainer pokemon
            if(chosenPoke == "torchic")
            {
                health1 = 45;
                //attack1 = 30;
                defense1 = 31;
                speed1 = 22;
            }
            else if(chosenPoke == "mudkip")
            {
                health1 = 50;
                //attack1 = 29;
                defense1 = 34;
                speed1 = 29;
            }
            else if(chosenPoke == "treecko")
            {
                health1 = 41;
                //attack1 = 29;
                defense1 = 33;
                speed1 = 25;
            }

            //Outside screen pokemon
            if (OutsideScreen.pokemonMatch == "Ralts")
            {
                health2 = 28;
                //attack2 = 23;
                defense2 = 23;
                speed2 = 13;
            }
            else if (OutsideScreen.pokemonMatch == "Poochyena")
            {
                health2 = 35;
                //attack2 = 27;
                defense2 = 22;
                speed2 = 28;
            }
            else if (OutsideScreen.pokemonMatch == "Butterfree")
            {
                health2 = 32;
                //attack2 = 21;
                defense2 = 25;
                speed2 = 24;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (area == "outside")
            {
                battleLabel.Text = $"A wild {OutsideScreen.pokemonMatch} has appeared!";
                Thread.Sleep(3000);
                battleLabel.Text = "What will you do?";
            }
            else if (area == "forest")
            {
                battleLabel.Text = $"A wild // has appeared!";
                Thread.Sleep(3000);
                battleLabel.Text = "What will you do?";
            }
            disableButtons();
            disableButtons2();
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
            button5.Visible = true;
            button5.Enabled = true;
            button6.Visible = true;
            button6.Enabled = true;
            button7.Visible = true;
            button7.Enabled = true;
            button8.Visible = true;
            button8.Enabled = true;
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
            button5.Visible = false;
            button5.Enabled = false;
            button6.Visible = false;
            button6.Enabled = false;
            button7.Visible = false;
            button7.Enabled = false;
            button8.Visible = false;
            button8.Enabled = false;
        }

        //items
        private void button5_Click(object sender, EventArgs e) //pokeball
        {
            if (health2 < 20)
            {
                if (OutsideScreen.pokemonMatch == "Raltz")
                {
                    SettingScreen.pokeTeam.Add("Raltz");
                }
                else if (OutsideScreen.pokemonMatch == "Poochyena")
                {
                    SettingScreen.pokeTeam.Add("Poochyama");
                }
                else if (OutsideScreen.pokemonMatch == "Butterfree")
                {
                    SettingScreen.pokeTeam.Add("Butterfree");
                }

                Thread.Sleep(5000);

                battleLabel.Text = $"You caught {OutsideScreen.pokemonMatch}!";
                Form1.ChangeScreen(this, new OutsideScreen());
            }
            else
            {
                Thread.Sleep(5000);
                battleLabel.Text = $"You could not catch {OutsideScreen.pokemonMatch}";
                turn = 2;
            }
        }

        private void button6_Click(object sender, EventArgs e) //milk
        {
            if(OutsideScreen.mooMooMilk >= 1)
            {
                health1 = health1 + 20;
                defense1 = defense1 + 10;
                disableButtons2();
                battleLabel.Text = $"{chosenPoke} healed 20 hp and their defense increased";
                Thread.Sleep(2000);
                battleLabel.Text = "";
                turn = 2;
            }
            else
            {
                disableButtons2();
                battleLabel.Text = "You do not have any Moo Moo Milk in you inventory!";
                Thread.Sleep(2000);
                battleLabel.Text = "\n Please choose something else";
                Thread.Sleep(2000);
                battleLabel.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e) //cookie
        {
            if(OutsideScreen.cookie >= 1)
            {
                health1 = health1 + 35;
                attack1 = attack1 + 8;
                disableButtons2();
                battleLabel.Text = $"{chosenPoke} healed 35 hp and their attack slightly increased";
                Thread.Sleep(2000);
                battleLabel.Text = "";
                turn = 2;
            }
            else
            {
                disableButtons2();
                battleLabel.Text = "You do not have any cookies in your inventory!";
                Thread.Sleep(2000);
                battleLabel.Text = "\n Please choose something else";
                Thread.Sleep(2000);
                battleLabel.Text = "";
                enableButtons2();
            }
        }

        private void button8_Click(object sender, EventArgs e) //spray
        {
            if(OutsideScreen.spray >= 1)
            {
                health1 = health1 + 60;
                disableButtons2();
                battleLabel.Text = $"{chosenPoke} healed 60 hp!";
                Thread.Sleep(2000);
                battleLabel.Text = "";
                turn = 2;
            }
            else
            {
                disableButtons2();
                battleLabel.Text = "You do not have any sprays in your inventory!";
                Thread.Sleep(2000);
                battleLabel.Text = "\n Please choose something else";
                Thread.Sleep(2000);
                battleLabel.Text = "";
                enableButtons2();
            }
        }


        //attacks
        private void button1_Click(object sender, EventArgs e) //attack 1
        {
            if(chosenPoke == "mudkip") //water gun
            {
                disableButtons();
                battleLabel.Text = "You delt damage!";
                attack1 = 40 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                turn = 2;
            }
            else if(chosenPoke == "torchic") //scratch
            {
                disableButtons();
                battleLabel.Text = "You delt damage!";
                attack1 = 40 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                turn = 2;
            }
            else if(chosenPoke == "treecko") // pound
            {
                disableButtons();
                battleLabel.Text = "You delt damage!";
                attack1 = 40 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                turn = 2;
            }
            else if(chosenPoke == "Raltz")//disarming voice
            {
                disableButtons(); 
                battleLabel.Text = "You delt damage!";
                attack1 = 42 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                turn = 2;
            }
            else if(chosenPoke == "Poochyena")//tackle
            {
                disableButtons();
                battleLabel.Text = "You delt damage!";
                attack1 = 40 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                turn = 2;
            }
            else if(chosenPoke == "Ceterpie")//Bug Bit
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 45 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }

        }

        private void button2_Click(object sender, EventArgs e) //attack 2
        {
            if (chosenPoke == "mudkip")//rock smash
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 42 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "torchic")//ember
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 45 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "treecko")//leafage
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 30 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "Raltz")//growl
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = $"{OutsideScreen.pokemonMatch}'s defense decreased!";
                defense2 = defense2 - 5;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "Poochyena")//howl
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = $"{chosenPoke}'s attack increased!";
                increase = increase + 4;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "Caterpie")//gust
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 30 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }
        }

        private void button3_Click(object sender, EventArgs e) //attack 3
        {
            if (chosenPoke == "mudkip") //growl
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = $"{chosenPoke}'s attack increased!";
                increase = increase + 5;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "torchic")//growl
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = $"{chosenPoke}'s attack increased!";
                increase = increase + 5;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "treecko")//quick attack
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 30 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "Raltz")//draining kiss
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 45 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                drainingKissHealth = totalDamage / 2;
                health1 = health1 + drainingKissHealth;
                Thread.Sleep(2000);
                battleLabel.Text = "You healed some health!";
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "Poochyena")//bite
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 50 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "Caterpie")//harden
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = $"{chosenPoke}'s defense increased!";
                defense1 = defense1 + 10;
                Thread.Sleep(4000);
                turn = 2;
            }
        }

        private void button4_Click(object sender, EventArgs e) //attack 4
        {
            if (chosenPoke == "mudkip")//rock throw
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 48 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "torchic")//quick attack
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 35 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "treecko")//leer
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = $"{OutsideScreen.pokemonMatch}'s defense decreased!";
                defense2 = defense2 - 10;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "Raltz")//psybeam
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 57 + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "Poochyena")//leer
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = $"{OutsideScreen.pokemonMatch}'s defense decreased!";
                defense2 = defense2 - 10;
                Thread.Sleep(4000);
                turn = 2;
            }
            else if (chosenPoke == "Caterpie")//tackle
            {
                disableButtons();
                Thread.Sleep(2000);
                battleLabel.Text = "You delt damage!";
                attack1 = 30  + increase - decrease;
                totalDamage = attack1 * (100 / (100 + defense2));
                health1 = health1 - totalDamage;
                Thread.Sleep(4000);
                turn = 2;
            }
        }

 
        //right menu screen
        private void fightButton_Click(object sender, EventArgs e)
        {
            enableButtons();

            if(chosenPoke == "torchic")
            {
                button1.Text = "Scratch";
                button2.Text = "Ember";
                button3.Text = "Growl";
                button4.Text = "Quick Attack";
            }
            else if(chosenPoke == "mudkip")
            {
                button1.Text = "Water Gun";
                button2.Text = "Rock Smash";
                button3.Text = "Growl";
                button4.Text = "Rock Throw";
            }
            else if(chosenPoke == "treecko")
            {
                button1.Text = "Pound";
                button2.Text = "Leafage";
                button3.Text = "Quick Attack";
                button4.Text = "Leer";
            }
            else if(chosenPoke == "Raltz")
            {
                button1.Text = "Disarming Voice";
                button2.Text = "Growl";
                button3.Text = "Draining Kiss";
                button4.Text = "Psybeam";
            }
            else if(chosenPoke == "Poochyena")
            {
                button1.Text = "Tackle";
                button2.Text = "Howl";
                button3.Text = "Bite";
                button4.Text = "Leer";
            }
            else if(chosenPoke == "Caterpie")
            {
                button1.Text = "Bug Bite";
                button2.Text = "Gust";
                button3.Text = "Harden";
                button4.Text = "Tackle";
            }
            //else if(chosenPoke == "Shroomish")
            //{
            //    button1.Text = "Tackle";
            //    button2.Text = "Headbutt";
            //    button3.Text = "Mega Drain";
            //    button4.Text = "";
            //}
            //else if(chosenPoke == "Vulpix")
            //{
            //    button1.Text = "Ember";
            //    button2.Text = "Quick Attack";
            //    button3.Text = "Growl";
            //    button4.Text = "";
            //}
            //else if(chosenPoke == "Oddish")
            //{
            //    button1.Text = "Growth";
            //    button2.Text = "Acid";
            //    button3.Text = "Mega Drain";
            //    button4.Text = "Absorb";
            //}
        }

        private void bagButton_Click(object sender, EventArgs e)
        {
            enableButtons2();
        }

        private void pokeButton_Click(object sender, EventArgs e)
        {
            enableButtons();
            battleLabel.Text = "";
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            battleLabel.Text = "You decided to run!";
            Thread.Sleep(5000);

            chance = randGen.Next(1, 101);

            if (chance > 20)
            {
                battleLabel.Text = "You successfully escaped!";
                Form1.ChangeScreen(this, new OutsideScreen());
            }
            else
            {
                battleLabel.Text = "You weren't able to escape!";
                turn = 2;
            }
        }

        private void enemyTurn()
        {
            disableButtons();
            if(turn == 2)
            {
                attackDecider = randGen.Next(1, 11);
                if(attackDecider < 3)
                {
                    totalDamage = 20 * (100 / (100 + defense1));
                    health1 = health1 - totalDamage;
                }
                else if(attackDecider > 3 && attackDecider < 6)
                {
                    totalDamage = 25 * (100 / (100 + defense1));
                    health1 = health1 - totalDamage;
                }
                else
                {
                    totalDamage = 30 * (100 / (100 + defense1));
                    health1 = health1 - totalDamage;
                }

                if (health1 <= 0)
                {
                    battleLabel.Text = "Your pokemon fainted!";
                    Thread.Sleep(5000);
                    battleLabel.Text = "You lose 50g";
                    Form1.ChangeScreen(this, new RoomScreen());
                }
                else if (health1 >= 1)
                {
                    turn = 1;
                }
            }
        }
    }
}
