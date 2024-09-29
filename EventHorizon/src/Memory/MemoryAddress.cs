using System;
using EventHorizon.src.Memory;

public class MemoryAddress

{
    public int Address {get;}
    public String Name {get; set;}

    public bool IsActive { get; set; }
    IMemoryDevice Device;
    public bool IsEditing { get; set; } = false;

    public MemoryAddress(int addr, IMemoryDevice dev)
    {
        Address = addr;
		Device = dev;
		Name =  Device.GetType().Name + ""+ addr.ToString();
        IsActive = Device.GetIsActive(Address);
    }

    public void Update(bool isActive)
    {
        this.IsActive = isActive;
        Device.UpdatePin(Address, isActive);
    }

    public bool GetActivationStatus()
    { return Device.GetIsActive(Address); }


}


