using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //game state
    int level;
    string gamestate;
    string password;
    int level3pascounter = 1;
    int level3pass1index;
    string hitmenu = "You can enter menu at any time";

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
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web browser close the tab");
            Application.Quit();
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
            Decidegamestate();
            startgame();
        }
        
        else
            Terminal.WriteLine("Invalid option");
    }
    void Decidegamestate()
    {
        switch (level)
        {
            case 1:
                gamestate = "Local Library";
                break;
            case 2:
                gamestate = "Police Station";
                break;
            case 3:
                gamestate = "Wifi System";
                break;
        }
    }
    void CheckPassword(string input)
    {
        if (level == 1 || level == 2)
        {
            if (input == password)
            {
                DisplayWinScreen();
            }
            else
            {
                Terminal.WriteLine("Sorry!! Wromg Password !!Try Again");
                startgame();
            }
        }
        else if (level == 3)
        {
            if (level3pascounter == 1)
            {
                if (input == password)
                {
                    Terminal.WriteLine("Stage1 cleared");
                    level3pascounter+= 1;
                    startgame();

                }
                else
                {
                    Terminal.WriteLine("Sorry!! Wromg Password !!Try Again");
                    startgame();
                }
            }
            else if (level3pascounter == 2)
            {
                if (input == password)
                {
                    level3pascounter = 1;
                    DisplayWinScreen();
                }
            }
        }

        
    }
    void DisplayWinScreen()
    {
        currentscreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(hitmenu); 
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You have got a book!!!");
                Terminal.WriteLine(@"
        ________
       /       //  
      /       //    
     /_______//   
    (_______(/
                "
                );
                break;
            case 2:
                Terminal.WriteLine("You have got a prison key!!!");
                Terminal.WriteLine(@"
  ___  
 /0  \_______________
 \___/-=' = '
                ");
                break;
            case 3:
                Terminal.WriteLine("You have got a Router signal");
                Terminal.WriteLine(@"

         _     )
        ||   )  )
        || )  )  )
        ||   )  )
      __||____ )    
    /___||______\
    |           |
    |___________|

                ");
                break;
        }
    }
    void startgame()
    {
        currentscreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hacking into " + gamestate);
        if (level == 3)
        {
            if (level3pascounter == 1)
            {
                Terminal.WriteLine("Stage 1 :");
            }
            else if (level3pascounter == 2)
            {
                Terminal.WriteLine("Stage 2 :");
            }
        }
        RandomPasswordgenerator();
        Terminal.WriteLine("Enter the password...Hint..."+password.Anagram());
        
        
    }
    void RandomPasswordgenerator()
    {
        switch (level)
        {
            case 1:
                password = level1password[Random.Range(0, level1password.Length)];
                break;
            case 2:
                password = level2password[Random.Range(0, level2password.Length)];
                break;
            case 3:
                if (level3pascounter == 1)
                {
                    level3pass1index = Random.Range(0, level3password.Length);
                    password = level3password[level3pass1index];
                }
                else
                {
                    int index = Random.Range(0, level3password.Length);
                    if (index == level3pass1index)
                        RandomPasswordgenerator();
                    else
                        password = level3password[index];
                }
                break;
            default:
                Debug.LogError("Invalid level entered");
                break;
        }
    } 
}
