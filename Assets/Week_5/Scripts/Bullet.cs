using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Bullet : MonoBehaviour
{
    [SerializeField] float m_Speed;

    Vector3 m_Position;

    [SerializeField] private TextMeshProUGUI healthBar;


    private void Awake()
    {
        gameManager.RestartGameEvent.AddListener(Reset);
        m_Position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * m_Speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            gameObject.SetActive(false);
            gameManager.dealDamage();
            healthBar.text = string.Format("Health: {0}%", gameManager.health);
        }
        

    }

    private void Reset()
    {
        gameObject.SetActive(true);
        transform.position = m_Position;
        healthBar.text = string.Format("Health: {0}%", gameManager.health);
        
    }


}
