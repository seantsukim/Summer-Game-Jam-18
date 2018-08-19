using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    public float rotateSpeed;
    public float moveSpeed;
    public enum MovementMode
    {
        DISCRETE,
        CONTINUOUS
    }
    public MovementMode movementMode;

    public AnimationCurve jumpCurve;
    public float jumpDuration;

    private List<GameObject> shadowObjs;

    private SpriteRenderer spriteRenderer;

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
    private float desiredRot;

    private bool lastMovingRight;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        shadowObjs = new List<GameObject>();
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach(Transform child in allChildren)
        {
            if(child.gameObject.name.Contains("Shadow"))
            {
                shadowObjs.Add(child.gameObject);
                child.gameObject.SetActive(false);
            }
        }

        rb2D = GetComponent<Rigidbody2D>();
        prevVelocity = Vector2.zero;

        lastMoveDir = Vector2.right;

        Keyframe[] keys = jumpCurve.keys;
        jumpDist = keys[keys.Length - 1].time;
        jumpMoveRate = jumpDist / jumpDuration;

        isJumping = false;
        jumpCoroutine = JumpMove();

        lastMovingRight = true;
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

            if(horizontal < 0f && lastMovingRight)
            {
                lastMovingRight = false;
                FlipDragonHorizontal();
            }
            else if(horizontal > 0 && !lastMovingRight)
            {
                lastMovingRight = true;
                FlipDragonHorizontal();
            }

            Vector2 velocity = new Vector2(horizontal, vertical).normalized * moveSpeed;
            if(velocity != Vector2.zero)
            {
                lastMoveDir = velocity.normalized;
            }

            if (movementMode == MovementMode.CONTINUOUS)
            {
                velocity = velocity != Vector2.zero ? velocity : prevVelocity;
            }
            rb2D.MovePosition(rb2D.position + (velocity * Time.fixedDeltaTime));
            desiredRot = Mathf.Rad2Deg * Mathf.Acos(Vector2.Dot(Vector2.right, lastMoveDir));
            Vector3 crossProduct = Vector3.Cross(Vector3.right, new Vector3(lastMoveDir.x, lastMoveDir.y, 0f));
            if(crossProduct.z < 0f)
            {
                desiredRot *= -1;
            }
            rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation, desiredRot, Time.deltaTime * rotateSpeed));
            prevVelocity = velocity;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            ActivateShadows(true);
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
            desiredPos += lastMoveDir * jumpMoveRate * Time.deltaTime;
            desiredPos.y = jumpStartPos.y + jumpCurve.Evaluate(jumpDist);
            yield return new WaitForEndOfFrame();
        }
        ActivateShadows(false);
        isJumping = false;
        jumpCoroutine = JumpMove();
    }

    void FlipDragonHorizontal()
    {
        spriteRenderer.flipY = !spriteRenderer.flipY;
        Vector3 pos;
        foreach (GameObject shadow in shadowObjs)
        {
            pos = shadow.transform.localPosition;
            pos.y *= -1;
            shadow.transform.localPosition = pos;
        }
    }

    public void ActivateShadows(bool active)
    {
        foreach(GameObject shadow in shadowObjs)
        {
            shadow.SetActive(active);
        }
    }
}
