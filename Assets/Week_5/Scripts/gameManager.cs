using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class gameManager : MonoBehaviour
{
    private static gameManager instance;

    public UnityEvent GameOverEvent;
    public static UnityEvent RestartGameEvent = new UnityEvent();

    public TextMeshProUGUI healthBar;
    public GameObject keyImage;
    public GameObject GameOverScreen;
    public GameObject Player;
    public GameObject Key;

    

    private Rigidbody rb;
    private int count;
    public static int health = 100;

    public Vector3 starting_Position;

    public static void dealDamage() 
    { 
        health -= 50;
        if (health <= 0)
        {
            instance.GameOver();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
        instance = this;
        rb = GetComponent<Rigidbody>();
        starting_Position = rb.position;
        count = 0;

        SetCountText();
        keyImage.SetActive(false);
        GameOverScreen.SetActive(false);
    }

    void SetCountText()
    {
        if (count == 1)
        {
            keyImage.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            GameOver();
        }

    }

    void GameOver()
    {
        GameOverEvent.Invoke();
        GameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        RestartGameEvent.Invoke();
        GameOverScreen.SetActive(false);
        count = 0;
        keyImage.SetActive(false);
        Key.SetActive(true);
        health = 100;
        healthBar.text = string.Format("Health: {0}%",health);
        rb.position = starting_Position;
        

    }


}
    
