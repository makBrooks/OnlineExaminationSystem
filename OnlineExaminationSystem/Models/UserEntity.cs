using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystem.Models
{
    public class UserEntity
    {
        public string userid { get; set; }
        public string userpassword { get; set; } = "";
        public string username { get; set; }
        public string userphone { get; set; }
        public string useremail { get; set; }
        public int usertechnology { get; set; }
        public int usersubject { get; set; }
        public string userstatus { get; set; }
        [NotMapped]
        public string techname { get; set; }
        [NotMapped]
        public string subname { get; set; }
        [NotMapped]
        public string connfermpassword { get; set; }
        [NotMapped]
        public int Appeared { get; set; }
        [NotMapped]
        public int Mark { get; set; }
        [NotMapped]
        public int noofque { get; set; }
        [NotMapped]
        public string? doe { get; set; } = "";

    }
    public class ResultDetails
    {
        public int? slno { get; set; }

        public string? userid { get; set; }
        public string? doe { get; set; } = "";
        public int? qid { get; set; }
        public string optchoose { get; set; } = "";
        public string rstatus { get; set; } = "";
        public string? dstatus { get; set; }


    }
    public class TechnologyMaster
    {
        public int techid { get; set; } = 0;

        public string techname { get; set; } = null;
    }
    public class SubjectMaster
    {
        public int subid { get; set; } = 0;
        public int techid { get; set; } = 0;
        public string? subname { get; set; }
        [NotMapped]
        public string? techname { get; set; }
    }
    public class SetupMaster
    {
        public int noofque { get; set; }
        public int timeinminute { get; set; }
        public string rules { get; set; }
    }
    public class QuestionMaster
    {
        public int slno { get; set; } = 0;
        public int? techid { get; set; }
        public int? subid { get; set; }
        public string? question { get; set; }
        public string? opt1 { get; set; }
        public string? opt2 { get; set; }
        public string? opt3 { get; set; }
        public string? opt4 { get; set; }
        public string? ans { get; set; }
        [NotMapped]
        public string techname { get; set; }
        [NotMapped]
        public string subname { get; set; }
        [NotMapped]
        public int id { get; set; }
    }
}
