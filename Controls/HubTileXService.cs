using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubTileX.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public static class HubTileXService
    {
        #region Attributes

        private static List<HubTileX> hubtileList = null;

        #endregion

        #region .ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="HubTileXService"/> class.
        /// </summary>
        static HubTileXService()
        {
            hubtileList = new List<HubTileX>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Registers the hub tile.
        /// </summary>
        /// <param name="hubTile">The hub tile.</param>
        public static void RegisterHubTile(HubTileX hubTile)
        {
            if (hubtileList != null)
                hubtileList.Add(hubTile);
        }

        /// <summary>
        /// Uns the register hub tile.
        /// </summary>
        /// <param name="hubTile">The hub tile.</param>
        public static void UnRegisterHubTile(HubTileX hubTile)
        {
            if (hubtileList != null)
                hubtileList.Remove(hubTile);
        }

        /// <summary>
        /// Freezes all.
        /// </summary>
        public static void FreezeAll()
        {
            if (hubtileList != null)
            {
                foreach (var hubtile in hubtileList)
                    hubtile.Freeze();
            }
        }

        /// <summary>
        /// Uns the freeze all.
        /// </summary>
        public static void UnFreezeAll()
        {
            if (hubtileList != null)
            {
                foreach (var hubtile in hubtileList)
                    hubtile.UnFreeze();
            }
        }

        #endregion
    }
}
