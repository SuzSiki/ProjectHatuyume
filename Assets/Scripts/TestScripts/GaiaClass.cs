using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaiaClass : MonoBehaviour
{
    static List<GaiaClass> classList = new List<GaiaClass>();
    protected virtual void Awake()
    {
        classList.Add(this);
    }

    protected void PrintNames(){
        classList.ForEach(x => Debug.Log(x.GetType().Name));
    }
}
