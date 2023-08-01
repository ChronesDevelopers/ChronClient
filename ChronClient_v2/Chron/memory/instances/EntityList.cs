using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ChronClient.GUI.Pages;
using Chrones.Cmr.MemoryManagement;

namespace ChronClient.Instance
{
    public static class EntityList
    {
#nullable enable
        //public static readonly Pointer EntityListStart = new Pointer("Minecraft.Windows.exe", 0x307D3A0, new int[] { 0x30, 0xF0, 0x330, 0x40 });
        //public static readonly Pointer EntityListEnd = new Pointer("Minecraft.Windows.exe", 0x307D3A0, new int[] { 0x30, 0xF0, 0x330, 0x48 });

        public static readonly Pointer EntityListStart = new Pointer("Minecraft.Windows.exe", 0x369D0B8, new int[] { 0xA8, 0x18, 0x10, 0x40 });
        public static readonly Pointer EntityListEnd = new Pointer("Minecraft.Windows.exe", 0x369D0B8, new int[] { 0xA8, 0x18, 0x10, 0x48 });

        public static List<Entity>? GetEntityList()
        {
            ulong StartAddress;
            ulong EndAddress;
            try
            {
                //StartAddress = Game.m.ReadUnsignedLong(EntityListStart);
                //EndAddress = Game.m.ReadUnsignedLong(EntityListEnd);
                StartAddress = Game.m.ReadUnsignedLong(EntityListStart);
                //Debug.WriteLine("0x{0:X}", Game.m.ReadUnsignedLong(EntityListStart));
                EndAddress = Game.m.ReadUnsignedLong(EntityListEnd);
                //Debug.WriteLine("0x{0:X}", Game.m.ReadUnsignedLong(EntityListEnd));
            }
            catch
            {
                //Debug.WriteLine("nope");
                return null;
            }

            if (StartAddress == null)
            {
                //Debug.WriteLine("nope");
                return null;
            }

            List<Entity> entities = new List<Entity>();

            for (ulong i = StartAddress; i < EndAddress; i += 8)
            {
                ulong EntityAddress = Game.m.ReadUnsignedLong(i);
                if (i == StartAddress)
                {
                    continue;
                }

                Entity entity = new Entity(EntityAddress);
                entity.confirmation = Game.m.ReadInt(EntityAddress);

                entities.Add(entity);
            }

            // Return List
            return entities;
        }

        public static List<Entity>? GetFullEntityList()
        {
            ulong StartAddress;
            ulong EndAddress;
            try
            {
                //StartAddress = Game.m.ReadUnsignedLong(EntityListStart);
                //EndAddress = Game.m.ReadUnsignedLong(EntityListEnd);
                StartAddress = Game.m.ReadUnsignedLong(EntityListStart);
                //Debug.WriteLine("0x{0:X}", Game.m.ReadUnsignedLong(EntityListStart));
                EndAddress = Game.m.ReadUnsignedLong(EntityListEnd);
                //Debug.WriteLine("0x{0:X}", Game.m.ReadUnsignedLong(EntityListEnd));
            }
            catch
            {
                //Debug.WriteLine("nope");
                return null;
            }

            if (StartAddress == null)
            {
                //Debug.WriteLine("nope");
                return null;
            }

            List<Entity> entities = new List<Entity>();

            for (ulong i = StartAddress; i < EndAddress; i += 8)
            {
                ulong EntityAddress = Game.m.ReadUnsignedLong(i);

                Entity entity = new Entity(EntityAddress);
                entity.confirmation = Game.m.ReadInt(EntityAddress);

                entities.Add(entity);
            }

            // Return List
            return entities;
        }

        public static Entity[]? GetEntityArray()
        {
            // Get Start Address
            // Get End Address
            // Get Length
            // Loop and give Address to Entity
            // Return Array
            return null;
        }

        public static List<Entity>? GetTargetEntitiesList()
        {
            ulong StartAddress;
            ulong EndAddress;
            try
            {
                //StartAddress = Game.m.ReadUnsignedLong(EntityListStart);
                //EndAddress = Game.m.ReadUnsignedLong(EntityListEnd);
                StartAddress = Game.m.ReadUnsignedLong(EntityListStart);
                //Debug.WriteLine("0x{0:X}", Game.m.ReadUnsignedLong(EntityListStart));
                EndAddress = Game.m.ReadUnsignedLong(EntityListEnd);
                //Debug.WriteLine("0x{0:X}", Game.m.ReadUnsignedLong(EntityListEnd));
            }
            catch
            {
                //Debug.WriteLine("nope");
                return null;
            }

            if (StartAddress == null)
            {
                //Debug.WriteLine("nope");
                return null;
            }

            List<Entity> entities = new List<Entity>();

            for (ulong i = StartAddress; i < EndAddress; i += 8)
            {
                ulong EntityAddress = Game.m.ReadUnsignedLong(i);
                if (i == StartAddress)
                {
                    continue;
                }

                Entity entity = new Entity(EntityAddress);

                entity.confirmation = Game.m.ReadInt(EntityAddress);

                entities.Add(entity);
            }

            // Return List
            return entities;
        }

        public static List<Entity>? GetTargetEntitiesList_Reachable(Vector3 from, float reach)
        {
            ulong StartAddress;
            ulong EndAddress;
            try
            {
                //StartAddress = Game.m.ReadUnsignedLong(EntityListStart);
                //EndAddress = Game.m.ReadUnsignedLong(EntityListEnd);
                StartAddress = Game.m.ReadUnsignedLong(EntityListStart);
                //Debug.WriteLine("0x{0:X}", Game.m.ReadUnsignedLong(EntityListStart));
                EndAddress = Game.m.ReadUnsignedLong(EntityListEnd);
                //Debug.WriteLine("0x{0:X}", Game.m.ReadUnsignedLong(EntityListEnd));
            }
            catch
            {
                //Debug.WriteLine("nope");
                return null;
            }

            if (StartAddress == null)
            {
                //Debug.WriteLine("nope");
                return null;
            }

            List<Entity> entities = new List<Entity>();

            for (ulong i = StartAddress; i < EndAddress; i += 8)
            {
                ulong EntityAddress = Game.m.ReadUnsignedLong(i);
                if (i == StartAddress)
                {
                    continue;
                }

                Entity entity = new Entity(EntityAddress);


                Vector3? _to = entity.XYZ;
                if (_to == null)
                {
                    continue;
                }
                Vector3 to = (Vector3)_to;
                float distance = (float)Math.Sqrt((to.X - from.X) * (to.X - from.X) + (to.Y - from.Y) * (to.Y - from.Y) + (to.Z - from.Z) * (to.Z - from.Z));
                if (distance > reach)
                {
                    continue;
                }

                entity.confirmation = Game.m.ReadInt(EntityAddress);

                entities.Add(entity);
            }

            // Return List
            return entities;
        }
#nullable disable
    }
}
