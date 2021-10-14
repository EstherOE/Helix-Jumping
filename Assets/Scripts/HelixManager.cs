using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{

    public GameObject[] helixObjects;
    public float ySpawn = 0;

    public float yDecreases;
    // Start is called before the first frame update



    public int numberofRings;
    void Start()
    {
        numberofRings = GameManager.singleton.currentLevelIndex + 6;
        //Spawn Helix Ring

        for (int i = 0; i < numberofRings; i++)
        {
           
                SpawnRing(Random.Range(0, helixObjects.Length - 1));
            
        }


        //Spawn the Last Ring

        SpawnRing(helixObjects.Length - 1);
    }

   

    public void SpawnRing(int ringIndex)
    {

        GameObject obj =Instantiate(helixObjects[ringIndex], transform.up *ySpawn, Quaternion.identity);
        obj.transform.parent= transform;

        ySpawn -= yDecreases;

    }

}
