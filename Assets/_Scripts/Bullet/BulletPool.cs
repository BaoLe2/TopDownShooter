using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool
{
    protected static BulletPool instance;
    public static BulletPool Instance { get => instance; }
    [SerializeField] protected Transform holder;

    protected override void Awake()
    {
        if (BulletPool.instance != null) Debug.LogError("Only 1 BulletPool");
        BulletPool.instance = this;
    }

    protected override void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            poolObjects.Add(obj);
            obj.transform.parent = this.holder;
        }
    }
    
    public override GameObject GetPooledObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }

        return null;
    }
}
