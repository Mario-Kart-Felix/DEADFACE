using FaceFinder.Data;

namespace FaceFinder.Finders
{
    public class VkFinder : AbstractFinder<InputData, VkProfile>
    {
        public VkFinder()
        {
            Children = new AbstractFinder[]
            {
                new VkWallFinder(),
                new VkGroupsFinder(),
                new VkFriendsFinder(), 
            };
        }
        private const string vk_token = "2010037d3a49142291a1a4938b53a6988f6fea2b8a8efd33c1c45fe33e7ad72764a28ff6e54f9c4417260";

        private string url =>
            $"https://api.vk.com/method/users.search?access_token={vk_token}&v=5.8&q={Input.name.firstName}%20{Input.name.lastName}&city=49&birth_day={Input.passport.birthDate.Day}&birth_month={Input.passport.birthDate.Month}";

        public override void Find()
        {
            var res = SimpleGet.GetJson(url)["response"];
            if (res["count"] + "" == "0")
                IsReliable = null;
            else
            {
                Output = new VkProfile(res["items"][0]);
                GetF<VkWallFinder>().Input = Output;
                base.Find();
            }
        }

        public override string Name { get; } = "Профиль ВКонтакте";
    }
}
