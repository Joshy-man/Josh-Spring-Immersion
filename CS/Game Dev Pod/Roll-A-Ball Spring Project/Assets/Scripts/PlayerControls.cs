using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    #region Variables
    // 1. Declare a public variable of type float named 'moveSpeed'; assign it the value '5f'
    // This variable stores how fast the player character moves
    public float moveSpeed = 5f;

    // 2. Declare a public variable of type CharacterController named 'controller'; Do not assign it a value here
    // This variable stores the player character's Charactercontroller component, which will be used to move the character later
    public CharacterController controller;

    

    // 3. Declare a public variable of type float named 'rotateSpeed'; assign it the value '10f'
    // This variable stores how fast the player rotates when changing direction
    public float rotateSpeed = 5f;
    #endregion


    // Start() is a built-in Unity function/method called before the first frame update of the game
    void Start()
    {
        // 4. Store/Assign the player's CharacterController component to the 'controller' variable (Hint: Use the GetComponent<>() funcntion)
        // This allows us to access the player character's CharacterController component through this variable, and call functions it has like Move() 
        controller = GetComponent<CharacterController>();
    }

    // Update is a built-in Unity function/method called every frame of your game (there is on average 60 frames per second)
    void Update()
    {
        // 5. Declare a private variable of type float named 'horizontalInput'
        // Assign this variable the output of the Input.GetAxis("") function 
        // This line of code collects the horizontal input (left & right) of the player & stores it inside the 'horizontalInput' variable
        float horizontalInput = Input.GetAxis("Horizontal");

        // 6. Declare a private variable of type float named 'vertricalInput'
        // Assign this variable the output of the Input.GetAxis("") function 
        // This line of code collects the vertical input (forward & back) of the player & stores it inside the 'verticalInput' variable
        float verticalInput = Input.GetAxis("Vertical");

        // 7. Declare a private variable of type Vector3 named 'moveDirection'
        // Assign this variable to a new Vector3(x, y, z) by plugging in your input variables for the x & z values respectively, and the y value as '0f'
        // This variable compiles all player input into a single direction the player character will move in
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);


        // 8. Write an if statement with the condtion: if 'moveDirection' is NOT equal to 'Vector3.zero'
        // This checks 'if the player's move direction is not zero', and is therefore supposed to be moving 
        // (Hint: Don't forget to create {} brackets after the head of the if statement; 9 - 11 should be inside and indented within those brackets)
        // (HINT: The "does not equal" operator is !=) 
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
        
            // 9. Declare a variable of type Quaternion named 'targetRotation'
            // Assign this variable the output of the function Quaternion.LookRotation(""), with the 'moveDirection' as the argument
            // This variable stores the desired direction we want the player character to turn towwards while moving
            // YOUR CODE HERE

            // 10. Assign the player character's transform.rotation value to the output of the Quaternion.Slerp() function;
            // Pass in 'transform.rotation', 'targetRotation', 'rotationSpeed * Time.deltaTime' as the arguments
            // This line of code rotates the player character over time until it is facing the direction it is traveling in
            // YOUR CODE HERE

            // 11. Access the 'controller' variable & call it's Move() function
            // Pass in 'moveDirection * moveSpeed * Time.deltaTime' as the arguments
            // This line of code applies our movement calculations and move speed to the player character to actually make them move!
            // YOUR CODE HERE
    }

    // 12. Return to the Unity Editor
    // Enter play mode and test your code; your player character should now be able to move around!
}


