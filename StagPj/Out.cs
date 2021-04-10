using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StagPj
{
    public class Out : Action
    {
        public Category cat;
        public Out() : base()
        {
            cat = new Category();
        }
        public float losses()
        {
            
            return 0;
        }
    }
}