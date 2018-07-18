using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetEnemy : MonoBehaviour
{
    private Camera _cam;
    private EnemyInView _target;
    private Image _image;
    
    public static bool LockedOn;

    public  static int LockedEnemy;

    public static List<EnemyInView> NearByEnemies = new List<EnemyInView>();

	// Use this for initialization
	void Start () {
  
		_cam = Camera.main;
	    _image = gameObject.GetComponent<Image>();

	    LockedOn = false;
	    _image.enabled = false;
	    LockedEnemy = 0;
	}

    
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Tab) && !LockedOn)
	    {
         
            if (NearByEnemies.Count > 0)
	        {
	            LockedOn = true;
	            _image.enabled = true;

	            LockedEnemy = 0;
	            _target = NearByEnemies[LockedEnemy];
	        }
	    }
        else if ((Input.GetKeyDown(KeyCode.X) && LockedOn) || NearByEnemies.Count == 0)
	    {
	        LockedOn = false;
	        _image.enabled = false;
	        LockedEnemy = 0;
	        _target = null;
	    }

	    if (Input.GetKeyDown(KeyCode.Tab))
	    {
           
            if (LockedEnemy == NearByEnemies.Count - 1)
	        {
	            LockedEnemy = 0;
	            _target = NearByEnemies[LockedEnemy];
	        }
	        else
	        {
	            LockedEnemy++;
	            _target = NearByEnemies[LockedEnemy];
	        }
	    }
	    if (LockedOn)
	    {
	        _target = NearByEnemies[LockedEnemy];

	        Vector3 temp = gameObject.transform.position = _cam.WorldToScreenPoint(_target.transform.position);
	        if (temp.z < 0)
	            temp *= -1;

	        gameObject.transform.position = temp;
            gameObject.transform.Rotate(new Vector3(0,0,-1));
	    }
	}
}
