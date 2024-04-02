using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private const string IS_WALKING = "IsWalking";
    private const string IS_RUNNING = "IsRunning";

    [SerializeField] private Player player;


    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
        animator.SetBool(IS_RUNNING, player.IsRunning());
    }

}




//public class PlayerAnimator : MonoBehaviour
//{
//    private const string IS_WALKING = "IsWalking";

//    [SerializeField] private Player player;
//    [SerializeField] private Animator animator;

//    private void Update()
//    {
//        // Überprüfen, ob 'animator' und 'player' zugewiesen sind
//        if (animator != null && player != null)
//        {
//            animator.SetBool(IS_WALKING, player.IsWalking());
//        }
//        else
//        {
//            Debug.LogWarning("Animator or player reference not set in PlayerAnimator script.");
//        }
//    }
//}