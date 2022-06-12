using UnityEngine;
using UnityEngine.InputSystem;

namespace Scrips
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;

        private PlayerInput _playerInput;

        private void Awake()
        {
            //_playerInput = new PlayerInput();
        }

        public void OnPrimaryContact(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _playerController.SwipeCheck(true);
                //Debug.Log($"context.performed: {context.performed}");
            }

            if (context.canceled)
            {
                _playerController.SwipeCheck(false);
                //Debug.Log($"context.canceled: {context.canceled}");
            }
                
        }

        public void OnVector(InputAction.CallbackContext context)
        {
            if(context.performed)
                _playerController.SetPosition(context.ReadValue<Vector2>());    
            //Debug.Log($"Vector: {context.ReadValue<Vector2>().normalized.x} {context.ReadValue<Vector2>().normalized.y}");
        }
    }
}