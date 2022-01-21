using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.Membership
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class SepAttribute : Attribute // có thể đặt tên Mota thay cho MotaAttribute
    {
        // Phương thức khởi tạo
        public SepAttribute(string v) {
            Role = v;
            IsAllow = Member.validateWithRole(Role);
        }

        public bool IsAllow { set; get; }
        public string Role { set; get; }
    }
}
