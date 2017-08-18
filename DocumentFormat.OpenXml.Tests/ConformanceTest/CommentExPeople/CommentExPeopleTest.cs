﻿// Copyright (c) Microsoft Open Technologies, Inc.  All rights reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.
using System;

namespace DocumentFormat.OpenXml.Tests.CommentExPeople
{
    using DocumentFormat.OpenXml.Tests.CommentExPeopleClass;
    using DocumentFormat.OpenXml.Tests.TaskLibraries;
    using OxTest;
    using System.IO;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Test for Comment People part.
    /// </summary>
    public class CommentExPeopleTest : OpenXmlTestBase
    {
        private readonly string generateDocumentFilePath = Path.Combine(TestUtil.TestResultsDirectory, Guid.NewGuid().ToString() + ".docx");
        private readonly string editedDocumentFilePath = Path.Combine(TestUtil.TestResultsDirectory, Guid.NewGuid().ToString() + ".docx");

        /// <summary>
        /// Constructor
        /// </summary>
        public CommentExPeopleTest(ITestOutputHelper output)
            : base(output)
        {
            string createFilePath = this.GetTestFilePath(this.generateDocumentFilePath);
            GeneratedDocument generatedDocument = new GeneratedDocument();
            generatedDocument.CreatePackage(createFilePath);

            this.Log.Pass("Create Word file. File path=[{0}].", createFilePath);
        }

        /// <summary>
        /// Element reading test for "Comment PeoplePart".
        /// </summary>
        [Fact]
        public void CommentExPeople01ReadElement()
        {
            string originalFilepath = this.GetTestFilePath(this.generateDocumentFilePath);

            TestEntities testEntities = new TestEntities();
            testEntities.ReadElements(originalFilepath, this.Log);
        }

        /// <summary>
        /// Element editing test for "Comment PeoplePart".
        /// </summary>
        [Fact]
        public void CommentExPeople02EditElement()
        {
            string originalFilepath = this.GetTestFilePath(this.generateDocumentFilePath);
            string editFilePath = this.GetTestFilePath(this.editedDocumentFilePath);

            System.IO.File.Copy(originalFilepath, editFilePath, true);

            TestEntities testEntities = new TestEntities();
            testEntities.EditElements(editFilePath, this.Log);
            testEntities.VerifyElements(editFilePath, this.Log);
        }
    }
}
