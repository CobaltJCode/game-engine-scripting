using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Week11
{

    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        public UnityEvent GameOverEvent;

        private int score;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            Bee.BeeKilledEvent.AddListener(OnBeeKilled);
        }

        [ContextMenu("Test GameOver Event")]
        void GameOver()
        {
            GameOverEvent.Invoke();
        }

        void OnBeeKilled(int score, Bee bee, string name, bool isJeffrey)
        {
            this.score += score;
            Debug.Log(this.score);
        }

        public static void AddGameOverEventListener(UnityAction action)
        {
            instance.GameOverEvent.AddListener(action);
        }
    }
}