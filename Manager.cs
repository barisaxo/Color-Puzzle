




//FIX MOVES ON LOAD

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public AudioClip blop, yay;
    public int solved, solved3, solved4, solved5,
        best, best3, best4, best5,
        moves, moves3, moves4, moves5,
        objectiveColor, objectiveColor3, objectiveColor4, objectiveColor5,
        count, count3, count4, count5,
        oldbest, oldbest4, oldbest3, oldbest5;
    public int[] savedColor3, savedColor4, savedColor5;
    public GameObject solvedText, bestText, movesText, BloopAudio;
    public int gridSize;
    public bool newColor, oBD;              //oBD == "ObjectiveButton" Done
    public Sprite black, white;

    GameObject[] block3, block4, block5;
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    void Awake()
    {
        if (PlayerPrefs.GetInt("OBD", 0) == 1)  { oBD = true; }


        int ncb = PlayerPrefs.GetInt("NewColorBool");
        if (ncb == 1) { newColor = true; }
        gridSize = PlayerPrefs.GetInt("GridSize", 9);

        oldbest = PlayerPrefs.GetInt("OldBest", 0);
        moves = PlayerPrefs.GetInt("Count", 0);
        objectiveColor = PlayerPrefs.GetInt("ObjectiveColor", 0);
        solved = PlayerPrefs.GetInt("Solved", 0);
        best = PlayerPrefs.GetInt("Best", 0);
    
        oldbest3 = PlayerPrefs.GetInt("OldBest3", 0);
        moves3 = PlayerPrefs.GetInt("Count3", 0);
        objectiveColor3 = PlayerPrefs.GetInt("ObjectiveColor3", 0);
        solved3 = PlayerPrefs.GetInt("Solved3", 0);
        best3 = PlayerPrefs.GetInt("Best3", 0);
        savedColor3 = new int[9];

        oldbest4 = PlayerPrefs.GetInt("OldBest4", 0);
        moves4 = PlayerPrefs.GetInt("Count4", 0);
        objectiveColor4 = PlayerPrefs.GetInt("ObjectiveColor4", 0);
        solved4 = PlayerPrefs.GetInt("Solved4", 0);
        best4 = PlayerPrefs.GetInt("Best4", 0);
        savedColor4 = new int[16];

        oldbest5 = PlayerPrefs.GetInt("OldBest5", 0);
        moves5 = PlayerPrefs.GetInt("Count5", 0);
        objectiveColor5 = PlayerPrefs.GetInt("ObjectiveColor5", 0);
        solved5 = PlayerPrefs.GetInt("Solved5", 0);
        best5 = PlayerPrefs.GetInt("Best5", 0);
        savedColor5 = new int[25];

        for (int i = 0; i < 9; i++)
        {
            savedColor3[i] = PlayerPrefs.GetInt("SavedColor3" + i);
        }
        for (int i = 0; i < 16; i++)
        {
            savedColor4[i] = PlayerPrefs.GetInt("SavedColor4" + i);
        }
        for (int i = 0; i < 25; i++)
        {
            savedColor5[i] = PlayerPrefs.GetInt("SavedColor5" + i);
        }
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    private void Start()
    {
        block3 = new GameObject[9];
        block4 = new GameObject[16];
        block5 = new GameObject[25];
    
        SetBlock3();
        SetBlock4(); 
        SetBlock5();
        SetUpOld3();
        SetUpOld4();
        SetUpOld5();

        Invoke("InvokeGB", 1f);

        if (solved3 >= 1)
        { GameObject.Find("GridSizesB").GetComponent<Button>().onClick.Invoke(); }
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    void InvokeGB()
    {
        Debug.Log("Invoked)");
        GameObject.Find("GB" + Mathf.Sqrt(gridSize)).GetComponent<Button>().onClick.Invoke();
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆





    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    void SetBlock3()
    {
        for (int i = 0; i < 9; i++)
        {
            block3[i] = GameObject.Find(3 + "Square" + (i + 1));
        }
    }
    void SetBlock4()
    {
        for (int i = 0; i < 16; i++)
        {
            block4[i] = GameObject.Find(4 + "Square" + (i + 1));
        }
    }
    void SetBlock5()
    {
        for (int i = 0; i < 25; i++)
        {
            block5[i] = GameObject.Find(5 + "Square" + (i + 1));
        }
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    public void SetUpOld()
     {
        if (gridSize == 9)
        { SetUpOld3(); }
        if (gridSize == 16)
        { SetUpOld4(); }
        if (gridSize == 25)
        { SetUpOld5(); }
    }
    public void SetUpOld3()
    {
        moves = moves3;
        UpdateText();

        if (objectiveColor3 == 0) // black
        {
            for (int i = 0; i < 9; i++)
            {
                if (block3[i].GetComponent<Colors>().r == true || block3[i].GetComponent<Colors>().g == true || block3[i].GetComponent<Colors>().b == true)
                { return; }
            }
        }

        // make similar funciton for white


        if (gridSize == 9)
        {
            Debug.Log("Setting up new");
            GameObject.Find("GB" + Mathf.Sqrt(gridSize)).GetComponent<Button>().onClick.Invoke();
            GameObject.Find("__Manager").GetComponent<Manager>().SetUp();
        }
        moves = moves3;
    }

    public void SetUpOld4()
    {
        moves = moves4;
        UpdateText();

        if (objectiveColor4 == 0) // black
        {
            for (int i = 0; i < 16; i++)
            {
                if (block4[i].GetComponent<Colors>().r == true || block4[i].GetComponent<Colors>().g == true || block4[i].GetComponent<Colors>().b == true)
                { return; }
            }
        }
        if (gridSize == 16)
        {
            Debug.Log("Setting up new");
            GameObject.Find("GB" + Mathf.Sqrt(gridSize)).GetComponent<Button>().onClick.Invoke();
            GameObject.Find("__Manager").GetComponent<Manager>().SetUp();
        }
    }
    public void SetUpOld5()
    {
        moves = moves5;
        UpdateText();

        if (objectiveColor5 == 0) // black
        {
            for (int i = 0; i < 25; i++)
            {
                if (block5[i].GetComponent<Colors>().r == true || block5[i].GetComponent<Colors>().g == true || block5[i].GetComponent<Colors>().b == true)
                { return; }
            }
        }
        if (gridSize == 25)
        {
            Debug.Log("Setting up new");
            GameObject.Find("GB" + Mathf.Sqrt(gridSize)).GetComponent<Button>().onClick.Invoke();
            GameObject.Find("__Manager").GetComponent<Manager>().SetUp();
        }
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆





    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    public void SetUp()
    {
        if (gridSize == 9)
         { SetUp3(); }
        if (gridSize == 16)
        { SetUp4(); }
        if (gridSize == 25)
        { SetUp5(); }
    }
    public void SetUp3()
    {
        block3 = new GameObject[gridSize];
        savedColor3 = new int[gridSize];
        // savedColor3 = new int[gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            block3[i] = GameObject.Find(Mathf.Sqrt(gridSize) + "Square" + (i + 1));
            block3[i].GetComponent<Colors>().gridSize = gridSize;
            block3[i].GetComponent<Colors>().NewGame();
            //    Debug.Log(Mathf.Sqrt(gridSize) + "Square" + (i + 1));
        }

        UpdateText();
    }
    public void SetUp4()
    {
        block4 = new GameObject[gridSize];
        savedColor4 = new int[gridSize];
        // savedColor3 = new int[gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            block4[i] = GameObject.Find(Mathf.Sqrt(gridSize) + "Square" + (i + 1));
            block4[i].GetComponent<Colors>().gridSize = gridSize;
            block4[i].GetComponent<Colors>().NewGame();
            //    Debug.Log(Mathf.Sqrt(gridSize) + "Square" + (i + 1));
        }

        UpdateText();
    }
    public void SetUp5()
    {
        block5 = new GameObject[gridSize];
        savedColor5 = new int[gridSize];
        // savedColor3 = new int[gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            block5[i] = GameObject.Find(Mathf.Sqrt(gridSize) + "Square" + (i + 1));
            block5[i].GetComponent<Colors>().gridSize = gridSize;
            block5[i].GetComponent<Colors>().NewGame();
            //    Debug.Log(Mathf.Sqrt(gridSize) + "Square" + (i + 1));
        }

        UpdateText();
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆





    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    public void SaveGame()
    {
        //PlayerPrefs.SetInt("Solved", solved);
        //PlayerPrefs.SetInt("Best", best);
        PlayerPrefs.SetInt("ObjectiveColor", objectiveColor);
        PlayerPrefs.SetInt("GridSize", gridSize);

        //PlayerPrefs.SetInt("Count3", count);
        //PlayerPrefs.SetInt("OldBest", oldbest);

        if (oBD == true) { int ohBD = 1; PlayerPrefs.SetInt("OBD", ohBD); }


        SaveGame3();
        SaveGame4();
        SaveGame5();
    }
    public void SaveGame3()
    {
        PlayerPrefs.SetInt("Solved3", solved3);
        PlayerPrefs.SetInt("Best3", best3);
        PlayerPrefs.SetInt("ObjectiveColor3", objectiveColor3);
       // PlayerPrefs.SetInt("GridSize", gridSize);
        //PlayerPrefs.SetInt("Count3", count3);
        PlayerPrefs.SetInt("OldBes3t", oldbest3);

        for (int i = 0; i < 9; i++)
        {
            savedColor3[i] = 0;
            if (block3[i].GetComponent<Colors>().r == true)
            { savedColor3[i] += 1; }
            if (block3[i].GetComponent<Colors>().g == true)
            { savedColor3[i] += 2; }
            if (block3[i].GetComponent<Colors>().b == true)
            { savedColor3[i] += 4; }
            PlayerPrefs.SetInt("SavedColor3" + i, savedColor3[i]);
        }
    }
    public void SaveGame4()
    {
        PlayerPrefs.SetInt("Solved4", solved4);
        PlayerPrefs.SetInt("Best4", best4);
        PlayerPrefs.SetInt("ObjectiveColor4", objectiveColor4);
       // PlayerPrefs.SetInt("GridSize", gridSize);
       // PlayerPrefs.SetInt("Count4", count4);
        PlayerPrefs.SetInt("OldBest4", oldbest4);

        for (int i = 0; i < 16; i++)
        {
            savedColor4[i] = 0;
            if (block4[i].GetComponent<Colors>().r == true)
            { savedColor4[i] += 1; }
            if (block4[i].GetComponent<Colors>().g == true)
            { savedColor4[i] += 2; }
            if (block4[i].GetComponent<Colors>().b == true)
            { savedColor4[i] += 4; }
            PlayerPrefs.SetInt("SavedColor4" + i, savedColor4[i]);
        }
    }
    public void SaveGame5()
    {
        PlayerPrefs.SetInt("Solved5", solved5);
        PlayerPrefs.SetInt("Best5", best5);
        PlayerPrefs.SetInt("ObjectiveColor5", objectiveColor5);
       // PlayerPrefs.SetInt("GridSize", gridSize);
       // PlayerPrefs.SetInt("Count5", count5);
        PlayerPrefs.SetInt("OldBest5", oldbest5);

        for (int i = 0; i < 25; i++)
        {
            savedColor5[i] = 0;
            if (block5[i].GetComponent<Colors>().r == true)
            { savedColor5[i] += 1; }
            if (block5[i].GetComponent<Colors>().g == true)
            { savedColor5[i] += 2; }
            if (block5[i].GetComponent<Colors>().b == true)
            { savedColor5[i] += 4; }
            PlayerPrefs.SetInt("SavedColor5" + i, savedColor5[i]);
        }
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆





    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    public void UpdateText()
    {
        if (gridSize == 9)
        {
            solvedText.GetComponent<Text>().text = ("Solved: " + solved3);
            bestText.GetComponent<Text>().text = ("Best: " + best3);
            movesText.GetComponent<Text>().text = ("Moves: " + moves3);
        }
        if (gridSize == 16)
        {
            solvedText.GetComponent<Text>().text = ("Solved: " + solved4);
            bestText.GetComponent<Text>().text = ("Best: " + best4);
            movesText.GetComponent<Text>().text = ("Moves: " + moves4);
        }
        if (gridSize == 25)
        {
            solvedText.GetComponent<Text>().text = ("Solved: " + solved5);
            bestText.GetComponent<Text>().text = ("Best: " + best5);
            movesText.GetComponent<Text>().text = ("Moves: " + moves5);
        }
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    public void CheckForSolve()
    {

        //tr = false;  // THIS IS IF I WANT TO TRY TO SAY "Make the puzzle all BLUE, or all RED..." etc. I don't think it will be solvable, i'm not sure ~\(.)V^V(.)/~
        //tg = false;
        //tb = false;
        //for (int sc = 0; sc <= 7; sc++)
        //if (objectiveColor == sc)
        //{
        //        tr |= (sc == 1 || sc == 3 || sc == 5 || sc == 7);

        //        tg |= (sc == 2 || sc == 3 || sc == 6 || sc == 7);

        //        tb |= (sc == 4 || sc == 5 || sc == 6 || sc == 7);

        //        for (int i = 0; i < gridsize; i++)
        //        {
        //        if (block3[i].GetComponent<Colors>().r != tr || block3[i].GetComponent<Colors>().g != tg || block3[i].GetComponent<Colors>().b != tb)
        //        { return; }
        //    }
        //}
        count = moves;
       // SaveGame();
        if (gridSize == 9) { SaveGame3(); Check3(); }
        if (gridSize == 16) { SaveGame4(); Check4(); }
        if (gridSize == 25) { SaveGame5(); Check5(); }
    }
    void Check3()
    {
        count3 = moves3;

        if (objectiveColor3 == 0) // black
        {
            for (int i = 0; i < gridSize; i++)
            {
                if (block3[i].GetComponent<Colors>().r == true || block3[i].GetComponent<Colors>().g == true || block3[i].GetComponent<Colors>().b == true)
                { return; }
            }
        }

        if (objectiveColor3 == 1) //white
        {
            for (int i = 0; i < gridSize; i++)
            {
                if (block3[i].GetComponent<Colors>().r == false || block3[i].GetComponent<Colors>().g == false || block3[i].GetComponent<Colors>().b == false)
                { return; }
            }
        }

        solved3++;
        oldbest3 = best3;
        if (best3 == 0 || best3 > moves3)
        { best3 = moves3; }
        moves3 = 0;
        if (solved3 == 1)
        SaveGame3();
        for (int i = 0; i < 9; i++)
        { GameObject.Find("GridSizesB").GetComponent<Button>().onClick.Invoke(); }
        Solved3();
    }
    void Check4()
    {
        count4 = moves4;
        if (objectiveColor4 == 0) // black
        {
            for (int i = 0; i < gridSize; i++)
            {
                if (block4[i].GetComponent<Colors>().r == true || block4[i].GetComponent<Colors>().g == true || block4[i].GetComponent<Colors>().b == true)
                { return; }
            }
        }

        if (objectiveColor4 == 1) //white
        {
            for (int i = 0; i < gridSize; i++)
            {
                if (block4[i].GetComponent<Colors>().r == false || block4[i].GetComponent<Colors>().g == false || block4[i].GetComponent<Colors>().b == false)
                { return; }
            }
        }
        solved4++;
        oldbest4 = best4;
        if (best4 == 0 || best4 > moves4)
        { best4 = moves4; }
        moves4 = 0;
        SaveGame4();
        Solved4();
    }
    void Check5()
    {
        count5 = moves5;
        if (objectiveColor5 == 0) // black
        {
            for (int i = 0; i < gridSize; i++)
            {
                if (block5[i].GetComponent<Colors>().r == true || block5[i].GetComponent<Colors>().g == true || block5[i].GetComponent<Colors>().b == true)
                { return; }
            }
        }

        if (objectiveColor5 == 1) //white
        {
            for (int i = 0; i < gridSize; i++)
            {
                if (block5[i].GetComponent<Colors>().r == false || block5[i].GetComponent<Colors>().g == false || block5[i].GetComponent<Colors>().b == false)
                { return; }
            }
        }
        solved5++;
        oldbest5 = best5;
        if (best5 == 0 || best5> moves5)
        { best5 = moves5; }
        moves5 = 0;
        SaveGame5();
        Solved5();
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    public void Solved()
    {
        if (gridSize == 9) { Solved3(); }
        if (gridSize == 16) { Solved4(); }
        if (gridSize == 25) { Solved5(); }
    }
    public void Solved3()
    {
        for (int i = 0; i < 9; i++)
        {
            block3[i].AddComponent<Rigidbody2D>();
            block3[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            block3[i].GetComponent<Rotate>().enabled = true;
            block3[i].GetComponent<Rotate>().RotateAgain();
            block3[i].GetComponent<BoxCollider2D>().enabled = true;
            block3[i].GetComponent<Button>().interactable = false;

        }
        if (newColor == false && best3 <= 33 && best3 >= 0)
        {
            newColor = true;
            GameObject.Find("ObjectiveB").GetComponent<ColorObjective>().CheckForSolvedTwo();
            //PlayerPrefs.SetInt("NewColorBool", 1);
        }
        Invoke("ButtonON3", 3f);
    }
    public void Solved4()
    {
        for (int i = 0; i < 16; i++)
        {
            block4[i].AddComponent<Rigidbody2D>();
            block4[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            block4[i].GetComponent<Rotate>().enabled = true;
            block4[i].GetComponent<Rotate>().RotateAgain();
            block4[i].GetComponent<BoxCollider2D>().enabled = true;
            block4[i].GetComponent<Button>().interactable = false;
        }
        Invoke("ButtonON4", 3f);
    }
    public void Solved5()
    {
        for (int i = 0; i < 25; i++)
        {
            block5[i].AddComponent<Rigidbody2D>();
            block5[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            block5[i].GetComponent<Rotate>().enabled = true;
            block5[i].GetComponent<Rotate>().RotateAgain();
            block5[i].GetComponent<BoxCollider2D>().enabled = true;
            block5[i].GetComponent<Button>().interactable = false;
        }
        Invoke("ButtonON5", 3f);
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    //void ButtonON()               //
    //{
    //    GameObject.Find("SolveB").GetComponent<Button>().onClick.Invoke();
    //    GameObject.Find("SolvedButtonText").GetComponent<Text>().text = (count.ToString() + "!");
    //    if (oldbest > count || oldbest == 0)
    //    {
    //        GameObject.Find("SolvedButtonText").GetComponent<Text>().text = (count.ToString() + "!        "+ "        NEW BEST!!!");
    //    }
    //    oldbest = best;
    //    SaveGame();
    //}
    void ButtonON3()               //
    {
        BloopAudio.GetComponent<AudioSource>().PlayOneShot(yay);
        GameObject.Find("SolveB").GetComponent<Button>().onClick.Invoke();
        GameObject.Find("SolvedButtonText").GetComponent<Text>().text = (count3.ToString() + "!");
        if (oldbest3 > count3 || oldbest3 == 0)
        {
            GameObject.Find("SolvedButtonText").GetComponent<Text>().text = (count3.ToString() + "!        " + "        NEW BEST!!!");
        }
        oldbest3 = best3;
        SaveGame();
    }
    void ButtonON4()               //
    {
        BloopAudio.GetComponent<AudioSource>().PlayOneShot(yay);
        GameObject.Find("SolveB").GetComponent<Button>().onClick.Invoke();
        GameObject.Find("SolvedButtonText").GetComponent<Text>().text = (count4.ToString() + "!");
        if (oldbest4 > count4 || oldbest4 == 0)
        {
            GameObject.Find("SolvedButtonText").GetComponent<Text>().text = (count4.ToString() + "!        " + "        NEW BEST!!!");
        }
        oldbest4 = best4;
        SaveGame();
    }
    void ButtonON5()               //
    {
        BloopAudio.GetComponent<AudioSource>().PlayOneShot(yay);
        GameObject.Find("SolveB").GetComponent<Button>().onClick.Invoke();
        GameObject.Find("SolvedButtonText").GetComponent<Text>().text = (count5.ToString() + "!");
        if (oldbest5 > count5 || oldbest5 == 0)
        {
            GameObject.Find("SolvedButtonText").GetComponent<Text>().text = (count5.ToString() + "!        " + "        NEW BEST!!!");
        }
        oldbest5 = best5;
        SaveGame();
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    void Reset()
    {
        if (gridSize == 9) { Reset3(); }
        if (gridSize == 16) { Reset4(); }
        if (gridSize == 25) { Reset5(); }
    }
        void Reset3()
        {
            for (int i = 0; i < gridSize; i++)
            { block3[i].GetComponent<Colors>().NewGame(); }
            moves3 = 0;
            count3 = 0;
            UpdateText();
            SaveGame3();
        }
        void Reset4()
        {
            for (int i = 0; i < gridSize; i++)
            { block4[i].GetComponent<Colors>().NewGame(); }
            moves4 = 0;
            count4 = 0;
            UpdateText();
        SaveGame4();
        }
        void Reset5()
        {
            for (int i = 0; i < gridSize; i++)
            { block5[i].GetComponent<Colors>().NewGame(); }
            moves5 = 0;
            count5 = 0;
            UpdateText();
        SaveGame5();
        }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    public void Resetting()
        {
            Invoke("Reset", .5f);
        }
        void Resetting3()
        {
            Invoke("Reset3", .5f);
        }
        void Resetting4()
        {
            Invoke("Reset4", .5f);
        }
        void Resetting5()
        {
            Invoke("Reset5", .5f);
        }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆
    public void ResetSaveData()
        {
            PlayerPrefs.SetInt("OBD", 0);
            PlayerPrefs.SetInt("Solved", 0);
            PlayerPrefs.SetInt("Best", 0);
            PlayerPrefs.SetInt("ObjectiveColor", 0);
            PlayerPrefs.SetInt("GridSize", 9);
            PlayerPrefs.SetInt("OldBest", 0);
            PlayerPrefs.SetInt("Count", 0);
            solved = 0;
            best = 0;
            objectiveColor = 0;
            gridSize = 9;
            moves = 0;
            oBD = false;

            PlayerPrefs.SetInt("Solved3", 0);
            PlayerPrefs.SetInt("Best3", 0);
            PlayerPrefs.SetInt("ObjectiveColor3", 0);
            PlayerPrefs.SetInt("OldBest3", 0);
            PlayerPrefs.SetInt("Count3", 0);
            solved3 = 0;
            best3 = 0;
            objectiveColor3 = 0;
            moves3 = 0;

            PlayerPrefs.SetInt("Solved4", 0);
            PlayerPrefs.SetInt("Best4", 0);
            PlayerPrefs.SetInt("ObjectiveColor4", 0);
            PlayerPrefs.SetInt("OldBest4", 0);
            PlayerPrefs.SetInt("Count4", 0);
            solved4 = 0;
            best4 = 0;
            objectiveColor4 = 0;
            moves4 = 0;

            PlayerPrefs.SetInt("Solved5", 0);
            PlayerPrefs.SetInt("Best5", 0);
            PlayerPrefs.SetInt("ObjectiveColor5", 0);
            PlayerPrefs.SetInt("OldBest5", 0);
            PlayerPrefs.SetInt("Coun5", 0);
            solved5 = 0;
            best5 = 0;
            objectiveColor5 = 0;
            moves5 = 0;

            Resetting3();
            Resetting4();
            Resetting5();
            UpdateText();
            GameObject.Find("Color Select Button").GetComponent<Image>().sprite = black;
            GameObject.Find("GB3").GetComponent<Button>().onClick.Invoke();
            newColor = false;
            PlayerPrefs.SetInt("NewColorBool", 0);
        }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    public void CheckObjective()
    {
        if (objectiveColor == 0)
        { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = black; }

        if (objectiveColor == 1)
        { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = white; }
    }

    public void blip()
    {
      BloopAudio.GetComponent<AudioSource>().PlayOneShot(blop);
    }
}
