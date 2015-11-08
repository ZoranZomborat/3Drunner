using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	public float moveSpeed;
	public float speedMultiplier;
	
	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;
	
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;
	
	public float jumpForce;
	public float speedMilestoneCounter;
	
	private float moveSpeedStore;
	
	
	public bool onGround;
	public LayerMask whatIsGround;
	
	public Transform groundCheck;
	public float groundCheckRadius;
	
	//public Collider2D groundCollider;
	public Animator myAnimator;

	private bool stopjump;
	private bool canDouble;
	
	public GameManager theGameManager;
	
	private Rigidbody2D myRigidBody;
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		
		//groundCollider = GetComponent<Collider2D> ();
		
		myAnimator = GetComponent<Animator> ();
		stopjump = true;
		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void Update () {
		//onGround = Physics2D.IsTouchingLayers (groundCollider, whatIsGround);
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		if (transform.position.x > speedMilestoneCount) {
			speedMilestoneCount+=speedIncreaseMilestone;
			speedIncreaseMilestone=speedIncreaseMilestone*speedMultiplier;
			moveSpeed=moveSpeed*speedMultiplier;
		}
		
		myRigidBody.velocity = new Vector2 (this.moveSpeed, myRigidBody.velocity.y);
		
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))) {

			if(onGround)
			{
			myRigidBody.velocity=new Vector2 ( myRigidBody.velocity.x,this.jumpForce);
			stopjump=false;
			}
			if(!onGround&&canDouble)
			{
				myRigidBody.velocity=new Vector2 ( myRigidBody.velocity.x,this.jumpForce);
				canDouble=false;
				stopjump=false;
			}

		}


	
		if (onGround) {

			canDouble=true;
		}

		myAnimator.SetFloat("Speed",myRigidBody.velocity.x);
		myAnimator.SetBool("Grounded",onGround);
	}
	
	void OnCollisionEnter2D(Collision2D other){
		
		if (other.gameObject.tag == "kill") {
			
			theGameManager.RestartGame();
			moveSpeed=moveSpeedStore;
			speedMilestoneCount=speedMilestoneCountStore;
			speedIncreaseMilestone=speedIncreaseMilestoneStore;
		}
		
	}
}
