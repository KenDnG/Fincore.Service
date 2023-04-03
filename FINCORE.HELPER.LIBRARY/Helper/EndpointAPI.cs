using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.HELPER.LIBRARY.Helper
{
    public static class EndpointAPI
    {
        public struct Endpoint
        {
            //RapindoUAT
            public static readonly string RAPINDOUATURL = "https://api.mcf.co.id:5011/";
            //RAPINDOLIVE
            public static readonly string RAPINDOLIVEURL = "https://api.mcf.co.id:5010/";
        }
        public struct Token
        {
            //rapindouat
            public static readonly string TokenCodeRapindoMAFUAT = "73feef94a47465e2e7e5cd523d9f10f1";
            public static readonly string TokenCodeRapindoMCFUAT = "1bbdf6068b904455253259268669b922";
            //rapindolive
            public static readonly string TokenCodeRapindoMAFLive = "f5545b6e20a5b2af74a92506b286f62b";
            public static readonly string TokenCodeRapindoMCFLive = "33a8ff3f84c8741d75e9dacaefb71f97";
        }
    }
}
