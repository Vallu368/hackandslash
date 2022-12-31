using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureDuration : MonoBehaviour
{
    public float life = 10f;
    public float fadeRate;
    public float targetAlpha;

    public bool canRespawn;

    public List<Renderer> children;

    string myName;
    string fragmentName;

    int i;
    int nextUpdate;
    int waited;

    bool enabled = false;
    bool isActive = false;
    bool reset;



    private void Awake()
    {
        myName = this.gameObject.transform.GetChild(0).name;
        fragmentName = myName + "Fragments";
    }
    private void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }

        if  (waited > life)
        {
            Debug.Log("fade");
            if (i < children.Count)
            {
                StartCoroutine(Fade(children[i]));
                i++;
            }
        }
        if (reset)
        {
            if (canRespawn)
            {
                if (!isActive)
                {
                    StartCoroutine(Resetting());
                }
            }
        }
    }
    void UpdateEverySecond()
    {
        if (enabled)
        {
            waited++;
        }
    }

    public void Kill()
    {
        
        foreach (Transform child in transform)
        {
            if (child.name == fragmentName)
            {
                foreach (Transform frag in child)
                {
                    children.Add(frag.GetComponent<Renderer>());
                    
                }
            }
        }
        enabled = true;

        }
    IEnumerator Resetting()
    {
        isActive = true;
        reset = false;
        yield return new WaitForSeconds(10f);
        GameObject meep = this.transform.GetChild(0).gameObject;
        GameObject gloob = this.transform.GetChild(1).gameObject;
        Destroy(gloob);
        meep.SetActive(true);
        isActive = false;

    }
    IEnumerator Fade(Renderer rend)
    {
        //rend.gameObject.GetComponent<Collider>().enabled = false;
        //Debug.Log("Fading " + rend.gameObject.name);
        targetAlpha = 0f;
        Color curColor = rend.material.color;
        
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            rend.material.color = curColor;
            foreach (Material mat in rend.materials)
            {
                mat.color = curColor;
            }
            yield return null;
        }
        yield return new WaitForSeconds(5f);
        Destroy(rend.gameObject);
        enabled = false;
        waited = 0;

        if (canRespawn)
        {
            if (!isActive)
            {
                reset = true;
            }
        }

        
        
    }
}
