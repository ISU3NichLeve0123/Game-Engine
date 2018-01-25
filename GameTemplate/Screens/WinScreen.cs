using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GameTemplate.Screens
{
    public partial class WinScreen : UserControl
    {
        public WinScreen()
        {
            InitializeComponent();

            ScreenControl.setComponentValues(this);
            defaultOverride();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ScreenControl.changeScreen(this, "MenuScreen");
        }

        /// <summary>
        /// Change any control default values here
        /// </summary>
        public void defaultOverride()
        {

        }

        private void WinScreen_Load(object sender, EventArgs e)
        {

        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            ScreenControl.changeScreen(this, "GameScreen");
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            ScreenControl.changeScreen(this, "MenuScreen");
        }
    }
}
