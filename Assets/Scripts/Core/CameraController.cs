using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float upperDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;
    private float lookUpper;

    private void Update()
    {
        //Follow player
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y + lookUpper, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        lookUpper = Mathf.Lerp(lookUpper, (upperDistance * player.localScale.y), Time.deltaTime * cameraSpeed);
    }
}