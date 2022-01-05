using UnityEngine;

public class RestartOnTrigger : MonoBehaviour
{
    [SerializeField]
    private LayerMask _PlayerLayerMask;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (_PlayerLayerMask == (_PlayerLayerMask | (1 << collider.gameObject.layer)))
        {
            GameController.Instance.Restart();
        }
    }
}
