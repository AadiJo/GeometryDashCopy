using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 5, transform.position.y, transform.position.z);
        if (Mathf.Abs(player.transform.position.y - transform.position.y) > 6)
        {
            transform.position = new Vector3(player.transform.position.x + 5, player.transform.position.y, transform.position.z);

        }
    }
}
