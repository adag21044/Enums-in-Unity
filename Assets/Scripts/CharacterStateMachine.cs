using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private ChacterStates currentState;
    private float idleTimer = 0f;
    private float idleTimeThreshold = 1f; // 1 saniye

    void Start()
    {
        currentState = ChacterStates.Idle;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Duruma göre işlemleri gerçekleştir
        switch (currentState)
        {
            case ChacterStates.Idle:
                Idle();
                break;

            case ChacterStates.Attack:
                Attack();
                break;

            case ChacterStates.Block:
                Block();
                break;
            
            default:
                Idle();
                break;        
        }

        // Durumu kontrol etmek için örnek bir giriş yöntemi, isteğe bağlı olarak değiştirilebilir
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetState(ChacterStates.Attack);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetState(ChacterStates.Block);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetState(ChacterStates.Idle);
        }
    }

    void SetState(ChacterStates newState)
    {
        currentState = newState;
    }

    void Idle()
    {
        idleTimer += Time.deltaTime;

        // Her 1 saniyede bir sprite değiştir
        if (idleTimer >= idleTimeThreshold)
        {
            for (int i = 0; i < 8; i++)
            {
                spriteRenderer.sprite = sprites[i];
            }

            idleTimer = 0f; // Sayaçı sıfırla
        }
    }

    void Attack()
    {
        spriteRenderer.sprite = sprites[1]; // Attack sprite'ı
    }

    void Block()
    {
        spriteRenderer.sprite = sprites[2]; // Block sprite'ı
    }

    // Enum tanımı
    enum ChacterStates
    {
        Idle,
        Attack,
        Block
    }
}
