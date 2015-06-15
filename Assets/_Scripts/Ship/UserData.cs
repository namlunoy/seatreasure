using UnityEngine;
using System.Collections;

public class UserData  {
    private static UserData _instance;
    public static UserData Instance
    {
        get {
            if (_instance == null)
                _instance = new UserData();
            return _instance;
        }
    }

    private UserData()
    {
        //Lấy các thứ ra
       // string s = JsonConvert.SerializeObject(new UserData());
    }
}
