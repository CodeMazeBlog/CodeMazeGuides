// See https://aka.ms/new-console-template for more information
using System.IO.Compression;
using Zip_files_in_NET;

var readZipStructure = new ReadZipStructure();

readZipStructure.WriteName("single-file.zip");
readZipStructure.WriteName("multi-file.zip");
readZipStructure.WriteName("multi-folder.zip");

readZipStructure.WriteFullName("single-file.zip");
readZipStructure.WriteFullName("multi-file.zip");
readZipStructure.WriteFullName("multi-folder.zip");

Console.ReadLine();
