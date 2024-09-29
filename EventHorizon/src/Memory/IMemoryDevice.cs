using System;
namespace EventHorizon.src.Memory
{
	public interface IMemoryDevice
	{
        public void UpdatePin(int ID, bool IsActive);

		public bool GetIsActive(int ID);
    }
}

