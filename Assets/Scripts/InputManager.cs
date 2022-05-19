using ContrerasAlex.Lab6;
using ContrerasAlex.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ContrerasAlex.Lab6
{ 
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private MovementControl movementController;
        [SerializeField] private RotateControl rotateController;
        [SerializeField] private ShootControl shootController;
        [SerializeField] private Respawner respawner;
        private ShootHandler shootHandler;
        private ResetHandler resetHandler;
        private PlayerInputActions inputScheme;

        private void Awake()
        {
            inputScheme = new PlayerInputActions();
            movementController.Initialize(inputScheme.Player.Move);
            rotateController.Initialize(inputScheme.Player.Rotate);
            shootHandler = new ShootHandler(inputScheme.Player.Shoot, shootController);
            resetHandler = new ResetHandler(inputScheme.Player.Restart, respawner);

        }
        private void OnEnable()
        {
            var _ = new QuitHandler(inputScheme.Player.Quit);
        }
    }

}


