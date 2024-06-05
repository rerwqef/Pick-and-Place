using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAiming : MonoBehaviour
{
    // Start is called before the first frame update
    public float turnSpeed = 15;
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float yaxisCam = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,yaxisCam,0),turnSpeed*Time.fixedDeltaTime);                                                                                                                       
    }
}
