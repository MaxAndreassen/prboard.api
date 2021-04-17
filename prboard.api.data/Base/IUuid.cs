using System;

namespace prboard.api.data.Base
{
    public interface INullableUuid
    {
        Guid? Uuid { get; set; }
    }
}