using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField] float smoothSpeed = 0.125f;

    //bool followCharacter = true;
    //bool transitionCamera = false;


    //bool transitionTeleported = false;
    //Transform beforeTransition;
    [SerializeField] float transitionSpeed = 1.7f;

    [SerializeField] CinemachineVirtualCamera movingOut;
    [SerializeField] CinemachineVirtualCamera movingIn;
    [SerializeField] CinemachineVirtualCamera transitionCamera;

    //private void FixedUpdate()
    //{
        //if (followCharacter)
        //{
        //    Vector3 desiredPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        //    Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        //    transform.position = smoothedPos;
        //    transform.LookAt(target.transform);
        //}
    //}

    public void FlipCamera()
    {
        //Debug.Log("camera flip called");
        //followCharacter = false;
        //transitionCamera = true;
        //beforeTransition = transform;
        if (transform.position.z < 0)
        {
            StartCoroutine(TransitionCamera_AB(true));
        }
        else
        {
            StartCoroutine(TransitionCamera_AB(false));
        }
    }

    private IEnumerator TransitionCamera_AB(bool transitionAB)
    {
        var virtualCameras = FindObjectsOfType<CinemachineVirtualCamera>();
        foreach (var camera in virtualCameras)
        {
            if (camera == transitionCamera)
            {
                camera.Priority += 2;
            }
        }

        yield return new WaitForSeconds(transitionSpeed);



        if (transitionAB)
        {
            foreach (var camera in virtualCameras)
            {
                if (camera == movingIn)
                {
                    camera.Priority += 4;
                }
            }
        }
        else
        {
            foreach (var camera in virtualCameras)
            {
                if (camera == movingOut)
                {
                    camera.Priority += 4;
                }
            }
        }
    }
}

        //while (true)
        //{
        //    transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right, 1)
        //    transform.LookAt(target.transform);
        //}
        //yield return;

        //if (transform.position.z > 0.1f)
        //{
        //    Debug.Log("move in");
        //    transform.position += (Vector3.forward + Vector3.right) * Time.deltaTime * transitionSpeed;
        //    transform.LookAt(target.transform);
        //}
        //else if (!transitionTeleported)
        //{
        //    Debug.Log("teleport");
        //    transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
        //}
        //else if (transform.position.z < 0f && transform.position.z > -beforeTransition.position.z)
        //{
        //    transform.position += (Vector3.back + Vector3.left) * Time.deltaTime * transitionSpeed;
        //    transform.LookAt(target.transform);
        //    Debug.Log("move out");
        //}
        //else if (transform.position.z < -beforeTransition.position.z)
        //{
        //    beforeTransition = null;
        //    followCharacter = true;
        //    transitionCamera = false;
        //}