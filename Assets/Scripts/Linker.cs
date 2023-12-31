using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Linker : MonoBehaviour{
    public GameObject mPlayer;
    public GameObject mStatusBalloon;
    public ParallaxManager mParallaxManager;
    public PlayerStatus mPlayerStatus;
    public PlayerSense mPlayerSense;
    public PlayerControll mPlayerControll;
    public UIManager mUIManager;
    public Inventory mInventory;
    public VNManager mVNManager;
    public GameManager mGameManager;
    public EnvironmentManager mEnvManager;
    public CameraFollow mCamera;
    public ScreenFade mEffectScreenFade;
    public UnityEngine.Rendering.Universal.Light2D mGlobalLight;
    public SwapableSprite mSwapSprite;
    public SFXManager mSFX;
}
