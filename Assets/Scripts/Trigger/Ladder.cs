using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : TriggerInfo
{
    public GameObject destinationPoint, startingPoint;

    public Vector2 GetDestinationPos(){
        return destinationPoint.transform.position;
    }

    public Vector2 GetLadderStartPos(){
        return startingPoint.transform.position;
    }
    
}
