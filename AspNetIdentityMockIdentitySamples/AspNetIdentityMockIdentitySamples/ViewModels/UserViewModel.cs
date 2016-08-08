using System.Collections.Generic;

namespace AspNetIdentityMockIdentitySamples.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<string> Roles { get; set; }
    }
}