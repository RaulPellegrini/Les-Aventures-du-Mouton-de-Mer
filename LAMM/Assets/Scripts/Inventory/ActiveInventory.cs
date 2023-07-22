using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : Singleton<ActiveInventory>
{
    [SerializeField] GameObject invetorySlot1;
    [SerializeField] GameObject invetorySlot2;
    [SerializeField] GameObject invetorySlot3;

    static private bool isTheKnightAlive = true;
    static private bool isTheMushroomAlive = false;
    static private bool isTheDemonAlive = false;
    public bool endGame = false;
    
    private int activeSlotIndexNum = 0;
    private PlayerControls playerControls;


    protected override void Awake()
    {
        base.Awake();
        playerControls = new PlayerControls();

    }

    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
        if (!isTheDemonAlive)
        {
            endGame = true;
        }
    }

    public void MushroomBossInventory()
    {
        transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        isTheMushroomAlive = false;
    }

    public void KnightBossInventory()
    {
        //vampireSword = transform.GetChild(0).GetComponentsInChildren<VampireSword>();
        //invetorySlot2.SetActive(true);
        //invetorySlot2 = childTransform.GetComponentInChildren<InventorySlot>().
        transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
        isTheKnightAlive = false;

    }

    public void DemonBossInventory()
    {
        transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
        isTheDemonAlive = false;
    }

    public void DropInactive()
    {
        gameObject.SetActive(false);
    }

    public void EquipStartingWeapon()
    {
        ToggleActiveHightlight(0);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void ToggleActiveSlot(int numValue) 
    {
        ToggleActiveHightlight(numValue -1);
    
    }

    private void ToggleActiveHightlight(int indexNum)
    {
        if (indexNum == 2 && isTheKnightAlive)
        {
            return;
        }

        if (indexNum == 1  && isTheMushroomAlive)
        {
            return;
        }

        if (indexNum == 3 && isTheDemonAlive)
        {
            return;
        }
        
        activeSlotIndexNum = indexNum;
        
        foreach (Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);

        ChangeActiveWeapon();
    }

    private void ChangeActiveWeapon()
     {

         if (ActiveWeapon.Instance.CurrentActiveWeapon != null)
         {
             Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject);
         }

         if (transform.GetChild(activeSlotIndexNum).GetComponentInChildren<InventorySlot>().GetWeaponInfo() == null)
         {
             ActiveWeapon.Instance.WeaponNull();
             return;
         }

         Transform childTransform = transform.GetChild(activeSlotIndexNum);
         InventorySlot inventorySlot = childTransform.GetComponentInChildren<InventorySlot>();
         WeaponInfo weaponInfo = inventorySlot.GetWeaponInfo();
         GameObject weaponToSpawn = weaponInfo.weaponPrefab;
   

        GameObject newWeapon = Instantiate(weaponToSpawn, ActiveWeapon.Instance.transform.position, Quaternion.identity);
        ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, 0);
        newWeapon.transform.parent = ActiveWeapon.Instance.transform;
        ActiveWeapon.Instance.NewWeapon(newWeapon.GetComponent<MonoBehaviour>());
    }

    
}
