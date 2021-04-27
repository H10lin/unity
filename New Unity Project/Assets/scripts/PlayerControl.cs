using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveForce = 100;
    private Rigidbody2D heroBody;
    private float fInput = 0.0f;
    public float MaxSpeed = 5;
    private bool bFaceRight = true;
    private bool bGround = false;
    Transform mGroundCheck;

    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        fInput = Input.GetAxis("Horizontal");
        heroBody.AddForce(Vector2.right * fInput  * moveForce );
        if (fInput < 0 && bFaceRight)
        {
            flip();

        }
        else if (fInput >0 && !bFaceRight )
        {
            flip();
        }
        
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(heroBody.velocity.x) < MaxSpeed)
        {
            heroBody.AddForce(fInput * moveForce * Vector2.right);
        }
        if (Mathf.Abs(heroBody.velocity.x) > MaxSpeed)
        {
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x)
                * MaxSpeed, heroBody.velocity.y);
        }
    }
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
}
