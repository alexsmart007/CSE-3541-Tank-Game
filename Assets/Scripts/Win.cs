using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ContrerasAlex.Lab6
{
    public class Win : MonoBehaviour
    {
        [SerializeField] private GameObject winText;
        public static bool win;
        // Start is called before the first frame update
        void Start()
        {
            winText.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (win)
            {
                winText.SetActive(true);
            }
        }
    }
}
