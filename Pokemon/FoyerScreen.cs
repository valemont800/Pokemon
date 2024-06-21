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
    public partial class FoyerScreen : UserControl
    {


        bool leftADown, rightDDown, upWDown, downSDown, spaceKeyDown;

        Player trainer;


        public FoyerScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            trainer = new Player(750, 300);
            Width = this.Width;
            Height = this.Height;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (upWDown)
            {
                trainer.Move("up");
            }
            if (downSDown)
            {
                trainer.Move("down");
            }
            if (leftADown)
            {
                trainer.Move("left");
            }
            if (rightDDown)
            {
                trainer.Move("right");
            }

            //if(trainer.x < 63 && trainer.X > 232 && trainer.Y == 877 && spaceKeyDown == true)
            //{
            //    Form1.ChangeScreen(this, new OutsideScreen());
            //}
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
