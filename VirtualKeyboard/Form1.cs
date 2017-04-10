using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;//for debugging
/**
 * Code Written by Ryan Sample
 **/
namespace VirtualKeyboard
{
    public partial class Form1 : Form
    {
        private Button prevkey;
        private Color defaultColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
        private Keyboard keyboard;

        public Form1()
        {
            InitializeComponent();
            keyboard = new Keyboard();
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
			Console.Write("alpha key pressed");
            keyboard.alphabetKeyPressed(button.Text.ToLower());
        }

        private void shiftKeyButtonClicked(object sender, MouseEventArgs e)
        {            
            Button button = sender as Button;
            keyboard.shiftKeyPressed();
            determineShiftKeyStateAndSetBackgroundColor();
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
