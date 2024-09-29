using EventHorizon.src.Memory;
using EventHorizon;
using Iot.Device.Mcp23xxx;
using System.Collections;
using System.Device.I2c;
using System.Runtime.InteropServices;

public class MemoryController
{
    private ArrayList Addresses;

    public MemoryController()
    {
        Console.WriteLine("Starting Memory");
        Addresses = new ArrayList(128);

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
            (RuntimeInformation.ProcessArchitecture == Architecture.Arm ||
            RuntimeInformation.ProcessArchitecture == Architecture.Arm64))
        {
            genrateAddresses();
        }
        else
        {
            Console.WriteLine("GPIO/I2C not supported on this platform. Simulating devices...");
            Settings.getInstance().SimulateI2CDevices = true;
            if (Settings.getInstance().SimulateI2CDevices)
            {
                SimulateDevices();
            }
        }

        Console.WriteLine("finished initializing Memory addresses");
    }

    private void genrateAddresses()
    {
        for (int i = 0; i < 8; i++)
        {
            try
            {
                IMemoryDevice dev;
                I2cConnectionSettings cset = new I2cConnectionSettings(1, 32 + i);
                I2cDevice idev = I2cDevice.Create(cset);
                Mcp23017 mcp23017 = new Mcp23017(idev);
                mcp23017.WriteByte(Register.IODIR, 0b0000_0000, Port.PortA);
                mcp23017.WriteByte(Register.IODIR, 0b0000_0000, Port.PortB);
                dev = new MemoryDevice(mcp23017);
                generateMemoryAddr(i, dev);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing I2C device at address {32 + i}: {ex.Message}");
                if (Settings.getInstance().SimulateI2CDevices)
                {
                    Console.WriteLine("Creating dummy device for address " + (32 + i));
                    generateMemoryAddr(i, new MemoryDeviceDummy());
                }
                else
                {
                    Console.WriteLine("Could not find controller at address: " + (32 + i));
                }
            }
        }
    }

    private void SimulateDevices()
    {
        for (int i = 0; i < 8; i++)
        {
            generateMemoryAddr(i, new MemoryDeviceDummy());
        }
    }

    private void generateMemoryAddr(int i, IMemoryDevice dev)
    {
        for (int a = 0; a < 16; a++)
        {
            int addr = (16 * i) + a;
            Console.WriteLine($"Generating memory address {addr}");
            Addresses.Add(new MemoryAddress(addr, dev));
        }
    }

    public ArrayList GetMemoryAddresses()
    {
        return Addresses;
    }

    public MemoryAddress GetMemoryAddressForIndex(int i)
    {
        if (i <= 128)
        {
            foreach (MemoryAddress a in Addresses)
            {
                if (a.Address == i)
                {
                    return a;
                }
            }
        }

        Console.WriteLine($"Memory address not in range {i}");
        throw new Exception($"Memory address not in range {i}");
    }
}
