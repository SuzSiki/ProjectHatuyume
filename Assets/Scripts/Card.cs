using UnityEngine;


[CreateAssetMenu]
public class Card:ScriptableObject,ICard{
    [SerializeField] string _Name;
    [SerializeField] string _Discription;
    [SerializeField] MessageData[] datas;


    public string Name{get{return _Name;}}
    public string Discription{get{return _Discription;}}
    public MessageData[] messages{get{return datas;}}
    
}