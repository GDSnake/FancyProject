using UnityEngine;

public class UIDirectionControl : MonoBehaviour
{
    public bool UseRelativeRotation = true;
    private Transform player;

    private Quaternion RelativeRotation;     


    private void Start()
    {
        RelativeRotation = transform.parent.localRotation;
    }


    private void Update()
    {
        if (UseRelativeRotation)
            transform.rotation = RelativeRotation;
        if (gameObject.tag == "Enemy")
        {
            player = GameObject.FindWithTag("Player").transform;
            /*Quaternion direction = transform.rotation;
            Vector3 rot = direction.eulerAngles;
            rot = new Vector3(rot.x+90, rot.y+45, rot.z);
            direction = Quaternion.Euler(rot);
            transform.rotation=direction;*/
            transform.LookAt(player);
        }
    }
}
