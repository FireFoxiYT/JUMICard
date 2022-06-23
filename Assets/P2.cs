using UnityEngine;
using System.Collections;

public class P2 : MonoBehaviour {

    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;
    public Transform WheelFLtrans;
    public Transform WheelFRtrans;
    public Transform WheelRLtrans;
    public Transform WheelRRtrans;
    public Vector3 eulertest;
    public float maxFwdSpeed = -3000;
    public float maxBwdSpeed = 1000f;
    public float gravity = 9.8f;
    float inputHorizontal;
    float inputVertical;
    private bool braked = false;
    private float maxBrakeTorque = 500;
    private Rigidbody rb;
    public Transform centreofmass;
    private float maxTorque = 500;
    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreofmass.transform.localPosition;
    }
    
   void FixedUpdate () {
     if(!braked){
            WheelFL.brakeTorque = 0;
            WheelFR.brakeTorque = 0;
            WheelRL.brakeTorque = 0;
            WheelRR.brakeTorque = 0;
        }
        //speed of car, Car will move as you will provide the input to it.
   
        WheelRR.motorTorque = -maxTorque * inputVertical;
        WheelRL.motorTorque = -maxTorque * inputVertical;
      
        //changing car direction
        //Here we are changing the steer angle of the front tyres of the car so that we can change the car direction.
        WheelFL.steerAngle = 30 * (inputHorizontal);
        WheelFR.steerAngle = 30 * inputHorizontal;
    }
    void Update()
    {
        InputManager();
        HandBrake();
        
        //for tyre rotate
        WheelFLtrans.Rotate(WheelFL.rpm/60*360*Time.deltaTime ,0,0);
        WheelFRtrans.Rotate(WheelFR.rpm/60*360*Time.deltaTime ,0,0);
        WheelRLtrans.Rotate(WheelRL.rpm/60*360*Time.deltaTime ,0,0);
        WheelRRtrans.Rotate(WheelRL.rpm/60*360*Time.deltaTime ,0,0);
        //changing tyre direction
        Vector3 temp = WheelFLtrans.localEulerAngles;
        Vector3 temp1 = WheelFRtrans.localEulerAngles;
        temp.y = WheelFL.steerAngle - (WheelFLtrans.localEulerAngles.z);
        WheelFLtrans.localEulerAngles = temp;
        temp1.y = WheelFR.steerAngle - WheelFRtrans.localEulerAngles.z;
        WheelFRtrans.localEulerAngles = temp1;
        eulertest = WheelFLtrans.localEulerAngles;
    }
    void HandBrake()
    {
        //P2
        if(Input.GetKey(KeyCode.Minus))
        {
            braked = true;
        }
        else
        {
            braked = false;
        }
        if(braked){
         
            WheelRL.brakeTorque = maxBrakeTorque * 20;//0000;
            WheelRR.brakeTorque = maxBrakeTorque * 20;//0000;
            WheelRL.motorTorque = 0;
            WheelRR.motorTorque = 0;
        }
    }

    void InputManager() 
    {
        if(Input.GetKey(KeyCode.UpArrow)) 
        {
            inputVertical = 1f;
        }
        if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            inputHorizontal = -1f;
        }
        if(Input.GetKey(KeyCode.DownArrow)) 
        {
            inputVertical = -1f;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            inputHorizontal = 1f;
        }

        if(!(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
        {
            inputVertical = 0f;
        }
        if(!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            inputHorizontal = 0f;
        }
    }
}