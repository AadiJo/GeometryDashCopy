using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    public Movement movement;
    public SpriteRenderer spriteRenderer;
    public Sprite CubeSprite;
    public Sprite ShipSprite;
    public Transform Sprite;
    void Start()
    {
        movement = GetComponent<Movement>();
        spriteRenderer.sprite = CubeSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.CurrentGamemode == 0)
        {
            spriteRenderer.sprite = CubeSprite;

        }
        if (movement.CurrentGamemode == (Gamemodes)1)
        {
            spriteRenderer.sprite = ShipSprite;
            Vector3 Rotation = Sprite.rotation.eulerAngles;
            Rotation.z = 0;
            Sprite.rotation = Quaternion.Euler(Rotation);

        }
    }
}
