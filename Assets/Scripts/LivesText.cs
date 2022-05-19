using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ContrerasAlex.Lab6
{
    public class LivesText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        // Start is called before the first frame update
        void Start()
        {
            text.text = "Lives: " + GenerateLevel.lives;
        }

        // Update is called once per frame
        void Update()
        {
            text.text = "Lives: " + GenerateLevel.lives;
        }
    }
}
