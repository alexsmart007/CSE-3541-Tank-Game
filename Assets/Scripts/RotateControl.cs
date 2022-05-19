using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ContrerasAlex.Lab6
{
    public class RotateControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerToRotate;
        [SerializeField] private float speed = 100f;
        private InputAction rotateAction;

        public void Initialize(InputAction rotateAction)
        {
            this.rotateAction = rotateAction;
            this.rotateAction.Enable();
        }
        private void FixedUpdate()
        {
            float x = this.rotateAction.ReadValue<Vector2>().x;
            var rotateVector = new Vector3(0f, x, 0f) * (speed * Time.deltaTime);
            rotateVector = playerToRotate.transform.TransformDirection(rotateVector);
            Quaternion rotateQuaternion = Quaternion.Euler(rotateVector);
            playerToRotate.MoveRotation(Quaternion.RotateTowards(playerToRotate.rotation, playerToRotate.rotation * rotateQuaternion, speed));
        }
    }
}
