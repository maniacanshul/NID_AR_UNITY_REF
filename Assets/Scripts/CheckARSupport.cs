using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class CheckARSupport : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private GameObject installAgainButton;
    [SerializeField] private ARSessionHandler sessionHandler;
    private IEnumerator Start()
    {
        installAgainButton.SetActive(false);
        loadingText.text = "Check Availability";

        yield return ARSession.CheckAvailability();

        if (ARSession.state == ARSessionState.NeedsInstall)
        {
            loadingText.text = "Installing";
            yield return ARSession.Install();
        }

        if (ARSession.state == ARSessionState.Ready || ARSession.state == ARSessionState.SessionInitializing || ARSession.state == ARSessionState.SessionTracking)
        {
            loadingText.text = "";
            installAgainButton.SetActive(false);
            sessionHandler.ARSessionEstablished();
        }
        else
        {
            loadingText.text = ARSession.state.ToString();
            switch (ARSession.state)
            {
                case ARSessionState.Unsupported:
                    {
                        break;
                    }
                case ARSessionState.NeedsInstall:
                    {
                        installAgainButton.SetActive(true);
                        StartCoroutine(Start());
                        break;
                    }
            }
        }
    }

}
