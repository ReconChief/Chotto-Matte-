﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class ThreeDCamera : CameraLogic
{
    
    //[SerializeField]private GameObject xZOrientationRef;
    private static Transform xZOrientation;
    private static GameObject retical;
    private static ThreeDCamera instance;
    //[SerializeField] private GameObject reticalObject;
    [SerializeField] private GameObject bodyTarget;
    private Vector3 currentEulerAngles;
    private readonly float maxXRotation=40;
    private float minXRotation = 10;
    private float distanceFromZend=5;
	private Vector3 target;
    private Vector3 offset;
	private bool aiming;
    private AudioSource audio;
    [SerializeField] private Vector3 aimingPosition;
    public Transform XZOrientation { get => xZOrientation; set => xZOrientation = value; }
    public static bool IsActive => instance!=null&&instance.isActiveAndEnabled;

    public static GameObject Retical { get => retical; set => retical = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        //Player.aiming += Aiming;
        //Player.notAiming += NotAiming;
        //Player.lockOn += LockedOn;
        //Player.kintoun += Kintoun;
        instance = this;
        xZOrientation = new GameObject("xZOrienatation").transform;
        xZOrientation.transform.SetParent(transform);
        audio = GetComponent<AudioSource>();
        //Retical = Instantiate(reticalObject,transform);
        //Retical = new GameObject("retical").transform;
        
        //Retical.transform.SetParent(transform);
       
		
        //xZOrientation= xZOrientationRef;
    }
    public override void Start()
    {
        
        base.Start();
        currentEulerAngles = transform.eulerAngles;
        currentEulerAngles.x = 10;
        transform.eulerAngles = currentEulerAngles;
		StartCoroutine(WaitABitCoroutine());
		//Retical.transform.position = Player.GetPlayer().AimmingPoint.transform.position + new Vector3(0,1f , 7);
    }
	
    public override void Update()
    {
        base.Update();
        GetInput();
    }
    private void OnEnable()
    {
        //transform.rotation = Player.GetPlayer().transform.rotation; I need to set this when the camera is set active, but not before the player is active on main menu
    }
	private IEnumerator WaitABitCoroutine() {


		yield return null;
        target = Body.transform.position;

	}
	private void Aiming()
    {
		
        currentEulerAngles.x = -2;
		distanceFromZend = 1.7f;
        offset = new Vector3(0,0.85f,0);
        //aiming = true;
        //transform.position += new Vector3(0, 1, 0);
        minXRotation = -90;
		//Debug.Log();
    }
    private void NotAiming() {

		distanceFromZend = 3;
        offset = new Vector3(0, 0, 0);
        //transform.position -= new Vector3(0, 1, 0);
        //currentEulerAngles.x = 10;
        minXRotation = 10;
        //aiming = false;
    }
    private void LockedOn() {
        //currentEulerAngles.x = -2;
        distanceFromZend = 1.7f;
        offset = new Vector3(-1f, 1f, 0);
        //aiming = true;
        //transform.position += new Vector3(0, 1, 0);
        minXRotation = -90;
        //Debug.Log();
    }
    private void Kintoun() {

        offset = new Vector3(0, 1f, 0);

    }
    
    void GetInput()
    {
        
        float x = Input.GetAxis("RightStickX");
        float y = Input.GetAxis("RightStickY");
        
        //distanceFromZend += Input.mouseScrollDelta.y*Time.deltaTime;

        ApplyRotationOffset(x,y,ref currentEulerAngles);
		
			RotateCamera(x, y, Body.transform.position);
        //in case this breaks put bodyTarget.transform.position
        
    }

    private float EnsureAngleIs0To360(float angle) {
        if (angle < 0)
            return (angle % 360) + 360;
        return angle % 360;
    }
    private void ApplyRotationOffset(float cameraHortizonal, float cameraVertical, ref Vector3 target) {
        if (Time.deltaTime == 0)
            return;

        float deltaFromInputX = cameraHortizonal * 55 * Time.deltaTime;
        float deltaFromInputY = cameraVertical * 55 * Time.deltaTime;

        target.y = EnsureAngleIs0To360(target.y+deltaFromInputX);
        target.x = target.x + deltaFromInputY;
        target.x = Mathf.Clamp(target.x, minXRotation, maxXRotation);
    }
    private void RotateCamera(float x, float y,Vector3 target)
    {

        
        transform.eulerAngles=currentEulerAngles;
        transform.position=Calculate3rdPersonCameraPosition(target,distanceFromZend,currentEulerAngles)+offset;     
        xZOrientation.eulerAngles = new Vector3(0,transform.eulerAngles.y,0); 
    }
    private Vector3 Calculate3rdPersonCameraPosition(Vector3 focusPosition, float distance, Vector3 eulerAngles) {
        
        float cosx = Mathf.Cos(Mathf.Deg2Rad * eulerAngles.x);
        float siny = Mathf.Sin(Mathf.Deg2Rad * eulerAngles.y);
        float sinx = Mathf.Sin(Mathf.Deg2Rad * eulerAngles.x);

        Vector3 offset = new Vector3(distance * -cosx * siny, -distance * -sinx, 0);

        float args = distance * distance * cosx * cosx;
        args *= 1 - siny * siny;
        offset.z = (eulerAngles.y < 270 && eulerAngles.y > 90) ? Mathf.Sqrt(args) : -Mathf.Sqrt(args);

        return focusPosition + offset;
    }
}
