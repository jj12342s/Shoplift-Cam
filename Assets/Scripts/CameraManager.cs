using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private List<GameObject> Cameras;
    public int currentCameraIndex;
    public PostProcessVolume nightVision;
    public PostProcessVolume normalVision;


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
        currentCameraIndex += 1;
        // Loop To First Camera if far enough
        if (currentCameraIndex >= Cameras.Count)
        {
            currentCameraIndex = 0; 
        }
        SwitchToCamera(currentCameraIndex);
    }
    public void RewindCameraIndex()
    {
        currentCameraIndex -= 1;
        // Loop To Last Camera if far enough
        if (currentCameraIndex < 0)
        {
            currentCameraIndex = Cameras.Count - 1; 
        }
        SwitchToCamera(currentCameraIndex);
    }

    public void ToggleNightVision()
    {
        nightVision.enabled = !nightVision.enabled;
        normalVision.enabled = !nightVision.enabled;
    }

}
