//Unity Keyboard input script for 4D movement of 2D sprites
//Works for WASD and Arrow Keys

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //This won't work without this line here

public class FnMOVE : MonoBehaviour
{
    //Automatically generated class from the InputActions asset. Mine is called "Inputs"
    //I then instantiate the Inputs and put them in a variable called "controls" but you can call it whatever you want, as long as you are consisitent
    public Inputs controls;

    //Movement Variables
    public Rigidbody2D rb; // You must add a rigidbody 2d component (inspector window) to the player gameobject in your scene
    public float moveSpeed = 10.0f; //How fast you want the player to move
    public Vector2 dPad; //This is just a variable. It can be named anything you want, like LeftAnalog, or whatevs

    void Awake() {
        controls = new Inputs(); //Instantiates the Inputs to be used for the rest of this script
        
    }

    //Required for new Input system
    public void OnEnable()
    {
        controls.Enable();  
    }

    //Required for new Input system
    public void OnDisable()
    {
        controls.Disable();
    }

    public void Start(){
        rb = GetComponent<Rigidbody2D>(); //This tells Unity to use the rigidbody2d of the player game object
    }

    public void Update() {
        //This is how we get the velocity to put into the rb
        //The value of this variable is the name of the C# class generated, then the Action Map, then the Name above the Bindings (ex: Move, Look, etc), then the ReadValue<Vector2>();
        //This is how the new input system works. 
        dPad = controls.PlayerMovement.Move.ReadValue<Vector2>();
        
    }

    void FixedUpdate()
    {
        //dPad is where the velocity Vector2 goes (the one that is from the input system)
        //This moves the player character
        rb.MovePosition(rb.position + dPad * Time.fixedDeltaTime);
    }

}
