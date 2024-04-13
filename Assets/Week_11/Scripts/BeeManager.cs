using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week11
{

    public class BeeManager : MonoBehaviour
    {
        [SerializeField] GameObject beeTemplate;

        // Start is called before the first frame update
        void Start()
        {
            for(int i = 0; i < 25; i++)
            {
                GameObject bee = Instantiate(beeTemplate);
                bee.transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            }
        }
    }
}