using System;



namespace ConsoleUI {
    /**
      * Colors
      * ======
      */
    class Colors {
        public static ConsoleColor TextForegroundColor = Console.ForegroundColor;
        public static ConsoleColor TextBackgroundColor = Console.BackgroundColor;
        public static ConsoleColor SelectedTextBackgroundColor = TextForegroundColor;
        public static ConsoleColor SelectedTextForegroundColor = TextBackgroundColor;
        public static ConsoleColor BackgroundColor = ConsoleColor.DarkGray;
    }
}
