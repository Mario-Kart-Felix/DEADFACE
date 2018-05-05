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
                new FoafFinder(),
            };
        }

        public override void Find()
        {
            var res = new VkApi.users_search
            {
                q = $"{Input.name.firstName}%20{Input.name.lastName}",
                city = 49,
                birth_day = Input.passport.birthDate.Day,
                birth_month = Input.passport.birthDate.Month
            }.Go();
            if (res["count"] + "" == "0")
                IsReliable = null;
            else
            {
                Output = new VkProfile(res["items"][0]);
                GetF<VkWallFinder>().Input = Output;
                GetF<VkGroupsFinder>().Input = Output;
                GetF<VkFriendsFinder>().Input = Output;
                GetF<FoafFinder>().Input = Output.id;
                base.Find();
            }
        }

        public override string Name { get; } = "Профиль ВКонтакте";
    }
}
