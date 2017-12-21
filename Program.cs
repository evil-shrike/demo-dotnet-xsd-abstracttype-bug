using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;

namespace xmlschema_core
{
    class Program
    {
        static void Main(string[] args)
        {
        	if (args.Length == 0) 
        	{ 
        		Console.WriteLine(".exe <schema> [<schema> ...]");
        		return;
        	}
			var schemas = new XmlSchemaSet();
			var schemaFiles = args;
			foreach (string schemaFilePath in schemaFiles)
			{
				using (var reader = new XmlTextReader(schemaFilePath))
				{
					XmlSchema schema = XmlSchema.Read(reader, null);
					schemas.Add(schema);
				}
			}
			schemas.Compile();
			Console.WriteLine("success");
        }
    }
}
