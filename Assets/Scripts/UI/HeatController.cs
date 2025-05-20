using UnityEngine;
using UnityEngine.UIElements;

public class HeatController : MonoBehaviour
{
    [SerializeField] public PlayerShooting shooting;

    public void OnEnable()
    {
        VisualElement root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        VisualElement heat = root.Q<VisualElement>("Heat");
        heat.dataSource = shooting;
    }


}
