package thiGK.ntu63130519.Controller;

public class Student {

	
	    private String firstName;
	    private String lastName;
	    private String className;
	    private String department;
	    private String university;
	    private String imageUrl;

	    public Student(String firstName, String lastName, String className, String department, String university, String imageUrl) {
	        this.firstName = firstName;
	        this.lastName = lastName;
	        this.className = className;
	        this.department = department;
	        this.university = university;
	        this.imageUrl = imageUrl;
	    }

	    

	    public String getFirstName() {
	        return firstName;
	    }

	    public void setFirstName(String firstName) {
	        this.firstName = firstName;
	    }

	    public String getLastName() {
	        return lastName;
	    }

	    public void setLastName(String lastName) {
	        this.lastName = lastName;
	    }

	    public String getClassName() {
	        return className;
	    }

	    public void setClassName(String className) {
	        this.className = className;
	    }

	    public String getDepartment() {
	        return department;
	    }

	    public void setDepartment(String department) {
	        this.department = department;
	    }

	    public String getUniversity() {
	        return university;
	    }

	    public void setUniversity(String university) {
	        this.university = university;
	    }

	    public String getImageUrl() {
	        return imageUrl;
	    }

	    public void setImageUrl(String imageUrl) {
	        this.imageUrl = imageUrl;
	    }
	}


