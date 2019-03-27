using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Actions
{
    public static class IActions
    {
        public static Fighter Fighter { get; set; } = new Fighter();
        public static FrameShiftDrive FrameShiftDrive { get; set; } = new FrameShiftDrive();
    }
}
