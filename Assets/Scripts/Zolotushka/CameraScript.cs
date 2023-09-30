using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float timeOffSet;
    [Header("Camera boundary settings")]
    [SerializeField] float leftCameraLimit;
    [SerializeField] float rightCameraLimit;
    [SerializeField] float lowerCameraLimit;
    [SerializeField] float upperCameraLimit;
    private Vector2 posOffSet;
    private Vector3 velocity;

    private void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player"); 
            Debug.Log("!= null");  
        }
        else
        {
            Debug.Log("== null");
        }
    }

    void FixedUpdate()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;
        endPos.x += posOffSet.x;
        endPos.y += posOffSet.y;
        endPos.z = -30;
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffSet);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftCameraLimit, rightCameraLimit),
            Mathf.Clamp(transform.position.y, lowerCameraLimit, upperCameraLimit),
            transform.position.z
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftCameraLimit, upperCameraLimit), new Vector2(rightCameraLimit, upperCameraLimit));
        Gizmos.DrawLine(new Vector2(rightCameraLimit, upperCameraLimit), new Vector2(rightCameraLimit, lowerCameraLimit));
        Gizmos.DrawLine(new Vector2(rightCameraLimit, lowerCameraLimit), new Vector2(leftCameraLimit, lowerCameraLimit));
        Gizmos.DrawLine(new Vector2(leftCameraLimit, lowerCameraLimit), new Vector2(leftCameraLimit, upperCameraLimit));
    }
}