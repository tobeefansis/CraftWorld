using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [SerializeField] Image sprite;
    [SerializeField] Sprite noSprite;

    public void ItemSet(Sprite sprite)
    {
        if (sprite==null)
        {
            this.sprite.sprite = noSprite;
        }
        else
        {
            this.sprite.sprite = sprite;

        }
    }
  
}
