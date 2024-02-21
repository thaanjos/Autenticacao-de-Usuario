namespace projeto_asp_net_cor
{
    public class MyUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string PassWordHash { get; set; }

        public virtual string PlaceholderText { get; set; }

    }
}
