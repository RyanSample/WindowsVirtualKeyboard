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
        private Color defaultColor = Color.FromKnownColor(KnownColor.Control);
        private Keyboard keyboard;

        public Form1()
        {
            InitializeComponent();
            keyboard = new Keyboard();
        }


        //probably auto generated and not needed.
        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        //resets the previous key's color
        private void resetKeyColor()
        {
            LShift.BackColor = DefaultBackColor;
            RShift.BackColor = DefaultBackColor;
            if (prevkey != null)
            {
                prevkey.BackColor = defaultColor;//reset color
            }
            else
            {
                Debug.WriteLine("Prevkey is null.");
            }
        }
        //colors both of the shift keys. This method saved a ton of space
        private void setShiftKeyBackGroundColorToHighlighted()
        {
            LShift.BackColor = Color.Blue;
            RShift.BackColor = Color.Blue;
        }
        private void resetShiftKeyBackgroundColor()
        {
            LShift.BackColor = DefaultBackColor;
            RShift.BackColor = DefaultBackColor;
        }
        //sets the key color for each character entered. also saved a ton of space
        private void setKeyColor(Button button)
        {
            
            defaultColor = button.BackColor;
            prevkey = button;
            button.BackColor = Color.Blue;
        }

        private void alphabetButtonClicked(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            keyboard.alphabetKeyPressed(button.Text.ToLower());
        }

        private void shiftKeyButtonClicked(object sender, MouseEventArgs e)
        {            
            Button button = sender as Button;
            keyboard.shiftKeyPressed();
            determineShiftKeyStateAndSetBackgroundColor();
        }
        //TODO finish shift method so that when an another key is pressed you get the caps version of it and then turn off shift.
        private void determineShiftKeyStateAndSetBackgroundColor()
        {
            if (!keyboard.getShiftKeyState())//shiftkey is already on
                resetShiftKeyBackgroundColor();
            else
                setShiftKeyBackGroundColorToHighlighted();
        }
    }
}
