using UnityEngine;


public interface ICard{
    string Name{get;}
    string Discription{get;}
    MessageData[] messages{get;}
}

[System.Serializable]
public class MessageData{
    [SerializeField] public int PersonIdInt;
    [SerializeField,Multiline] public string Message;
}