// See https://aka.ms/new-console-template for more information
using DirectoryAndDirectoryInfo;

var path = @"C:\Public\CM-Demos";

DirectoryMethods.CreateADirectory(path);
DirectoryMethods.GetFilesInDirectory(path);
DirectoryMethods.DeleteDirectory(path);
