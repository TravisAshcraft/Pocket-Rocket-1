using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainShip : MonoBehaviour
{
    public GameObject greenShip, wierdShip, ufoShip;
    private MeshRenderer myMesh;
    private readonly string selectedShip = "SelectedShip";
    private void Awake()
    {
        myMesh = this.GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        int getShip;

        getShip = PlayerPrefs.GetInt(selectedShip);

        switch (getShip)
        {
            case 1:
                GameObject wierd = wierdShip;
                break;
            case 2:
                GameObject ufo = ufoShip;
                break;
            case 3:
                GameObject green = greenShip;
                break;
        }
    }

}
