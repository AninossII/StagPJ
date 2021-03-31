using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StagPj
{
    public class In:Action
    {
        public Sour sour;
        public In() : base()
        {
            sour = new Sour();
        }
        public float Add()
        {
            return 0;
        }
    }
}