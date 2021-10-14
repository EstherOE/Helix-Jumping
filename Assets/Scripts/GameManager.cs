
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{

    public static bool gameOver;
    public static bool levelCompleted;
    public static bool isGameStarted = false;
    public static bool mute = false;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePanel;
    public GameObject startPanel;
    public Slider objSlid;


    public TextMeshProUGUI currentLvelText;  
    public TextMeshProUGUI nextLvelText;

    
    public int best;
    public int score;
    public static int numberPassofRings;
    public int currentLevelIndex;
  
    public static GameManager singleton;
   
    HelixManager helixManager;
    


    private void Awake()


    {
       
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);
        best = PlayerPrefs.GetInt("HighScore");
       
            currentLevelIndex = PlayerPrefs.GetInt("currentLevelIndex", 1);
        
        
        PlayerPrefs.DeleteKey("currentLevelIndex");
        
    }
    // Start is called before the first frame update
    void Start()
    {

        helixManager = FindObjectOfType<HelixManager>();
        Time.timeScale = 1;
       isGameStarted= gameOver = levelCompleted=false;
        gameOverPanel.SetActive(false);
        numberPassofRings = 0;
        Admanager.instance.RequestInter();
      
    }

    // Update is called once per frame
    void Update()
    {

        //update our half UI

        currentLvelText.text = currentLevelIndex.ToString();
        nextLvelText.text = (currentLevelIndex + 1).ToString();
        int progress = numberPassofRings * 100 / FindObjectOfType<HelixManager>().numberofRings;
        objSlid.value = progress;
        //Pc
        if(Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            isGameStarted = true;
            gamePanel.SetActive(true);
            startPanel.SetActive(false);
        }

        //Mobile
        if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
            isGameStarted = true;
            gamePanel.SetActive(true);
            startPanel.SetActive(false);
        }

        // gameOver
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            
            if (Input.GetButtonDown("Fire1"))
            {
                singleton.score = 0;
                SceneManager.LoadScene(1);
            }

            if (Random.RandomRange(0, 3) == 0)
            {
                Admanager.instance.showInter();
            }
        }
        // level Completed
        if(levelCompleted)
        {

            levelCompletedPanel.SetActive(true);
            if(Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("currentLevelIndex", 1+currentLevelIndex);
              
                SceneManager.LoadScene(1);

            }
        }
    }


    public void addScoreInt(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
