using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickandDrop : MonoBehaviour
{
    [SerializeField]
    LayerMask pickableLayermask;
 //   [SerializeField]
   // Transform cameraTranform;
    [SerializeField]
    GameObject pickUpUi;
    [SerializeField]
    [Min(1)]
    private float hitRange = 3;
    [SerializeField] Transform pickupparent;
    [SerializeField] GameObject  InHandItem;
    [SerializeField] Vector3 Offset;                                     
    RaycastHit hit;
    private void Update()
    {
 
         

        if (hit.collider != null)
        {
            hit.collider.GetComponent<HighLightTheObject>()?.OnHighLight(false);
            pickUpUi.SetActive(false);
        }

        if (InHandItem != null) return;

        if (Physics.Raycast(Camera.main.transform.position,
            Camera.main.transform.forward,
            out hit,
            hitRange, pickableLayermask))
            
            {
            hit.collider.GetComponent<HighLightTheObject>()?.OnHighLight(true);
            pickUpUi.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Pickup();
        }
    }
    public void Drop()
    {

    }        
    public void Pickup()
    {
      if(hit.collider)
        {
            if (hit.collider.GetComponent<NormalItems>())
            {
                InHandItem = hit.collider.gameObject;
                InHandItem.transform.position=Vector3.zero+Offset;
                InHandItem.transform.rotation=Quaternion.identity;
                InHandItem.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
                InHandItem.transform.SetParent(pickupparent.transform, false);
                InHandItem.GetComponent<NormalItems>().Picked = true;
                return;
            }
        }
    }
    
    public void Place()
    {

    }
    
}
