using UnityEngine;

public class ManagerTester : MonoBehaviour
{
    public CameraManager cameraManager;
    public bool camerasActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camerasActive = !camerasActive;
            if (camerasActive)
            {
                cameraManager.GetComponent<CameraManager>().EnterCameras(0);
            }
            else
            {
                cameraManager.GetComponent<CameraManager>().ExitCameras();
            }

        }
        if (camerasActive)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                cameraManager.GetComponent<CameraManager>().RewindCameraIndex();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                cameraManager.GetComponent<CameraManager>().AdvanceCameraIndex();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                cameraManager.GetComponent<CameraManager>().SwitchToCamera(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                cameraManager.GetComponent<CameraManager>().SwitchToCamera(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                cameraManager.GetComponent<CameraManager>().SwitchToCamera(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                cameraManager.GetComponent<CameraManager>().SwitchToCamera(3);
            }
        }
    }
}
    

