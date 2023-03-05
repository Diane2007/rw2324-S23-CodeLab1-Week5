using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ASCIILevelLoader : MonoBehaviour
{
    public GameObject wall;
    public GameObject doggo;
    public GameObject dad;
    public GameObject burger;

    int currentLevel = 0;   //level starts with 0
    public int CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }
    
    //keeping track of the score whenever burger is eaten
    int burgerScore = 0;
    public TextMeshPro scoreTracker;
    public int BurgerScore
    {
        get { return burgerScore; }
        set
        {
            burgerScore = value;
            scoreTracker.text = "" + burgerScore;
        }
    }
    
    
    //prepare for file names and direction
    const string FILE_NAME = "LevelNum.txt";
    const string FILE_DIR = "/Level/";
    string FILE_PATH;

    GameObject currentPlayer;
    GameObject level;
    
    //variables for the game objects' place on the screen
    Vector2 doggoStartPos;
    public float xOffset = 0f;
    public float yOffset = 0f;
    
    void Start()
    {
        //define File_Path
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        LoadLevel();
        scoreTracker.text = "" + BurgerScore;
    }

    void LoadLevel()
    {
        Destroy(level);     //destroy just in case there are previous level game objects
        
        level = new GameObject("Level");    //create a new game object named "Level"
        
        //customize the file_name for each level
        string newPath = FILE_PATH.Replace("Num", "" + currentLevel);
        
        //make an array for each line in the txt file
        string[] fileLines = File.ReadAllLines(newPath);
        
        //for loop, going through each line
        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            //with a new string var file Contents, get each line out of the array
            string fileContents = fileLines[yPos];
            
            //a new array of characters, turn chars in the current line into this array
            char[] lineText = fileContents.ToCharArray();
            
            //for loop inside the for loop, going through each char of this char array
            for (int xPos = 0; xPos < lineText.Length; xPos++)
            {
                //get each character out of the array
                char c = lineText[xPos];
                
                //now we need to see if any of these characters are dogs, dad, burger, or wall
                GameObject newObj;      //just a holder of the potential dogs, dad, burger, and wall

                switch (c)
                {
                    case'G':    //G = golden retriever
                        doggoStartPos = new Vector2(xOffset + xPos, yOffset - yPos);    //where the dog starts
                        newObj = Instantiate<GameObject>(doggo);    //make a new doggo instance
                        currentPlayer = newObj;     //this is our current player
                        break;
                    case'w':
                        newObj = Instantiate<GameObject>(wall);     //make a new wall
                        break;
                    case'd':
                        newObj = Instantiate<GameObject>(dad);      //make a new dad (lol)
                        break;
                    case'b':
                        newObj = Instantiate<GameObject>(burger);   //make a new burger
                        break;
                    default:
                        newObj = null;
                        break;
                }

                if (newObj != null)     //if the characters are not null
                {
                    //each will have a position according to their xPos and yPos in the for loop
                    newObj.transform.position =
                        new Vector2(xOffset + xPos, yOffset - yPos);
                    //make the GameObject "level" the parent of GameObject "newObj"
                    newObj.transform.parent = level.transform;
                }

            }
        }
    }

    public void ResetDoggo()
    {
        //reset doggo position to where he starts
        currentPlayer.transform.position = doggoStartPos;
    }

    public void EatBurger()
    {
        Debug.Log("Yay food!!");
        CurrentLevel++;     //when doggo eats burger, level number goes up
        BurgerScore++;
    }
}
