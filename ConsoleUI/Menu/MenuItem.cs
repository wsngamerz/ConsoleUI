namespace ConsoleUI {
    /**
      * MenuCallback
      * ============
      */
    public delegate void MenuCallback();



    /**
      * MenuItem
      * ========
      *
      * Child class which holds the callback (delegate) method which will
      * be called when the MenuItem is selected along with the Text to 
      * display in the menu.
      */
    class MenuItem {
        private string menuText;
        private MenuCallback menuCallback;

        /**
          * Constructor(string, MenuCallback)
          * Creates a menu item with text and a method as a callback.
          */
        public MenuItem(string text, MenuCallback callback) {
            menuText = text;
            menuCallback = callback;
        }


        /**
          * Constructor(string, Menu)
          * Creates a menu item with text and another menu to display.
          */
        public MenuItem(string text, Menu menu) {
            menuText = menu.menuTitle;
            menuCallback = menu.Show;
        }


        /**
          * Text
          */
        public string Text {
            get { return menuText; }
            set { menuText = value; }
        }


        /**
          * Select()
          * The callback method
          */
        public void Select() {
            menuCallback();
        }
    }
}
