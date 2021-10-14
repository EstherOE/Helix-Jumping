using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xterSelector : MonoBehaviour
{

    public GameObject[] xters;
    int xterInt =0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject xter in xters)
        {
            xter.SetActive(false);
        }

        xters[xterInt].SetActive(true);
    }

    public void Changexter(int newxter)
    {
        xters[xterInt].SetActive(false);
        xters[newxter].SetActive(true);

        xterInt = newxter;
    }
}
