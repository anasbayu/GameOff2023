using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : TriggerInfo
{
    public GameObject destinationPoint;

    public Vector2 GetDestinationPos(){
        return destinationPoint.transform.position;
    }
}
