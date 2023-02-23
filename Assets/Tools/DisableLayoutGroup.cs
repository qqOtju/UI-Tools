using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisableLayoutGroup : MonoBehaviour
{
    [SerializeField] private LayoutGroup layoutGroup;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        Destroy(layoutGroup);
        Destroy(this);
    }
}
