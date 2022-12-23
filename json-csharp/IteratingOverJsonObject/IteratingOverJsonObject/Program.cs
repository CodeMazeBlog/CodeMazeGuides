// See https://aka.ms/new-console-template for more information

using IteratingOverJsonObject;

var testData = new TestData();
var jsonObject = testData.GenerateJsonData();

var jsonNet = new JsonIteration();

jsonNet.IterateOverJsonDynamically(jsonObject);
jsonNet.IterateUsingJArray(jsonObject);
jsonNet.IterateUsingStaticObject(jsonObject);
jsonNet.IterateUsingSystemJson(jsonObject);

