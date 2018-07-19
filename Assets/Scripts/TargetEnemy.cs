using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// TargetEnemy class takes care of drawing the crosshair over an enemy, if on the screen, and selecting which enemy to draw over if multiple
/// </summary>
public class TargetEnemy : MonoBehaviour
{
    private Camera _cam;
    private static Image _image;
    public static bool LockedOn;
    public  static int LockedEnemy;
    public static List<EnemyInView> VisibleEnemies = new List<EnemyInView>();

    private static EnemyInView _target;
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
	    if (VisibleEnemies.Count == 0)
	    {
            TurnOffLockOn();
        }
	    else if (Input.GetKeyDown(KeyCode.Tab) && !LockedOn)
	    {
         
            if (VisibleEnemies.Count > 0)
	        {
	            LockedOn = true;
	            _image.enabled = true;
	            LockedEnemy = 0;
	            _target = VisibleEnemies[LockedEnemy];
	        }
	    }
        else if ((Input.GetKeyDown(KeyCode.X) && LockedOn))
	    {
	        TurnOffLockOn();
	    }

	    if (Input.GetKeyDown(KeyCode.Tab))
	    {
           
            if (LockedEnemy == VisibleEnemies.Count - 1)
	        {
	            LockedEnemy = 0;
	            _target = VisibleEnemies[LockedEnemy];
	        }
	        else
	        {
	            LockedEnemy++;
	            _target = VisibleEnemies[LockedEnemy];
	        }
	    }
	    if (LockedOn)
	    {
	        _target = VisibleEnemies[LockedEnemy];

	        Vector3 temp = gameObject.transform.position = _cam.WorldToScreenPoint(_target.transform.position);
	        if (temp.z < 0)
	            temp *= -1; // Needs this to prevent drawing crosshair mirrored duplicate in the opposite direction

	        gameObject.transform.position = temp;
            gameObject.transform.Rotate(new Vector3(0,0,-1));
	    }
	}

    public static void TurnOffLockOn()
    {
        LockedOn = false;
        _image.enabled = false;
        LockedEnemy = 0;
        _target = null;
    }
}
