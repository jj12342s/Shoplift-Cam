using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private List<GameObject> Cameras;
    public int currentCameraIndex;
    public bool nightVision = false;
    public int RecordingCharges = 3;
    public float RecordingTimer = 5f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created  
    void Start()
    {
       foreach (GameObject camera in Cameras)
        {
            camera.SetActive(false);
        }
    }

    [SerializeField]
    public void EnterCameras(int cameraIndex = 0)
    {
        Debug.Log("Entering cameras");
        SwitchToCamera(cameraIndex);
    }    
    public void SwitchToCamera(int cameraIndex)
    {

        Debug.Log("Switching to camera: " + cameraIndex);
        currentCameraIndex = cameraIndex;
        // Deactivate all cameras
        foreach (GameObject camera in Cameras)
        {
            camera.SetActive(false);
            mainCamera.SetActive(false);
        }
        // Activate the selected camera
        Cameras[cameraIndex].SetActive(true);
    }
    public void SwitchToMainCamera()
    {
        if (nightVision)
        {
            ToggleNightVision(); // Turn off night vision if it's active
        }
        foreach (GameObject camera in Cameras)
        {
            camera.SetActive(false);
        }
       
        mainCamera.SetActive(true);
        currentCameraIndex = -1;
    }
    public void ExitCameras()
    {
        Debug.Log("Exiting cameras");
        SwitchToMainCamera();
        //Something special can be done here when exiting cameras like playing a sound or allowing a jumpscare
    }
    public void AdvanceCameraIndex()
    {
        // If night vision is not active, allow camera index change
        if (!nightVision)
        {
            currentCameraIndex += 1;
            // Loop To First Camera if far enough
            if (currentCameraIndex >= Cameras.Count)
            {
                currentCameraIndex = 0;
            }
            SwitchToCamera(currentCameraIndex);
        }
        else
        {
            Debug.Log("Cannot change camera while night vision is active");
        }
    }
    public void RewindCameraIndex()
    {
        // If night vision is not active, allow camera index change
        if (!nightVision)
        {
            currentCameraIndex -= 1;
            // Loop To Last Camera if far enough
            if (currentCameraIndex < 0)
            {
                currentCameraIndex = Cameras.Count - 1;
            }
            SwitchToCamera(currentCameraIndex);
        }
        else
        {
            Debug.Log("Cannot change camera while night vision is active");
        }
        
    }

    public void ToggleNightVision()
    {
        if (RecordingCharges > 0 && !nightVision)
        {
            RecordingCharges -= 1;
            Debug.Log("Recording Activated");
            nightVision = !nightVision;
            Cameras[currentCameraIndex].transform.GetChild(0).gameObject.SetActive(nightVision);
            Invoke("ToggleNightVision", RecordingTimer);
        }
        else
        {
            if (nightVision)
            {
                Debug.Log("Night Vision Deactivated");
                nightVision = false;
                Cameras[currentCameraIndex].transform.GetChild(0).gameObject.SetActive(false);
                CancelInvoke("ToggleNightVision");
            }
            else if (RecordingCharges <= 0)
            {
                Debug.Log("No Recording Charges Left");
            }


        }
        

    }

}
