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

        List<int> enemeyX = new List<int>(new int[] { });
        List<int> enemeyY = new List<int>(new int[] { });
        List<int> enemeySize = new List<int>(new int[] { });

        int heroX = 100;
        int heroY = 399;
        int heroSize = 50;
        int enemyMovementSpeed = 10;
        int enemyMovementMaxSpeed = 30;
        int hitSpeedChange = 2;
        int enemySpawn = 0;

        int pylonY = 400;
        int pylonSize = 20;

        int ToastX;
        int ToastY;
        int ToastSize;
        int toastHungerBarValue = 25;

        int umbrellaX;
        int umbrellaY;
        int umbrellaSize;
        Boolean umbrelliaCollsionProtection = false;

        int winX;
        int winY;
        int winSize;
        SolidBrush winCondtion = new SolidBrush(Color.Yellow);

        int enemyOccurenceCounter = 0;
        int powerUpOccurenceCounter = 0;
        int hungerBarCounter = 0;
        bool hungerBar = false;
        int temp = 60000;

        int lineX = 0;
        int lineY = 450;
        int lineLength = 16000;
        int lineHeight = 450;

        int ceilingX = 0;
        int ceilingY = 250;
        int ceilingHeight = 5;
        int ceilingLength = 160000;
        Pen ceilingPen = new Pen(Color.Red, 10);

        Pen linePen = new Pen(Color.Red, 10);
        Pen imagePen = new Pen(Color.Black, 10);

        //Graphics objects
        SolidBrush heroBrush = new SolidBrush(Color.Black);

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
            //
            temp = temp - gameTimer.Interval;

            #region main character movements
            //NOTE -- if you add any more objects in the backround, then make sure to make the movements for them here.
            for (int i = 0; i < enemeyX.Count; i++)
            {
                enemeyX[i] -= enemyMovementSpeed - 5;

            }
            if (dDown == true)
            {
                if (enemyMovementSpeed < enemyMovementMaxSpeed && enemyMovementSpeed >= 10)
                {
                    enemyMovementSpeed = enemyMovementSpeed + 2;

                }
                for (int i = 0; i < enemeyX.Count; i++)
                {
                    enemeyX[i] -= enemyMovementSpeed;

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
            Rectangle pylonRec = new Rectangle(hero, pylonY, pylonSize, pylonSize);
            Rectangle planeRec = new Rectangle(planeX, planeY, planeSize, planeSize);
            Rectangle birdRec = new Rectangle(birdX, birdY, birdSize, birdSize);
            Rectangle groundRec = new Rectangle(lineX, lineY, lineLength, lineHeight);
            Rectangle toastRec = new Rectangle(ToastX, ToastY, ToastSize, ToastSize);
            Rectangle umbrellaRec = new Rectangle(umbrellaX, umbrellaY, umbrellaSize, umbrellaSize);
            Rectangle ceilingRec = new Rectangle(ceilingX, ceilingY, ceilingLength, ceilingHeight);
            //enemies 
            if (heroRec.IntersectsWith(pylonRec) && umbrelliaCollsionProtection == false)
            {
                enemyMovementSpeed = enemyMovementSpeed / hitSpeedChange;
            }
            else if (heroRec.IntersectsWith(pylonRec) && umbrelliaCollsionProtection == true)
            {
                umbrelliaCollsionProtection = false;
            }

            if (heroRec.IntersectsWith(planeRec) && umbrelliaCollsionProtection == false)
            {
                enemyMovementSpeed = enemyMovementSpeed / hitSpeedChange;
            }
            else if (heroRec.IntersectsWith(planeRec) && umbrelliaCollsionProtection == true)
            {
                umbrelliaCollsionProtection = false;
            }

            if (heroRec.IntersectsWith(birdRec) && umbrelliaCollsionProtection == false)
            {
                enemyMovementSpeed = enemyMovementSpeed / hitSpeedChange;
            }
            else if (heroRec.IntersectsWith(birdRec) && umbrelliaCollsionProtection == true)
            {
                umbrelliaCollsionProtection = false;
            }

            //powerups
            if (heroRec.IntersectsWith(toastRec))
            {
                toastHungerBarValue = toastHungerBarValue + 25;
            }
            if (heroRec.IntersectsWith(umbrellaRec) && umbrelliaCollsionProtection == false)
            {
                umbrelliaCollsionProtection = true;
            }
            // boundaries
            if (heroRec.IntersectsWith(groundRec))
            {
                heroY--;
            }
            if (heroRec.IntersectsWith(ceilingRec))
            {
                heroY += 2;
            }
            #endregion

            if (enemyOccurenceCounter >= 1200)
            {
                SpawnGen();

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
    }
    private void PowerUpSpawn()
    {
         = 0;
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

        }
    }
}
    

    