using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public abstract class SingleObject : MonoBehaviour
{
    //protected static List<SingleObject> SingleObjectList = new List<SingleObject>();
    protected static Dictionary<string, SingleObject> SingleObjectList = new Dictionary<string, SingleObject>();

    protected string ClassName;
    protected virtual void Awake()
    {
        Singleton();
        SetInstance();
    }





    ///<summary>
    ///SingleObject内のAwakeで呼ばれるので、
    ///</summary>
    protected abstract void SetInstance();

    //自分自身のインスタンスを取得。
    protected SingleObject GetInstance()
    {
        return SingleObjectList[this.GetType().Name];
    }

    void Singleton()
    {
        ClassName = this.GetType().Name;
        SingleObject mem = null;
        SingleObjectList.TryGetValue(ClassName,out mem);
        if (mem == null)
        {
            SingleObjectList[ClassName] = this;
            return;
        }
        Destroy(this.gameObject);
    }
}