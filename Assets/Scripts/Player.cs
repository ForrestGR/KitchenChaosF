using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private LayerMask weaponsLayerMask;   //lamo

    //Accessors
    private bool isWalking;

    private Vector3 lastInteractDir;


    //Mein Quatsch
    private bool isRunning;
    [SerializeField] private float jumpForce = 10f; //mein quatsch
    private Rigidbody rb;  //mein quatsch


    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;

        rb = GetComponent<Rigidbody>(); //mein quatsch        
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();

        MyDumpJumpAndRunningFunction();
    }
        

    //Functions
    private void HandleMovement()
        {
            Vector2 inputVector = gameInput.GetMovementVectorNormalized();

            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

            float moveDistance = moveSpeed * Time.deltaTime;
            float playerRadius = 0.7f;
            float playerHeight = 2f;
            bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);   //Raycast(Vector3 Origin, Vector3 direction, float MaxDistance)  , return boolean , if Raycast false = canMove = true
                                                                                                                                                            //CapsuleCast auch ganz wild


            if (!canMove)
            {
                // Cannot move towards moveDir

                // Attempt only X movement
                Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

                if (canMove)
                {
                    // Can move only on the X
                    moveDir = moveDirX;
                }
                else
                {
                    // Cannot move only on the X

                    // Attempt only Z movement
                    Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                    canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                    if (canMove)
                    {
                        // Can move only on the Z
                        moveDir = moveDirZ;
                    }
                    else
                    {
                        // Cannot move in any direction
                    }
                }
            }


            if (canMove)
            {
                transform.position += moveDir * moveDistance;                                            //transfrom referes to the script is attached to, the player in this case
            }



            isWalking = moveDir != Vector3.zero;


            float rotateSpeed = 10f;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);           //transform.rotation/.eulerangles/.lookat/.forward/.right/.left/.up/.down

        }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))      //Raycast hitted das erste object welches es trifft und gibt einen bool zurück, raycastall gibt ein array zurück mit allem gehitteten
        {                                                                                                                              //oder nutze raycast mit layermask und smash nur die objecte die die gleiche layermask haben
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))                            
            {
                //Has ClearCounter
                clearCounter.Interact();                                                                                            
            }                                                                                                   
        }


        if (Physics.Raycast(transform.position, lastInteractDir, out raycastHit, interactDistance, weaponsLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out AK47 aK47))
            {
                aK47.Interact();
            }
        }


    }




    //Accessors
    public bool IsWalking()
        {
            return isWalking;
        }


    public bool IsRunning()
        {
            return isRunning;
        }




    //Mein Quatsch, Jumping and running
    private void MyDumpJumpAndRunningFunction()
    {
        // Jumping logic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //super bad running und animation
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeed / 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }
    private void Jump()
     {
        // Überprüfe, ob der Spieler sich auf dem Boden befindet (optional)

        // Füge die Sprungkraft hinzu
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
     }

}


