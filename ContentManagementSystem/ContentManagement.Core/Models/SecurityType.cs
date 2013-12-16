using System;
using System.Collections.Generic;

namespace ContentManagement.Models
{
    public partial class SecurityType
    {
        public SecurityType()
        {
            this.ContentSecurities = new List<ContentSecurity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ContentSecurity> ContentSecurities { get; set; }
    }
}
