using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected Sprite[] itemSprite;
    protected Image image;
    protected float applyItemTime = 5f;

    protected string name;
    protected float speed;
    protected float size;
    protected int createIndex;

    private void OnDisable()
    {
        image = GetComponent<Image>();
        createIndex = 0;
    }

    public abstract void SetItmeInfo();
    public abstract void UseItem();

    public virtual void CreateItem(float speed, float size, int createdIndex)
    {
        this.speed = speed;
        this.size = size;
        createIndex = createdIndex;
    }
}
