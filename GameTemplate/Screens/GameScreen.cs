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

namespace GameTemplate.Screens
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        #region required global values - DO NOT CHANGE

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;

        #endregion

        //TODO - Place game global variables here 
        //---------------------------------------

        //initial starting points for black rectangle
        Random randGen = new Random();

        bool fall = false;
        List<int> enemeyX = new List<int>(new int[] { });
        List<int> enemeyY = new List<int>(new int[] { });
        List<int> enemeySize = new List<int>(new int[] { });

        List<int> powerUpX = new List<int>(new int[] { });
        List<int> powerUpY = new List<int>(new int[] { });
        List<int> powerUpSize = new List<int>(new int[] { });

        int heroX = 100;
        int heroY = 399;
        int heroSize = 50;
        int enemyMovementSpeed = 10;
        int enemyMovementMaxSpeed = 30;
        int hitSpeedChange = 2;
        int enemySpawn = 0;
        int powerUpSpwn = 0;
        Boolean collision = false;
      

        int toastY = 400;
        int toastSize = 30;

        int pylonY = 400;
        int pylonSize = 20;

        int toastHungerBarValue = 25;
        //Umbrealla variables
        int umbreallaY = 400;
        int umbrelllaSize = 25;
        Boolean umbrelliaCollsionProtection = false;

        int winX;
        int winY;
        int winSize;
        SolidBrush winCondtion = new SolidBrush(Color.Yellow);
        //Mischallionuis variables
        int enemyOccurenceCounter = 20;
        int powerUpOccurenceCounter = 0;
        int hungerBarCounter = 0;
        bool hungerBar = false;
        int temp = 60000;
        //Bottom of Level variables
        int lineX = 0;
        int lineY = 450;
        int lineLength = 16000;
        int lineHeight = 450;
        // Celing Of Level variables
        int ceilingX = 0;
        int ceilingY = 250;
        int ceilingHeight = 5;
        int ceilingLength = 160000;


        //Graphics objects
        SolidBrush heroBrush = new SolidBrush(Color.Black);
        Pen ceilingPen = new Pen(Color.Red, 10);
        Pen linePen = new Pen(Color.Red, 10);
        Pen imagePen = new Pen(Color.Black, 10);
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

            enemyOccurenceCounter += gameTimer.Interval;
            powerUpOccurenceCounter += gameTimer.Interval;
            //
            for (int i = 0; i < enemeyX.Count; i++)
            {
                if (enemeyX[i] <0)
                {
                    enemeyX.RemoveAt(i);
                    enemeyY.RemoveAt(i);
                    enemeySize.RemoveAt(i);
                }
            }
            for (int i = 0; i < powerUpX.Count; i++)
            {
                if (powerUpX[i] < 0)
                {
                    powerUpX.RemoveAt(i);
                    powerUpY.RemoveAt(i);
                    powerUpSize.RemoveAt(i);
                }
            }
            temp = temp - gameTimer.Interval;
            #region main character movements
            //NOTE -- if you add any more objects in the backround, then make sure to make the movements for them here.

            for (int i = 0; i < enemeyX.Count; i++)
            {
                enemeyX[i] -= enemyMovementSpeed - 3;

            }
            //for (int i = 0; i < powerUpX.Count; i++)
            //{
            //    powerUpX[i] -= enemyMovementSpeed - 5;
            //}

            if (dDown == true)
            {
                if (enemyMovementSpeed < enemyMovementMaxSpeed )
                {
                    enemyMovementSpeed = enemyMovementSpeed + 2;

                }
            }
            if (wDown == true)
            {// Make jump and fall method
                heroY = heroY - 2;
            }

            if (spaceDown == true && hungerBarCounter == 100)
            {
                enemyMovementSpeed = enemyMovementSpeed * 2;
                hungerBarCounter--;
                hungerBar = true;
            }
            else if (hungerBarCounter == 0 && hungerBar == true)
            {
                enemyMovementSpeed = enemyMovementSpeed / 2;
                hungerBar = false;
            }

            #endregion
            #region monster movements - TO BE COMPLETed


            #endregion
            #region collision detection - TO BE COMPLETED
            //Intersction rectangles
            Rectangle heroRec = new Rectangle(heroX, heroY, heroSize, heroSize);

            for (int i = 0; i < enemeyX.Count; i++)
            {
                Rectangle enemy1rec = new Rectangle(enemeyX[i], enemeyY[i], enemeySize[i], enemeySize[i]);
                //if (i == 1)
                //{
                //    Rectangle enemy2rec = new Rectangle(enemeyX[i], enemeyY[i], enemeySize[i], enemeySize[i]);

                    //if (heroRec.IntersectsWith(enemy2rec) && umbrelliaCollsionProtection == false)
                    //{
                    //    enemyMovementSpeed = enemyMovementSpeed / hitSpeedChange;
                    //}
                    //else if (heroRec.IntersectsWith(enemy2rec) && umbrelliaCollsionProtection == true)
                    //{
                    //    umbrelliaCollsionProtection = false;
                    //}
                //}
                if (heroRec.IntersectsWith(enemy1rec) && umbrelliaCollsionProtection == false && collision == false)
                {
                    enemyMovementSpeed = enemyMovementSpeed / hitSpeedChange;
                    collision = true;
                }
                else if (heroRec.IntersectsWith(enemy1rec) && umbrelliaCollsionProtection == true)
                {
                    umbrelliaCollsionProtection = false;
                }

                if(enemyMovementSpeed >= 10)
                {
                    collision = false;
                }

            }
            //if (enemySpawn >= 6)
            //{
            //    Rectangle enemy1rec = new Rectangle(enemeyX[0], enemeyY[0], enemeySize[0], enemeySize[0]);
            //    if (enemySpawn == 3 || enemySpawn == 4 || enemySpawn == 5)
            //    {
            //        Rectangle enemy2rec = new Rectangle(enemeyX[1], enemeyY[1], enemeySize[1], enemeySize[1]);
            //    }
            //}

            Rectangle groundRec = new Rectangle(lineX, lineY, lineLength, lineHeight);
            Rectangle ceilingRec = new Rectangle(ceilingX, ceilingY, ceilingLength, ceilingHeight);
            for (int i = 0; i < powerUpX.Count; i++)
            {
                Rectangle powerUpRec = new Rectangle(powerUpX[i], powerUpY[i], powerUpSize[i], powerUpSize[i]);

                if (heroRec.IntersectsWith(powerUpRec))
                {
                    if (powerUpSpwn == 1)
                    {
                        if (umbrelliaCollsionProtection == false)
                        {
                            umbrelliaCollsionProtection = true;
                        }
                        else if (powerUpSpwn == 0)
                        {
                            toastHungerBarValue += 25;
                        }
                    }
                }

                //enemies 
                //Poweups

            }
            // boundaries
            if (wDown == true && !fall)
            {// Make jump and fall method
                heroY = heroY - 5;
            }
            else
            {
                fall = true;
            }
            // falling 
            if (fall == true)
            {
                heroY += 5;
            }

            // boundaries
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

            if (enemyOccurenceCounter >= 1200)
            {
                SpawnGen();

            }
            if (powerUpOccurenceCounter >= 2000)
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
            //Player rectangle
            e.Graphics.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
            //Lines
            e.Graphics.DrawLine(linePen, lineX, lineY, lineLength, lineY);

            e.Graphics.DrawLine(ceilingPen, ceilingX, ceilingY, ceilingLength, ceilingY);

            for (int i = 0; i < enemeyX.Count; i++)
            {
                e.Graphics.FillRectangle(heroBrush, enemeyX[i], enemeyY[i], enemeySize[i], enemeySize[i]);
            }

            for (int i = 0; i < powerUpX.Count; i++)
            {
                e.Graphics.FillEllipse(heroBrush, powerUpX[i], powerUpY[i], powerUpSize[i], powerUpSize[i]);
            }



        }
        private void SpawnGen()
        {
            enemyOccurenceCounter = 0;
            enemySpawn = randGen.Next(0, 6);

            switch (enemySpawn)
            {
                case 0:
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(pylonY);
                    enemeySize.Add(pylonSize);
                    //a single pylon will spawn
                    break;
                case 1:
                    //set airplane off screen and move to the left of the screen.
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(heroY);
                    enemeySize.Add(heroSize);
                    break;
                case 2:
                    //set a bird off screen and move to the left of the screen.
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(heroY);
                    enemeySize.Add(heroSize);
                    break;
                case 3:
                    //set a pylon off screen and a bird 200 pixels to the right of the pylon,
                    //Pylon
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(pylonY);
                    enemeySize.Add(heroSize);
                    //Bird
                    enemeyX.Add(heroX + 1200);
                    enemeyY.Add(heroY);
                    enemeySize.Add(heroSize);
                    break;
                case 4:
                    // set a pylon off and an airplane 200 pixels to the right of the pylon
                    //Pylon
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(pylonY);
                    enemeySize.Add(heroSize);
                    //Plane
                    enemeyX.Add(heroX + 1200);
                    enemeyY.Add(heroY);
                    enemeySize.Add(heroSize);
                    break;
                case 5:
                    //set an airplane off screen and bird 200 pixels to the right of the plane
                    //Airplane
                    enemeyX.Add(heroX + 1000);
                    enemeyY.Add(heroY);
                    enemeySize.Add(heroSize);
                    //Bird
                    enemeyX.Add(heroX + 1200);
                    enemeyY.Add(heroY);
                    enemeySize.Add(heroSize);
                    break;
            }

        }

        private void PowerUpGen()
        {
            powerUpOccurenceCounter = 0;
            powerUpSpwn = randGen.Next(0, 2);

            switch (enemySpawn)
            {
                case 0:
                    powerUpX.Add(heroX + 1000);
                    powerUpY.Add(toastY);
                    powerUpSize.Add(toastSize);
                    //set a toast power up off screen 
                    break;
                case 1:
                    //set umbrella off screen and move to the left of the screen.
                    powerUpX.Add(heroX + 1000);
                    powerUpY.Add(umbreallaY);
                    powerUpSize.Add(umbrelllaSize);
                    break;
            }
        }
    }
}