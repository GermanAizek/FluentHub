﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHub.Octokit.Models.ActivityPayloads
{
    public class ForkEventPayload
    {
        public OctokitOriginal.Repository Forkee { get; set; }
    }
}
