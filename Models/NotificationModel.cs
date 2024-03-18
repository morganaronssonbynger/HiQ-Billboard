using System;
namespace Billboard.Models
{
    public class NotificationModel
    {
        public NotificationModel()
        {
        }
        public class Assignment
        {
            public string? start { get; set; }
            public string? end { get; set; }
            public string? role { get; set; }
            public string? seller { get; set; }
            public string? customer { get; set; }
        }

        public class Vacation
        {
            public string? type { get; set; }
            public string? status { get; set; }
            public string? start { get; set; }
            public string? end { get; set; }
        }

        public class Value
        {
            public string? id { get; set; }
            public string? birthday { get; set; }
            public string? email { get; set; }
            public string? lastName { get; set; }
            public string? firstName { get; set; }
            public string? teamId { get; set; }
            public string? firstDayOfEmployment { get; set; }
            public string? companyId { get; set; }
            public string? regionId { get; set; }
            public string? countryId { get; set; }
            public List<Assignment> assignments { get; set; }
            public List<Vacation> vacations { get; set; }
        }

        public class NotificationContainer
        {
            public string? OdataContext { get; set; }
            public List<Value> value { get; set; }
            //This list contains all employees
        }



    }
}



