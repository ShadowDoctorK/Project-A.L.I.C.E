using System.Xml.Serialization;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using System.Xml;

namespace ALICE_XML_Interface
{
    #region Serialize / Deserialize
    public class XmlControl
    {
        /// <summary>
        /// Deserializes an xml document back into an object
        /// </summary>
        /// <param name="xml">The xml data to deserialize</param>
        /// <param name="type">The type of the object being deserialized</param>
        /// <returns>A deserialized object</returns>
        public static object Deserialize(XmlDocument xml)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(Root));
            string xmlString = xml.OuterXml.ToString();
            byte[] buffer = ASCIIEncoding.UTF8.GetBytes(xmlString);
            MemoryStream ms = new MemoryStream(buffer);
            //XmlReader Reader = new XmlTextReader(ms);
            try
            {
                Root Binds = (Root)Serializer.Deserialize(ms);
                return Binds;
            }

            catch (Exception ex)
            {

            }
            finally
            {
                //Reader.Close();
            }
            return null;
        }

        /// <summary>
        /// Serializes an object into an Xml Document
        /// </summary>
        /// <param name="o">The object to serialize</param>
        /// <returns>An Xml Document consisting of said object's data</returns>
        public static XmlDocument Serialize(Root Binds)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(Root));

            MemoryStream Stream = new MemoryStream();
            XmlTextWriter Writer = new XmlTextWriter(Stream, new UTF8Encoding())
            {
                Formatting = Formatting.Indented,
                IndentChar = ' ',
                Indentation = 5
            };

            try
            {
                Serializer.Serialize(Writer, Binds);
                XmlDocument xml = new XmlDocument();
                string xmlString = ASCIIEncoding.UTF8.GetString(Stream.ToArray());
                xml.LoadXml(xmlString);
                return xml;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Writer.Close();
                Stream.Close();
            }
            return null;
        }

        #region Elements
        [XmlRoot(ElementName = "MouseXMode")]
        public class MouseXMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseXDecay")]
        public class MouseXDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseYMode")]
        public class MouseYMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseYDecay")]
        public class MouseYDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "Primary")]
        public class Primary
        {
            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; set; }
            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }
            [XmlElement(ElementName = "Modifier")]
            public List<Modifier> Modifier { get; set; }
        }

        [XmlRoot(ElementName = "Secondary")]
        public class Secondary
        {
            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; set; }
            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }
            [XmlElement(ElementName = "Modifier")]
            public Modifier Modifier { get; set; }
        }

        [XmlRoot(ElementName = "MouseReset")]
        public class MouseReset
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MouseSensitivity")]
        public class MouseSensitivity
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseDecayRate")]
        public class MouseDecayRate
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseDeadzone")]
        public class MouseDeadzone
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseLinearity")]
        public class MouseLinearity
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseGUI")]
        public class MouseGUI
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "Binding")]
        public class Binding
        {
            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; set; }
            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }
        }

        [XmlRoot(ElementName = "Inverted")]
        public class Inverted
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "Deadzone")]
        public class Deadzone
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "YawAxisRaw")]
        public class YawAxisRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "YawLeftButton")]
        public class YawLeftButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawRightButton")]
        public class YawRightButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawToRollMode")]
        public class YawToRollMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "YawToRollSensitivity")]
        public class YawToRollSensitivity
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "YawToRollMode_FAOff")]
        public class YawToRollMode_FAOff
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "ToggleOn")]
        public class ToggleOn
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "YawToRollButton")]
        public class YawToRollButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "RollAxisRaw")]
        public class RollAxisRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "RollLeftButton")]
        public class RollLeftButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RollRightButton")]
        public class RollRightButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PitchAxisRaw")]
        public class PitchAxisRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "PitchUpButton")]
        public class PitchUpButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PitchDownButton")]
        public class PitchDownButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "LateralThrustRaw")]
        public class LateralThrustRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "LeftThrustButton")]
        public class LeftThrustButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RightThrustButton")]
        public class RightThrustButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VerticalThrustRaw")]
        public class VerticalThrustRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "UpThrustButton")]
        public class UpThrustButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DownThrustButton")]
        public class DownThrustButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "AheadThrust")]
        public class AheadThrust
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ForwardThrustButton")]
        public class ForwardThrustButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BackwardThrustButton")]
        public class BackwardThrustButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UseAlternateFlightValuesToggle")]
        public class UseAlternateFlightValuesToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "YawAxisAlternate")]
        public class YawAxisAlternate
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "RollAxisAlternate")]
        public class RollAxisAlternate
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "PitchAxisAlternate")]
        public class PitchAxisAlternate
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "LateralThrustAlternate")]
        public class LateralThrustAlternate
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "VerticalThrustAlternate")]
        public class VerticalThrustAlternate
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ThrottleAxis")]
        public class ThrottleAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ThrottleRange")]
        public class ThrottleRange
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "Modifier")]
        public class Modifier
        {
            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; set; }
            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }
        }

        [XmlRoot(ElementName = "ToggleReverseThrottleInput")]
        public class ToggleReverseThrottleInput
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "ForwardKey")]
        public class ForwardKey
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BackwardKey")]
        public class BackwardKey
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ThrottleIncrement")]
        public class ThrottleIncrement
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus100")]
        public class SetSpeedMinus100
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus75")]
        public class SetSpeedMinus75
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus50")]
        public class SetSpeedMinus50
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus25")]
        public class SetSpeedMinus25
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeedZero")]
        public class SetSpeedZero
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeed25")]
        public class SetSpeed25
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeed50")]
        public class SetSpeed50
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeed75")]
        public class SetSpeed75
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeed100")]
        public class SetSpeed100
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawAxis_Landing")]
        public class YawAxis_Landing
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "YawLeftButton_Landing")]
        public class YawLeftButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawRightButton_Landing")]
        public class YawRightButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawToRollMode_Landing")]
        public class YawToRollMode_Landing
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "PitchAxis_Landing")]
        public class PitchAxis_Landing
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "PitchUpButton_Landing")]
        public class PitchUpButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PitchDownButton_Landing")]
        public class PitchDownButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RollAxis_Landing")]
        public class RollAxis_Landing
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "RollLeftButton_Landing")]
        public class RollLeftButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RollRightButton_Landing")]
        public class RollRightButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "LateralThrust_Landing")]
        public class LateralThrust_Landing
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "LeftThrustButton_Landing")]
        public class LeftThrustButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RightThrustButton_Landing")]
        public class RightThrustButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VerticalThrust_Landing")]
        public class VerticalThrust_Landing
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "UpThrustButton_Landing")]
        public class UpThrustButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DownThrustButton_Landing")]
        public class DownThrustButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "AheadThrust_Landing")]
        public class AheadThrust_Landing
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ForwardThrustButton_Landing")]
        public class ForwardThrustButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BackwardThrustButton_Landing")]
        public class BackwardThrustButton_Landing
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleFlightAssist")]
        public class ToggleFlightAssist
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "UseBoostJuice")]
        public class UseBoostJuice
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HyperSuperCombination")]
        public class HyperSuperCombination
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "Supercruise")]
        public class Supercruise
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "Hyperspace")]
        public class Hyperspace
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DisableRotationCorrectToggle")]
        public class DisableRotationCorrectToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "OrbitLinesToggle")]
        public class OrbitLinesToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SelectTarget")]
        public class SelectTarget
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleNextTarget")]
        public class CycleNextTarget
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CyclePreviousTarget")]
        public class CyclePreviousTarget
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SelectHighestThreat")]
        public class SelectHighestThreat
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleNextHostileTarget")]
        public class CycleNextHostileTarget
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CyclePreviousHostileTarget")]
        public class CyclePreviousHostileTarget
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "TargetWingman0")]
        public class TargetWingman0
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "TargetWingman1")]
        public class TargetWingman1
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "TargetWingman2")]
        public class TargetWingman2
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SelectTargetsTarget")]
        public class SelectTargetsTarget
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "WingNavLock")]
        public class WingNavLock
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleNextSubsystem")]
        public class CycleNextSubsystem
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CyclePreviousSubsystem")]
        public class CyclePreviousSubsystem
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "TargetNextRouteSystem")]
        public class TargetNextRouteSystem
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PrimaryFire")]
        public class PrimaryFire
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SecondaryFire")]
        public class SecondaryFire
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleFireGroupNext")]
        public class CycleFireGroupNext
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleFireGroupPrevious")]
        public class CycleFireGroupPrevious
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DeployHardpointToggle")]
        public class DeployHardpointToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DeployHardpointsOnFire")]
        public class DeployHardpointsOnFire
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "ToggleButtonUpInput")]
        public class ToggleButtonUpInput
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "DeployHeatSink")]
        public class DeployHeatSink
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ShipSpotLightToggle")]
        public class ShipSpotLightToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RadarRangeAxis")]
        public class RadarRangeAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "RadarIncreaseRange")]
        public class RadarIncreaseRange
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RadarDecreaseRange")]
        public class RadarDecreaseRange
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseEnginesPower")]
        public class IncreaseEnginesPower
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseWeaponsPower")]
        public class IncreaseWeaponsPower
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseSystemsPower")]
        public class IncreaseSystemsPower
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ResetPowerDistribution")]
        public class ResetPowerDistribution
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HMDReset")]
        public class HMDReset
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleCargoScoop")]
        public class ToggleCargoScoop
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "EjectAllCargo")]
        public class EjectAllCargo
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "LandingGearToggle")]
        public class LandingGearToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MicrophoneMute")]
        public class MicrophoneMute
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "MuteButtonMode")]
        public class MuteButtonMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "CqcMuteButtonMode")]
        public class CqcMuteButtonMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "UseShieldCell")]
        public class UseShieldCell
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FireChaffLauncher")]
        public class FireChaffLauncher
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ChargeECM")]
        public class ChargeECM
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "EnableRumbleTrigger")]
        public class EnableRumbleTrigger
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "EnableMenuGroups")]
        public class EnableMenuGroups
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "WeaponColourToggle")]
        public class WeaponColourToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "EngineColourToggle")]
        public class EngineColourToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UIFocus")]
        public class UIFocus
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UIFocusMode")]
        public class UIFocusMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "FocusLeftPanel")]
        public class FocusLeftPanel
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusCommsPanel")]
        public class FocusCommsPanel
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusOnTextEntryField")]
        public class FocusOnTextEntryField
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "QuickCommsPanel")]
        public class QuickCommsPanel
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusRadarPanel")]
        public class FocusRadarPanel
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusRightPanel")]
        public class FocusRightPanel
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "LeftPanelFocusOptions")]
        public class LeftPanelFocusOptions
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "CommsPanelFocusOptions")]
        public class CommsPanelFocusOptions
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "RolePanelFocusOptions")]
        public class RolePanelFocusOptions
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "RightPanelFocusOptions")]
        public class RightPanelFocusOptions
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "EnableCameraLockOn")]
        public class EnableCameraLockOn
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "GalaxyMapOpen")]
        public class GalaxyMapOpen
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SystemMapOpen")]
        public class SystemMapOpen
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ShowPGScoreSummaryInput")]
        public class ShowPGScoreSummaryInput
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookToggle")]
        public class HeadLookToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "Pause")]
        public class Pause
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FriendsMenu")]
        public class FriendsMenu
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Up")]
        public class UI_Up
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Down")]
        public class UI_Down
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Left")]
        public class UI_Left
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Right")]
        public class UI_Right
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Select")]
        public class UI_Select
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Back")]
        public class UI_Back
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Toggle")]
        public class UI_Toggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleNextPanel")]
        public class CycleNextPanel
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CyclePreviousPanel")]
        public class CyclePreviousPanel
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MouseHeadlook")]
        public class MouseHeadlook
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseHeadlookInvert")]
        public class MouseHeadlookInvert
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseHeadlookSensitivity")]
        public class MouseHeadlookSensitivity
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookDefault")]
        public class HeadlookDefault
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookIncrement")]
        public class HeadlookIncrement
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookMode")]
        public class HeadlookMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookResetOnToggle")]
        public class HeadlookResetOnToggle
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookSensitivity")]
        public class HeadlookSensitivity
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookSmoothing")]
        public class HeadlookSmoothing
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookReset")]
        public class HeadLookReset
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookPitchUp")]
        public class HeadLookPitchUp
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookPitchDown")]
        public class HeadLookPitchDown
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookPitchAxisRaw")]
        public class HeadLookPitchAxisRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookYawLeft")]
        public class HeadLookYawLeft
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookYawRight")]
        public class HeadLookYawRight
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookYawAxis")]
        public class HeadLookYawAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MotionHeadlook")]
        public class MotionHeadlook
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookMotionSensitivity")]
        public class HeadlookMotionSensitivity
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "yawRotateHeadlook")]
        public class YawRotateHeadlook
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "CamPitchAxis")]
        public class CamPitchAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamPitchUp")]
        public class CamPitchUp
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamPitchDown")]
        public class CamPitchDown
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamYawAxis")]
        public class CamYawAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamYawLeft")]
        public class CamYawLeft
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamYawRight")]
        public class CamYawRight
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateYAxis")]
        public class CamTranslateYAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateForward")]
        public class CamTranslateForward
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateBackward")]
        public class CamTranslateBackward
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateXAxis")]
        public class CamTranslateXAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateLeft")]
        public class CamTranslateLeft
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateRight")]
        public class CamTranslateRight
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateZAxis")]
        public class CamTranslateZAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateUp")]
        public class CamTranslateUp
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateDown")]
        public class CamTranslateDown
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamZoomAxis")]
        public class CamZoomAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamZoomIn")]
        public class CamZoomIn
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamZoomOut")]
        public class CamZoomOut
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateZHold")]
        public class CamTranslateZHold
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "ToggleDriveAssist")]
        public class ToggleDriveAssist
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "DriveAssistDefault")]
        public class DriveAssistDefault
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggySteeringXMode")]
        public class MouseBuggySteeringXMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggySteeringXDecay")]
        public class MouseBuggySteeringXDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggyRollingXMode")]
        public class MouseBuggyRollingXMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggyRollingXDecay")]
        public class MouseBuggyRollingXDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggyYMode")]
        public class MouseBuggyYMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggyYDecay")]
        public class MouseBuggyYDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "SteeringAxis")]
        public class SteeringAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "SteerLeftButton")]
        public class SteerLeftButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SteerRightButton")]
        public class SteerRightButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyRollAxisRaw")]
        public class BuggyRollAxisRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "BuggyRollLeftButton")]
        public class BuggyRollLeftButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyRollRightButton")]
        public class BuggyRollRightButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyPitchAxis")]
        public class BuggyPitchAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "BuggyPitchUpButton")]
        public class BuggyPitchUpButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyPitchDownButton")]
        public class BuggyPitchDownButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VerticalThrustersButton")]
        public class VerticalThrustersButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "BuggyPrimaryFireButton")]
        public class BuggyPrimaryFireButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggySecondaryFireButton")]
        public class BuggySecondaryFireButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "AutoBreakBuggyButton")]
        public class AutoBreakBuggyButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "HeadlightsBuggyButton")]
        public class HeadlightsBuggyButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleBuggyTurretButton")]
        public class ToggleBuggyTurretButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SelectTarget_Buggy")]
        public class SelectTarget_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MouseTurretXMode")]
        public class MouseTurretXMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseTurretXDecay")]
        public class MouseTurretXDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseTurretYMode")]
        public class MouseTurretYMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseTurretYDecay")]
        public class MouseTurretYDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretYawAxisRaw")]
        public class BuggyTurretYawAxisRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretYawLeftButton")]
        public class BuggyTurretYawLeftButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretYawRightButton")]
        public class BuggyTurretYawRightButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretPitchAxisRaw")]
        public class BuggyTurretPitchAxisRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretPitchUpButton")]
        public class BuggyTurretPitchUpButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretPitchDownButton")]
        public class BuggyTurretPitchDownButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DriveSpeedAxis")]
        public class DriveSpeedAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "BuggyThrottleRange")]
        public class BuggyThrottleRange
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "BuggyToggleReverseThrottleInput")]
        public class BuggyToggleReverseThrottleInput
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "BuggyThrottleIncrement")]
        public class BuggyThrottleIncrement
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseSpeedButtonMax")]
        public class IncreaseSpeedButtonMax
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DecreaseSpeedButtonMax")]
        public class DecreaseSpeedButtonMax
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseSpeedButtonPartial")]
        public class IncreaseSpeedButtonPartial
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "DecreaseSpeedButtonPartial")]
        public class DecreaseSpeedButtonPartial
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseEnginesPower_Buggy")]
        public class IncreaseEnginesPower_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseWeaponsPower_Buggy")]
        public class IncreaseWeaponsPower_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseSystemsPower_Buggy")]
        public class IncreaseSystemsPower_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ResetPowerDistribution_Buggy")]
        public class ResetPowerDistribution_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleCargoScoop_Buggy")]
        public class ToggleCargoScoop_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "EjectAllCargo_Buggy")]
        public class EjectAllCargo_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RecallDismissShip")]
        public class RecallDismissShip
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UIFocus_Buggy")]
        public class UIFocus_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusLeftPanel_Buggy")]
        public class FocusLeftPanel_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusCommsPanel_Buggy")]
        public class FocusCommsPanel_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "QuickCommsPanel_Buggy")]
        public class QuickCommsPanel_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusRadarPanel_Buggy")]
        public class FocusRadarPanel_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusRightPanel_Buggy")]
        public class FocusRightPanel_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "GalaxyMapOpen_Buggy")]
        public class GalaxyMapOpen_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SystemMapOpen_Buggy")]
        public class SystemMapOpen_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookToggle_Buggy")]
        public class HeadLookToggle_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewToggleMode")]
        public class MultiCrewToggleMode
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewPrimaryFire")]
        public class MultiCrewPrimaryFire
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewSecondaryFire")]
        public class MultiCrewSecondaryFire
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewPrimaryUtilityFire")]
        public class MultiCrewPrimaryUtilityFire
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewSecondaryUtilityFire")]
        public class MultiCrewSecondaryUtilityFire
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseXMode")]
        public class MultiCrewThirdPersonMouseXMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseXDecay")]
        public class MultiCrewThirdPersonMouseXDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseYMode")]
        public class MultiCrewThirdPersonMouseYMode
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseYDecay")]
        public class MultiCrewThirdPersonMouseYDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
        public class MultiCrewThirdPersonYawAxisRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonYawLeftButton")]
        public class MultiCrewThirdPersonYawLeftButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonYawRightButton")]
        public class MultiCrewThirdPersonYawRightButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
        public class MultiCrewThirdPersonPitchAxisRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonPitchUpButton")]
        public class MultiCrewThirdPersonPitchUpButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonPitchDownButton")]
        public class MultiCrewThirdPersonPitchDownButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
        public class MultiCrewThirdPersonMouseSensitivity
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
        public class MultiCrewThirdPersonFovAxisRaw
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonFovOutButton")]
        public class MultiCrewThirdPersonFovOutButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonFovInButton")]
        public class MultiCrewThirdPersonFovInButton
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewCockpitUICycleForward")]
        public class MultiCrewCockpitUICycleForward
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewCockpitUICycleBackward")]
        public class MultiCrewCockpitUICycleBackward
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderRequestDock")]
        public class OrderRequestDock
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderDefensiveBehaviour")]
        public class OrderDefensiveBehaviour
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderAggressiveBehaviour")]
        public class OrderAggressiveBehaviour
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderFocusTarget")]
        public class OrderFocusTarget
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderHoldFire")]
        public class OrderHoldFire
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderHoldPosition")]
        public class OrderHoldPosition
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderFollow")]
        public class OrderFollow
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OpenOrders")]
        public class OpenOrders
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PhotoCameraToggle")]
        public class PhotoCameraToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PhotoCameraToggle_Buggy")]
        public class PhotoCameraToggle_Buggy
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraScrollLeft")]
        public class VanityCameraScrollLeft
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraScrollRight")]
        public class VanityCameraScrollRight
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleFreeCam")]
        public class ToggleFreeCam
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraOne")]
        public class VanityCameraOne
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraTwo")]
        public class VanityCameraTwo
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraThree")]
        public class VanityCameraThree
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraFour")]
        public class VanityCameraFour
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraFive")]
        public class VanityCameraFive
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraSix")]
        public class VanityCameraSix
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraSeven")]
        public class VanityCameraSeven
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraEight")]
        public class VanityCameraEight
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraNine")]
        public class VanityCameraNine
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamToggleHUD")]
        public class FreeCamToggleHUD
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamSpeedInc")]
        public class FreeCamSpeedInc
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamSpeedDec")]
        public class FreeCamSpeedDec
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamY")]
        public class MoveFreeCamY
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ThrottleRangeFreeCam")]
        public class ThrottleRangeFreeCam
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "ToggleReverseThrottleInputFreeCam")]
        public class ToggleReverseThrottleInputFreeCam
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOn ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamForward")]
        public class MoveFreeCamForward
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamBackwards")]
        public class MoveFreeCamBackwards
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamX")]
        public class MoveFreeCamX
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamRight")]
        public class MoveFreeCamRight
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamLeft")]
        public class MoveFreeCamLeft
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamZ")]
        public class MoveFreeCamZ
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamUpAxis")]
        public class MoveFreeCamUpAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamDownAxis")]
        public class MoveFreeCamDownAxis
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamUp")]
        public class MoveFreeCamUp
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamDown")]
        public class MoveFreeCamDown
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PitchCameraMouse")]
        public class PitchCameraMouse
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "YawCameraMouse")]
        public class YawCameraMouse
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "PitchCamera")]
        public class PitchCamera
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamMouseSensitivity")]
        public class FreeCamMouseSensitivity
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamMouseYDecay")]
        public class FreeCamMouseYDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "PitchCameraUp")]
        public class PitchCameraUp
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PitchCameraDown")]
        public class PitchCameraDown
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawCamera")]
        public class YawCamera
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamMouseXDecay")]
        public class FreeCamMouseXDecay
        {
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "YawCameraLeft")]
        public class YawCameraLeft
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawCameraRight")]
        public class YawCameraRight
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RollCamera")]
        public class RollCamera
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "RollCameraLeft")]
        public class RollCameraLeft
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RollCameraRight")]
        public class RollCameraRight
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleRotationLock")]
        public class ToggleRotationLock
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FixCameraRelativeToggle")]
        public class FixCameraRelativeToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FixCameraWorldToggle")]
        public class FixCameraWorldToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "QuitCamera")]
        public class QuitCamera
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleAdvanceMode")]
        public class ToggleAdvanceMode
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamZoomIn")]
        public class FreeCamZoomIn
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamZoomOut")]
        public class FreeCamZoomOut
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FStopDec")]
        public class FStopDec
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FStopInc")]
        public class FStopInc
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Undo")]
        public class CommanderCreator_Undo
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Redo")]
        public class CommanderCreator_Redo
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Rotation_MouseToggle")]
        public class CommanderCreator_Rotation_MouseToggle
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Rotation")]
        public class CommanderCreator_Rotation
        {
            [XmlElement(ElementName = "Binding")]
            public Binding Binding { get; set; }
            [XmlElement(ElementName = "Inverted")]
            public Inverted Inverted { get; set; }
            [XmlElement(ElementName = "Deadzone")]
            public Deadzone Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_Play_Pause")]
        public class GalnetAudio_Play_Pause
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_SkipForward")]
        public class GalnetAudio_SkipForward
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_SkipBackward")]
        public class GalnetAudio_SkipBackward
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_ClearQueue")]
        public class GalnetAudio_ClearQueue
        {
            [XmlElement(ElementName = "Primary")]
            public Primary Primary { get; set; }
            [XmlElement(ElementName = "Secondary")]
            public Secondary Secondary { get; set; }
        }
        #endregion

        [Serializable]
        [XmlRoot(ElementName = "Root")]
        public class Root
        {
            [XmlElement(ElementName = "KeyboardLayout")]
            public string KeyboardLayout { get; set; }
            [XmlElement(ElementName = "MouseXMode")]
            public MouseXMode MouseXMode { get; set; }
            [XmlElement(ElementName = "MouseXDecay")]
            public MouseXDecay MouseXDecay { get; set; }
            [XmlElement(ElementName = "MouseYMode")]
            public MouseYMode MouseYMode { get; set; }
            [XmlElement(ElementName = "MouseYDecay")]
            public MouseYDecay MouseYDecay { get; set; }
            [XmlElement(ElementName = "MouseReset")]
            public MouseReset MouseReset { get; set; }
            [XmlElement(ElementName = "MouseSensitivity")]
            public MouseSensitivity MouseSensitivity { get; set; }
            [XmlElement(ElementName = "MouseDecayRate")]
            public MouseDecayRate MouseDecayRate { get; set; }
            [XmlElement(ElementName = "MouseDeadzone")]
            public MouseDeadzone MouseDeadzone { get; set; }
            [XmlElement(ElementName = "MouseLinearity")]
            public MouseLinearity MouseLinearity { get; set; }
            [XmlElement(ElementName = "MouseGUI")]
            public List<MouseGUI> MouseGUI { get; set; }
            [XmlElement(ElementName = "YawAxisRaw")]
            public YawAxisRaw YawAxisRaw { get; set; }
            [XmlElement(ElementName = "YawLeftButton")]
            public YawLeftButton YawLeftButton { get; set; }
            [XmlElement(ElementName = "YawRightButton")]
            public YawRightButton YawRightButton { get; set; }
            [XmlElement(ElementName = "YawToRollMode")]
            public YawToRollMode YawToRollMode { get; set; }
            [XmlElement(ElementName = "YawToRollSensitivity")]
            public YawToRollSensitivity YawToRollSensitivity { get; set; }
            [XmlElement(ElementName = "YawToRollMode_FAOff")]
            public YawToRollMode_FAOff YawToRollMode_FAOff { get; set; }
            [XmlElement(ElementName = "YawToRollButton")]
            public YawToRollButton YawToRollButton { get; set; }
            [XmlElement(ElementName = "RollAxisRaw")]
            public RollAxisRaw RollAxisRaw { get; set; }
            [XmlElement(ElementName = "RollLeftButton")]
            public RollLeftButton RollLeftButton { get; set; }
            [XmlElement(ElementName = "RollRightButton")]
            public RollRightButton RollRightButton { get; set; }
            [XmlElement(ElementName = "PitchAxisRaw")]
            public PitchAxisRaw PitchAxisRaw { get; set; }
            [XmlElement(ElementName = "PitchUpButton")]
            public PitchUpButton PitchUpButton { get; set; }
            [XmlElement(ElementName = "PitchDownButton")]
            public PitchDownButton PitchDownButton { get; set; }
            [XmlElement(ElementName = "LateralThrustRaw")]
            public LateralThrustRaw LateralThrustRaw { get; set; }
            [XmlElement(ElementName = "LeftThrustButton")]
            public LeftThrustButton LeftThrustButton { get; set; }
            [XmlElement(ElementName = "RightThrustButton")]
            public RightThrustButton RightThrustButton { get; set; }
            [XmlElement(ElementName = "VerticalThrustRaw")]
            public VerticalThrustRaw VerticalThrustRaw { get; set; }
            [XmlElement(ElementName = "UpThrustButton")]
            public UpThrustButton UpThrustButton { get; set; }
            [XmlElement(ElementName = "DownThrustButton")]
            public DownThrustButton DownThrustButton { get; set; }
            [XmlElement(ElementName = "AheadThrust")]
            public AheadThrust AheadThrust { get; set; }
            [XmlElement(ElementName = "ForwardThrustButton")]
            public ForwardThrustButton ForwardThrustButton { get; set; }
            [XmlElement(ElementName = "BackwardThrustButton")]
            public BackwardThrustButton BackwardThrustButton { get; set; }
            [XmlElement(ElementName = "UseAlternateFlightValuesToggle")]
            public UseAlternateFlightValuesToggle UseAlternateFlightValuesToggle { get; set; }
            [XmlElement(ElementName = "YawAxisAlternate")]
            public YawAxisAlternate YawAxisAlternate { get; set; }
            [XmlElement(ElementName = "RollAxisAlternate")]
            public RollAxisAlternate RollAxisAlternate { get; set; }
            [XmlElement(ElementName = "PitchAxisAlternate")]
            public PitchAxisAlternate PitchAxisAlternate { get; set; }
            [XmlElement(ElementName = "LateralThrustAlternate")]
            public LateralThrustAlternate LateralThrustAlternate { get; set; }
            [XmlElement(ElementName = "VerticalThrustAlternate")]
            public VerticalThrustAlternate VerticalThrustAlternate { get; set; }
            [XmlElement(ElementName = "ThrottleAxis")]
            public ThrottleAxis ThrottleAxis { get; set; }
            [XmlElement(ElementName = "ThrottleRange")]
            public ThrottleRange ThrottleRange { get; set; }
            [XmlElement(ElementName = "ToggleReverseThrottleInput")]
            public ToggleReverseThrottleInput ToggleReverseThrottleInput { get; set; }
            [XmlElement(ElementName = "ForwardKey")]
            public ForwardKey ForwardKey { get; set; }
            [XmlElement(ElementName = "BackwardKey")]
            public BackwardKey BackwardKey { get; set; }
            [XmlElement(ElementName = "ThrottleIncrement")]
            public ThrottleIncrement ThrottleIncrement { get; set; }
            [XmlElement(ElementName = "SetSpeedMinus100")]
            public SetSpeedMinus100 SetSpeedMinus100 { get; set; }
            [XmlElement(ElementName = "SetSpeedMinus75")]
            public SetSpeedMinus75 SetSpeedMinus75 { get; set; }
            [XmlElement(ElementName = "SetSpeedMinus50")]
            public SetSpeedMinus50 SetSpeedMinus50 { get; set; }
            [XmlElement(ElementName = "SetSpeedMinus25")]
            public SetSpeedMinus25 SetSpeedMinus25 { get; set; }
            [XmlElement(ElementName = "SetSpeedZero")]
            public SetSpeedZero SetSpeedZero { get; set; }
            [XmlElement(ElementName = "SetSpeed25")]
            public SetSpeed25 SetSpeed25 { get; set; }
            [XmlElement(ElementName = "SetSpeed50")]
            public SetSpeed50 SetSpeed50 { get; set; }
            [XmlElement(ElementName = "SetSpeed75")]
            public SetSpeed75 SetSpeed75 { get; set; }
            [XmlElement(ElementName = "SetSpeed100")]
            public SetSpeed100 SetSpeed100 { get; set; }
            [XmlElement(ElementName = "YawAxis_Landing")]
            public YawAxis_Landing YawAxis_Landing { get; set; }
            [XmlElement(ElementName = "YawLeftButton_Landing")]
            public YawLeftButton_Landing YawLeftButton_Landing { get; set; }
            [XmlElement(ElementName = "YawRightButton_Landing")]
            public YawRightButton_Landing YawRightButton_Landing { get; set; }
            [XmlElement(ElementName = "YawToRollMode_Landing")]
            public YawToRollMode_Landing YawToRollMode_Landing { get; set; }
            [XmlElement(ElementName = "PitchAxis_Landing")]
            public PitchAxis_Landing PitchAxis_Landing { get; set; }
            [XmlElement(ElementName = "PitchUpButton_Landing")]
            public PitchUpButton_Landing PitchUpButton_Landing { get; set; }
            [XmlElement(ElementName = "PitchDownButton_Landing")]
            public PitchDownButton_Landing PitchDownButton_Landing { get; set; }
            [XmlElement(ElementName = "RollAxis_Landing")]
            public RollAxis_Landing RollAxis_Landing { get; set; }
            [XmlElement(ElementName = "RollLeftButton_Landing")]
            public RollLeftButton_Landing RollLeftButton_Landing { get; set; }
            [XmlElement(ElementName = "RollRightButton_Landing")]
            public RollRightButton_Landing RollRightButton_Landing { get; set; }
            [XmlElement(ElementName = "LateralThrust_Landing")]
            public LateralThrust_Landing LateralThrust_Landing { get; set; }
            [XmlElement(ElementName = "LeftThrustButton_Landing")]
            public LeftThrustButton_Landing LeftThrustButton_Landing { get; set; }
            [XmlElement(ElementName = "RightThrustButton_Landing")]
            public RightThrustButton_Landing RightThrustButton_Landing { get; set; }
            [XmlElement(ElementName = "VerticalThrust_Landing")]
            public VerticalThrust_Landing VerticalThrust_Landing { get; set; }
            [XmlElement(ElementName = "UpThrustButton_Landing")]
            public UpThrustButton_Landing UpThrustButton_Landing { get; set; }
            [XmlElement(ElementName = "DownThrustButton_Landing")]
            public DownThrustButton_Landing DownThrustButton_Landing { get; set; }
            [XmlElement(ElementName = "AheadThrust_Landing")]
            public AheadThrust_Landing AheadThrust_Landing { get; set; }
            [XmlElement(ElementName = "ForwardThrustButton_Landing")]
            public ForwardThrustButton_Landing ForwardThrustButton_Landing { get; set; }
            [XmlElement(ElementName = "BackwardThrustButton_Landing")]
            public BackwardThrustButton_Landing BackwardThrustButton_Landing { get; set; }
            [XmlElement(ElementName = "ToggleFlightAssist")]
            public ToggleFlightAssist ToggleFlightAssist { get; set; }
            [XmlElement(ElementName = "UseBoostJuice")]
            public UseBoostJuice UseBoostJuice { get; set; }
            [XmlElement(ElementName = "HyperSuperCombination")]
            public HyperSuperCombination HyperSuperCombination { get; set; }
            [XmlElement(ElementName = "Supercruise")]
            public Supercruise Supercruise { get; set; }
            [XmlElement(ElementName = "Hyperspace")]
            public Hyperspace Hyperspace { get; set; }
            [XmlElement(ElementName = "DisableRotationCorrectToggle")]
            public DisableRotationCorrectToggle DisableRotationCorrectToggle { get; set; }
            [XmlElement(ElementName = "OrbitLinesToggle")]
            public OrbitLinesToggle OrbitLinesToggle { get; set; }
            [XmlElement(ElementName = "SelectTarget")]
            public SelectTarget SelectTarget { get; set; }
            [XmlElement(ElementName = "CycleNextTarget")]
            public CycleNextTarget CycleNextTarget { get; set; }
            [XmlElement(ElementName = "CyclePreviousTarget")]
            public CyclePreviousTarget CyclePreviousTarget { get; set; }
            [XmlElement(ElementName = "SelectHighestThreat")]
            public SelectHighestThreat SelectHighestThreat { get; set; }
            [XmlElement(ElementName = "CycleNextHostileTarget")]
            public CycleNextHostileTarget CycleNextHostileTarget { get; set; }
            [XmlElement(ElementName = "CyclePreviousHostileTarget")]
            public CyclePreviousHostileTarget CyclePreviousHostileTarget { get; set; }
            [XmlElement(ElementName = "TargetWingman0")]
            public TargetWingman0 TargetWingman0 { get; set; }
            [XmlElement(ElementName = "TargetWingman1")]
            public TargetWingman1 TargetWingman1 { get; set; }
            [XmlElement(ElementName = "TargetWingman2")]
            public TargetWingman2 TargetWingman2 { get; set; }
            [XmlElement(ElementName = "SelectTargetsTarget")]
            public SelectTargetsTarget SelectTargetsTarget { get; set; }
            [XmlElement(ElementName = "WingNavLock")]
            public WingNavLock WingNavLock { get; set; }
            [XmlElement(ElementName = "CycleNextSubsystem")]
            public CycleNextSubsystem CycleNextSubsystem { get; set; }
            [XmlElement(ElementName = "CyclePreviousSubsystem")]
            public CyclePreviousSubsystem CyclePreviousSubsystem { get; set; }
            [XmlElement(ElementName = "TargetNextRouteSystem")]
            public TargetNextRouteSystem TargetNextRouteSystem { get; set; }
            [XmlElement(ElementName = "PrimaryFire")]
            public PrimaryFire PrimaryFire { get; set; }
            [XmlElement(ElementName = "SecondaryFire")]
            public SecondaryFire SecondaryFire { get; set; }
            [XmlElement(ElementName = "CycleFireGroupNext")]
            public CycleFireGroupNext CycleFireGroupNext { get; set; }
            [XmlElement(ElementName = "CycleFireGroupPrevious")]
            public CycleFireGroupPrevious CycleFireGroupPrevious { get; set; }
            [XmlElement(ElementName = "DeployHardpointToggle")]
            public DeployHardpointToggle DeployHardpointToggle { get; set; }
            [XmlElement(ElementName = "DeployHardpointsOnFire")]
            public DeployHardpointsOnFire DeployHardpointsOnFire { get; set; }
            [XmlElement(ElementName = "ToggleButtonUpInput")]
            public ToggleButtonUpInput ToggleButtonUpInput { get; set; }
            [XmlElement(ElementName = "DeployHeatSink")]
            public DeployHeatSink DeployHeatSink { get; set; }
            [XmlElement(ElementName = "ShipSpotLightToggle")]
            public ShipSpotLightToggle ShipSpotLightToggle { get; set; }
            [XmlElement(ElementName = "RadarRangeAxis")]
            public RadarRangeAxis RadarRangeAxis { get; set; }
            [XmlElement(ElementName = "RadarIncreaseRange")]
            public RadarIncreaseRange RadarIncreaseRange { get; set; }
            [XmlElement(ElementName = "RadarDecreaseRange")]
            public RadarDecreaseRange RadarDecreaseRange { get; set; }
            [XmlElement(ElementName = "IncreaseEnginesPower")]
            public IncreaseEnginesPower IncreaseEnginesPower { get; set; }
            [XmlElement(ElementName = "IncreaseWeaponsPower")]
            public IncreaseWeaponsPower IncreaseWeaponsPower { get; set; }
            [XmlElement(ElementName = "IncreaseSystemsPower")]
            public IncreaseSystemsPower IncreaseSystemsPower { get; set; }
            [XmlElement(ElementName = "ResetPowerDistribution")]
            public ResetPowerDistribution ResetPowerDistribution { get; set; }
            [XmlElement(ElementName = "HMDReset")]
            public HMDReset HMDReset { get; set; }
            [XmlElement(ElementName = "ToggleCargoScoop")]
            public ToggleCargoScoop ToggleCargoScoop { get; set; }
            [XmlElement(ElementName = "EjectAllCargo")]
            public EjectAllCargo EjectAllCargo { get; set; }
            [XmlElement(ElementName = "LandingGearToggle")]
            public LandingGearToggle LandingGearToggle { get; set; }
            [XmlElement(ElementName = "MicrophoneMute")]
            public MicrophoneMute MicrophoneMute { get; set; }
            [XmlElement(ElementName = "MuteButtonMode")]
            public MuteButtonMode MuteButtonMode { get; set; }
            [XmlElement(ElementName = "CqcMuteButtonMode")]
            public CqcMuteButtonMode CqcMuteButtonMode { get; set; }
            [XmlElement(ElementName = "UseShieldCell")]
            public UseShieldCell UseShieldCell { get; set; }
            [XmlElement(ElementName = "FireChaffLauncher")]
            public FireChaffLauncher FireChaffLauncher { get; set; }
            [XmlElement(ElementName = "ChargeECM")]
            public ChargeECM ChargeECM { get; set; }
            [XmlElement(ElementName = "EnableRumbleTrigger")]
            public EnableRumbleTrigger EnableRumbleTrigger { get; set; }
            [XmlElement(ElementName = "EnableMenuGroups")]
            public EnableMenuGroups EnableMenuGroups { get; set; }
            [XmlElement(ElementName = "WeaponColourToggle")]
            public WeaponColourToggle WeaponColourToggle { get; set; }
            [XmlElement(ElementName = "EngineColourToggle")]
            public EngineColourToggle EngineColourToggle { get; set; }
            [XmlElement(ElementName = "UIFocus")]
            public UIFocus UIFocus { get; set; }
            [XmlElement(ElementName = "UIFocusMode")]
            public UIFocusMode UIFocusMode { get; set; }
            [XmlElement(ElementName = "FocusLeftPanel")]
            public FocusLeftPanel FocusLeftPanel { get; set; }
            [XmlElement(ElementName = "FocusCommsPanel")]
            public FocusCommsPanel FocusCommsPanel { get; set; }
            [XmlElement(ElementName = "FocusOnTextEntryField")]
            public FocusOnTextEntryField FocusOnTextEntryField { get; set; }
            [XmlElement(ElementName = "QuickCommsPanel")]
            public QuickCommsPanel QuickCommsPanel { get; set; }
            [XmlElement(ElementName = "FocusRadarPanel")]
            public FocusRadarPanel FocusRadarPanel { get; set; }
            [XmlElement(ElementName = "FocusRightPanel")]
            public FocusRightPanel FocusRightPanel { get; set; }
            [XmlElement(ElementName = "LeftPanelFocusOptions")]
            public LeftPanelFocusOptions LeftPanelFocusOptions { get; set; }
            [XmlElement(ElementName = "CommsPanelFocusOptions")]
            public CommsPanelFocusOptions CommsPanelFocusOptions { get; set; }
            [XmlElement(ElementName = "RolePanelFocusOptions")]
            public RolePanelFocusOptions RolePanelFocusOptions { get; set; }
            [XmlElement(ElementName = "RightPanelFocusOptions")]
            public RightPanelFocusOptions RightPanelFocusOptions { get; set; }
            [XmlElement(ElementName = "EnableCameraLockOn")]
            public EnableCameraLockOn EnableCameraLockOn { get; set; }
            [XmlElement(ElementName = "GalaxyMapOpen")]
            public GalaxyMapOpen GalaxyMapOpen { get; set; }
            [XmlElement(ElementName = "SystemMapOpen")]
            public SystemMapOpen SystemMapOpen { get; set; }
            [XmlElement(ElementName = "ShowPGScoreSummaryInput")]
            public ShowPGScoreSummaryInput ShowPGScoreSummaryInput { get; set; }
            [XmlElement(ElementName = "HeadLookToggle")]
            public HeadLookToggle HeadLookToggle { get; set; }
            [XmlElement(ElementName = "Pause")]
            public Pause Pause { get; set; }
            [XmlElement(ElementName = "FriendsMenu")]
            public FriendsMenu FriendsMenu { get; set; }
            [XmlElement(ElementName = "UI_Up")]
            public UI_Up UI_Up { get; set; }
            [XmlElement(ElementName = "UI_Down")]
            public UI_Down UI_Down { get; set; }
            [XmlElement(ElementName = "UI_Left")]
            public UI_Left UI_Left { get; set; }
            [XmlElement(ElementName = "UI_Right")]
            public UI_Right UI_Right { get; set; }
            [XmlElement(ElementName = "UI_Select")]
            public UI_Select UI_Select { get; set; }
            [XmlElement(ElementName = "UI_Back")]
            public UI_Back UI_Back { get; set; }
            [XmlElement(ElementName = "UI_Toggle")]
            public UI_Toggle UI_Toggle { get; set; }
            [XmlElement(ElementName = "CycleNextPanel")]
            public CycleNextPanel CycleNextPanel { get; set; }
            [XmlElement(ElementName = "CyclePreviousPanel")]
            public CyclePreviousPanel CyclePreviousPanel { get; set; }
            [XmlElement(ElementName = "MouseHeadlook")]
            public MouseHeadlook MouseHeadlook { get; set; }
            [XmlElement(ElementName = "MouseHeadlookInvert")]
            public MouseHeadlookInvert MouseHeadlookInvert { get; set; }
            [XmlElement(ElementName = "MouseHeadlookSensitivity")]
            public MouseHeadlookSensitivity MouseHeadlookSensitivity { get; set; }
            [XmlElement(ElementName = "HeadlookDefault")]
            public HeadlookDefault HeadlookDefault { get; set; }
            [XmlElement(ElementName = "HeadlookIncrement")]
            public HeadlookIncrement HeadlookIncrement { get; set; }
            [XmlElement(ElementName = "HeadlookMode")]
            public HeadlookMode HeadlookMode { get; set; }
            [XmlElement(ElementName = "HeadlookResetOnToggle")]
            public HeadlookResetOnToggle HeadlookResetOnToggle { get; set; }
            [XmlElement(ElementName = "HeadlookSensitivity")]
            public HeadlookSensitivity HeadlookSensitivity { get; set; }
            [XmlElement(ElementName = "HeadlookSmoothing")]
            public HeadlookSmoothing HeadlookSmoothing { get; set; }
            [XmlElement(ElementName = "HeadLookReset")]
            public HeadLookReset HeadLookReset { get; set; }
            [XmlElement(ElementName = "HeadLookPitchUp")]
            public HeadLookPitchUp HeadLookPitchUp { get; set; }
            [XmlElement(ElementName = "HeadLookPitchDown")]
            public HeadLookPitchDown HeadLookPitchDown { get; set; }
            [XmlElement(ElementName = "HeadLookPitchAxisRaw")]
            public HeadLookPitchAxisRaw HeadLookPitchAxisRaw { get; set; }
            [XmlElement(ElementName = "HeadLookYawLeft")]
            public HeadLookYawLeft HeadLookYawLeft { get; set; }
            [XmlElement(ElementName = "HeadLookYawRight")]
            public HeadLookYawRight HeadLookYawRight { get; set; }
            [XmlElement(ElementName = "HeadLookYawAxis")]
            public HeadLookYawAxis HeadLookYawAxis { get; set; }
            [XmlElement(ElementName = "MotionHeadlook")]
            public MotionHeadlook MotionHeadlook { get; set; }
            [XmlElement(ElementName = "HeadlookMotionSensitivity")]
            public HeadlookMotionSensitivity HeadlookMotionSensitivity { get; set; }
            [XmlElement(ElementName = "yawRotateHeadlook")]
            public YawRotateHeadlook YawRotateHeadlook { get; set; }
            [XmlElement(ElementName = "CamPitchAxis")]
            public CamPitchAxis CamPitchAxis { get; set; }
            [XmlElement(ElementName = "CamPitchUp")]
            public CamPitchUp CamPitchUp { get; set; }
            [XmlElement(ElementName = "CamPitchDown")]
            public CamPitchDown CamPitchDown { get; set; }
            [XmlElement(ElementName = "CamYawAxis")]
            public CamYawAxis CamYawAxis { get; set; }
            [XmlElement(ElementName = "CamYawLeft")]
            public CamYawLeft CamYawLeft { get; set; }
            [XmlElement(ElementName = "CamYawRight")]
            public CamYawRight CamYawRight { get; set; }
            [XmlElement(ElementName = "CamTranslateYAxis")]
            public CamTranslateYAxis CamTranslateYAxis { get; set; }
            [XmlElement(ElementName = "CamTranslateForward")]
            public CamTranslateForward CamTranslateForward { get; set; }
            [XmlElement(ElementName = "CamTranslateBackward")]
            public CamTranslateBackward CamTranslateBackward { get; set; }
            [XmlElement(ElementName = "CamTranslateXAxis")]
            public CamTranslateXAxis CamTranslateXAxis { get; set; }
            [XmlElement(ElementName = "CamTranslateLeft")]
            public CamTranslateLeft CamTranslateLeft { get; set; }
            [XmlElement(ElementName = "CamTranslateRight")]
            public CamTranslateRight CamTranslateRight { get; set; }
            [XmlElement(ElementName = "CamTranslateZAxis")]
            public CamTranslateZAxis CamTranslateZAxis { get; set; }
            [XmlElement(ElementName = "CamTranslateUp")]
            public CamTranslateUp CamTranslateUp { get; set; }
            [XmlElement(ElementName = "CamTranslateDown")]
            public CamTranslateDown CamTranslateDown { get; set; }
            [XmlElement(ElementName = "CamZoomAxis")]
            public CamZoomAxis CamZoomAxis { get; set; }
            [XmlElement(ElementName = "CamZoomIn")]
            public CamZoomIn CamZoomIn { get; set; }
            [XmlElement(ElementName = "CamZoomOut")]
            public CamZoomOut CamZoomOut { get; set; }
            [XmlElement(ElementName = "CamTranslateZHold")]
            public CamTranslateZHold CamTranslateZHold { get; set; }
            [XmlElement(ElementName = "ToggleDriveAssist")]
            public ToggleDriveAssist ToggleDriveAssist { get; set; }
            [XmlElement(ElementName = "DriveAssistDefault")]
            public DriveAssistDefault DriveAssistDefault { get; set; }
            [XmlElement(ElementName = "MouseBuggySteeringXMode")]
            public MouseBuggySteeringXMode MouseBuggySteeringXMode { get; set; }
            [XmlElement(ElementName = "MouseBuggySteeringXDecay")]
            public MouseBuggySteeringXDecay MouseBuggySteeringXDecay { get; set; }
            [XmlElement(ElementName = "MouseBuggyRollingXMode")]
            public MouseBuggyRollingXMode MouseBuggyRollingXMode { get; set; }
            [XmlElement(ElementName = "MouseBuggyRollingXDecay")]
            public MouseBuggyRollingXDecay MouseBuggyRollingXDecay { get; set; }
            [XmlElement(ElementName = "MouseBuggyYMode")]
            public MouseBuggyYMode MouseBuggyYMode { get; set; }
            [XmlElement(ElementName = "MouseBuggyYDecay")]
            public MouseBuggyYDecay MouseBuggyYDecay { get; set; }
            [XmlElement(ElementName = "SteeringAxis")]
            public SteeringAxis SteeringAxis { get; set; }
            [XmlElement(ElementName = "SteerLeftButton")]
            public SteerLeftButton SteerLeftButton { get; set; }
            [XmlElement(ElementName = "SteerRightButton")]
            public SteerRightButton SteerRightButton { get; set; }
            [XmlElement(ElementName = "BuggyRollAxisRaw")]
            public BuggyRollAxisRaw BuggyRollAxisRaw { get; set; }
            [XmlElement(ElementName = "BuggyRollLeftButton")]
            public BuggyRollLeftButton BuggyRollLeftButton { get; set; }
            [XmlElement(ElementName = "BuggyRollRightButton")]
            public BuggyRollRightButton BuggyRollRightButton { get; set; }
            [XmlElement(ElementName = "BuggyPitchAxis")]
            public BuggyPitchAxis BuggyPitchAxis { get; set; }
            [XmlElement(ElementName = "BuggyPitchUpButton")]
            public BuggyPitchUpButton BuggyPitchUpButton { get; set; }
            [XmlElement(ElementName = "BuggyPitchDownButton")]
            public BuggyPitchDownButton BuggyPitchDownButton { get; set; }
            [XmlElement(ElementName = "VerticalThrustersButton")]
            public VerticalThrustersButton VerticalThrustersButton { get; set; }
            [XmlElement(ElementName = "BuggyPrimaryFireButton")]
            public BuggyPrimaryFireButton BuggyPrimaryFireButton { get; set; }
            [XmlElement(ElementName = "BuggySecondaryFireButton")]
            public BuggySecondaryFireButton BuggySecondaryFireButton { get; set; }
            [XmlElement(ElementName = "AutoBreakBuggyButton")]
            public AutoBreakBuggyButton AutoBreakBuggyButton { get; set; }
            [XmlElement(ElementName = "HeadlightsBuggyButton")]
            public HeadlightsBuggyButton HeadlightsBuggyButton { get; set; }
            [XmlElement(ElementName = "ToggleBuggyTurretButton")]
            public ToggleBuggyTurretButton ToggleBuggyTurretButton { get; set; }
            [XmlElement(ElementName = "SelectTarget_Buggy")]
            public SelectTarget_Buggy SelectTarget_Buggy { get; set; }
            [XmlElement(ElementName = "MouseTurretXMode")]
            public MouseTurretXMode MouseTurretXMode { get; set; }
            [XmlElement(ElementName = "MouseTurretXDecay")]
            public MouseTurretXDecay MouseTurretXDecay { get; set; }
            [XmlElement(ElementName = "MouseTurretYMode")]
            public MouseTurretYMode MouseTurretYMode { get; set; }
            [XmlElement(ElementName = "MouseTurretYDecay")]
            public MouseTurretYDecay MouseTurretYDecay { get; set; }
            [XmlElement(ElementName = "BuggyTurretYawAxisRaw")]
            public BuggyTurretYawAxisRaw BuggyTurretYawAxisRaw { get; set; }
            [XmlElement(ElementName = "BuggyTurretYawLeftButton")]
            public BuggyTurretYawLeftButton BuggyTurretYawLeftButton { get; set; }
            [XmlElement(ElementName = "BuggyTurretYawRightButton")]
            public BuggyTurretYawRightButton BuggyTurretYawRightButton { get; set; }
            [XmlElement(ElementName = "BuggyTurretPitchAxisRaw")]
            public BuggyTurretPitchAxisRaw BuggyTurretPitchAxisRaw { get; set; }
            [XmlElement(ElementName = "BuggyTurretPitchUpButton")]
            public BuggyTurretPitchUpButton BuggyTurretPitchUpButton { get; set; }
            [XmlElement(ElementName = "BuggyTurretPitchDownButton")]
            public BuggyTurretPitchDownButton BuggyTurretPitchDownButton { get; set; }
            [XmlElement(ElementName = "DriveSpeedAxis")]
            public DriveSpeedAxis DriveSpeedAxis { get; set; }
            [XmlElement(ElementName = "BuggyThrottleRange")]
            public BuggyThrottleRange BuggyThrottleRange { get; set; }
            [XmlElement(ElementName = "BuggyToggleReverseThrottleInput")]
            public BuggyToggleReverseThrottleInput BuggyToggleReverseThrottleInput { get; set; }
            [XmlElement(ElementName = "BuggyThrottleIncrement")]
            public BuggyThrottleIncrement BuggyThrottleIncrement { get; set; }
            [XmlElement(ElementName = "IncreaseSpeedButtonMax")]
            public IncreaseSpeedButtonMax IncreaseSpeedButtonMax { get; set; }
            [XmlElement(ElementName = "DecreaseSpeedButtonMax")]
            public DecreaseSpeedButtonMax DecreaseSpeedButtonMax { get; set; }
            [XmlElement(ElementName = "IncreaseSpeedButtonPartial")]
            public IncreaseSpeedButtonPartial IncreaseSpeedButtonPartial { get; set; }
            [XmlElement(ElementName = "DecreaseSpeedButtonPartial")]
            public DecreaseSpeedButtonPartial DecreaseSpeedButtonPartial { get; set; }
            [XmlElement(ElementName = "IncreaseEnginesPower_Buggy")]
            public IncreaseEnginesPower_Buggy IncreaseEnginesPower_Buggy { get; set; }
            [XmlElement(ElementName = "IncreaseWeaponsPower_Buggy")]
            public IncreaseWeaponsPower_Buggy IncreaseWeaponsPower_Buggy { get; set; }
            [XmlElement(ElementName = "IncreaseSystemsPower_Buggy")]
            public IncreaseSystemsPower_Buggy IncreaseSystemsPower_Buggy { get; set; }
            [XmlElement(ElementName = "ResetPowerDistribution_Buggy")]
            public ResetPowerDistribution_Buggy ResetPowerDistribution_Buggy { get; set; }
            [XmlElement(ElementName = "ToggleCargoScoop_Buggy")]
            public ToggleCargoScoop_Buggy ToggleCargoScoop_Buggy { get; set; }
            [XmlElement(ElementName = "EjectAllCargo_Buggy")]
            public EjectAllCargo_Buggy EjectAllCargo_Buggy { get; set; }
            [XmlElement(ElementName = "RecallDismissShip")]
            public RecallDismissShip RecallDismissShip { get; set; }
            [XmlElement(ElementName = "UIFocus_Buggy")]
            public UIFocus_Buggy UIFocus_Buggy { get; set; }
            [XmlElement(ElementName = "FocusLeftPanel_Buggy")]
            public FocusLeftPanel_Buggy FocusLeftPanel_Buggy { get; set; }
            [XmlElement(ElementName = "FocusCommsPanel_Buggy")]
            public FocusCommsPanel_Buggy FocusCommsPanel_Buggy { get; set; }
            [XmlElement(ElementName = "QuickCommsPanel_Buggy")]
            public QuickCommsPanel_Buggy QuickCommsPanel_Buggy { get; set; }
            [XmlElement(ElementName = "FocusRadarPanel_Buggy")]
            public FocusRadarPanel_Buggy FocusRadarPanel_Buggy { get; set; }
            [XmlElement(ElementName = "FocusRightPanel_Buggy")]
            public FocusRightPanel_Buggy FocusRightPanel_Buggy { get; set; }
            [XmlElement(ElementName = "GalaxyMapOpen_Buggy")]
            public GalaxyMapOpen_Buggy GalaxyMapOpen_Buggy { get; set; }
            [XmlElement(ElementName = "SystemMapOpen_Buggy")]
            public SystemMapOpen_Buggy SystemMapOpen_Buggy { get; set; }
            [XmlElement(ElementName = "HeadLookToggle_Buggy")]
            public HeadLookToggle_Buggy HeadLookToggle_Buggy { get; set; }
            [XmlElement(ElementName = "MultiCrewToggleMode")]
            public MultiCrewToggleMode MultiCrewToggleMode { get; set; }
            [XmlElement(ElementName = "MultiCrewPrimaryFire")]
            public MultiCrewPrimaryFire MultiCrewPrimaryFire { get; set; }
            [XmlElement(ElementName = "MultiCrewSecondaryFire")]
            public MultiCrewSecondaryFire MultiCrewSecondaryFire { get; set; }
            [XmlElement(ElementName = "MultiCrewPrimaryUtilityFire")]
            public MultiCrewPrimaryUtilityFire MultiCrewPrimaryUtilityFire { get; set; }
            [XmlElement(ElementName = "MultiCrewSecondaryUtilityFire")]
            public MultiCrewSecondaryUtilityFire MultiCrewSecondaryUtilityFire { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonMouseXMode")]
            public MultiCrewThirdPersonMouseXMode MultiCrewThirdPersonMouseXMode { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonMouseXDecay")]
            public MultiCrewThirdPersonMouseXDecay MultiCrewThirdPersonMouseXDecay { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonMouseYMode")]
            public MultiCrewThirdPersonMouseYMode MultiCrewThirdPersonMouseYMode { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonMouseYDecay")]
            public MultiCrewThirdPersonMouseYDecay MultiCrewThirdPersonMouseYDecay { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
            public MultiCrewThirdPersonYawAxisRaw MultiCrewThirdPersonYawAxisRaw { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonYawLeftButton")]
            public MultiCrewThirdPersonYawLeftButton MultiCrewThirdPersonYawLeftButton { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonYawRightButton")]
            public MultiCrewThirdPersonYawRightButton MultiCrewThirdPersonYawRightButton { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
            public MultiCrewThirdPersonPitchAxisRaw MultiCrewThirdPersonPitchAxisRaw { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonPitchUpButton")]
            public MultiCrewThirdPersonPitchUpButton MultiCrewThirdPersonPitchUpButton { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonPitchDownButton")]
            public MultiCrewThirdPersonPitchDownButton MultiCrewThirdPersonPitchDownButton { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
            public MultiCrewThirdPersonMouseSensitivity MultiCrewThirdPersonMouseSensitivity { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
            public MultiCrewThirdPersonFovAxisRaw MultiCrewThirdPersonFovAxisRaw { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonFovOutButton")]
            public MultiCrewThirdPersonFovOutButton MultiCrewThirdPersonFovOutButton { get; set; }
            [XmlElement(ElementName = "MultiCrewThirdPersonFovInButton")]
            public MultiCrewThirdPersonFovInButton MultiCrewThirdPersonFovInButton { get; set; }
            [XmlElement(ElementName = "MultiCrewCockpitUICycleForward")]
            public MultiCrewCockpitUICycleForward MultiCrewCockpitUICycleForward { get; set; }
            [XmlElement(ElementName = "MultiCrewCockpitUICycleBackward")]
            public MultiCrewCockpitUICycleBackward MultiCrewCockpitUICycleBackward { get; set; }
            [XmlElement(ElementName = "OrderRequestDock")]
            public OrderRequestDock OrderRequestDock { get; set; }
            [XmlElement(ElementName = "OrderDefensiveBehaviour")]
            public OrderDefensiveBehaviour OrderDefensiveBehaviour { get; set; }
            [XmlElement(ElementName = "OrderAggressiveBehaviour")]
            public OrderAggressiveBehaviour OrderAggressiveBehaviour { get; set; }
            [XmlElement(ElementName = "OrderFocusTarget")]
            public OrderFocusTarget OrderFocusTarget { get; set; }
            [XmlElement(ElementName = "OrderHoldFire")]
            public OrderHoldFire OrderHoldFire { get; set; }
            [XmlElement(ElementName = "OrderHoldPosition")]
            public OrderHoldPosition OrderHoldPosition { get; set; }
            [XmlElement(ElementName = "OrderFollow")]
            public OrderFollow OrderFollow { get; set; }
            [XmlElement(ElementName = "OpenOrders")]
            public OpenOrders OpenOrders { get; set; }
            [XmlElement(ElementName = "PhotoCameraToggle")]
            public PhotoCameraToggle PhotoCameraToggle { get; set; }
            [XmlElement(ElementName = "PhotoCameraToggle_Buggy")]
            public PhotoCameraToggle_Buggy PhotoCameraToggle_Buggy { get; set; }
            [XmlElement(ElementName = "VanityCameraScrollLeft")]
            public VanityCameraScrollLeft VanityCameraScrollLeft { get; set; }
            [XmlElement(ElementName = "VanityCameraScrollRight")]
            public VanityCameraScrollRight VanityCameraScrollRight { get; set; }
            [XmlElement(ElementName = "ToggleFreeCam")]
            public ToggleFreeCam ToggleFreeCam { get; set; }
            [XmlElement(ElementName = "VanityCameraOne")]
            public VanityCameraOne VanityCameraOne { get; set; }
            [XmlElement(ElementName = "VanityCameraTwo")]
            public VanityCameraTwo VanityCameraTwo { get; set; }
            [XmlElement(ElementName = "VanityCameraThree")]
            public VanityCameraThree VanityCameraThree { get; set; }
            [XmlElement(ElementName = "VanityCameraFour")]
            public VanityCameraFour VanityCameraFour { get; set; }
            [XmlElement(ElementName = "VanityCameraFive")]
            public VanityCameraFive VanityCameraFive { get; set; }
            [XmlElement(ElementName = "VanityCameraSix")]
            public VanityCameraSix VanityCameraSix { get; set; }
            [XmlElement(ElementName = "VanityCameraSeven")]
            public VanityCameraSeven VanityCameraSeven { get; set; }
            [XmlElement(ElementName = "VanityCameraEight")]
            public VanityCameraEight VanityCameraEight { get; set; }
            [XmlElement(ElementName = "VanityCameraNine")]
            public VanityCameraNine VanityCameraNine { get; set; }
            [XmlElement(ElementName = "FreeCamToggleHUD")]
            public FreeCamToggleHUD FreeCamToggleHUD { get; set; }
            [XmlElement(ElementName = "FreeCamSpeedInc")]
            public FreeCamSpeedInc FreeCamSpeedInc { get; set; }
            [XmlElement(ElementName = "FreeCamSpeedDec")]
            public FreeCamSpeedDec FreeCamSpeedDec { get; set; }
            [XmlElement(ElementName = "MoveFreeCamY")]
            public MoveFreeCamY MoveFreeCamY { get; set; }
            [XmlElement(ElementName = "ThrottleRangeFreeCam")]
            public ThrottleRangeFreeCam ThrottleRangeFreeCam { get; set; }
            [XmlElement(ElementName = "ToggleReverseThrottleInputFreeCam")]
            public ToggleReverseThrottleInputFreeCam ToggleReverseThrottleInputFreeCam { get; set; }
            [XmlElement(ElementName = "MoveFreeCamForward")]
            public MoveFreeCamForward MoveFreeCamForward { get; set; }
            [XmlElement(ElementName = "MoveFreeCamBackwards")]
            public MoveFreeCamBackwards MoveFreeCamBackwards { get; set; }
            [XmlElement(ElementName = "MoveFreeCamX")]
            public MoveFreeCamX MoveFreeCamX { get; set; }
            [XmlElement(ElementName = "MoveFreeCamRight")]
            public MoveFreeCamRight MoveFreeCamRight { get; set; }
            [XmlElement(ElementName = "MoveFreeCamLeft")]
            public MoveFreeCamLeft MoveFreeCamLeft { get; set; }
            [XmlElement(ElementName = "MoveFreeCamZ")]
            public MoveFreeCamZ MoveFreeCamZ { get; set; }
            [XmlElement(ElementName = "MoveFreeCamUpAxis")]
            public MoveFreeCamUpAxis MoveFreeCamUpAxis { get; set; }
            [XmlElement(ElementName = "MoveFreeCamDownAxis")]
            public MoveFreeCamDownAxis MoveFreeCamDownAxis { get; set; }
            [XmlElement(ElementName = "MoveFreeCamUp")]
            public MoveFreeCamUp MoveFreeCamUp { get; set; }
            [XmlElement(ElementName = "MoveFreeCamDown")]
            public MoveFreeCamDown MoveFreeCamDown { get; set; }
            [XmlElement(ElementName = "PitchCameraMouse")]
            public PitchCameraMouse PitchCameraMouse { get; set; }
            [XmlElement(ElementName = "YawCameraMouse")]
            public YawCameraMouse YawCameraMouse { get; set; }
            [XmlElement(ElementName = "PitchCamera")]
            public PitchCamera PitchCamera { get; set; }
            [XmlElement(ElementName = "FreeCamMouseSensitivity")]
            public FreeCamMouseSensitivity FreeCamMouseSensitivity { get; set; }
            [XmlElement(ElementName = "FreeCamMouseYDecay")]
            public FreeCamMouseYDecay FreeCamMouseYDecay { get; set; }
            [XmlElement(ElementName = "PitchCameraUp")]
            public PitchCameraUp PitchCameraUp { get; set; }
            [XmlElement(ElementName = "PitchCameraDown")]
            public PitchCameraDown PitchCameraDown { get; set; }
            [XmlElement(ElementName = "YawCamera")]
            public YawCamera YawCamera { get; set; }
            [XmlElement(ElementName = "FreeCamMouseXDecay")]
            public FreeCamMouseXDecay FreeCamMouseXDecay { get; set; }
            [XmlElement(ElementName = "YawCameraLeft")]
            public YawCameraLeft YawCameraLeft { get; set; }
            [XmlElement(ElementName = "YawCameraRight")]
            public YawCameraRight YawCameraRight { get; set; }
            [XmlElement(ElementName = "RollCamera")]
            public RollCamera RollCamera { get; set; }
            [XmlElement(ElementName = "RollCameraLeft")]
            public RollCameraLeft RollCameraLeft { get; set; }
            [XmlElement(ElementName = "RollCameraRight")]
            public RollCameraRight RollCameraRight { get; set; }
            [XmlElement(ElementName = "ToggleRotationLock")]
            public ToggleRotationLock ToggleRotationLock { get; set; }
            [XmlElement(ElementName = "FixCameraRelativeToggle")]
            public FixCameraRelativeToggle FixCameraRelativeToggle { get; set; }
            [XmlElement(ElementName = "FixCameraWorldToggle")]
            public FixCameraWorldToggle FixCameraWorldToggle { get; set; }
            [XmlElement(ElementName = "QuitCamera")]
            public QuitCamera QuitCamera { get; set; }
            [XmlElement(ElementName = "ToggleAdvanceMode")]
            public ToggleAdvanceMode ToggleAdvanceMode { get; set; }
            [XmlElement(ElementName = "FreeCamZoomIn")]
            public FreeCamZoomIn FreeCamZoomIn { get; set; }
            [XmlElement(ElementName = "FreeCamZoomOut")]
            public FreeCamZoomOut FreeCamZoomOut { get; set; }
            [XmlElement(ElementName = "FStopDec")]
            public FStopDec FStopDec { get; set; }
            [XmlElement(ElementName = "FStopInc")]
            public FStopInc FStopInc { get; set; }
            [XmlElement(ElementName = "CommanderCreator_Undo")]
            public CommanderCreator_Undo CommanderCreator_Undo { get; set; }
            [XmlElement(ElementName = "CommanderCreator_Redo")]
            public CommanderCreator_Redo CommanderCreator_Redo { get; set; }
            [XmlElement(ElementName = "CommanderCreator_Rotation_MouseToggle")]
            public CommanderCreator_Rotation_MouseToggle CommanderCreator_Rotation_MouseToggle { get; set; }
            [XmlElement(ElementName = "CommanderCreator_Rotation")]
            public CommanderCreator_Rotation CommanderCreator_Rotation { get; set; }
            [XmlElement(ElementName = "GalnetAudio_Play_Pause")]
            public GalnetAudio_Play_Pause GalnetAudio_Play_Pause { get; set; }
            [XmlElement(ElementName = "GalnetAudio_SkipForward")]
            public GalnetAudio_SkipForward GalnetAudio_SkipForward { get; set; }
            [XmlElement(ElementName = "GalnetAudio_SkipBackward")]
            public GalnetAudio_SkipBackward GalnetAudio_SkipBackward { get; set; }
            [XmlElement(ElementName = "GalnetAudio_ClearQueue")]
            public GalnetAudio_ClearQueue GalnetAudio_ClearQueue { get; set; }
            [XmlAttribute(AttributeName = "PresetName")]
            public string PresetName { get; set; }
            [XmlAttribute(AttributeName = "MajorVersion")]
            public string MajorVersion { get; set; }
            [XmlAttribute(AttributeName = "MinorVersion")]
            public string MinorVersion { get; set; }
        }
    }
    #endregion

}