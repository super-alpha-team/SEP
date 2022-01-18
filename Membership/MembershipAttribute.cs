using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.DataAnnotations;


namespace SEP.Membership
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]

    public class MembershipAttribute: ValidationAttribute
    {
        public MembershipAttribute(string v) => acceptedRole = v;

        public string acceptedRole { set; get; }

        public override bool IsValid(object value)
        {
            // check the current user role equal acceptedRole

            return true;
        }
    }
}
