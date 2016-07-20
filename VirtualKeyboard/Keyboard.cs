using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualKeyboard
{
    //TODO key combinations, by default ctrl should begin a key combination when clicked 
    class Keyboard
    {
        private bool shiftKeyOn, //determines if the shift key has been pressed and the next character will be uppercase
                     capsLockKeyOn, //variable for storing if capslock is on
                     ctrlKeyOn,
                     windowsKeyOn,
                     altKeyOn;

        //default constructor
        public Keyboard()
        {
            shiftKeyOn = false;
            capsLockKeyOn = false;
            ctrlKeyOn = false;
            windowsKeyOn = false;
            altKeyOn = false;
        }

        //all KeyPressed methods toggle the state of the variables.
        public void shiftKeyPressed()
        {
            shiftKeyOn = !shiftKeyOn;
        }

        public void capsLockKeyPressed()
        {
            capsLockKeyOn = !capsLockKeyOn;
        }

        public void ctrlKeyPressed()
        {
            ctrlKeyOn = !ctrlKeyOn;
        }

        public void windowsKeyPressed()
        {
            windowsKeyOn = !windowsKeyOn;
        }

        public void altKeyPressed()
        {
            altKeyOn = !altKeyOn;
        }

        public void alphabetKeyPressed()
        {
            Console.WriteLine("Test");
        }

        //get methods return the current state of the keys pressed
        public bool getShiftKeyState()
        {
            return shiftKeyOn;
        }

        public bool getCapsLockKeyState()
        {
            return capsLockKeyOn;
        }

        public bool getCtrlKeyState()
        {
            return ctrlKeyOn;
        }

        public bool getWindowsKeyState()
        {
            return windowsKeyOn;
        }

        public bool getAltKeyState()
        {
            return altKeyOn;
        }

    }
}
