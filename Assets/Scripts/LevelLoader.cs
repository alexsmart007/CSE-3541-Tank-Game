using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ContrerasAlex.Lab6
{
    public class LevelLoader : MonoBehaviour
    {
        public Animator transition;
        public static int numOfTanks;
        public GameObject musicRound;
        public AudioSource winRound;
        public AudioSource backgroundRound;
        public AudioClip winClip;
        private bool playOnce = true;

        [SerializeField] private float transitionTime;

        // Update is called once per frame
        void Update()
        {
            if(GenerateLevel.numOfTanks == 0)
            {
                LoadNextLevel();
            }

        }

        public void LoadNextLevel()
        {
            if(GenerateLevel.level != 11)
            {
                StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex + 1)));
            }
            else
            {
                Win.win = true;
            }
        }

        IEnumerator LoadLevel(int levelIndex)
        {

            //Play Animation
            transition.SetTrigger("Start");
            if(playOnce && musicRound != null)
            {
                winRound = Instantiate(winRound);
                winRound.enabled = true;
                winRound.clip = winClip;
                winRound.Play();
                backgroundRound.Stop();
                playOnce = false;
            }
            //Wait
            yield return new WaitForSeconds(transitionTime);
            //Load Scene
            backgroundRound.Play();
            SceneManager.LoadScene(levelIndex);
        }
    }
}
