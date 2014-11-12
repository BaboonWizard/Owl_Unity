using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	//Global Variables

	[SerializeField]
	private float distanceAway;
	[SerializeField]
	private	float distanceUp;
	[SerializeField]
	private float smooth;
	[SerializeField]
	private Transform follow;
	[SerializeField] 
	private Vector3 offset = new Vector3(0f, 1.5f, 0f);


	private Vector3 LookDir;
	private Vector3 targetPosition;

	//Smoothing and damping
	private Vector3 velocityCamSmooth = Vector3.zero;
	[SerializeField]
	private float camSmoothDampTime = 0.1f;

	// Use this for initialization
	void Start () {
		follow = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate()
	{
		Vector3 characterOffset = follow.position + offset;

		LookDir = characterOffset - this.transform.position;
		LookDir.y = 0;
		LookDir.Normalize();
		Debug.DrawRay(this.transform.position, LookDir, Color.green);





		Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
		Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue);
		Debug.DrawLine(follow.position, targetPosition, Color.magenta);
		targetPosition = characterOffset + follow.up * distanceUp - LookDir * distanceAway;

		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

		smoothPosition(this.transform.position, targetPosition);

		transform.LookAt(follow);

		              }

	private void smoothPosition(Vector3 fromPos, Vector3 toPos)
	{
		this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime);
	}
}
