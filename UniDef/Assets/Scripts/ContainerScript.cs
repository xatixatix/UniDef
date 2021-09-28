using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    void LateUpdate()
    {
        if (transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
