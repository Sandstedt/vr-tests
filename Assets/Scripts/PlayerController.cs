using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityExample
{
  public class PlayerController : MonoBehaviour
  {
    [SerializeField] private Rigidbody rb;

    [Header("Moving settings")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private float turnSpeed;
    private Vector3 moveVector;

    void OnMove(InputValue value)
    {
      moveVector = Vector3.zero;
      var moveDirection = value.Get<Vector2>();
      moveVector += new Vector3(moveDirection.x, 0f, moveDirection.y) * moveSpeed; // * Time.deltaTime
      rb.AddForce(moveVector);
      RotateToVelocity(turnSpeed, moveVector);
    }

    public void RotateToVelocity(float turnSpeed, Vector3 dir)
    {
      Quaternion slerp;

      if (dir.magnitude > 1f)
      {
        dir.y = dir.y + (dir.magnitude * 0.2f);
        Quaternion dirQ = Quaternion.LookRotation(dir);
        slerp = Quaternion.Slerp(rb.rotation, dirQ, turnSpeed * Time.deltaTime);
      }
      else
      {
        Quaternion upright = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        slerp = Quaternion.Slerp(rb.rotation, upright, turnSpeed * Time.deltaTime);
      }
      rb.MoveRotation(slerp);
    }

    // Uncomment for keyboard testing
    //void FixedUpdate()
    //{  
    // rb.AddForce(moveVector);
    // RotateToVelocity(turnSpeed, moveVector);
    //}
  }
}

