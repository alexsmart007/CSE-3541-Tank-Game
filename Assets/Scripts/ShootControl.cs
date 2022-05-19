using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ContrerasAlex.Lab6
{
    public class ShootControl : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        public Rigidbody shell;
        public Transform fire;
        public AudioSource shootingAudio;
        public AudioClip fireClip;

        [SerializeField] private float currentLaunchForce;
        
        public void Shoot()
        {

            Vector3 bulletPosition = fire.transform.position + new Vector3(0f, 0f, 0f);
            Quaternion bulletRotation = player.transform.rotation;
            Rigidbody shellInstance = Instantiate(shell, bulletPosition, bulletRotation) as Rigidbody;
            shellInstance.velocity = currentLaunchForce * fire.forward;
            shootingAudio.clip = fireClip;
            shootingAudio.Play();
        }
    }
}
