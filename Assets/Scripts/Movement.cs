using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum Speeds { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4 }
public enum Gamemodes { Cube = 0, Ship = 1 }

public enum Gravity { Upright = 1, UpsideDown = -1 }

public class Movement : MonoBehaviour
{

    public Speeds CurrentSpeed;
    public Gamemodes CurrentGamemode;
    //                       0      1      2       3      4
    float[] SpeedValues = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f };

    public Transform GroundCheckTrasnform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;
    public Transform Sprite;
    public float cubeGrav = 12.41067f;
    public float shipGrav = 5;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    
    void Update()
    {
        
        transform.position += Vector3.right * SpeedValues[(int)CurrentSpeed] * Time.deltaTime;
        // checking for gm
        if (CurrentGamemode == 0)
        {
            rb.gravityScale = cubeGrav;

            if (OnGround())
            {   // Getting Sprite rotation
                Vector3 Rotation = Sprite.rotation.eulerAngles;
                // Nearest 90 degree ---
                Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
                Sprite.rotation = Quaternion.Euler(Rotation);
                // Jump ---

                if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    // resetting velocity
                    rb.velocity = Vector2.zero;
                    //                                 Method of adding force
                    rb.AddForce(Vector2.up * 26.6581f, ForceMode2D.Impulse);

                }

            }
            else
            {
                // rotation ---
                Sprite.Rotate(Vector3.back * 0.8f);

            }
        }
        if (CurrentGamemode == (Gamemodes)1)
        {
            rb.gravityScale = shipGrav;

            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                // resetting velocity
                rb.velocity = Vector2.zero;
                //                                 Method of adding force
                rb.AddForce(Vector2.up * 30f, ForceMode2D.Force);

            }

        }
        
    }

    bool OnGround()
    {

        return Physics2D.OverlapCircle(GroundCheckTrasnform.position, GroundCheckRadius, GroundMask);

    }

    public void ChangeThroughPortal(Gamemodes Gamemode, Speeds Speed, Gravity Gravity, int State)
    {

        switch (State)
        {
            case 0:
                CurrentSpeed = Speed;
                break;
            case 1:
                CurrentGamemode = Gamemode;
                break;
            case 2:
                rb.gravityScale = Mathf.Abs(rb.gravityScale) * (int)Gravity;
                break;

        }

    }
}
