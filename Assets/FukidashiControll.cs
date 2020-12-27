using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//仕事:
public class FukidashiControll : SingleObject
{
    Fukidashi[] fukidashiArray = Fukidashi.Fukidashis;
    public static FukidashiControll instance = null;

    ModuleState _State = ModuleState.disabled;
    Fukidashi nowFukidashi = null;
    public ModuleState State{
        get{return _State;}
        private set{_State = value;}
    }

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        State = ModuleState.waiting;
    }

    protected override void SetInstance()
    {
        instance = GetInstance() as FukidashiControll;
    }

    void Singleton(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(instance.gameObject);
            State = ModuleState.waiting;
        }
    }

    public bool LoadCard(ICard card){
        if(State != ModuleState.waiting){
            Debug.LogWarning("FukidashiControll:LoadCardFailed");
            return false;
        }
        StartCoroutine(MessageLoader(card.messages));
        return true;
    }

    IEnumerator MessageLoader(MessageData[] datas){
        State = ModuleState.working;
        foreach(MessageData data in datas){
            nowFukidashi = fukidashiArray[data.PersonIdInt];
            nowFukidashi.ShowMessage(data.Message);
            yield return new WaitWhile(()=>nowFukidashi.NowState == FState.notTalking); //ShowMessageでTalkingになっているはずだが一応貫通防止
            yield return new WaitUntil(()=>nowFukidashi.NowState == FState.notTalking);
            nowFukidashi.HideMessage();
        }
        DisableAll();
        State = ModuleState.waiting;
    }

    void DisableAll(){
        foreach(Fukidashi fukidashi in fukidashiArray){
            fukidashi.Disable();
        }
    }

    public void OnPositiveInput(){
        if(State == ModuleState.working){
            nowFukidashi.PositiveSignal();
        }
    }

}

public enum ModuleState{
    disabled,
    initializing,
    waiting,
    working
}