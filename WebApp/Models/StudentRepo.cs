namespace WebApp.Models
{
    public class StudentRepo
    {
        public static List<StudentModel> _students = new List<StudentModel>();
        //{
        //    new(){StudentId = 1, StudentName="Test", StudentEmail="test@test.com", StudentPhone=6666677777,StudentAddress="Test City"}
        //};
        public static List<StudentModel> GetStudents() => _students;
        public static StudentModel? GetStudentById(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
                return null;
            else
                return new StudentModel
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    StudentEmail = student.StudentEmail,
                    StudentPhone = student.StudentPhone,
                    StudentAddress = student.StudentAddress
                };
        }
        public static void AddStudents(StudentModel model)
        {
            var _studentId = 0;
            if (_students.Count > 0)
                _studentId = _students.Max(s => s.StudentId);
            model.StudentId = _studentId + 1;
            _students.Add(model);
        }
        public static void UpdateStudents(int id, StudentModel model)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
                return;
            else
            {
                student.StudentName = model.StudentName;
                student.StudentEmail = model.StudentEmail;
                student.StudentPhone = model.StudentPhone;
                student.StudentAddress = model.StudentAddress;
            }
        }
        public static void DeleteStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student == null) return;
            else
            {
                _students.Remove(student);
            }
        }
    }
}
