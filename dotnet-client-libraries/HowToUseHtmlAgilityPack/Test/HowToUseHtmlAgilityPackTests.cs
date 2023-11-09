using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class HowToUseHtmlAgilityPackTests
    {
        private readonly ITestOutputHelper output;

        public HowToUseHtmlAgilityPackTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void WhenParsingHtmlFromString_ThenHtmlDocumentIsCreated()
        {
            // arrange
            var html = @"<!DOCTYPE html>
                        <html>
                        <body>
	                        <h1>Learn To Code in C#</h1>
	                        <p>Programming is really <i>easy</i>.</p>
                        </body>
                        </html> ";

            // act
            var dom = new HtmlDocument();
            dom.LoadHtml(html);

            var documentHeader = dom.DocumentNode.SelectSingleNode("//h1");

            // assert
            Assert.Equal("Learn To Code in C#", documentHeader.InnerHtml);
        }

        [Fact]
        public void WhenParsingHtmlFromFile_ThenHtmlDocumentIsCreated()
        {
            // arrange
            var path = @"test.html";

            // act
            var doc = new HtmlDocument();
            doc.Load(path);

            var htmlHeader = doc.DocumentNode.SelectSingleNode("//h2");

            // assert
            Assert.Equal("HTML Agility Pack", htmlHeader.InnerHtml);
        }

        [Fact]
        public void WhenParsingHtmlFromUrl_ThenHtmlDocumentIsCreated()
        {
            // arrange
            var url = @"https://code-maze.com/";

            // act
            var web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

            // assert
            Assert.Equal("Code Maze - C#, .NET and Web Development Tutorials", node.InnerHtml);
        }

        [Fact]
        public async void WhenParsingHtmlFromUrlAsync_ThenHtmlDocumentIsCreated()
        {
            // arrange
            var url = @"https://code-maze.com/";

            // act
            var web = new HtmlWeb();
            var htmlDoc = await web.LoadFromWebAsync(url);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

            // assert
            Assert.Equal("Code Maze - C#, .NET and Web Development Tutorials", node.InnerHtml);
        }

        [Fact]
        public void WhenUsingDoubleSlah_ThenNodeSelectedRegardlessPosition()
        {
            // act
            var doc = new HtmlDocument();
            doc.Load("test.html");

            var nodes = doc.DocumentNode.SelectNodes("//li");

            // assert
            Assert.Equal("Parser", nodes[0].InnerHtml);
            Assert.Equal("Selectors", nodes[1].InnerHtml);
            Assert.Equal("DOM management", nodes[2].InnerHtml);
        }

        [Fact]
        public void WhenUsingSingleSlah_ThenNodeSelected()
        {
            // act
            var doc = new HtmlDocument();
            doc.Load("test.html");

            var node = doc.DocumentNode.SelectSingleNode("/html/body/h2");

            // assert
            Assert.Equal("HTML Agility Pack", node.InnerHtml);
        }

        [Fact]
        public void WhenUsingSelectNodes_ThenSelectDescendantNodes()
        {
            // act
            var dom = new HtmlDocument();
            dom.Load("test.html");

            var body = dom.DocumentNode.SelectSingleNode("/html/body");

            var listItems = body.SelectNodes("./ul/li");

            // assert
            Assert.Equal(3, listItems.Count);
        }

        [Fact]
        public void WhenSelectByAttribute_ThenElementIsReturned()
        {
            // act
            var dom = new HtmlDocument();
            dom.Load("test.html");

            var node = dom.DocumentNode.SelectSingleNode("//p[@id='second']");

            // assert
            Assert.Equal("HAP is a popular web scraping tool.", node.InnerHtml);
        }

        [Fact]
        public void WhenSelectInCollection_ThenUseIndexesAndFunctions()
        {
            // act
            var dom = new HtmlDocument();
            dom.Load("test.html");

            var secondParagraph = dom.DocumentNode.SelectSingleNode("//p[1]");
            var lastParagraph = dom.DocumentNode.SelectSingleNode("//p[last()]");

            // assert
            Assert.Equal("Programming is really <i>easy</i>.", secondParagraph.InnerHtml);
            Assert.Equal("Features:", lastParagraph.InnerHtml);
        }

        [Fact]
        public void WhenAddingNode_ThenDomGetsUpdated()
        {
            // arrange
            var dom = new HtmlDocument();
            dom.Load("test.html");

            var list = dom.DocumentNode.SelectSingleNode("//ul");

            // act
            list.ChildNodes.Add(HtmlNode.CreateNode("<li>Added dynamically</li>"));

            // assert
            Assert.Equal(
    @"<ul>
		<li>Parser</li>
		<li>Selectors</li>
		<li>DOM management</li>
	<li>Added dynamically</li></ul>", list.OuterHtml);
        }

        [Fact]
        public void WhenRemovingNode_ThenDomGetsUpdated()
        {
            // arrange
            var dom = new HtmlDocument();
            dom.Load("test.html");

            var list = dom.DocumentNode.SelectSingleNode("//ul");

            // act
            list.RemoveChild(list.SelectNodes("li").First());

            // assert
            Assert.Equal(
    @"<ul>
		
		<li>Selectors</li>
		<li>DOM management</li>
	</ul>", list.OuterHtml);
        }

        [Fact]
        public void WhenRemovingNode_ThenNodeIsUpdated()
        {
            // arrange
            var dom = new HtmlDocument();
            dom.Load("test.html");

            var list = dom.DocumentNode.SelectSingleNode("//ul");

            // act
            foreach (var node in list.ChildNodes.Where(x => x.Name == "li"))
            {
                node.FirstChild.InnerHtml = "List Item Text";
                node.Attributes.Append("class", "list-item");
            }

            // assert
            Assert.Equal(
    @"<ul>
		<li class=""list-item"">List Item Text</li>
		<li class=""list-item"">List Item Text</li>
		<li class=""list-item"">List Item Text</li>
	</ul>", list.OuterHtml);
        }

        [Fact]
        public void WhenWritingOutHtml_ThenWritesToDiskFile()
        {
            // arrange
            var dom = new HtmlDocument();
            dom.Load("test.html");

            // act
            using var textWriter = File.CreateText("test_out.html");
            dom.Save(textWriter);

            // assert
            Assert.True(File.Exists("test_out.html"));
        }

        [Fact]
        public void WhenTraversingDocument_ThenAllNodesVisited()
        {
            // arrange
            var dom = new HtmlDocument();
            dom.Load("test.html");

            // act
            var toc = new List<HtmlNode>();
            var headerTags = new string[] { "h1", "h2", "h3", "h4", "h5", "h6" };
            void VisitNodesRecursively(HtmlNode node)
            {
                if (headerTags.Contains(node.Name))
                    toc.Add(node);

                foreach(var child in node.ChildNodes)
                    VisitNodesRecursively(child);
            }

            VisitNodesRecursively(dom.DocumentNode);

            // assert
            Assert.Equal(2, toc.Count);
            Assert.Contains(toc, x => x.Name == "h1" && x.InnerText == "Learn To Code in C#");
            Assert.Contains(toc, x => x.Name == "h2" && x.InnerText == "HTML Agility Pack");
        }

        [Fact]
        public void WhenWritingOutNodeContent_ThenWritesToDiskFile()
        {
            // arrange
            var dom = new HtmlDocument();
            dom.Load("test.html");

            var list = dom.DocumentNode.SelectSingleNode("//ul");

            // act
            using (var textWriter = File.CreateText("list.html"))
            {
                list.WriteTo(textWriter);
            }

            using (var textWriter = File.CreateText("items_only.html"))
            {
                list.WriteContentTo(textWriter);
            }

            // assert
            Assert.Equal(
    @"<ul>
		<li>Parser</li>
		<li>Selectors</li>
		<li>DOM management</li>
	</ul>", File.ReadAllText("list.html"));

            Assert.Equal(
    @"
		<li>Parser</li>
		<li>Selectors</li>
		<li>DOM management</li>
	", File.ReadAllText("items_only.html"));
        }

        [Fact]
        public void WhenDescendantNodes_ThenFlatListOfNodesReturned()
        {
            // arrange
            var dom = new HtmlDocument();
            dom.Load("test.html");

            // act
            var groups = dom.DocumentNode.DescendantsAndSelf()
                .Where(x => !x.Name.StartsWith("#"))
                .GroupBy(x => x.Name);
            
            foreach (var group in groups)
                this.output.WriteLine($"Tag '{group.Key}' found {group.Count()} times.");

            // assert
            Assert.Contains(groups, x => x.Key == "html" && x.Count() == 1);
            Assert.Contains(groups, x => x.Key == "body" && x.Count() == 1);
            Assert.Contains(groups, x => x.Key == "h1" && x.Count() == 1);
            Assert.Contains(groups, x => x.Key == "p" && x.Count() == 3);
            Assert.Contains(groups, x => x.Key == "i" && x.Count() == 1);
            Assert.Contains(groups, x => x.Key == "h2" && x.Count() == 1);
            Assert.Contains(groups, x => x.Key == "ul" && x.Count() == 1);
            Assert.Contains(groups, x => x.Key == "li" && x.Count() == 3);
        }
    }
}