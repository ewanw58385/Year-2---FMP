using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    [HideInInspector] public bool isGrounded;
    [SerializeField] private LayerMask ground;

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "floor") 
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        isGrounded = false;
    }
}
