using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float CameraStartPoint;
    public float CameraEndPoint;

    bool isMovingRight = true;
    public float Duration;
    float testing = 0;

    private void Update()
    {
        testing += Time.deltaTime;
        Debug.Log(testing);
        if (transform.position.x >= CameraEndPoint)
        {
             StartCoroutine(moveCamera(false));
        }
        else if (transform.position.x <= CameraStartPoint)
        {
             StartCoroutine(moveCamera(true));
        }
    }

    IEnumerator moveCamera(bool moveRight)
    {
        float currentTime = 0;
        while (currentTime <= Duration + 0.1)
        {
            if (moveRight)
            {
                transform.position = new Vector3(Mathf.Lerp(CameraStartPoint, CameraEndPoint, currentTime / Duration), transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(Mathf.Lerp(CameraEndPoint, CameraStartPoint, currentTime / Duration), transform.position.y, transform.position.z);
            }
            currentTime += Time.deltaTime;
            Debug.Log(currentTime);
            yield return null;
        }
        currentTime = 0;
    }
}
