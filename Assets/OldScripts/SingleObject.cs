using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public abstract class SingleObject:MonoBehaviour{
    protected static List<SingleObject> SingleObjectList = new List<SingleObject>();


    protected virtual void Awake()
    {
        Singleton();
        SetInstance();
    }

    protected abstract void SetInstance();

    void Singleton()
    {
        foreach(SingleObject obj in SingleObjectList)
        {
            if(obj.name == this.name)
            {
                Destroy(this.gameObject);
                return;
            }
        }
        SingleObjectList.Add(this);
    }

    void OnDestroy()
    {
        SingleObjectList.Remove(this);
    }
}