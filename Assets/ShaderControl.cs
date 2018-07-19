using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderControl : MonoBehaviour
{
    public int count;
    private float _sumValue;
	// Use this for initialization
	void Start ()
	{
	    count = GetComponent<Renderer>().materials.Length;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _sumValue = Mathf.Sin(Time.time*2);
	    foreach (var material in GetComponent<Renderer>().materials)
	    {
            material.SetFloat("_Sum", _sumValue + 1);
        }
        
        
    }
}
