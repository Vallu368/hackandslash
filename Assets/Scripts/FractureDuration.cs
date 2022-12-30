using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureDuration : MonoBehaviour
{
    public float life = 10f;
    public List<MeshRenderer> children;
    string myName;
    string fragmentName;

    private void Awake()
    {
        myName = this.gameObject.transform.GetChild(0).name;
        fragmentName = myName + "Fragments";
    }

    public void Kill()
    {
        foreach (Transform child in transform)
        {
            if (child.name == fragmentName)
            {
                foreach (Transform frag in child)
                {
                    children.Add(frag.GetComponent<MeshRenderer>());
                }
            }
        }
        

        }
}
