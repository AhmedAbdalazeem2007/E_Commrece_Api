﻿namespace Api_PL.Helpers
{
    public class JWT
    {
        public string Key {  get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public DateTime Duration {  get; set; }
    }
}
