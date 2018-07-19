using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ShaderControl class simply sends the Time in seconds since beginning times 2 to the _Sum variable on the GradientLitShader, normalized from 0 to 2 and
/// 6 times to the _Mult variable on the GradientLitShader, normalized from 0 to 2. 
/// </summary>
public class ShaderControl : MonoBehaviour
{
    
    private float _sumValue;
    private float _multValue;
	
	
	// Update is called once per frame
	void Update ()
	{
	    _multValue = Mathf.Cos(Time.time*6);
	    _sumValue = Mathf.Sin(Time.time*2);
	    foreach (var material in GetComponent<Renderer>().materials)
	    {
            material.SetFloat("_Sum", _sumValue + 1);
            material.SetFloat("_Mult", _multValue + 1);
        }
        
        
    }
}
