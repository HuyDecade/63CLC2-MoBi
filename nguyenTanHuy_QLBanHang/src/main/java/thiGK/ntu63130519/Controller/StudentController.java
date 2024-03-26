package thiGK.ntu63130519.Controller;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

import thiGK.ntu63130519.model.StudentService;

@Controller
public class StudentController {
    private final StudentService studentService;

    public StudentController(StudentService studentService) {
        this.studentService = studentService;
    }

    @GetMapping("/students")
    public String getAllStudents(Model model) {
        model.addAttribute("students", studentService.getAllStudents());
        model.addAttribute("newStudent", new Student(null, null, null, null, null, null)); // Tạo một đối tượng Student mới để binding với form
        return "student-list";
    }

    @PostMapping("/students/add")
    public String addStudent(@ModelAttribute("newStudent") thiGK.ntu63130519.model.Student newStudent) {
        studentService.addStudent(newStudent);
        return "redirect:/students";
    }

    @GetMapping("/students/search")
    public String searchStudent(@RequestParam("id") String id, Model model) {
        thiGK.ntu63130519.model.Student student = studentService.findStudentById(id);
        if (student != null) {
            model.addAttribute("foundStudent", student);
        } else {
            model.addAttribute("errorMessage", "Student not found");
        }
        return "student-list";
    }
}
