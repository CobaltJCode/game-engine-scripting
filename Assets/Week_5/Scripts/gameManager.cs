using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public TextMeshProUGUI healthBar;
    public GameObject keyImage;

    private Rigidbody rb;
    private int count;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        keyImage.SetActive(false);
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

    }

}
    
