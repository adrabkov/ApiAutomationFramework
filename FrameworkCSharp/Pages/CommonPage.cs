using FrameworkCSharp.Enum;
using OpenQA.Selenium;
using System.Security.Cryptography;

namespace FrameworkCSharp.Pages
{
    public class CommonPage : PageBase
    {
        public CommonPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.Id("ts_input");
        private readonly By profileName = By.ClassName("top_profile_name");
        private readonly By searchField = By.Id("ts_input");
        private readonly By friendPage = By.XPath("//a[contains(@class, 'ts_contact')]");
        private readonly By ItemsMenu = By.XPath("//div[@id='side_bar_inner']//li");
        private readonly By topProfileMenu = By.XPath("//div[@id='top_profile_menu']/a");
        private readonly By topProfileMunuLink = By.ClassName("top_profile_name");


        public bool ProfileNameIsDisplayed() => IsElementVisible(profileName);
        public void inputSearchText(string name)
        {
            ClickElementBy(searchField);
            SendKeys(searchField, name);
        }
        public SearchResultPage openSearchResultPage()
        {
            var list = GetlistOfElements(friendPage);
            return ClickIWebElement<SearchResultPage>(list[0]);
        }
        public MyProfilePage openMyProfileTab() => ClickIWebElement<MyProfilePage>(GetlistOfElements(ItemsMenu)[(int)MenuItems.My_profile]);
        public CommunitiesPage openCommunitiesTab() => ClickIWebElement<CommunitiesPage>(GetlistOfElements(ItemsMenu)[(int)MenuItems.Communities]);
        public PhotosPage openPhotosTab() => ClickIWebElement<PhotosPage>(GetlistOfElements(ItemsMenu)[(int)MenuItems.Photos]);
        public MessagesPage openMessageTab() => ClickIWebElement<MessagesPage>(GetlistOfElements(ItemsMenu)[(int)MenuItems.Messages]);
        public FriendsPage openFriendTab() => ClickIWebElement<FriendsPage>(GetlistOfElements(ItemsMenu)[(int)MenuItems.Friends]);
        public EditInfoPage openEditTab() => ClickIWebElement<EditInfoPage>(GetlistOfElements(topProfileMenu)[(int)TopProfileItems.Edit]);
        public SettingPage openSettingPage() => ClickIWebElement<SettingPage>(GetlistOfElements(topProfileMenu)[(int)TopProfileItems.Settings]);
        public void clickTopMenu() => ClickElementBy(topProfileMunuLink);
        public SignInPage clickLogOutButton() => ClickIWebElement<SignInPage>(GetlistOfElements(topProfileMenu)[(int)TopProfileItems.Log_out]);
    }
}
