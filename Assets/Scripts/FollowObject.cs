using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    private Transform _FollowObject;

    [SerializeField]
    private Vector3 _Offset;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = _FollowObject.position + _Offset;
    }
}
