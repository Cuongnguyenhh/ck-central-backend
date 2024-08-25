using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StackExchange.Redis.Role;

namespace CK.Central.Core.Constants
{
    public class ApiSubdomainRoute
    {
        public const string ckcms = "central-cms-master";
        public const string ckcmsauth = "central-cms-auth";
        public const string ckcmsgenerate = "central-cms-generate";
        public const string ckcmshealthcheck = "central-cms-healthcheck";
        public const string ckcmsjob = "central-cms-job";
        public const string ckcmsmasterdata = "central-cms-masterdata";
        public const string ckcmsportal = "central-cms-portal";
        
        public const string ckgrabmart = "central-grabmart-master";
        public const string ckgrabmartauth = "central-grabmart-auth";
        public const string ckgrabmartcampaign = "central-grabmart-campaign";
        public const string ckgrabmarthealthcheck = "central-grabmart-healthcheck";
        public const string ckgrabmartjob = "central-grabmart-job";
        public const string ckgrabmartmenu = "central-grabmart-menu";
        public const string ckgrabmartorder = "central-grabmart-order";
        public const string ckgrabmartstore = "central-grabmart-store";

        public const string ckpos = "central-pos-master";
        public const string ckposgrabmartorder = "central-pos-grabmart-order";
        public const string ckposgrabmartstock = "central-pos-grabmart-stock";
        public const string ckposhealthcheck = "central-pos-healthcheck";
        public const string ckposjob = "central-pos-job";
    }
}
