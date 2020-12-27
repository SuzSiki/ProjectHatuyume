using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardThrower : MonoBehaviour
{

    //Button button;
    [SerializeField]Card card;

    void Awake()
    {
        //button = GetComponent<Button>();
    }

    public void Throw(){
        var fControll = FukidashiControll.instance;
        fControll.LoadCard(card);
    }

}
