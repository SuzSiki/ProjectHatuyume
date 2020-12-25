using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour, InputActions.IPlayerActions
{
    InputActions input;

    void Awake()
    {
        input = new InputActions();
        input.Player.SetCallbacks(this);
    }

    
    public void OnTalknext(InputAction.CallbackContext context)
    {
        
    }

    void OnEnable()
    {
        Debug.Log("enabled");
        input.Enable();
    }
    
}
