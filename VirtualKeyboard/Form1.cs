using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
/**
 * Code Written by Ryan Sample
 **/
namespace VirtualKeyboard
{
    public partial class Form1 : Form
    {
        //private Button prevkey;
        private Color defaultColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
        private Keyboard keyboard;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams param = base.CreateParams;
				param.ExStyle |= 0x08000000;
				return param;
			}
		}
		public Form1()
        {
            InitializeComponent();
            keyboard = new Keyboard();
			this.TopMost = true;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        //colors both of the shift keys. This method saved a ton of space
        private void setShiftKeyBackGroundColorToHighlighted()
        {
            LShift.BackColor = Color.Blue;
            RShift.BackColor = Color.Blue;
        }
        private void resetShiftKeyBackgroundColor()
        {
            LShift.BackColor = defaultColor;
            RShift.BackColor = defaultColor;
        }

        private void alphabetButtonClicked(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            keyboard.alphabetKeyPressed(button.Text.ToLower());
        }

		private void escapeKeyClicked(object sender, MouseEventArgs e)
		{
			Button button = sender as Button;
		}

        private void shiftKeyButtonClicked(object sender, MouseEventArgs e)
        {            
            Button button = sender as Button;
            keyboard.shiftKeyPressed();
            determineShiftKeyStateAndSetBackgroundColor();
        }

		private void spacebarClicked(object sender, MouseEventArgs e)
		{
			keyboard.spacebarPressed();
		}
        
		private void capsLockKeyClicked(object sender, MouseEventArgs e)
		{
			if (keyboard.getCapsLockKeyState())
			{
				capslock.BackColor = defaultColor;
				keyboard.capsLockKeyPressed();
			}else
			{
				capslock.BackColor = Color.Blue;
				keyboard.capsLockKeyPressed();
			}
		}
		private void numericalKeyClicked(object sender, MouseEventArgs e)
		{
			Button button = sender as Button;
			keyboard.numericalOrSymbolKeyPressed(button);
		}

        private void determineShiftKeyStateAndSetBackgroundColor()
        {
            if (!keyboard.getShiftKeyState())//shiftkey is already on
                resetShiftKeyBackgroundColor();
            else
                setShiftKeyBackGroundColorToHighlighted();
        }
    }
}
