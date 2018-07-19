using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInView : MonoBehaviour
{
    private Camera cam;
    private bool addOnlyOnce;
	// Use this for initialization
	void Start () {
		cam= Camera.main;
	    addOnlyOnce = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 enemyPosition = cam.WorldToViewportPoint(gameObject.transform.position);

	    bool onScreen = enemyPosition.z > 0 && enemyPosition.x > 0 && enemyPosition.x < 1 && enemyPosition.y > 0 &&
	                    enemyPosition.y < 1;

	    if (onScreen && addOnlyOnce)
	    {
	        addOnlyOnce = false;
	        TargetEnemy.NearByEnemies.Add(this);
	    }
	    else if(!onScreen)
	    {
	        TargetEnemy.NearByEnemies.Remove(this);
	        addOnlyOnce = true;
	    }
	}
}
