using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICameraState
{
    void OnEnter();
    void Update();
    void FixedUpdate();
    void OnExit();
}
/// <summary>
/// Behavours of the camera are accessed here
/// </summary>
public class CameraRumbleMotion : MonoBehaviour
{
    public static CameraRumbleMotion instance;
    private ICameraState _State;

    [SerializeField]
    private Transform _PlayerHands;
    public Transform PlayerHands { get { return _PlayerHands; } }

    private void Awake()
    {
        _State = new Idle(this);
        CreateInstance();
    }

    //create static instance of class
    void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void LateUpdate()
    {
        _State.Update();
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    ShakeCamera(1, 2f);
        //}
    }
    //switches camera to rumble state
    public void ShakeCamera(float rumbleintensity, float rumbletime)
    {
        SwitchState(new Rumble(this, rumbleintensity, rumbletime));
    }

    // switches camera's state
    public void SwitchState(ICameraState state)
    {
        _State.OnExit();
        _State = state;
        _State.OnEnter();
    }
}
/// <summary>
/// State that does nothing
/// </summary>
public class Idle : ICameraState
{
    CameraRumbleMotion _Behaviour;

    public Idle(CameraRumbleMotion behaviour)
    {

    }
    public void OnEnter()
    {

    }
    public void Update()
    {

    }
    public void FixedUpdate()
    {

    }
    public void OnExit()
    {

    }
}
/// <summary>
/// State that makes the camere rumble
/// </summary>
public class Rumble : ICameraState
{
    CameraRumbleMotion _Camera;
    float _RumbleTime, _RumbleIntensity, _RumbleTick, _CurrentIntensity;

    public Rumble(CameraRumbleMotion camera, float rumbleintensity, float rumbletime)
    {
        _Camera = camera;
        _RumbleTime = rumbletime;
        _RumbleIntensity = rumbleintensity;
        _CurrentIntensity = _RumbleIntensity;
    }
    public void OnEnter()
    {

    }
    public void Update()
    {
       
         

        //calculate rotation of camera
        Vector3 cameraRotation = _Camera.transform.localEulerAngles;
        Vector3 newrotation = Vector3.Lerp(cameraRotation, new Vector3(cameraRotation.x + _CurrentIntensity * RandomSign(), cameraRotation.y + _CurrentIntensity * RandomSign(), cameraRotation.z + _CurrentIntensity * RandomSign()), 0.5f);
        _Camera.transform.Rotate(new Vector3(0, newrotation.y, newrotation.z));

        //calculate rotation of hands
        cameraRotation = _Camera.PlayerHands.transform.localEulerAngles;
         newrotation = Vector3.Lerp(cameraRotation, new Vector3(cameraRotation.x + _CurrentIntensity * RandomSign(), cameraRotation.y + _CurrentIntensity * RandomSign(), cameraRotation.z + _CurrentIntensity * RandomSign()), 0.5f);
        _Camera.PlayerHands.transform.Rotate(-new Vector3(newrotation.z, newrotation.y, newrotation.z));

        _CurrentIntensity = Mathf.Lerp(_RumbleIntensity, 0, 1 - _RumbleTime);
        _RumbleTime -= Time.deltaTime;
        if (_RumbleTime <= 0)
        {
            _Camera.SwitchState(new Idle(_Camera));
        }
    }
    public void FixedUpdate()
    {

    }
    public void OnExit()
    {
        //reset rotation of hands
        _Camera.PlayerHands.localRotation = new Quaternion();
    }

    int RandomSign()
    {
        if (Random.Range(0, 2) == 0)
        {
            return -1;
        }
        return 1;
    }
}

