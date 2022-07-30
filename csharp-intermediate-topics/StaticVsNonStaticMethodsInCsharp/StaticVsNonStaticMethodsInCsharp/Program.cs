using StaticVsNonStaticMethodsInCsharp;

var staticVsNonStaticMethods = new StaticVsNonStaticMethods();
staticVsNonStaticMethods.Addition(10, 5);


StaticVsNonStaticMethods.Division(10, 5);

StaticVsNonStaticMethods.IncrementNumber();

var words = new string[] { "article-1", "article-2", "article-3", "article-4", "article-5" };
words.FindSearchedElementIndex("article-3");