using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    [SerializeField] private float movementSpeed = 30;
    private Animator animator;
   
    private CharacterController character;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

       
        
         character.Move(movement * Time.deltaTime * movementSpeed);
         animator.SetFloat("Speed", movement.magnitude);



    }

    
}
