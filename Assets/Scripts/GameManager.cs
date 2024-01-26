using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float FinishTime;
    [SerializeField] TextMeshProUGUI Timmer;
    [SerializeField] TextMeshProUGUI EndGameComunicat;
    [SerializeField] GameObject Coin;

    //public Transform[] coinPosition;

    private float time = 0;
    private int inttime;
    bool isGameFinished = false;
    public int CoinsColleted = 0;

    GameObject[] allCoins;

    public static GameManager instance;
    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;

    }
    void Start()
    {
         //allCoins = GameObject.FindGameObjectsWithTag("COIN");
        allCoins = GameObject.FindGameObjectsWithTag("spawnpos");
        loadCoins();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameFinished == false)
        {
            if(time < FinishTime)
            {
                time = time + Time.deltaTime ;
                inttime = (int)time;
                Timmer.text = inttime.ToString();    
            }
        
            if(time >= FinishTime) {
                Time.timeScale = 0;
                EndGameComunicat.text = "you lose";
                UiManager.instance.Resstarbuton.SetActive(true);
            }
        }
        
        if(CoinsColleted == allCoins.Length)
        {
            EndGameComunicat.text = "you win";
            isGameFinished = true;
            UiManager.instance.Resstarbuton.SetActive(true);
        }
    }

    public void ReloadLevel()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
        
    }

    void loadCoins()
    {
        for(int i = 0; i < allCoins.Length; i++)
        {
            
            Instantiate(Coin, allCoins[i].transform.position, Quaternion.identity);
        }
    }
}
