using System;
using System.Linq;

namespace FrameworkLib_Common.Model_Renamed;

public class JobDrawback
{
    public int JobId { get; set; }
    public int DrawbackId { get; set; }

    public virtual Job Job { get; set; } = null!;
    public virtual Drawback Drawback { get; set; } = null!;
}
