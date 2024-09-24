using UnityEngine;

public class ViewSwitch : MonoBehaviour
{
    private Model[] _viewVariants;

    public int VariantsCount { get { return _viewVariants.Length; } }

    private void Awake()
    {
        _viewVariants = GetComponentsInChildren<Model>();

        foreach (Model t in _viewVariants)
        {
            t.gameObject.SetActive(false);
        }

    }

    public Model GetModel(int viewIndex)=> _viewVariants[viewIndex];
}
