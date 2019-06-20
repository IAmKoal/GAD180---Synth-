using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPortal : MonoBehaviour
{
    public SpawningEngine portalStat;
    public Vector3 currentPortalPos;

    public Transform playerPos;

    public GameObject arrowPointer;

    private void Update()
    {
        currentPortalPos = portalStat.curPortal.transform.position; //- Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log(currentPortalPos);
        //currentPortalPos.z = 0;
        //arrowPointer.transform.LookAt(currentPortalPos);
        Vector2 pPos = playerPos.transform.position;
        var angle = Mathf.Atan2(pPos.y-currentPortalPos.y, pPos.x-currentPortalPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 180f, Vector3.forward);
    }
}
