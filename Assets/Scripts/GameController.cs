using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerController _Player;

    [SerializeField]
    private Transform _SpawnPoint;

    public static GameController Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameControllers present in the scene. Only one instance is allowed per scene. Destroying this object.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void Restart()
    {
        Debug.Log("Restarting");

        // Reset player position/rotation
        _Player.transform.position = _SpawnPoint.position;
        _Player.transform.rotation = Quaternion.identity;
    }
}
