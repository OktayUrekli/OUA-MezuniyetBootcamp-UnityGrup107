using UnityEngine;
using DG.Tweening;
public class TreasureChest : MonoBehaviour
{
    public static TreasureChest instance;
    public Animator animator;
    public Transform lid;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OpenChest()
    {
        lid.DOLocalRotate(new Vector3(-90f, 0, 0), 1f).SetEase(Ease.Linear);
    }
}
