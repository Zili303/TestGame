using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MapSettings mapSettings;

    private Player player;
    private PlayerInput playerInput;
    private PlayerLevelSystem playerLevelSystem;

    private float moveSpeed = 5;

    private void OnEnable() 
    {
        playerInput.OnPlayerMove += HandlePlayerMovement;
        playerLevelSystem.OnPlayerLevelUp += LevelUp;
    }

    private void OnDisable() 
    {
        playerInput.OnPlayerMove -= HandlePlayerMovement;
        playerLevelSystem.OnPlayerLevelUp -= LevelUp;
    }

    private void Awake()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
        playerLevelSystem = GetComponent<PlayerLevelSystem>();

        SetSpeed(player.Stats);
    }

    private void HandlePlayerMovement(Vector2 movement)
    {
        Vector3 movementDirection = new Vector3(movement.x, 0f, 0f);

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

        if (transform.position.x < -mapSettings.MapWide)
        {
            transform.position = new Vector3(-mapSettings.MapWide, transform.position.y, transform.position.z);
        }

        if (transform.position.x > mapSettings.MapWide)
        {
            transform.position = new Vector3(mapSettings.MapWide, transform.position.y, transform.position.z);
        }
    }

    private void LevelUp(PlayerStats playerLevel)
    {
        SetSpeed(playerLevel);
    }

    private void SetSpeed(PlayerStats playerStats)
    {
        moveSpeed = playerStats.MoveSpeed;
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
    }
}