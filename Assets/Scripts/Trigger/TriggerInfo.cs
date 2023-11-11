using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfo : MonoBehaviour{
    string[] triggerData = {"Chest", "Ladder", "Door", "Lore"};
    
    [Dropdown("triggerData")]
    public string triggerName;      // Chest, Ladder, Door, Obstacle.

    
}
