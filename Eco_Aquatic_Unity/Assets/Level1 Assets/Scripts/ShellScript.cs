using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;

    private SpriteRenderer spriteRenderer;

    float elapsedTime = 0;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= 5) 
        {
            ChangeTheDamnSprite;
            elapsedTime = 0;
        }
    }

    void ChangeTheDamnSprite()
    {
        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = sprite2;
        }
    }
}
