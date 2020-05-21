using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //game state
    int level;
    string password;
    string[] level1password = { "shelves", "books" ,"study","atheneum","silence","bibliophile"};
    string[] level2password = { "prisoner", "jail","lockup","thana","uniform","substation","chowkidar" };
    string[] level3password = { "ethernet", "router","bluetooth","encryption","bandwidth","firewall"};
    enum Screen { MainMenu,Password,Win};
    Screen currentscreen;
    
    

    void Start()
    {
       ShowMainMenu("Hello");
    }

    

    void ShowMainMenu(string greeting)
    {
        currentscreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into??");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Press 3 for Wifi system ");
        Terminal.WriteLine("Enter your selection");
    }

    void OnUserInput(string input)
    {
        
        if (input == "menu")
            {
                ShowMainMenu("Hello Sayan");

            }
        
        else if (currentscreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentscreen == Screen.Password)
        {

            CheckPassword(input);
        }
        
        
    }

    void RunMainMenu(string input)
    {
        bool isvalidlevel = (input == "1" || input == "2" || input == "3");
        if (isvalidlevel)
        {
            level = int.Parse(input);
            startgame();
        }
        
        else
            Terminal.WriteLine("Invalid option");
    }
    void CheckPassword(string input)
    {
        if (level == 1)
        {
            if (input == password)
            {
                Terminal.WriteLine("Congratulations!!! Correct Password");
                currentscreen = Screen.Win;
            }
            else
                Terminal.WriteLine("Sorry!! Wromg Password !!Try Again");

        }
        else if (level == 2)
        {
            if (input == password)
            {
                Terminal.WriteLine("Congratulations!!! Correct Password");
                currentscreen = Screen.Win;
            }
            else
                Terminal.WriteLine("Sorry!! Wromg Password !!Try Again");
        }
        else if (level == 3)
        {
            if (input == password)
            {
                Terminal.WriteLine("Congratulations!!! Correct Password");
                currentscreen = Screen.Win;
            }
            else
                Terminal.WriteLine("Sorry!! Wromg Password !!Try Again");
        }
    }

    void startgame()
    {
        currentscreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1password[Random.Range(0,level1password.Length)];
                break;
            case 2:
                password = level2password[Random.Range(0,level2password.Length)];
                break;
            case 3:
                password = level3password[Random.Range(0,level3password.Length)];
                break;
            default:
                Debug.LogError("Invalid level entered");
                break;

        }
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Enter the password for level " + level);
    }
}
