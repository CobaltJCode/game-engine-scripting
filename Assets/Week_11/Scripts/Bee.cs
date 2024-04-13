using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Week11
{
    public class Bee : MonoBehaviour
    {
        /// <summary>
        /// Arg1: Point value of the bee
        /// Arg2: The actual be object that was just killed
        /// Arg3: The name of the bee
        /// Arg4: Was his name Jeffrey?
        /// </summary>
        public static UnityEvent<int,Bee,string,bool> BeeKilledEvent = new UnityEvent<int, Bee, string, bool>();

        private void Start()
        {
            GameManager.AddGameOverEventListener(OnGameOver);
        }

        void OnGameOver()
        {
            int pointVal = Random.Range(1, 11);
            BeeKilledEvent.Invoke(pointVal, this, "Jerry Seinfeld", false);
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}