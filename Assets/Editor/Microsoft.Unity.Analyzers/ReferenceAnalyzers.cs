﻿#if ENABLE_VSTU

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using UnityEngine;
using UnityEditor;

using SyntaxTree.VisualStudio.Unity.Bridge;

[InitializeOnLoad]
public class ProjectFileHook
{
    // necessary for XLinq to save the xml project file in utf8
    class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }

    static ProjectFileHook()
    {
        ProjectFilesGenerator.ProjectFileGeneration += (string name, string content) =>
        {
            // parse the document and make some changes
            var document = XDocument.Parse(content);
            var ns = document.Root.Name.Namespace;

            var ig = new XElement(ns + "ItemGroup",
                new XElement(ns + "Analyzer", new XAttribute("Include", "Assets\\Editor\\Microsoft.Unity.Analyzers\\Microsoft.Unity.Analyzers.dll")));

            document.Root.Add(ig);

            // save the changes using the Utf8StringWriter
            var str = new Utf8StringWriter();
            document.Save(str);

            return str.ToString();
        };
    }
}

#endif