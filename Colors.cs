using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//GO (gSquareX)      they are no longer squares with current art but thats ok       | (• ◡•)|/ \(❍ᴥ❍ʋ)


public class Colors : MonoBehaviour
{
    
    public Sprite black, white, red, blue, green, cyan, magenta, yellow;
    public bool r, g, b, newGrid, NewColor;
    bool doL, doR, doU, doD, cTW;
    GameObject manager;
    public GameObject[] square, square3, square4, square5;
    Vector3 startPos;
    public int gridSize;
    public int sc;
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆



    private void Awake()
    {
       
        //Debug.Log("Awake " + this.gameObject);
        manager = GameObject.Find("__Manager");
        gridSize = manager.GetComponent<Manager>().gridSize;
        square = new GameObject[gridSize];
        square3 = new GameObject[9];
        square4 = new GameObject[16];
        square5 = new GameObject[25];
        startPos = this.transform.position;
        this.GetComponent<Rotate>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Button>().interactable = true;

        for (int i = 0; i < 9; i++)
        {
            square3[i] = GameObject.Find(3 + "Square" + (i + 1));
        }

        for (int i = 0; i < 16; i++)
        {
            square4[i] = GameObject.Find(4 + "Square" + (i + 1));
        }

        for (int i = 0; i < 25; i++)
        {
            square5[i] = GameObject.Find(5 + "Square" + (i + 1));
        }

        for (int i = 0; i < 9; i++)
        {
            if (square3[i] == this.gameObject)
            { sc = manager.GetComponent<Manager>().savedColor3[i]; }
        }
        //if (gridSize == 16)
        for (int i = 0; i < 16; i++)
        {
            if (square4[i] == this.gameObject)
            { sc = manager.GetComponent<Manager>().savedColor4[i]; }
        }
        // if (gridSize == 25)
        for (int i = 0; i < 25; i++)
        {
            if (square5[i] == this.gameObject)
            { sc = manager.GetComponent<Manager>().savedColor5[i]; }
        }

        r |= (sc == 1 || sc == 3 || sc == 5 || sc == 7);
        g |= (sc == 2 || sc == 3 || sc == 6 || sc == 7);
        b |= (sc == 4 || sc == 5 || sc == 6 || sc == 7);


        SetColor();
    }


