using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : UIBehaviour
{
    public bool Visible {
        get => gameObject.activeSelf;
    }

    public virtual void Hide() {
        gameObject.SetActive(false);
    }

    public virtual void Show() {
        gameObject.SetActive(true);
    }
}