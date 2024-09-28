using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string PlayerNameCur;
    public string PlayerNameHs;
    public int PlayerScoreHs;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


    }

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SavePlayerData
    {
        public string PlayerName;
        public int PlayerScore;
    }

    public void SavePlayerName()
    {
        
        Debug.Log("SavePlayerName()" + PlayerNameHs + PlayerScoreHs);
        SavePlayerData playerData = new SavePlayerData();
        playerData.PlayerName = PlayerNameHs;
        playerData.PlayerScore = PlayerScoreHs;

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavePlayerData playerData = JsonUtility.FromJson<SavePlayerData>(json);

            PlayerNameHs = playerData.PlayerName;
            PlayerScoreHs = playerData.PlayerScore;
        }
        else
        {
            Debug.Log("LoadPlayerName() - No file, setting temp PlayerName and score to 0");
            PlayerNameHs = "PlayerName";
            PlayerScoreHs = 0;
        }
    }
}
