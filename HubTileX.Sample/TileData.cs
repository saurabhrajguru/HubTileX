using System;

namespace HubTileX.Sample
{
    /// <summary>
    /// 
    /// </summary>
    public class TileData
    {
        #region Properties

        /// <summary>
        /// Gets or sets the image URI.
        /// </summary>
        /// <value>
        /// The image URI.
        /// </value>
        public string ImageUri
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the merchant.
        /// </summary>
        /// <value>
        /// The name of the merchant.
        /// </value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the merchant address.
        /// </summary>
        /// <value>
        /// The merchant address.
        /// </value>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [should flip].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [should flip]; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldFlip
        {
            get;
            set;
        }

        #endregion
    }
}
