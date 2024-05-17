using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] protected GameObject[] brickObj;
    [SerializeField] protected List<GameObject> pool = new List<GameObject>();

    protected virtual void Awake()
    {

    }
}
