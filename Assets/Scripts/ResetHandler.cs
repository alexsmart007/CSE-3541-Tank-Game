using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ContrerasAlex.Lab6
{
    public class ResetHandler
    {
        private Respawner respawner;

        public ResetHandler(InputAction resetAction, Respawner respawner)
        {
            resetAction.performed += ResetAction_performed;
            resetAction.Enable();
            this.respawner = respawner;
        }

        private void ResetAction_performed(InputAction.CallbackContext obj)
        {
            this.respawner.Respawn();
        }
    }
}
