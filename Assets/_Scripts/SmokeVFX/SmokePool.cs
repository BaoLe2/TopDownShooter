using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokePool : ObjectPool
{
    protected static SmokePool instance;
    public static SmokePool Instance { get => instance; }
    [SerializeField] protected Transform holder;

    protected override void Awake()
    {
        if (SmokePool.instance != null) Debug.LogError("Only 1 SmokePool");
        SmokePool.instance = this;
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
