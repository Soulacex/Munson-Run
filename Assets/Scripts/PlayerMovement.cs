using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private bool turnLeft, turnRight;
    public float speed = 7.0f;
    private CharacterController myCharacterController;
    private bool jump = false;
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);
        jump = Input.GetKeyDown(KeyCode.W);
        if (turnLeft)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight)
            transform.Rotate(new Vector3(0f, 90f, 0f));
        else if (jump)
            myAnimator.Play("Jump");
        
        if(myCharacterController.transform.position.y < 1)
        {
           Die();
        }
        
        myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }

    void Die() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}