using System;
using ConsoleUI;



class MainClass {
    public static void Main(string[] args) {
        Utils.Setup();
        MainMenu().Show();
    }


    /**
      * Menu Component Demo
      * ===================
      * Use the Up and Down arrow keys to navigate
      * to select an option, press Enter.
      */       
    public static Menu MainMenu() {
        // create the menu
        Menu mainMenu = new Menu("The Main Menu", MenuOption.ALIGN_CENTER, MenuOption.ALIGN_MIDDLE, MenuOption.TEXT_ALIGN_CENTER);

        // add items to the menu
        mainMenu.AddItem(new MenuItem("MenuItem 1", new MenuCallback(ExitApplication)));
        mainMenu.AddItem(new MenuItem("MenuItem 2", new MenuCallback(ExitApplication)));
        mainMenu.AddItem(new MenuItem("SubMenu", SubMenu()));
        mainMenu.AddItem(new MenuItem("Exit", new MenuCallback(ExitApplication)));
        
        return mainMenu;
    }


    /**  
      * SubMenu Component Demo
      * ======================
      * Example that shows a sub-menu in use with a smooth
      * tranition between the two.
      *
      * A SubMenu is just a regular Menu that is added as a callback
      * to the parent MenuItem.
      */
    public static Menu SubMenu() {
        Menu subMenu = new Menu("SubMenu", MenuOption.ALIGN_CENTER, MenuOption.ALIGN_MIDDLE, MenuOption.TEXT_ALIGN_CENTER);

        // add the items to the sub menu the same
        // way you would to a normal menu
        subMenu.AddItem(new MenuItem("SubMenu Option 1", new MenuCallback(ExitApplication)));
        subMenu.AddItem(new MenuItem("SubMenu Option 2", new MenuCallback(ExitApplication)));
        subMenu.AddItem(new MenuItem("SubMenu Option 3", new MenuCallback(ExitApplication)));
        subMenu.AddItem(new MenuItem("SubMenu Option 4", new MenuCallback(ExitApplication)));
        subMenu.AddItem(new MenuItem("SubMenu Option 5", new MenuCallback(ExitApplication)));
        subMenu.AddItem(new MenuItem("Back", new MenuCallback(BackToMainMenu)));

        return subMenu;
    }

    public static void BackToMainMenu() {
        // Back buttons can be created by creating a new instance of the
        // old/prev menu
        MainMenu().Show();
    }

    public static void ExitApplication() {
        Console.Clear();
        return;
    }
}
