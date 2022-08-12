using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGraphics : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();

    void Awake()
    {
        int rand = Random.Range(0, sprites.Count);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[rand];

        PolygonCollider2D col = GetComponent<PolygonCollider2D>();
        col.TryUpdateShapeToAttachedSprite();
    }
}
