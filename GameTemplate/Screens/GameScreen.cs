//Nick and Rhyss, Jan 25, 2018, game with collsions, drawn images and user inputs, goal orientated. 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameTemplate.Dialogs;
using System.IO;
using System.Media;


namespace GameTemplate.Screens
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();

            backSongPlayer = new System.Windows.Media.MediaPlayer();
            backSongPlayer.Open(new Uri(Application.StartupPath + "/Resources/BackSong.mp3"));
        }

        #region required global values - DO NOT CHANGE

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;

        #endregion
        //Sound Players and Random generator      
        System.Windows.Media.MediaPlayer backSongPlayer;
        SoundPlayer powerUp = new SoundPlayer(Properties.Resources.Power_Up_KP_1879176533);
        SoundPlayer jump = new SoundPlayer(Properties.Resources.Jump_SoundBible_com_1007297584);
        SoundPlayer carHorn = new SoundPlayer(Properties.Resources.Car_Horn_Honk_1_SoundBible_com_248048021);
        SoundPlayer hurt = new SoundPlayer(Properties.Resources.punch_or_whack__Vladimir_403040765);
        SoundPlayer classBell = new SoundPlayer(Properties.Resources.Class_Bell_SoundBible_com_1426436341);
        //List for enemys
        List<int> enemeyX = new List<int>(new int[] { });
        List<int> enemeyY = new List<int>(new int[] { });
        List<int> enemeySize = new List<int>(new int[] { });
        //Lists for Power Ups
        List<int> powerUpX = new List<int>(new int[] { });
        List<int> powerUpY = new List<int>(new int[] { });
        List<int> powerUpSize = new List<int>(new int[] { });
        //Hero variables
        int heroX = 200;
        int heroY = 350;
        int heroSize = 75;
        int runAnimation = 0;
        int enemyMovementSpeed = 10;
        int enemyMovementMaxSpeed = 30;
        int hitSpeedChange = 2;
        bool fall = false;
        //Random Gen variables
        int enemySpawn = 0;
        int powerUpSpwn = 0;
        Boolean collision = false;
        ////Toast variables
        //int toastY = 395;
        //int toastSize = 55;
        //int toastHungerBarValue = 250;
        //Enemy variables
        int pylonY = 390;
        int pylonSize = 60;
        int birdSize = 55;
        int paperPlaneSize = 70;
        //Umbrealla variables
        int umbreallaY = 400;
        int umbrelllaSize = 50;
        Boolean umbrelliaCollsionProtection = false;
        //Random Generator Variables
        Random randGen = new Random();
        int enemyOccurenceCounter = 0;
        int powerUpOccurenceCounter = 0;
        //Bottom of Level variables
        int lineX = 0;
        int lineY = 450;
        int lineLength = 8000;
        int lineHeight = 450;
        // Celing Of Level variables
        int ceilingX = 0;
        int ceilingY = 150;
        int ceilingHeight = 5;
        int ceilingLength = 16000;
        //Timer
        int temp = 3750;
        //Hungerbar
        int hungerX = -100;
        //int hungerY = 50;
        //int hungerSizeLength = 100;
        //int hungerSizeWidth = 20;
        //int hungerBarCounter = 500;
        //bool hungerBar = false;
        //Graphics objects
        SolidBrush bottomBrush = new SolidBrush(Color.Purple);
        Pen ceilingPen = new Pen(Color.Red, 1);
        Pen linePen = new Pen(Color.Gray, 1);
        SolidBrush topBrush = new SolidBrush(Color.HotPink);
        Font timerFont = new Font("Arial", 16, FontStyle.Bold);
        //----------------------------------------
        // PreviewKeyDown required for UserControl instead of KeyDown as on a form
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pauseGame();
            }

            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.B:
                    bDown = true;
                    break;
                case Keys.N:
                    nDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }

            //player 2 button presses
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.C:
                    cDown = true;
                    break;
                case Keys.V:
                    vDown = true;
                    break;
                case Keys.X:
                    xDown = true;
                    break;
                case Keys.Z:
                    zDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.B:
                    bDown = false;
                    break;
                case Keys.N:
                    nDown = false;
                    break;
                case Keys.M:
                    mDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }

            //player 2 button releases
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.C:
                    cDown = false;
                    break;
                case Keys.V:
                    vDown = false;
                    break;
                case Keys.X:
                    xDown = false;
                    break;
                case Keys.Z:
                    zDown = false;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// All game update logic must be placed in this event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Timer Function
            countdown();
            //Backround Song
            if (temp > 0)
            {
                backSongPlayer.Play();
            }
            else if (temp <= 0)
            {
                backSongPlayer.Stop();
            }
            //Occurnce counters going up and timer going down
            temp--;
            enemyOccurenceCounter += gameTimer.Interval;
            powerUpOccurenceCounter += gameTimer.Interval;
            //Removeal of enemys that are off screen
            for (int i = 0; i < enemeyX.Count; i++)
            {
                if (enemeyX[i] < -30)
                {
                    enemeyX.RemoveAt(i);
                    enemeyY.RemoveAt(i);
                    enemeySize.RemoveAt(i);
                }
            }
            for (int i = 0; i < powerUpX.Count; i++)
            {
                if (powerUpX[i] < -30)
                {
                    powerUpX.RemoveAt(i);
                    powerUpY.RemoveAt(i);
                    powerUpSize.RemoveAt(i);
                }
            }
            #region main character movements
            //NOTE -- if you add any more objects in the backround, then make sure to make the movements for them here.

            for (int i = 0; i < enemeyX.Count; i++)
            {
                enemeyX[i] -= enemyMovementSpeed - 3;

            }
            for (int i = 0; i < powerUpX.Count; i++)
            {
                powerUpX[i] -= enemyMovementSpeed - 3;
                lineLength -= enemyMovementSpeed - 3;

            }

            if (dDown == true)
            {
                if (enemyMovementSpeed < enemyMovementMaxSpeed)
                {
                    enemyMovementSpeed = enemyMovementSpeed + 2;

                }
            }
            if (wDown == true)
            {// Make jump and fall method
                heroY = heroY - 2;
            }

            //if (spaceDown == true && hungerBarCounter >= 0)
            //{
            //    enemyMovementSpeed = enemyMovementSpeed * 2;
            //    hungerBarCounter-= 50;
            //    hungerBar = true;
            //}
            //else if (hungerBarCounter == 0 && hungerBar == true)
            //{
            //    enemyMovementSpeed = enemyMovementSpeed / 1000;
            //    hungerBar = false;
            //}

            #endregion
            #region monster movements - TO BE COMPLETed

            //label1 = Convert.ToString(lineLength);
            #endregion
            #region collision detection - TO BE COMPLETED
            //Intersction rectangles
            Rectangle heroRec = new Rectangle(heroX, heroY, heroSize, heroSize);
            Rectangle groundRec = new Rectangle(lineX, lineY, lineLength, lineHeight);
            Rectangle ceilingRec = new Rectangle(ceilingX, ceilingY, ceilingLength, ceilingHeight);
            //Enemy Collsion
            for (int i = 0; i < enemeyX.Count; i++)
            {
                Rectangle enemy1rec = new Rectangle(enemeyX[i], enemeyY[i], enemeySize[i], enemeySize[i]);
                if (heroRec.IntersectsWith(enemy1rec) && umbrelliaCollsionProtection == false && collision == false)
                {
                    hurt.Play();
                    enemyMovementSpeed = enemyMovementSpeed / hitSpeedChange;
                    collision = true;
                }
                if (heroRec.IntersectsWith(enemy1rec) && umbrelliaCollsionProtection == true)
                {
                    umbrelliaCollsionProtection = false;
                    enemeyX.RemoveAt(i);
                    enemeyY.RemoveAt(i);
                    enemeySize.RemoveAt(i);
                }
                if (enemyMovementSpeed >= 10)
                {
                    collision = false;
                }

            }
            //PowerUp Collsion
            for (int i = 0; i < powerUpX.Count; i++)
            {
                Rectangle powerUpRec = new Rectangle(powerUpX[i], powerUpY[i], powerUpSize[i], powerUpSize[i]);

                if (heroRec.IntersectsWith(powerUpRec))
                {
                    powerUp.Play();
                    if (powerUpSpwn == 1)
                    {
                        if (umbrelliaCollsionProtection == false)
                        {
                            umbrelliaCollsionProtection = true;
                            powerUpX.RemoveAt(i);
                            powerUpY.RemoveAt(i);
                            powerUpSize.RemoveAt(i);
                        }
                    }
                    if (powerUpSpwn == 0)
                    {
                        //hungerBarCounter += toastHungerBarValue; ;
                        hungerX += 50;
                        powerUpX.RemoveAt(i);
                        powerUpY.RemoveAt(i);
                        powerUpSize.RemoveAt(i);
                    }
                }
            }
            //jumping collsion
            if (wDown == true && !fall)
            {
                heroY = heroY - 5;
            }
            else
            {
                fall = true;
            }
            // falling collsion
            if (fall == true)
            {
                heroY += 5;
            }

            // boundaries collsion
            if (heroRec.IntersectsWith(groundRec))
            {
                fall = false;
                heroY -= 5;
            }
            if (heroRec.IntersectsWith(ceilingRec))
            {
                heroY += 5;
                fall = true;
            }
            #endregion
            //Generates Random Enemy once true
            if (enemyOccurenceCounter >= 1200)
            {
                SpawnGen();
            }
            //Generates Random PowerUp once true
            if (powerUpOccurenceCounter >= 4000)
            {
                PowerUpGen();
            }
            //refresh the screen, which causes the GameScreen_Paint method to run
            Refresh();
        }


        /// <summary>
        /// Open the pause dialog box and gets Cancel or Abort result from it
        /// </summary>
        private void pauseGame()
        {
            gameTimer.Enabled = false;
            rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = false;

            DialogResult result = PauseDialog.Show();

            if (result == DialogResult.Cancel)
            {
                gameTimer.Enabled = true;
            }
            if (result == DialogResult.Abort)
            {
                ScreenControl.changeScreen(this, "MenuScreen");
            }
        }

        /// <summary>
        /// All drawing, (and only drawing), to be done here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Player rectangle animation          
            if (runAnimation == 0)
            {
                e.Graphics.DrawImage(Properties.Resources.Run__11_, heroX, heroY, heroSize, heroSize);
            }
            //if (runAnimation == 1)
            //{
            //    e.Graphics.DrawImage(Properties.Resources.Idle__1_, heroX, heroY, heroSize, heroSize);
            //    runAnimation = 2;
            //}
            //if (runAnimation == 2)
            //{
            //    e.Graphics.DrawImage(Properties.Resources.Run__1_, heroX, heroY, heroSize, heroSize);
            //    runAnimation = 0;
            //}

            //Lines/Boundaries/Timer/HungerLabel
            e.Graphics.DrawLine(linePen, lineX, lineY, lineLength, lineY);
            e.Graphics.DrawImage(Properties.Resources.school_bus, lineLength,350 , 150, 150);
            e.Graphics.FillRectangle(bottomBrush, lineX, lineY, lineLength+ 1000, lineLength + 1000);
            e.Graphics.FillRectangle(topBrush, ceilingX, 0, lineLength + 1000, 150);
            e.Graphics.DrawString("Time: " + temp, timerFont, bottomBrush, 800, 50);
            if(umbrelliaCollsionProtection == true )
            {
                e.Graphics.DrawImage(Properties.Resources.umbrella, 300, 40, 50, 50);
                e.Graphics.DrawString("Umbrella PowerUp", timerFont, bottomBrush, 100, 50);
            }            
            // e.Graphics.DrawString("Hunger Level", timerFont, heroBrush, 0, 25);
            //if (hungerBarCounter >= 100)
            //{
            //    e.Graphics.FillRectangle(heroBrush, hungerX, hungerY, hungerSizeLength, hungerSizeWidth);
            //    if(spaceDown == true && hungerBarCounter >0)
            //    {
            //        hungerX--;
            //    }
            //}
            //Enemys
            for (int i = 0; i < enemeyX.Count; i++)
            {
                if (enemeySize[i] == paperPlaneSize)
                {
                    e.Graphics.DrawImage(Properties.Resources.paper_plane, enemeyX[i], enemeyY[i], enemeySize[i], enemeySize[i]);
                }
                if (enemeySize[i] == pylonSize)
                {
                    e.Graphics.DrawImage(Properties.Resources.cone, enemeyX[i], enemeyY[i], enemeySize[i], enemeySize[i]);
                }
                if (enemeySize[i] == birdSize)
                {
                    e.Graphics.DrawImage(Properties.Resources.Bird, enemeyX[i], enemeyY[i], enemeySize[i], enemeySize[i]);
                }
            }
            //PowerUps
            for (int i = 0; i < powerUpX.Count; i++)
            {
                //if (powerUpSize[i] == toastSize)
                //{
                //    e.Graphics.DrawImage(Properties.Resources.toast, powerUpX[i], powerUpY[i], powerUpSize[i], powerUpSize[i]);
                //}
                if (powerUpSize[i] == umbrelllaSize)
                {
                    e.Graphics.DrawImage(Properties.Resources.umbrella, powerUpX[i], powerUpY[i], powerUpSize[i], powerUpSize[i]);
                }
            }
        }
        //Geneartes what will spawn for enemys
        private void SpawnGen()
        {
            enemyOccurenceCounter = 0;
            enemySpawn = randGen.Next(0, 6);

            switch (enemySpawn)
            {
                case 0:
                    //Pylon and adds values to apporiate list
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(pylonY);
                    enemeySize.Add(pylonSize);
                    break;
                case 1:
                    //Paperplane and adds values to apporiate list
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(heroY);
                    enemeySize.Add(paperPlaneSize);
                    break;
                case 2:
                    //Bird and adds values to apporiate list
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(heroY);
                    enemeySize.Add(birdSize);
                    break;
                case 3:
                    //Pylon and adds values to apporiate list
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(pylonY);
                    enemeySize.Add(pylonSize);
                    //Bird and adds values to apporiate list
                    enemeyX.Add(heroX + 1400);
                    enemeyY.Add(heroY);
                    enemeySize.Add(birdSize);
                    break;
                case 4:
                    //Pylon and adds values to apporiate list
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(pylonY);
                    enemeySize.Add(pylonSize);
                    //Paperplane and adds values to apporiate list
                    enemeyX.Add(heroX + 1400);
                    enemeyY.Add(heroY);
                    enemeySize.Add(paperPlaneSize);
                    break;
                case 5:
                    //Paperplane and adds values to apporiate list
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(heroY);
                    enemeySize.Add(paperPlaneSize);
                    //Bird and adds values to apporiate list
                    enemeyX.Add(heroX + 1600);
                    enemeyY.Add(heroY);
                    enemeySize.Add(birdSize);
                    break;
            }

        } //Countsdown until zero
        private void countdown()
        {
            temp--;
            if (temp <= 0)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = false;
                backSongPlayer.Stop();
                ScreenControl.changeScreen(this, "WinScreen");
            }
            if (heroX > lineLength)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = false;
                backSongPlayer.Stop();
                ScreenControl.changeScreen(this, "LostScreen");
            }
        }
        private void PowerUpGen()
        {
            powerUpOccurenceCounter = 0;
            powerUpSpwn = randGen.Next(1, 2);

            switch (powerUpSpwn)
            {
                //case 0:
                //    //Toast and adds values to apporiate list
                //    powerUpX.Add(heroX + 1100);
                //    powerUpY.Add(toastY);
                //    powerUpSize.Add(toastSize);
                //    break;
                case 1:
                    //Umbrella and adds values to apporiate list
                    powerUpX.Add(heroX + 1100);
                    powerUpY.Add(umbreallaY);
                    powerUpSize.Add(umbrelllaSize);
                    break;
            }

        }
    }
}