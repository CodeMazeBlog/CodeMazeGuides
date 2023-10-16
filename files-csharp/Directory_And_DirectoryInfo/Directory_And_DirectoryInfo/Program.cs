// See https://aka.ms/new-console-template for more information
using Directory_And_DirectoryInfo;

var path = @"C:\Public\CM-Demos";

DirectoryMethods.CreateADirectory(path);
DirectoryMethods.GetFilesInDirectory(path);
DirectoryMethods.DeleteDirectory(path);
