using UnityEngine;

public class CameraController : MonoBehaviour
{

    //Camera Speed
    [SerializeField] private float speed;
    private float currentPosX; //Tells camera to go to a position
    private Vector3 velocity = Vector3.zero;

    //Follow Player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        //Follow player
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z); //Camera will be ahead of player
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);

    }
    
}
