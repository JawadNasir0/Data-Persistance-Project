using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI nameText;
    public string name;
    
    void Awake()
    {   LoadBestScore();
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance =this;
        DontDestroyOnLoad(gameObject);
    }
    public void StartGame()
    {
        name =nameText.text;
        SceneManager.LoadScene(1);
    }
    void LoadBestScore()
    {
        string path = Application.persistentDataPath +"/savefile.json";
        if(File.Exists(path))
         {
             string json =File.ReadAllText(path);
             MainManager.SaveData data = JsonUtility.FromJson<MainManager.SaveData>(json);
             bestScoreText.text = "BestScore: "+ data.bestScoreName +" : "+data.bestScore;
         }
    }
}
