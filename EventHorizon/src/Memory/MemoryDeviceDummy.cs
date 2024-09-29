using System;
using Iot.Device.Mcp23xxx;

namespace EventHorizon.src.Memory
{
    public class MemoryDeviceDummy : IMemoryDevice
    {
		private bool IsActive = false;

		public bool GetIsActive(int ID)
		{
			return this.IsActive;
        }

		public void UpdatePin(int Id, bool isActive)
        {
            this.IsActive = isActive;

			Console.WriteLine(Id + " is now: " + IsActive);
        }
    }
}

