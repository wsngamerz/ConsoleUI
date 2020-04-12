using System;



namespace ConsoleUI {
    /**
      * Utils
      * =====
      */
    class Utils {
        /**
          * Setup
          * Setup the UI.
          */
        public static void Setup() {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.BackgroundColor = Colors.TextBackgroundColor;
            Console.ForegroundColor = Colors.TextForegroundColor;
        }

        /**
          * CenterText
          * Centers text given the string and the number of characters that the 
          * text needs to be centered in.
          */
        public static string CenterText(string text, int characters) {
            if (text.Length > characters) {
                throw new System.ArgumentException("Paramater is too small for the given text", "characters");
            }

            return text.PadLeft(((characters - text.Length) / 2) + text.Length).PadRight(characters);
        }
    }
}
