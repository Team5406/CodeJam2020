using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    private float moveSpeed;
    public static PlayerMovement Instance;
    public VectorValue startingPos;
    private SceneTransition sceneTransition;


    Animator animator;

    Vector2 lookDirection = new Vector2(1, 0);
    Vector2 movement;

    void Start()
    {
        animator = GetComponent<Animator>();
        moveSpeed = Constants.moveSpeed;

        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);



        sceneTransition = GameObject.FindGameObjectWithTag("transition").GetComponent<SceneTransition>();


    }


    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(movement.x, movement.y);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
