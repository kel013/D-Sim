using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : Interactable
{
    [SerializeField] Animation anim;
    [SerializeField] Fridge fridge;
    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Interact()
    {
        if (anim.isPlaying)
            return;

        if (!isOpen)
            StartCoroutine(OpenTheFreezer());
        else
            CloseFreezer();
    }

    IEnumerator OpenTheFreezer()
    {
        if (fridge.IsOpen())
        {
            fridge.CloseFridge();
            yield return new WaitForSeconds(anim["fridge_close"].length * anim["fridge_close"].speed);
        }
        else
            yield return 0;
        OpenFreezer();
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public void OpenFreezer()
    {
        anim.Play("freezer_open");
        isOpen = true;
    }

    public void CloseFreezer()
    {
        anim.Play("freezer_close");
        isOpen = false;
    }
}
