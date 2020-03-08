using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaHammer : ItemClass
{
    
    private GameObject playerCont;
    private GameObject curPlayCont;
    private PlayerStats stats;
    

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = UsePlasmaHammer;
        playerCont = GameObject.FindWithTag("Player");
        setHasIndicator(true);
        GetSpellIndicator().SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetSpellIndicator().GetComponent<SpellIndicator>().setAimDiriection(playerCont.GetComponent<MainControls>().getRSDirection());
        GetSpellIndicator().GetComponent<SpellIndicator>().setOrigin(playerCont.transform.position);
    }

    public void UsePlasmaHammer()
    {

    }

}
