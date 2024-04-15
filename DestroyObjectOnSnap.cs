using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroyObjectOnSnap : MonoBehaviour
{
    public Transform respawnPoint; 
    public GameObject prefabSip; 
    [SerializeField]
    private GameObject stredTetiva;
    private XRSocketInteractor socketInteractor;
    private SipKontroler sipKontroler_ref; 
    private void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        Transform parent = transform.parent;
        while (parent != null)
        {
            sipKontroler_ref = parent.GetComponent<SipKontroler>();
            if (sipKontroler_ref != null)
            {
                break;
            }
            parent = parent.parent;
        }
    }
    private void Update()
    {
        if (socketInteractor.isSelectActive)
        {
            XRBaseInteractable interactable = socketInteractor.selectTarget;
            if (interactable != null)
            {
                Destroy(interactable.gameObject);
                stredTetiva.SetActive(true);
                VytvorSip();
                if (sipKontroler_ref != null)
                {
                    sipKontroler_ref.isArrow = true;
                }
            }
        }
    }
    private void VytvorSip()
    {
        GameObject respawnedObject = Instantiate(prefabSip, respawnPoint.position, respawnPoint.rotation);
        Rigidbody respawnedRigidbody = respawnedObject.GetComponent<Rigidbody>();
        if (respawnedRigidbody != null)
        {
            respawnedRigidbody.constraints = RigidbodyConstraints.None;
        }
        respawnedObject.transform.SetParent(respawnPoint, true);
    }
}