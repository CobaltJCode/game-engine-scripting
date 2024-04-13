using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public int score;
    public string username;
    public float balance;

    public Data data;


    [ContextMenu("Do Load")]
    public void LoadDataTest()
    {
        PlayerPrefs.GetInt("score", 10000);
        PlayerPrefs.GetString("username");
        PlayerPrefs.GetFloat("balance");

        PlayerPrefs.GetFloat("position-x");
        PlayerPrefs.GetFloat("position-y");
        PlayerPrefs.GetFloat("position-z");

        //transform.position = new Vector3(x, y, z);

        string positionString = PlayerPrefs.GetString("position", "0 0 0");
        //
        string[] axis = positionString.Split(' ');
        transform.position = new Vector3(float.Parse(axis[0]), float.Parse(axis[1]), float.Parse(axis[2]));

        data = JsonUtility.FromJson<Data>(PlayerPrefs.GetString("data"));
    }
}
