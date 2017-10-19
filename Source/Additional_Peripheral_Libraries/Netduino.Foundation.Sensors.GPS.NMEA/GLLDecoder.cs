﻿using System;
namespace Netduino.Foundation.Sensors.GPS
{
    /// <summary>
    /// Process GLL (Geographic position Latitude / Longitude) messages from a 
    /// GPS receiver.
    /// </summary>
    public class GLLDecoder : NMEADecoder
    {
        #region Delegates and events

        /// <summary>
        /// Delegate for the GLL data received event.
        /// </summary>
        /// <param name="location">Location data to pass to the application.</param>
        public delegate void GeographicLatitudeLongitudeReceived(GPSLocation location);

        /// <summary>
        /// Event raised when valid GLL data is received.
        /// </summary>
        public event GeographicLatitudeLongitudeReceived OnGeographicLatitudeLongitudeReceived = null;

        #endregion Delegates and events

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GLLDecoder()
        {
        }

        #endregion Constructors

        #region NMEADecoder methods & properties

        /// <summary>
        /// Prefix for the GLL (Geographic position Latitude / Longitude) decoder.
        /// </summary>
        public override string Prefix { get { return ("$GPGLL"); } }

        /// <summary>
        /// Friendly name for the GLL messages.
        /// </summary>
        public override string Name { get { return("GLL - Global Postioning System Fix Data"); } }

        /// <summary>
        /// Process the data from a GLL message.
        /// </summary>
        /// <param name="data">String array of the message components for a GLL message.</param>
        public override void Process(string[] data)
        {
            if (OnGeographicLatitudeLongitudeReceived != null)
            {
                //
                //  Status is stored in element 7 (position 6), A = valid, V = not valid.
                //
                if (data[6] == "A")
                {
                    GPSLocation location = new GPSLocation();
                    location.Latitude = NMEAHelpers.DegreesMinutesDecode(data[1], data[2]);
                    location.Longitude = NMEAHelpers.DegreesMinutesDecode(data[3], data[4]);
                    location.ReadingTime = NMEAHelpers.TimeOfReading(null, data[5]);
                    OnGeographicLatitudeLongitudeReceived(location);
                }
            }
        }

        #endregion NMEADecoder methods & properties
    }
}