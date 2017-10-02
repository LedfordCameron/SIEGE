#pragma strict
static var myDistance:float=5;

function Start () {
	
}

function Update () {
	var hit:RaycastHit;
	if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),hit)){
	myDistance = hit.distance;
	}
}
