using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : BaoMonoBehaviour
{
    [SerializeField] protected List<GameObject> poolObjects = new List<GameObject>();
    [SerializeField] protected int amountToPool = 10;
    [SerializeField] protected GameObject prefab;
    protected override void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }
    }

    public abstract GameObject GetPooledObject();
}
