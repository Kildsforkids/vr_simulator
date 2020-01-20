using UnityEngine;

public class ContainerController : MonoBehaviour
{
    public bool isActive;
    public GameController.ObjectType type;
    public ContainerController[] connectedContainers;
    public ContainerController[] conditionObjects;
    public Material redTransparentMat;
    public Material defaultTransparent;

    private MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    public bool isBlocked()
    {
        foreach (var container in connectedContainers)
        {
            if (container.isActive) return true;
        }
        return false;
    }

    public bool isConditionObjectsActive()
    {
        foreach (var container in conditionObjects)
        {
            if (!container.isActive) return false;
        }
        return true;
    }

    public void EnableMesh(bool enable)
    {
        
        if (transform.childCount > 0)
        {
            foreach (var mesh in transform.GetComponentsInChildren<MeshRenderer>())
            {
                //if (enable && !isConditionObjectsActive())
                //{
                //    mesh.material = redTransparentMat;
                //}
                //else
                //{
                //    mesh.material = defaultTransparent;
                //}
                if (isConditionObjectsActive())
                {
                    mesh.enabled = enable;
                }
                //mesh.enabled = enable;
            }
        }
        else
        {
            if (isConditionObjectsActive())
            {
                mesh.enabled = enable;
            }
            //if (enable && !isConditionObjectsActive())
            //{
            //    mesh.material = redTransparentMat;
            //}
            //else
            //{
            //    mesh.material = defaultTransparent;
            //}
            //mesh.enabled = enable;
        }
    }
}
