using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fukidashi : MonoBehaviour
{
    FState lastState = FState.disabled;
    FState _NowState = FState.disabled;
    public static Fukidashi[] Fukidashis = new Fukidashi[2];
    TMP_Text tmpTex;
    Animator animator;

    string thinking = "‥"; 

    UITrigger ENTER = UITrigger.Enter;
    UITrigger EXIT = UITrigger.Exit;
    UITrigger IDLE = UITrigger.Idle;
    UITrigger DISABLE = UITrigger.Disable;

    bool ifWaitForFukidashiOpen = true;

    [SerializeField]float TypeIntervalSec = 0.5f;
    [SerializeField]int _ID;  //識別に使うID
    public int ID
    {
        get { return _ID; }
    }

    public FState NowState{
        get{return _NowState;}
        private set{_NowState = value;}
    }

    public void PositiveSignal(){
        if(NowState == FState.talking){
            StartCoroutine(Hayamawashi());
        }
        else if(NowState == FState.Waiting){
            NowState = FState.notTalking;
        }
    }

    IEnumerator Hayamawashi()
    {
        var tmp = TypeIntervalSec;
        TypeIntervalSec = 0;
        yield return new WaitUntil(()=>NowState == FState.Waiting);
        TypeIntervalSec = tmp;
    }

    public void Disable(){
        animator.SetTrigger(UITriggerManager.GetTrigger(EXIT));
        ifWaitForFukidashiOpen = true;
        NowState = FState.disabled;
    }

    void Awake()
    {
        tmpTex = GetComponentInChildren<TMP_Text>();
        Fukidashis[_ID] = this;
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    bool StateChanged
    {
        get { return lastState != NowState; }
    }

    public void ShowMessage(string message)
    {
        ComeFrontLayer();
        if (NowState == FState.disabled)
        {
            gameObject.SetActive(true);
            NowState = FState.enabled;
            animator.SetTrigger(UITriggerManager.GetTrigger(ENTER));
        }
        else{
            animator.SetTrigger(UITriggerManager.GetTrigger(IDLE));
        }
        StartCoroutine(TypeMotion(message));

    }

    public void HideMessage(){
        animator.SetTrigger(UITriggerManager.GetTrigger(DISABLE));
    }

    void ComeFrontLayer()
    {
        transform.SetSiblingIndex(1); //吹き出しを下のレイヤーに引っ込める。
    }

    IEnumerator TypeMotion(string message)
    {
        tmpTex.text = "";
        yield return new WaitUntil(()=>!ifWaitForFukidashiOpen); //これがあることで、Enterで文字だけ先走ってしまわないようにする。
        NowState = FState.talking;
        //string wordTyped = "";
        for (int i = 0; i < message.Length; i++)
        {
            yield return new WaitForSeconds(TypeIntervalSec);
            if(message[i].ToString() == thinking){
                yield return StartCoroutine(TypeThinking());
            }
            else{
                tmpTex.text = tmpTex.text.Insert(tmpTex.text.Length,message[i].ToString());
            }
        }
        NowState = FState.Waiting;
    }

    IEnumerator TypeThinking()
    {
        var tmpInterval = TypeIntervalSec * 5;
        for(int i = 0;i<3;i++){
            yield return new WaitForSeconds(tmpInterval);
            tmpTex.text = tmpTex.text.Insert(tmpTex.text.Length,"・");
        }
    }





    void LateUpdate()
    {
        lastState = NowState;
    }

    //吹き出しのエントリーアニメーションが終わったら呼ばれる。
    public void OnEntryEnd(){
        ifWaitForFukidashiOpen = false;
    }
}

public enum FState
{
    enabled,    //吹き出しが有効化された時
    talking,    //吹き出しが使われている（話している)状態
    Waiting,  //自分の会話フェーズでプレイヤーの入力を待っている状態
    notTalking, //会話フェーズで自分のターンではないとき
    disabled    //無効化されている状態s
}