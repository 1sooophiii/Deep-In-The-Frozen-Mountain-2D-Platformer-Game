using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private GameObject playerTransformTera;
    [SerializeField] private GameObject playerTransformKev;
    private Transform playerTransform;
    [SerializeField] private float boundX = 0.5f;
    //[SerializeField] private float boundY = 0.5f;
    private Vector2 cameraMovement;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = new Vector2(0, 0);
        playerTransform = playerTransformTera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransformTera.activeSelf)
        {
            playerTransform = playerTransformTera.transform;
        } else if (playerTransformKev.activeSelf)
        {
            playerTransform = playerTransformKev.transform;
        }

        if (playerTransform.position.x - transform.position.x > boundX)
        {
            cameraMovement.x = playerTransform.position.x - transform.position.x - boundX;
        }
        else if(playerTransform.position.x - transform.position.x < -boundX)
        {
            cameraMovement.x = playerTransform.position.x - transform.position.x + boundX;
        }
        else
        {
            cameraMovement.x = 0;
        }

        /*
        if (playerTransform.position.y - transform.position.y > boundY)
        {
            cameraMovement.y = playerTransform.position.y - transform.position.y - boundY;
        }
        else if (playerTransform.position.y - transform.position.y < -boundY)
        {
            cameraMovement.y = playerTransform.position.y - transform.position.y + boundY;
        }
        else
        {
            cameraMovement.y = 0;
        }
        */
        

        transform.Translate(cameraMovement);
    }
}
