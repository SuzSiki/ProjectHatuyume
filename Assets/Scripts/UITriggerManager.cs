using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriggerManager
{
    static Dictionary<UITrigger,string> TriggerDict = new Dictionary<UITrigger, string>(){
        {UITrigger.Enter,"Enter"},
        {UITrigger.Exit,"Exit"},
        {UITrigger.Idle,"Idle"},
        {UITrigger.Disable,"Disable"}
    };


    static public string GetTrigger(UITrigger key){
        return TriggerDict[key];
    }
}

public enum UITrigger{
    Enter,
    Exit,
    Idle,
    Disable
}