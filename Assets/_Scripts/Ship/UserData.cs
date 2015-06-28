using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class UserData
{
    private static UserData _instance = null;
    public static UserData Instance
    {
        get
        {
            if (_instance == null)
                Load();
            _instance.active[1] = true;
            return _instance;
        }
    }
    public int[] stars;
    public bool[] active;

    public UserData()
    {
        stars = new int[10];
        active = new bool[10];
        active[1] = true;
    }

    private static void Load()
    {
        //Đọc từ file ra
        string data = PlayerPrefs.GetString("data");
        if (data.Length < 3)
            _instance = new UserData();
        else
            _instance = JsonConvert.DeserializeObject<UserData>(data);
    }

    public void Save()
    {
        PlayerPrefs.SetString("data", JsonConvert.SerializeObject(Instance));
        MonoBehaviour.print("saved!");
    }

}
