using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StagPj
{
    public class Out:Action
    {
        public Category category;
        public Out() : base()
        {
            category = new Category();
        }
        public float losses()
        {
            return 0;
        }
    }
}