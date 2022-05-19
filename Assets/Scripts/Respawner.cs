using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ContrerasAlex.Lab6
{
    public class Respawner : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private Vector3 initialPosition;
        private Quaternion initialRotation;

        void Start()
        {
            this.initialPosition = player.transform.position;
            this.initialRotation = player.transform.rotation;
        }
        public void Respawn()
        {
            player.transform.position = this.initialPosition;
            player.transform.rotation = this.initialRotation;
        }
    }
}
