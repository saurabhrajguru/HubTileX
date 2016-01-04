using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace HubTileX.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class HubTileX : Control
    {
        #region Attributes

        private DispatcherTimer flipTimer = null;
        private bool isAtRear = false;
        private double flipDuration = 3;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the content of the front.
        /// </summary>
        /// <value>
        /// The content of the front.
        /// </value>
        public object FrontContent
        {
            get
            {
                return base.GetValue(FrontContentProperty);
            }
            set
            {
                base.SetValue(FrontContentProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the content of the rear.
        /// </summary>
        /// <value>
        /// The content of the rear.
        /// </value>
        public object RearContent
        {
            get
            {
                return base.GetValue(RearContentProperty);
            }
            set
            {
                base.SetValue(RearContentProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public ICommand Command
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        /// <value>
        /// The command parameter.
        /// </value>
        public object CommandParameter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the duration of the flip.
        /// </summary>
        /// <value>
        /// The duration of the flip.
        /// </value>
        public double FlipDuration
        {
            get
            {
                return this.flipDuration;
            }
            set
            {
                this.flipDuration = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [should flip].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [should flip]; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldFlip
        {
            get
            {
                return (bool)base.GetValue(ShouldFlipProperty);
            }
            set
            {
                base.SetValue(ShouldFlipProperty, value);
            }
        }

        #endregion

        #region Dependancy Properties

        public static readonly DependencyProperty FrontContentProperty = DependencyProperty.Register("FrontContent", typeof(object), typeof(HubTileX), null);
        public static readonly DependencyProperty RearContentProperty = DependencyProperty.Register("RearContent", typeof(object), typeof(HubTileX), null);
        public static readonly DependencyProperty FirstContentTemplateProperty = DependencyProperty.Register("FrontContentTemplate", typeof(DataTemplate), typeof(HubTileX), null);
        public static readonly DependencyProperty SecondContentTemplateProperty = DependencyProperty.Register("RearContentTemplate", typeof(DataTemplate), typeof(HubTileX), null);
        public static readonly DependencyProperty ShouldFlipProperty = DependencyProperty.Register("ShouldFlip", typeof(bool), typeof(HubTileX), null);

        #endregion

        #region .ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="HubTileX"/> class.
        /// </summary>
        public HubTileX()
        {
            this.DefaultStyleKey = typeof(HubTileX);
            this.Loaded += HubTileX_Loaded;
            this.Unloaded += HubTileX_Unloaded;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Called before the <see cref="E:System.Windows.UIElement.Tap" /> event occurs.For information on using gestures on Windows Phone, see How to handle manipulation events for Windows Phone.
        /// </summary>
        /// <param name="e">Event data for the event.</param>
        protected override void OnTap(GestureEventArgs e)
        {
            base.OnTap(e);
            if (this.Command != null)
            {
                if (this.Command.CanExecute(this.CommandParameter))
                    this.Command.Execute(this.CommandParameter);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Freezes this instance.
        /// </summary>
        public void Freeze()
        {
            if (flipTimer != null)
            {
                if (flipTimer.IsEnabled)
                    flipTimer.Stop();
            }
        }

        /// <summary>
        /// Uns the freeze.
        /// </summary>
        public void UnFreeze()
        {
            if (flipTimer != null)
            {
                if (!flipTimer.IsEnabled)
                    flipTimer.Start();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the Loaded event of the HubTileX control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void HubTileX_Loaded(object sender, RoutedEventArgs e)
        {
            HubTileXService.RegisterHubTile(this);
            if (this.RearContent != null && this.ShouldFlip)
            {
                flipTimer = new DispatcherTimer();
                flipTimer.Interval = TimeSpan.FromSeconds(this.flipDuration);
                flipTimer.Tick += flipTimer_Tick;
                flipTimer.Start();
            }
        }

        /// <summary>
        /// Handles the Tick event of the flipTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void flipTimer_Tick(object sender, EventArgs e)
        {
            if (!this.isAtRear)
            {
                VisualStateManager.GoToState(this, "Flipped", true);
                this.isAtRear = true;
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", true);
                this.isAtRear = false;
            }
        }

        /// <summary>
        /// Handles the Unloaded event of the HubTileX control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void HubTileX_Unloaded(object sender, RoutedEventArgs e)
        {
            HubTileXService.UnRegisterHubTile(this);
            if (flipTimer != null)
            {
                if (flipTimer.IsEnabled)
                    flipTimer.Stop();
            }
        }

        #endregion
    }
}
