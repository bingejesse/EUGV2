using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar.Keyboard;

namespace SC.View2
{
    public class KeyboardInstance
    {
        public static Keyboard CreateNumericKeyboard()
        {
            Keyboard keyboard = new Keyboard();

            LinearKeyboardLayout keyboardlayout = new LinearKeyboardLayout();

            keyboardlayout.AddKey("7");
            keyboardlayout.AddKey("8");
            keyboardlayout.AddKey("9");
            keyboardlayout.AddLine();

            keyboardlayout.AddKey("4");
            keyboardlayout.AddKey("5");
            keyboardlayout.AddKey("6");
            keyboardlayout.AddLine();

            keyboardlayout.AddKey("1");
            keyboardlayout.AddKey("2");
            keyboardlayout.AddKey("3");
            keyboardlayout.AddLine();

            keyboardlayout.AddKey("0");
            keyboardlayout.AddKey("←退格", "{BACKSPACE}", width: 21);

            keyboard.Layouts.Add(keyboardlayout);

            return keyboard;
        }

        public static Keyboard CreateNormalKeyboard()
        {
            Keyboard keyboard = new Keyboard();

            LinearKeyboardLayout keyboardlayout = new LinearKeyboardLayout();

            keyboardlayout.AddKey("1");
            keyboardlayout.AddKey("2");
            keyboardlayout.AddKey("3");
            keyboardlayout.AddKey("4");
            keyboardlayout.AddKey("5");
            keyboardlayout.AddKey("6");
            keyboardlayout.AddKey("7");
            keyboardlayout.AddKey("8");
            keyboardlayout.AddKey("9");
            keyboardlayout.AddKey("0");
            keyboardlayout.AddLine();

            keyboardlayout.AddKey("q");
            keyboardlayout.AddKey("w");
            keyboardlayout.AddKey("e");
            keyboardlayout.AddKey("r");
            keyboardlayout.AddKey("t");
            keyboardlayout.AddKey("y");
            keyboardlayout.AddKey("u");
            keyboardlayout.AddKey("i");
            keyboardlayout.AddKey("o");
            keyboardlayout.AddKey("p");
            keyboardlayout.AddLine();

            keyboardlayout.AddKey("a");
            keyboardlayout.AddKey("s");
            keyboardlayout.AddKey("d");
            keyboardlayout.AddKey("f");
            keyboardlayout.AddKey("g");
            keyboardlayout.AddKey("h");
            keyboardlayout.AddKey("j");
            keyboardlayout.AddKey("k");
            keyboardlayout.AddKey("l");
            keyboardlayout.AddLine();

            keyboardlayout.AddKey("z");
            keyboardlayout.AddKey("x");
            keyboardlayout.AddKey("c");
            keyboardlayout.AddKey("v");
            keyboardlayout.AddKey("b");
            keyboardlayout.AddKey("n");
            keyboardlayout.AddKey("m");
            keyboardlayout.AddKey("←退格", "{BACKSPACE}", width: 32);

            keyboard.Layouts.Add(keyboardlayout);

            return keyboard;
        }
    }
}
