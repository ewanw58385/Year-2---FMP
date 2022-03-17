using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]public Rigidbody2D rb;
    [HideInInspector]public Animator anim;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal"); //gets axis as vector2
        transform.position += new Vector3(HorizontalInput, 0, 0) * Time.deltaTime * moveSpeed;         
    }
}