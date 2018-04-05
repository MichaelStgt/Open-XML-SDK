﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Xml;

namespace DocumentFormat.OpenXml
{
    /// <summary>
    /// Represents the decimal value for attributes.
    /// </summary>
    [DebuggerDisplay("{InnerText}")]
    public class DecimalValue : OpenXmlSimpleValue<Decimal>
    {
        /// <summary>
        /// Initializes a new instance of the DecimalValue class.
        /// </summary>
        public DecimalValue()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DecimalValue class using the supplied
        /// Decimal value.
        /// </summary>
        /// <param name="value">The Decimal value.</param>
        public DecimalValue(Decimal value)
            : base(value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DecimalValue class by deep copying
        /// the supplied DecimalValue class.
        /// </summary>
        /// <param name="source">
        /// The source DecimalValue class.
        /// </param>
        public DecimalValue(DecimalValue source)
            : base(source)
        {
        }

        private protected override string GetText(Decimal input) => XmlConvert.ToString(input);

        private protected override Decimal Parse(string input) => XmlConvert.ToDecimal(input);

        /// <summary>
        /// Implicitly converts the specified value to a Decimal value.
        /// </summary>
        /// <param name="xmlAttribute">
        /// The DecimalValue to convert.
        /// </param>
        /// <returns>
        /// The converted Decimal value.
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown when xmlAttribute is null.</exception>
        public static implicit operator Decimal(DecimalValue xmlAttribute)
        {
            if (xmlAttribute == null)
            {
                throw new InvalidOperationException(ExceptionMessages.ImplicitConversionExceptionOnNull);
            }

            return ToDecimal(xmlAttribute);
        }

        /// <summary>
        /// Initializes a new instance of the DecimalValue class by implicitly
        /// converting the supplied Decimal value.
        /// </summary>
        /// <param name="value">
        /// The Decimal value.
        /// </param>
        /// <returns>A new DecimalValue instance with the value.</returns>
        public static implicit operator DecimalValue(Decimal value)
        {
            return FromDecimal(value);
        }

        /// <summary>
        /// Returns a new DecimalValue object that was created from a Decimal value.
        /// </summary>
        /// <param name="value">A Decimal value to use to create a new DecimalValue object.</param>
        /// <returns>A DecimalValue object that corresponds to the value parameter.</returns>
        public static DecimalValue FromDecimal(Decimal value)
        {
            return new DecimalValue(value);
        }

        /// <summary>
        /// Returns the Decimal representation of a DecimalValue object.
        /// </summary>
        /// <param name="xmlAttribute">
        /// A DecimalValue object to use to retrieve a Decimal representation.
        /// </param>
        /// <returns>A Decimal value that represents a DecimalValue object.</returns>
        public static Decimal ToDecimal(DecimalValue xmlAttribute)
        {
            if (xmlAttribute == null)
            {
                throw new InvalidOperationException(ExceptionMessages.ImplicitConversionExceptionOnNull);
            }

            return xmlAttribute.Value;
        }

        private protected override OpenXmlSimpleType CloneImpl() => new DecimalValue(this);
    }
}
