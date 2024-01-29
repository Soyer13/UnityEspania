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
    public GameObject Player;
    public Transform PlayerCameraPosition;

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
        loadPlayerPositoion();
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

    public IEnumerator CourutineTest()
    {
        yield return new WaitForSeconds(1);
        /*while (true)
        {
            yield return null;
        }*/
    }

    public void savePlayerPosition()
    {
        PlayerPrefs.SetFloat("PlayerX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", Player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", Player.transform.position.z);
        PlayerPrefs.Save();
        Debug.Log(Player.transform.position.x + " , " + Player.transform.position.y + " , " + Player.transform.position.z);
    }
    public void loadPlayerPositoion()
    {
        float PlayerX = PlayerPrefs.GetFloat("PlayerX");
        float PlayerY = PlayerPrefs.GetFloat("PlayerY");
        float PlayerZ = PlayerPrefs.GetFloat("PlayerZ");
        Debug.Log(PlayerX+ " "+ PlayerY + " " + PlayerZ);
        //Player.transform.position = new Vector3(PlayerX, PlayerY, PlayerZ);
        Player.transform.SetPositionAndRotation(new Vector3(PlayerX, PlayerY, PlayerZ), Quaternion.identity);
    }
}
