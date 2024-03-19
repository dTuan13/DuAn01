using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : TunBehaviour
{
    [Header("Spawner")]

    [SerializeField] protected Transform Holder;

    [SerializeField] protected List<Transform> prefabs;

    [SerializeField] protected List<Transform> poobObjs;

    [SerializeField] protected int randomCount = 0;
    public int RandomCount => randomCount;

    [SerializeField] protected string tickAppear;

    public string TickAppear => tickAppear;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform Prefabs = transform.Find("Prefabs");
        if(Prefabs == null)
        {
            Debug.LogWarning(transform.name + ": LoadPrefabs");
            return;
        }

        foreach(Transform obj in Prefabs)
        {
            this.prefabs.Add(obj);
        }
        this.HidePrefabs();
    }

    protected virtual void LoadHolder()
    {
        if (this.Holder != null) return;
        this.Holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + ": LoadHolder");
    }

    protected virtual void HidePrefabs()
    {
        foreach(Transform obj in this.prefabs)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 pos, Quaternion rot)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab == null)
        {
            Debug.LogWarning("Don't find " + prefabName);
            return null;
        }
        return this.Spawn(prefab, pos, rot);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetLocalPositionAndRotation(pos, rot);
        newPrefab.SetParent(this.Holder);
        newPrefab.gameObject.SetActive(true);
        this.randomCount++;
        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform obj in this.poobObjs)
        {
            if(obj.name == prefab.name)
            {
                this.poobObjs.Remove(obj);
                return obj;
            }
        }

        Transform newObj = Instantiate(prefab);
        newObj.name = prefab.name;
        return newObj;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform obj in this.prefabs)
        {
            if (obj.name == prefabName) return obj;
        }
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        if (this.poobObjs.Contains(obj)) return;
        this.poobObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.randomCount--;
    }

    public virtual Transform RandomPrefab()
    {
        int random = Random.Range(0, this.prefabs.Count);
        return this.prefabs[random];
    }
}
