using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private List<GameObject> Cameras;
    [SerializeField] private UIManager uiManager;
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
        uiManager.ShowCharges(RecordingCharges);
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
        uiManager.HideCharges();
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
            uiManager.ShowCharges(RecordingCharges);
            Debug.Log("Recording Activated");
            nightVision = !nightVision;
            Cameras[currentCameraIndex].transform.GetChild(1).gameObject.SetActive(nightVision);
            Invoke("ToggleNightVision", RecordingTimer);
        }
        else
        {
            if (nightVision)
            {
                Debug.Log("Night Vision Deactivated");
                nightVision = false;
                Cameras[currentCameraIndex].transform.GetChild(1).gameObject.SetActive(false);
                CancelInvoke("ToggleNightVision");
            }
            else if (RecordingCharges <= 0)
            {
                Debug.Log("No Recording Charges Left");
            }


        }


    }
    
    public void SetChargeAmount(int amount)
    {
        RecordingCharges = amount; // Reset to default or set to a specific value
        uiManager.ShowCharges(RecordingCharges); // Update UI to reflect the new charge amount
    }
    public void AddCharges(int amount)
    {
        RecordingCharges += amount; // Return the current charge amount
        uiManager.ShowCharges(RecordingCharges); // Update UI to reflect the new charge amount
    }
}
