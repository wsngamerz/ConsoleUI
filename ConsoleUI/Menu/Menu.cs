using System;
using System.Collections.Generic;



namespace ConsoleUI {
    /**
      * Menu
      * ====
      *
      * Parent class which holds all the MenuItems and controls the
      * rendering + user inputs.
      */
    class Menu {
        public string menuTitle = null;
        private List<MenuItem> menuItems = new List<MenuItem>();

        private int selectedItem = 0;
        private bool isRunning = false;
        private bool updateNeeded = true;
        private int menuWidth = 0;
        private int menuPadding = 3;
        private int menuTextPadding = 3;

        // Display options
        private MenuOption horizontalAlignment = MenuOption.ALIGN_LEFT;
        private MenuOption verticalAlignment = MenuOption.ALIGN_TOP;
        private MenuOption textAlignment = MenuOption.TEXT_ALIGN_LEFT;


        /**
          * Constructor(menuTitle, **MenuOptions)
          */
        public Menu(string menuTitle, params MenuOption[] options) {
            this.menuTitle = menuTitle;
            menuWidth = menuTitle.Length;

            foreach(MenuOption option in options) {            
                switch(option) {
                    case MenuOption.ALIGN_LEFT:
                    case MenuOption.ALIGN_CENTER:
                    case MenuOption.ALIGN_RIGHT:
                        horizontalAlignment = option;
                        break;

                    case MenuOption.ALIGN_TOP:
                    case MenuOption.ALIGN_MIDDLE:
                    case MenuOption.ALIGN_BOTTOM:
                        verticalAlignment = option;
                        break;
                    
                    case MenuOption.TEXT_ALIGN_LEFT:
                    case MenuOption.TEXT_ALIGN_CENTER:
                    case MenuOption.TEXT_ALIGN_RIGHT:
                        textAlignment = option;
                        break;
                }
            }
        }


        /**
          * AddItem(MenuItem)
          * Adds an item to the menu to be displayed.
          */
        public void AddItem(MenuItem item) {
            menuItems.Add(item);

            // check if widest item, if it is then change the width
            // of entire menu to ensure in line
            int menuItemWidth = item.Text.Length;
            if (menuItemWidth > menuWidth) {
                menuWidth = menuItemWidth;
            }
        }


        /**
          * Show()
          * Triggers the menu to be drawn and starts a loop for user
          * inputs.
          *
          * Only use a skeleton loop so that it can be easily implemented into
          * an example where multiple menus can be rendered simultaneously without
          * issue.
          */
        public void Show() {
            isRunning = true;

            while (isRunning) {
                // draw the UI
                if (updateNeeded) {
                    Draw();
                    updateNeeded = false;
                }

                // accept a user input
                ConsoleKeyInfo userInput = Console.ReadKey();
                ConsoleKey key = userInput.Key;

                // perform actions based upon user input
                switch(key) {
                    case ConsoleKey.DownArrow:
                        MoveDown();
                        break;
                    
                    case ConsoleKey.UpArrow:
                        MoveUp();
                        break;
                    
                    case ConsoleKey.Enter:
                        SelectItem();
                        break;
                }
            }
        }


        /**
          * MoveDown()
          * Moves the currently highlighted item down
          */
        public void MoveDown() {
            if (CanMove(1)) {
                selectedItem++;
                updateNeeded = true;
            }
        }


        /**
          * MoveUp()
          * Moves the currently highlighted item up
          */
        public void MoveUp() {
            if (CanMove(-1)) {
                selectedItem--;
                updateNeeded = true;
            }
        }


        /**
          * SelectItem()
          * Run the callback function of the currently highlighted item
          */
        public void SelectItem() {
            // stop menu loop
            isRunning = false;
            updateNeeded = true;
            Console.Clear();

            // run the callback function
            menuItems[selectedItem].Select();
        }


        /**
          * CanMove(int)
          * Method for checking whether the movement of the selected
          * item is within bounds.
          */
        private bool CanMove(int change) {
            int newSelected = selectedItem + change;
            return newSelected >= 0 && newSelected <= menuItems.Count - 1;
        }


        /**
          * Draw()
          * Method for drawing the current 'frame' of the menu.
          */
        private void Draw() {
            int startX = 0;
            int startY = 0;

            Console.SetCursorPosition(0, 0);
            Console.Clear();

            // calculate start positions for vertical alignment
            switch(verticalAlignment) {
                case MenuOption.ALIGN_TOP:
                    startY = 0;
                    break;
                
                case MenuOption.ALIGN_MIDDLE:
                    startY = (Console.WindowHeight / 2) - (menuItems.Count / 2);
                    break;
                
                case MenuOption.ALIGN_BOTTOM:
                    startY = Console.WindowHeight - menuItems.Count - 1;
                    break;
            }

            // calculate start positions for horizontal alignment
            switch(horizontalAlignment) {
                case MenuOption.ALIGN_LEFT:
                    startX = 0;
                    break;

                case MenuOption.ALIGN_CENTER:
                    startX = (Console.WindowWidth / 2) - ((menuWidth + menuTextPadding + menuPadding) / 2);
                    break;

                case MenuOption.ALIGN_RIGHT:
                    startX = Console.WindowWidth - menuWidth - (2 * menuTextPadding);
                    break;
            }

            // Draw background
            Console.BackgroundColor = Colors.BackgroundColor;
            for (int i = 0; i < menuItems.Count + 4; i++) {
                Console.SetCursorPosition(startX - menuPadding, startY - 1 + i);
                Console.Write(new String(' ', menuWidth + (2 * menuPadding) + (2 * menuTextPadding)));
            }

            // Draw menu title
            Console.SetCursorPosition(startX, startY);
            Console.Write(Utils.CenterText(menuTitle, menuWidth + (2 * menuTextPadding)));

            // Draw the menu items and set the active styling
            for (int i = 0; i < menuItems.Count; i++) {
                // set caluclated positions
                Console.SetCursorPosition(startX, startY + i + 2);

                MenuItem menuItem = menuItems[i];

                if (i == selectedItem) {
                    Console.BackgroundColor = Colors.SelectedTextBackgroundColor;
                    Console.ForegroundColor = Colors.SelectedTextForegroundColor;
                    DrawMenuItem(menuItem);
                    Console.BackgroundColor = Colors.TextBackgroundColor;
                    Console.ForegroundColor = Colors.TextForegroundColor;
                } else {
                    Console.BackgroundColor = Colors.BackgroundColor;
                    DrawMenuItem(menuItem);
                    Console.BackgroundColor = Colors.TextBackgroundColor;
                }
            }
        }


        /**
          * DrawMenuItem(item)
          */
        private void DrawMenuItem(MenuItem item) {
            string alignedText = null;

            switch(textAlignment) {
                case MenuOption.TEXT_ALIGN_LEFT:
                    alignedText = item.Text.PadRight(menuWidth);
                    break;
                
                case MenuOption.TEXT_ALIGN_CENTER:
                    alignedText = Utils.CenterText(item.Text, menuWidth);
                    break;
                
                case MenuOption.TEXT_ALIGN_RIGHT:
                    alignedText = item.Text.PadLeft(menuWidth);
                    break;
            }

            Console.WriteLine("{1}{0}{1}", alignedText, "".PadRight(menuTextPadding));
        }
    }
}
