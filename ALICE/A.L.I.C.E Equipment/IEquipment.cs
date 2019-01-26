using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Objects;

namespace ALICE_Core
{
    public static class IEquipment
    {

    }

    public class Equipment_Base
    {
        public T New<T>() { return default(T); }
    }
}