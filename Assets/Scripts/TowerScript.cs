using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{

    public float speed=150;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGameStarted)
            return;
        //PC
        if(Input.GetMouseButton(0))
        {
            float mousex = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, -mousex * speed* Time.deltaTime, 0);
        }



        //mobile
        if(Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Moved)
        {
            float xDelta = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0, -xDelta * speed * Time.deltaTime, 0);
        }

    }
}
