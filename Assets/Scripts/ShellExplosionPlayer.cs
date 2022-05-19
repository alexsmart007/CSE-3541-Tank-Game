using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ContrerasAlex.Lab6
{
    public class ShellExplosionPlayer : MonoBehaviour
    {
        public ParticleSystem explosionParticles;
        public AudioSource explosionAudio;
        public AudioSource roundAudio;
        public AudioClip bounceClip;
        public AudioClip explodeClip;
        public AudioClip walkClip;
        public AudioClip victoryClip;
        public AudioClip defeatClip;
        public LayerMask tankMask;
        public float explosionRadius = 5f;
        public bool bounced = false;
        public static int destoryed = 0;

        [SerializeField] private float bouncedForce;


        [System.Obsolete]
        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Tank"))
            {
                explosionParticles.Play();
                explosionAudio.clip = explodeClip;
                explosionAudio.Play();
                Destroy(other.gameObject);
                Destroy(explosionParticles.gameObject, explosionParticles.duration);
                Destroy(this.gameObject, 0.15f);
                bounced = false;
                destoryed--;
                GenerateLevel.numOfTanks--;
            }
            else if(other.gameObject.CompareTag("Player") && bounced)
            {
                explosionParticles.Play();
                explosionAudio.clip = explodeClip;
                explosionAudio.Play();
                Destroy(other.gameObject);
                Destroy(explosionParticles.gameObject, explosionParticles.duration);
                Destroy(this.gameObject, 0.15f);
                bounced = false;
                GameOver.playerAlive = false;
                destoryed--;
            }
            else if((other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("HoriWall")) && bounced)
            {
                explosionParticles.Play();
                explosionAudio.clip = explodeClip;
                explosionAudio.Play();
                Destroy(explosionParticles.gameObject, explosionParticles.duration);
                Destroy(this.gameObject, 0.15f);
                bounced = false;
                destoryed--;
            }
            else if(other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("HoriWall"))
            {
                if (other.gameObject.CompareTag("HoriWall")){
                    this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0) - gameObject.transform.rotation.eulerAngles);
                }
                else
                {
                    this.gameObject.transform.rotation = Quaternion.Euler(-gameObject.transform.rotation.eulerAngles);
                }                   
                this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * bouncedForce;
                explosionAudio.clip = bounceClip;
                explosionAudio.Play();
                bounced = true;
            }
            
        }
    }
}
