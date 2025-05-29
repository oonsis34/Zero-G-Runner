using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform player; 
    public float followSpeed = 2f; 

    private Vector3 offset; 

    void Start()
    {
        if (player != null)
        {
            offset = transform.position - player.position; 
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            
            Vector3 targetPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);

            
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
