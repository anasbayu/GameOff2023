using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfo : MonoBehaviour{
    string[] triggerData = {"Chest", "Ladder", "Door", "Lore", "Moveable"};
    
    [Dropdown("triggerData")]
    public string triggerName;

    
}
