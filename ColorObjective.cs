using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// GO "ObjectiveB"

public class ColorObjective : MonoBehaviour
{

    private void Start()
    {
      //  bool done = GameObject.Find("__Manager").GetComponent<Manager>().oBD;
      //  bool Done = // MAKE A BOOL IN THE MANAGER AND ONCE THIS TASK IS COMPLETED
            //               SAVE IT WITH PLAYERPREFS SO THIS ONLY HAPPENS ONE TIME

    }


    public void CheckForSolved()
    {
        var co = GameObject.Find("__Manager").GetComponent<Manager>().best3;
        if (co <= 33 && co != 0)
        { this.GetComponent<Button>().onClick.Invoke(); }
    }



    public void CheckForSolvedTwo()
    {
        if (GameObject.Find("__Manager").GetComponent<Manager>().oBD == true)
        { return; }
        Invoke("Checking", 2.5f);
        GameObject.Find("__Manager").GetComponent<Manager>().oBD = true;
        GameObject.Find("__Manager").GetComponent<Manager>().SaveGame();
    }



        void Checking()
    {
        GameObject.Find("Menu Button").GetComponent<Button>().onClick.Invoke();
        var co = GameObject.Find("__Manager").GetComponent<Manager>().best3;
        if (co <= 33 && co != 0)
        { this.GetComponent<Button>().onClick.Invoke(); }
    }
}