    // Start is called before the first frame update && AWAKE IS CALLED BEFORE START FUNCTIONS!!! HEY HEY
    public void First()
    {
        //manager = GameObject.Find("__Manager");
        //gridSize = manager.GetComponent<Manager>().gridSize;
        //square = new GameObject[gridSize];
        //startPos = this.transform.position;
        //this.GetComponent<Rotate>().enabled = false;
        //this.GetComponent<BoxCollider2D>().enabled = false;
        //this.GetComponent<Button>().interactable = true;

        //int gs = GameObject.Find("__Manager").GetComponent<Manager>().gridSize;
        //int ms = (int)Mathf.Sqrt(this.gameObject.GetComponentInParent<GridSizeSub>().setGridSizeTo);
        //if (gs == ms)
        //{
        gridSize = manager.GetComponent<Manager>().gridSize;
        //for (int i = 0; i < gridSize; i++)
        //    {
        //        square[i] = GameObject.Find(Mathf.Sqrt(gridSize) + "Square" + (i + 1));
        //    }

        for (int i = 0; i < 9; i++)
        {
            square3[i] = GameObject.Find(3 + "Square" + (i + 1));
        }

        for (int i = 0; i < 16; i++)
        {
            square4[i] = GameObject.Find(4 + "Square" + (i + 1));
        }

        for (int i = 0; i < 25; i++)
        {
            square5[i] = GameObject.Find(5 + "Square" + (i + 1));
        }


        //if (GetComponentInParent<GridSizeSub>().setGridSizeTo == gridSize)
        //{
        //    Debug.Log("This" + GetComponentInParent<GridSizeSub>().setGridSizeTo);
        //    for (int i = 0; i < gridSize; i++)
        //    {

               // if (square[i] == this.gameObject || square3[i] == this.gameObject || square4[i] == this.gameObject || square5[i] == this.gameObject )
                //{
              //  if (gridSize == 9)
              for (int i = 0; i <9; i++)
                    {
                        if (square3[i] == this.gameObject)
                        { sc = manager.GetComponent<Manager>().savedColor3[i]; }
                    }
        //if (gridSize == 16)
        for (int i = 0; i < 16; i++)
        {
                    if (square4[i] == this.gameObject)
                    { sc = manager.GetComponent<Manager>().savedColor4[i]; }
                }
        // if (gridSize == 25)
        for (int i = 0; i < 25; i++)
        {
                    if (square5[i] == this.gameObject)
                    { sc = manager.GetComponent<Manager>().savedColor5[i]; }
                }

                    r |= (sc == 1 || sc == 3 || sc == 5 || sc == 7);
                    g |= (sc == 2 || sc == 3 || sc == 6 || sc == 7);
                    b |= (sc == 4 || sc == 5 || sc == 6 || sc == 7);
                

        SetColor();
        // SetSavedColors();
        // manager.GetComponent<Manager>().SetUpOld();
        //}
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆






   //public void SetSavedColors()
   // {
   //     gridSize = manager.GetComponent<Manager>().gridSize;
   //     if (GetComponentInParent<GridSizeSub>().setGridSizeTo == gridSize)
   //     {
   //         for (int i = 0; i < gridSize; i++)
   //         {

   //             if (square[i] == this.gameObject)
   //             {
   //                 sc = manager.GetComponent<Manager>().savedColor3[i];
   //                 Debug.Log(sc + manager.GetComponent<Manager>().savedColor3[i] + "WALA");
   //                 r |= (sc == 1 || sc == 3 || sc == 5 || sc == 7);
   //                 g |= (sc == 2 || sc == 3 || sc == 6 || sc == 7);
   //                 b |= (sc == 4 || sc == 5 || sc == 6 || sc == 7);
   //             }
   //         }
   //     }

    //    SetColor();

        //for (int i = 0; i < gridSize; i++)
        //{
        //    if (square[i].GetComponent<Colors>().r == true || square[i].GetComponent<Colors>().g == true || square[i].GetComponent<Colors>().b == true)
        //    { return; }
        //}

        //for (int i = 0; i < gridSize; i++)
        //{
        //    if (square[i] == this.gameObject)
        //        Invoke("NewGame", 0f);
        //}
   // }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆





    public void NewGame()
    {
        gridSize = manager.GetComponent<Manager>().gridSize;
        Destroy(GetComponent<Rigidbody2D>());
        this.GetComponent<Rotate>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Button>().interactable = true;
        transform.SetPositionAndRotation(startPos, Quaternion.Euler(new Vector3(0, 0, 0)));

        r = false;
        g = false;
        b = false;

        int randR = Random.Range(0, 2);
        int randG = Random.Range(0, 2);
        int randB = Random.Range(0, 2);

         r |= randR == 1;    // another way to say: if the interger 'randR' is equal to 1, then set the bool 'r' equal to true...
        g |= randG == 1;
        b |= randB == 1;
        SetColor();
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    public void SetColor()
    {

        if (r == true && g == false && b == false)
        {
            GetComponent<Image>().sprite = red;
        }
        //GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f); }

        if (r == true && g == true && b == false)
        {
            GetComponent<Image>().sprite = yellow;
        }
        //GetComponent<Image>().color = new Color(1f, 1f, 0f, 1f); }

        if (r == true && g == false && b == true)
        {
            GetComponent<Image>().sprite = magenta;
        }
        //GetComponent<Image>().color = new Color(1f, 0f, 1f, 1f); }

        if (r == false && g == true && b == false)
        {
            GetComponent<Image>().sprite = green;
        }
        //GetComponent<Image>().color = new Color(0f, 1f, 0f, 1f); }

        if (r == false && g == true && b == true)
        {
            GetComponent<Image>().sprite = cyan;
        }
        //GetComponent<Image>().color = new Color(0f, 1f, 1f, 1f); }

        if (r == false && g == false && b == true)
        {
            GetComponent<Image>().sprite = blue;
        }
        //GetComponent<Image>().color = new Color(0f, 0f, 1f, 1f); }

        if (r == true && g == true && b == true)
        {
            GetComponent<Image>().sprite = white;
        }
            //GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f); }

            if (r == false && g == false && b == false)
            {
                GetComponent<Image>().sprite = black;
                //  GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f); }
            }
    }
    //∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆




    public void Clicked()
    {
        manager.GetComponent<Manager>().blip();
        gridSize = manager.GetComponent<Manager>().gridSize;
        square = new GameObject[gridSize];

            for (int i = 0; i < gridSize; i++)
            {
                square[i] = GameObject.Find(Mathf.Sqrt(gridSize) + "Square" + (i + 1));
            }

        for (int i = 0; i < gridSize; i++)
        {
            if (square[i] == this.gameObject)
            {
                int gs = (int)Mathf.Sqrt(gridSize);

                doL = true;
                doR = true;
                doU = false;
                doD = false;

                for (int n = 0; n < gs; n++)
                {
                    doL &= i - 1 != (n * gs) - 1;         // &= is set to false. |= is set to true

                    doR &= i != (n * gs) - 1;

                    doU |= i - gs > -1;

                    doD |= i + gs < gridSize;
                }


                //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


                if (doL == true && (i - 1 > -1)) // left
                {
                    if (r == true)
                    {
                        square[i - 1].GetComponent<Colors>().r = !square[i - 1].GetComponent<Colors>().r;
                    }

                    if (b == true)
                    {
                        square[i - 1].GetComponent<Colors>().b = !square[i - 1].GetComponent<Colors>().b;
                    }

                    if (g == true)
                    {
                        square[i - 1].GetComponent<Colors>().g = !square[i - 1].GetComponent<Colors>().g;

                    }

                    if (gridSize == 9)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor3 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i - 1].GetComponent<Colors>().g = !square[i - 1].GetComponent<Colors>().g;
                                square[i - 1].GetComponent<Colors>().b = !square[i - 1].GetComponent<Colors>().b;
                                square[i - 1].GetComponent<Colors>().r = !square[i - 1].GetComponent<Colors>().r;
                            }
                        }
                    }
                    if (gridSize == 16)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor4 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i - 1].GetComponent<Colors>().g = !square[i - 1].GetComponent<Colors>().g;
                                square[i - 1].GetComponent<Colors>().b = !square[i - 1].GetComponent<Colors>().b;
                                square[i - 1].GetComponent<Colors>().r = !square[i - 1].GetComponent<Colors>().r;
                            }
                        }
                    }
                    if (gridSize == 25)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor5 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i - 1].GetComponent<Colors>().g = !square[i - 1].GetComponent<Colors>().g;
                                square[i - 1].GetComponent<Colors>().b = !square[i - 1].GetComponent<Colors>().b;
                                square[i - 1].GetComponent<Colors>().r = !square[i - 1].GetComponent<Colors>().r;
                            }
                        }
                    }
                    square[i - 1].GetComponent<Colors>().Invoke("SetColor", .1f);
                }


                //~~~~~~~~~~~~~~~~~


                if (doR == true && (i + 1 < gridSize))
                {
                    if (r == true)
                    {
                        square[i + 1].GetComponent<Colors>().r = !square[i + 1].GetComponent<Colors>().r;
                    }

                    if (b == true)
                    {
                        square[i + 1].GetComponent<Colors>().b = !square[i + 1].GetComponent<Colors>().b;
                    }

                    if (g == true)
                    {
                        square[i + 1].GetComponent<Colors>().g = !square[i + 1].GetComponent<Colors>().g;
                    }

                    if (gridSize == 9)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor3 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i + 1].GetComponent<Colors>().g = !square[i + 1].GetComponent<Colors>().g;
                                square[i + 1].GetComponent<Colors>().b = !square[i + 1].GetComponent<Colors>().b;
                                square[i + 1].GetComponent<Colors>().r = !square[i + 1].GetComponent<Colors>().r;
                            }
                        }
                    }
                    if (gridSize == 16)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor4 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i + 1].GetComponent<Colors>().g = !square[i + 1].GetComponent<Colors>().g;
                                square[i + 1].GetComponent<Colors>().b = !square[i + 1].GetComponent<Colors>().b;
                                square[i + 1].GetComponent<Colors>().r = !square[i + 1].GetComponent<Colors>().r;
                            }
                        }
                    }
                    if (gridSize == 25)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor5 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i + 1].GetComponent<Colors>().g = !square[i + 1].GetComponent<Colors>().g;
                                square[i + 1].GetComponent<Colors>().b = !square[i + 1].GetComponent<Colors>().b;
                                square[i + 1].GetComponent<Colors>().r = !square[i + 1].GetComponent<Colors>().r;
                            }
                        }
                    }
                    square[i + 1].GetComponent<Colors>().Invoke("SetColor", .1f);
                }
                //~~~~~~~~~~~~~~~~



                if (doU == true)
                {
                    if (r == true)
                    {
                        square[i -gs].GetComponent<Colors>().r = !square[i -gs].GetComponent<Colors>().r;
                    }

                    if (b == true)
                    {
                        square[i - gs].GetComponent<Colors>().b = !square[i - gs].GetComponent<Colors>().b;
                    }

                    if (g == true)
                    {
                        square[i - gs].GetComponent<Colors>().g = !square[i - gs].GetComponent<Colors>().g;
                    }

                    if (gridSize == 9)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor3 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i - gs].GetComponent<Colors>().g = !square[i - gs].GetComponent<Colors>().g;
                                square[i - gs].GetComponent<Colors>().b = !square[i - gs].GetComponent<Colors>().b;
                                square[i - gs].GetComponent<Colors>().r = !square[i - gs].GetComponent<Colors>().r;
                            }
                        }
                    }
                    if (gridSize == 16)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor4 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i - gs].GetComponent<Colors>().g = !square[i - gs].GetComponent<Colors>().g;
                                square[i - gs].GetComponent<Colors>().b = !square[i - gs].GetComponent<Colors>().b;
                                square[i - gs].GetComponent<Colors>().r  = !square[i - gs].GetComponent<Colors>().r;
                            }
                        }
                    }
                    if (gridSize == 25)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor5 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i - gs].GetComponent<Colors>().g = !square[i - gs].GetComponent<Colors>().g;
                                square[i - gs].GetComponent<Colors>().b = !square[i - gs].GetComponent<Colors>().b;
                                square[i - gs].GetComponent<Colors>().r  = !square[i - gs].GetComponent<Colors>().r;
                            }
                        }
                    }
                    square[i - gs].GetComponent<Colors>().Invoke("SetColor", .1f);
                }
                //~~~~~~~~~~~~~


                if (doD == true)
                {
                    if (r == true)
                    {
                        square[i + gs].GetComponent<Colors>().r = !square[i + gs].GetComponent<Colors>().r;
                    }

                    if (b == true)
                    {
                        square[i + gs].GetComponent<Colors>().b = !square[i + gs].GetComponent<Colors>().b;
                    }

                    if (g == true)
                    {
                        square[i + gs].GetComponent<Colors>().g = !square[i + gs].GetComponent<Colors>().g;
                    }
                    if (gridSize == 9)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor3 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i + gs].GetComponent<Colors>().g = !square[i + gs].GetComponent<Colors>().g;
                                square[i + gs].GetComponent<Colors>().b = !square[i + gs].GetComponent<Colors>().b;
                                square[i + gs].GetComponent<Colors>().r = !square[i + gs].GetComponent<Colors>().r;
                            }
                        }
                    }
                    if (gridSize == 16)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor4 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i + gs].GetComponent<Colors>().g = !square[i + gs].GetComponent<Colors>().g;
                                square[i + gs].GetComponent<Colors>().b = !square[i + gs].GetComponent<Colors>().b;
                                square[i + gs].GetComponent<Colors>().r = !square[i + gs].GetComponent<Colors>().r;
                            }
                        }
                    }
                    if (gridSize == 25)
                    {
                        if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor5 == 1)
                        {
                            if (r == false && g == false && b == false)
                            {
                                square[i + gs].GetComponent<Colors>().g = !square[i + gs].GetComponent<Colors>().g;
                                square[i + gs].GetComponent<Colors>().b = !square[i + gs].GetComponent<Colors>().b;
                                square[i + gs].GetComponent<Colors>().r = !square[i + gs].GetComponent<Colors>().r;
                            }
                        }
                    }
                    square[i + gs].GetComponent<Colors>().Invoke("SetColor", .1f);
                }
            }
        }

        //if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor == 0)
        //    { r = false; g = false; b = false; }
        if (gridSize == 9)
        {
            if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor3 == 0)
            { r = false; g = false; b = false; }
        }
        if (gridSize == 16)
        {
            if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor4 == 0)
            { r = false; g = false; b = false; }
        }
        if (gridSize == 25)
        {
            if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor5 == 0)
            { r = false; g = false; b = false; }
        }

        if (gridSize == 9)
            if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor3 == 1)
            { r = true; g = true; b = true; }
        if (gridSize == 16)
            if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor4 == 1)
            { r = true; g = true; b = true; }
        if (gridSize == 25)
            if (GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor5 == 1)
            { r = true; g = true; b = true; }

        Invoke("SetColor", .1f);

        if (gridSize == 9)
        {
            manager.GetComponent<Manager>().moves3++;
        }
        if (gridSize == 16)
        {
            manager.GetComponent<Manager>().moves4++;
        }
        if (gridSize == 25)
        {
            manager.GetComponent<Manager>().moves5++;
        }
        manager.GetComponent<Manager>().Invoke("UpdateText", .1f);
        manager.GetComponent<Manager>().CheckForSolve();
    }
}

//∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆∆


/*      if (r == true && g == false && b == false)
        { GetComponent<Image>().color = new Color(0.75f, 0.15f, 0.15f, 1f); }

        if (r == true && g == true && b == false)
        { GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.15f, 1f); }

        if (r == true && g == false && b == true)
        { GetComponent<Image>().color = new Color(0.75f, 0.15f, 0.75f, 1f); }

        if (r == false && g == true && b == false)
        { GetComponent<Image>().color = new Color(0.15f, 0.75f, 0.15f, 1f); }

        if (r == false && g == true && b == true)
        { GetComponent<Image>().color = new Color(0.15f, 0.75f, 0.75f, 1f); }

        if (r == false && g == false && b == true)
        { GetComponent<Image>().color = new Color(0.15f, 0.15f, 0.75f, 1f); }

        if (r == true && g == true && b == true)
        { GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f, 1f); }

        if (r == false && g == false && b == false)
        { GetComponent<Image>().color = new Color(0.15f, 0.15f, 0.15f, .75f); }

    */
