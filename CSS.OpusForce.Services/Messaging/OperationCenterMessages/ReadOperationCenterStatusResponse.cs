﻿using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ReadOperationCenterStatusResponse : ResponseBase
    {
        public OperationCenterStatusView OperationCenterStatus { get; set; }
    }
}
