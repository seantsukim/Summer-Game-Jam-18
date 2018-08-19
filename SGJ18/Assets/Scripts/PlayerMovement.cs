using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public enum MovementMode
    {
        DISCRETE,
        CONTINUOUS
    }
    public MovementMode movementMode;

    public AnimationCurve jumpCurve;
    public float jumpDuration;

    public GameObject shadowObj;

    private Rigidbody2D rb2D;
    private Vector2 prevVelocity;

    private Vector2 lastMoveDir;

    private float jumpDist;
    private float jumpMoveRate;
    private float jumpTime;
    public bool isJumping;
    private IEnumerator jumpCoroutine;

    private Vector2 jumpStartPos;
    private Vector2 desiredPos;  

	// Use this for initialization
	void Start ()
    {
        shadowObj.SetActive(false);

        rb2D = GetComponent<Rigidbody2D>();
        prevVelocity = Vector2.zero;

        lastMoveDir = Vector2.right;

        Keyframe[] keys = jumpCurve.keys;
        jumpDist = keys[keys.Length - 1].time;
        jumpMoveRate = jumpDist / jumpDuration;

        isJumping = false;
        jumpCoroutine = JumpMove();
    }

    void FixedUpdate()
    {
        if(isJumping)
        {
            rb2D.MovePosition(desiredPos);
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 velocity = new Vector2(horizontal, vertical).normalized * speed;
            if(velocity != Vector2.zero)
            {
                lastMoveDir = velocity.normalized;
            }

            if (movementMode == MovementMode.CONTINUOUS)
            {
                velocity = velocity != Vector2.zero ? velocity : prevVelocity;
            }
            rb2D.MovePosition(rb2D.position + (velocity * Time.fixedDeltaTime));
            prevVelocity = velocity;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            shadowObj.SetActive(true);
            isJumping = true;
            jumpTime = 0f;
            jumpDist = 0f;
            jumpStartPos = rb2D.position;
            StartCoroutine(jumpCoroutine);
        }
    }

    IEnumerator JumpMove()
    {
        while (jumpTime < jumpDuration)
        {
            jumpTime += Time.deltaTime;
            jumpDist += jumpMoveRate * Time.deltaTime;

            desiredPos = rb2D.position;
            Debug.Log(desiredPos + "|" + lastMoveDir * jumpMoveRate * Time.deltaTime);
            Debug.Log(lastMoveDir * jumpMoveRate * Time.deltaTime);
            desiredPos += lastMoveDir * jumpMoveRate * Time.deltaTime;
            desiredPos.y = jumpStartPos.y + jumpCurve.Evaluate(jumpDist);
            Debug.Log(desiredPos.y);
            yield return new WaitForEndOfFrame();
        }
        shadowObj.SetActive(false);
        isJumping = false;
        jumpCoroutine = JumpMove();
    }
}
