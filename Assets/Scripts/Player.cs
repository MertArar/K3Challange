using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    
    [SerializeField] private float moveSpeed = 7f;
    
    private void Update()
    {
        // Karakterin tuşlarla etkileşime geçmesi.
        Vector2 inputVector = new Vector2(0,0);
        
        if(Input.GetKey(KeyCode.W)){
        inputVector.y = +1;
        }
        if(Input.GetKey(KeyCode.S)){
        inputVector.y = -1;
        }
        if(Input.GetKey(KeyCode.A)){
        inputVector.x = -1;
        }
        if(Input.GetKey(KeyCode.D)){
        inputVector.x = +1;
        }
        
        // Karakterin haraket etmesi.
        inputVector = inputVector.normalized;
        
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
        
        // Karakteri döndürme.
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);        
    }
}
