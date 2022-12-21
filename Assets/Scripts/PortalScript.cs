using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalScript : MonoBehaviour
{
    public Gamemodes Gamemode;
    public Speeds Speed;
    public Gravity gravity;
    public int State;

    void OnTriggerEnter2D(Collider2D collision)
    {

        try
        {
            Movement movement = collision.gameObject.GetComponent<Movement>();
            //change portal func __
            movement.ChangeThroughPortal(Gamemode, Speed, gravity, State);

        }
        catch { }

    }

}
