using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] Animator animator;
    float turnSmoothVelocity;

    [SerializeField] Joystick joystick;

    [SerializeField] GameObject Sickle;
    void Update()
    {
        //        float horizontal = Input.GetAxisRaw("Horizontal");
        //        float vertical = Input.GetAxisRaw("Vertical");

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction*speed*Time.deltaTime);
            animator.Play("Move");
        }
    }

    public void Mow()
    {
        Sickle.SetActive(true);
        animator.Play("Attack");
    }
}