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
    RaycastHit hit;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Pickup();
        }        

        if (hit.collider != null)
        {
            hit.collider.GetComponent<HighLightTheObject>()?.OnHighLight(false);
            pickUpUi.SetActive(false);
        }
        if (Physics.Raycast(Camera.main.transform.position,
            Camera.main.transform.forward,
            out hit,
            hitRange, pickableLayermask))
            
            {
            hit.collider.GetComponent<HighLightTheObject>()?.OnHighLight(true);
            pickUpUi.SetActive(true);
        }

    }
    public void Drop()
    {

    }
    public void Pickup()
    {
      if(hit.collider)
        {

        }
    }
    
    public void Place()
    {

    }
    
}
