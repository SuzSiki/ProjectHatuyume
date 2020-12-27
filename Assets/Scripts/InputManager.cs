using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;


public class InputManager : MonoBehaviour, TalkingActions.IPlayerActions
{
    TalkingActions input;
    FukidashiControll fControll;
    ModuleState _State = ModuleState.disabled;
    [SerializeField] CardThrower cardThrower;
    public ModuleState State{
        get{return _State;}
        private set{_State = value;}
    }
    void Awake()
    {
        input = new TalkingActions();
        input.Player.SetCallbacks(this);
        StartCoroutine(InitVariables());
    }

    IEnumerator InitVariables()
    {

        while(!Initializer()){
            State = ModuleState.initializing;
            yield return null;
        }
        input.Enable(); 
        State = ModuleState.waiting;
    }

    bool Initializer(){
        //List<SingleObject> list = new List<SingleObject>();
        if(fControll == null){
            fControll = FukidashiControll.instance;
            //list.Add(fControll);
        }
        
        return fControll != null;
    }


    public void OnPositive(InputAction.CallbackContext context)
    {
        if(State != ModuleState.waiting){Debug.LogWarning("MADA:" + State);}
        if(context.performed){
            fControll.OnPositiveInput();
        }
    }

    public void OnCardThrow(InputAction.CallbackContext context){
        if(State != ModuleState.waiting){Debug.LogWarning("MADA:" + State);}
        if(context.performed){
            cardThrower.Throw();
        }
    }

    void OnEnable()
    {
        Debug.Log("enabled");
        input.Enable();
    }
    
}
