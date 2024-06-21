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

namespace Pokemon
{
    public partial class RoomScreen : UserControl
    {
        //design
        SolidBrush wallBrush = new SolidBrush(Color.Khaki);
        SolidBrush turquoiseBrush = new SolidBrush(Color.Turquoise);
        SolidBrush brownBrush = new SolidBrush(Color.SaddleBrown);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        Rectangle wall = new Rectangle(0, 0, 1100, 300);
        Rectangle stairCarpet = new Rectangle(950, 300, 20, 50);

        bool leftADown, rightDDown, upWDown, downSDown, spaceKeyDown ;

        Player trainer;

        public RoomScreen()
        {
            InitializeComponent();
            InitializeGame();

        }
        private void InitializeGame()
        {
            trainer = new Player(800, 1000);
            Width = this.Width;
            Height = this.Height;

        }
        private void roomTimer_Tick(object sender, EventArgs e)
        {
            //player movement
            if(upWDown)
            {
                trainer.Move("up");
            }
            if(downSDown)
            {
                trainer.Move("down");
            }
            if(leftADown)
            {
                trainer.Move("left");
            }
            if(rightDDown)
            {
                trainer.Move("right");
            }

            //if(Player.IntersectsWith(stairCarpet))
            //{
            //    if (spaceKeyDown == true)
            //    {
            //        Form1.ChangeScreen(this, new FoyerScreen());
            //    }
            //}
        }

        private void RoomScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(wallBrush, wall);
            e.Graphics.FillRectangle(redBrush, stairCarpet);
        }

        private void RoomScreen_KeyUp(object sender, KeyEventArgs e)
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

        private void RoomScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch(e.KeyCode)
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
