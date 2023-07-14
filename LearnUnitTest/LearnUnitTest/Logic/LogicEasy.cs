using LearnUnitTest.DNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LearnUnitTest.Logic
{
    public class LogicEasy
    {
        private readonly IDNS _dNS;
        public LogicEasy(IDNS dNS)
        {
            _dNS = dNS;   
        }
        public string SayHi()
        {
            var dnsSuccess = _dNS.SendDNS();
            if(dnsSuccess)
            {
                return "Hello : baby";
            }
            else
            {
                return "Opps: fail ";
            }    
        }
        public int SumTwoNum(int num1, int num2)
        {
            return num1 + num2;
        }
        public DateTime DateNow()
        {
            return DateTime.Now;
        }
        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }
        public IEnumerable<PingOptions> GetPingOptionsList()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
            };
            return pingOptions;
        }
    }
}
