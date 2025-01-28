using UnityEngine;

public class MouseLook : MonoBehaviour
{
    const float CLAMP_MIN = -45;
    const float CLAMP_MAX = 45;

    float lookSensitivity = 2.0f;
    GameObject player;

    Vector2 rotation = Vector2.zero;
    Vector2 smoothRot = Vector2.zero;
    Vector2 velRot = Vector2.zero;
    
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
        smoothRot.y = Mathf.SmoothDamp(smoothRot.y, rotation.y, ref velRot.y, 0.1f);
        transform.localEulerAngles = new Vector3(-smoothRot.y, 0, 0);
    }
}
