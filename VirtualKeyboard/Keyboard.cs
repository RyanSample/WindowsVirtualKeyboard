﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void alphabetKeyPressed(string buttonText)
        {
            if (getShiftKeyState() ^ getCapsLockKeyState()) { 
                Console.WriteLine(buttonText.ToUpper());
				SendKeys.Send(buttonText.ToUpper());
			}
			else         
			{
				Console.WriteLine(buttonText);
				SendKeys.Send(buttonText); 
			}
        }

        public void numericalOrSymbolKeyPressed(Button inputButton)
        {
            //TODO need to split string and then determine which key to press
            //the first string in the split array will only be the output if shift is on. 
			//by default we need to get the character after the return so the characters[1]
            String buttonText = inputButton.Text;
			string[] separators = new string[] { "\r\n" };
			string[] characters = buttonText.Split(separators, StringSplitOptions.None);
			if (getShiftKeyState())
			{
				//windows forms uses an '&' as an escape character so when we hit shift+7 we get '&&' instead of '&'
				if(characters[0] == "&&")
				{
					SendKeys.Send("{&}");
					return;//check this when sending key combos, may become an issue
				}
				SendKeys.Send("{" + characters[0] + "}");
			}
			else
			{
				SendKeys.Send("{" + characters[1] + "}");
			}
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
