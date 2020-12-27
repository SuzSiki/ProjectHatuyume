using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
//GameManagerのStateの影響を受けるオブジェクト
public class StateBasedObject : MonoBehaviour
{
    StateManager stateManager;

    void Awake()
    {
        stateManager = StateManager.instance;
    }
    protected virtual void Update()
    {

        switch (stateManager.NowState)
        {
            case States.Talking:
                if(stateManager.StateChanged)
                    OnTalking();
                WhileTalking();
                break;
        }
    }

    protected virtual void OnTalking()
    {

    }

    protected virtual void WhileTalking()
    {
        
    }
}
*/