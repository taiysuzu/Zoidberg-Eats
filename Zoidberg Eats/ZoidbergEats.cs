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
using System.Media;

namespace Zoidberg_Eats
{
    public partial class ZoidbergEats : Form
    {
        string gameState = "title";

        bool leftDown = false;
        bool rightDown = false;

        int score = 0;
        int time = 600;

        int zoidbergX = 350;
        int zoidbergY = 400;
        int zoidbergSpeed = 6;

        int zoidbergBoxNum = 0;

        List<int> objectXList = new List<int>();
        List<int> objectYList = new List<int>();
        List<int> objectSpeedList = new List<int>();
        List<string> objectTypeList = new List<string>();
        int objectSize = 60;

        List<int> highScoreList = new List<int>();

        Random randGen = new Random();
        int randVal = 0;

        SolidBrush greenBrush = new SolidBrush(Color.FromArgb(55, 225, 145));
        SolidBrush redBrush = new SolidBrush(Color.FromArgb(192, 0, 0));
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Font screenFont = new Font("Futurama Bold Font", 12);
        Font gameOverFont = new Font("Futurama Title Font", 40);

        SoundPlayer title = new SoundPlayer(Properties.Resources.Futurama_beatbox_opening_2);
        SoundPlayer theme = new SoundPlayer(Properties.Resources.Futurama_theme_song);
        SoundPlayer hey = new SoundPlayer(Properties.Resources.zoidberg_hey);
        SoundPlayer eat = new SoundPlayer(Properties.Resources.zoidberg_eat);
        SoundPlayer scream = new SoundPlayer(Properties.Resources.zoidberg_scream);

        public ZoidbergEats()
        {
            InitializeComponent();
            title.PlayLooping();
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
                highScoreList.Add(score);
            }

            //move Zoidberg - incorporated check for if you have touched a box/entered the alternate universe
            if (leftDown == true && zoidbergX > 10 && zoidbergBoxNum % 2 == 0)
            {
                zoidbergX -= zoidbergSpeed;
                zoidbergBox.BackgroundImage = Properties.Resources.zoidberg_left;
            }
            else if (leftDown == true && zoidbergX > 10)
            {
                zoidbergX -= zoidbergSpeed;
                zoidbergBox.BackgroundImage = Properties.Resources.blue_zoidberg_left;
            }

            if (rightDown == true && zoidbergX < 700 && zoidbergBoxNum % 2 == 0)
            {
                zoidbergX += zoidbergSpeed;
                zoidbergBox.BackgroundImage = Properties.Resources.zoidberg_right;
            }
            else if (rightDown == true && zoidbergX > 10)
            {
                zoidbergX += zoidbergSpeed;
                zoidbergBox.BackgroundImage = Properties.Resources.blue_zoidberg_right;
            }

            //check if a new object will be created
            randVal = randGen.Next(0, 1001);

            if (randVal < 3) //0.3% chance of parallel box
            {
                objectXList.Add(randGen.Next(10, 750));
                objectYList.Add(0);
                objectSpeedList.Add(randGen.Next(10, 15));
                objectTypeList.Add("box");
            }
            else if (randVal >= 3 && randVal < 20) //1.7% chance of nibbler
            {
                objectXList.Add(randGen.Next(10, 750));
                objectYList.Add(0);
                objectSpeedList.Add(randGen.Next(7, 12));
                objectTypeList.Add("nibbler");
            }
            else if (randVal >= 20 && randVal < 60) //4% chance of fish
            {
                objectXList.Add(randGen.Next(10, 750));
                objectYList.Add(0);
                objectSpeedList.Add(randGen.Next(8, 15));
                objectTypeList.Add("fish");
            }
            else if (randVal >= 60 && randVal < 90)//3% chance of pizza
            {
                objectXList.Add(randGen.Next(10, 750));
                objectYList.Add(0);
                objectSpeedList.Add(randGen.Next(8, 15));
                objectTypeList.Add("pizza");
            }

            //move objects down screen
            for (int i = 0; i < objectXList.Count(); i++)
            {
                objectYList[i] += objectSpeedList[i];
            }

            //check if objects can be deleted once off screen
            for (int i = 0; i < objectXList.Count(); i++)
            {
                if (objectYList[i] > 500)
                {
                    objectXList.RemoveAt(i);
                    objectYList.RemoveAt(i);
                    objectSpeedList.RemoveAt(i);
                    objectTypeList.RemoveAt(i);
                    break;
                }
            }

            //check collision of zoidberg and the objects
            Rectangle zoidbergRect = new Rectangle(zoidbergX, zoidbergY, zoidbergBox.Width, zoidbergBox.Height);

            for (int i = 0; i < objectXList.Count(); i++)
            {
                Rectangle objectRect = new Rectangle(objectXList[i], objectYList[i], objectSize, objectSize - 15);

                if (zoidbergRect.IntersectsWith(objectRect))
                {
                    if (objectTypeList[i] == "fish")
                    {
                        score += 5;
                        eat.Play();
                    }
                    else if (objectTypeList[i] == "pizza")
                    {
                        score += 10;
                        eat.Play();
                    }
                    else if (objectTypeList[i] == "nibbler")
                    {
                        scream.Play();
                        gameTimer.Enabled = false;
                        gameState = "over";
                        for (int j = 0; j < highScoreList.Count; j++)
                        {
                            if (highScoreList[j] == score && score > 0)
                            {
                                highScoreList.RemoveAt(j);
                            }
                        }
                        highScoreList.Add(score);
                    }
                    else if (objectTypeList[i] == "box")
                    {
                        zoidbergBoxNum++;
                    }

                    objectXList.RemoveAt(i);
                    objectYList.RemoveAt(i);
                    objectSpeedList.RemoveAt(i);
                    objectTypeList.RemoveAt(i);
                    break;
                }
            }

