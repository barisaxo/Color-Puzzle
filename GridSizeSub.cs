using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSizeSub : MonoBehaviour
{

    public int setGridSizeTo;
    // Start is called before the first frame update

public void Shiclacky()
    {
        GameObject.Find("__Manager").GetComponent<Manager>().gridSize = setGridSizeTo;
      //  GameObject.Find("__Manager").GetComponent<Manager>().newSizeSet = false;
        GameObject.Find("GB" + Mathf.Sqrt(setGridSizeTo)).GetComponent<Button>().onClick.Invoke();
        // GameObject.Find("__Manager").GetComponent<Manager>().SetUpOld();
        GameObject.Find("__Manager").GetComponent<Manager>().SaveGame();
    }
}
