using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    [SerializeField] float m_Speed;

    private int health = 100;

    [SerializeField] private TextMeshProUGUI healthBar;


    private void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * m_Speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        health--;
        healthBar.text = string.Format("Health: {100%}", health);

    }
}