            //check if zoidberg has travelled to the alternate universe (got the box) and change background
            if (zoidbergBoxNum % 2 == 0)
            {
                this.BackgroundImage = Properties.Resources.planet_express_building;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.blue_planet_express;
            }

            this.Refresh();
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
                        e.Graphics.DrawImage(Properties.Resources.Parallelbox, objectXList[i], objectYList[i], objectSize, objectSize);
                    }
                    else if (objectTypeList[i] == "nibbler")
                    {
                        e.Graphics.DrawImage(Properties.Resources.nibbler_png, objectXList[i], objectYList[i], objectSize, objectSize);
                        scream.Play();
                    }
                    else if (objectTypeList[i] == "fish")
                    {
                        e.Graphics.DrawImage(Properties.Resources.fish, objectXList[i], objectYList[i], objectSize, objectSize);
                    }
                    else if (objectTypeList[i] == "pizza")
                    {
                        e.Graphics.DrawImage(Properties.Resources.panucci_s_pizza_box, objectXList[i], objectYList[i], objectSize, objectSize);
                    }
                }
            }

            //game over screen
            else if (gameState == "over")
            {
                this.BackgroundImage = Properties.Resources.piT46KB;

                titleLabel.Visible = false;
                subtitleLabel.Visible = false;
                titleZoidberg.Visible = false;

                zoidbergBox.Visible = false;

                adLabel.Text = "Brought to you by:";
                adLabel.Visible = true;
                adPictureBox.Visible = true;

                //check to see if you got a high score and diplay the correct game over screen
                if (highScoreList[0] > score || score == 0)
                {
                    e.Graphics.DrawImage(Properties.Resources.game_over_zoidberg, 145, 63, 510, 374);
                    e.Graphics.DrawString("Game Over", gameOverFont, redBrush, 230, 70);
                }
                else if (highScoreList[0] <= score)
                {
                    e.Graphics.DrawImage(Properties.Resources.new_high_score_zoidberg, 145, 63, 510, 374);
                    e.Graphics.DrawString("High Score", gameOverFont, redBrush, 230, 70);
                }

                e.Graphics.DrawString($"Score: {score}", screenFont, greenBrush, 350, 130);

                //sort scores highest to lowest then remove the smallest number if the list gets larger than 5
                for (int i = 0; i <= highScoreList.Count(); i++)
                {

                    highScoreList.Sort();
                    highScoreList.Reverse();

                    if (highScoreList.Count() >= 6)
                    {
                        highScoreList.RemoveAt(5);
                    }
                }

                //draw leaderboard
                e.Graphics.DrawString("This Session's Top 5:", screenFont, greenBrush, 300, 200);
                e.Graphics.DrawString("Zoidberg", screenFont, redBrush, 320, 230);
                if (highScoreList.Count() >= 2)
                {
                    e.Graphics.DrawString("Zoidberg", screenFont, redBrush, 320, 250);
                }
                if (highScoreList.Count() >= 3)
                {
                    e.Graphics.DrawString("Zoidberg", screenFont, redBrush, 320, 270);
                }
                if (highScoreList.Count() >= 4)
                {
                    e.Graphics.DrawString("Zoidberg", screenFont, redBrush, 320, 290);
                }
                if (highScoreList.Count() >= 5)
                {
                    e.Graphics.DrawString("Zoidberg", screenFont, redBrush, 320, 310);
                }
                e.Graphics.DrawString($"{highScoreList[0]}", screenFont, redBrush, 420, 230);
                try
                {
                    e.Graphics.DrawString($"{highScoreList[1]}", screenFont, redBrush, 420, 250);
                    e.Graphics.DrawString($"{highScoreList[2]}", screenFont, redBrush, 420, 270);
                    e.Graphics.DrawString($"{highScoreList[3]}", screenFont, redBrush, 420, 290);
                    e.Graphics.DrawString($"{highScoreList[4]}", screenFont, redBrush, 420, 310);
                }
                catch
                {

                }
            }
        }

        //start game engine
        public void GameInitialize()
        {
            this.BackgroundImage = Properties.Resources.planet_express_building;

            score = 0;
            time = 600;
            zoidbergBoxNum = 0;

            titleLabel.Visible = false;
            subtitleLabel.Visible = false;
            titleZoidberg.Visible = false;
            adLabel.Visible = false;
            adPictureBox.Visible = false;

            gameTimer.Enabled = true;
            gameState = "running";

            zoidbergBox.Visible = true;
            zoidbergX = 350;
            objectXList.Clear();
            objectYList.Clear();
            objectSpeedList.Clear();
            objectTypeList.Clear();

            title.Stop();
        }
    }
}
