using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
[CreateAssetMenu]
public class KeyConfigData : ScriptableObject
{
    public KeyCode key;
    //同じステートは二度以上選ばないこと
    public List<StateAndEvents> stateEventList = new List<StateAndEvents>();
    public bool AllowLongPush = true;
    
    public void Action(States state)
    {
        stateEventList.Find(x => x.state == state).events.Invoke();
    }
}
[System.Serializable]
public class StateAndEvents
{
    [SerializeField] public States state;
    [SerializeField] public UnityEvent events;
    [SerializeField] public InputType type;
}
public enum InputType{
    down,
    up,
    wile
}