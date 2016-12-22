//using UnityEngine;
//using System.Collections;

//public class Enemy : MonoBehaviour {

//    // Use this for initialization
//    GameObject pathGO;
//    Transform targetPathNode;
//    int pathNodeIndex = 0;
//    float speed = 5f;
//    public int health = 3;
//    void Start () {
//        pathGO = GameObject.Find("Path");
//	}

//    void GetNextPathNode()
//    {
//        if(pathNodeIndex < pathGO.transform.childCount)
//        {
//            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
//            pathNodeIndex++;
//        }
//        else
//        {
//            targetPathNode = null;
//            ReachedGoal();
            
//        }
        
//    }
	
//	// Update is called once per frame
//	void Update () {
//	    if(targetPathNode == null)
//        {
//            GetNextPathNode();
//            if(targetPathNode == null)
//            {
//                //enemy je na cilju
//                ReachedGoal();
//                return;
//            }
//        }

        
//        Vector3 dir = targetPathNode.position - this.transform.localPosition;
//        float distThisFrame = speed * Time.deltaTime;
//        if(dir.magnitude <= distThisFrame)
//        {
//            targetPathNode = null;
//        }
//        else
//        {
//            transform.Translate(dir.normalized * distThisFrame);
//            //this.transform.rotation =  Quaternion.LookRotation(dir);
//        }
        
//	}
//   void ReachedGoal()
//    {
//        Destroy(gameObject);
//    }

//}
