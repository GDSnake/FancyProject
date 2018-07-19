using UnityEngine;
/// <summary>
/// UIDirectionControl class makes Enemy health bar face towards the player always
/// </summary>
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
            transform.LookAt(player);
        }
    }
}
