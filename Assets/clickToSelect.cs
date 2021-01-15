using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickToSelect : MonoBehaviour {

    private GameObject target; //클릭한곳
    private GameObject critPlate; //찔리면 아픈곳
    private GameObject sword; //칼

    // Use this for initialization
    void Start () {
        target = null;
        string critPoint = Random.Range(0,44).ToString(); //0~44까지 랜덤으로 정함.
        critPoint = "Plate (" + critPoint + ")";
        critPlate = GameObject.Find(critPoint); // critPlate는 critPoint를 참조해서 만듬.
        Debug.Log("[Start]critPlate : " + critPlate);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))//If user cliked something
        {
            target = GetClickedObject(); // load clicked object(클릭한 오브젝트를 target에 할당)
            if (target.name.StartsWith("Plate")) // If target's name is startwith "Plate"(타겟이름이 Plate로 시작되는 거면)
            {
                if (target.GetComponent<MeshRenderer>().material.color == new Color(1, 1, 1, 1))// If it's White(타겟의 색이 흰색이면)
                {
                    target.GetComponent<MeshRenderer>().material.color = new Color(255, 255, 0); // change to Yellow(타겟의 색을 노랑으로)
                }
                else if (target.GetComponent<MeshRenderer>().material.color == new Color(255, 255, 0)) // If it's Yellow(타겟의 색을 노랑이면)
                {
                    sword = target.transform.Find("sword").gameObject; // Plate의 child인 sword를 설정.
                    sword.SetActive(true); // 원래 sword는 안 보이는데 이를 보이게 함.
                    if (target == critPlate)// 아픈곳이라면
                    {
                        target.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0); // 아무튼 칼꼽았을때 아픈곳이라면 검은색으로 바꿈
                        target = GameObject.Find("pirateHead"); // 타겟을 머리로 바꿈
                        Blow(target); // 뽈롱~
                        sword.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 255); // 아픈곳에 칼 꼽았으면, 칼의 색을 청록색으로 바꿈.
                    } 
                    else //아픈곳이 아니었다면
                    {
                        target.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0); // change to Red(타겟의 색을 빨강으로)
                    }
                }
            }
        }
    }

    private GameObject GetClickedObject()
    {
        RaycastHit hit; // Raycast = 마우스 포인터에서 빔을 쭉 쏴서, 첫번째로 맞은거 가 클릭한것이라고 판단함. 
        GameObject target = null; // initialize target(타겟을 초기화)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 라이브러리 갖다썻음

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit))) //Raycast = 마우스 포인터에서 빔을 쭉 쏴서, 첫번째로 맞은거 가 클릭한것이라고 판단함. 
        {
            target = hit.collider.gameObject; // clicked object assign to target(타겟에 클릭한 오브젝트를 할당)
        }
        Debug.Log("[GetClickedObject]target : " + target);
        return target; //syntax == semantic(리턴 타겟)
    }

    private GameObject Blow(GameObject something) {
        something.GetComponent<Rigidbody>().AddForce(-50, 1000, 50); // give force to something(something에 [X:500,Y:1000,Z:500] 의 힘을 가함)
        return null; // 이거 안하면 뭐라고 함
    }
}