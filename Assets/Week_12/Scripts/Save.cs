using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Save : MonoBehaviour
{
    public int score;
    public string username;
    public float balance
    {
        get
        {
            return _balance;
        }
        set
        {
            _balance = value;
            PlayerPrefs.SetFloat("balance", _balance);
        }
    }
    private float _balance;

    public Data data;


    [ContextMenu("Do Save")]
   public void SavaDataTest()
   {

        PlayerPrefs.SetInt("score",  score);
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetFloat("balance", balance);

        string position = string.Format("{0} {1} {2}",transform.position.x,transform.position.y,transform.position.z);
        PlayerPrefs.SetString("position", position);

        PlayerPrefs.SetFloat("position-x", transform.position.x);
        PlayerPrefs.SetFloat("position-y", transform.position.y);
        PlayerPrefs.SetFloat("position-z", transform.position.z);


        data.score = score;
        data.username = username;
        data.balance = balance;
        data.position = transform.position;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        PlayerPrefs.SetString("data", json);
   }




}
