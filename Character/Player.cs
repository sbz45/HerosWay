using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player instance;
    public Bag bag;
    


    
    public float raycastDistance;
    public float moveSpeed;
    


    // Start is called before the first frame update

    private new void Awake()
    {
        base.Awake();
        Debug.Log("playerAwake");
        GameManager.instance.player = this;
    }




}
