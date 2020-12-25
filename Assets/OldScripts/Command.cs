using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Command<T> : ScriptableObject
{
    public abstract void execute(T obj);
}
