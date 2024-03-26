package thiGK.ntu63130519.Controller;


import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

public class HomeController {
	 @GetMapping("/")
	    public String index(Model model) {
	        // Mock data for students
	        List<Student> students = new ArrayList<>();
	        students.add(new Student("Nguyen", "Huy", "63130519", "CNTT", "NTU", "f1.jpg"));
	        model.addAttribute("students", students);
	        return "index";
	    }
}
