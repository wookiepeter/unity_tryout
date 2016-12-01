using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    public float maxSpeed = 200f;
    public float moveForce = 80f;

    bool jump; 
    bool grounded;
    public float jumpForce = 600f;

    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(rb2d.position, Vector2.down * 0.52f);
        Debug.DrawRay(rb2d.position, Vector2.down * 0.52f);

        if (grounded && Input.GetButtonDown("Jump"))
            jump = true;
    }

    void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (jump)
        {
            jump = false;

            rb2d.AddForce(Vector2.up * jumpForce);
        }
	}


}
