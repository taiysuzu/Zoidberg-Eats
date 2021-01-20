/* Taiyo Suzuki
 * Jan. 22 2021
 * Zoidberg Eats is a 2D interactive game themed around the character Zoidberg from the cartoon Futurama
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoidberg_Eats
{
    public partial class ZoidbergEats : Form
    {
        string gameState = "title";

        bool leftDown = false;
        bool rightDown = false;

        int score = 0;
        int time = 200;

        int zoidbergX = 350;
        int zoidbergY = 400;
        int zoidbergSpeed = 6;

        List<int> objectXList = new List<int>();
        List<int> objectYList = new List<int>();
        List<int> objectSpeedList = new List<int>();
        List<string> objectTypeList = new List<string>();
        int objectSize = 100;

        Random randGen = new Random();
        int randVal = 0;

        SolidBrush greenBrush = new SolidBrush(Color.FromArgb(55, 225, 145));
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Font screenFont = new Font("Futurama Bold Font", 12);

        public ZoidbergEats()
        {
            InitializeComponent();
        }

        //set key inputs
        private void ZoidbergEats_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "title" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "title" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void ZoidbergEats_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }
        }

        //game engine
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //decrease timer and check if it has reached zero
            time--;

            if (time == 0)
            {
                gameTimer.Enabled = false;
                gameState = "over";
            }

                //move Zoidberg
            if (leftDown == true && zoidbergX > 10)
            {
                zoidbergX -= zoidbergSpeed;
                zoidbergBox.BackgroundImage = Properties.Resources.zoidberg_left;
            }

            if (rightDown == true && zoidbergX < 700)
            {
                zoidbergX += zoidbergSpeed;
                zoidbergBox.BackgroundImage = Properties.Resources.zoidberg_right;
            }
            Refresh();

            //will a new object be created?
            randVal = randGen.Next(1, 1001);


        }

        //draw to the screen
        private void ZoidbergEats_Paint(object sender, PaintEventArgs e)
        {
            //title screen  
            if (gameState == "title")
            {
                titleLabel.Text = "Zoidberg Eats";
                subtitleLabel.Text = "Press Space to start or Esc to exit";

                adLabel.Text = "Brought to you by:";
                adLabel.Visible = true;
                adPictureBox.Visible = true;
            }
            //game over screen
            else if (gameState == "over")
            {
                this.BackgroundImage = Properties.Resources.planet_express_building;

                titleLabel.Visible = false;
                subtitleLabel.Visible = false;
                titleZoidberg.Visible = false;

                zoidbergBox.Visible = false;

                adLabel.Text = "Brought to you by:";
                adLabel.Visible = true;
                adPictureBox.Visible = true;
            }
            //redraw screen while game is running
            else if (gameState == "running")
            {
                //score box
                e.Graphics.FillRectangle(blackBrush, 6, 6, 140, 44);
                e.Graphics.FillRectangle(whiteBrush, 8, 8, 136, 40);
                e.Graphics.DrawString($"Time Left: {time}", screenFont, greenBrush, 10, 10);
                e.Graphics.DrawString($"Score: {score}", screenFont, greenBrush, 10, 30);

                //draw zoidberg
                Point zoidberg = new Point(zoidbergX, zoidbergY);
                zoidbergBox.Location = zoidberg;

                //draw objects 
                for (int i = 0; i < objectXList.Count(); i++)
                {
                    if (objectTypeList[i] == "box")
                    {
                        e.Graphics.DrawImage(Properties.Resources.Parallelbox, objectXList[i], objectYList[i]);
                    }
                    else if (objectTypeList[i] == "nibbler")
                    {
                        e.Graphics.DrawImage(Properties.Resources.nibbler_png, objectXList[i], objectYList[i]);
                    }
                    else if (objectTypeList[i] == "fish")
                    {
                        e.Graphics.DrawImage(Properties.Resources.fish, objectXList[i], objectYList[i]);
                    }
                    else if (objectTypeList[i] == "pizza")
                    {
                        e.Graphics.DrawImage(Properties.Resources.panucci_s_pizza_box, objectXList[i], objectYList[i]);
                    }
                }
            }
        }

        //start game engine
        public void GameInitialize()
        {
            this.BackgroundImage = Properties.Resources.planet_express_building;

            titleLabel.Visible = false;
            subtitleLabel.Visible = false;
            titleZoidberg.Visible = false;

            adLabel.Visible = false;
            adPictureBox.Visible = false;

            gameTimer.Enabled = true;
            gameState = "running";

            zoidbergBox.Visible = true;
        }
    }
}
