using System;
using System.Collections.Generic;
using System.Text;

namespace Bushuosx.ObserverPattern
{
    public class PubliserMessage
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
