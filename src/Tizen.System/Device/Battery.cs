/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for the Battery level.
    /// </summary>
    public enum BatteryLevelStatus
    {
        /// <summary>
        /// The battery goes empty.
        /// Prepare for the safe termination of the application,
        /// because the device starts a shutdown process soon
        /// after entering this level.
        /// </summary>
        Empty = 0,
        /// <summary>
        /// The battery charge is at a critical state.
        /// You may have to stop using multimedia features,
        /// because they are not guaranteed to work correctly
        /// at this battery status.
        /// </summary>
        Critical,
        /// <summary>
        /// The battery has little charge left.
        /// </summary>
        Low,
        /// <summary>
        /// The battery status is not to be careful.
        /// </summary>
        High,
        /// <summary>
        /// The battery status is full.
        /// </summary>
        Full
    }

    /// <summary>
    /// The Battery class provides the Properties and Events for device battery.
    /// </summary>
    /// <remarks>
    /// The Battery API provides the way to get the current battery capacity value (Percent),
    /// battery state and charging state. It also provides Events for an application
    /// to receive the battery status change events from the device.
    /// To receive the battery event, application should register with respective EventHandler.
    /// </remarks>
    /// <code>
    ///     Console.WriteLine("battery Charging state is: {0}", Tizen.System.Battery.IsCharging);
    ///     Console.WriteLine("battery Percent is: {0}", Tizen.System.Battery.Percent);
    /// </code>
    public static class Battery
    {
        private static readonly object s_lock = new object();
        /// <summary>
        /// Gets the battery charge percentage.
        /// </summary>
        /// <value>It returns an integer value from 0 to 100 that indicates remaining
        /// battery charge as a percentage of the maximum level.</value>
        public static int Percent
        {
            get
            {
                int percent = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceBatteryGetPercent(out percent);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get battery percentage.");
                }
                return percent;
            }
        }
        /// <summary>
        /// Gets the current Battery level.
        /// </summary>
        public static BatteryLevelStatus Level
        {
            get
            {
                int level = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceBatteryGetLevelStatus(out level);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get battery status.");
                }
                return (BatteryLevelStatus)level;
            }
        }
        /// <summary>
        /// Gets the current charging state.
        /// </summary>
        public static bool IsCharging
        {
            get
            {
                bool charging;
                DeviceError res = (DeviceError)Interop.Device.DeviceBatteryIsCharging(out charging);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get battery charging state.");
                }
                return charging;
            }
        }

        private static EventHandler<BatteryPercentChangedEventArgs> s_capacityChanged;
        /// <summary>
        /// CapacityChanged is triggered when the battery charge percentage is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A BatteryCapacityChangedEventArgs object that contains changed battery capacity (Percent)</param>
        /// <code>
        /// public static async Task BatteryEventHandler()
        /// {
        ///     EventHandler<BatteryPercentChangedEventArgs> handler = null;
        ///     handler = (object sender, BatteryChargingStateChangedEventArgs args) =>
        ///     {
        ///          Console.WriteLine("battery Percent is: {0}", args.Percent);
        ///     }
        ///     Battery.PercentChanged += handler;
        ///     await Task.Delay(20000);
        ///  }
        /// </code>
        public static event EventHandler<BatteryPercentChangedEventArgs> PercentChanged
        {
            add
            {
                lock (s_lock)
                {
                    if (s_capacityChanged == null)
                    {
                        EventListenerStart(EventType.BatteryPercent);
                    }
                    s_capacityChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_capacityChanged -= value;
                    if (s_capacityChanged == null)
                    {
                        EventListenerStop(EventType.BatteryPercent);
                    }
                }
            }
        }

        private static event EventHandler<BatteryLevelChangedEventArgs> s_levelChanged;

        /// <summary>
        /// LevelChanged is triggered when the battery level is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A BatteryLevelChangedEventArgs object that contains changed battery level </param>
        /// <code>
        /// public static async Task BatteryEventHandler()
        /// {
        ///     EventHandler<BatteryLevelChangedEventArgs> handler = null;
        ///     handler = (object sender, BatteryLevelChangedEventArgs args) =>
        ///     {
        ///          Console.WriteLine("battery Level is: {0}", args.Level);
        ///     }
        ///     Battery.LevelChanged += handler;
        ///     await Task.Delay(20000);
        ///  }
        /// </code>
        public static event EventHandler<BatteryLevelChangedEventArgs> LevelChanged
        {
            add
            {
                lock (s_lock)
                {
                    if (s_levelChanged == null)
                    {
                        EventListenerStart(EventType.BatteryLevel);
                    }
                    s_levelChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_levelChanged -= value;
                    if (s_levelChanged == null)
                    {
                        EventListenerStop(EventType.BatteryLevel);
                    }
                }
            }
        }

        private static event EventHandler<BatteryChargingStateChangedEventArgs> s_chargingStateChanged;
        /// <summary>
        /// ChargingStatusChanged is triggered when the Battery charging status is changed.
        /// This event is triggered when Charger is connected/Disconnected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A BatteryChargingStateChangedEventArgs object that contains changed battery charging state</param>
        /// <code>
        /// public static async Task BatteryEventHandler()
        /// {
        ///     EventHandler<BatteryChargingStateChangedEventArgs> handler = null;
        ///     handler = (object sender, BatteryChargingStateChangedEventArgs args) =>
        ///     {
        ///          Console.WriteLine("battery Level is: {0}", args.IsCharging);
        ///     }
        ///     Battery.ChargingStateChanged += handler;
        ///     await Task.Delay(20000);
        ///  }
        /// </code>
        public static event EventHandler<BatteryChargingStateChangedEventArgs> ChargingStateChanged
        {
            add
            {
                lock (s_lock)
                {
                    if (s_chargingStateChanged == null)
                    {
                        EventListenerStart(EventType.BatteryCharging);
                    }
                    s_chargingStateChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_chargingStateChanged -= value;
                    if (s_chargingStateChanged == null)
                    {
                        EventListenerStop(EventType.BatteryCharging);
                    }
                }
            }
        }

        private static Interop.Device.deviceCallback s_cpacityHandler;
        private static Interop.Device.deviceCallback s_levelHandler;
        private static Interop.Device.deviceCallback s_chargingHandler;

        private static void EventListenerStart(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.BatteryPercent:
                    s_cpacityHandler = (int type, IntPtr value, IntPtr data) =>
                    {
                        int val = value.ToInt32();
                        BatteryPercentChangedEventArgs e = new BatteryPercentChangedEventArgs()
                        {
                            Percent = val
                        };
                        s_capacityChanged?.Invoke(null, e);
                        return true;
                    };

                    Interop.Device.DeviceAddCallback(eventType, s_cpacityHandler, IntPtr.Zero);
                    break;

                case EventType.BatteryLevel:
                    s_levelHandler = (int type, IntPtr value, IntPtr data) =>
                    {
                        int val = value.ToInt32();
                        BatteryLevelChangedEventArgs e = new BatteryLevelChangedEventArgs()
                        {
                            Level = (BatteryLevelStatus)val
                        };
                        s_levelChanged?.Invoke(null, e);
                        return true;
                    };

                    Interop.Device.DeviceAddCallback(eventType, s_levelHandler, IntPtr.Zero);
                    break;

                case EventType.BatteryCharging:
                    s_chargingHandler = (int type, IntPtr value, IntPtr data) =>
                    {
                        bool val = (value.ToInt32() == 1);
                        BatteryChargingStateChangedEventArgs e = new BatteryChargingStateChangedEventArgs()
                        {
                            IsCharging = val
                        };
                        s_chargingStateChanged?.Invoke(null, e);
                        return true;
                    };
                    Interop.Device.DeviceAddCallback(eventType, s_chargingHandler, IntPtr.Zero);
                    break;
            }
        }

        private static void EventListenerStop(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.BatteryPercent:
                    Interop.Device.DeviceRemoveCallback(eventType, s_cpacityHandler);
                    break;

                case EventType.BatteryLevel:
                    Interop.Device.DeviceRemoveCallback(eventType, s_levelHandler);
                    break;

                case EventType.BatteryCharging:
                    Interop.Device.DeviceRemoveCallback(eventType, s_chargingHandler);
                    break;
            }
        }
    }
}
