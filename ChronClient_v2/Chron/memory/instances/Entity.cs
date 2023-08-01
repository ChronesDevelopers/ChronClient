using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace ChronClient.Instance
{
    public class Entity
    {
#nullable enable
        public Entity(ulong EntityBaseAddress)
        {
            this.EntityBaseAddress = EntityBaseAddress;
        }
        public ulong EntityBaseAddress { get; private set; }
        public int? confirmation = null; 
        public bool Exists { get { try { if (confirmation == null) { return true; } int read = Game.m.ReadInt(EntityBaseAddress); if (read == confirmation) { return true; } else { return false; } } catch { return false; } } }
        //public string? UserName { get { try { return Game.m.ReadString(EntityBaseAddress + 0xA18, 20); } catch { return null; } } }
        public float? HitBoxWidth { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x474); } catch { return null; } } set { Game.m.WriteMemory(EntityBaseAddress + 0x474, value); } }
        public float? HitBoxHeight { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x478); } catch { return null; } } set { Game.m.WriteMemory(EntityBaseAddress + 0x478, value); } }
        public float? X1 { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x458); } catch { return null; } } set { Game.m.WriteMemory(EntityBaseAddress + 0x458, value); } }
        public float? Y1 { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x45C); } catch { return null; } } set { Game.m.WriteMemory(EntityBaseAddress + 0x45C, value); } }
        public float? Z1 { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x460); } catch { return null; } } set { Game.m.WriteMemory(EntityBaseAddress + 0x460, value); } }
        public float? X2 { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x464); } catch { return null; } } set { Game.m.WriteMemory(EntityBaseAddress + 0x464, value); } }
        public float? Y2 { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x468); } catch { return null; } } set { Game.m.WriteMemory(EntityBaseAddress + 0x468, value); } }
        public float? Z2 { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x46C); } catch { return null; } } set { Game.m.WriteMemory(EntityBaseAddress + 0x46C, value); } }
        public float? X { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x458) + 0.3f; } catch { return null; } } set { X1 = value - 0.3f; X2 = value + 0.3f; } }
        public float? Y { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x45C);        } catch { return null; } } set { Y1 = value       ; Y2 = value + 1.8f; } }
        public float? Z { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x460) + 0.3f; } catch { return null; } } set { Z1 = value - 0.3f; Z2 = value + 0.3f; } }
        public Vector3? XYZ
        {
            get
            {
                try
                {
                    Vector3 vector = new Vector3();
                    float? vecX = this.X;
                    if (vecX != null)
                    {
                        vector.X = (float)vecX;
                    }
                    else { return null; }
                    float? vecY = this.Y;
                    if (vecY != null)
                    {
                        vector.Y = (float)vecY;
                    }
                    else { return null; }
                    float? vecZ = this.Z;
                    if (vecZ != null)
                    {
                        vector.Z = (float)vecZ;
                    }
                    else { return null; }
                    return vector;

                } catch { return null; }
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                Vector3 vector = (Vector3)value;
                this.X = vector.X;
                this.Y = vector.Y;
                this.Z = vector.Z;
            }
        }
        public float? Pitch
        {
            get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x100); } catch { return null; } }
            set { try { if (value == null) { return; } Game.m.WriteMemory(EntityBaseAddress + 0x100, value); } catch { } }
        }
        public float? Yaw
        {
            get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x104); } catch { return null; } }
            set { try { if (value == null) { return; } Game.m.WriteMemory(EntityBaseAddress + 0x104, value); } catch { } }
        }
        public Vector3? LookingVector
        {
            get
            {
                try
                {
                    Vector3 vec = new Vector3();
                    float? pitch = Pitch;
                    float? yaw = Yaw;
                    if (Pitch == null || Yaw == null)
                    {
                        return null;
                    }
                    yaw += 89.9f;
                    yaw = yaw * (float)Math.PI / 178F;
                    pitch = pitch * (float)Math.PI / 178f;
                    vec.X = (float)Math.Cos((float)yaw) * (float)Math.Cos((float)pitch);
                    vec.Y = (float)Math.Sin((float)pitch);
                    vec.Z = (float)Math.Sin((float)yaw) * (float)Math.Cos((float)pitch);
                    return (Vector3?)vec;
                }
                catch { return null; }
            }
        }
        public Vector2? LookingVectorXY
        {
            get
            {
                try
                {
                    Vector2 vec = new Vector2();
                    float? pitch = Pitch;
                    float? yaw = Yaw;
                    if (Pitch == null || Yaw == null)
                    {
                        return null;
                    }
                    yaw += 89.9f;
                    yaw = yaw * (float)Math.PI / 178F;
                    pitch = pitch * (float)Math.PI / 178f;
                    vec.X = (float)Math.Cos((float)yaw);
                    vec.Y = (float)Math.Sin((float)yaw);
                    return (Vector2?)vec;
                }
                catch { return null; }
            }
        }
        public bool? IsFlying { get { try { return Game.m.ReadBool(EntityBaseAddress + 0x8B8); } catch { return null; } } set { if (value == null) { return; } Game.m.WriteMemory(EntityBaseAddress + 0x8B8, value); } }
        public bool? OnGround { get { try { return Game.m.ReadBool(EntityBaseAddress + 0x1A0); } catch { return null; } } set { if (value == null) { return; } Game.m.WriteMemory(EntityBaseAddress + 0x178, value); } }
        public float? VelX { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x494); } catch { return null; } } set { if (value == null) { return; } Game.m.WriteMemory(EntityBaseAddress + 0x494, (float)value); } }
        public float? VelY { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x498); } catch { return null; } } set { if (value == null) { return; } Game.m.WriteMemory(EntityBaseAddress + 0x498, (float)value); } }
        public float? VelZ { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x49C); } catch { return null; } } set { if (value == null) { return; } Game.m.WriteMemory(EntityBaseAddress + 0x49C, (float)value); } }
        public Vector3? Vel
        {
            get
            {
                try
                {
                    Vector3 vector = new Vector3();

                    float? velX = VelX;
                    if (velX != null)
                    {
                        vector.X = (float)velX;
                    } else
                    {
                        return null;
                    }

                    float? velY = VelY;
                    if (velY != null)
                    {
                        vector.Y = (float)velY;
                    }
                    else
                    {
                        return null;
                    }

                    float? velZ = VelZ;
                    if (velZ != null)
                    {
                        vector.Z = (float)velZ;
                    }
                    else
                    {
                        return null;
                    }

                    return (Vector3?)vector;
                }
                catch { return null; }
            }
            set
            {
                if (value != null)
                {
                    return;
                }
                Vector3 vector = (Vector3)value;
                this.VelX = vector.X;
                this.VelY = vector.Y;
                this.VelZ = vector.Z;
            }
        }
        public float? FallingDistance { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x19C); } catch { return null; } } set { if (value == null) { return; } Game.m.WriteMemory(EntityBaseAddress + 0x19C, (float)value); } }
        public float? StepHigh { get { try { return Game.m.ReadFloat(EntityBaseAddress + 0x200); } catch { return null; } } set { if (value == null) { return; } Game.m.WriteMemory(EntityBaseAddress + 0x1F8, (float)value); } }
#nullable disable
    }
}
