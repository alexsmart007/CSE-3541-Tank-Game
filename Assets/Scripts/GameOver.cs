using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ContrerasAlex.Lab6
{
    public class GameOver : MonoBehaviour
    {
        public static bool playerAlive;
        [SerializeField] private GameObject gameoverText;
        [SerializeField] private GameObject player;
        private GameObject playerCopy;
        private Vector3 initialPosition;
        private Quaternion initialRotation;
        public AudioSource loseRound;
        public AudioSource backgroundRound;
        public AudioClip loseClip;
        private bool playOnce = true;
        // Start is called before the first frame update
        void Start()
        {
            gameoverText.SetActive(false);
            playerAlive = true;
            this.initialPosition = player.transform.position;
            this.initialRotation = player.transform.rotation;
        }

        // Update is called once per frame
        void Update()
        {
            if (!playerAlive)
            {
                GenerateLevel.lives--;
                if(GenerateLevel.lives == 0)
                {
                    LoadGameOver();
                }
                else
                {
                    playerAlive = true;
                    playerCopy = Instantiate(player, this.initialPosition, Quaternion.identity);
                }
            }
        }

        public void LoadGameOver()
        {
            gameoverText.SetActive(true);
            if (playOnce && loseRound != null)
            {
                loseRound = Instantiate(loseRound);
                loseRound.enabled = true;
                loseRound.clip = loseClip;
                loseRound.Play();
                backgroundRound.Stop();
                playOnce = false;
            }
        }
    }
  }
