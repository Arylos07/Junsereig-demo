using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public bool isDead = false;
    public bool isMoving = false;
    public float CurrentSpeed;

    private void FixedUpdate()
    {
        if(isDead == false)
        {
            if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                isMoving = false;
                animator.ResetTrigger("Walking");
                animator.SetTrigger("Idle");
            }
            else
            {
                isMoving = true;
                animator.ResetTrigger("Idle");
                animator.SetTrigger("Walking");
            }

            //GetAxis for keyboard. If console mode is enabled, use GetAxisRaw instead.
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + move * CurrentSpeed);
        }
    }

}
