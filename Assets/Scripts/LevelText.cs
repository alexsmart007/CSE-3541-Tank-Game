using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ContrerasAlex.Lab6
{
    public class LevelText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        // Start is called before the first frame update
        void Start()
        {
            text.text = "Level " + (GenerateLevel.level-1) + " Complete!";
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
