using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;
    protected TextMeshProUGUI text;
    protected float applyItemTime = 5f;

    protected float speed;
    protected float size;
    protected int createIndex;

    public abstract void SetItmeInfo(int createIndex);
}
