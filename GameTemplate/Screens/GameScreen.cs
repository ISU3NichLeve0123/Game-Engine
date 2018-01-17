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
        
        int heroX = 200;
        int heroY = 390;
        int heroSize = 50;
        int enemyMovementSpeed= 5;
        int enemyMovementMaxSpeed = 20;
        int hitSpeedChange = 2;
        bool jump = false;

       
        int pylonX = 1200;
        int pylonY = 400;
        int pylonSize = 50;

        int birdX;
        int birdY;
        int birdSize;

        int planeX;
        int planeY;
        int planeSize;

        int ToastX;
        int ToastY;
        int ToastSize;
        int toastHungerBarValue;

        int umbrellaX;
        int umbrellaY;
        int umbrellaSize;
        Boolean umbrelliaCollsionProtection;

        int winX;
        int winY;
        int winSize;
        SolidBrush winCondtion = new SolidBrush(Color.Yellow);

        int enemyOccurenceCounter;
        int powerupOccurenceCounter;
        int hungerBarCounter;
        bool hungerBar = false;
        int temp = 60000;

        int lineX = 0;
        int lineY= 450;
        int lineLength = 16000;

        int ceilingX = 0;
        int ceilingY = 250;
        int ceilingLength = 160000;
        int ceilingCollision = 400;
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

            temp = temp - gameTimer.Interval;

            #region main character movements
            Boolean speedHalving = false;
            //NOTE -- if you add any more objects in the backround, then make sure to make the movements for them here.

            if (dDown == true )
            {
                if(enemyMovementSpeed < enemyMovementMaxSpeed && enemyMovementSpeed >0)
                {
                    enemyMovementSpeed = enemyMovementSpeed + 2;
                
                }

                pylonX = pylonX - enemyMovementSpeed;
                planeX = planeX - enemyMovementSpeed;
                birdX = birdX - enemyMovementSpeed;
                lineX = lineX - enemyMovementSpeed;
            }

            if (aDown == true )
            {
                if( enemyMovementSpeed < enemyMovementMaxSpeed && enemyMovementSpeed >0)
                {
                enemyMovementSpeed = enemyMovementSpeed - 2;
                }
                pylonX = pylonX - enemyMovementSpeed;
                planeX = planeX - enemyMovementSpeed;
                birdX = birdX - enemyMovementSpeed;
                lineX = lineX - enemyMovementSpeed;
            }
            if(enemyMovementSpeed <=0)
                {
                 enemyMovementSpeed++;
                 }

            if (wDown == true)
            {// Make jump and fall method
                heroY = heroY - 2;
            }

             if (spaceDown == true && hungerBarCounter == 100)
             {
                enemyMovementSpeed = enemyMovementSpeed *2;
                hungerBarCounter--;
                hungerBar = true;
             }
             else if( hungerBarCounter == 0 && hungerBar == true)
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
            Rectangle pylonRec = new Rectangle(pylonX, pylonY, pylonSize, pylonSize);
            Rectangle planeRec = new Rectangle(planeX, planeY, planeSize, planeSize);
            Rectangle birdRec = new Rectangle(birdX, birdY, birdSize, birdSize);
            Rectangle groundRec = new Rectangle(lineX, lineY, lineLength, lineY);
            Rectangle toastRec = new Rectangle(ToastX, ToastY, ToastSize, ToastSize);
            Rectangle umbrellaRec = new Rectangle(umbrellaX, umbrellaY, umbrellaSize, umbrellaSize);
            Rectangle ceilingRec = new Rectangle(ceilingX, ceilingY, ceilingLength, ceilingY);
            //enemies 
            if (heroRec.IntersectsWith(pylonRec) && umbrelliaCollsionProtection == false)
            {
                enemyMovementSpeed = enemyMovementSpeed / hitSpeedChange;
            }
            else if(heroRec.IntersectsWith(pylonRec) && umbrelliaCollsionProtection == true)
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
                heroY++;
            }
            #endregion
        

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
            
            e.Graphics.FillRectangle(heroBrush,pylonX,pylonY,pylonSize,pylonSize);
            //e.Graphics.FillRectangle(heroBrush, 0, 0, 1000, 1000);

            
        }

     }

}
    

    