using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ContrerasAlex.Lab6
{
    public class GenerateLevel : MonoBehaviour
    {
        public static int level = 0;
        public static int lives = 3;
        public static int numOfTanks;
        [SerializeField] private GameObject enemyTank;
        public List<GameObject> tankSpawnPoints = new List<GameObject>();

        // Start is called before the first frame update
        void Awake()
        {
            level++;
            numOfTanks = Random.Range(level, level+1);
            for(int i = 1; i <= numOfTanks; i++)
            {
                GameObject goToSpawn = tankSpawnPoints[tankSpawnPoints.Count-i];
                Instantiate(enemyTank, goToSpawn.transform.position, Quaternion.identity);
            }
        }
    }
}
