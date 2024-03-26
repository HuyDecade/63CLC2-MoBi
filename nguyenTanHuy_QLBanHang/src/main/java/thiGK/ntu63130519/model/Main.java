package thiGK.ntu63130519.model;

import java.util.List;

public class Main {
    public static void main(String[] args) {
       
        StudentService studentService = new StudentService();

        
        List<Student> allStudents = studentService.getAllStudents();
        System.out.println("All Students:");
        for (Student student : allStudents) {
            System.out.println("ID: " + student.getId() + ", Name: " + student.getName() + ", Cumulative Score: " + student.getCumulativeScore());
        }

       
        String searchId = "SV002";
        Student foundStudent = studentService.findStudentById(searchId);
        if (foundStudent != null) {
            System.out.println("\nStudent found with ID " + searchId + ":");
            System.out.println("Name: " + foundStudent.getName() + ", Cumulative Score: " + foundStudent.getCumulativeScore());
        } else {
            System.out.println("\nStudent with ID " + searchId + " not found.");
        }

        
        Student newStudent = new Student("SV004", "van thanh", 8.9);
        studentService.addStudent(newStudent);
        System.out.println("\nNew student added:");
        System.out.println("ID: " + newStudent.getId() + ", Name: " + newStudent.getName() + ", Cumulative Score: " + newStudent.getCumulativeScore());
    }
}

