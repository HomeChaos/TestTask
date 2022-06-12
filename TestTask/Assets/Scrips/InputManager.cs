using UnityEngine;
using UnityEngine.InputSystem;

namespace Scrips
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;

        public void OnPrimaryContact(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _playerController.SwipeCheck(true);
            }

            if (context.canceled)
            {
                _playerController.SwipeCheck(false);
            }
        }

        public void OnVector(InputAction.CallbackContext context)
        {
            if (context.performed)
                _playerController.SetPosition(context.ReadValue<Vector2>());
        }
    }
}