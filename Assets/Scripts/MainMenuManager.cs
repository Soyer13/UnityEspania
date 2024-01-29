using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void loadGame(int ID)
    {
        SceneManager.LoadScene(ID);
    }


    public void SaveValue(string UsernameInput)
    {
        PlayerPrefs.SetString("UserName", UsernameInput); 
    }

    public void LoadValue()
    {
        
        string playername = PlayerPrefs.GetString("UserName");
        PlayerName.text = playername;        
    }
}
