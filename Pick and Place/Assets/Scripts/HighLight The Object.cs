using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightTheObject : MonoBehaviour
{
    [SerializeField]
    List<Renderer> renders;
    [SerializeField]
    Color color=Color.white;
    [SerializeField]
    List<Material> materials;
    private void Awake()
    {
        materials=new List<Material> ();     
        foreach(var render in renders) {
            materials.AddRange(new List<Material>(render.materials));
        }  
    }
   public void   OnHighLight(bool m)
    {
        if (m)
        {
            foreach(var metrial in materials)
            {
                metrial.EnableKeyword("_EMISSION");
                metrial.SetColor("_EMISSION", color);
            }
        }
        else
        {
            foreach(var metrial in materials)
            {
                metrial.DisableKeyword("_EMISSION");

            }
        }
    }
}
