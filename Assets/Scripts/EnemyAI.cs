using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ContrerasAlex.Lab6
{
    public class EnemyAI : MonoBehaviour
    {
        bool playerFound =false;
        private GameObject lastHit;
        private Vector3 playerLocation = Vector3.zero;
        private Vector3 collision = Vector3.zero;
        private GameObject player;
        public Rigidbody shell;
        private Transform fire;
        private float currentLaunchForce;
        public AudioSource shootingAudio;
        public AudioClip fireClip;

        // Start is called before the first frame update
        void Start()
        {
            currentLaunchForce = 10f;
            GameObject test = new GameObject();
            fire = test.transform;
            fire.transform.parent = this.gameObject.transform;
            fire.transform.position = this.gameObject.transform.position + new Vector3(0f, 1.7f, 1.35f);
            fire.transform.rotation = this.gameObject.transform.rotation;
        }

        // Update is called once per frame
        void Update()
        {
                float degrees = 0;
                var ray = new Ray(origin: this.gameObject.transform.position, direction: this.gameObject.transform.forward + Vector3.Scale(this.gameObject.transform.right, new Vector3(degrees, 0, 0)));
                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction * 25f, Color.red);
                if (Physics.Raycast(ray, out hit, maxDistance: 25f))
                {
                    lastHit = hit.transform.gameObject;
                    collision = hit.point;
                    if (lastHit.CompareTag("Player"))
                    {
                        playerFound = true;
                        playerLocation = collision;
                        player = lastHit;

                    }
                }
            if (playerFound)
            {
                var newDirection = Quaternion.LookRotation(playerLocation - this.gameObject.transform.position);
                this.gameObject.transform.rotation = newDirection;
                if (ShellExplosionEnemy.destoryed == 0)
                {
                    Shoot();
                }
                playerFound = false;
            }
            else
            {
                this.gameObject.transform.Rotate(new Vector3(0,0.5f,0));
            }

        }

        public void Shoot()
        {
            ShellExplosionEnemy.destoryed++;
            Vector3 bulletPosition = fire.transform.position;
            Quaternion bulletRotation = gameObject.transform.rotation;
            Rigidbody shellInstance = Instantiate(shell, bulletPosition, bulletRotation) as Rigidbody;
            shellInstance.velocity = currentLaunchForce * fire.forward;
            shootingAudio.clip = fireClip;
            shootingAudio.Play();
        }
    }
}
