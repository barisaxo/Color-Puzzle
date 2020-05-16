using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for BG images and Blocks when they explode (still works with round blocks because the 2d box colider will push them apart in random ways)


public class Rotate : MonoBehaviour
{
    float r;
    public float min, max;

    void Start()
    {
        r = Random.Range(min, max);

        transform.Rotate(0, 0, Random.Range(-1800f, 180f));
    }


    void FixedUpdate()
    {
        transform.Rotate(0, 0, r * Time.fixedDeltaTime);
    }

    //used to help make the puzzle 'explode' after being solved.
    public void RotateAgain()
    {
        transform.Rotate(0, 0, Random.Range(-180f, 180f));
    }
}
