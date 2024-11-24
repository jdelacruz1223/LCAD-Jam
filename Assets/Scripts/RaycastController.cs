using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private HighlightInterface lastHighlighted = null;
    public GameObject target;
    // move mouse pointer raycast here later?
    public void CastCheck(RaycastHit hit)
    {
        target = hit.collider.gameObject;
        Debug.Log($"Hit: {hit.collider.name}");

        if(target.gameObject.CompareTag("SanityMod"))
        {
            HighlightInterface highlightable = target.GetComponent<HighlightInterface>();
            if(highlightable != null)
            {
                if(lastHighlighted != highlightable)
                {
                    UnhighlightLastObject();
                    highlightable.Highlight(true);
                    lastHighlighted = highlightable;
                }
            }
        }
        else
        {
            Debug.Log("unhighlight");
            UnhighlightLastObject();
        }
    }
    void UnhighlightLastObject()
    {
        if(lastHighlighted != null)
        {
            lastHighlighted.Highlight(false);
            lastHighlighted = null;
        }
    }
}
