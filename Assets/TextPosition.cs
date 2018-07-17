using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPosition : MonoBehaviour
{

    public Text nameLabel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 namePos = GetComponent<Camera>().WorldToScreenPoint(this.transform.position);
	    nameLabel.transform.position = namePos;
	}
}
