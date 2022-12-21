using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionPlayer : MonoBehaviour
{
    public Movement movement;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "die")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
