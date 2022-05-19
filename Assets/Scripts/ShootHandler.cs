using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ContrerasAlex.Lab6
{
    public class ShootHandler
    {
        ShootControl shootController;
        public ShootHandler(InputAction shootAction, ShootControl shootController)
        {
            shootAction.performed += ShootAction_performed;
            shootAction.Enable();
            this.shootController = shootController;
        }

        private void ShootAction_performed(InputAction.CallbackContext obj)
        {
            shootController.Shoot();

        }
    }
}

