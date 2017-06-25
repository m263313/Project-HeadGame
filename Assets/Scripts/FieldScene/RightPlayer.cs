using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayer : MonoBehaviour
{

    public static RightPlayer current;
    public Vector3 startPosition;
    GameObject player;
    float JumpTime = 0f;
    public float MaxJumpTime = 5f;
    public float JumpSpeed = 10f;
    Rigidbody2D myBody = null;
    public float speed = 1;
    bool JumpActive = false;
    bool isGrounded = false;
    // Use this for initialization
    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        current = this;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        float value = Input.GetAxis("RightPlayerHorizontal");
        if (Mathf.Abs(value) > 0)
        {



            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }
        Vector3 from = transform.position + Vector3.up * 0.5f;
        Vector3 to = transform.position + Vector3.down * 0.5f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        //Перевіряємо чи проходить лінія через Collider з шаром Ground
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        //Намалювати лінію (для розробника)
        Debug.DrawLine(from, to, Color.red);
        if (hit)
        {
            isGrounded = true;

        }
        else
        {

            isGrounded = false;
        }

        if (Input.GetButtonDown("RightPlayerJump") && isGrounded)
        {
            this.JumpActive = true;
        }
        //  if (Input.GetButtonDown("RightPlayerJump"))
        if (this.JumpActive)
        {
            if (Input.GetButtonDown("RightPlayerJump"))
            {
                this.JumpTime += Time.deltaTime;
                if (this.JumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = myBody.velocity;
                    vel.y = JumpSpeed * (2.5f - JumpTime / MaxJumpTime);
                    myBody.velocity = vel;
                }
            }
            else
            {
                this.JumpActive = false;
                this.JumpTime = 0;
            }
        }
    }
}
