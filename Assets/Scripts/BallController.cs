using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{ 
    //Properties...
    public float force = 100.0f;
    private Rigidbody ballRB;
  
    private Vector3 startPos;
    GameManager manager;

    private AudioManager audio;
    private void Awake()
    {
        startPos = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        manager = FindObjectOfType<GameManager>();
        audio = FindObjectOfType<AudioManager>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        audio.Play("bounce");
        ballRB.velocity = Vector3.zero;
        ballRB.AddForce(Vector3.up * force, ForceMode.Impulse);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        
        if(materialName =="Safe (Instance)")
        {
           manager.addScoreInt(1);
            // The ball 
        }

        else if(materialName == "Unsafe (Instance)")
        {
            GameManager.gameOver = true;


            audio.Play("gameover");
        }

        else if(materialName =="LastRing (Instance)" && !GameManager.levelCompleted)
        {
            
            GameManager.levelCompleted = true;

            audio.Play("winlevel");
        }
    }

}
