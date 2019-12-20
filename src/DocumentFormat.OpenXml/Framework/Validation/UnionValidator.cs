﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DocumentFormat.OpenXml.Validation;
using System.Collections.Generic;

namespace DocumentFormat.OpenXml.Framework
{
    internal class UnionValidator : IOpenXmlSimpleTypeValidator
    {
        private readonly List<IOpenXmlSimpleTypeValidator> _others;

        public UnionValidator(List<IOpenXmlSimpleTypeValidator> others, byte id)
        {
            _others = others;
            Id = id;
        }

        public byte Id { get; }

        public IEnumerable<IOpenXmlSimpleTypeValidator> Validators => _others;

        public void Validate(ValidationContext context)
        {
            var errorRaised = false;

            using (context.Push(_ => errorRaised = true))
            {
                foreach (var other in _others)
                {
                    other.Validate(context);

                    if (!errorRaised)
                    {
                        return;
                    }

                    errorRaised = false;
                }
            }

            var current = context.Current;

            context.CreateError(
                id: "Sch_AttributeUnionFailedEx",
                description: SR.Format(ValidationResources.Sch_AttributeUnionFailedEx, current.Property.GetQName(), current.Value),
                errorType: ValidationErrorType.Schema);
        }
    }
}
