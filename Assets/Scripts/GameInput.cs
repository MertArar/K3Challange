using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    
    private PlayerInputActions playerInputActions;
    
    private void Awake() 
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();    
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
