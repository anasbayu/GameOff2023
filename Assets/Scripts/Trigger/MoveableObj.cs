using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObj : TriggerInfo{
    bool isPushAble;
    public Rigidbody2D mRigidBody;

    void Start(){
        isPushAble = false;
        mRigidBody = GetComponent<Rigidbody2D>();
    }
}
