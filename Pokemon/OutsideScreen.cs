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
    public partial class OutsideScreen : UserControl
    {

        bool leftADown, rightDDown, upWDown, downSDown, spaceKeyDown;

        Player trainer;

        Random randGen = new Random();
        int randEncounter;
        int randPokemon;
        public static string pokemonMatch;
        public static int pokeBalls, spray, cookie, mooMooMilk;

        public OutsideScreen()
        {
            InitializeComponent();
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            
            randEncounter = randGen.Next(1, 101);

            if (randEncounter < 60)
            {
                //save players coordinantes = after match is over, they appear in the same spot
                randPokemon = randGen.Next(1, 90);

                if(randPokemon < 90 && randPokemon > 60)
                {
                    pokemonMatch = "Ralts";
                    RandEncounterScreen.area = "outside";
                    Form1.ChangeScreen(this, new RandEncounterScreen());
                }
                else if(randPokemon < 60 && randPokemon > 30)
                {
                    pokemonMatch = "Poochyena";
                    RandEncounterScreen.area = "outside";
                    Form1.ChangeScreen(this, new RandEncounterScreen());
                }
                else if(randPokemon < 30 && randPokemon > 0)
                {
                    pokemonMatch = "Caterpie";
                    RandEncounterScreen.area = "outside";
                    Form1.ChangeScreen(this, new RandEncounterScreen());
                }


            }
        }

        private void FoyerScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    leftADown = false;
                    break;
                case Keys.D:
                    rightDDown = false;
                    break;
                case Keys.S:
                    downSDown = false;
                    break;
                case Keys.W:
                    upWDown = false;
                    break;
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
            }
        }

        private void FoyerScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftADown = true;
                    break;
                case Keys.Right:
                    rightDDown = true;
                    break;
                case Keys.Down:
                    downSDown = true;
                    break;
                case Keys.Up:
                    upWDown = true;
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    break;
            }
        }
    }
}
