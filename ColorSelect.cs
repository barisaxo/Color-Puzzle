using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// GO's "White Block" & "Black Block"


public class ColorSelect : MonoBehaviour
{

    public int colorObjective, colorObjective3, colorObjective4, colorObjective5;
    public Sprite white, black;

    //1 = W, 0 = Bl;

    public void SetObjectiveInManager()
    {
        //GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor = colorObjective;
        int gs = GameObject.Find("__Manager").GetComponent<Manager>().gridSize;

        if (gs == 9)
        {
            GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor3 = colorObjective3;
        }
        if (gs == 16)
        {
            GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor4 = colorObjective4;
        }
        if (gs == 25)
        {
            GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor5 = colorObjective5;
        }
    }



    public void SetColor()
    {
        if (GameObject.Find("__Manager").GetComponent<Manager>().gridSize == 9)
        {
            if (this.colorObjective3 == 1)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = white; }

            if (this.colorObjective3 == 0)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = black; }
        }


        if (GameObject.Find("__Manager").GetComponent<Manager>().gridSize == 16)
        {
            if (this.colorObjective4 == 1)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = white; }

            if (this.colorObjective4 == 0)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = black; }
        }

        if (GameObject.Find("__Manager").GetComponent<Manager>().gridSize == 25)
        {
            if (this.colorObjective5 == 1)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = white; }

            if (this.colorObjective5 == 0)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = black; }
        }


        //if (this.colorObjective == 1)
        //{ GameObject.Find("Color Select Button").GetComponent<Image>().sprite = white; }

        //if (this.colorObjective == 0)
        //{ GameObject.Find("Color Select Button").GetComponent<Image>().sprite = black; }
    }


    public void SetCOIndicator()
    {
        int gs = GameObject.Find("__Manager").GetComponent<Manager>().gridSize;
        int CO3 = GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor3;
        int CO4 = GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor4;
        int CO5 = GameObject.Find("__Manager").GetComponent<Manager>().objectiveColor5;


        if (gs == 9)
        {
            if (CO3 == 1)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = white; }

            if (CO3 == 0)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = black; }
        }


        if (gs == 16)
        {
            if (CO4 == 1)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = white; }

            if (CO4 == 0)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = black; }
        }

        if (gs == 25)
        {
            if (CO5 == 1)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = white; }

            if (CO5 == 0)
            { GameObject.Find("Color Select Button").GetComponent<Image>().sprite = black; }
        }
    }
}


