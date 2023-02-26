using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionFuncDelegatesCSharp;
using System.Text;

namespace ActionFuncDelegatesCSharpTests
{
    [TestClass]
    public class MenuFormatterUnitTest
    {
        public class CD { public string AlbumTitle { get; set; } }
        public class DVD { public string FilmTitle { get; set; } }

        const string mainMenu = "main menu";
        const string mainMenuFormatted = "*** Main Menu ***";
        const string dsotm = "the dark side of the moon";
        const string dsotmFormatted = "*** The Dark Side Of The Moon ***";
        const string walle = "wall-e";
        const string walleFormatted = "*** Wall-E ***";

        [TestMethod]
        public void Given_FormalDelegate_Then_TitleCasedWithStars()
        {
            var menu = new DelegateMenuFormatter(formatTitle);

            Assert.IsNotNull(menu);

            var formattedTitle = menu.GetTitle(mainMenu);

            Assert.AreEqual(mainMenuFormatted, formattedTitle);
        }

        [TestMethod]
        public void Given_FormalDelegate_When_RefParam_Then_TitleCasedWithStars()
        {
            var menu = new RefParamDelegateMenuFormatter(formatTitleRef);

            Assert.IsNotNull(menu);

            var formattedTitle = menu.GetTitle(mainMenu);

            Assert.AreEqual(mainMenuFormatted, formattedTitle);
        }

        [TestMethod]
        public void Given_ActionDelegate_Then_TitleCasedWithStars()
        {
            var menu = new ActionMenuFormatter();

            Assert.IsNotNull(menu);
            menu.FormatTitle = formatTitle;
            var formattedTitle = menu.GetTitle(mainMenu);

            Assert.AreEqual(mainMenuFormatted, formattedTitle);
        }

        [TestMethod]
        public void Given_FuncDelegate_Then_TitleCasedWithStars()
        {
            var menu = new FuncMenuFormatter();
            Assert.IsNotNull(menu);
      
            menu.FormatTitle = getFormattedTitle;
            var formattedTitle = menu.GetTitle(mainMenu);

            Assert.AreEqual(mainMenuFormatted, formattedTitle);
        }

        [TestMethod]
        public void Given_FuncTDelegate_When_TIsCD_Then_AlbumTitleCasedWithStars()
        {
            var menu = new FuncTMenuFormatter<CD>();

            Assert.IsNotNull(menu);
          
            menu.FormatTitle = getTitleFromCD;
            var cd = new CD { AlbumTitle = dsotm };
            var formattedTitle = menu.GetTitle(cd);

            Assert.AreEqual(dsotmFormatted, formattedTitle);
        }

        [TestMethod]
        public void Given_FuncTDelegate_When_TIsDVD_Then_FilmTitleCasedWithStars()
        {
            var menu = new FuncTMenuFormatter<DVD>();

            Assert.IsNotNull(menu);
            menu.FormatTitle = getTitleFromDVD;

            var dvd = new DVD { FilmTitle = walle };
            var formattedTitle = menu.GetTitle(dvd);

            Assert.AreEqual(walleFormatted, formattedTitle);
        }

        string getFormattedTitle(string rawTitle)
        {
            var titleCase = new StringBuilder();
            var toupper = false;
            var titleChar = ' ';
            for (int i = 0; i < rawTitle.Length; i++)
            {
                toupper = i == 0 || !char.IsLetter(titleChar);
                titleChar = toupper ? char.ToUpper(rawTitle[i]) : rawTitle[i];

                titleCase.Append(titleChar);
            }
            return $"*** {titleCase} ***";
        }

        void formatTitle(MenuFormatterBase titleContainer)
        {
            titleContainer.Title = getFormattedTitle(titleContainer.Title);
        }

        void formatTitleRef(ref string title)
        {
            title = getFormattedTitle(title);
        }

        string getTitleFromCD(CD titleContainer) 
        {
            return getFormattedTitle(titleContainer.AlbumTitle);
        }

        string getTitleFromDVD(DVD titleContainer)
        {
            return getFormattedTitle(titleContainer.FilmTitle);
        }
    }
}
