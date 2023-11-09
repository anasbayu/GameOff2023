using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    public GameObject layerBG, layer1, layer2, layer3, layerForeGround;
    public float layer1Speed, layer2Speed, layer3Speed, layerForeGroundSpeed;

    public void ParallaxingForward(bool isMovingForward){
        int direction = 1;      // 1 = right, -1 = left.
        if(!isMovingForward){
            direction = -1;
        }
        layer1.transform.Translate(Vector2.left * direction * layer1Speed * Time.deltaTime);
        layer2.transform.Translate(Vector2.left * direction * layer2Speed * Time.deltaTime);
        layer3.transform.Translate(Vector2.left * direction * layer3Speed * Time.deltaTime);
        layerForeGround.transform.Translate(Vector2.left * direction * layerForeGroundSpeed * Time.deltaTime);
    }
}
