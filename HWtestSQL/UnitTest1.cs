using System;
using Xunit;
using System.Data.SqlTypes;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;



namespace HWtestSQL
{
    public class UnitTest1
    {
        [Fact]
        public void TestBroshkinaMusic()
        {
            string conectionString = @"Data Source=C:/Users/Пользователь/Desktop/db/school.db";
            string commandData = "SELECT music FROM progress WHERE pupil_id =(SELECT pupil_id FROM" +
                " pupils WHERE last_name_pupil = 'Broshkina') ";

            object actual = Convert.ToInt32 (SQLHelp.SQLiteData(conectionString, commandData));
            object expected = 12;
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void TestSalaryTeacherMin()
        {
            string conectionString = @"Data Source=C:/Users/Пользователь/Desktop/db/school.db";
            string commandData = "SELECT salary FROM teachers WHERE school_id = (SELECT school_id FROM " +
                "pupils WHERE pupil_id=(SELECT pupil_id FROM progress WHERE algebra=(SELECT max(algebra)" +
                " FROM progress))) ORDER BY salary";

            object actual = Convert.ToInt32(SQLHelp.SQLiteData(conectionString, commandData));
            object expected = 4800;
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void TestPhoneTeachers()
        {
            string conectionString = @"Data Source=C:/Users/Пользователь/Desktop/db/school.db";
            string commandData = "SELECT phone FROM teachers WHERE first_name = 'Oksana' AND school_id=(SELECT" +
                " school_id FROM pupils WHERE pupil_id=(SELECT pupil_id FROM progress WHERE english = 11))";

            object actual = SQLHelp.SQLiteData(conectionString, commandData);
            object expected = 380506352897;
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void TestSecuritySearch()
        {
            string conectionString = @"Data Source=C:/Users/Пользователь/Desktop/db/school.db";
            string commandData = "SELECT security FROM schools WHERE school_id=(SELECT school_id FROM" +
                " teachers WHERE teacher_id=(SELECT teacher_id FROM pupils WHERE pupil_id =(SELECT " +
                "pupil_id FROM progress WHERE music=(SELECT min(music) FROM progress))))";

            object actual = SQLHelp.SQLiteData(conectionString, commandData);
            object expected = "Guard";
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void TestDateOfBirth()
        {
            string conectionString = @"Data Source=C:/Users/Пользователь/Desktop/db/school.db";
            string commandData = "SELECT date_of_birth FROM pupils WHERE teacher_id=(SELECT teacher_id" +
                " FROM teachers WHERE school_id=(SELECT school_id FROM schools WHERE security " +
                "like '%io%' AND region like '%ustr%') AND phone like '%38073%')";

            object actual = SQLHelp.SQLiteData(conectionString, commandData);
            object expected = "20.03.2006";
            Assert.Equal(actual, expected);
        }
    }
}
