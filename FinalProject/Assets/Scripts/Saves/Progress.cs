using System;
using UnityEngine;

[Serializable]
public class GameInfo
{
    public uint LevelsPassed = 0;
    public uint Coins = 0;
    public uint BulletPowerLevel = 1;
    public uint HpLevel = 1;
}

public class Progress : MonoBehaviour
{

    
    private static Progress _instance;

    public static Progress GetInstance()
    {
        return _instance;
    }
    public GameInfo Info;

    private void Awake()
    {
        
        if (_instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            _instance = this;
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string jsonEncoded = JsonUtility.ToJson(Info);
        PlayerPrefs.SetString("save", jsonEncoded);
    }

    private void Load()
    {
        string jsonEncoded = PlayerPrefs.GetString("save");
        if (string.IsNullOrEmpty(jsonEncoded))
        {
            Info = new GameInfo();
            return;
        }
        Info = JsonUtility.FromJson<GameInfo>(jsonEncoded);
    }

}
