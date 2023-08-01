using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Chrones.Cmr.MemoryManagement
{
    public class Memory
    {
        #region Import
        [DllImport("kernel32.dll", SetLastError = true)] public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);
        [DllImport("kernel32.dll", SetLastError = true)] public static extern IntPtr CreateToolhelp32Snapshot(SnapshotFlags dwFlags, int th32ProcessID);
        [DllImport("kernel32.dll")] public static extern bool Module32First(IntPtr hSnapshot, ref MODULEENTRY32 lpme);
        [DllImport("kernel32.dll")] public static extern bool Module32Next(IntPtr hSnapshot, ref MODULEENTRY32 lpme);
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)] [return: MarshalAs(UnmanagedType.Bool)] public static extern bool CloseHandle(IntPtr hObject);


        [DllImport("kernel32.dll", SetLastError = true)] public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [MarshalAs(UnmanagedType.AsAny)] object lpBuffer, int dwSize, out IntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll", SetLastError = true)] public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [MarshalAs(UnmanagedType.AsAny)] object lpBuffer, int dwSize, IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)] public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)] public static extern bool ReadProcessMemory(IntPtr hProcess, UInt64 lpBaseAddress, byte[] lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)] public static extern bool ReadProcessMemory(IntPtr hProcess, UInt64 lpBaseAddress, byte[] lpBuffer, Int32 nSize, IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll")] public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, UIntPtr nSize, IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll")] public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, IntPtr nSize, out ulong lpNumberOfBytesRead);
        [DllImport("kernel32.dll")] public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] IntPtr lpBuffer, IntPtr nSize, out ulong lpNumberOfBytesRead);


        [DllImport("kernel32.dll")] public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);
        [DllImport("kernel32.dll")] public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);
        #endregion

        #region ImportEnumStruct
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }
        public enum SnapshotFlags : uint
        {
            HeapList = 0x00000001,
            Process = 0x00000002,
            Thread = 0x00000004,
            Module = 0x00000008,
            Module32 = 0x00000010,
            Inherit = 0x80000000,
            All = 0x0000001F,
            NoHeaps = 0x40000000
        }
        [StructLayout(LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct MODULEENTRY32
        {
            internal uint dwSize;
            internal uint th32ModuleID;
            internal uint th32ProcessID;
            internal uint GlblcntUsage;
            internal uint ProccntUsage;
            internal IntPtr modBaseAddr;
            internal uint modBaseSize;
            internal IntPtr hModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            internal string szModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            internal string szExePath;
        }
        #endregion

        public static IntPtr GetModuleBaseAddress(Process proc, string modName)
        {
            IntPtr addr = IntPtr.Zero;

            foreach (ProcessModule m in proc.Modules)
            {
                if (m.ModuleName == modName)
                {
                    addr = m.BaseAddress;
                    break; ;
                }
            }
            return addr;
        }

        public static IntPtr GetModuleBaseAddress(int procId, string modName)
        {
            IntPtr modBaseAddr = IntPtr.Zero;

            IntPtr hSnap = CreateToolhelp32Snapshot(SnapshotFlags.Module | SnapshotFlags.Module32, procId);

            if (hSnap.ToInt64() != -1)
            {
                MODULEENTRY32 modEntry = new MODULEENTRY32();
                modEntry.dwSize = (uint)Marshal.SizeOf(typeof(MODULEENTRY32));

                if (Module32First(hSnap, ref modEntry))
                {
                    do
                    {
                        if (modEntry.szModule.Equals(modName))
                        {
                            modBaseAddr = modEntry.modBaseAddr;
                            break;
                        }
                    } while (Module32Next(hSnap, ref modEntry));
                }
            }

            CloseHandle(hSnap);
            return modBaseAddr;
        }

        public IntPtr GetModuleBaseAddress(string modName)
        {
            IntPtr addr = IntPtr.Zero;

            foreach (ProcessModule m in Proc.Modules)
            {
                if (m.ModuleName == modName)
                {
                    addr = m.BaseAddress;
                    break; ;
                }
            }

            return addr;
        }

        public static IntPtr FindAddressWithPointer(IntPtr hProc, IntPtr ptr, int[] offsets)
        {
            var buffer = new byte[IntPtr.Size];

            foreach (int i in offsets)
            {
                ReadProcessMemory(hProc, ptr, buffer, buffer.Length, out
                var read);
                ptr = (IntPtr.Size == 4) ? IntPtr.Add(new IntPtr(BitConverter.ToInt32(buffer, 0)), i) : ptr = IntPtr.Add(new IntPtr(BitConverter.ToInt64(buffer, 0)), i);
            }
            return ptr;
        }

        public IntPtr FindAddressWithPointer(Pointer pointer)
        {
            try
            {
                IntPtr ret = IntPtr.Zero;
                IntPtr ModuleBaseAddress = GetModuleBaseAddress(pointer.ModuleBase);
                if (ModuleBaseAddress == IntPtr.Zero)
                {
                    return IntPtr.Zero;
                }
                ret = FindAddressWithPointer(this.hProc, (IntPtr)(ModuleBaseAddress + pointer.PointerAddress), pointer.Offsets);
                return ret;
            } catch { return IntPtr.Zero; }
        }

        public int FindAddressWithPointer(string ModuleBase, int Address, int[] offsets)
        {
            return (int)FindAddressWithPointer(this.hProc, GetModuleBaseAddress(this.Proc, ModuleBase) + Address, offsets);
        }

        public string ProcessName;
        public Process Proc;
        public IntPtr hProc;

        public Process GetProcID 
        {
            get { return this.Proc; }
        }

        public Memory(string ProcessName)
        {
            this.ProcessName = ProcessName;
            ConnectToProcess();
        }

        public void ConnectToProcess()
        {
            try
            {
                this.Proc = Process.GetProcessesByName(this.ProcessName)[0];
                this.hProc = OpenProcess(ProcessAccessFlags.All, false, Proc.Id);
            } catch { }
        }

        #region Write
        public void WriteMemory(Pointer pointer, object value)
        {
            try
            {
                IntPtr ModuleBaseAddress = GetModuleBaseAddress(this.Proc, pointer.ModuleBase);
                IntPtr TargetAddress = FindAddressWithPointer(this.hProc, (IntPtr)(ModuleBaseAddress + pointer.PointerAddress), pointer.Offsets);
                WriteProcessMemory(this.hProc, TargetAddress, value, 4, out _);
            } catch
            {

            }
        }

        public void WriteMemory(int address, object value)
        {
            WriteProcessMemory(this.hProc, (IntPtr)address, value, 4, out _);
        }

        public void WriteMemory(long address, object value)
        {
            WriteProcessMemory(this.hProc, (IntPtr)address, value, 4, out _);
        }

        public void WriteMemory(ulong address, object value)
        {
            WriteProcessMemory(this.hProc, (IntPtr)address, value, 4, out _);
        }

        public void WriteMemory(IntPtr address, object value)
        {
            WriteProcessMemory(this.hProc, address, value, 4, out _);
        }

        public void PatchMemory(string ModuleBase, int Address, byte[] write)
        {
            try
            {
                IntPtr ModuleBaseAddress = GetModuleBaseAddress(Proc, ModuleBase);
                uint oldprotect;

                VirtualProtectEx(this.hProc, (IntPtr)(ModuleBaseAddress + Address), (UIntPtr)write.Length, 0x40, out oldprotect);
                WriteProcessMemory(this.hProc, ModuleBaseAddress + Address, write, write.Length, out _);
                VirtualProtectEx(this.hProc, (IntPtr)(ModuleBaseAddress + Address), (UIntPtr)write.Length, oldprotect, out oldprotect);
            } catch { }
        }

        public void PatchMemory(int Address, byte[] write)
        {
            try
            {
                uint oldprotect;

                VirtualProtectEx(this.hProc, (IntPtr)(Address), (UIntPtr)write.Length, 0x40, out oldprotect);
                WriteProcessMemory(this.hProc, (IntPtr)Address, write, write.Length, IntPtr.Zero);
                VirtualProtectEx(this.hProc, (IntPtr)(Address), (UIntPtr)write.Length, oldprotect, out oldprotect);
            } catch { }
        }

        public void NopMemory(string ModuleBase, int Address, int length)
        {

            byte[] NopArray = new byte[length];
            for (int i = 0; i < NopArray.Length; i++)
            {
                NopArray[i] = 0x90;
            }
            PatchMemory(ModuleBase, Address, NopArray);
        }

        public void NopMemory(int Address, int length)
        {

            byte[] NopArray = new byte[length];
            for (int i = 0; i < NopArray.Length; i++)
            {
                NopArray[i] = 0x90;
            }
            PatchMemory(Address, NopArray);
        }
        #endregion

        #region Read
        public byte[] ReadMemory(Pointer pointer, long length)
        {
            try
            {
                byte[] memory = new byte[length];

                IntPtr ModuleBaseAddress = GetModuleBaseAddress(Proc, pointer.ModuleBase);
                IntPtr TargetAddress = FindAddressWithPointer(hProc, (IntPtr)(ModuleBaseAddress + pointer.PointerAddress), pointer.Offsets);

                ReadProcessMemory(this.hProc, TargetAddress, memory, (UIntPtr)length, IntPtr.Zero);
                return memory;
            } catch(Exception e) { throw e; }
        }

        public int ReadInt(Pointer pointer)
        {
            try
            {
                byte[] memory = new byte[4];

                IntPtr ModuleBaseAddress = GetModuleBaseAddress(Proc, pointer.ModuleBase);
                IntPtr TargetAddress = FindAddressWithPointer(hProc, (IntPtr)(ModuleBaseAddress + pointer.PointerAddress), pointer.Offsets);

                ReadProcessMemory(this.hProc, TargetAddress, memory, (UIntPtr)4, IntPtr.Zero);
                return BitConverter.ToInt32(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public int ReadInt(ulong Address)
        {
            try
            {
                byte[] memory = new byte[4];

                ReadProcessMemory(this.hProc, (UInt64)Address, memory, 4, IntPtr.Zero);
                return BitConverter.ToInt32(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public float ReadFloat(Pointer pointer)
        {
            try
            {
                byte[] memory = new byte[4];

                IntPtr ModuleBaseAddress = GetModuleBaseAddress(Proc, pointer.ModuleBase);
                IntPtr TargetAddress = FindAddressWithPointer(hProc, (IntPtr)(ModuleBaseAddress + pointer.PointerAddress), pointer.Offsets);

                ReadProcessMemory(this.hProc, TargetAddress, memory, (UIntPtr)4, IntPtr.Zero);
                return BitConverter.ToSingle(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public float ReadFloat(int Address)
        {
            try
            {
                byte[] memory = new byte[4];

                ReadProcessMemory(this.hProc, (IntPtr)Address, memory, (UIntPtr)4, IntPtr.Zero);
                return BitConverter.ToSingle(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public float ReadFloat(ulong Address)
        {
            try
            {
                byte[] memory = new byte[4];

                ReadProcessMemory(this.hProc, (UInt64)Address, memory, 4, IntPtr.Zero);
                return BitConverter.ToSingle(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public float ReadFloat(IntPtr Address)
        {
            try
            {
                byte[] memory = new byte[4];

                ReadProcessMemory(this.hProc, Address, memory, (UIntPtr)4, IntPtr.Zero);
                return BitConverter.ToSingle(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public bool ReadBool(Pointer pointer)
        {
            try
            {
                byte[] memory = new byte[4];

                IntPtr ModuleBaseAddress = GetModuleBaseAddress(Proc, pointer.ModuleBase);
                IntPtr TargetAddress = FindAddressWithPointer(hProc, (IntPtr)(ModuleBaseAddress + pointer.PointerAddress), pointer.Offsets);

                ReadProcessMemory(this.hProc, TargetAddress, memory, (UIntPtr)4, IntPtr.Zero);
                return BitConverter.ToBoolean(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public bool ReadBool(int Address)
        {
            try
            {
                byte[] memory = new byte[4];

                ReadProcessMemory(this.hProc, (IntPtr)Address, memory, (UIntPtr)4, IntPtr.Zero);
                return BitConverter.ToBoolean(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public bool ReadBool(ulong Address)
        {
            try
            {
                byte[] memory = new byte[4];

                ReadProcessMemory(this.hProc, (UInt64)Address, memory, 4, IntPtr.Zero);
                return BitConverter.ToBoolean(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public UInt64 ReadUnsignedLong(UInt64 Address)
        {
            try
            {
                byte[] memory = new byte[8];

                ReadProcessMemory(this.hProc, (UInt64)Address, memory, 8, IntPtr.Zero);
                return BitConverter.ToUInt64(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public UInt64 ReadUnsignedLong(Pointer pointer)
        {
            try
            {
                byte[] memory = new byte[8];

                IntPtr ModuleBaseAddress = GetModuleBaseAddress(Proc, pointer.ModuleBase);
                IntPtr TargetAddress = FindAddressWithPointer(hProc, (IntPtr)(ModuleBaseAddress + pointer.PointerAddress), pointer.Offsets);

                ReadProcessMemory(this.hProc, (UInt64)TargetAddress, memory, 8, IntPtr.Zero);
                return BitConverter.ToUInt64(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public Int64 ReadLong(int Address)
        {
            try
            {
                byte[] memory = new byte[8];

                ReadProcessMemory(this.hProc, (IntPtr)Address, memory, (UIntPtr)8, IntPtr.Zero);
                return BitConverter.ToInt64(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public Int64 ReadLong(Pointer pointer)
        {
            try
            {
                byte[] memory = new byte[8];

                IntPtr ModuleBaseAddress = GetModuleBaseAddress(Proc, pointer.ModuleBase);
                IntPtr TargetAddress = FindAddressWithPointer(hProc, (IntPtr)(ModuleBaseAddress + pointer.PointerAddress), pointer.Offsets);

                ReadProcessMemory(this.hProc, TargetAddress, memory, (UIntPtr)8, IntPtr.Zero);
                return BitConverter.ToInt64(memory, 0);
            }
            catch (Exception e) { throw e; }
        }

        public string ReadString(ulong Address, ulong Length)
        {
            try
            {
                byte[] memory = new byte[Length];

                ulong counter = 0;
                foreach (byte _byte in memory)
                {
                    byte[] read = new byte[1];
                    ReadProcessMemory(this.hProc, (IntPtr)(Address + counter), read, (UIntPtr)1, IntPtr.Zero);

                    if (read[0] == 0)
                    {
                        break;
                    }

                    memory[counter] = read[0];
                    counter++;
                }
                int counter_ = Convert.ToInt32(Math.Max(0, counter));
                return new string(Encoding.Default.GetString(memory).Take(counter_).ToArray());
            }
            catch (Exception e) { throw e; }
        }
        #endregion

    }

    public class Pointer
    {
        public string ModuleBase;
        public int PointerAddress;
        public int[] Offsets;

        public Pointer(string ModuleBase, int PointerAddress, int[] Offsets)
        {
            this.ModuleBase = ModuleBase;
            this.PointerAddress = PointerAddress;
            this.Offsets = Offsets;
        }
    }
}
