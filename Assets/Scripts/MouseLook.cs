using UnityEngine;

public class MouseLook : MonoBehaviour
{
    const float CLAMP_MIN = -90;
    const float CLAMP_MAX = 90;

    float lookSensitivity = 2.0f;
    GameObject player;

    Vector2 rotation = Vector2.zero;
    
    void Start()
    {
        player = transform.parent.gameObject;
    }

    void Update()
    {
        // Rotate the player
        player.transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity);

        // Rotate the camera
        rotation.y += Input.GetAxis("Mouse Y") * lookSensitivity;
        rotation.y = Mathf.Clamp(rotation.y, CLAMP_MIN, CLAMP_MAX);
        transform.localEulerAngles = new Vector3(-rotation.y, 0, 0);
    }
}
