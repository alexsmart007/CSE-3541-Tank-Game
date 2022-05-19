using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ContrerasAlex.Lab6
{
    public class MovementControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerToMove;
        [SerializeField] private float speed = 2.5f;
        private InputAction moveAction;
        public AudioSource moveAudio;
        public AudioClip moveClip;
        public GameObject musicRound;
        private bool playOnce = true;

        [SerializeField] private float time;
        public void Initialize(InputAction moveAction)
        {
            this.moveAction = moveAction;
            this.moveAction.Enable();
            moveAudio = Instantiate(moveAudio);
            moveAudio.enabled = true;
            moveAudio.clip = moveClip;
        }
        private void FixedUpdate()
        {
            float x = this.moveAction.ReadValue<Vector2>().x;
            float z = this.moveAction.ReadValue<Vector2>().y;
            
            var moveVector = new Vector3(x, 0f, z) * (speed * Time.deltaTime);
            moveVector = playerToMove.transform.TransformDirection(moveVector);
            playerToMove.MovePosition(Vector3.MoveTowards(playerToMove.position, playerToMove.position + moveVector, speed));
 
            if ( (x!=0 || z != 0) && playOnce)
            {
                moveAudio.Play();
                playOnce = false;
            }
            else
            {
                moveAudio.Stop();
                playOnce=true;
            }
        }
    }
}
