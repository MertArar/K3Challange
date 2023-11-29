using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction; 
    private PlayerInputActions playerInputActions;
    
    private void Awake() 
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    
    public Vector2 GetMovementVectorNormalized()
    {
         // Karakterin tuşlarla etkileşime geçmesi.
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();        
        // Karakterin haraket etmesi.
        inputVector = inputVector.normalized;
                
        return inputVector;
    }
}
