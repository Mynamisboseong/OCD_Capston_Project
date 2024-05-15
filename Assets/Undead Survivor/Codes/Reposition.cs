using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Collider2D coll;
    

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        
        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;
        Vector3 playerDir = GameManager.Instance.player.inputVec;

        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float diffX = Mathf.Abs(dirX);
        float diffY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        switch (transform.tag)
        {
            case "Ground":
                if (Mathf.Abs(diffX - diffY) <= 0.1f)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;

            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                }
                break;
        }

        //if (!collision.CompareTag("Area"))
        //    return;

        
        //Vector3 playerPos = GameManager.Instance.player.transform.position;
        //Vector3 myPos = transform.position;
        //float diffX = Mathf.Abs(playerPos.x - myPos.x);
        //float diffY = Mathf.Abs(playerPos.y - myPos.y);


        //float dirX = playerDir.x <0 ? -1 : 1;
        //float dirY = playerDir.y <0 ? -1 : 1;

        //switch (transform.tag)
        //{
        //    case "Ground":
        //        if (diffX >diffY)
        //        {
        //            transform.Translate(Vector3.right * dirX * 40);
        //        }
        //        else if (diffX <diffY)
        //        {
        //            transform.Translate(Vector3.up * dirX * 40);
        //        }
        //        break;

        //    case "Enemy":

        //        break;
        //}
    }
}
