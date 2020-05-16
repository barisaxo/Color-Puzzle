using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  GO "HelpB"

public class Count : MonoBehaviour
{

    public int count;

public void Counting()
    {
        count++;
        if (count >= 5)
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
}