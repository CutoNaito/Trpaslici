using System;

namespace Trpaslici
{
    class TrpaslikFactory
    {
        public Trpaslik CreateTrpaslik(string type)
        {
            switch (type)
            {
                case "Pathfinding":
                    return new PathfindingTrpaslik();
                case "Teleport":
                    return new TeleportTrpaslik();
                case "Right":
                    return new RightTrpaslik();
                case "Left":
                    return new LeftTrpaslik();
                default:
                    throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
