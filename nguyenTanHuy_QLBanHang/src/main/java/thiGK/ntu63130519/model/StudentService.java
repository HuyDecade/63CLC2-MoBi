package thiGK.ntu63130519.model;

import java.util.ArrayList;
import java.util.List;

public class StudentService {
    private List<Student> students;

   
    public StudentService() {
        students = new ArrayList<>();
        
        students.add(new Student("SV001", "tan huy", 8.5));
        students.add(new Student("SV002", "huy hanh", 7.8));
        students.add(new Student("SV003", "huy tan", 9.2));
    }

    
    public List<Student> getAllStudents1() {
        return students;
    }

    
    public Student findStudentById(String id) {
        for (Student student : students) {
            if (student.getId().equals(id)) {
                return student;
            }
        }
        return null; 
    }

    
    public void addStudent(Student student) {
        students.add(student);
    }


	public List<Student> getAllStudents() {
		// TODO Auto-generated method stub
		return null;
	}




}
