using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableThisAfterStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


 public   void Disabler()
    {

        {
            int gs = GameObject.Find("__Manager").GetComponent<Manager>().gridSize;
            int ms = (int)Mathf.Sqrt(this.gameObject.GetComponent<GridSizeSub>().setGridSizeTo);
            if (gs != ms)
                this.gameObject.SetActive(false);
        }
    }
}
