using System;
using Microsoft.SPOT;

namespace Netduino.Foundation.Servos
{
    public static class NamedServoConfigs
    {
        /// <summary>
        /// Represents an ideal 180� servo that has a minimum pulse of 1ms and a max of 2ms.
        /// </summary>
        public static ServoConfig Ideal180Servo = new ServoConfig();
        /// <summary>
        /// Represents an ideal 270� servo that has a minimum pulse of 1ms and a max of 2ms.
        /// </summary>
        public static ServoConfig Ideal270Servo = new ServoConfig(maximumAngle: 270);

        /// <summary>
        /// Represents the BlueBird BMS models. Maximum angle is 120. Pulse range is 900�s - 2,100�s.
        /// See: https://www.blue-bird-model.com/products_detail/309.htm
        /// </summary>
        public static ServoConfig BlueBirdBMS120 = new ServoConfig(minimumPulseDuration: 900, maximumPulseDuration: 2100, maximumAngle: 120);

        /// <summary>
        /// Represents the HiTec "Standard" servo models. Angle: 0-180, Pulse: 900 - 1,200
        /// </summary>0
        public static ServoConfig HiTecStandard = new ServoConfig(minimumPulseDuration: 900, maximumPulseDuration: 2100, maximumAngle: 180);
    }
}
