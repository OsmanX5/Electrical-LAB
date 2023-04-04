using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DirectAndRayInteractorSwitch : MonoBehaviour
{
    public InputActionReference TogleButton;
    public GameObject DirectInteractor;
    public GameObject RayInteractor;
    bool isDirect = true;
    private void Start()
    {
        isDirect = true;
        SwitchToDirect();
    }
    void Update()
    {
        if (TogleButton.action.triggered)
        {
            if (isDirect) SwitchToRay();
            else SwitchToDirect();
            isDirect = !isDirect;
        }
    }
    void SwitchToRay()
    {
        DirectInteractor.SetActive(false);
        RayInteractor.SetActive(true);
    }
    void SwitchToDirect()
    {
        RayInteractor.SetActive(false);
        DirectInteractor.SetActive(true);
    }
    
}
