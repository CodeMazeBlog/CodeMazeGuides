// See https://aka.ms/new-console-template for more information
using Simple.OData.Client;
using System;
using System.IO;
using UsingOData;

//Sleep in order to wait for the web service to start
Thread.Sleep(10000);

var client = new ODataClient("https://localhost:7004/odata/");

var companies = await client
    .For<Company>()
    .Top(2)
    .Skip(1)
    .FindEntriesAsync();
