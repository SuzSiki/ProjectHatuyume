using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;
/*
//コマンドやオブザーバーなどいろいろな方を検討された後、結局UNITYEventベースで動くことになった悲しいクラス
public class StateBaseKeyReconnector : StateBasedObject
{
    [SerializeField] KeyConfigData[] keyConfigArray;

    // Start is called before the first frame update
    void Start()
    {

    }

    protected override void Update()
    {
        base.Update();
        States state = StateManager.instance.NowState;
        foreach(KeyConfigData data in keyConfigArray){
            if(data.AllowLongPush){
                if(Input.GetKey(data.key))
                {
                    data.Action(state);
                }
            }
        }
    }


    void ResetButtons(States state)
    {
    }
    

}
*/