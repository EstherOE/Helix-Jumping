using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
  [SerializeField]private TextMeshProUGUI scoreText;
   [SerializeField] private TextMeshProUGUI highScoreText;

    int dscore;
    // Update is called once per frame
    void Update()
    {
         scoreText.text = "Score: " + GameManager.singleton.score;
        highScoreText.text = "Highscore: " + GameManager.singleton.best;
    }

    
}
