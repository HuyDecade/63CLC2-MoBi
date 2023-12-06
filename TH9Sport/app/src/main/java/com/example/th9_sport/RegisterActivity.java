package com.example.th9_sport;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class RegisterActivity extends AppCompatActivity {

    private EditText editTextFullName;
    private EditText editTextEmail;
    private EditText editTextPassword;
    private Button buttonRegister;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        editTextFullName = findViewById(R.id.editTextFullName);
        editTextEmail = findViewById(R.id.editTextEmail);
        editTextPassword = findViewById(R.id.editTextPassword);
        buttonRegister = findViewById(R.id.buttonRegister);

        buttonRegister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Xử lý logic đăng ký ở đây
                String fullName = editTextFullName.getText().toString();
                String email = editTextEmail.getText().toString();
                String password = editTextPassword.getText().toString();

                if (isValidRegistration(fullName, email, password)) {
                    // Đăng ký thành công
                    showToast("Registration successful");
                } else {
                    // Đăng ký thất bại
                    showToast("Invalid registration information");
                }
            }
        });
    }

    private boolean isValidRegistration(String fullName, String email, String password) {
        // Thực hiện kiểm tra đăng ký ở đây (ví dụ: kiểm tra tính hợp lệ của email, độ dài mật khẩu, v.v.)
        // Trong ví dụ này, chúng ta giả sử đăng ký luôn thành công
        return true;
    }

    private void showToast(String message) {
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show();
    }
}
