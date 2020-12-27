using UnityEngine;

/*
public class StateManager:SingleObject{
    public States NowState;
    States LastState;
    public static StateManager instance;
    
    public bool StateChanged{get{return LastState != NowState;}}

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void SetInstance()
    {
        foreach(SingleObject obj in SingleObjectList){
            if(this.name == obj.name){
                instance = obj as StateManager;
            }
        }
    }


    void LateUpdate()
    {
        LastState = NowState;
    }
}

public enum States{
    Talking

}
*/